using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TesteEverton.Models
{
    public class EModel : IDisposable
    {
        private SqlConnection conn;

        public EModel()
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
    public class EnderecoModel : Model
    {
        private SqlConnection conn;

        public List<Endereco> Read()
        {
            List<Endereco> lista = new List<Endereco>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * 
                                FROM Endereco";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Endereco e = new Endereco
                {
                    Identificador = reader.GetInt32(0),
                    IdentificadorCliente = reader.GetInt32(1),
                    Logradouro = reader.GetString(2),
                    Numero = reader.GetString(3),
                    Complemento = reader.GetString(4),
                    Cidade = reader.GetString(5),
                    UF = reader.GetString(6),
                    CEP = reader.GetString(7)
                };

                lista.Add(e);
            }

            return lista;
        }
        public void Create(Endereco e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Endereco VALUES (@nome, @cpf, @rg, @dataNascimento, @ativo)";

            cmd.Parameters.AddWithValue("@identificadorCliente", e.IdentificadorCliente);
            cmd.Parameters.AddWithValue("@logradouro", e.Logradouro);
            cmd.Parameters.AddWithValue("@numero", e.Numero);
            cmd.Parameters.AddWithValue("@complemento", e.Complemento);
            cmd.Parameters.AddWithValue("@cidade", e.Cidade);
            cmd.Parameters.AddWithValue("@uf", e.UF);
            cmd.Parameters.AddWithValue("@cep", e.CEP);

            cmd.ExecuteNonQuery();
        }

        public void Update(Endereco e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"UPDATE Endereco SET IdentificadorCliente = @identificadorCliente, Logradouro = @logradouro, Numero = @numero, Complemento = @complemento, Cidade = @cidade, UF = @uf, CEP = cep
                                    WHERE Identificador = @id";

            cmd.Parameters.AddWithValue("@identificadorCliente", e.IdentificadorCliente);
            cmd.Parameters.AddWithValue("@logradouro", e.Logradouro);
            cmd.Parameters.AddWithValue("@numero", e.Numero);
            cmd.Parameters.AddWithValue("@complemento", e.Complemento);
            cmd.Parameters.AddWithValue("@cidade", e.Cidade);
            cmd.Parameters.AddWithValue("@uf", e.UF);
            cmd.Parameters.AddWithValue("@cep", e.CEP);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM Endereco WHERE Identificador = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public Endereco Read(int id)
        {
            Endereco e = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM Endereco
                                WHERE Identificador = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                e = new Endereco
                {
                    Identificador = reader.GetInt32(0),
                    IdentificadorCliente = reader.GetInt32(1),
                    Logradouro = reader.GetString(2),
                    Numero = reader.GetString(3),
                    Complemento = reader.GetString(4),
                    Cidade = reader.GetString(5),
                    UF = reader.GetString(6),
                    CEP = reader.GetString(7)
                };
            }

            return e;
        }
    }
}