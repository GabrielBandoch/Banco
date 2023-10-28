using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    internal class Transacao
    {
        // propriedades
        private DateTime data;
        private string motivo;
        private string tipo;
        private decimal valor;

        // getters
        public DateTime Data { get { return data; } }
        public string Motivo { get {  return motivo; } }
        public string Tipo { get { return tipo; } }
        public decimal Valor { get {  return valor; } }


        // método construtor
        public Transacao(DateTime dat, string mot,  string tip, 
            decimal val)
        {
            this.data = dat;
            this.motivo = mot;
            this.tipo = tip;
            this.valor = val;
        }
    }
}
