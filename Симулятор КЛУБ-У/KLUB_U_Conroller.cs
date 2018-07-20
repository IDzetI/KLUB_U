using System;

namespace Симулятор_КЛУБ_У
{
    abstract class KLUB_U_Conroller
    {
        /*          Variables       */

        protected KLUB_U Klub_u { get; set; }

        protected bool HasCassette { get; set; }
        protected bool IsAlarm { get; set; }
        protected bool RB { get; set; }
        protected bool RBS { get; set; }
        protected bool CorrectPath { get; set; }
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
        protected int[] TrainParametrs { get; set; }
        protected bool[] Trafficlights { get; set; }

        // true = path is main; false = path is literal 
        protected bool Path { get; set; }
        
        // true if train dosn't move
        protected bool IsStop { get; set; }

        // distance to the target
        protected int Distance { get; set; }

        //  0 - Maneuring; 
        //  1 - Train mode; 
        //  2 - Double traction mode 
        protected byte MovingMode { get; set; }

        // true if the brake release is blocked
        protected bool BanBrakeRelease { get; set; }

        //TODO Time format
        //time of arrival at the next station
        protected int TimeToNextStation { get; set; }
        protected int ActualTime { get; set; }


        
        
        
        /*          Constants           */

        protected readonly String[] InputInfoParametrs =
            {
                "Табельный номер машиниста", "Номер поезда",
                "Длина поезда в осях","Длина поезда в вагонах",
                "Масса поезда, т"
            };


        
        
        /*          Constructor         */

        public KLUB_U_Conroller(KLUB_U klub_u)
        {
            Klub_u = klub_u;
            ActualSpeed = 0;
            AllowableSpeed = 100;
            Acceleration = 0;
            MovingMode = 1;
            Frequency = 50;
            Info = "";
            Coordinate = 0;
            TrainParametrs = new Int32[]{ 0, 0, 0, 0, 0};
            
            // 8 - white blink
            // 7 - green4
            // 6 - green3
            // 5 - green2
            // 4 - green1
            // 3 - yellow
            // 2 - yellow red
            // 1 - red
            // 0 - white     
            Trafficlights = new bool[] {    false, false, false, false, false, false, false, false,
                                            false };
            ManualTrafficlightControl = false;
            ManualCoordinateControl = false;

            PathNumber = 1;
            CorrectPath = true;
            
            klub_u.SetActualSpeed(ActualSpeed);
            klub_u.SetAllowableSpeed(AllowableSpeed);
            klub_u.SetCoordinate(Coordinate);
            klub_u.SetStarion("");
            klub_u.SetTime("12.34.51");
            klub_u.SetTimeOnSchedule("13.00.00");
            Klub_u.SetPressureTM((float)0.01);
            Klub_u.SetPressureUR((float)0.23);
            klub_u.SetFrequency(Frequency);
            Klub_u.SetPathNumber(PathNumber, CorrectPath);
            Klub_u.SetAcceleration(Acceleration);
            Klub_u.OnMainPathIndicator();
        }




        /*          Abstract functions  */

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

        //variables            
        protected byte InputFrequency { get; set; }
        protected bool InputHasCassatte { get; set; }
        protected bool ManualCoordinateControl { get; set; }
        protected bool ManualTrafficlightControl { get; set; }
        protected bool AloneMode { get; set; }
        protected bool RBP { get; set; }

        //functions
        abstract public void SelectFrequency25();
        abstract public void SelectFrequency50();
        abstract public void SelectFrequency75();

        abstract public void InstallCassette();
        abstract public void UninstallCassette();

        abstract public void OnManualCoordinateControlMode();
        abstract public void OffManualCoordinateControlMode();
        abstract public void ManualChangeCoordinate(int coordinate);

        abstract public void OnManualTrafficlightsControlMode();
        abstract public void OffManualTrafficlightsControlMode();
        abstract public void ManualChangeTrafficlight0Blink(bool state);
        abstract public void ManualChangeTrafficlight0(bool state);
        abstract public void ManualChangeTrafficlight1(bool state);
        abstract public void ManualChangeTrafficlight2(bool state);
        abstract public void ManualChangeTrafficlight3(bool state);
        abstract public void ManualChangeTrafficlight4(bool state);
        abstract public void ManualChangeTrafficlight5(bool state);
        abstract public void ManualChangeTrafficlight6(bool state);
        abstract public void ManualChangeTrafficlight7(bool state);
        
        abstract public void OnAloneMode();
        abstract public void OffAloneMode();

        abstract public void PressButtonRBP();
        abstract public void HoldDownRBP();
        abstract public void ReleaseRBP();
    }

}
