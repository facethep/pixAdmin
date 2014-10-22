using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pixAdmin.DBStats;

namespace pixAdmin
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                var db = new PetaPoco.Database("myConnectionString");
                string sQuery = "SELECT id, name + ' - ' + pcmac + ' - ' + cast( id as varchar) as name  FROM providers order by name asc";
                var result = db.Fetch<pixProviders>(sQuery);
                drpProviders.DataSource = result;
                drpProviders.DataBind();
                db.CloseSharedConnection();
                
               // ListItem i = new ListItem("Select Provider","-1");
               // drpProviders.Items.Add(i);
               

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var db = new PetaPoco.Database("myConnectionString");

            string sQuery = "SELECT top 25 * FROM Requests ";
            
                sQuery = sQuery + " where providerid=" + drpProviders.SelectedValue;
          

            sQuery = sQuery + " order by date_created desc";
            var result = db.Query<pixRequests>(sQuery);
            GridView1.DataSource = result;
            GridView1.DataBind(); 
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var db = new PetaPoco.Database("myConnectionString");

            string sQuery = "select top 50 Responses.id,Responses.date_created, Responses.resGuid, Responses.full_url, Responses.response_url , Responses.sentToProvider, countryCode FROM  Responses";
            sQuery = sQuery + " where Responses.providerid=" + drpProviders.SelectedValue; ;
            sQuery = sQuery + " order by Responses.date_created desc";


            var result = db.Query<pixResponses>(sQuery);
            GridView2.DataSource = result;
            GridView2.DataBind(); 
        }
    }
}