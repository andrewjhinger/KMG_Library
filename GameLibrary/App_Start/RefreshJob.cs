using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Caching;

namespace GameLibrary.App_Start
{
    public class RefreshJob
    {
        public static void SetupRefreshJob()
        {

            //remove a previous job
            Action remove = HttpContext.Current.Cache["Refresh"] as Action;
            if (remove is Action)
            {
                HttpContext.Current.Cache.Remove("Refresh");
                remove.EndInvoke(null);
            }

            //get the worker
            Action work = () =>
            {
                while (true)
                {
                    Thread.Sleep(60000);
                    WebClient refresh = new WebClient();
                    try
                    {
                        refresh.UploadString("http://kingmakers.thetenantartprints.com", string.Empty);
                    }
                    catch (Exception ex)
                    {
                        //snip...
                    }
                    finally
                    {
                        refresh.Dispose();
                    }

                }
            };
            work.BeginInvoke(null, null);

            //add this job to the cache
            HttpContext.Current.Cache.Add(
                "Refresh",
                work,
                null,
                Cache.NoAbsoluteExpiration,
                Cache.NoSlidingExpiration,
                CacheItemPriority.Normal,
                (s, o, r) => { SetupRefreshJob(); }
                );
        }
    }
}