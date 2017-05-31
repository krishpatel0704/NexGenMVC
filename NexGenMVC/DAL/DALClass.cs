using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace NexGenMVC.DAL
{
    public class DALClass
    {
        public static string conString = Convert.ToString(ConfigurationManager.ConnectionStrings["DefaultConnectionEntities"].ConnectionString);
       

        public SqlConnection cn = new SqlConnection(conString);
        SqlCommand cmd = null;
        SqlDataAdapter ad = null;
        public bool InsertData(SqlCommand cmd)
        {
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

                using (cn = new SqlConnection(conString))
                {
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            { }
            return true;
        }



    }
}