using CustomerWebApiDDD.Domain.Models;
using NUnit.Framework;
using System;

namespace CustomerWebApiDDD.Test
{
    public class AddressTest
    {
        [Test]
        public void AddressCaseTestWithoutStreet()
        {
            try
            {
                Address address = Address.New(1, string.Empty, "neighborhood", "city", "state");

                if (address.Validate())
                    Assert.Fail();

            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void AddressCaseTestWithoutNeighborhood()
        {
            try
            {
                Address address = Address.New(1, "street", string.Empty, "city", "state");

                if (address.Validate())
                    Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void AddressCaseTestWithoutCity()
        {
            try
            {
                Address address = Address.New(1, "street", "neighborhood", string.Empty, "state");

                if (address.Validate())
                    Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void AddressCaseTestWithoutState()
        {
            try
            {
                Address address = Address.New(1, "street", "neighborhood", "city", string.Empty);

                if (address.Validate())
                    Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        public void AddressCaseTestStreetOverLenght()
        {
            try
            {
                Address address = Address.New(1, "123456789012345678901234567890123456789012345678901", "neighborhood", "city", "state");

                if (address.Validate())
                    Assert.Fail();

            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void AddressCaseTestNeighborhoodOverLenght()
        {
            try
            {
                Address address = Address.New(1, "street", "12345678901234567890123456789012345678901", "city", "state");

                if (address.Validate())
                    Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void AddressCaseTestCityOverLenght()
        {
            try
            {
                Address address = Address.New(1, "street", "neighborhood", "12345678901234567890123456789012345678901", "state");

                if (address.Validate())
                    Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void AddressCaseTestStateOverLenght()
        {
            try
            {
                Address address = Address.New(1, "street", "neighborhood", "city", "12345678901234567890123456789012345678901");

                if (address.Validate())
                    Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }
    }
}
