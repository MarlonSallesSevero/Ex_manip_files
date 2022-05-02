namespace EX.Entities
{
    internal class Product
    {
        public string nome { get; set; }
        public double preco { get; set; }
        public int qtd { get; set; }

        public Product(string nome, double preco, int qtd)
        {
            this.nome = nome;
            this.preco = preco;
            this.qtd = qtd;
        }
        public double total()
        {
            return qtd * preco;
        }
    }
}
