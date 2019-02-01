using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Models;
using Week2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Week2.Views.Items
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDeletePage : ContentPage
    {
        // ReSharper disable once NotAccessedField.Local
        private ItemDetailViewModel viewModel;

        public Item Data { get; set; }

        public ItemDeletePage(ItemDetailViewModel sentViewModel)
        {
            // Save off the item
            Data = sentViewModel.Data;
            sentViewModel.Title = "Delete " + sentViewModel.Title;

            InitializeComponent();

            // Set the data binding for the page
            BindingContext = viewModel = sentViewModel;
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteData", Data);

            // Remove Item Details Page manualy
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);

            await Navigation.PopAsync();
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}