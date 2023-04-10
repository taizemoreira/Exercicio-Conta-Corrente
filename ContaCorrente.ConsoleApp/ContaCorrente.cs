using System;
namespace ExContaCorrente
{
    public class ContaCorrente
    {
        private double saldo;
        private double limite;

        public ContaCorrente(double saldoInicial, double limite)
        {
            saldo = saldoInicial;
            this.limite = limite;
        }

        public void Saque(double valor)
        {
            if (valor > saldo + limite)
            {
                Console.WriteLine("Saque não permitido. Limite de saque excedido.");
                return;
            }

            saldo -= valor;
            Console.WriteLine("Saque realizado com sucesso!");
        }

        public void Deposito(double valor)
        {
            saldo += valor;
            Console.WriteLine("Depósito realizado com sucesso!");
        }

        public double Saldo()
        {
            return saldo;
        }

        public void Transferencia(ContaCorrente contaDestino, double valor)
        {
            if (valor > saldo)
            {
                Console.WriteLine("Transferência não permitida. Saldo insuficiente.");
                return;
            }

            saldo -= valor;
            contaDestino.Deposito(valor);
            Console.WriteLine("Transferência realizada com sucesso!");
        }
    }

    class Program
    {
        static void Main()
        {
            ContaCorrente conta1 = new ContaCorrente(1000, 500);
            ContaCorrente conta2 = new ContaCorrente(500, 200);

            conta1.Saque(300);
            Console.WriteLine("Saldo conta 1: " + conta1.Saldo());

            conta1.Transferencia(conta2, 500);
            Console.WriteLine("Saldo conta 1: " + conta1.Saldo());
            Console.WriteLine("Saldo conta 2: " + conta2.Saldo());

            conta2.Deposito(100);
            Console.WriteLine("Saldo conta 2: " + conta2.Saldo());
        }
    }
}
