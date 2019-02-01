using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Week2.Models;
using Week2.Controllers;

namespace Week2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Item Data { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Data = new Item
            {
                Name = "Item name",
                Description = "This is an item description.",
                ID = Guid.NewGuid().ToString(),
                Value = 1,
                ImageURI = ItemsController.DefaultImageURI
        };

            //BindingContext = this;
            AttributePicker.SelectedItem = Data.Attribute.ToString();
        }
        private async void Save_Clicked(object sender, EventArgs e)
        {
            // If the image in teh data box is empty, use the default one..
            if (string.IsNullOrEmpty(Data.ImageURI))
            {
                Data.ImageURI = ItemsController.DefaultImageURI;
            }

            MessagingCenter.Send(this, "AddData", Data);
            await Navigation.PopAsync();
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