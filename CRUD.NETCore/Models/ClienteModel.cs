using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TesteEverton.Models
{
    public class CModel : IDisposable
    {
        private SqlConnection conn;

        public CModel()
        {
            string strConn = "Data Source=(LocalDB)\\MSSQLLocalDB;Database=DBTestePratico;Integrated Security=SSPI;";
            conn = new SqlConnection(strConn);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }
    }

    public class ClienteModel : Model
    {
        private SqlConnection conn;

        public List<Cliente> Read()
        {
            List<Cliente> lista = new List<Cliente>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * 
                                FROM Cliente WHERE Ativo EQUALS true";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cliente c = new Cliente
                {
                    Identificador = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    CPF = reader.GetString(2),
                    RG = reader.GetString(4),
                    DataNascimento = (DateTime)reader["DataNascimento"],
                    Ativo = (bool)reader["Ativo"]
                };

                lista.Add(c);
            }

            return lista;
        }
        public void Create(Cliente c)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Cliente VALUES (@nome, @cpf, @rg, @dataNascimento, @ativo)";

            cmd.Parameters.AddWithValue("@nome", c.Nome);
            cmd.Parameters.AddWithValue("@cpf", c.CPF);
            cmd.Parameters.AddWithValue("@rg", c.RG);
            cmd.Parameters.AddWithValue("@dataNascimento", c.DataNascimento);
            cmd.Parameters.AddWithValue("@rg", c.Ativo);

            cmd.ExecuteNonQuery();
        }

        public void Update(Cliente c)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"UPDATE Cliente SET Nome = @nome, CPF = @cpf, RG = @rg, DataNascimento = @dataNascimento, Ativo = @ativo
                                    WHERE Identificador = @id";

            cmd.Parameters.AddWithValue("@nome", c.Nome);
            cmd.Parameters.AddWithValue("@cpf", c.CPF);
            cmd.Parameters.AddWithValue("@rg", c.RG);
            cmd.Parameters.AddWithValue("@dataNascimento", c.DataNascimento);
            cmd.Parameters.AddWithValue("@rg", c.Ativo);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM Cliente WHERE Identificador = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public Cliente Read(int id)
        {
            Cliente c = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM Cliente
                                WHERE Identificador = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                c = new Cliente
                {
                    Identificador = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    CPF = reader.GetString(2),
                    RG = reader.GetString(4),
                    DataNascimento = (DateTime)reader["DataNascimento"],
                    Ativo = (bool)reader["Ativo"]
                };
            }

            return c;
        }
    }

}
