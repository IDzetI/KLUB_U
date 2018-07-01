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

        public override void HoldDownRB(){ RB = true; }
        public override void HoldDownRBS() { RBS = true; }

        public override void InstallCassette()
        {
            HasCassette = true;
            Klub_u.OnRegisterIndicatorIndicator();
        }

        public override void PressButton0()
        {
            if (inputInfoMode)
            {
                TrainParametrs[inputInfoParametr] = TrainParametrs[inputInfoParametr] * 10 + 0;
                Klub_u.SetInfo(InputInfoParametrs[inputInfoParametr] + " - " + TrainParametrs[inputInfoParametr].ToString() + " ");
            }
            else
                inputNumberTool.AddSimvol(0);
        }

        public override void PressButton1()
        {
            if (inputInfoMode)
            {
                TrainParametrs[inputInfoParametr] = TrainParametrs[inputInfoParametr] * 10 + 1;
                Klub_u.SetInfo(InputInfoParametrs[inputInfoParametr] + " - " + TrainParametrs[inputInfoParametr].ToString() + " ");
            }
            else
                inputNumberTool.AddSimvol(1);
        }

        public override void PressButton2()
        {
            if (inputInfoMode)
            {
                TrainParametrs[inputInfoParametr] = TrainParametrs[inputInfoParametr] * 10 + 2;
                Klub_u.SetInfo(InputInfoParametrs[inputInfoParametr] + " - " + TrainParametrs[inputInfoParametr].ToString() + " ");
            }
            else
                inputNumberTool.AddSimvol(2);
        }

        public override void PressButton3()
        {
            if (inputInfoMode)
            {
                TrainParametrs[inputInfoParametr] = TrainParametrs[inputInfoParametr] * 10 + 3;
                Klub_u.SetInfo(InputInfoParametrs[inputInfoParametr] + " - " + TrainParametrs[inputInfoParametr].ToString() + " ");
            }
            else
                inputNumberTool.AddSimvol(3);
        }

        public override void PressButton4()
        {
            if (inputInfoMode)
            {
                TrainParametrs[inputInfoParametr] = TrainParametrs[inputInfoParametr] * 10 + 4;
                Klub_u.SetInfo(InputInfoParametrs[inputInfoParametr] + " - " + TrainParametrs[inputInfoParametr].ToString() + " ");
            }
            else
                inputNumberTool.AddSimvol(4);
        }

        public override void PressButton5()
        {
            if (inputInfoMode)
            {
                TrainParametrs[inputInfoParametr] = TrainParametrs[inputInfoParametr] * 10 + 5;
                Klub_u.SetInfo(InputInfoParametrs[inputInfoParametr] + " - " + TrainParametrs[inputInfoParametr].ToString() + " ");
            }
            else
                inputNumberTool.AddSimvol(5);
        }

        public override void PressButton6()
        {
            if (inputInfoMode)
            {
                TrainParametrs[inputInfoParametr] = TrainParametrs[inputInfoParametr] * 10 + 6;
                Klub_u.SetInfo(InputInfoParametrs[inputInfoParametr] + " - " + TrainParametrs[inputInfoParametr].ToString() + " ");
            }
            else
                inputNumberTool.AddSimvol(6);
        }

        public override void PressButton7()
        {
            if (inputInfoMode)
            {
                TrainParametrs[inputInfoParametr] = TrainParametrs[inputInfoParametr] * 10 + 7;
                Klub_u.SetInfo(InputInfoParametrs[inputInfoParametr] + " - " + TrainParametrs[inputInfoParametr].ToString() + " ");
            }
            else
                inputNumberTool.AddSimvol(7);
        }

        public override void PressButton8()
        {
            if (inputInfoMode)
            {
                TrainParametrs[inputInfoParametr] = TrainParametrs[inputInfoParametr] * 10 + 8;
                Klub_u.SetInfo(InputInfoParametrs[inputInfoParametr] + " - " + TrainParametrs[inputInfoParametr].ToString() + " ");
            }
            else
                inputNumberTool.AddSimvol(8);
        }

        public override void PressButton9()
        {
            if (inputInfoMode)
            {
                TrainParametrs[inputInfoParametr] = TrainParametrs[inputInfoParametr] * 10 + 9;
                Klub_u.SetInfo(InputInfoParametrs[inputInfoParametr] + " - " + TrainParametrs[inputInfoParametr].ToString() + " ");
            }
            else
                inputNumberTool.AddSimvol(9);
        }

        public override void PressButtonDOWN()
        {
            illuminationStatus = !illuminationStatus;
            ShowIlluminationStatus();
        }

        private void ShowIlluminationStatus()
        {
            if (illuminationStatus)
                MessageBox.Show("Подсветка включена яркость = "+illumination.ToString());
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
            
        public override void PressButtonK()
        {
            inputInfoMode = false;
            inputPathMode = false;
            inputPathCorrectnessMode = false;
            Klub_u.SetInfo(Info);

            inputCommandMode = true;
            inputNumberTool.Reset();
        }

        private void ShowPlaceHolder() { MessageBox.Show("действуют в соответствии с алгоритмами работы системы САУТ-ЦМ/485"); }

        public override void PressButtonK20()
        {
            ShowPlaceHolder();
        }

        public override void PressButtonL()
        {
            inputCommandMode = false;
            inputPathMode = false;
            inputPathCorrectnessMode = false;

            if (inputInfoMode)
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
            else if (ActualSpeed == 0 && HasCassette)
            {
                inputInfoMode = true;
                inputInfoParametr = 0;
                Klub_u.SetInfo(InputInfoParametrs[inputInfoParametr]+ " - " + TrainParametrs[inputInfoParametr]+ " ");
            }
        }

        public override void PressButtonMinus()
        {
            PlusOrMinusParametr(-1);
        }

        private void PlusOrMinusParametr(int a)
        {
            if (inputInfoMode)
            {
                TrainParametrs[inputInfoParametr] += a;
                Klub_u.SetInfo(InputInfoParametrs[inputInfoParametr] + " - " + TrainParametrs[inputInfoParametr].ToString() + " ");
            }
            if (inputPathMode)
            {
                PathNumber += (byte)a;
                Klub_u.SetInfo("Номер пути = " + PathNumber.ToString() + " ");
            }
            if (inputPathCorrectnessMode)
            {
                CorrectPath = !CorrectPath;
                Klub_u.SetInfo("Признак правильности пути = " + (CorrectPath ? "1" : "0") + " ");
            }
        }

        public override void PressButtonOK()
        {
            if (inputInfoMode) TrainParametrs[inputInfoParametr] = 0;
            if (inputCommandMode) inputCommandMode = false;
        }

        public override void PressButtonOS()
        {
            ShowPlaceHolder();
        }

        public override void PressButtonOTPR()
        {
            ShowPlaceHolder();
        }

        public override void PressButtonP()
        {
            if (inputPathMode)
            {
                inputPathMode = false;
                inputPathCorrectnessMode = true;
                Klub_u.SetInfo("Признак правильности пути = " + (CorrectPath ? "1" : "0") + " ");
            }
            else
            {
                if (inputPathCorrectnessMode)
                {
                    inputPathCorrectnessMode = false;
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

        public override void PressButtonPlus()
        {
            PlusOrMinusParametr(+1);
        }

        public override void PressButtonPODTYAG()
        {
            ShowPlaceHolder();
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

        public override void OnManualCoordinateControlMode()
        {
            throw new NotImplementedException();
        }

        public override void OffManualCoordinateControlMode()
        {
            throw new NotImplementedException();
        }
    }
}
