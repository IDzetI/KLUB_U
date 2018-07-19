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
    public partial class KLUB_U : Form
    {
        KLUB_U_Conroller Controller;


        public KLUB_U()
        {
            InitializeComponent();
            Controller = new My_KLUB_U_Controller(this);
        }

        
        /*        Управление индикаторами         */
        
        //управление индикатором главного пути
        public void OnMainPathIndicator() { mainPathIndicator.Image = Properties.Resources.mainPathGreen; }
        public void OffMainPathIndicator() { mainPathIndicator.Image = Properties.Resources.mainPathGray; }

        //управление индикатором бокового пути
        public void OnLiteralPathIndicator() { literalPathIndicalor.Image = Properties.Resources.literalPathGreen; }
        public void OffLiteralPathIndicator() { literalPathIndicalor.Image = Properties.Resources.literalPathGray; }

        //управление индикатором манёвренного режима работы локомотива
        public void OnManeuringModeIndicator() { maneuveringModeIndicator.ForeColor = Color.GreenYellow; }
        public void OffManeuringModeIndicator() { maneuveringModeIndicator.ForeColor = Color.Gray; }

        //управление индикатором поездного режима работы локоматива
        public void OnTrainModeIndicator() { trainModeIndocator.ForeColor = Color.GreenYellow; }
        public void OffTrainModeIndicator() { trainModeIndocator.ForeColor = Color.Gray; }

        //управление индикатором режима двойной тяги
        public void OnDoubleTractionModeIndicator() { blinkTrainModeTimer.Start(); }
        public void OffDoubleTractionModeIndicator() { blinkTrainModeTimer.Stop(); trainModeIndocator.ForeColor = Color.Gray; }
        private void blinkTrainModeTimer_Tick(object sender, EventArgs e)
        {
            if (trainModeIndocator.ForeColor == Color.Gray)
                trainModeIndocator.ForeColor = Color.GreenYellow;
            else
                trainModeIndocator.ForeColor = Color.Gray;
        }

        //управление индикатором исправности канала регистрации и наличия кассеты регистрации в кассетоприемнике
        public void OnRegisterIndicatorIndicator() { registerIndicator.ForeColor = Color.GreenYellow; }
        public void OffRegisterIndicatorIndicator() { registerIndicator.ForeColor = Color.Gray; }

        //управление индикатором сигнала "Внимание!"
        public void OnAlarmIndicator() { alarmIndicator.Image = Properties.Resources.alarmRed; }
        public void OffAlarmIndicator() { alarmIndicator.Image = Properties.Resources.alarmGray; }

        //управление индикаторами светофора
        // 0
        public void OnTrafficLight0Indicator() { trafficLight1Indicator.BackColor = Color.White; }
        public void OffTrafficLight0Indicator() { trafficLight1Indicator.BackColor = Color.Black; }
        //TODO
        public void OnTrafficLight0BlinkIndicator() { }
        public void OffTrafficLight0BlinkIndicator() {  }
        // 1
        public void OnTrafficLight1Indicator() { trafficLight2Indicator.BackColor = Color.Red; }
        public void OffTrafficLight1Indicator() { trafficLight2Indicator.BackColor = Color.FromArgb(255, 64, 0, 0); }
        // 2
        public void OnTrafficLight2Indicator() { trafficLight3Indicator.Image = Properties.Resources.yellowRedIndicatorON; }
        public void OffTrafficLight2Indicator() { trafficLight3Indicator.Image = Properties.Resources.yellowRedIndicatorOFF; }
        // 3
        public void OnTrafficLight3Indicator() { trafficLight4Indicator.BackColor = Color.Yellow; }
        public void OffTrafficLight3Indicator() { trafficLight4Indicator.BackColor = Color.FromArgb(255, 64, 64, 0); }
        // 4
        public void OnTrafficLight4Indicator() { trafficLight5Indicator.BackColor = Color.Green; }
        public void OffTrafficLight4Indicator() { trafficLight5Indicator.BackColor = Color.FromArgb(255, 0, 64, 0); }
        // 5
        public void OnTrafficLight5Indicator() { trafficLight6Indicator.BackColor = Color.Green; }
        public void OffTrafficLight5Indicator() { trafficLight6Indicator.BackColor = Color.FromArgb(255, 0, 64, 0); }
        // 6
        public void OnTrafficLight6Indicator() { trafficLight7Indicator.BackColor = Color.Green; }
        public void OffTrafficLight6Indicator() { trafficLight7Indicator.BackColor = Color.FromArgb(255, 0, 64, 0); }
        // 7
        public void OnTrafficLight7Indicator() { trafficLight8Indicator.BackColor = Color.Green; }
        public void OffTrafficLight7Indicator() { trafficLight8Indicator.BackColor = Color.FromArgb(255, 0, 64, 0); }

        //управлением индикатором запрета отпуска тормозов (при работе с системой САУТ)
        public void OnBanBrakeReleaseIndicator() { banBrakeReleaseIndicator.BackColor = Color.Red; }
        public void OffBanBrakeReleaseIndicator() { banBrakeReleaseIndicator.BackColor = Color.FromArgb(255, 64, 0, 0); }

        //управление индикатором направления поезда
        public void SetForwardDirection() { directionIndicator.Image = Properties.Resources.directionForward;}
        public void SetBacwardDirection() { directionIndicator.Image = Properties.Resources.directionBackward; }
        public void SetNonDirection() { directionIndicator.Image = Properties.Resources.direction0; }
        


        /*        Вывод данных на приборную панель         */

        //вывод координат поезда в м на приборную панель
        public void SetCoordinate(float coordinate) { coordinateTextBox.Text = coordinate.ToString(); }

        //вывод название следующей станции на приборную панель
        public void SetStarion(String station) { starionTexBox.Text = station; }

        //вывод времени по графику на приборную панель
        public void SetTimeOnSchedule(String time) { timeOnScheduleTextBox.Text = time; }
        
        //вывод актуального вренени на приборную панель
        public void SetTime(String time) { timeTextBox.Text = time; }

        //вывод актуальной скорости на приборную панель
        public void SetActualSpeed(byte speed) { actualSpeedTextBox.Text = speed.ToString(); }
        
        //вывод максимальной скорости на приборную панель
        public void SetAllowableSpeed(byte speed) { allowableSpeedTextBox.Text = speed.ToString(); }

        //вывод давления ТМ на приборную панель
        public void SetPressureTM(float pressure) { pressureTMTextBox.Text = pressure.ToString(); }

        //вывод давления УР на приборную панель
        public void SetPressureUR(float pressure) { PressureURTexBox.Text = pressure.ToString(); }

        //вывод частоты АЛСН на приборную панель
        public void SetFrequency(byte frequency) { frequencyTextBox.Text = frequency.ToString(); }

        //вывод номера пути и признака его правильности на приборную панель
        public void SetPathNumber(byte pathNumber, bool correctness) { nPathTextBox.Text = pathNumber.ToString() + " " + (correctness ? "ПР" : "НП"); }

        //вывод усккорения на приборную панель
        public void SetAcceleration(float acceleration) { accelerationTexBox.Text = acceleration.ToString(); }

        //вывод коэффициента торможения на приборную панель
        public void SetBrakingFactor(float brakingFactor) { brakingFactorTextBox.Text = brakingFactor.ToString(); }

        //вывод растояния до цели на приборную панель
        public void SetDistance(int distance) { distanceTexBox.Text = distance.ToString(); }

        //вывод информации в информационную строку на приборной панели
        public void SetInfo(String info) { infoTexBox.Text = info; }



        /*          Обрабатывание нажатий на кнопки         */

        private void buttonPlus_Click(object sender, EventArgs e) { Controller.PressButtonPlus(); }
        private void buttonMinus_Click(object sender, EventArgs e) { Controller.PressButtonMinus(); }
        private void buttonOK_Click(object sender, EventArgs e) { Controller.PressButtonOK(); }

        private void buttonP_Click(object sender, EventArgs e) { Controller.PressButtonP(); }
        private void buttonL_Click(object sender, EventArgs e) { Controller.PressButtonL(); }
        private void buttonI_Click(object sender, EventArgs e) { Controller.PressButtonI(); }
        private void buttonK_Click(object sender, EventArgs e) { Controller.PressButtonK(); }

        private void button0_Click(object sender, EventArgs e) { Controller.PressButton0(); }
        private void button1_Click(object sender, EventArgs e) { Controller.PressButton1(); }
        private void button2_Click(object sender, EventArgs e) { Controller.PressButton2(); }
        private void button3_Click(object sender, EventArgs e) { Controller.PressButton3(); }
        private void button4_Click(object sender, EventArgs e) { Controller.PressButton4(); }
        private void button5_Click(object sender, EventArgs e) { Controller.PressButton5(); }
        private void button6_Click(object sender, EventArgs e) { Controller.PressButton6(); }
        private void button7_Click(object sender, EventArgs e) { Controller.PressButton7(); }
        private void button8_Click(object sender, EventArgs e) { Controller.PressButton8(); }
        private void button9_Click(object sender, EventArgs e) { Controller.PressButton9(); }

        private void buttonVK_Click(object sender, EventArgs e) { Controller.PressButtonVK(); }
        private void buttonRMP_Click(object sender, EventArgs e) { Controller.PressButtonRMP(); }
        private void buttonF_Click(object sender, EventArgs e) { Controller.PressButtonF(); }

        private void buttonUp_Click(object sender, EventArgs e) { Controller.PressButtonUP(); }
        private void buttonDown_Click(object sender, EventArgs e) { Controller.PressButtonDOWN(); }

        private void buttonPODTYAG_Click(object sender, EventArgs e) { Controller.PressButtonPODTYAG(); }
        private void buttonOTPR_Click(object sender, EventArgs e) { Controller.PressButtonOTPR(); }
        private void buttonOS_Click(object sender, EventArgs e) { Controller.PressButtonOS(); }
        private void buttonK20_Click(object sender, EventArgs e) { Controller.PressButtonK20(); }

        private void buttonRB_Click(object sender, EventArgs e) { Controller.PressButtonRB(); }
        private void RBcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RBcheckBox.Checked)
                Controller.HoldDownRB();
            else
                Controller.ReleaseRB();
        }

        private void buttonRBS_Click(object sender, EventArgs e) { Controller.ReleaseRBS(); }
        private void RBScheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RBScheckBox.Checked)
                Controller.HoldDownRBS();
            else
                Controller.ReleaseRBS();
        }



        /*          input panel         */

        private void cassetteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cassetteCheckBox.Checked)
                Controller.InstallCassette();
            else
                Controller.InstallCassette();
        }

        private void frequencyRadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (frequency25RadioButton.Checked) Controller.SelectFrequency25();
            else if (frequency50RadioButton.Checked) Controller.SelectFrequency50();
            else if (frequency75RadioButton.Checked) Controller.SelectFrequency75();
        }

        private void aloneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            buttonRBP.Enabled = !aloneCheckBox.Checked;
            RBPcheckBox.Enabled = !aloneCheckBox.Checked;

            if (aloneCheckBox.Checked)
                Controller.OnAloneMode();
            else
                Controller.OffAloneMode();
        }

        private void buttonRBP_Click(object sender, EventArgs e) { Controller.PressButtonRBP(); }

        private void RBPcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RBPcheckBox.Checked)
                Controller.HoldDownRBP();
            else
                Controller.ReleaseRBP();
        }
        
        private void manualCoordinateControlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            panelControlCoordinate.Enabled = manualCoordinateControlCheckBox.Checked;

            if (manualCoordinateControlCheckBox.Checked)
                Controller.OnManualCoordinateControlMode();
            else
                Controller.OffManualCoordinateControlMode();
        }

        private void buttonManualControlCoordinate_Click(object sender, EventArgs e) { Controller.ManualChangeCoordinate(Convert.ToInt32(сontrolCoordinateTextBox.Text)); }
    }     
} 
