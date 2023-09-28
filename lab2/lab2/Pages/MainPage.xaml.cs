﻿using lab2.Models;
using lab2.Pages;
using Microsoft.Maui.Controls;

namespace lab2;

public partial class MainPage : ContentPage
{
	public List<Product> Products = new();
    private Label _selectedItemHeader = new Label { FontSize = 18 };
    private ListView _productsListView;
    private Button _editProductButton;
    private Button _addProductButton;
    public MainPage()
	{
		Products = new List<Product>()
		{
			new Product(1, "Apple", "kdjkj321234", "AppleProducer", 5.99, new DateTime(2024, 3, 23), 25),
			new Product(1, "Milk", "ab39803z", "MilkProducer", 12.59, new DateTime(2023, 11, 15), 30),
			new Product(1, "Cookie", "13fkllf1234", "CookieProducer", 34.29, new DateTime(2024, 3, 23), 25),
			new Product(1, "Banana", "123qwe", "BananaProducer", 13.45, new DateTime(2024, 3, 23), 25)
		};
        _productsListView = new ListView();
        // определяем источник данных
        _productsListView.ItemsSource = Products;

        // определяем шаблон данных
        _productsListView.ItemTemplate = new DataTemplate(() =>
        {
            Label nameLabel = new Label { FontSize = 16 };
            nameLabel.SetBinding(Label.TextProperty, "Name");

            Label ageLabel = new Label { FontSize = 14 };
            ageLabel.SetBinding(Label.TextProperty, "Price");

            // создаем объект ViewCell.
            return new ViewCell
            {
                View = new StackLayout
                {
                    Padding = new Thickness(0, 5),
                    Orientation = StackOrientation.Vertical,
                    Children = { nameLabel, ageLabel }
                }
            };
        });

        _editProductButton = new Button
        {
            Text = "Изменить",
            FontSize = 16,
            BorderWidth = 1,
            BackgroundColor = Colors.Purple,
            TextColor = Colors.White,
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Start,
            IsVisible = false
        };
        _editProductButton.Clicked += ToEditPage;
        _addProductButton = new Button
        {
            Text = "Добавить",
            FontSize = 16,
            BorderWidth = 1,
            BackgroundColor = Colors.Purple,
            TextColor = Colors.White,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Start
        };
        _addProductButton.Clicked += ToAddPage;
        _productsListView.ItemSelected += ProductsListView_ItemSelected;
        Content = new StackLayout { Children = { _selectedItemHeader, _editProductButton, _productsListView, _addProductButton }, Padding = 7 };

	}

    private void ProductsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        _editProductButton.IsVisible = true;
        var selectedProduct = e.SelectedItem as Product;
        if (selectedProduct != null)
            _selectedItemHeader.Text = selectedProduct.ToString();
    }

    private async void ToEditPage(object? sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new EditPage(_productsListView.SelectedItem as Product));
    }

    private async void ToAddPage(object? sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new CreatePage(Products));
    }
}

