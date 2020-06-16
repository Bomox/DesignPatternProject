using System;
using DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
     public class WeaponRepository : BaseRepository<Weapon>
    {
        private static bool instanceFlag = false;

        public static WeaponRepository getMethod()
        {
            if (!instanceFlag)
            {
                instanceFlag = true;
                return new WeaponRepository();

            }
            else
            {
                return null;
            }
        }

        public void Save(Weapon weapon)
        {
            if (weapon.ID == 0)
            {
                base.Create(weapon);
            }
            else
            {
                base.Update(weapon, item => item.ID == weapon.ID);
            }
        }
     #region .
        private static bool instanceFlagTwo = false;

        public static WeaponRepository getMethodTwo()
        {
            if (!instanceFlagTwo)
            {
                instanceFlagTwo = true;
                return new WeaponRepository();
            }
            else
            {
                return null;
            }
        }
        #endregion
     }
}
