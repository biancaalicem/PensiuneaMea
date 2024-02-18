using PensiuneaMea.Models;

namespace PensiuneaMea;

public partial class CaracteristiciPachetPage : ContentPage
{
    PachetSejur sl;
	public CaracteristiciPachetPage(PachetSejur slist)
	{
		InitializeComponent();
        sl = slist;
	}
    async void OnSaveButtonClicked(object sender, EventArgs e) 
    {
        var caracteristiciPachet = (CaracteristiciPachet)BindingContext; 
        await App.Database.SaveCaracteristiciPachetAsync(caracteristiciPachet);
        listView.ItemsSource = await App.Database.GetCaracteristiciPacheteAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e) 
    { 
        var caracteristiciPachet= (CaracteristiciPachet)BindingContext; 
        await App.Database.DeleteCaracteristiciPachetAsync(caracteristiciPachet);
        listView.ItemsSource = await App.Database.GetCaracteristiciPacheteAsync(); }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        CaracteristiciPachet p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as CaracteristiciPachet;
            var lp = new ListCaracteristiciPachet()
            {
                PachetSejurID = sl.ID,
                CaracteristiciPachetID = p.ID
            };
            await App.Database.SaveListCaracteristiciPachetAsync(lp);
            p.ListCaracteristiciPachete = new List<ListCaracteristiciPachet> { lp };
            await Navigation.PopAsync();
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetCaracteristiciPacheteAsync();
    }
}
