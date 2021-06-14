using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace CSharpTestProject
{
    public class SampleUnitTest : IClassFixture<HotelSampleCollection>
    {
        private readonly IList<Hotel> _collection;

        public SampleUnitTest(HotelSampleCollection sampleCollection)
        {
            _collection = sampleCollection.Collection;
        }

        [Fact]
        public void ShouldFail()
        {
            Assert.True(false);
        }
        
        [Theory]
        [InlineData("2020-3-16", "2020-3-17", "2020-3-18")]
        public void CasoDeTeste1(string data0, string data1, string data2)
        {
            var hotel = _collection.ObterMaisBarato(TipoDeCliente.Regular, DateTime.Parse(data0),
                DateTime.Parse(data1), DateTime.Parse(data2));

            Assert.NotNull(hotel);
            Assert.Equal("Parque das flores", hotel.Nome);
        }
        
        [Theory]
        [InlineData("2020-3-20", "2020-3-21", "2020-3-22")]
        public void CasoDeTeste2(string data0, string data1, string data2)
        {
            var hotel = _collection.ObterMaisBarato(TipoDeCliente.Regular, DateTime.Parse(data0),
                DateTime.Parse(data1), DateTime.Parse(data2));

            Assert.NotNull(hotel);
            Assert.Equal("Jardim Botânico", hotel.Nome);
        }
        
        [Theory]
        [InlineData("2020-3-26", "2020-3-27", "2020-3-28")]
        public void CasoDeTeste3(string data0, string data1, string data2)
        {
            var hotel = _collection.ObterMaisBarato(TipoDeCliente.ComFidelidade, DateTime.Parse(data0),
                DateTime.Parse(data1), DateTime.Parse(data2));

            Assert.NotNull(hotel);
            Assert.Equal("Mar Atlântico", hotel.Nome);
        }
    }
}