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
    public partial class logic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                lstProviders.DataSource = webSettings.loadProviders();
                lstProviders.DataValueField = "id";
                lstProviders.DataTextField = "name";
                lstProviders.DataBind();



                lstPages.DataSource = webSettings.loadLandingPages();
                lstPages.DataValueField = "id";
                lstPages.DataTextField = "name";
                lstPages.DataBind();
            }

        }

        protected void lstPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intPageID = Convert.ToInt16(lstPages.SelectedValue);
            string strCountryCode = lstCountryCode.SelectedValue;
            pixProviders p = webSettings.GetProvider(Convert.ToInt16(lstProviders.SelectedValue));
            pixLandingPages page = webSettings.GetPage(webSettings.getRealPageID(intPageID, p.id));
            lblRealPage.Text = page.name;
            lblX.Text = p.sendResponseEvery.ToString();
            HyperLink1.NavigateUrl = page.url;

          

           
        }

        protected void lstCountryCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intPageID = Convert.ToInt16(lstPages.SelectedValue);
            string strCountryCode = lstCountryCode.SelectedValue;
            pixProviders p = webSettings.GetProvider(Convert.ToInt16(lstProviders.SelectedValue));

            lblGEO_X.Text = webSettings.getGeoX(intPageID, strCountryCode, p.id).ToString();
            upgateURLByGEO();
        }

        private void upgateURLByGEO()
        {
            pixLandingPagesByGEO pageByGeo;
            int intPageID = Convert.ToInt16(lstPages.SelectedValue);
            string strCountryCode = lstCountryCode.SelectedValue;
            pixLandingPages page;

            pageByGeo = webSettings.GetPageByGEO(intPageID, strCountryCode);
            if (pageByGeo != null)
            {
                HyperLink2.Visible = true;
                page = webSettings.GetPage(pageByGeo.pageid);
                lblPageByGeo.Text = page.name;
                HyperLink2.NavigateUrl = pageByGeo.url;
            }
            else
            {
                lblPageByGeo.Text = "No page by GEO";
                HyperLink2.Visible = false;
            }
        }
    }
}