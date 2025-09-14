using MaiuAppMinhasCompras.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace MaiuAppMinhasCompras.Views
{
    public partial class RelatorioCategoria : ContentPage
    {
        private ObservableCollection<Produto> lista;

        public RelatorioCategoria(ObservableCollection<Produto> produtos)
        {
            InitializeComponent();
            lista = produtos;

            // Agrupar e calcular total por categoria
            var totalPorCategoria = lista
                .GroupBy(p => p.Categoria)
                .Select(g => new RelatorioItem
                {
                    Categoria = g.Key,
                    Total = g.Sum(p => p.Preco * p.Quantidade)
                }).ToList();

            lstRelatorio.ItemsSource = totalPorCategoria;
        }
    }

    public class RelatorioItem
    {
        public string Categoria { get; set; }
        public double Total { get; set; }
    }
}