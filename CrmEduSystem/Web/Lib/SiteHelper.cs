using Models;
using System.Linq;

namespace Lib
{
    public class SiteHelper
    {
        public static Models.Site Default
        {
            get
            {
                return new SiteLogic().GetSites(new Models.Site() { }).FirstOrDefault();
            }
        }
    }
}