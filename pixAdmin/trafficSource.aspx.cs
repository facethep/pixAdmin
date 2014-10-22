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
    public partial class trafficSource : System.Web.UI.Page
    {

     

        public class sourceType
        {
            public string pageName { get; set; }
            public string providerName { get; set; }
            public int pageCount { get; set; }
            public int Installs{ get; set; }
            public decimal conversion { get; set; }
            

        }
        private string strPCMC;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private void showData()
        {
            lblTime1.Text = "Traffic sources in the past " + drpDays.SelectedItem;

            var db = new PetaPoco.Database("myConnectionString");
            List<sourceType> ppList = new List<sourceType>();
            List<sourceType> ppList2 = new List<sourceType>();

            string strSQL = "select *,  cast((cast(Installs as decimal)/ cast(pageCount as decimal) *100)  as decimal (7,3) ) as conversion from ( ";
            strSQL += " select pageName, providerName,  count(pageName) pageCount, dbo.Responses_Calc_Sum(provider_id,page_id," + drpDays.SelectedValue + ") as Installs from";
            strSQL += "(select providers.id as provider_id, landingPages.id as page_id, (providers.name + ' - ' + providers.pcmac  +' - ' + cast(providers.id as varchar(4) )) as providerName, ";
            strSQL += " landingPages.name + ' - ' + cast(landingpages.id as varchar(4)) as pageName ";
            strSQL += " from Requests, landingPages, providers";
            strSQL += " where ";
            strSQL += " cast(date_created as datetime)  > getdate() - " + drpDays.SelectedValue;
            strSQL += " and Requests.pageid = LandingPages.id";
            strSQL += " and Requests.providerid = Providers.id";
            strSQL += " and  providerid <> 2045 and providerid <>1000 ";
            if (strPCMC != String.Empty)
                strSQL += " and Providers.pcmac='" + strPCMC +"'";
            strSQL += " ) as MySelect ";
            strSQL += " group by provider_id, page_id,providerName, PageName";
             strSQL += " ) as MySelect2 ";
            strSQL += " order by pageName, pageCount desc";

            var result = db.Query<dynamic>(strSQL);

            foreach (var item in result)
            {
                sourceType oSource = new sourceType();
                oSource.pageName = item.pageName;
                oSource.providerName = item.providerName;
                oSource.pageCount = item.pageCount;
                oSource.Installs = item.Installs;
                oSource.conversion = item.conversion;

                ppList.Add(oSource);
            }
            grdTraffic.DataSource = ppList;
            grdTraffic.DataBind();


            if (drpDays2.SelectedValue!="-1")
            {
                lblTime2.Text = "Traffic sources in the past " + drpDays2.SelectedItem;

                result = null;

                strSQL = "select *,  cast((cast(Installs as decimal)/ cast(pageCount as decimal) *100)  as decimal (7,3) ) as conversion from ( ";
                strSQL += " select pageName, providerName,  count(pageName) pageCount, dbo.Responses_Calc_Sum(provider_id,page_id," + drpDays2.SelectedValue + ") as Installs from";
                strSQL += "(select providers.id as provider_id, landingPages.id as page_id, (providers.name + ' - ' + providers.pcmac  +' - ' + cast(providers.id as varchar(4) )) as providerName, ";
                strSQL += " landingPages.name + ' - ' + cast(landingpages.id as varchar(4)) as pageName ";
                strSQL += " from Requests, landingPages, providers";
                strSQL += " where ";
                strSQL += " cast(date_created as datetime)  > getdate() - " + drpDays2.SelectedValue;
                strSQL += " and Requests.pageid = LandingPages.id";
                strSQL += " and Requests.providerid = Providers.id";
                strSQL += " and  providerid <> 2045 and providerid <>1000 ";
                if (strPCMC != String.Empty)
                    strSQL += " and Providers.pcmac='" + strPCMC +"'";
                strSQL += " ) as MySelect ";
                strSQL += " group by provider_id, page_id,providerName, PageName";
                    strSQL += " ) as MySelect2 ";
                strSQL += " order by pageName, pageCount desc";

                 result = db.Query<dynamic>(strSQL);

                foreach (var item in result)
                {
                    sourceType oSource = new sourceType();
                    oSource.pageName = item.pageName;
                    oSource.providerName = item.providerName;
                    oSource.pageCount = item.pageCount;
                    oSource.Installs = item.Installs;
                    oSource.conversion = item.conversion;


                    ppList2.Add(oSource);
                }
                grdTraffic2.DataSource = ppList2;
                grdTraffic2.DataBind();


            }

        }

        protected void btnPC_Click(object sender, EventArgs e)
        {
            strPCMC = "PC";
            showData();

        }

        protected void btnMac_Click(object sender, EventArgs e)
        {
          strPCMC = "MAC";
          showData();

        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            strPCMC = string.Empty;
            showData();
        }
    }
}