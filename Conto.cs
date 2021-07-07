using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//I conti hanno:
//Intestatario, Tipo di conto (Corrente o Risparmio), Saldo

namespace Banca
{
    class Conto
    {
        public string Intestatario { get; set; }
        public TipologiaConto TipoDiConto { get; set; }
        public double Saldo { get; set; }

        public int IdConto { get; set; }

        //costruttori
        public Conto()
        {

        }

        public Conto(string intestatario,TipologiaConto tipologia)
        {
            Intestatario = intestatario;
            TipoDiConto = tipologia;
            Saldo = 100;
        }
    }

    public enum TipologiaConto
    {
        Corrente = 1,
        Risparmio = 2
    }
}
