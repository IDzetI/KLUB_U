using System;

namespace Симулятор_КЛУБ_У
{
    abstract class KLUB_U_Conroller
    {
        private KLUB_U Klub_u { get; set; }

        protected bool HasCassette { get; set; }
        protected bool IsAlarm { get; set; }
        protected byte Frequency { get; set; }
        protected byte PathNumber { get; set; }
        protected int Coordinate { get; set; }
        protected int ActualSpeed { get; set; }
        protected int AllowableSpeed { get; set; }
        protected float PressureTM { get; set; }
        protected float PressureUR { get; set; }
        protected float Acceleration { get; set; }
        protected float BrakingFactor { get; set; }
        protected String Info { get; set; }
        protected String NameNextStation { get; set; }

        // true = path is main; false = path is literal 
        protected bool Path { get; set; }

        // in binary representation
        protected byte TrafficLights { get; set; }

        // true if train dosn't move
        protected bool IsStop { get; set; }

        // distance to the target
        protected int Distance { get; set; }

        // 0 - Maneuring; 1 - Train mode; 2 - Double traction mode 
        protected byte MovingMode { get; set; }

        // true if the brake release is blocked
        protected bool BanBrakeRelease { get; set; }

        //TODO Time format
        //time of arrival at the next station
        protected int TimeToNextStation { get; set; }
        protected int ActualTime { get; set; }
        

        public KLUB_U_Conroller(KLUB_U klub_u) { Klub_u = klub_u; }

        abstract public void PressButton0();
        abstract public void PressButton1();
        abstract public void PressButton2();
        abstract public void PressButton3();
        abstract public void PressButton4();
        abstract public void PressButton5();
        abstract public void PressButton6();
        abstract public void PressButton7();
        abstract public void PressButton8();
        abstract public void PressButton9();

        abstract public void PressButtonPODTYAG();
        abstract public void PressButtonOTPR();
        abstract public void PressButtonOS();
        abstract public void PressButtonK20();

        abstract public void PressButtonPlus();
        abstract public void PressButtonMinus();
        abstract public void PressButtonOK();

        abstract public void PressButtonP();
        abstract public void PressButtonL();
        abstract public void PressButtonI();
        abstract public void PressButtonK();

        abstract public void PressButtonUP();
        abstract public void PressButtonDOWN();

        abstract public void PressButtonVK();
        abstract public void PressButtonRMP();
        abstract public void PressButtonF();

        abstract public void PressButtonRB();
        abstract public void PressButtonRBS();

        abstract public void HoldDownRB();
        abstract public void ReleaseRB();

        abstract public void HoldDownRBS();
        abstract public void ReleaseRBS();

        /*          admin control       */

        protected byte InputFrequency { get; set; }
        protected bool InputHasCassatte { get; set; }

        abstract public void SelectFrequency25();
        abstract public void SelectFrequency50();
        abstract public void SelectFrequency75();

        abstract public void InstallCassette();
        abstract public void UninstallCassette();
    }

}
