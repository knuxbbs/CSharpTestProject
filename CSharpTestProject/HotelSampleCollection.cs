namespace CSharpTestProject
{
    public class HotelSampleCollection
    {
        public Hotel[] Collection =
        {
            new Hotel
            {
                Nome = "Parque das flores",
                Classificacao = 3,
                TaxaDiaDeSemana = 110,
                TaxaDiaDeSemanaComFidelidade = 80,
                TaxaFimDeSemana = 90,
                TaxaFimDeSemanaComFidelidade = 80
            },
            new Hotel
            {
                Nome = "Jardim Botânico",
                Classificacao = 4,
                TaxaDiaDeSemana = 160,
                TaxaDiaDeSemanaComFidelidade = 110,
                TaxaFimDeSemana = 60,
                TaxaFimDeSemanaComFidelidade = 50
            },
            new Hotel
            {
                Nome = "Mar Atlântico",
                Classificacao = 5,
                TaxaDiaDeSemana = 220,
                TaxaDiaDeSemanaComFidelidade = 100,
                TaxaFimDeSemana = 150,
                TaxaFimDeSemanaComFidelidade = 40
            }
        };
    }
}