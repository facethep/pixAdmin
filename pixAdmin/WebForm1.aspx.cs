using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetaPoco;
using pixAdmin.DBStats;
using log4net;

namespace pixAdmin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
       

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string strProvider;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            strProvider =  drpProviders.SelectedValue;

            if (!Page.IsPostBack)
            {
                var db = new PetaPoco.Database("myConnectionString");
                string sQuery = "SELECT id, name + ' - ' +cast( id as varchar) as name  FROM providers";
                var result = db.Fetch<pixProviders>(sQuery);
                drpProviders.DataSource = result;
                drpProviders.DataBind();
             


                sQuery = "SELECT id, name + ' - ' +cast( id as varchar) as name  FROM landingpages";
                 var result1 = db.Fetch<pixLandingPages>(sQuery);
                drpPages.DataSource = result1;
                drpPages.DataBind();
                db.CloseSharedConnection();
                


            }



        }

       

   

        protected void Button2_Click(object sender, EventArgs e)
        {

            log.Error("erro me");
            log.Debug("debug me");
            log.Fatal(" fatal me");
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            var db = new PetaPoco.Database("myConnectionString");

           string queryBooks = "SELECT * FROM Requests order by date_created desc"; 
        var result = db.Query<pixRequests>(queryBooks);
       // GridView1.DataSource = result;
        //GridView1.DataBind(); 


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            var db = new PetaPoco.Database("myConnectionString");

            string queryBooks = "SELECT * FROM Responses order by date_created desc";
            var result = db.Query<pixResponses>(queryBooks);
          //  GridView1.DataSource = result;
           // GridView1.DataBind(); 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnIsGUID_Click(object sender, EventArgs e)
        {
            Guid oGuid;
            if (Guid.TryParse(txtGUID.Text, out oGuid))
            {
                lblIsGuid.Text = oGuid.ToString();
                lblIsGuid.ForeColor =System.Drawing.Color.Green;
            }
            else{
                lblIsGuid.Text = "Damm, this is NOT GUID !";
                lblIsGuid.ForeColor =System.Drawing.Color.Red;
            }


        }

            
    }
}