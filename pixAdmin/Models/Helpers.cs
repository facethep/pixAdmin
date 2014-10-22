using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;

namespace pixAdmin.Models
{
    public class Helpers
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
          (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


      public static string GetLocationFromIPDB(string IP)
        {

            string GeoipDb = System.Configuration.ConfigurationManager.AppSettings["GEO_COUNTRY_DB"].ToString();
            //open the database
            string retVal = "";

            try
            {
                LookupService ls = new LookupService(GeoipDb, LookupService.GEOIP_MEMORY_CACHE);
                //get country of the ip address
                Country c = ls.getCountry(IP);

                if (c != null)
                {
                    retVal = c.getCode();
                    //-- means there is no city for that IP in the database
                    if (retVal  =="--") { retVal = "";}
                }
            }

            catch (Exception e)
            {
                log.Error("Could not return IP from DATABASE", e);
                retVal = "";
            }

            if (retVal==""){
                    retVal = GetLocationFromIP(IP);
            }
           
            
            return retVal;
        }

        public static string GetLocationFromIP(string IP)
        {
            string strRequestLocation = "http://freegeoip.net/xml/";
            WebClient proxy = new WebClient();

            strRequestLocation += IP;
            XmlDocument xml = new XmlDocument();
            string retVal = "N/A";
             

            try
            {
                if (!proxy.IsBusy)
                {
                    var response = proxy.DownloadString(strRequestLocation);
                    xml.LoadXml(response);
                    XmlNode node = xml.SelectSingleNode("/Response/CountryCode");
                    retVal = node.InnerText;
                }
            }

            catch (Exception e)
            {
                log.Error("rController - Error getting location for IP: " + IP, e);

            }
            proxy.Dispose();

            return retVal;
        }

    }
}