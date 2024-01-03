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
    public partial class guitarinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    Button1.Visible = false; // add
                    Button2.Visible = false; // delete
                    Button3.Visible = false; // update
                    
                }
                else if (Session["role"].Equals("user"))
                {
                    Button1.Visible = true; // add
                    Button2.Visible = false; // delete
                    Button3.Visible = false; // update

                }

                else if (Session["role"].Equals("admin"))
                {
                    Button1.Visible = true; // add
                    Button2.Visible = true; // delete
                    Button3.Visible = true; // update
                }
            }
            catch (Exception ex)
            {

            }
        }

        // go button click
        protected void Button4_Click(object sender, EventArgs e)
        {
           getGuitarByID();
        }


        // update button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateGuitarByID();
        }
        // delete button click
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteGuitarByID();
        }
        // add button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            addNewGuitar();

        }



        // user defined functions

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

        void updateGuitarByID()
        {   

            if (checkIfGuitarExists())
            {
                try
                {
                    string filepath = "~/guitar_inventory/inventory_logo";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("guitar_inventory/" + filename));
                        filepath = "~/guitar_inventory/" + filename;
                    }

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE guitar_master_tbl set guitar_name=@guitar_name, guitar_type=@guitar_type, guitar_color=@guitar_color, guitar_weight=@guitar_weight, guitar_material=@guitar_material, number_of_strings=@number_of_strings, guitar_price=@guitar_price, guitar_img_link=@guitar_img_link, publish_date=@publish_date,guitar_description=guitar_description where Id='" + TextBox8.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@guitar_name", TextBox12.Text.Trim());
                    cmd.Parameters.AddWithValue("@guitar_type", DropDownList4.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@guitar_color", TextBox13.Text.Trim());
                    cmd.Parameters.AddWithValue("@guitar_weight", TextBox14.Text.Trim());
                    cmd.Parameters.AddWithValue("@guitar_material", TextBox15.Text.Trim());
                    cmd.Parameters.AddWithValue("@number_of_strings", TextBox16.Text.Trim());
                    cmd.Parameters.AddWithValue("@guitar_price", TextBox17.Text.Trim());
                    cmd.Parameters.AddWithValue("@guitar_img_link", filepath);
                    //cmd.Parameters.AddWithValue("@publisher_name", Session["fullname"]);
                    cmd.Parameters.AddWithValue("@publish_date", TextBox18.Text.Trim());
                    cmd.Parameters.AddWithValue("@guitar_description", TextBox19.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Guitar Updated Successfully');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Guitar ID');</script>");
            }
            
        }     //done

        void getGuitarByID()
        {   
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from guitar_master_tbl WHERE Id='" + TextBox8.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox12.Text = dt.Rows[0]["guitar_name"].ToString();
                    DropDownList4.SelectedValue = dt.Rows[0]["guitar_type"].ToString().Trim();
                    TextBox13.Text = dt.Rows[0]["guitar_color"].ToString();
                    TextBox14.Text = dt.Rows[0]["guitar_weight"].ToString();
                    TextBox15.Text = dt.Rows[0]["guitar_material"].ToString();
                    TextBox16.Text = dt.Rows[0]["number_of_strings"].ToString();
                    TextBox17.Text = dt.Rows[0]["guitar_price"].ToString().Trim();
                    TextBox18.Text = dt.Rows[0]["publish_date"].ToString();
                    TextBox19.Text = dt.Rows[0]["guitar_description"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Guitar ID');</script>");
                }

            }
            catch (Exception ex)
            {

            }
            
        }   //done

        bool checkIfGuitarExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from guitar_master_tbl where Id='" + TextBox8.Text.Trim() + "' OR guitar_name='" + TextBox12.Text.Trim() + "';", con);
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
                string filepath = "~/guitar_inventory/inventory_logo.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("guitar_inventory/" + filename));
                filepath = "~/guitar_inventory/" + filename;


                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                
                SqlCommand cmd = new SqlCommand("INSERT INTO guitar_master_tbl(guitar_name,guitar_type,guitar_color,guitar_weight,guitar_material,number_of_strings,guitar_price,guitar_img_link,publisher_name,publish_date,guitar_description) values(@guitar_name,@guitar_type,@guitar_color,@guitar_weight,@guitar_material,@number_of_strings,@guitar_price,@guitar_img_link,@publisher_name,@publish_date,@guitar_description)", con);

               // cmd.Parameters.AddWithValue("@Id", TextBox8);
                cmd.Parameters.AddWithValue("@guitar_name", TextBox12.Text.Trim());
                cmd.Parameters.AddWithValue("@guitar_type", DropDownList4.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@guitar_color", TextBox13.Text.Trim());
                cmd.Parameters.AddWithValue("@guitar_weight", TextBox14.Text.Trim());
                cmd.Parameters.AddWithValue("@guitar_material", TextBox15.Text.Trim());
                cmd.Parameters.AddWithValue("@number_of_strings", TextBox16.Text.Trim());
                cmd.Parameters.AddWithValue("@guitar_price", TextBox17.Text.Trim());
                cmd.Parameters.AddWithValue("@guitar_img_link", filepath);
                cmd.Parameters.AddWithValue("@publisher_name", Session["fullname"]);
                cmd.Parameters.AddWithValue("@publish_date", TextBox18.Text.Trim());
                cmd.Parameters.AddWithValue("@guitar_description", TextBox19.Text.Trim());
                
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