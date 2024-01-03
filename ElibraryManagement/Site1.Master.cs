using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"]==null)
                {
                    LinkButton5.Visible = false; // user login link button
                    LinkButton1.Visible = true; // user login link button
                    LinkButton2.Visible = true; // sign up link button

                    LinkButton3.Visible = false; // logout link button
                    LinkButton7.Visible = false; // hello user link button

                    LinkButton30.Visible = false; // member management link button
                    LinkButton13.Visible = false;
                    LinkButton18.Visible = false;
                    LinkButton50.Visible = false;
                    LinkButton51.Visible = false;



                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = false; // sign up link button

                    LinkButton3.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton30.Visible = false;
                    LinkButton18.Visible = false;
                    LinkButton50.Visible = false;
                    LinkButton51.Visible = false;

                    LinkButton7.Text = "Привіт, " + Session["member_id"].ToString();


                 

                }

                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = false; // sign up link button

                    LinkButton3.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello Admin";


                   
                    LinkButton13.Visible = false; // member management link button
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }
        protected void LinkButton50_Click(object sender, EventArgs e)
        {
            Response.Redirect("reportingGuitars.aspx");
        }
        protected void LinkButton51_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("reportingUsers.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("guitarinventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewguitars.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("guitarinventory.aspx");
        }

        protected void LinkButton13_Click(object sender, EventArgs e)
        {
            Response.Redirect("favviewguitars.aspx");
        }

        protected void LinkButton31_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewguitars.aspx");
        }

        //logout button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["member_id"] = null;
            Session["fullname"] = null;
            Session["role"] = null;
            Session["status"] = null;

            LinkButton31.Visible = true; // user login link button
            LinkButton30.Visible = false; // sign up link button

            LinkButton5.Visible = false; // logout link button
            LinkButton13.Visible = false;

            LinkButton1.Visible = true; // user login link button
            LinkButton2.Visible = true; // sign up link button

            LinkButton3.Visible = false; // logout link button
            LinkButton18.Visible = false; // hello user link button

            LinkButton7.Visible = false; // member management link button
            Response.Redirect("homepage.aspx");
        }

        // view profile
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }

        protected void LinkButton18_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }

        protected void LinkButton30_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }
    }
}