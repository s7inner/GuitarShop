using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ElibraryManagement
{
    public partial class userprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
                if (Session["member_id"].ToString() == "" || Session["member_id"] == null)
                {
                    
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    GridView1.DataBind();


                    if (!Page.IsPostBack)
                    {
                        getUserPersonalDetails();
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
        }

        // update button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            
                updateUserPersonalDetails();

            
        }



        // user defined function

        string getAccountStatus() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where member_id='" + TextBox8.Text.Trim() + "' AND password='" + TextBox9.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
               
                    while (dr.Read())
                    {

                    return dr.GetValue(6).ToString();

                    
                    }
 
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return null;
        }         //done

        void updateUserPersonalDetails()
        {
            string password = "";
            if (TextBox10.Text.Trim() == "")
            {
                password = TextBox9.Text.Trim();
            }
            else
            {
                password = TextBox10.Text.Trim();
            }
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
               

                SqlCommand cmd = new SqlCommand("update member_master_tbl set full_name=@full_name,dob=@dob,contact_no=@contact_no,email=@email,password=@password,account_status=@account_status WHERE member_id='" + Session["member_id"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox12.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox13.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox14.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password);
                //cmd.Parameters.AddWithValue("@account_status", "pending");
                cmd.Parameters.AddWithValue("@account_status", getAccountStatus());

                update_guitar_master_tbl();
                Session["fullname"] = TextBox11.Text.Trim();
                


                int result = cmd.ExecuteNonQuery();
                con.Close();

               

                if (result > 0)
                {

                    Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                    getUserPersonalDetails();
                    GridView1.DataBind();
                  
                }
                else
                {
                    Response.Write("<script>alert('Invaid entry');</script>");
                }
               

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }        //done

        void update_guitar_master_tbl() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("update guitar_master_tbl set publisher_name=@publisher_name WHERE publisher_name='" + Session["fullname"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@publisher_name", TextBox11.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        void getUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='" + Session["member_id"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox11.Text = dt.Rows[0]["full_name"].ToString();
                TextBox12.Text = dt.Rows[0]["dob"].ToString();
                TextBox13.Text = dt.Rows[0]["contact_no"].ToString();
                TextBox14.Text = dt.Rows[0]["email"].ToString();
                TextBox8.Text = dt.Rows[0]["member_id"].ToString();
                TextBox9.Text = dt.Rows[0]["password"].ToString();



                Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();

                if (dt.Rows[0]["account_status"].ToString().Trim() == "active")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "deactive")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-info");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }          //done

        
    }

}