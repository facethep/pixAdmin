using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using pixAdmin.DBStats;

/*
 name of two tables is the same
 * add total
 * add average for conversion
 */

namespace pixAdmin
{
    public partial class Stats : System.Web.UI.Page
    {

        int totalErrors = 0;
        int totalInstalls = 0;
        float totalRevenu = 0;
        //float totalRevenuSent = 0;
        float totalCost = 0;



        public string strProvider;
        
        decimal totalConv = 0;
       
        int totalResponse = 0;
        int totalRequest = 0;

        enum lableType{ Provider=1, Country};
    
        protected void Page_Load(object sender, EventArgs e)
        {

          
            strProvider = drpProviders.SelectedValue;

            if (!Page.IsPostBack)
            {
                txtStartDate.Text = System.DateTime.Today.ToShortDateString();
                txtEndDate.Text = System.DateTime.Today.ToShortDateString();


               var db = new PetaPoco.Database("myConnectionString");
                string sQuery = "SELECT id, name + ' - ' + pcmac + ' - ' + cast( id as varchar) as name  FROM providers order by name asc";
                var result = db.Fetch<pixProviders>(sQuery);
                
                
                drpProviders.DataSource = result;
                drpProviders.DataBind();
                drpProviders.Items.Add(new ListItem("ALL", "-1"));
                drpProviders.SelectedValue = "-1";
                db.CloseSharedConnection();
                
             


            }
        }

        protected void btnStatsPerCountryCode_Click(object sender, EventArgs e)
        {

            var db = new PetaPoco.Database("myConnectionString");

            string sQuery = "select  countryCode name, sum(requestCount) Requests, sum(responseCount) Response, "; 
            sQuery = sQuery + " cast(cast( sum(responseCount) as decimal(10,3))/ cast(sum(requestCount) as decimal(10,3))*100 as decimal(10,2) ) as conversion ";
            sQuery = sQuery + " from pixStats  ";
            sQuery = sQuery + "  where  ";
            sQuery = sQuery + " ((providerid=" + strProvider + ") or (-1 = " + strProvider + ")) and ";
            sQuery = sQuery + " responseCount is not null ";
            sQuery = sQuery + " group by  countryCode ";
            sQuery = sQuery + " order by 4 desc  ";


            lblTable2.Text = getLabelDesc(lableType.Country); 
                 var result = db.Query<totalConversion>(sQuery);
                 grdTotalCountry.DataSource = result;
                 grdTotalCountry.DataBind();
                 db.CloseSharedConnection();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            var db = new PetaPoco.Database("myConnectionString");
            var result =new object();
           

           string sQuery = " select ";
           if (chkDate.Checked)
           {
               sQuery = sQuery + " statDate Date, ";
           }
           else
           {
               sQuery = sQuery + " '1900-01-01' Date, ";
           }
            sQuery = sQuery + " providerName name, sum(requestCount) Requests, sum(responseCount) Response, " ;
                 sQuery = sQuery + "cast(cast( sum(responseCount) as decimal(10,3))/ cast(sum(requestCount) as decimal(10,3))*100 as decimal(10,2) ) as conversion";
                 sQuery = sQuery + " from pixStats where ";
                 sQuery = sQuery + " ((providerid=" + strProvider + ") or (-1 = " + strProvider + ")) and ";

                 if (chkDate.Checked)
                 {
                     sQuery = sQuery + "   CAST(statDate  as date) <= CAST('" + txtEndDate.Text + "'  as date) and ";
                     sQuery = sQuery + "   CAST(statDate  as date) >= CAST('" + txtStartDate.Text + "'  as date) and ";
                 }

          
                 sQuery = sQuery + " responseCount is not null";

                 if (chkDate.Checked)
                 {
                     sQuery = sQuery + " group by statDate, providerName";
                 }
                 else
                 {
                     sQuery = sQuery + " group by providerName";
                 }

                 if (chkDate.Checked)
                 {
                     sQuery = sQuery + " order by 1 desc";
                 }
                 else { 
                     sQuery = sQuery + " order by 4 desc "; }
                 
            // if (chkDate.Checked)
            //     {

                  result = db.Query<totalConversionPerDate>(sQuery);
            // }
            // else{
           //       result = db.Query<totalConversion>(sQuery);
           //  }

             lblTable1.Text = getLabelDesc(lableType.Provider);  

        grdTotalConv.DataSource = result;
        grdTotalConv.DataBind();
        db.CloseSharedConnection();


        }


        private  string getLabelDesc (Enum e){
            string lableTxt = "";
            
          

            switch (e.ToString().ToLower())
            {
                case "provider":
                    lableTxt = "Conversion per provider, ";
                    break;
                case "country":
                    lableTxt = "Conversion per country, ";
                    break;

            }            
           
                lableTxt += drpProviders.SelectedItem.Text + ", ";
            

            if (chkDate.Checked)
            {
                lableTxt += txtStartDate.Text + " - " + txtEndDate.Text;

            }

            return lableTxt;
        }

        protected void chkDaily_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDaily.Checked)
            {
                txtEndDate.Enabled = false;
                txtStartDate.Enabled = false;

            }
            else{
                txtEndDate.Enabled = true;
                txtStartDate.Enabled = true;
            }


        }

        protected void btnResponseError_Click(object sender, EventArgs e)
        {
            var db = new PetaPoco.Database("myConnectionString");

            string sQuery = "select cast( resDate as date) resDate, count(1) count from ResponseError group by cast( resDate as date) order by cast( resDate as date) desc ";
            var result = db.Query<errorResponses>(sQuery);
            grdErrorResponses.DataSource = result;
            grdErrorResponses.DataBind();




            sQuery = "select cast(statDate as date) resDate, sum(responseCount) count from pixStats group by cast(statDate as date) order by cast(statDate as date) desc";
             result = db.Query<errorResponses>(sQuery);
            grdTotalInstalls.DataSource = result;
            grdTotalInstalls.DataBind();
            db.CloseSharedConnection();




        }


        protected void grdErrorResponses_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                errorResponses product = (errorResponses)e.Row.DataItem;

                totalErrors += product.count; 

            }

            else if (e.Row.RowType == DataControlRowType.Footer)

            {

                e.Row.Cells[0].Text = "Total: ";
                e.Row.Cells[1].Text =  totalErrors.ToString();

            }
        }


        protected void grdTotalInstalls_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                errorResponses product = (errorResponses)e.Row.DataItem;

                totalInstalls += product.count; 

            }

            else if (e.Row.RowType == DataControlRowType.Footer)

            {

                e.Row.Cells[0].Text = "Total: ";
                e.Row.Cells[1].Text = totalInstalls.ToString();

            }
        }


        protected void grdTotalConv_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalConversionPerDate rowData = (totalConversionPerDate)e.Row.DataItem;

                totalResponse += rowData.Response;
                totalRequest += rowData.Requests;


            }

            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                totalConv = ((decimal)totalResponse / (decimal)totalRequest);
                e.Row.Cells[0].Text = "Total: ";
                e.Row.Cells[2].Text = totalRequest.ToString();
                e.Row.Cells[3].Text = totalResponse.ToString();
                e.Row.Cells[4].Text = (Math.Truncate(totalConv * 100*1000)/1000).ToString();

            }
        }


        protected void grdTotalCountry_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalConversion rowData = (totalConversion)e.Row.DataItem;

                totalResponse += rowData.Response;
                totalRequest += rowData.Requests;


            }

            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                totalConv = ((decimal)totalResponse / (decimal)totalRequest);
                e.Row.Cells[0].Text = "Total: ";
                e.Row.Cells[2].Text = totalRequest.ToString();
                e.Row.Cells[3].Text = totalResponse.ToString();
                e.Row.Cells[4].Text = (Math.Truncate(totalConv * 100*1000)/1000).ToString();

            }
        }

        protected void grdTiers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                sumByTier rowData = (sumByTier)e.Row.DataItem;
                totalRevenu += rowData.revenu;
                //totalRevenuSent += rowData.revenuSent;
                totalCost += rowData.cost;
                e.Row.Cells[0].Text = rowData.date.ToShortDateString();

            }

            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total: ";
                e.Row.Cells[5].Text = (totalRevenu.ToString());
                //e.Row.Cells[6].Text = (totalRevenuSent.ToString());
                e.Row.Cells[6].Text = (totalCost.ToString());


            }
        }

       


        protected void btnByTier_Click(object sender, EventArgs e)
        {
           
            //total revenu 
            var db = new PetaPoco.Database("myConnectionString");

            string sQuery = "select cast(statDate as date) Date, providerName , TierName, Sum(responseCount) installs, Sum(responseCount) * Tiers.revenu as revenu,  Sum(responseSentCount) installsSent, Sum(responseSentCount) * Tiers.cost as cost  from pixStats, Tiers";
            sQuery = sQuery + " where pixStats.countryCode = Tiers.countryCode and ";
            sQuery = sQuery + "  pixStats.providerID = Tiers.providerID and ";

            sQuery = sQuery + " ((pixStats.providerid=" + strProvider + ") or (-1 = " + strProvider + "))  ";

            if (chkDate.Checked)
            {
                sQuery = sQuery + "   and CAST(statDate  as date) <= CAST('" + txtEndDate.Text + "'  as date)  ";
                sQuery = sQuery + "   and CAST(statDate  as date) >= CAST('" + txtStartDate.Text + "'  as date)  ";
            }

            sQuery = sQuery + " group by providerName, TierName, cast(statDate as date) ,revenu, cost ";
            sQuery = sQuery + " order by providerName, cast(statDate as date) desc";
           
            var result = db.Query<sumByTier>(sQuery);
            grdTiers.DataSource = result;
            grdTiers.DataBind();
            db.CloseSharedConnection();


           



        }

       
        
      
    }
}