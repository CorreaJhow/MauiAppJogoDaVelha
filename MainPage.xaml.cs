namespace MauiAppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        string vez = "X";
        public MainPage()
        {
            InitializeComponent();
        }

        //Sender = botão que foi clicado ou "enviador"
        //Basicamente qual elemento que disparou o event
        private void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btn.IsEnabled = false;

            if (vez.ToUpper() == "X")
            {
                btn.Text = "X";
                vez = "O";
            }
            else
            {
                btn.Text = "O";
                vez = "X";
            }


        }
    }

}
