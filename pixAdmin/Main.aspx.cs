using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pixAdmin.DBStats;


/*
 1. move all buttons below date
 * first select date than provider
 *  We shoudl add total to:
Request to landing page,  Responses (Pixel notification), Installs Per GEO
 
 */

namespace pixAdmin
{
    public partial class Main : System.Web.UI.Page
    {

        public string strProvider, strPage;
        int total = 0;
           
        
        protected void Page_Load(object sender, EventArgs e)
        {
             strProvider = drpProviders.SelectedValue;
             strPage = drpPage.SelectedValue;

             if (!Page.IsPostBack)
             {
                 txtFromDate.Text = System.DateTime.Today.ToShortDateString();
                 txtToDate.Text = System.DateTime.Today.ToShortDateString();

                 pixProviders t = new pixProviders();
                 t.name = "ALL -choose wisely";
                 t.id = -1;

                 var db = new PetaPoco.Database("myConnectionString");
                 string sQuery = "SELECT id, name + ' - ' + pcmac + ' - ' + cast( id as varchar) as name  FROM providers order by name asc";
                 var result = db.Fetch<pixProviders>(sQuery);
                 result.Add(t);
                 result.Reverse();
                 drpProviders.DataSource = result;
                 drpProviders.DataBind();
                 db.CloseSharedConnection();
                 
                //  ListItem i = new ListItem("ALL -choose wisely","-1");
                 // drpProviders.Items.Add(i)

                 pixLandingPages l = new pixLandingPages();
                 l.name = "ALL -choose wisely";
                 l.id = -1;
                 sQuery = "SELECT id, cast( id as varchar) + ' - ' + name + ' - ' + pcmac  as name  FROM landingpages order by name asc";
                  var result2 = db.Fetch<pixLandingPages>(sQuery);
                  result2.Add(l);
                  result2.Reverse();
                  drpPage.DataSource = result2;
                  drpPage.DataBind();
                  db.CloseSharedConnection();


             }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var db = new PetaPoco.Database("myConnectionString");

            //Request.Form.Keys("datepicker")

            string sQuery = "select  Providers.name + ' - '+Providers.pcmac as name, CAST(date_created  as date) as date, count(1) as sum from Providers, Requests ";
            sQuery = sQuery + " where Providers.id = Requests.providerid";
            sQuery = sQuery + " and ((Providers.id=" + strProvider + ") or (-1 = " + strProvider + "))";
            sQuery = sQuery + " and  CAST(Requests.date_created  as date) <= CAST('" + txtToDate.Text + "'  as date) ";
            sQuery = sQuery + " and  CAST(Requests.date_created  as date) >= CAST('" + txtFromDate.Text + "'  as date) ";
            sQuery = sQuery + " group by Providers.name + ' - '+Providers.pcmac, CAST(date_created  as date)";
            sQuery = sQuery + " order by CAST(date_created  as date) desc";

            var result = db.Query<SumReqRes>(sQuery);
            GridView1.DataSource = result;
            GridView1.DataBind();



            sQuery = " select  Providers.name + ' - '+Providers.pcmac as name, CAST(Responses.date_created  as date) as date, count(1)  as sum from Providers, Requests, Responses";
            sQuery  = sQuery  + " where Providers.id = Requests.providerid";
            sQuery  = sQuery  + " and Responses.resGuid = Requests.reqGuid";
            sQuery = sQuery   + " and ((Providers.id=" + strProvider + ") or (-1 = " + strProvider + "))";
            sQuery = sQuery + " and  CAST(Responses.date_created  as date) <= CAST('" + txtToDate.Text + "'  as date) ";
            sQuery = sQuery + " and  CAST(Responses.date_created  as date) >= CAST('" + txtFromDate.Text + "'  as date) ";
            sQuery = sQuery + " group by Providers.name + ' - '+Providers.pcmac, CAST(Responses.date_created  as date)";
            sQuery  = sQuery  + " order by CAST(Responses.date_created  as date) desc";

            result = db.Query<SumReqRes>(sQuery);
            GridView2.DataSource = result;
            GridView2.DataBind();
            db.CloseSharedConnection();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var db = new PetaPoco.Database("myConnectionString");

            string strProvider = drpProviders.SelectedValue;

            string sQuery = "select Providers.name + ' - '+Providers.pcmac as name, CAST(date_created  as date) as date, countryCode, count (1) as 'sum' from Requests, Providers ";
            sQuery = sQuery + " where Requests.providerid = Providers.id ";
            sQuery = sQuery + " and ((Providers.id=" + strProvider + ") or (-1 = " + strProvider + "))";
            sQuery = sQuery + " and  CAST(Requests.date_created  as date) <= CAST('" + txtToDate.Text + "'  as date) ";
            sQuery = sQuery + " and  CAST(Requests.date_created  as date) >= CAST('" + txtFromDate.Text + "'  as date) ";
            sQuery = sQuery + " group by countryCode, CAST(date_created  as date)  ,Providers.name + ' - '+Providers.pcmac";
            sQuery = sQuery + " order by CAST(date_created  as date) desc, count(1) desc";

            var result = db.Query<RequestCount>(sQuery);
            GridView3.DataSource = result;
            GridView3.DataBind();
            db.CloseSharedConnection();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            var db = new PetaPoco.Database("myConnectionString");

            string sQuery = "select  Providers.name + ' - '+Providers.pcmac as name, CAST(Responses.date_created  as date) as date, countryCode, count(1) as installs,sum(CASE WHEN sentToProvider = 1 THEN 1 END)   as sentToProvider  from  responses, Providers";
            sQuery = sQuery + " where Responses.providerid = Providers.id ";
            sQuery = sQuery + " and Responses.providerid = Providers.id";
            sQuery = sQuery + " and  CAST(Responses.date_created  as date) <= CAST('" + txtToDate.Text + "'  as date) ";
            sQuery = sQuery + " and  CAST(Responses.date_created  as date) >= CAST('" + txtFromDate.Text + "'  as date) ";
            sQuery = sQuery + " and ((Responses.providerid=" + strProvider + ") or (-1 = " + strProvider + "))";
            sQuery = sQuery + " group by Responses.countryCode, CAST(Responses.date_created  as date) ,Providers.name + ' - '+Providers.pcmac";
            sQuery = sQuery + " order by Providers.name + ' - '+Providers.pcmac, CAST(Responses.date_created  as date) desc , installs desc";


            var result = db.Fetch<sumInstalls>(sQuery);
            GridView4.DataSource = result.ToList();
            GridView4.DataBind();
            db.CloseSharedConnection();

        }


        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RequestCount product = (RequestCount)e.Row.DataItem;

                total += product.sum; 

            }

            else if (e.Row.RowType == DataControlRowType.Footer)

            {

                e.Row.Cells[2].Text = "Total: ";
                e.Row.Cells[3].Text = total.ToString();

            }
        }

        protected void btnInstalls_Click(object sender, EventArgs e)
        {
            var db = new PetaPoco.Database("myConnectionString");

            string sQuery = " select  Providers.name + ' - '+Providers.pcmac as name, CAST(Responses.date_created  as date) as date, count(1)  as sum ,sum(CASE WHEN sentToProvider = 1 THEN 1 END)   as sentToProvider from Providers,  Responses";
            sQuery = sQuery + " where Providers.id = Responses.providerid";
            sQuery = sQuery + " and ((Providers.id=" + strProvider + ") or (-1 = " + strProvider + "))";
            sQuery = sQuery + " and  CAST(Responses.date_created  as date) <= CAST('" + txtToDate.Text + "'  as date) ";
            sQuery = sQuery + " and  CAST(Responses.date_created  as date) >= CAST('" + txtFromDate.Text + "'  as date) ";
            sQuery = sQuery + " group by Providers.name + ' - '+Providers.pcmac, CAST(Responses.date_created  as date)";
            sQuery = sQuery + " order by CAST(Responses.date_created  as date) desc";

            var result = db.Query<SumReqRes>(sQuery);
            GridView2.DataSource = result;
            GridView2.DataBind();
            db.CloseSharedConnection();
        }

        protected void btnInstallByGEO_SUM_Click(object sender, EventArgs e)
        {
            var db = new PetaPoco.Database("myConnectionString");

            string sQuery = "select  Providers.name + ' - '+Providers.pcmac as name,  countryCode, count(1) as installs,sum(CASE WHEN sentToProvider = 1 THEN 1 END)   as sentToProvider  from  responses, Providers";
            sQuery = sQuery + " where Responses.providerid = Providers.id ";
            sQuery = sQuery + " and Responses.providerid = Providers.id";
            sQuery = sQuery + " and  CAST(Responses.date_created  as date) <= CAST('" + txtToDate.Text + "'  as date) ";
            sQuery = sQuery + " and  CAST(Responses.date_created  as date) >= CAST('" + txtFromDate.Text + "'  as date) ";
            sQuery = sQuery + " and ((Responses.providerid=" + strProvider + ") or (-1 = " + strProvider + "))";
            sQuery = sQuery + " group by Responses.countryCode, Providers.name + ' - '+Providers.pcmac";
            sQuery = sQuery + " order by Providers.name + ' - '+Providers.pcmac, installs desc";


            var result = db.Fetch<sumInstalls>(sQuery);
            GridView4.DataSource = result.ToList();
            GridView4.DataBind();
            db.CloseSharedConnection();
        }

        protected void btnpageInstalls_Click(object sender, EventArgs e)
        {
            var db = new PetaPoco.Database("myConnectionString");

            string sQuery = " select  cast( landingpages.id as varchar) + ' - ' + landingpages.name + ' - '+landingpages.pcmac as name,  countryCode, count(1)  as sum ,sum(CASE WHEN sentToProvider = 1 THEN 1 END)   as sentToProvider from landingpages,  Responses";
            sQuery = sQuery + " where landingpages.id = Responses.pageid";
            sQuery = sQuery + " and ((landingpages.id=" + strPage + ") or (-1 = " + strPage + "))";
            sQuery = sQuery + " and  CAST(Responses.date_created  as date) <= CAST('" + txtToDate.Text + "'  as date) ";
            sQuery = sQuery + " and  CAST(Responses.date_created  as date) >= CAST('" + txtFromDate.Text + "'  as date) ";
            sQuery = sQuery + " group by cast( landingpages.id as varchar) + ' - ' + landingpages.name + ' - '+landingpages.pcmac, countryCode";
            sQuery = sQuery + " order by 1,3 desc";

            var result = db.Query<pageInstalls>(sQuery);
            grdpageInstalls.DataSource = result;
            grdpageInstalls.DataBind();
            db.CloseSharedConnection();
        }
    }
}