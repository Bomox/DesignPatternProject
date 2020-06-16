using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
   public class WarframeRepository : BaseRepository<Warframe>
    {
        private static bool instanceFlag = false;

        public static WarframeRepository getMethod()
        {
            if (!instanceFlag)
            {
                instanceFlag = true;
                return new WarframeRepository();
            }
            else
            {
                return null;
            }
        }

        public void Save(Warframe warframe)
        {
            if (warframe.ID == 0)
            {
                base.Create(warframe);
            }
            else
            {
                base.Update(warframe, item => item.ID == warframe.ID);
            }
        }
      #region .
        private static bool instanceFlagTwo = false;

        public static WarframeRepository getMethodTwo()
        {
            if (!instanceFlagTwo)
            {
                instanceFlagTwo = true;
                return new WarframeRepository();
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}

