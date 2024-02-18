using PensiuneaMea.Models;

namespace PensiuneaMea;

public partial class ListEntryPage : ContentPage
{
	public ListEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetPacheteSejurAsync();
    }
    async void OnPachetSejurAddedClicked(object sender, EventArgs e) { await Navigation.PushAsync(new ListPage { BindingContext = new PachetSejur() }); }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null) { await Navigation.PushAsync(new ListPage { BindingContext = e.SelectedItem as PachetSejur }); }
    }
}