using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using TaskTecherDiogo2.Interface;
using TaskTecherDiogo2.Models;
using static TaskTecherDiogo2.Models.Metodos;
using System.Globalization;

namespace TaskTecherDiogo2.Services
{
    public class SimulacaoService : InterfaceSimulacao
    {
        public Retorno CalcularMargem(Requisicao requisicao)
        {
            var margem = (requisicao.Renda - requisicao.SomaDebitos) * 0.35;
            var margemCartao = (requisicao.Renda - requisicao.SomaDebitos) * 0.05;
            const int Multiplicador = 29;
            const double CoeficienteNovo = 0.02295;
            const double CoeficientePort = 0.02305;
            List<Contratos> Contrato = new List<Contratos>();

            var responde = new Retorno
            {
                MargemLivre = (double)margem,
                ValorDisponivel = (double)margem / CoeficienteNovo,
                MargemCartao = (double)margemCartao,
                LimiteCartao = (double)margemCartao * Multiplicador,
                ValorSaque = (double)((margemCartao * Multiplicador) * 0.70)
            };

            if (requisicao.Contrato != null)
            {
                foreach (var contrato in requisicao.Contrato)
                    Contrato.Add(new Contratos
                    {
                        CodigoBanco= contrato.CodigoBanco,
                        NumeroContrato= contrato.NumeroContrato,
                        SaldoDevedor = contrato.SaldoDevedor,
                        ValorDisponivel = (decimal?)(contrato.ValorParcela / CoeficientePort) - (decimal?)contrato.SaldoDevedor,
                        ValorParcela = contrato.ValorParcela
                    });
                responde.Contrato = Contrato;

            }

            return responde;
        }
         
    }
}
