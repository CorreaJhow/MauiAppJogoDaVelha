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

            VerificarVencedor();
        }

        private void NovoJogo_Clicked(object sender, EventArgs e)
        {
            ReiniciarJogo();
        }

        void VerificarVencedor()
        {
            string vencedor = (vez == "X") ? "O" : "X";
            bool haVencedor = false;

            // --- Verificação de Linhas ---

            // Linha 1
            if (!string.IsNullOrEmpty(btn10.Text) && btn10.Text == btn11.Text && btn11.Text == btn12.Text)
            {
                haVencedor = true;
            }
            // Linha 2
            else if (!string.IsNullOrEmpty(btn20.Text) && btn20.Text == btn21.Text && btn21.Text == btn22.Text)
            {
                haVencedor = true;
            }
            // Linha 3
            else if (!string.IsNullOrEmpty(btn30.Text) && btn30.Text == btn31.Text && btn31.Text == btn32.Text)
            {
                haVencedor = true;
            }

            // --- Verificação de Colunas ---

            // Coluna 1
            else if (!string.IsNullOrEmpty(btn10.Text) && btn10.Text == btn20.Text && btn20.Text == btn30.Text)
            {
                haVencedor = true;
            }
            // Coluna 2
            else if (!string.IsNullOrEmpty(btn11.Text) && btn11.Text == btn21.Text && btn21.Text == btn31.Text)
            {
                haVencedor = true;
            }
            // Coluna 3
            else if (!string.IsNullOrEmpty(btn12.Text) && btn12.Text == btn22.Text && btn22.Text == btn32.Text)
            {
                haVencedor = true;
            }

            // --- Verificação de Diagonais ---

            // Diagonal Principal (\)
            else if (!string.IsNullOrEmpty(btn10.Text) && btn10.Text == btn21.Text && btn21.Text == btn32.Text)
            {
                haVencedor = true;
            }
            // Diagonal Secundária (/)
            else if (!string.IsNullOrEmpty(btn12.Text) && btn12.Text == btn21.Text && btn21.Text == btn30.Text)
            {
                haVencedor = true;
            }

            if (haVencedor)
            {
                DisplayAlert("Fim de Jogo", $"O Jogador **{vencedor}** venceu! 🥳", "OK");
                DesabilitarBotoes(); 
            }
            else if (VerificarEmpate()) 
            {
                DisplayAlert("Fim de Jogo", "O jogo empatou! 🤝", "OK");
                DesabilitarBotoes();
            }

            bool VerificarEmpate()
            {
                int contador = 0;

                if (!string.IsNullOrEmpty(btn10.Text)) contador++;
                if (!string.IsNullOrEmpty(btn11.Text)) contador++;
                if (!string.IsNullOrEmpty(btn12.Text)) contador++;
                if (!string.IsNullOrEmpty(btn20.Text)) contador++;
                if (!string.IsNullOrEmpty(btn21.Text)) contador++;
                if (!string.IsNullOrEmpty(btn22.Text)) contador++;
                if (!string.IsNullOrEmpty(btn30.Text)) contador++;
                if (!string.IsNullOrEmpty(btn31.Text)) contador++;
                if (!string.IsNullOrEmpty(btn32.Text)) contador++;

                return contador == 9;
            }           
        }

        void DesabilitarBotoes()
        {
            LimparEAtivarBotoes(false);
        }

        // Lógica de Reinício
        void ReiniciarJogo()
        {
            LimparEAtivarBotoes(true);

            vez = "X";
        }

        void LimparEAtivarBotoes(bool ativar)
        {
            var botoes = new List<Button>
                { btn10, btn11, btn12,
                  btn20, btn21, btn22,
                  btn30, btn31, btn32
                };

            foreach (var btn in botoes)
            {
                btn.Text = string.Empty; // Limpa o texto (X ou O)
                btn.IsEnabled = ativar;   // Ativa (true) ou Desativa (false)
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            ReiniciarJogo();
        }
    }
}
