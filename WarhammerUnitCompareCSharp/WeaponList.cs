using System;
using System.Collections.Generic;
using System.IO;
using Weapon;


    public class WeaponList : dictionary<string, Weapon>
    {
        public WeaponList(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                string line = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    Weapon weapon = new Weapon(line);
                    this.add(weapon);
                }
            }
        }
    }
