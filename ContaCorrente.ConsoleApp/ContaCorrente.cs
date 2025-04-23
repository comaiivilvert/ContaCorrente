using System.Reflection.Metadata.Ecma335;

namespace ContaCorrente.ConsoleApp
{ 
    internal class ContaCorrente
    {
        public double saldo = 1000;
        public int numero;
        public double limite;
        public Movimentacoes[] movimentacoes;
        public int quantidadeMovimentacoes = 0;

        public void Transferir(ContaCorrente destino, double valor)
        {
            bool conseguiuSacar = Sacar(valor);
            if (conseguiuSacar)
            {
                destino.Depositar(valor);
                AdicionarMovimentacao("Transferência para conta " + destino.numero, valor);
            }
        }
        
        public bool Sacar(double valor)
        {
            if (saldo + limite >= valor)
            {
                saldo -= valor;
                AdicionarMovimentacao("Saque", valor);
                return true;
            }
            else
            {
                Console.WriteLine("Saldo insuficiente.");
                return false;
            }
        }

        public void Depositar(double valor)
        {
            saldo += valor;
            AdicionarMovimentacao("Deposito", valor);

        }

        public void ExibirExtrato()
        {
            Console.WriteLine("Extrato da conta " + numero + ":");
            for (int i = 0; i < quantidadeMovimentacoes; i++)
            {
                Console.WriteLine(movimentacoes[i].Descrever());
            }
            Console.WriteLine("Saldo atual: R$" + saldo);
        }

        public void AdicionarMovimentacao(string tipo, double valor)
        {
            if (quantidadeMovimentacoes < movimentacoes.Length)
            {
                movimentacoes[quantidadeMovimentacoes] = new Movimentacoes(tipo, valor);
                quantidadeMovimentacoes++;
            }
            else
            {
                Console.WriteLine("Número máximo de movimentações atingido.");
            }
        }

    }


}
