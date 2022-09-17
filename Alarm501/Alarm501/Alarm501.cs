/* Alarm501.cs
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
using System.IO;
using System.Globalization;

namespace Alarm501
{
    /// <summary>
    /// A class containing the functionality for adding, editing, stopping and snoozing alarms.
    /// </summary>
    public partial class Alarm501 : Form
    {

        private Controller controller;

        /// <summary>
        /// Initializes the component, and reads in information from the "Alarms.txt" file. If there are times
        /// listed in the file, these times are converted into DateTime values and listed in the alarm list box.
        /// </summary>
        public Alarm501(Controller c)
        {
            InitializeComponent();
            controller = c;
            controller.setAlarmListBoxItemMethod = SetAlarmListBoxItem;
            controller.addToListBoxMethod = AddToListBox;
            controller.setWentOffLabelTextMethod = SetWentOffLabelText;
            controller.disableAddAlarmButtonMethod = DisableAddAlarmButton;
            controller.invokeWentOffLabelToConfigureMethod = InvokeWentOffLabelToConfigure;
            controller.invokeAlarmListBoxToConfigureMethod = InvokeAlarmListBoxtoConfigure;
            controller.setSelectedIndexMethod = SetSelectedIndex;
            controller.configureButtonsAndLabelMethod = ConfigureButtonsAndLabel;
            List<string> alarmTimes = c.HandleFormLoad();
            if (alarmTimes.Count >= 5)
            {
                addAlarmButton.Enabled = false;
            }
            foreach (string s in alarmTimes)
            {
                alarmListBox.Items.Add(s);
            }
            this.FormClosed += new FormClosedEventHandler(Form_FormClosed);
        }

        /// <summary>
        /// An event handler for when the index of the alarm list box changes. If nothing is selected, the label
        /// at the bottom of the form becomes blank. Otherwise, this event handler checks if an alarm can be added,
        /// snoozed, or stopped.
        /// </summary>
        /// <param name="sender">Contains a reference to the object that raised the event.</param>
        /// <param name="e">Holds the event data.</param>
        private void alarmListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.currentSelectedIndex = alarmListBox.SelectedIndex;
            if (alarmListBox.SelectedIndex != -1)
            {
                editButton.Invoke((Action)delegate
                {
                    editButton.Enabled = true;
                });
                if (alarmListBox.Items.Count < 5)
                {
                    addAlarmButton.Invoke((Action)delegate
                    {
                        addAlarmButton.Enabled = true;
                    });
                }
                wentOffLabel.Visible = true;
                wentOffLabel.Text = controller.alarms[alarmListBox.SelectedIndex].Status;
                if (controller.alarms[alarmListBox.SelectedIndex].GoingOff == true)
                {
                    wentOffLabel.Invoke((Action)delegate
                    {
                        snoozeButton.Enabled = true;
                    });
                    wentOffLabel.Invoke((Action)delegate
                    {
                        stopButton.Enabled = true;
                    });
                }
                else
                {
                    wentOffLabel.Invoke((Action)delegate
                    {
                        snoozeButton.Enabled = false;
                    });
                    wentOffLabel.Invoke((Action)delegate
                    {
                        stopButton.Enabled = false;
                    });
                }
            }
            else
            {
                wentOffLabel.Text = "";
            } 
        }

        /// <summary>
        /// An event handler for the add alarm button. It creates a new AddOrEditAlarms, and calls the Form_Closed
        /// event to handle the adding the alarm to the list box.
        /// </summary>
        /// <param name="sender">Contains a reference to the object that raised the event.</param>
        /// <param name="e">Holds the event data.</param>
        private void addButton_Click(object sender, EventArgs e)
        {
            controller.AddAlarm();
            if (alarmListBox.Items.Count > 4)
            {
                addAlarmButton.Enabled = false;
            }
        }

        /// <summary>
        /// An event handler for when the edit button is clicked. If an item in the list box is selected,
        /// then a new addOrEditAlarms is made to hold the new time.
        /// </summary>
        /// <param name="sender">Contains a reference to the object that raised the event.</param>
        /// <param name="e">Holds the event data.</param>
        private void editButton_Click(object sender, EventArgs e)
        {
            controller.EditAlarm(alarmListBox.SelectedIndex);
        }   

        /// <summary>
        /// An event handler for when the stop button is clicked. It changes the value of the alarm to indicate
        /// that it's not going off, disables the snooze and stop buttons, and changes the text of the alarm to
        /// say "Off."
        /// </summary>
        /// <param name="sender">Contains a reference to the object that raised the event.</param>
        /// <param name="e">Holds the event data.</param>
        private void stopButton_Click(object sender, EventArgs e)
        {
            alarmListBox.Items[alarmListBox.SelectedIndex] = controller.HandleStop(alarmListBox.SelectedIndex);
        }

        /// <summary>
        /// An event handler for the snooze button. It signals that the alarm is no longer going off, disables the
        /// snooze and stop buttons, and adds three seconds to the alarm.
        /// </summary>
        /// <param name="sender">Contains a reference to the object that raised the event.</param>
        /// <param name="e">Holds the event data.</param>
        private void snoozeButton_Click(object sender, EventArgs e)
        {
            controller.HandleSnooze(alarmListBox.SelectedIndex);
            snoozeButton.Enabled = false;
            stopButton.Enabled = false;
        }

        /// <summary>
        /// A method for disabling the add alarm button.
        /// </summary>
        /// <param name="s">A pointless string needed to keep this methods parameters the same as the Update delegate's parameters.</param>
        /// <param name="a">A pointless Alarm needed to keep this methods parameters the same as the Update delegate's parameters.</param>
        /// <param name="index">A pointless int needed to keep this methods parameters the same as the Update delegate's parameters.</param>
        public void DisableAddAlarmButton(string s, Alarm a, int index)
        {
            addAlarmButton.Enabled = false;
        }

        /// <summary>
        /// A method which takes a string parameter and adds it to the alarmListBox control.
        /// </summary>
        /// <param name="s">The item to add to the alarmListBox control.</param>
        /// <param name="a">A pointless Alarm needed to keep this methods parameters the same as the Update delegate's parameters.</param>
        /// <param name="index">A pointless int needed to keep this methods parameters the same as the Update delegate's parameters.</param>
        public void AddToListBox(string s, Alarm a, int index)
        {
            alarmListBox.Items.Add(s);
        }

        /// <summary>
        /// A method that sets the text of the current selected item in the alarmListBox control to the string variable that was passed in.
        /// </summary>
        /// <param name="s">The alarm time and whether it's on or off.</param>
        /// <param name="a">A pointless Alarm needed to keep this methods parameters the same as the Update delegate's parameters.</param>
        /// <param name="index">A pointless int needed to keep this methods parameters the same as the Update delegate's parameters.</param>
        public void SetAlarmListBoxItem(string s, Alarm a, int index)
        {
            alarmListBox.Items[alarmListBox.SelectedIndex] = s;
        }

        /// <summary>
        /// A method that sets the text of the wentOffLabel control to the string variable that was passed in.
        /// </summary>
        /// <param name="s">The status of the selected alarm.</param>
        /// <param name="a">A pointless Alarm needed to keep this methods parameters the same as the Update delegate's parameters.</param>
        /// <param name="index">A pointless int needed to keep this methods parameters the same as the Update delegate's parameters.</param>
        public void SetWentOffLabelText(string s, Alarm a, int index)
        {
            wentOffLabel.Text = s;
        }

        /// <summary>
        /// A method for changing the current selected index of the alarm list box.
        /// </summary>
        /// <param name="s">A pointless string needed to keep this methods parameters the same as the Update delegate's parameters.</param>
        /// <param name="a">A pointless Alarm needed to keep this methods parameters the same as the Update delegate's parameters.</param>
        /// <param name="index">An index to change the current selected index of the alarm list box to.</param>
        public void SetSelectedIndex(string s, Alarm a, int index)
        {
            alarmListBox.SelectedIndex = index;
        }

        /// <summary>
        /// A method that enables the snooze button and stop button, and makes the wentOffLabel control visible.
        /// </summary>
        /// <param name="s">A pointless string needed to keep this methods parameters the same as the Update delegate's parameters.</param>
        /// <param name="a">A pointless Alarm needed to keep this methods parameters the same as the Update delegate's parameters.</param>
        /// <param name="index">A pointless int needed to keep this methods parameters the same as the Update delegate's parameters.</param>
        public void ConfigureButtonsAndLabel(string s, Alarm a, int index)
        {
            snoozeButton.Invoke((Action)delegate
            {
                snoozeButton.Enabled = true;
            });
            stopButton.Invoke((Action)delegate
            {
                stopButton.Enabled = true;
            });
            wentOffLabel.Invoke((Action)delegate
            {
                wentOffLabel.Visible = true;
            });
        }

        /// <summary>
        /// A method that calls the SetStatusAndSelectedIndex method in the controller. This method is required because the modifications
        /// made in the SetStatusAndSelectedIndex method have to be wrapped in an invoke call.
        /// </summary>
        /// <param name="s">A pointless string needed to keep this methods parameters the same as the Update delegate's parameters.</param>
        /// <param name="a">The Alarm variable to be used in the SetStatusAndSelectedIndex method.</param>
        /// <param name="index">The int variable to be used in the SetStatusAndSelectedIndex method.</param>
        public void InvokeWentOffLabelToConfigure(string s, Alarm a, int index)
        {
            wentOffLabel.Invoke((Action)delegate
            {
                controller.SetStatusAndSelectedIndex(a, index);

            });
        }

        /// <summary>
        /// A method that calls the CallConfigureButtonsAndLabel method in the controller. This method is required because the modifications
        /// made in the CallConfigureButtonsAndLabel method have to be wrapped in an invoke call.        
        /// </summary>
        /// <param name="s">A pointless string needed to keep this methods parameters the same as the Update delegate's parameters.</param>
        /// <param name="a">The Alarm variable to be used in the CallConfigureButtonsAndLabel method.</param>
        /// <param name="index">A pointless int needed to keep this methods parameters the same as the Update delegate's parameters.</param>
        public void InvokeAlarmListBoxtoConfigure(string s, Alarm a, int index)
        {
            alarmListBox.Invoke((Action)delegate
            {
                controller.CallConfigureButtonsAndLabel(a);
            });
        }

        /// <summary>
        /// An event handler for when the main form is closed. It writes all of the alarms to the "Alarms.txt" file
        /// and stops the timer.
        /// </summary>
        /// <param name="sender">Contains a reference to the object that raised the event.</param>
        /// <param name="e">Holds the event data.</param>
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            controller.HandleFormClosed();
        }

        private void Form_Closed(object sender, FormClosedEventArgs e) { }

        private void Repeat_Form_Closed(object sender, FormClosedEventArgs e) { }

        private void Form1_Load(object sender, EventArgs e) { }

    }
}