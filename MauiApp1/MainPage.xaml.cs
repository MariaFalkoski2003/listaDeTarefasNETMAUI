namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private List<CheckBox> checkBoxes = new List<CheckBox>();

        public MainPage()
        {
            InitializeComponent();
        }

        private void AdicionarButton_Clicked(object? sender, EventArgs e)
        {
            string? texto = TarefaEntry.Text;

            if (string.IsNullOrWhiteSpace(texto))
            {
                return;
            }

            CheckBox check = new CheckBox();

            Label label = new Label
            {
                Text = texto,
                VerticalOptions = LayoutOptions.Center
            };

            check.CheckedChanged += (s, args) =>
            {
                if (args.Value)
                {
                    label.TextDecorations = TextDecorations.Strikethrough;
                    label.TextColor = Colors.Gray;
                }
                else
                {
                    label.TextDecorations = TextDecorations.None;
                    label.ClearValue(Label.TextColorProperty);
                }

                AtualizarContador();
            };

            HorizontalStackLayout linha = new HorizontalStackLayout
            {
                Spacing = 10,
                Children = { check, label }
            };

            ListaTarefasLayout.Children.Add(linha);
            checkBoxes.Add(check);

            TarefaEntry.Text = string.Empty;

            AtualizarContador();
        }

        private void AtualizarContador()
        {
            int total = checkBoxes.Count;
            int concluidas = 0;

            foreach (CheckBox c in checkBoxes)
            {
                if (c.IsChecked)
                {
                    concluidas++;
                }
            }

            ContadorLabel.Text = $"{concluidas} de {total} tarefas concluídas";
        }
    }
}
