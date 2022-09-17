/* AddOrEditAlarms.cs
 * Author: Riley Smith
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm501
{
    public delegate void SetExitReasonMethod(string s);

    /// <summary>
    /// A class containing the functionality for setting the time of the alarm and configuring whether the alarm is
    /// turned on or not.
    /// </summary>
    public partial class AddOrEditAlarms : Form
    {
        SetExitReasonMethod serm;

        /// <summary>
        /// Initializes the component.
        /// </summary>
        public AddOrEditAlarms(SetExitReasonMethod s)
        {
            InitializeComponent();
            alarmSoundComboBox.Items.Add("Radar");
            alarmSoundComboBox.Items.Add("Beacon");
            alarmSoundComboBox.Items.Add("Chimes");
            alarmSoundComboBox.Items.Add("Circuit");
            alarmSoundComboBox.Items.Add("Reflection");
            serm = s;
            serm("");
        }

        /// <summary>
        /// An event handler for when the set button is clicked. The value of the local buttonPressed variable is
        /// changed to "Set", the local alarmTime variable is set to the time in the clock time picker, and the form
        /// is closed.
        /// </summary>
        /// <param name="sender">Contains a reference to the object that raised the event.</param>
        /// <param name="e">Holds the event data.</param>
        private void setAlarmButton_Click(object sender, EventArgs e)
        {
            serm("Set");
            this.Close();
        }

        /// <summary>
        /// An event handler for when the cancel button is clicked. The value of the local buttonPressed variable is
        /// changed to "Cancel", and the form is closed.
        /// </summary>
        /// <param name="sender">Contains a reference to the object that raised the event.</param>
        /// <param name="e">Holds the event data.</param>
        private void cancelAlarmButton_Click(object sender, EventArgs e)
        {
            serm("Cancel");
            this.Close();
        }

        /// <summary>
        /// A method which sets the clockTimePicker control's value equal to the time passed in.
        /// </summary>
        /// <param name="time">The time to set the clockTimePicker's value to.</param>
        public void SetClockTimePickerValue(DateTime time)
        {
            clockTimePicker.Value = time;
        }

        /// <summary>
        /// A method that checks or unchecks the onCheckBox control depending on the value passed in.
        /// </summary>
        /// <param name="isChecked">A bool representing whether the onCheckBox control should be checked or not.</param>
        public void SetOnCheckBoxValue(bool isChecked)
        {
            onCheckBox.Checked = isChecked;
        }

        /// <summary>
        /// A method which sets the snoozePeriodUpDown's value equal to the value passed in.
        /// </summary>
        /// <param name="snoozePeriod">The number to set the snoozePeriodUpDown's value to.</param>
        public void SetSnoozePeriodUpDownValue(int snoozePeriod)
        {
            snoozePeriodUpDown.Value = snoozePeriod;
        }

        private void onCheckBox_CheckedChanged(object sender, EventArgs e){ }

        private void clockTimePicker_ValueChanged(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }

        private void alarmSoundLabel_Click(object sender, EventArgs e) { }

        private void alarmSoundComboBox_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
