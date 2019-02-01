using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Models;
using Week2.ViewModels;
using Week2.Controllers;
using Week2.Views.Items;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Week2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemEditPage : ContentPage
    {
        // ReSharper disable once NotAccessedField.Local
        private ItemDetailViewModel viewModel;

        // The data returned from the edit.
        public Item Data { get; set; }

        // The constructor takes a View Model
        // It needs to set the Picker values after doing the bindings.
        public ItemEditPage(ItemDetailViewModel sentViewModel)
        {
            // Save off the item
            Data = sentViewModel.Data;

            sentViewModel.Title = "Edit " + sentViewModel.Title;
            InitializeComponent();

            // Set the data binding for the page
            BindingContext = viewModel = sentViewModel;

            //Need to make the SelectedItem a string, so it can select the correct item.
            //AttributePicker.SelectedItem = Data.Attribute.ToString();

        }

        // Save on the Tool bar
        private async void Save_Clicked(object sender, EventArgs e)
        {
            // If the image in teh data box is empty, use the default one..
            if (string.IsNullOrEmpty(Data.ImageURI))
            {
                Data.ImageURI = ItemsController.DefaultImageURI;
            }

            MessagingCenter.Send(this, "EditData", Data);

            // removing the old ItemDetails page, 2 up counting this page
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);

            // Add a new items details page, with the new Item data on it
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(Data)));

            // Last, remove this page
            Navigation.RemovePage(this);
        }

        // Cancel and go back a page in the navigation stack
        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // The stepper function for Value
        void Value_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            ValueValue.Text = String.Format("{0}", e.NewValue);
        }
    }
}