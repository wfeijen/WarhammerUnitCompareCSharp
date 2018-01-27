using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WarhammerUnitCompareCSharp
{
    public class UnitList : Dictionary<string, Unit>
    {
        public UnitList(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                string line = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    Unit unit = new Unit(line);
                    try
                    {
                        this.Add(unit._Unit, unit);
                    }
                    catch (System.ArgumentException e)
                    {
                        SimpleLogger sl = new SimpleLogger("WarhammerUnitCompareCSharp.log", true);
                        sl.Error("Wapen " + unit._Unit + " komt meerdere keren voor.");
                    }
                }
            }
        }

    }
}
