using MaiuAppMinhasCompras.Models;

namespace MaiuAppMinhasCompras.Views
{
    public partial class NovoProduto : ContentPage
    {
        public NovoProduto()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Cria o produto com os dados do formulário
                Produto p = new Produto
                {
                    Descricao = txt_descricao.Text,
                    Quantidade = string.IsNullOrWhiteSpace(txt_quantidade.Text) ? 0 : Convert.ToDouble(txt_quantidade.Text),
                    Preco = string.IsNullOrWhiteSpace(txt_preco.Text) ? 0 : Convert.ToDouble(txt_preco.Text),
                    Categoria = pickerCategoria.SelectedItem?.ToString() ?? "Sem categoria"
                };

                await App.Db.Insert(p);
                await DisplayAlert("Sucesso!", "Registro Inserido", "OK");

                // Volta para a tela anterior após salvar
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}