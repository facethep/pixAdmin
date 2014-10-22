using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pixAdmin.Models;
using System.Collections;

namespace pixAdmin
{
    public partial class cachObjects : System.Web.UI.Page
    {

        private List<string> cacheItems = new List<string>(new string[] { "providers", "landingPages", "landingPagesByGeo", "landingPagesMask", "landingPages_X_Mask" });

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void showCache()
        {
            HttpContext oc = HttpContext.Current;

            List<string> foundCacheItems = new List<string>();

            IDictionaryEnumerator en = oc.Cache.GetEnumerator();
            string strResult;
            while (en.MoveNext())
            {

                strResult = cacheItems.Find(item => item == en.Key.ToString());
                if (strResult != null)
                {
                    foundCacheItems.Add(strResult);
                    DataGrid aa = new DataGrid();
                    aa.EnableViewState = false;
                    aa.DataSource = en.Value;
                    aa.DataBind();
                    Label lbl = new Label();
                    lbl.Text = "<h2>Cache content of: " + en.Key + "</h2>";

                    Page.Controls.Add(lbl);

                    Page.Controls.Add(aa);

                }



                // selct case on object name and append to datagrid                 
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            showCache();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            foreach (string cacheName in cacheItems) // Loop through List with foreach
            {
                cacheSettings.RemoveFromCache(cacheName);
            }
            showCache();
        }
    }
}
