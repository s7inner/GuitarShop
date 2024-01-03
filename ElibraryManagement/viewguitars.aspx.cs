using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class viewguitars : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null)
            {
                TextBox8.Visible = false;
                Button3.Visible = false;
                Button6.Visible = false;
            }
            else if (Session["role"].Equals("user"))
            {
                TextBox8.Visible = true;
                Button3.Visible = true;
                Button6.Visible = false;
            }
            else if (Session["role"].Equals("admin"))
            {
                TextBox8.Visible = true;
                Button3.Visible = false;
                Button6.Visible = true;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox8.Text != "" && checkIfGuitarExistsByName()==false)
            {
                addNewGuitar();
                TextBox8.Text = "";
            }
            else 
            {
                Response.Write("<script>alert('" + "Поле для введення Id пусте або дана гітара вже добавлена!" + "');</script>");
            }

            
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
          

            if (TextBox8.Text != "")
            {
                deleteGuitarByID();
                TextBox8.Text = "";
            }
            else
            {
                Response.Write("<script>alert('" + "Поле для введення Id пусте!" + "');</script>");
            }

        }
        protected void Button32_Click(object sender, EventArgs e)
        {



        }




        void deleteGuitarByID()
        {
            if (checkIfGuitarExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from guitar_master_tbl WHERE Id='" + TextBox8.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    //Видалення гітари з кошику
                    if (checkIfGuitarExists2())
                    {
                        con = new SqlConnection(strcon);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        cmd = new SqlCommand("DELETE from guitar_fav_master_tbl WHERE Id='" + TextBox8.Text.Trim() + "'", con);

                        cmd.ExecuteNonQuery();
                        con.Close();


                        Response.Write("<script>alert('Guitar Deleted Successfully');</script>");

                        GridView1.DataBind();
                    }
                        

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }

        }         //done

        bool checkIfGuitarExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from guitar_master_tbl where Id='" + TextBox8.Text.Trim() + "';", con);
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
        }    //done

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
        }    //done

        bool checkIfGuitarExistsByName()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from guitar_fav_master_tbl where main_table_id='" + TextBox8.Text.Trim() + "';", con);
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
        }    //done

        void addNewGuitar()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                
                SqlCommand cmd = new SqlCommand("SELECT * from guitar_master_tbl where Id='" + TextBox8.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                
                string guitar_name =  dt.Rows[0].ItemArray[1].ToString();
                string guitar_type = dt.Rows[0].ItemArray[2].ToString();
                string guitar_color = dt.Rows[0].ItemArray[3].ToString();
                string guitar_weight = dt.Rows[0].ItemArray[4].ToString();
                string guitar_material = dt.Rows[0].ItemArray[5].ToString();
                string number_of_strings = dt.Rows[0].ItemArray[6].ToString();
                string guitar_price = dt.Rows[0].ItemArray[7].ToString();
                string guitar_img_link = dt.Rows[0].ItemArray[8].ToString();
                string publisher_name = dt.Rows[0].ItemArray[9].ToString();
                string publish_date = dt.Rows[0].ItemArray[10].ToString();
                string guitar_description = dt.Rows[0].ItemArray[11].ToString();
                string sessionUsername = Session["fullname"].ToString();

                con.Close();


                 con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd = new SqlCommand("INSERT INTO guitar_fav_master_tbl(guitar_name,guitar_type,guitar_color,guitar_weight,guitar_material,number_of_strings,guitar_price,guitar_img_link,publisher_name,publish_date,guitar_description,sessionUsername,main_table_id) values(@guitar_name,@guitar_type,@guitar_color,@guitar_weight,@guitar_material,@number_of_strings,@guitar_price,@guitar_img_link,@publisher_name,@publish_date,@guitar_description,@sessionUsername,@main_table_id)", con);

                // cmd.Parameters.AddWithValue("@Id", TextBox8);
                cmd.Parameters.AddWithValue("@guitar_name", guitar_name);
                cmd.Parameters.AddWithValue("@guitar_type", guitar_type);
                cmd.Parameters.AddWithValue("@guitar_color", guitar_color);
                cmd.Parameters.AddWithValue("@guitar_weight", guitar_weight);
                cmd.Parameters.AddWithValue("@guitar_material", guitar_material);
                cmd.Parameters.AddWithValue("@number_of_strings", number_of_strings);
                cmd.Parameters.AddWithValue("@guitar_price", guitar_price);
                cmd.Parameters.AddWithValue("@guitar_img_link", guitar_img_link);
                cmd.Parameters.AddWithValue("@publisher_name", publisher_name);
                cmd.Parameters.AddWithValue("@publish_date", publish_date);
                cmd.Parameters.AddWithValue("@guitar_description", guitar_description);
                cmd.Parameters.AddWithValue("@sessionUsername", sessionUsername);
                cmd.Parameters.AddWithValue("@main_table_id", TextBox8.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Guitar added successfully.');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
               
            }


            
        }    //done

       
    }
}