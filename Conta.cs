using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    internal class Conta
    {
        // propriedades
        private string numero;
        private string titular;
        private decimal saldo;
        private List<Transacao> transacoes = new List<Transacao>();

        // getters/setters
        public string Numero { get { return this.numero; } }
        public string Titular { get { return this.titular; } }
        public decimal Saldo { get { return this.saldo; } }


        // método construtor
        public Conta(string num, string tit) 
        { 
            this.numero = num;
            this.titular = tit;
            this.saldo = 0;
        }



        // outros métodos
        public string mostrarDados()
        {
            string info = "";
            info += "Conta de ";
            info += this.titular;
            info += " possui saldo de R$ ";
            info += this.saldo.ToString();
            return info;
        }


        public void registrarMovimento(string tip, string mot, decimal val)
        {
            // se é débito
            if (tip == "D") this.saldo -= val;

            // se é crédito
            if (tip == "C") this.saldo += val;

            // guarda o movimento
            this.transacoes.Add(new Transacao(DateTime.Now, mot, tip, val));
        }



        public string recuperarExtrato()
        {
            StringBuilder extrato = new StringBuilder();
            decimal saldo = 0;

            extrato.AppendLine("Data\t\tTipo\tValor\tSaldo\tMotivo");
            extrato.AppendLine("-----------------------------------");
            for (int x=0; x<this.transacoes.Count; x++) 
            {
                if (transacoes[x].Tipo == "D") saldo -= transacoes[x].Valor;
                else saldo += transacoes[x].Valor;
                extrato.AppendLine( $"{transacoes[x].Data.ToShortDateString()}\t{transacoes[x].Tipo}\t{transacoes[x].Valor}\t{saldo}\t{transacoes[x].Motivo}" );
            }
            
            return extrato.ToString();
        }


    }
}



/*
 * Get/Set X Métodos
 * 
        // via getter & setters
        public decimal Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }


        // via métodos
        public decimal mostrarSaldo()
        {
            return this.saldo;
        }

        public void mudarSaldo(decimal val)
        {
            this.saldo = val;
        }

 */