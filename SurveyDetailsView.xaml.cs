namespace Survey_5330038;

public partial class SurveyDetailsView : ContentPage
{
    private readonly string[] teams =
    {
        "Alianza Lima",
        "América",
        "Boca Juniors",
        "Caracas FC",
        "Colo-Colo",
        "Peñarol",
        "Real Madrid",
        "Saprissa"
    };
	public SurveyDetailsView()
	{
		InitializeComponent();
	}

    private async void FavoriteTeam_Clicked(object sender, EventArgs e)
    {
        var favoriteteam = await DisplayActionSheet(Literals.FavoriteTeamTitle, null, null, teams);
        if(!string.IsNullOrWhiteSpace(favoriteteam))
        {
            FavoriteTeamLabel.Text = favoriteteam;
        }
    }

    private async void OkButton_Clicked(object sender, EventArgs e)
    {
        //evaluamos si los datos estan completos
        if (string.IsNullOrWhiteSpace(NameEntry.Text) || string.IsNullOrWhiteSpace(FavoriteTeamLabel.Text))
        {
            return;
        }

        //Creamos el nuevo objeto de tipo survey
        var newSurvey = new Survey()
        {
            Name = NameEntry.Text,
            Birthdate = BirthdatePicker.Date,
            FavoriteTeam = FavoriteTeamLabel.Text

        };
        //publicamos  el mensaje con el objeto  de encuenta como argumento
        MessagingCenter.Send((ContentPage)this,
            Messages.NewSurveyComplete, newSurvey);

        //Removemos la pagina de la pila de navegacion para regresar inmediatamente
        await Navigation.PopAsync();
    }
}