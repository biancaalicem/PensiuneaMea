using PensiuneaMea.Models;

namespace PensiuneaMea;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e) 
	{ 
		var slist = (PachetSejur)BindingContext;
		slist.Date = DateTime.UtcNow; 
		await App.Database.SavePachetSejurAsync(slist);
		await Navigation.PopAsync(); 
	}
    async void OnDeleteButtonClicked(object sender, EventArgs e)
	{
		var slist = (PachetSejur)BindingContext;
		await App.Database.DeletePachetSejurAsync(slist);
		await Navigation.PopAsync(); 
	}
	async void OnChooseButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new CaracteristiciPachetPage((PachetSejur)this.BindingContext)
		{
			BindingContext = new CaracteristiciPachet()
		});
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (PachetSejur)BindingContext;
        listView.ItemsSource = await App.Database.GetListCaracteristiciPacheteAsync(shopl.ID);
    }
}
