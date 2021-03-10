using System;

namespace DIO.Bank
{
    public class ContaBancaria
    {
        private TipoConta TipoConta {get;set;}
        private double Saldo {get;set;}
        private double Credito {get;set;}
        private string Nome {get;set;}

        public ContaBancaria(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            //Validacao do saldo
            if (this.Saldo - valorSaque < (this.Credito*-1)){
                Console.WriteLine("Desculpe, Saldo Insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é de {1}", this.Nome, this.Saldo);
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é de {1}", this.Nome, this.Saldo);
        }

        public void Transferencia(ContaBancaria contaDestino, double valorTransferencia)
        {
            if(this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";

            retorno+="Tipo de Conta " + this.TipoConta + " | ";
            retorno+="Nome " + this.Nome + " | ";
            retorno+="Saldo " + this.Saldo + " | ";
            retorno+="Crédito " + this.Credito + " | ";
            
            return retorno;
        }
    }
}