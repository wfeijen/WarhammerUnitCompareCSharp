using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarhammerUnitCompareCSharp
{
    public class WeaponChoice
    {
        public long amount;
        public Weapon weapon;

        public WeaponChoice(long amountIn,Weapon weaponIn)
        {
            amount = amountIn;
            weapon = weaponIn;
        }

        public WeaponChoice copy()
        {
            return(new WeaponChoice(amount,weapon));        
        }
    }
}
