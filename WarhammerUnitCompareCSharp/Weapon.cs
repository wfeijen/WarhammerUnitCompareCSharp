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

    private int makeZeroIfNotParsedInt(string input)
    {
        int tmp;
        if (int.TryParse(input, out tmp)) return tmp;
        else return 0;
    }

    private long makeZeroIfNotParsedLong(string input)
    {
        long tmp;
        if (long.TryParse(input, out tmp)) return tmp;
        else return 0;
    }

    public Weapon(string csvString)
    {
        string[] values = csvString.Split(',');
        if (values.Length != 12)
        {
            System.Windows.Forms.MessageBox.Show("Only " + values.Length + " in weapon row.", "Critical Warning");
            throw new System.ArgumentOutOfRangeException("Only " + values.Length + " in weapon row.", "original");
        }
        _faction = values[0];
        _name = values[1];
        _pts = makeZeroIfNotParsedInt(values[2]);
        _shots = makeZeroIfNotParsedLong(values[3]);
        _range = makeZeroIfNotParsedLong(values[4]);
        _type = values[5];
        _S = makeZeroIfNotParsedInt(values[6]);
        _AP = makeZeroIfNotParsedInt(values[7]);
        _D = makeZeroIfNotParsedLong(values[8]);
        _abilities = values[9];
        _MD = makeZeroIfNotParsedLong(values[10]);
        _warpCharge = makeZeroIfNotParsedLong(values[11]);
    }
}

