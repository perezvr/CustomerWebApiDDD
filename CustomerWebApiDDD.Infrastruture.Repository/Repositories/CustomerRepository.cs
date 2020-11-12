using CustomerWebApiDDD.Domain.Core.Interfaces.Repositories;
using CustomerWebApiDDD.Domain.Models;
using CustomerWebApiDDD.Infrastruture.Repository.ConnectionDB;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CustomerWebApiDDD.Infrastruture.Repository.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> Get()
        {
            using SqlConnection con = Connection.GetConnection();
            try
            {
                List<Customer> customers = new List<Customer>();
                con.Open();

                string SQL = $@"SELECT Id, Name, Cpf, Birth
                                FROM Customer";

                SqlCommand cmd = new SqlCommand(SQL, con);

                var dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                    customers.Add(Customer.New(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetDateTime(3)));

                return customers;
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public Customer Get(int id)
        {
            using SqlConnection con = Connection.GetConnection();
            try
            {
                Customer customer = null;
                con.Open();

                string SQL = $@"SELECT Id, Name, Cpf, Birth
                                FROM Customer WHERE 
                                Id = @id";

                SqlCommand cmd = new SqlCommand(SQL, con);
                cmd.Parameters.AddWithValue("@id", id);
                var dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                    customer = Customer.New(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetDateTime(3));

                return customer;
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void Insert(Customer customer)
        {
            using SqlConnection con = Connection.GetConnection();
            try
            {
                string SQL = $@"INSERT INTO Customer (Name, Cpf, Birth)
                                VALUES (@name, @cpf, @birth)";

                con.Open();
                SqlCommand cmd = new SqlCommand(SQL, con);

                cmd.Parameters.AddWithValue("@name", customer.Name);
                cmd.Parameters.AddWithValue("@cpf", customer.Cpf);
                cmd.Parameters.AddWithValue("@birth", customer.Birth);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void Update(int id, Customer customer)
        {
            using SqlConnection con = Connection.GetConnection();
            try
            {
                string SQL = $@"UPDATE Customer 
                                SET Name = @name, Cpf = @cpf, Birth = @birth
                                WHERE Id = @id";

                con.Open();
                SqlCommand cmd = new SqlCommand(SQL, con);

                cmd.Parameters.AddWithValue("@name", customer.Name);
                cmd.Parameters.AddWithValue("@cpf", customer.Cpf);
                cmd.Parameters.AddWithValue("@birth", customer.Birth);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void Delete(int id)
        {
            using SqlConnection con = Connection.GetConnection();
            try
            {
                string SQL = $@"DELETE
                                FROM Customer
                                WHERE Id = @id";

                con.Open();
                SqlCommand cmd = new SqlCommand(SQL, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
