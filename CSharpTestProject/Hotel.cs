using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpTestProject
{
    public class Hotel
    {
        public string Nome { get; set; }
        public int Classificacao { get; set; }
        public decimal TaxaDiaDeSemana { get; set; }
        public decimal TaxaDiaDeSemanaComFidelidade { get; set; }
        public decimal TaxaFimDeSemana { get; set; }
        public decimal TaxaFimDeSemanaComFidelidade { get; set; }

        public decimal CalcularTaxaPorPeriodo(TipoDeCliente tipoDeCliente, params DateTime[] datas)
        {
            decimal totalizador = 0;

            foreach (var data in datas)
            {
                if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (tipoDeCliente == TipoDeCliente.ComFidelidade)
                    {
                        totalizador += TaxaFimDeSemanaComFidelidade;
                    }
                    else
                    {
                        totalizador += TaxaFimDeSemana;
                    }
                }
                else
                {
                    if (tipoDeCliente == TipoDeCliente.ComFidelidade)
                    {
                        totalizador += TaxaDiaDeSemanaComFidelidade;
                    }
                    else
                    {
                        totalizador += TaxaDiaDeSemana;
                    }
                }
            }

            return totalizador;
        }
    }

    public enum TipoDeCliente
    {
        Regular,
        ComFidelidade
    }

    public static class HotelCollectionExtensions
    {
        public static Hotel ObterMaisBarato(this IEnumerable<Hotel> hoteis, TipoDeCliente tipoDeCliente,
            params DateTime[] datas)
        {
            var totalPorHotel = new Dictionary<Hotel, decimal>();

            foreach (var hotel in hoteis)
            {
                var taxaPorPeriodo = hotel.CalcularTaxaPorPeriodo(tipoDeCliente, datas);
                totalPorHotel.TryAdd(hotel, taxaPorPeriodo);
            }

            var menorValor = totalPorHotel.Min(x => x.Value);
            var hoteisComMenorValor = totalPorHotel.Where(x => x.Value == menorValor)
                .Select(x => x.Key);

            return hoteisComMenorValor.OrderByDescending(x => x.Classificacao).First();
        }
    }
}