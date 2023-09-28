namespace lab1;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		if(NameLabel.IsVisible)
			NameLabel.IsVisible = false;
		else
			NameLabel.IsVisible = true;
	}
}

