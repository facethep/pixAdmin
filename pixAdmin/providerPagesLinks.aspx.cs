using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pixAdmin.Models;
using pixAdmin.DBStats;
namespace pixAdmin
{
    public partial class providerPagesLinks : System.Web.UI.Page
    {
        public class providerPages
        {
            public String pageName { get; set; }
            public String pageUrl { get; set; }

            
        }
        
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                List<pixProviders> pProviders = webSettings.loadProviders();

                lstProviders.DataSource = pProviders;
                lstProviders.DataTextField = "name";
                lstProviders.DataValueField = "id";
                lstProviders.DataBind();


            }

        }


        private void loadListBox(string pcType)
        {
            List<pixProviders> pProviders = webSettings.loadProviders();
            lstProviders.DataSource = pProviders.FindAll(x => x.pcmac == pcType);
            lstProviders.DataTextField = "name";
            lstProviders.DataValueField = "id";
            lstProviders.DataBind();  
        }
        protected void btnPC_Click(object sender, EventArgs e)
        {
            loadListBox("PC");
        }

        protected void btnMac_Click(object sender, EventArgs e)
        {
           
            loadListBox("MAC");
        }

        private void buildURLS()
        {
            string strURL = "http://www.myloopme.com/api/r/";
            string providerID = lstProviders.SelectedValue;
            string tmpStr,strParams;
             
            pixProviders provider = webSettings.GetProvider(Convert.ToInt16(providerID));

            string param1, param2, param3;
            param1 = provider.param1;
            param2 = provider.param2;
            param3 = provider.param3;

            strParams = param1 + "=[" + param1 +"]";

            if (param2 != null && param2 != String.Empty)
                strParams += '&' + param2 + "=[" + param2 +']';
            if (param3 != null &&param3 != String.Empty)
                strParams += '&' + param3 + "=[" + param3 +']';

            List<pixLandingPages> lp = webSettings.loadLandingPages();
            List<providerPages> ppList = new List<providerPages>();
            List<pixLandingPages> landingPages = lp.FindAll(x => x.pcmac == provider.pcmac);


            foreach (pixLandingPages page in landingPages)
            {
                providerPages pPage = new providerPages();

                //tmpStr = page.name + " = " + strURL +providerID + page.id.ToString() + "/?" + strParams;
                //Response.Write(tmpStr + "<br>");
                pPage.pageName = page.name;
                pPage.pageUrl = strURL + providerID + page.id.ToString() + "/?" + strParams;
                ppList.Add(pPage);
                pPage = null;
            }

            grdLinks.DataSource = ppList;
            
            grdLinks.DataBind();
        }

        protected void lstProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
            buildURLS();
        }
    }
}