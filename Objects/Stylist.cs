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

        public static Stylist Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE id = @StylistId;", conn);
            SqlParameter stylistIdParameter = new SqlParameter();
            stylistIdParameter.ParameterName = "@StylistId";
            stylistIdParameter.Value = id.ToString();
            cmd.Parameters.Add(stylistIdParameter);
            SqlDataReader rdr = cmd.ExecuteReader();

            int foundStylistId = 0;
            string foundStylistName = null;
            string foundStylistSpecialty = null;
            int foundStylistExperience = 0;

            while(rdr.Read())
            {
                foundStylistId = rdr.GetInt32(0);
                foundStylistName = rdr.GetString(1);
                foundStylistSpecialty = rdr.GetString(2);
                foundStylistExperience = rdr.GetInt32(3);
            }
            Stylist foundStylist = new Stylist(foundStylistName, foundStylistSpecialty, foundStylistExperience, foundStylistId);

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return foundStylist;
        }

        public static Stylist FindByName(string name)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE name = @StylistName;", conn);
            SqlParameter stylistNameParameter = new SqlParameter();
            stylistNameParameter.ParameterName = "@StylistName";
            stylistNameParameter.Value = name;
            cmd.Parameters.Add(stylistNameParameter);
            SqlDataReader rdr = cmd.ExecuteReader();

            int foundStylistId = 0;
            string foundStylistName = null;
            string foundStylistSpecialty = null;
            int foundStylistExperience = 0;

            while(rdr.Read())
            {
                foundStylistId = rdr.GetInt32(0);
                foundStylistName = rdr.GetString(1);
                foundStylistSpecialty = rdr.GetString(2);
                foundStylistExperience = rdr.GetInt32(3);
            }
            Stylist foundStylist = new Stylist(foundStylistName, foundStylistSpecialty, foundStylistExperience, foundStylistId);

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return foundStylist;
        }


        public List<Client> GetClients()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE stylist_id = @StylistId;", conn);
            SqlParameter stylistIdParameter = new SqlParameter();
            stylistIdParameter.ParameterName = "@StylistId";
            stylistIdParameter.Value = this.GetId();
            cmd.Parameters.Add(stylistIdParameter);
            SqlDataReader rdr = cmd.ExecuteReader();

            List<Client> clients = new List<Client> {};
            while(rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientName = rdr.GetString(1);
                int clientStylistId = rdr.GetInt32(2);
                Client newClient = new Client(clientName, clientStylistId, clientId);
                clients.Add(newClient);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return clients;
        }

        public void UpdateProperties(string newName, string newSpecialty, int newExperience)
       {
           SqlConnection conn = DB.Connection();
           conn.Open();

           SqlCommand cmd = new SqlCommand("UPDATE stylists SET name = @NewName, specialty = @NewSpecialty, experience = @NewExperience OUTPUT INSERTED.* WHERE id = @StylistId;", conn);

           SqlParameter newNameParameter = new SqlParameter();
           newNameParameter.ParameterName = "@NewName";
           newNameParameter.Value = newName;
           cmd.Parameters.Add(newNameParameter);

           SqlParameter newExperienceParameter = new SqlParameter();
           newExperienceParameter.ParameterName = "@NewExperience";
           newExperienceParameter.Value = newExperience;
           cmd.Parameters.Add(newExperienceParameter);

           SqlParameter newSpecialtyParameter = new SqlParameter();
           newSpecialtyParameter.ParameterName = "@NewSpecialty";
           newSpecialtyParameter.Value = newSpecialty;
           cmd.Parameters.Add(newSpecialtyParameter);

           SqlParameter stylistIdParameter = new SqlParameter();
           stylistIdParameter.ParameterName = "@StylistId";
           stylistIdParameter.Value = this.GetId();
           cmd.Parameters.Add(stylistIdParameter);
           SqlDataReader rdr = cmd.ExecuteReader();

           while(rdr.Read())
           {
               this._name = rdr.GetString(1);
               this._specialty = rdr.GetString(2);
               this._experience = rdr.GetInt32(3);
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
