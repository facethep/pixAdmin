using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using pixAdmin.DBStats;

namespace pixAdmin.UC
{
    public partial class ucProviders : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                var db = new PetaPoco.Database("myConnectionString");
                string sQuery = "SELECT id, name + ' - ' + pcmac + ' - ' + cast( id as varchar) as name  FROM providers";
                var result = db.Fetch<pixProviders>(sQuery);
                drpProviders.DataSource = result;
                drpProviders.DataBind();
                db.CloseSharedConnection();

            
            }
        }
    }
}