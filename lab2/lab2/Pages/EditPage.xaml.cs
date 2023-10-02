using lab2.Models;

namespace lab2.Pages;

public partial class EditPage : ContentPage
{
	private Product _productForEdit;
	private Label _label = new Label() { FontSize = 18 };
    private Entry _nameEntry;
    private Entry _priceEntry;
    private Entry _producerEntry;
    private Entry _upcEntry;
    private Entry _quantityEntry;
    private DatePicker _datePicker;

	public EditPage(Product productForEdit)
	{
		_productForEdit = productForEdit;
		_label.Text = "Изменение продукта\n" + productForEdit.ToString();
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

        Button editButton = new Button
        {
            Text = "Изменить",
            FontSize = 16,
            BorderWidth = 1,
            BackgroundColor = Colors.Purple,
            TextColor = Colors.White,
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Start
        };
        editButton.Clicked += ProductEdit;

        _nameEntry = new Entry()
        {
            FontSize = 22,
            MaxLength = 20,
            Text = _productForEdit.Name,
            IsEnabled = false
        };

        _producerEntry = new Entry()
        {
            Placeholder = "Введите производителя",
            FontSize = 22,
            MaxLength = 20,
            Keyboard = Keyboard.Text,
            Text = _productForEdit.Producer
        };

        _upcEntry = new Entry()
        {
            Placeholder = "Введите UDC",
            FontSize = 22,
            MaxLength = 20,
            Keyboard = Keyboard.Text,
            Text = _productForEdit.UPC
        };

        _priceEntry = new Entry()
        {
            Placeholder = "Введите цену",
            FontSize = 22,
            MaxLength = 20,
            Keyboard = Keyboard.Numeric,
            Text = _productForEdit.Price.ToString()
        };

        _quantityEntry = new Entry()
        {
            Placeholder = "Введите количество",
            FontSize = 22,
            MaxLength = 20,
            Keyboard = Keyboard.Numeric,
            Text = _productForEdit.Quantity.ToString()
        };

        Label dateLabel = new Label()
        {
            Text = "Выберите срок годности"
        };
        _datePicker = new DatePicker()
        {
            Date = _productForEdit.ExpireDate
        };
        Content = new StackLayout { Children = { _label, _nameEntry, _priceEntry, _producerEntry, _upcEntry, _quantityEntry, dateLabel, _datePicker, editButton, backButton }, Padding = 7 };
	}

    private async void ToMainPage(object? sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private void ProductEdit(object? sender, EventArgs e)
    {
        _productForEdit.Name = _nameEntry.Text;
        _productForEdit.Producer = _producerEntry.Text;
        _productForEdit.Price = double.Parse(_priceEntry.Text);
        _productForEdit.Quantity = int.Parse(_quantityEntry.Text);
        _productForEdit.UPC = _upcEntry.Text;
        _productForEdit.ExpireDate = _datePicker.Date;
       
        ToMainPage(sender, e);
    }
}