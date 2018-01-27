using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarhammerUnitCompareCSharp
{
    public class Unit
    {
        string _Faction = "";
        public long _Pts = 0;
        public string _Role = "";
        public string _Unit = "";
        public long _M = 0;
        public long _WS = 0;
        public long _BS = 0;
        public long _S = 0;
        public long _T = 0;
        public long _W = 0;
        public long _A = 0;
        public long _Ld = 0;
        public long _Save = 0;
        public long _WL = 0;
        public long _Inv = 0;
        public string _WeaponsString = "";
        public string _ExtraRules = "";
         //WeaponList weapons = "";

        public Unit(string Faction,
            int Pts,
            string Role,
            string Unit,
            long M,
            long WS,
            long BS,
            long S,
            long T,
            long W,
            long A,
            long Ld,
            long Save,
            long WL,
            long Inv,
            string WeaponsString,
            string ExtraRules)
        {
            _Faction = Faction;
            _Pts = Pts;
            _Role = Role;
            _Unit = Unit;
            _M = M;
            _WS = WS;
            _BS = BS;
            _S = S;
            _T = T;
            _W = W;
            _A = A;
            _Ld = Ld;
            _Save = Save;
            _WL = WL;
            _Inv = Inv;
            _WeaponsString = WeaponsString;
            _ExtraRules = ExtraRules;
        }

        public Unit(string csvString)
        {
            string[] values = csvString.Split(',');
            if (values.Length != 17)
            {
                SimpleLogger sl = new SimpleLogger("WarhammerUnitCompareCSharp.log", true);
                sl.Error("Only " + values.Length + " in unit row.");
                throw new System.ArgumentOutOfRangeException("Only " + values.Length + " in unit row.", "original");
            }
            int i = 0;
            _Faction = values[i++];
            _Pts = Utilities.makeZeroIfNotParsedLong(values[i++]);
            _Role = values[i++];
            _Unit = values[i++];
            _M = Utilities.makeZeroIfNotParsedLong(values[i++]);
            _WS = Utilities.makeZeroIfNotParsedLong(values[i++]);
            _BS = Utilities.makeZeroIfNotParsedLong(values[i++]);
            _S = Utilities.makeZeroIfNotParsedLong(values[i++]);
            _T = Utilities.makeZeroIfNotParsedLong(values[i++]);
            _W = Utilities.makeZeroIfNotParsedLong(values[i++]);
            _A = Utilities.makeZeroIfNotParsedLong(values[i++]);
            _Ld = Utilities.makeZeroIfNotParsedLong(values[i++]);
            _Save = Utilities.makeZeroIfNotParsedLong(values[i++]);
            _WL = Utilities.makeZeroIfNotParsedLong(values[i++]);
            _Inv = Utilities.makeZeroIfNotParsedLong(values[i++]);
            _WeaponsString = values[i++];
            _ExtraRules = values[i++];
        }
    }
}
