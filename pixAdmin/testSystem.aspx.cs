using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pixAdmin.Models;

namespace pixAdmin
{
    public partial class testSystem : System.Web.UI.Page
    {
        private List<string> cacheItems = new List<string>(new string[] { "providers", "landingPages", "landingPagesByGeo", "landingPagesMask", "landingPages_X_Mask" });


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            foreach (string cacheName in cacheItems) // Loop through List with foreach
            {
                cacheSettings.RemoveFromCache(cacheName);
            }
        }
    }
}