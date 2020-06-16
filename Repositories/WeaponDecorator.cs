using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Repositories
{
    public class WeaponDecorator : BaseRepository<Weapon>
    {
        BaseRepository<Weapon> component;

        public WeaponDecorator(WeaponRepository instance)
        {
            component = instance;
        }

        public List<Weapon> GetAllAbove50()
        {
            List<Weapon> weaponsabove50 = new List<Weapon>();
            List<Weapon> weapons = component.GetAll();

            for(int i = 0; i < weapons.Count; i++)
            {
                if(weapons[i].Damage > 50)
                {
                    weaponsabove50.Add(weapons[i]);
                }
            }
            return weaponsabove50;
        }
    }
}
