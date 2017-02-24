using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon
{
    public class Stylist
    {
        private int _id;
        private string _name;
        private string _specialty;
        private int _experience;

        public Stylist(string name, string specialty, int experience, int Id = 0)
        {
            _id = Id;
            _name = name;
            _specialty = specialty;
            _experience = experience;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetSpecialty()
        {
            return _specialty;
        }

        public int GetExperience()
        {
            return _experience;
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist>{};
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM stylist;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistName = rdr.GetString(1);
                string stylistSpecialty = rdr.GetString(2);
                int stylistExperience = rdr.GetInt32(3);
                Stylist newStylist = new Stylist(stylistName, stylistSpecialty, stylistExperience, stylistId);
                allStylists.Add(newStylist);
            }

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }

            return allStylists;
        }






        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM stylist;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
