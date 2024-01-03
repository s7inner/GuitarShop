using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class favviewguitars : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("guitar_order.aspx");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox8.Text !="" &&checkIfGuitarExists2()!=false)
            {
                deleteGuitarByID();
                TextBox8.Text = "";
            }
            else
            {
                Response.Write("<script>alert('" + "Гітара з введеним Id відсутня!" + "');</script>");
            }

           
          
        }

        void deleteGuitarByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                GridViewRow row = GridView1.Rows[0];
                row.Cells[0].Text.Trim();

                //Видалення з guitar_master
                SqlCommand cmd = new SqlCommand("DELETE from guitar_fav_master_tbl WHERE Id='" + TextBox8.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }




        }

        bool checkIfGuitarExists2()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from guitar_fav_master_tbl where Id='" + TextBox8.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);


                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }  //done


    }
}