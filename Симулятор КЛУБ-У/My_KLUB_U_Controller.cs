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

        public override void PressButtonK()
        {
            inputInfoMode = false;
            inputPathMode = false;
            inputPathCorrectnessMode = false;
            Klub_u.SetInfo(Info);

            inputCommandMode = true;
            inputNumberTool.Reset();
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
                        Klub_u.OffDoubleTractionModeIndicator();
                        Klub_u.OnManeuringModeIndicator();
                        break;
                    case 1: //Train mode
                        Klub_u.OffManeuringModeIndicator();
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
                        Klub_u.OffManeuringModeIndicator();
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
                switch (inputNumberTool.GetNumber())
                {
                    case 1:
                        //TODO принудительный переход на следующий участок ЭК
                        break;
                    case 2:
                        //TODO изменение яркости свечения индикации блоков БИЛ и БИЛ-ПОМ
                        break;
                    case 3:
                        //TODO индикация в информационной строке БИЛ текущей даты, принятой от СНС
                        break;
                    case 5:
                        //TODO вход в меню ввода постоянных характеристик (доступны машинисту только для чтения)
                        break;
                    case 6:
                        //TODO ввод начальной координаты и характера её изменения (на участках не внесенных в ЭК, 
                        //при отсутствии приема информации со спутников или отсутствии ЭК на локомотиве)
                        break;
                    case 10:
                    case 522:
                        //TODO индикация номера электронной карты (на время 4 сек.)
                        break;
                    case 45:
                        //TODO индикация номера активной кабины
                        break;
                    case 46:
                        //TODO индикация номера активного комплекта КЛУБ-У
                        break;
                    case 47:
                        //TODO индикация номера активного ДПС
                        break;
                    case 70:
                        //TODO выключение индикации наличия исправных модулей (выключение диагностики)
                        break;
                    case 71:
                        //TODO включение индикация наличия исправных модулей (включение диагностики)
                        break;
                    case 80:
                        //TODO индикация давления в тормозной магистрали
                        break;
                    case 81:
                        //TODO индикация давления в тормозных цилиндрах
                        break;
                    case 82:
                        //TODO индикация давления в УР 2 кабины
                        break;
                    case 83:
                        //TODO индикация давления в УР 1 кабины
                        break;
                    case 91:
                        //TODO перезапуск 1-го комплекта МЦО и переход на 2-й комплект при его исправности
                        break;
                    case 92:
                        //TODO перезапуск 2-го комплекта МЦО и переход на 1-й комплект при его исправности
                        break;
                    case 122:
                        //TODO индикация на блоке БИЛ давления (ТМ и УР) в МПа
                        break;
                    case 123:
                        //TODO индикация на блоке БИЛ давления (ТМ и УР) в кгс/см2
                        break;
                    case 259:
                        //TODO включение режима диагностики САУТ
                        break;
                    case 260:
                        //TODO выключение режима диагностики САУТ
                        break;
                    case 262:
                        //TODO движение по системе многих единиц при работе в режиме «Двойная тяга» 
                        //(вводится на втором локомотиве из режима «Двойная тяга» и отменяет 
                        //все проверки бдительности)
                        break;
                    case 263:
                        //TODO для грузовой (6) и маневровой (7) категории поезда. Устанавливает 
                        //время 120 сек (вместо 74 сек) с момента включения тяги (вывода контроллера 
                        //из нулевого положения) до достижения скорости 2 км/ч
                        break;
                    case 799:
                        //TODO движение по некодированному участку или при закрытой АБ, а так же на 
                        //втором локомотиве при работе двойной тягой. Блокирует прием кодов из 
                        //рельсовой цепи и позволяет установить требуемую допускаемую скорость при 
                        //движении с белым огнем на блоке индикации
                        break;
                    case 800:
                        //TODO отмена движения при закрытой автоблокировке и по полуавтоблокировке
                        break;
                    case 809:
                        //TODO движение по полуавтоблокировке (прием кодов не блокируется). 
                        //Позволяет установить требуемую допустимую скорость при движении по ПАБ 
                        //по белому огню на БИЛ
                        break;
                    case 1036:
                        //TODO переход на работу с другим ДПС
                        break;
                    case 1045:
                        //TODO проверка действия блока КОН. При заряженных УР, ТМ, ПМ установить 
                        //ручки КМ395 и КВТ254 (215) во 2-е положение и ввести команду. На блоке 
                        //индикации установиться значение фактической скорости 20 км/ч, через 10-14 
                        //сек появится индикация «Срыв от КОН» и произойдет срабатывание ЭПК 
                        //(при затормаживании КВТ254 (215) с давлением в ТЦ более 1,0-1,5 кгс/см2 
                        //срабатывание ЭПК после набора команды не произойдет)
                        break;
                    default: MessageBox.Show("Команда номер " + inputNumberTool.GetNumber() + " не опреедлена."); break;
                }
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

        public override void HoldDownRB() { RB = true; }
        public override void ReleaseRB() { RB = false; }
        public override void HoldDownRBS() { RBS = true; }
        public override void ReleaseRBS() { RBS = false; }

        private void ShowPlaceHolder() { MessageBox.Show("действуют в соответствии с алгоритмами работы системы САУТ-ЦМ/485"); }

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

        private void ShowIlluminationStatus()
        {
            if (illuminationStatus)
                MessageBox.Show("Подсветка включена яркость = " + illumination.ToString());
            else
                MessageBox.Show("Подсветка выключена");
        }

        private void UpdateTrafficlights()
        {
            for (int i = Trafficlights.Length - 1; i >= 0; i--)
            {
                if (i > 7 && Trafficlights[i]) Trafficlights[i - 8] = false;
                OnOrOffTrafficLight(i, Trafficlights[i]);
            }
        }

        private void OnOrOffTrafficLight(int number, bool status)
        {
            if (status)
                switch (number)
                {
                    case 0: Klub_u.OnTrafficLight0Indicator(); break;
                    case 1: Klub_u.OnTrafficLight1Indicator(); break;
                    case 2: Klub_u.OnTrafficLight2Indicator(); break;
                    case 3: Klub_u.OnTrafficLight3Indicator(); break;
                    case 4: Klub_u.OnTrafficLight4Indicator(); break;
                    case 5: Klub_u.OnTrafficLight5Indicator(); break;
                    case 6: Klub_u.OnTrafficLight6Indicator(); break;
                    case 7: Klub_u.OnTrafficLight7Indicator(); break;
                    case 8: Klub_u.OnTrafficLight0BlinkIndicator(); break;
                    default: MessageBox.Show("ERROR: On TrafficLight Indicator " + number.ToString()); break;
                }
            else
                switch (number)
                {
                    case 0: Klub_u.OffTrafficLight0Indicator(); break;
                    case 1: Klub_u.OffTrafficLight1Indicator(); break;
                    case 2: Klub_u.OffTrafficLight2Indicator(); break;
                    case 3: Klub_u.OffTrafficLight3Indicator(); break;
                    case 4: Klub_u.OffTrafficLight4Indicator(); break;
                    case 5: Klub_u.OffTrafficLight5Indicator(); break;
                    case 6: Klub_u.OffTrafficLight6Indicator(); break;
                    case 7: Klub_u.OffTrafficLight7Indicator(); break;
                    case 8: Klub_u.OffTrafficLight0BlinkIndicator(); break;
                    default: MessageBox.Show("ERROR: Off TrafficLight Indicator " + number.ToString()); break;
                }
        }
        
        private void NextInputPath()
        {
            inputPathMode = false;
            inputPathCorrectnessMode = true;
            Klub_u.SetInfo("Признак правильности пути = " + (CorrectPath ? "1" : "0") + " ");
            Klub_u.SetPathNumber(PathNumber, CorrectPath);
        }

        private void NextInputPathCorrectness()
        {
            inputPathCorrectnessMode = false;
            Klub_u.SetInfo(Info);
            Klub_u.SetPathNumber(PathNumber, CorrectPath);
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



        //Controls panel
        public override void HoldDownRBP() { RBP = true; }
        public override void ReleaseRBP() { RBP = false; }
        public override void OnAloneMode() { AloneMode = true; }
        public override void OffAloneMode() { AloneMode = false; }
        public override void OnManualCoordinateControlMode() { ManualCoordinateControl = true; }
        public override void OffManualCoordinateControlMode() { ManualCoordinateControl = false; }

        public override void SelectFrequency25() { InputFrequency = 25; }
        public override void SelectFrequency50() { InputFrequency = 50; }
        public override void SelectFrequency75() { InputFrequency = 75; }

        public override void OnManualTrafficlightsControlMode() { ManualCoordinateControl = true; Klub_u.SetManualTrafficLightsControl(Trafficlights); }
        public override void OffManualTrafficlightsControlMode() { ManualCoordinateControl = false; }

        public override void ManualChangeTrafficlight0Blink(bool state) { ManualControlTrafficlight(8, state); }
        public override void ManualChangeTrafficlight0(bool state) { ManualControlTrafficlight(0, state); }
        public override void ManualChangeTrafficlight1(bool state) { ManualControlTrafficlight(1, state); }
        public override void ManualChangeTrafficlight2(bool state) { ManualControlTrafficlight(2, state); }
        public override void ManualChangeTrafficlight3(bool state) { ManualControlTrafficlight(3, state); }
        public override void ManualChangeTrafficlight4(bool state) { ManualControlTrafficlight(4, state); }
        public override void ManualChangeTrafficlight5(bool state) { ManualControlTrafficlight(5, state); }
        public override void ManualChangeTrafficlight6(bool state) { ManualControlTrafficlight(6, state); }
        public override void ManualChangeTrafficlight7(bool state) { ManualControlTrafficlight(7, state); }

        public override void ManualChangeCoordinate(int coordinzte)
        {
            if (ManualCoordinateControl) Coordinate = coordinzte;
            Klub_u.SetCoordinate(Coordinate);
        }
        
        private void ManualControlTrafficlight(int number, bool state)
        {
            Trafficlights[number] = state;
            UpdateTrafficlights();
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
    }
}
