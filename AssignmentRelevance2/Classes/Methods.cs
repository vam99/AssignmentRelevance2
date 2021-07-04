using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AssignmentRelevance2.Classes
{
    public static class Methods
    {
        public static SqlConnection con = new SqlConnection();
        public static SqlCommand com = new SqlCommand();
        public static SqlDataReader dr;
        public static void OpenCon(SqlConnection con)
        {
            //con.ConnectionString = "data source=.\\SQLEXPRESS; database=proiectRelevance; integrated security = SSPI;";
            con.ConnectionString = "Server=DESKTOP-OMEOTO8\\VLAD; Database=proiectRelevance; Trusted_Connection=true;";
            con.Open();
        }
        public static List<Produse> FetchProduse()
        {
            List<Produse> listaProduse = new List<Produse>();
            if (listaProduse.Count > 0)
            {
                listaProduse.Clear();
            }

            try
            {
                Methods.OpenCon(con);
                com.Connection = con;
                com.CommandText = "SELECT Cod, Descriere, Pret, Cantitate FROM Produse";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    listaProduse.Add(new Produse()
                    {
                        Cod = (int)dr["Cod"],
                        Descriere = dr["Descriere"].ToString(),
                        Pret = (decimal)dr["Pret"],
                        Cantitate = (int)dr["Cantitate"],
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare", ex);
            }
            finally
            {
                con.Close();
            }
            return listaProduse;
        }
    }
}
