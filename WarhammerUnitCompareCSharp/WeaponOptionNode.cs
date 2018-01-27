using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarhammerUnitCompareCSharp
{
    public class WeaponOptionNode
    {
        int _min, _max;
        Weapon _weapon;
        Operator _operator=Operator.Onbekend;
        List<WeaponOptionNode> _weaponOptions=new List<WeaponOptionNode>();

        public WeaponOptionNode(string stringNotation,WeaponList weaponList)
        {
            int dept = 0;
            string nextlevel="";
            string itemString = "";
            string stringNotationMinusMinMax = stripMinMaxOffString(stringNotation, ref _min, ref _max);
            foreach (Char c in stringNotationMinusMinMax)
            {
                if (c.CompareTo(']') == 0)
                {
                    dept -= dept;
                    if (dept == 0)
                    {
                        WeaponOptionNode newNode = new WeaponOptionNode(nextlevel, weaponList);
                        _weaponOptions.Add(newNode);
                        nextlevel = "";
                    }
                    if (dept < 0)
                    {
                        SimpleLogger sl = new SimpleLogger("WarhammerUnitCompareCSharp.log", true);
                        sl.Error("More ] than [ in : " + stringNotation);
                    }
                }
                if (dept > 0) nextlevel += c;
                else if (c.CompareTo('+') == 0)
                {
                    if (_operator != Operator.Or)
                    {
                        _operator = Operator.And;
                        if (itemString != "")
                        {
                            WeaponOptionNode newNode = new WeaponOptionNode(itemString, weaponList);
                            _weaponOptions.Add(newNode);
                            itemString = "";
                        }
                    }
                    else
                    {
                        SimpleLogger sl = new SimpleLogger("WarhammerUnitCompareCSharp.log", true);
                        sl.Error("Conflicting operators in: " + stringNotation);
                    }
                }
                else if (c.CompareTo('/') == 0)
                {
                    if (_operator != Operator.And)
                    {
                        _operator = Operator.Or;
                        if (itemString != "")
                        {
                            WeaponOptionNode newNode = new WeaponOptionNode(itemString, weaponList);
                            _weaponOptions.Add(newNode);
                            itemString = "";
                        }
                    }
                    else
                    {
                        SimpleLogger sl = new SimpleLogger("WarhammerUnitCompareCSharp.log", true);
                        sl.Error("Conflicting operators in: " + stringNotation);
                    }
                }
                else if("[]".IndexOf(c)<0) itemString += c;
                if (c.CompareTo('[') == 0)
                    dept += 1;
            }
            if (itemString.Length != 0)
            {
                if (_weaponOptions.Count == 0) _weapon=weaponList[itemString];
                else
                {
                    WeaponOptionNode newNode = new WeaponOptionNode(itemString, weaponList);
                    _weaponOptions.Add(newNode);
                }
            }
        }

        public static string stripMinMaxOffString(string wos, ref int minOut, ref int maxOut)
        {
            minOut = 0;
            maxOut = 0;
            int i = 0;
            string dummy = "";
            while ("0123456789".IndexOf(wos[i]) >= 0) dummy += wos[i++];
            if (dummy.Length == 0) minOut = 1;
            else minOut = Utilities.makeZeroIfNotParsedInt(dummy);
            dummy = "";
            if ("-".IndexOf(wos[i]) >= 0) i++;
            while ("0123456789".IndexOf(wos[i]) >= 0) dummy += wos[i++];
            if (dummy.Length > 0) maxOut = Utilities.makeZeroIfNotParsedInt(dummy);
            if (maxOut < minOut) maxOut = minOut;
            return(wos.Substring(i));
        }

        /*public static void getWeaponOption(string wos, ref int minOut, ref int maxOut, ref Weapon weaponOut, WeaponList weaponList)
        {
            minOut = 0;
            maxOut = 0;
            int i = 0;
            string dummy = "";
            while ("0123456789".IndexOf(wos[i]) >= 0) dummy += wos[i++];
            if (dummy.Length == 0) minOut = 1;
            else minOut = Utilities.makeZeroIfNotParsedInt(dummy);
            dummy = "";
            if ("-".IndexOf(wos[i]) >= 0) i++;
            while ("0123456789".IndexOf(wos[i]) >= 0) dummy += wos[i++];
            if (dummy.Length > 0)  maxOut = Utilities.makeZeroIfNotParsedInt(dummy);
            if (maxOut < minOut) maxOut = minOut;
            dummy = wos.Substring(i);
            weaponOut = weaponList[dummy];
        }*/

        private List<List<WeaponChoice>> combineAnd(List<WeaponOptionNode> wonl, int i)
        {
            List<List<WeaponChoice>> firstPart = wonl[i].validWeaponLists();
            if (i < wonl.Count-1)
            {
                List<List<WeaponChoice>> answer = new List<List<WeaponChoice>>();
                List<List<WeaponChoice>> secondPart = combineAnd(wonl, i + 1);
                foreach (List<WeaponChoice> wcf in firstPart)
                    foreach (List<WeaponChoice> wcs in secondPart)
                        answer.Add(wcf.Concat(wcs).ToList());
                return (answer);
            }
            else return firstPart;
        }

        public List<List<WeaponChoice>> validWeaponLists()
        {
            List<List<WeaponChoice>> answer = new List<List<WeaponChoice>>();

            if (_weapon == null)
            {// this means that we have a list
                if (_operator == Operator.Or)
                {
                    for (int i = _min; i <= _max; i++)                    
                        foreach (WeaponOptionNode won in _weaponOptions)                        
                            foreach (List<WeaponChoice> wol in won.validWeaponLists())
                            { 
                                foreach (WeaponChoice wc in wol)
                                {
                                    wc.amount = wc.amount * i;
                                }
                                answer.Add(wol);
                            }  
                 }
                else
                {// + and -> which means that we need to make al the combinations
                    List<List<WeaponChoice>> temp = combineAnd(_weaponOptions, 0);
                    for (int i = _min; i <= _max; i++)
                        foreach (List<WeaponChoice> wcl in temp)
                        {
                            List<WeaponChoice> wclNew = new List<WeaponChoice>();
                            foreach (WeaponChoice wc in wcl)
                            {
                                WeaponChoice wcNew = wc.copy();
                                wcNew.amount = wcNew.amount * i;
                                wclNew.Add(wcNew);
                            }
                            answer.Add(wclNew);
                        }                                
                }
            }
            else {
                for(int i=_min;i<=_max;i++)
                {
                    List<WeaponChoice> l = new List<WeaponChoice>();
                    WeaponChoice wc = new WeaponChoice(i, _weapon);
                    l.Add(wc);
                    answer.Add(l);
                }
            }
            return answer;
        }
    }   


    public enum Operator { And,Or,Onbekend}
}
