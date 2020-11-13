using CustomerWebApiDDD.Domain.Core.Interfaces.Repositories;
using CustomerWebApiDDD.Domain.Models;
using CustomerWebApiDDD.Infrastruture.Repository.DBConnection;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CustomerWebApiDDD.Infrastruture.Repository.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public List<Address> Get()
        {
            using SqlConnection con = Connection.GetConnection();
            try
            {
                List<Address> addresses = new List<Address>();
                con.Open();

                string SQL = $@"SELECT Id, Street, Neighborhood, City, State
                                FROM Address";

                SqlCommand cmd = new SqlCommand(SQL, con);

                var dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                    addresses.Add(Address.New(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(2), dataReader.GetString(2)));

                return addresses;
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

        public Address Get(int id)
        {
            using SqlConnection con = Connection.GetConnection();
            try
            {
                Address address = null;
                con.Open();

                string SQL = $@"SELECT Id, Street, Neighborhood, City, State
                                FROM Address
                                WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(SQL, con);
                cmd.Parameters.AddWithValue("@id", id);
                var dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                    address = Address.New(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(2), dataReader.GetString(2));

                return address;
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

        public int Insert(Address address)
        {
            address.Validate();

            using SqlConnection con = Connection.GetConnection();
            try
            {
                string SQL = $@"INSERT INTO Address (Street, Neighborhood, City, State)
                                OUTPUT Inserted.ID
                                VALUES (@street, @neighborhood, @city, @state)";

                con.Open();
                SqlCommand cmd = new SqlCommand(SQL, con);

                cmd.Parameters.AddWithValue("@street", address.Street);
                cmd.Parameters.AddWithValue("@neighborhood", address.Neighborhood);
                cmd.Parameters.AddWithValue("@city", address.City);
                cmd.Parameters.AddWithValue("@state", address.State);
                var dataReader = cmd.ExecuteReader();

                int id = 0;

                while (dataReader.Read())
                    id = dataReader.GetInt32(0);

                return id;
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

        public void Update(int id, Address address)
        {
            address.Validate();

            using SqlConnection con = Connection.GetConnection();
            try
            {
                string SQL = $@"UPDATE Address 
                                SET Street = @street, Neighborhood = @neighborhood, City = @city, State = @state
                                WHERE Id = @id";

                con.Open();
                SqlCommand cmd = new SqlCommand(SQL, con);

                cmd.Parameters.AddWithValue("@street", address.Street);
                cmd.Parameters.AddWithValue("@neighborhood", address.Neighborhood);
                cmd.Parameters.AddWithValue("@city", address.City);
                cmd.Parameters.AddWithValue("@state", address.State);
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
                                FROM Address
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
