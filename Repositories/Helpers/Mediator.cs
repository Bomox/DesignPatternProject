using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Repositories.Helpers
{
    public class Mediator
    {
         WarframeRepository mediatorwarframe;
         WeaponRepository mediatorweapon;

        public Mediator(WarframeRepository warframe, WeaponRepository weapon)
        {
            mediatorweapon = weapon;
            mediatorwarframe = warframe;
        }

        public void ClearDatabase()
        {
            List<Weapon> weapons = mediatorweapon.GetAll();
            List<Warframe> warframes = mediatorwarframe.GetAll();

            for(int i = 1; i <= weapons.Capacity; i++)
            {
                mediatorweapon.DeleteByID(weapons[i].ID);
            }

            for (int i = 1; i <= warframes.Capacity; i++)
            {
                mediatorwarframe.DeleteByID(warframes[i].ID);
            }
        }
    }
}
