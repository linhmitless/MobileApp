using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Week2.Models;
using Week2.Views;
using Week2.ViewModels;

namespace Week2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterPage : ContentPage
    {
        private CharactersViewModel _viewModel;

        public CharacterPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = CharactersViewModel.Instance;
        }

        private async void OnCharacterSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var data = args.SelectedItem as Week2.Models.Character;
            if (data == null)
                return;

            await Navigation.PushAsync(new Week2.Views.Character.CharacterDetailPage(new CharacterDetailViewModel(data)));

            // Manually deselect Character.
            //CharacterListView.SelectedCharacter = null;
        }

        private async void AddCharacter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewCharacterPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = null;

            if (ToolbarItems.Count > 0)
            {
                ToolbarItems.RemoveAt(0);
            }

            InitializeComponent();

            if (_viewModel.Dataset.Count == 0)
            {

                _viewModel.LoadDataCommand.Execute(null);
            }
            else if (_viewModel.NeedsRefresh())
            {
                _viewModel.LoadDataCommand.Execute(null);
            }

            BindingContext = _viewModel;
        }
    }
}