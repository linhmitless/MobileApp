﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Models;
using Week2.ViewModels;
using Week2.Controllers;
using Week2.Views;
using Week2.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Week2.Views.Character;


namespace Week2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterEditPage : ContentPage
    {
        // ReSharper disable once NotAccessedField.Local
        private CharacterDetailViewModel _viewModel;

        public Week2.Models.Character Data { get; set; }

        public CharacterEditPage(CharacterDetailViewModel viewModel)
        {
            // Save off the item
            Data = viewModel.Data;
            viewModel.Title = "Edit " + viewModel.Title;

            InitializeComponent();


            // Set the data binding for the page
            BindingContext = _viewModel = viewModel;
        }

        public async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "EditData", Data);

            // removing the old ItemDetails page, 2 up counting this page
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);

            // Add a new items details page, with the new Item data on it
            await Navigation.PushAsync(new CharacterDetailPage(new CharacterDetailViewModel(Data)));

            // Last, remove this page
            Navigation.RemovePage(this);
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private void Value_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            AgeValue.Text = String.Format("{0}", e.NewValue);
        }
    }
}