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
    public partial class update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }





        protected void Button1_Click(object sender, EventArgs e)
        {
            var db = new PetaPoco.Database("myConnectionString");


            string queryBooks = "SELECT top 1000 id, user_ip FROM Requests where countryCode is Null";
            var result = db.Query<pixRequests>(queryBooks);

            String strcountryCode = string.Empty;
            lblCountry.Text = "STARTING to update records !!";

            foreach (var item in result)
            {

                strcountryCode = Helpers.GetLocationFromIPDB(item.user_ip);

                // item.countryCode = strcountryCode;
                //  db.Update("Requests", "countryCode", new { countryCode = strcountryCode }, item.id);

                db.Update<pixRequests>("SET countryCode=@0 WHERE id=@1", strcountryCode, item.id);
                // db.CloseSharedConnection();

                //   db.Update<pixRequests>(item, new string[] { "countryCode" });

                //get country code


            }
            lblCountry.Text = "FINISHED 1000 records !!";
            db.CloseSharedConnection();
            db.Dispose();
        }
    }
}