﻿using Shopper;
using Shopper.Models;
using Xamarin.Forms;

namespace Shopper
{
    public class ProductPageCS : ContentPage
    {
        public ProductPageCS()
        {
            Title = "Product";

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            var notesEntry = new Entry();
            notesEntry.SetBinding(Entry.TextProperty, "Notes");

            var doneSwitch = new Switch();
            doneSwitch.SetBinding(Switch.IsToggledProperty, "Bought");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var product = (Product)BindingContext;
                await App.ProductDataBase.SaveItemAsync(product);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) =>
            {
                var product = (Product)BindingContext;
                await App.ProductDataBase.DeleteItemAsync(product);
                await Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Name" },
                    nameEntry,
                    new Label { Text = "Notes" },
                    notesEntry,
                    new Label { Text = "Bought" },
                    doneSwitch,
                    saveButton,
                    deleteButton,
                    cancelButton
                }
            };
        }
    }
}
