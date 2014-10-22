using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pixAdmin.DBStats;


namespace pixAdmin
{
    public partial class PagesByGEO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                BindPages();
            }
       
        }

     private void BindPages()
        {
            var db = new PetaPoco.Database("myConnectionString");
            string sQuery = "select  * from LandingPagesByGEO";
            var result = db.Query <pixLandingPagesByGEO>(sQuery);
            grdPageByGeo.DataSource = result;
            grdPageByGeo.DataBind();
            db.CloseSharedConnection();
        }
    }
}