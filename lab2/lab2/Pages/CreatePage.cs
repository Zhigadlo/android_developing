using lab2.Models;
using System.Collections.ObjectModel;

namespace lab2.Pages;

public class CreatePage : ContentPage
{
    private ObservableCollection<Product> _productList;
    private Label _label = new Label() { FontSize = 22 };
    private Entry _nameEntry;
    private Entry _priceEntry;
    private Entry _producerEntry;
    private Entry _upcEntry;
    private Entry _quantityEntry;
    private DatePicker _datePicker;

    public CreatePage(ObservableCollection<Product> productList)
    {
        _productList = productList;
        _label.Text = "Добавление продукта";
        Button backButton = new Button
        {
            Text = "Назад",
            FontSize = 16,
            BorderWidth = 1,
            BackgroundColor = Colors.Purple,
            TextColor = Colors.White,
            HorizontalOptions = LayoutOptions.End,
            VerticalOptions = LayoutOptions.Start
        };
        backButton.Clicked += ToMainPage;

        Button addButton = new Button
        {
            Text = "Добавить",
            FontSize = 16,
            BorderWidth = 1,
            BackgroundColor = Colors.Purple,
            TextColor = Colors.White,
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Start
        };
        addButton.Clicked += AddProduct;

        _nameEntry = new Entry()
        {
            Placeholder = "Введите название",
            FontSize = 22,
            MaxLength = 20
        };

        _producerEntry = new Entry()
        {
            Placeholder = "Введите производителя",
            FontSize = 22,
            MaxLength = 20,
            Keyboard = Keyboard.Text
        };

        _upcEntry = new Entry()
        {
            Placeholder = "Введите UDC",
            FontSize = 22,
            MaxLength = 20,
            Keyboard = Keyboard.Text
        };

        _priceEntry = new Entry()
        {
            Placeholder = "Введите цену",
            FontSize = 22,
            MaxLength = 20,
            Keyboard = Keyboard.Numeric
        };

        _quantityEntry = new Entry()
        {
            Placeholder = "Введите количество",
            FontSize = 22,
            MaxLength = 20,
            Keyboard = Keyboard.Numeric
        };

        Label dateLabel = new Label()
        {
            Text = "Выберите срок годности"
        };
        _datePicker = new DatePicker()
        {
            Date = DateTime.Now
        };
        Content = new StackLayout { Children = { _label, _nameEntry, _priceEntry, _producerEntry, _upcEntry, _quantityEntry, dateLabel, _datePicker, addButton, backButton }, Padding = 7 };
    }

    private async void ToMainPage(object? sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private void AddProduct(object? sender, EventArgs e)
    {
        var name = _nameEntry.Text;
        var producer = _producerEntry.Text;
        var price = double.Parse(_priceEntry.Text);
        var quantity = int.Parse(_quantityEntry.Text);
        var upc = _upcEntry.Text;
        var expireDate = _datePicker.Date;

        Product newProduct = new Product(_productList.Last().Id+1, name, upc, producer, price, expireDate, quantity);
        _productList.Add(newProduct);
        ToMainPage(sender, e);
    }
}