using System;
using System.Collections.Generic;
using System.Globalization;
//


namespace TaskTecherDiogo2.Models
{
    public class Metodos
    {
        public class Requisicao
        {
            public double Renda { get; set; }
            public double? SomaDebitos { get; set; }
            public List <Contratos> Contrato { get; set; }
        }
          
        public class Retorno
        {
            public double MargemLivre { get; set; }
            public double ValorDisponivel { get; set; }
            public List<Contratos> Contrato { get; set; }
            public double MargemCartao { get; set; }

            public double LimiteCartao { get; set; }
            public double ValorSaque { get; set; }

        }

        public class Contratos
        {
            public double? NumeroContrato{ get; set; }
            public int? CodigoBanco { get; set; }
            public double? SaldoDevedor { get; set; }
            public double? ValorParcela { get; set; }
            public decimal? ValorDisponivel {get;set;}

        }

    }
}
