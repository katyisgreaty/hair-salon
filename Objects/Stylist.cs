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

            SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
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

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                bool idEquality = this.GetId() == newStylist.GetId();
                bool nameEquality = this.GetName() == newStylist.GetName();
                bool specialtyEquality = this.GetSpecialty() == newStylist.GetSpecialty();
                bool experienceEquality = this.GetExperience() == newStylist.GetExperience();
                return (idEquality && nameEquality && specialtyEquality && experienceEquality);
            }
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO stylists (name, specialty, experience) OUTPUT INSERTED.id VALUES (@StylistName, @StylistSpecialty, @StylistExperience);", conn);

            SqlParameter nameParameter = new SqlParameter("@StylistName", this.GetName());

            SqlParameter specialtyParameter = new SqlParameter("@StylistSpecialty", this.GetSpecialty());

            SqlParameter experienceParameter = new SqlParameter("@StylistExperience", this.GetExperience());

            cmd.Parameters.Add(nameParameter);
            cmd.Parameters.Add(specialtyParameter);
            cmd.Parameters.Add(experienceParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }




        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM stylists;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
