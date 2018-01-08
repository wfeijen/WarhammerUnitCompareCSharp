using System;


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
            _name = name;
            _pts = pts;
            _shots = shots;
            _range = range;
            _type = type;
            _S = S;
            _AP = AP;
            _D = D;
            _Abilities = Abilities;
            _MD = MD;
            _WarpCharge = WarpCharge;
        }

        public Weapon(string csvString)
        {
            string values = line.Split(';');
            if (len(values) != 11)
            {
                MessageBox.Show("Only " + len(values) + " in weapon row.", "Critical Warning", true);
                throw new System.ArgumentOutOfRangeException("Only " + len(values) + " in weapon row.", "original");
            }
            _name = values[0];
            _pts = values[1];
            _shots = values[2];
            _range = values[3];
            _type = values[4];
            _S = values[5];
            _AP = values[6];
            _D = values[7];
            _Abilities = values[8];
            _MD = values[9];
            _WarpCharge = values[10];
        }
    }

