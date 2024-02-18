using PensiuneaMea.Models;
namespace PensiuneaMea;

public partial class AlegerePachetEntryPage : ContentPage
{
	public AlegerePachetEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetAlegerePacheteAsync();
    }
    async void OnAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AlegerePachetPage
        {
            BindingContext = new AlegerePachet()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null) { await Navigation.PushAsync(new AlegerePachetPage { BindingContext = e.SelectedItem as AlegerePachet }); }
    }
}