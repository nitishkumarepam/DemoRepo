using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TaskPage.Models;

namespace TaskPage
{
    public class CRUD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRUD"].ToString());

        public bool InsertData(HomePage model)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("details_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@username", model.UserName);
            cmd.Parameters.AddWithValue("@date", model.Date_Time);
            cmd.Parameters.AddWithValue("@phonenumber", model.PhoneNumber);
            cmd.Parameters.AddWithValue("@email", model.EMail);

            int i = cmd.ExecuteNonQuery();//returns number of rows affected
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool DeleteData(int id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("data_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            int i = cmd.ExecuteNonQuery();//returns number of rows affected
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<HomePage> GetOrders()
        {
            List<HomePage> models = new List<HomePage>();

            SqlCommand cmd = new SqlCommand("details_sp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                models.Add(
                    new HomePage
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        UserName = Convert.ToString(dr["username"]),
                        EMail = Convert.ToString(dr["email"]),
                        Date_Time = Convert.ToDateTime(dr["date"]),
                        PhoneNumber = Convert.ToString(dr["phonenumber"])


                    });
            }
            return models;
        }

        public bool UpdateData(HomePage model)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DataUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", model.Id);
            cmd.Parameters.AddWithValue("@username", model.UserName);
            cmd.Parameters.AddWithValue("@email", model.EMail);
            cmd.Parameters.AddWithValue("@phonenumber", model.PhoneNumber);
            cmd.Parameters.AddWithValue("@date", model.Date_Time);
            
            int i = cmd.ExecuteNonQuery();//returns number of rows affected
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}