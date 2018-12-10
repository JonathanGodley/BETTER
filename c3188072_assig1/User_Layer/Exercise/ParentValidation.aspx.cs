using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using c3188072_assig1.Models;

namespace c3188072_assig1.User_Layer.Exercise
{
    public partial class ParentValidation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // check if user has pending points
            try
            {
                int UserID = int.Parse(Page.RouteData.Values["var"].ToString());

                //string query = "";
                //Utilities.SelectQuery(query);

                // redirect to home page
                Response.BufferOutput = true;
                Response.Redirect("~/Default");
            }
            catch
            {
                // if no userID provided
                Response.BufferOutput = true;
                Response.Redirect("~/Shared/ErrorPage");
            }
        }
    }
}