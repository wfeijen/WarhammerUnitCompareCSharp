using System;

namespace WarhammerUnitCompareCSharp
{
    public class Weapon
    {
        public string _faction;
        public string _name;
        public int _pts;
        public long _shots;
        public long _range;
        public string _type;
        public int _S;
        public int _AP;
        public long _D;
        public string _abilities;
        public long _MD;
        public long _warpCharge;

        public Weapon(string faction,
            string name,
            int pts,
            long shots,
            long range,
            string type,
            int S,
            int AP,
            long D,
            string Abilities,
            long MD,
            long WarpCharge)
        {
            _faction = faction;
            _name = name;
            _pts = pts;
            _shots = shots;
            _range = range;
            _type = type;
            _S = S;
            _AP = AP;
            _D = D;
            _abilities = Abilities;
            _MD = MD;
            _warpCharge = WarpCharge;
        }



        public Weapon(string csvString)
        {
            string[] values = csvString.Split(',');
            if (values.Length != 12)
            {
                SimpleLogger sl = new SimpleLogger("WarhammerUnitCompareCSharp.log", true);
                sl.Error("Only " + values.Length + " in weapon row.");
                throw new System.ArgumentOutOfRangeException("Only " + values.Length + " in weapon row.", "original");
            }
            _faction = values[0];
            _name = values[1];
            _pts = Utilities.makeZeroIfNotParsedInt(values[2]);
            _shots = Utilities.makeZeroIfNotParsedLong(values[3]);
            _range = Utilities.makeZeroIfNotParsedLong(values[4]);
            _type = values[5];
            _S = Utilities.makeZeroIfNotParsedInt(values[6]);
            _AP = Utilities.makeZeroIfNotParsedInt(values[7]);
            _D = Utilities.makeZeroIfNotParsedLong(values[8]);
            _abilities = values[9];
            _MD = Utilities.makeZeroIfNotParsedLong(values[10]);
            _warpCharge = Utilities.makeZeroIfNotParsedLong(values[11]);
        }
    }
}

