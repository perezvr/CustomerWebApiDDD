using CustomerWebApiDDD.Domain.Models;
using NUnit.Framework;
using System;

namespace CustomerWebApiDDD.Test
{
    public class CustomerTest
    {
        [Test]
        public void CustomerCaseTestWithoutName()
        {
            try
            {
                Customer customer = Customer.New(1, string.Empty, "12345678901", new DateTime(2010, 1, 1));

                if (customer.Validate())
                    Assert.Fail();

            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void CustomerCaseTestWithoutCpf()
        {
            try
            {
                Customer customer = Customer.New(1, "Name", string.Empty, new DateTime(2010, 1, 1));

                if (customer.Validate())
                    Assert.Fail();

            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void CustomerCaseTestInvalidCpf()
        {
            try
            {
                Customer customer = Customer.New(1, "testName", "12345678901", new DateTime(2010, 1, 1));

                if (customer.Validate())
                    Assert.Fail();

            }
            catch (Exception ex)
            {
                if (!ex.Message.Equals("Invalid CPF"))
                    Assert.Fail();
            }
        }

        [Test]
        public void CustomerCaseTestNameOverLenght()
        {
            try
            {
                Customer customer = Customer.New(1, "1234567890123456789012345678901", "11121828701", new DateTime(2010, 1, 1));

                if (customer.Validate())
                    Assert.Fail();

            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }
    }
}
