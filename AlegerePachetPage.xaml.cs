using PensiuneaMea.Models;
namespace PensiuneaMea;

public partial class AlegerePachetPage : ContentPage
{
	public AlegerePachetPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var alegerePachet = (AlegerePachet)BindingContext;
        await App.Database.SaveAlegerePachetAsync(alegerePachet);
        await Navigation.PopAsync();
    }

    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var alegerePachet = (AlegerePachet)BindingContext; var address = alegerePachet.Adress; var locations = await Geocoding.GetLocationsAsync(address);
        var options = new MapLaunchOptions { Name = "Sejurul meu la Valea Morii" };
        var location = locations?.FirstOrDefault();
        // var myLocation = await Geolocation.GetLocationAsync(); var myLocation = new Location(46.7731796289, 23.6213886738);
        await Map.OpenAsync(location, options);
    }
}