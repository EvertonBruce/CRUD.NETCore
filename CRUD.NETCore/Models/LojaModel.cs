using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TesteEverton.Models
{
    public class Model : IDisposable
    {
        private SqlConnection conn;

        public Model()
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

    public class LojaModel : Model
    {
        private SqlConnection conn;
        public List<Loja> Read()
        {
            List<Loja> lista = new List<Loja>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * 
                                FROM Loja";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Loja l = new Loja
                {
                    Identificador = reader.GetInt32(0),
                    Nome = reader.GetString(1)
                };

                lista.Add(l);
            }

            return lista;
        }
    }
}