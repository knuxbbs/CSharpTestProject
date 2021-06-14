using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace CSharpTestProject
{
    public class SampleUnitTest : IClassFixture<HotelCollectionFixture>
    {
        private readonly IList<Hotel> _collection;

        public SampleUnitTest(HotelCollectionFixture collectionFixture)
        {
            _collection = collectionFixture.Collection;
        }

        [Fact]
        public void ShouldFail()
        {
            Assert.True(false);
        }

        [Fact]
        public void CasoDeTeste1()
        {
            var hotel = _collection.ObterMaisBarato(TipoDeCliente.Regular, new DateTime(2020, 3, 16),
                new DateTime(2020, 3, 17), new DateTime(2020, 3, 18));

            Assert.NotNull(hotel);
            Assert.Equal("Parque das flores", hotel.Nome);
        }
        
        [Fact]
        public void CasoDeTeste2()
        {
            var hotel = _collection.ObterMaisBarato(TipoDeCliente.Regular, new DateTime(2020, 3, 20),
                new DateTime(2020, 3, 21), new DateTime(2020, 3, 22));

            Assert.NotNull(hotel);
            Assert.Equal("Jardim Botânico", hotel.Nome);
        }
        
        [Fact]
        public void CasoDeTeste3()
        {
            var hotel = _collection.ObterMaisBarato(TipoDeCliente.ComFidelidade, new DateTime(2020, 3, 26),
                new DateTime(2020, 3, 27), new DateTime(2020, 3, 28));

            Assert.NotNull(hotel);
            Assert.Equal("Mar Atlântico", hotel.Nome);
        }
    }
}