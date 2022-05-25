using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace Textbox_autocomplete.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public DataSet GetName(string prefix)
        {
            SqlCommand com = new SqlCommand("select C.* from Country C WHERE C.country_Name LIKE '%'+@prefix+'%'", con);
            com.Parameters.AddWithValue("@prefix", prefix);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(ds);
            return ds;
        }
    }
}