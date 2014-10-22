    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pixAdmin.DBStats
{


    public class SumReqRes
    {
        public string name { get; set; }
        public DateTime date { get; set; }
        public int sum { get; set; }
        public int sentToProvider { get; set; }

        

    }

    

    public class sumInstalls
    {
        public string Name { get; set; }
        public DateTime date { get; set; }
        public string countryCode{ get; set; }
        public int installs{ get; set; }
        public int sentToProvider { get; set; }

    }

    public class sumByTier
    {
        public DateTime date { get; set; }
        public string providerName { get; set; }

        public string TierName { get; set; }

        public int installs { get; set; }
        public int installsSent { get; set; }
        
        public float revenu { get; set; }
        public float cost { get; set; }

        

    }

    public class RequestCount
    {
        public string name { get; set; }
        public DateTime date { get; set; }
        public string countryCode { get; set; }
       public int sum { get; set; }

    }

    [PetaPoco.TableName("Providers")]
    [PetaPoco.PrimaryKey("id",autoIncrement=false)]
    public class pixProviders
    {
        public int id { get; set; }
        public string name { get; set; }
        public string pixel_url { get; set; }
        public string method { get; set; }
        public Boolean isActive { get; set; }
        public string pcmac { get; set; }
        public string param1 { get; set; }
        public string param2 { get; set; }
        public string param3 { get; set; }
        public short sendResponseEvery { get; set; }
        public string pixel_url_Text2Replace { get; set; }



    }

    [PetaPoco.TableName("LandingPagesByGEO")]
    [PetaPoco.PrimaryKey("pageid,countryCode")]
    public class pixLandingPagesByGEO
    {
        public int pageid { get; set; }
        public string countryCode { get; set; }
        public string url { get; set; }

    }


    [PetaPoco.TableName("LandingPages")]
   [PetaPoco.PrimaryKey("id", autoIncrement = false)]
    public class pixLandingPages
    {
        public int id { get; set; }
        public string name { get; set; }
        public string advertizer { get; set; }
        public string url { get; set; }
        public Boolean isActive { get; set; }
        public string pcmac { get; set; }

    }


    public class pixTiers_presentation
    {
        public long id { get; set; }
        public int providerID { get; set; }
        public string providerName { get; set; }
        public string TierName { get; set; }
        public string countryCode { get; set; }
        public decimal revenu { get; set; }
        public decimal cost { get; set; }
    }
            



    [PetaPoco.TableName("Tiers")]
    [PetaPoco.PrimaryKey("id", autoIncrement = true)]
    public class pixTiers
    {
        public long id { get; set; }
        public int providerID { get; set; }
        public string TierName { get; set; }
        public string countryCode { get; set; }
        public decimal revenu { get; set; }

        public decimal cost{ get; set; }

    }


    [PetaPoco.TableName("Requests")]
    [PetaPoco.PrimaryKey("id", autoIncrement = true)]

    public class pixRequests
    {
        public long id { get; set; }
        public DateTime date_created { get; set; }
        public Guid reqGuid { get; set; }
        public int providerid { get; set; }
        public int pageid { get; set; }
        public string full_url { get; set; }
        public string redirect_to { get; set; }
        public string param1 { get; set; }
        public string param2 { get; set; }
        public string param3 { get; set; }
        public string user_ip { get; set; }
        public string platform { get; set; }
        public string countryCode { get; set; }
    }


    [PetaPoco.TableName("Responses")]
    [PetaPoco.PrimaryKey("id", autoIncrement = true)]
    public class pixResponses
    {
        public long id { get; set; }
        public DateTime date_created { get; set; }
        public Guid resGuid { get; set; }
        public string full_url { get; set; }
        public string response_url { get; set; }
        public string user_ip { get; set; }
        public Boolean sentToProvider { get; set; }
        //public string platform { get; set; }
        public string countryCode { get; set; }
    }



    public class totalConversion
    {
        public DateTime date { get; set; }
        public string name { get; set; }
        public int Requests { get; set; }
        public int Response { get; set; }
        public Decimal conversion { get; set; }

    }


    public class totalConversionPerDate
    {
        public DateTime date { get; set; }
        public string name { get; set; }
        public int Requests { get; set; }
        public int Response { get; set; }
        public Decimal conversion { get; set; }

    }

    public class errorResponses
    {
        public DateTime resDate { get; set; }
        public int count{ get; set; }
        

    }


    [PetaPoco.TableName("LandingPagesMask")]
    [PetaPoco.PrimaryKey("id", autoIncrement = true)]
    public class pixPageRedirection
    {
        public int  id{ get; set; }
        public int providerid { get; set; }
        public int pageid_origin { get; set; }
        public int pageid_redirectTo { get; set; }


    }

    [PetaPoco.TableName("LandingPages_X_Mask")]
    [PetaPoco.PrimaryKey("id")]
    public class pixLandingPages_X_Mask
    {
        public int id { get; set; }
        public int providerid { get; set; }
        public int pageid { get; set; }
        public string countryCode { get; set; }
        public int sendResponseEvery_x { get; set; }
    }


     [PetaPoco.TableName("LandingPagesMask")]
    [PetaPoco.PrimaryKey("id")]
    public class pixLandingPagesMask
    {
        public int id { get; set; }
        public int providerid { get; set; }
        public int pageid_origin { get; set; }
        public int pageid_redirectTo { get; set; }
        


    }

}