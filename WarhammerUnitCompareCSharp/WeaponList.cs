using System;
using System.Collections.Generic;
using System.IO;



public class WeaponList : Dictionary<string, Weapon>
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
                try
                {
                    this.Add(weapon._name, weapon);
                }
                catch (System.ArgumentException e){
                    System.Windows.Forms.MessageBox.Show("Wapen " + weapon._name + " komt meerdere keren voor.","Warning");
                }
            }
        }
    }
}
