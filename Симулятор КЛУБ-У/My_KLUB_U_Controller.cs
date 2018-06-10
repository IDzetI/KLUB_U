using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Симулятор_КЛУБ_У
{
    class My_KLUB_U_Controller : KLUB_U_Conroller
    {
        public My_KLUB_U_Controller(KLUB_U klub_u) : base(klub_u)
        {

        }

        public override void PressButton0()
        {
            Klub_u.OnAlarmIndicator();
        }
    }
}
