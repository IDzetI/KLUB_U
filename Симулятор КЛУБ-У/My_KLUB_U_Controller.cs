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
        private InputNumderTool inputNumberTool;
        private bool inputCommandMode;
        private bool inputPathMode;
        private bool inputPathCorrectnessMode;

        private byte inputInfoParametr;
        private bool inputInfoMode;

        private byte illumination;
        private bool illuminationStatus;

        public My_KLUB_U_Controller(KLUB_U klub_u) : base(klub_u)
        {
            klub_u.OnTrainModeIndicator();

            inputNumberTool = new InputNumderTool();
            inputInfoMode = false;
            inputInfoParametr = 0;
            inputCommandMode = false;
        }

        private void UpdateTrafficlights()
        {
            // 8 - white blink
            // 7 - green4
            // 6 - green3
            // 5 - green2
            // 4 - green1
            // 3 - yellow
            // 2 - yellow red
            // 1 - red
            // 0 - white     

            if (Trafficlights[8])
            {
                Trafficlights[0] = false;
                Klub_u.OffTrafficLight1BlinkIndicator();
            }
            //TODO 
            if(Trafficlights[7])
        }

        private void PressNumberButtonN(byte n)
        {
            if (inputInfoMode)
            {
                TrainParametrs[inputInfoParametr] = TrainParametrs[inputInfoParametr] * 10 + n;
                Klub_u.SetInfo(InputInfoParametrs[inputInfoParametr] + " - " + TrainParametrs[inputInfoParametr].ToString() + " ");
            }
            else if (inputPathMode)
            {
                PathNumber = (byte)(PathNumber * 10 + n);
                Klub_u.SetInfo("Номер пути = " + PathNumber.ToString() + " ");
            }
            else if (inputPathCorrectnessMode)
            {
                CorrectPath = n == 1;
                Klub_u.SetInfo("Признак правильности пути = " + (CorrectPath ? "1" : "0") + " ");
            }
            else
                inputNumberTool.AddSimvol(n);
        }

        // a = +1 if press button plus and a = -1 if press minus
        private void PlusOrMinusParametr(int a)
        {
            if (inputInfoMode)
            {
                TrainParametrs[inputInfoParametr] += a;
                Klub_u.SetInfo(InputInfoParametrs[inputInfoParametr] + " - " + TrainParametrs[inputInfoParametr].ToString() + " ");
            }
            else if (inputPathMode)
            {
                PathNumber += (byte)a;
                Klub_u.SetInfo("Номер пути = " + PathNumber.ToString() + " ");
            }
            else if (inputPathCorrectnessMode)
            {
                CorrectPath = !CorrectPath;
                Klub_u.SetInfo("Признак правильности пути = " + (CorrectPath ? "1" : "0") + " ");
            }
        }

        public override void PressButtonK()
        {
            inputInfoMode = false;
            inputPathMode = false;
            inputPathCorrectnessMode = false;
            Klub_u.SetInfo(Info);

            inputCommandMode = true;
            inputNumberTool.Reset();
        }

        private void NextInputInfo()
        {
            inputInfoParametr++;
            if (inputInfoParametr >= 5)
            {
                inputInfoMode = false;
                Klub_u.SetInfo(Info);
                return;
            }
            else
                Klub_u.SetInfo(InputInfoParametrs[inputInfoParametr] + " - " + TrainParametrs[inputInfoParametr] + " ");
        }

        public override void PressButtonL()
        {
            inputCommandMode = false;
            inputPathMode = false;
            inputPathCorrectnessMode = false;

            if (inputInfoMode)
            {
                NextInputInfo();
            }
            else if (ActualSpeed == 0 && HasCassette)
            {
                inputInfoMode = true;
                inputInfoParametr = 0;
                Klub_u.SetInfo(InputInfoParametrs[inputInfoParametr] + " - " + TrainParametrs[inputInfoParametr] + " ");
            }
        }
        
        public override void PressButtonOK()
        {
            if (inputInfoMode) TrainParametrs[inputInfoParametr] = 0;
            else if (inputCommandMode) inputCommandMode = false;
            else if (inputPathMode) PathNumber = 0;
            else if (inputPathCorrectnessMode) inputPathCorrectnessMode = false;
        }

        private void NextInputPath()
        {
            inputPathMode = false;
            inputPathCorrectnessMode = true;
            Klub_u.SetInfo("Признак правильности пути = " + (CorrectPath ? "1" : "0") + " ");
        }

        private void NextInputPathCorrectness()
        {
            inputPathCorrectnessMode = false;
            Klub_u.SetInfo(Info);
        }
        
        public override void PressButtonP()
        {
            if (inputPathMode)
            {
                NextInputPath();
            }
            else
            {
                if (inputPathCorrectnessMode)
                {
                    NextInputPathCorrectness();
                }
                else
                {
                    inputCommandMode = false;
                    inputInfoMode = false;
                    inputPathMode = true;
                    Klub_u.SetInfo("Номер пути = " + PathNumber.ToString() + " ");
                }
            }

        }

        public override void PressButtonRB()
        {
            //TODO RB
            throw new NotImplementedException();
        }

        public override void PressButtonRBS()
        {
            //TODO RBS
            throw new NotImplementedException();
        }

        public override void PressButtonRBP()
        {
            //TODO RBP
            throw new NotImplementedException();
        }

        public override void PressButtonRMP()
        {
            if (ActualSpeed == 0 && HasCassette)
            {
                MovingMode++;
                MovingMode %= 3;
                if (MovingMode == 0 && Trafficlights[2] || Trafficlights[3] || (Trafficlights[0] && Trafficlights[8]))
                    MovingMode++;

                // TODO в течение 30 с после одновременного нажатия РБ и РБП
                if (MovingMode == 2 && Trafficlights[2] || Trafficlights[3] || (Trafficlights[0] && Trafficlights[8]))
                    MovingMode = 0;

                switch (MovingMode)
                {
                    case 0: // Maneurng mode
                        //TODO Прием сигналов АЛСН не производится
                        //TODO На блоке индикации горит белый огонь
                        AllowableSpeed = 60;
                        //TODO Проверка бдительности в начале движения не производится
                        Klub_u.OffTrainModeIndicator();
                        Klub_u.OnMainPathIndicator();
                        break;
                    case 1: //Train mode
                        Klub_u.OffMainPathIndicator();
                        Klub_u.OffDoubleTractionModeIndicator();
                        Klub_u.OnTrainModeIndicator();
                        break;
                    case 2: //Double traction mode 
                        //TODO не осуществляет прием кодов АЛСН, 
                        //TODO не осуществляет прием кодов светофоров от цифрового радиоканала 
                        //     (на БИЛ и БИЛ-ПОМ индицируется сигнал «Б»);
                        //TODO обеспечивает изменение скорости движения по сигналу «Б» после ввода команды «К799»
                        //TODO не производит экстренное торможение посредством блока КОН;
                        //TODO не осуществляет однократную проверку бдительности при трогании, 
                        //     контроль скатывания и контроль исправности ДПС;
                        //TODO формирует на БИЛ информацию о впередилежащих местах ограничения скорости, 
                        //     не производя при этом фактической отработки Vцел и Vдоп по данным ограничениям.
                        Klub_u.OffMainPathIndicator();
                        Klub_u.OffTrainModeIndicator();
                        Klub_u.OnDoubleTractionModeIndicator();
                        break;
                    default: MessageBox.Show("Error when switching the travel mode"); break;
                }
            }
        }

        public override void PressButtonUP()
        {
            if (inputCommandMode)
            {
                //TODO execution command
            }
            else if (inputInfoMode) NextInputInfo();
            else if (inputPathMode) NextInputPath();
            else if (inputPathCorrectnessMode) NextInputPathCorrectness();
        }

        public override void PressButtonVK()
        {
            if((!AloneMode && RB && RBP) || (AloneMode && RB))
            {
                Trafficlights[1] = false;
                Trafficlights[0] = true;
                AllowableSpeed = 20;
            }
        }
        
        public override void PressButtonDOWN()
        {
            illuminationStatus = !illuminationStatus;
            ShowIlluminationStatus();
        }

        private void ShowIlluminationStatus()
        {
            if (illuminationStatus)
                MessageBox.Show("Подсветка включена яркость = " + illumination.ToString());
            else
                MessageBox.Show("Подсветка выключена");
        }

        public override void PressButtonF()
        {
            Frequency %= 75;
            Frequency += 25;
            Klub_u.SetFrequency(Frequency);
        }

        public override void PressButtonI()
        {
            illumination %= 7;
            illumination++;
            ShowIlluminationStatus();
        }
        
        public override void InstallCassette()
        {
            HasCassette = true;
            Klub_u.OnRegisterIndicatorIndicator();
        }

        public override void UninstallCassette()
        {
            HasCassette = false;
            Klub_u.OffRegisterIndicatorIndicator();
        }

        public override void HoldDownRB() { RB = true; }
        public override void ReleaseRB() { RB = false; }
        public override void HoldDownRBS() { RBS = true; }
        public override void ReleaseRBS() { RBS = false; }
        public override void HoldDownRBP() { RBP = true; }
        public override void ReleaseRBP() { RBP = false; }
        public override void OnAloneMode() { AloneMode = true; }
        public override void OffAloneMode() { AloneMode = false; }
        public override void OnManualCoordinateControlMode() { ManualCoordinateControl = true; }
        public override void OffManualCoordinateControlMode() { ManualCoordinateControl = false; }


        private void ShowPlaceHolder() { MessageBox.Show("действуют в соответствии с алгоритмами работы системы САУТ-ЦМ/485"); }
        public override void PressButtonK20() { ShowPlaceHolder(); }
        public override void PressButtonPODTYAG() { ShowPlaceHolder(); }
        public override void PressButtonOS() { ShowPlaceHolder(); }
        public override void PressButtonOTPR() { ShowPlaceHolder(); }
        
        public override void PressButtonPlus() { PlusOrMinusParametr(+1); }
        public override void PressButtonMinus() { PlusOrMinusParametr(-1); }

        public override void PressButton0() { PressNumberButtonN(0); }
        public override void PressButton1() { PressNumberButtonN(1); }
        public override void PressButton2() { PressNumberButtonN(2); }
        public override void PressButton3() { PressNumberButtonN(3); }
        public override void PressButton4() { PressNumberButtonN(4); }
        public override void PressButton5() { PressNumberButtonN(5); }
        public override void PressButton6() { PressNumberButtonN(6); }
        public override void PressButton7() { PressNumberButtonN(7); }
        public override void PressButton8() { PressNumberButtonN(8); }
        public override void PressButton9() { PressNumberButtonN(9); }
        
        public override void SelectFrequency25() { InputFrequency = 25; }
        public override void SelectFrequency50() { InputFrequency = 50; }
        public override void SelectFrequency75() { InputFrequency = 75; }
    }
}
