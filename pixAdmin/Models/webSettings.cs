using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using pixAdmin.DBStats;

namespace pixAdmin.Models
{
    static public class webSettings
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
    (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static Boolean saveIncache = false;

        static webSettings()
        {
        }

        public static List<pixProviders> loadProviders()
        {
            string cacheName = "providers";

            List<pixProviders> providers;
          //  if (!cacheSettings.IsIncache(cacheName) && saveIncache)
           // {
                var db = new PetaPoco.Database("myConnectionString");

                string sQuery = " SELECT id, name + ' - ' + pcmac + ' - ' + cast( id as varchar) as name, pixel_url, sendResponseEvery, upper(pcmac) as pcmac, param1,param2,param3  FROM providers order by name asc";
            //    try
             //   {
                    var result = db.Fetch<pixProviders>(sQuery);
                    db.CloseSharedConnection();
                    providers = result.ToList();
                    cacheSettings.SaveTocache(cacheName, providers);
            //    }

             //   catch (Exception e)
             //   {
             //       log.Fatal("!! cannot load Settings of all providers !!", e);
             //   }
           // }
            //return cacheSettings.GetFromCache<List<pixProviders>>(cacheName);
            return providers;
        }


        public static pixProviders GetProvider(int provideID)
        {

            List<pixProviders> providers = loadProviders();

            try
            {

                return providers.Find(x => x.id == provideID);

            }
            catch (Exception e)
            {
                log.Fatal("!! ERROR settings - GetProvider!!", e);


            }
            return null;
        }


        public static List<pixLandingPages> loadLandingPages()
        {
            string cacheName = "landingPages";

            List<pixLandingPages> landingPages;
           // if (!cacheSettings.IsIncache(cacheName) && saveIncache)
            //{
                var db = new PetaPoco.Database("myConnectionString");
                string sQuery = "SELECT id, cast( id as varchar) +' - ' + name + ' - ' + advertizer +' -' + pcmac as name ,advertizer, url, upper(pcmac) as pcmac  FROM LandingPages";
              //  try
                //{
                    var result = db.Fetch<pixLandingPages>(sQuery);
                    db.CloseSharedConnection();
                    landingPages = result.ToList();
                  //  cacheSettings.SaveTocache(cacheName, landingPages);

              //  }

                //catch (Exception e)
                //{
                  //  log.Fatal("!! cannot load Settings of all Landing pages !!", e);
                //}
            //}
            //return cacheSettings.GetFromCache<List<pixLandingPages>>(cacheName);
                    return landingPages;
        }


        public static pixLandingPages GetPage(int pageID)
        {

            List<pixLandingPages> pages = loadLandingPages();

            return pages.Find(x => x.id == pageID);
        }


        private static List<pixLandingPagesByGEO> loadLandingPagesByGEO()
        {
            string cacheName = "landingPagesByGeo";

            List<pixLandingPagesByGEO> pagesByGEO;
          //  if (!cacheSettings.IsIncache(cacheName) && saveIncache)
           // {
                var db = new PetaPoco.Database("myConnectionString");
                string sQuery = "SELECT * FROM LandingPagesByGEO";
             //   try
              //  {
                    var result = db.Fetch<pixLandingPagesByGEO>(sQuery);
                    db.CloseSharedConnection();
                    pagesByGEO = result.ToList();
                //    cacheSettings.SaveTocache(cacheName, pagesByGEO);

                //}

                //catch (Exception e)
                //{
                 //   log.Error("!! cannot load Settings of all Landing pages By GEO !!", e);
                //}
            //}
            //return cacheSettings.GetFromCache<List<pixLandingPagesByGEO>>(cacheName);
            return pagesByGEO;
        }


        public static pixLandingPagesByGEO GetPageByGEO(int pageID, string GEO)
        {
            List<pixLandingPagesByGEO> pagesByGEO = loadLandingPagesByGEO();
            return pagesByGEO.Find(x => x.pageid == pageID && x.countryCode == GEO);
        }


        public static Boolean checkLandingPageByGeo(int pageID)
        {
            if (pageID.Equals(5000) || pageID.Equals(5010) || pageID.Equals(5011))
            {
                return false;
                //TODO: work on logic
            }
            return false;

        }



        private static List<pixLandingPagesMask> loadLandingPagesMask()
        {
            string cacheName = "landingPagesMask";

            List<pixLandingPagesMask> pagesMask;
          //  if (!cacheSettings.IsIncache(cacheName) && saveIncache)
          //  {

                var db = new PetaPoco.Database("myConnectionString");
                string sQuery = "SELECT * FROM LandingPagesMask";
            //    try
             //   {
                    var result = db.Fetch<pixLandingPagesMask>(sQuery);
                    db.CloseSharedConnection();
                    pagesMask = result.ToList();
               //     cacheSettings.SaveTocache(cacheName, pagesMask);

                //}

               // catch (Exception e)
                //{
                  //  log.Error("!! cannot load Settings of all Landing pages Mask !!", e);
                //}
            //}
            //return cacheSettings.GetFromCache<List<pixLandingPagesMask>>(cacheName);
                    return pagesMask;
        }

        public static int getRealPageID(int pageID, int providerID)
        {

            List<pixLandingPagesMask> pagesMask = loadLandingPagesMask();

            pixLandingPagesMask mask_provider, mask_global;

            mask_global = pagesMask.Find(x => x.pageid_origin == pageID && x.providerid == -1);
            mask_provider = pagesMask.Find(x => x.pageid_origin == pageID && x.providerid == providerID);

            if (mask_provider != null)
            {
                return mask_provider.pageid_redirectTo;
            }
            if (mask_global != null)
            {
                return mask_global.pageid_redirectTo;
            }



            return pageID;
        }



        private static List<pixLandingPages_X_Mask> loadLandingPagesMask_X()
        {
            string cacheName = "landingPages_X_Mask";
            List<pixLandingPages_X_Mask> pages_X_Mask;
          //  if (!cacheSettings.IsIncache(cacheName) && saveIncache)
           // {
                var db = new PetaPoco.Database("myConnectionString");
                string sQuery = "SELECT * FROM LandingPages_X_Mask";
             //   try
              //  {
                    var result = db.Fetch<pixLandingPages_X_Mask>(sQuery);
                    db.CloseSharedConnection();
                    pages_X_Mask = result.ToList();
               //     cacheSettings.SaveTocache(cacheName, pages_X_Mask);
               // }

                //catch (Exception e)
                //{
                //    log.Error("!! cannot load Settings of all Landing pages X Mask !!", e);
                //}
            //}
            //return cacheSettings.GetFromCache<List<pixLandingPages_X_Mask>>(cacheName);
                    return pages_X_Mask;
        }

        public static int getGeoX(int pageID, string countryCode, int providerid)
        {
            List<pixLandingPages_X_Mask> pages_X_Mask = loadLandingPagesMask_X();

            pixLandingPages_X_Mask pageByCountryCode;
            pixLandingPages_X_Mask pageByProviderX;

            pageByProviderX = pages_X_Mask.Find(x => x.pageid == pageID && x.countryCode == countryCode && x.providerid == providerid);
            pageByCountryCode = pages_X_Mask.Find(x => x.pageid == pageID && x.countryCode == countryCode && x.providerid == -1);


            if (pageByProviderX != null)
            {
                return pageByProviderX.sendResponseEvery_x;
            }

            if (pageByCountryCode != null)
            {
                return pageByCountryCode.sendResponseEvery_x;
            }

            return -1;
        }




    }
}

