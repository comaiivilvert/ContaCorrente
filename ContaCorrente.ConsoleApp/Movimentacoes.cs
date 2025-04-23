namespace ContaCorrente.ConsoleApp
{
    class Movimentacoes
    {
        public string tipo;
        public double valor;

        public Movimentacoes(string t, double v)
        {
            tipo = t;
            valor = v;
        }
        public string Descrever()
        {
            return tipo + ": R$" + valor;
        }
    }
}
