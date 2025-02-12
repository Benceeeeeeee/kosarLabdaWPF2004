using kosar2004;
using MySql.Data.MySqlClient;

using System;

using System.Collections.Generic;

using System.Data.SqlClient;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace kosar2000
{
    internal class Adatbazis
    {
        private List<Merkozes> lista;
        private string connectionString;
        public Adatbazis()
        {
            lista = new List<Merkozes>();
            connectionString = "server=localhost;database=asda;user=root;password='';";
        }
        public List<Merkozes> Feltolt()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM eredmenyek;";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Merkozes m = new Merkozes
                            (
                                reader.GetString("hazai"),
                                reader.GetString("idegen"),
                                reader.GetInt32("hazai_pont"),
                                reader.GetInt32("idegen_pont"),
                                reader.GetString("helyszín"),
                                reader.GetDateTime("idõpont")
                            );

                            lista.Add(m);
                        }
                    }
                }
            }
            
            catch (MySqlException ex)
            {
                Console.WriteLine("Adatbázis hiba történt: " + ex.Message);
                Environment.Exit(1); // Program leállítása hiba esetén
            }

            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt: " + ex.Message);
                Environment.Exit(1);
            }

            return lista;
        }

        public string F2()
        {
            string s;
            int hazai = lista.Count(x => x.Hazai == "Real Madrid");
            int idegen = lista.Count(x => x.Idegen == "Real Madrid");

            s = $"Real Madrid hazai: {hazai} idegen: {idegen}";

            return s;
        }

        public string F3()
        {
            string s;
            var voltDontetlen = lista.Any(x => x.HazaiPont == x.IdegenPont);

            s = $"Volt döntetlen? {(voltDontetlen? "igen" : "nem")}";

            return s;
        }

        public string F4()
        {
            return lista.Where(x => x.Hazai.Contains("Barcelona")).ToList()[0].Hazai;
        }
        public string F5()
        {
            string s = "";
            var seged = lista.Where(x => x.Idopont == new DateTime(2004, 11, 21)).ToList();

            foreach (var item in seged)
            {
                s += $"{item.Hazai} - {item.Idegen} ({item.HazaiPont}:{item.IdegenPont})\n";
            }

            return s;
        }
        public string F6()
        {
            Dictionary<string, int> stat = new Dictionary<string, int>();

            foreach (var item in lista)
            {
                string kulcs = item.Helyszin;
                if (!stat.ContainsKey(kulcs))
                {
                    stat[kulcs] = 0 ;
                }
                stat[kulcs]++;
            }

            string s = "";
            foreach (var item in stat)
            {
                if(item.Value > 20)
                {
                    s += $"{item.Key}: {item.Value}\n";
                }
            }

            return s;
        }
    }
}