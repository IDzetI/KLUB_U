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

        public override void HoldDownRB(){ RB = true; }
        public override void HoldDownRBS() { RBS = true; }

        public override void InstallCassette()
        {
            HasCassette = true;
            Klub_u.OnRegisterIndicatorIndicator();
        }

        public override void PressButton0()
        {
            throw new NotImplementedException();
        }

        public override void PressButton1()
        {
            throw new NotImplementedException();
        }

        public override void PressButton2()
        {
            throw new NotImplementedException();
        }

        public override void PressButton3()
        {
            throw new NotImplementedException();
        }

        public override void PressButton4()
        {
            throw new NotImplementedException();
        }

        public override void PressButton5()
        {
            throw new NotImplementedException();
        }

        public override void PressButton6()
        {
            throw new NotImplementedException();
        }

        public override void PressButton7()
        {
            throw new NotImplementedException();
        }

        public override void PressButton8()
        {
            throw new NotImplementedException();
        }

        public override void PressButton9()
        {
            throw new NotImplementedException();
        }

        public override void PressButtonDOWN()
        {
            throw new NotImplementedException();
        }

        public override void PressButtonF()
        {
            throw new NotImplementedException();
        }

        public override void PressButtonI()
        {
            throw new NotImplementedException();
        }

        public override void PressButtonK()
        {
            throw new NotImplementedException();
        }

        public override void PressButtonK20()
        {
            throw new NotImplementedException();
        }

        public override void PressButtonL()
        {
            throw new NotImplementedException();
        }

        public override void PressButtonMinus()
        {
            throw new NotImplementedException();
        }

        public override void PressButtonOK()
        {
            throw new NotImplementedException();
        }

        public override void PressButtonOS()
        {
            throw new NotImplementedException();
        }

        public override void PressButtonOTPR()
        {
            throw new NotImplementedException();
        }

        public override void PressButtonP()
        {
            throw new NotImplementedException();
        }

        public override void PressButtonPlus()
        {
            throw new NotImplementedException();
        }

        public override void PressButtonPODTYAG()
        {
            throw new NotImplementedException();
        }

        public override void PressButtonRB()
        {
            throw new NotImplementedException();
        }

        public override void PressButtonRBS()
        {
            throw new NotImplementedException();
        }

        public override void PressButtonRMP()
        {
            throw new NotImplementedException();
        }

        public override void PressButtonUP()
        {
            throw new NotImplementedException();
        }

        public override void PressButtonVK()
        {
            throw new NotImplementedException();
        }

        public override void ReleaseRB()
        {
            throw new NotImplementedException();
        }

        public override void ReleaseRBS()
        {
            throw new NotImplementedException();
        }

        public override void SelectFrequency25()
        {
            throw new NotImplementedException();
        }

        public override void SelectFrequency50()
        {
            throw new NotImplementedException();
        }

        public override void SelectFrequency75()
        {
            throw new NotImplementedException();
        }

        public override void UninstallCassette()
        {
            throw new NotImplementedException();
        }
    }
}
