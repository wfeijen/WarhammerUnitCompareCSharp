using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WfeijenWH;

namespace WarhammerUnitCompareCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WeaponList weaponList=new WeaponList("");
        }
    }
}
