namespace webapiteste.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string? nome { get; set; }
        public string? descricao { get; set; }
        public decimal? preco  { get; set; }
        public string? ImagemUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

    }
}
