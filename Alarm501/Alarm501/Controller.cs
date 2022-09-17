/* Controller.cs
 * Author: Riley Smith
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace Alarm501
{
    /// <summary>
    /// A delegate that removes the need for the controller class to have a Alarm501 variable. It can store any methods with string, Alarm,
    /// and index parameters.
    /// </summary>
    /// <param name="s">A string to be used by the view.</param>
    /// <param name="a">An alarm to be used by the view.</param>
    /// <param name="index">An int to be used by the view.</param>
    public delegate void Update(string s, Alarm a, int index);

    /// <summary>
    /// The controller of this MVC-designed program. It calls the AddOrEditAlarms class when the user wants to add or edit alarms,
    /// and it communicates with the Alarm class to pass the correct data to the model. The methods in this class are called by the
    /// Alarm501 class, which is the view, so that the correct data can be displayed in the view.
    /// </summary>
    public class Controller
    {
        System.Timers.Timer timer;
        string currentExitReason = "";
        public List<Alarm> alarms = new List<Alarm>();
        public int currentSelectedIndex = -1;
        public Update setAlarmListBoxItemMethod;
        public Update addToListBoxMethod;
        public Update setWentOffLabelTextMethod;
        public Update disableAddAlarmButtonMethod;
        public Update invokeWentOffLabelToConfigureMethod;
        public Update invokeAlarmListBoxToConfigureMethod;
        public Update setSelectedIndexMethod;
        public Update configureButtonsAndLabelMethod;

        /// <summary>
        /// The class constructor. It's empty for this program.
        /// </summary>
        public Controller() { }
    
        /// <summary>
        /// A method for editing an existing alarm. It calls other methods which set the edit form's values equal to the values that
        /// were previously saved for the alarms. It also saves the updated values by calling an event handler for when the edit form
        /// is closed.
        /// </summary>
        /// <param name="selectedIndex">The index of the alarm's information in the view's alarmListBox control.</param>
        public void EditAlarm(int selectedIndex)
        {
            currentSelectedIndex = selectedIndex;
            AddOrEditAlarms addOrEdit = new AddOrEditAlarms(SetExitReason);
            if (selectedIndex != -1)
            {
                addOrEdit.SetClockTimePickerValue(alarms[selectedIndex].AlarmTime);
                addOrEdit.SetOnCheckBoxValue(alarms[selectedIndex].IsOn);
                addOrEdit.SetSnoozePeriodUpDownValue(alarms[selectedIndex].SnoozePeriod);
                addOrEdit.Show();
                addOrEdit.FormClosed += new FormClosedEventHandler(Edit_Form_Closed);
            }
        }

        /// <summary>
        /// An event handler for when the edit form is closed. It replaces the old information of the alarm that's being edited and
        /// replaces it with the information put into the input view.
        /// </summary>
        /// <param name="sender">Contains a reference to the object that raised the event.</param>
        /// <param name="e">Holds the event data.</param>
        private void Edit_Form_Closed(object sender, FormClosedEventArgs e)
        {
            int selectedIndex = currentSelectedIndex;
            AddOrEditAlarms currentAddOrEdit = (AddOrEditAlarms)sender;
            if (currentExitReason.Equals("Set"))
            {
                Alarm a = new Alarm();
                a.AlarmTime = currentAddOrEdit.clockTimePicker.Value;
                a.Status = "Turned Off";
                a.SnoozePeriod = (int)currentAddOrEdit.snoozePeriodUpDown.Value;
                a.IsOn = currentAddOrEdit.onCheckBox.Checked;
                if (currentAddOrEdit.alarmSoundComboBox.SelectedItem == null)
                {
                    a.AlarmSound = "None";
                }
                else
                {
                    a.AlarmSound = currentAddOrEdit.alarmSoundComboBox.SelectedItem.ToString();
                }
                alarms[selectedIndex] = a;
                string onCheckBoxValue = "Off";
                if (a.IsOn == true)
                {
                    a.Status = "Turned on";
                    onCheckBoxValue = "On";
                }
                DateTime time = currentAddOrEdit.clockTimePicker.Value;
                setAlarmListBoxItemMethod(time.ToString("hh:mm tt") + " " + onCheckBoxValue, a, 0);
            }
        }

        /// <summary>
        /// A method to be called whenever the user selected the add alarm button. It creates a new input view form, shows 
        /// the form, and calls the appropriate event handler for whenever the add alarm form is closed.
        /// </summary>
        public void AddAlarm()
        {
            AddOrEditAlarms addOrEdit = new AddOrEditAlarms(SetExitReason);
            addOrEdit.Show();
            addOrEdit.FormClosed += new FormClosedEventHandler(Add_Form_Closed);           
        }

        /// <summary>
        /// An event handler for whenever the add alarm form is closed. It takes all of the information that was entered into
        /// the input view form and saves it in an Alarm object so that it can be displayed to the user in the output view form.
        /// </summary>
        /// <param name="sender">Contains a reference to the object that raised the event.</param>
        /// <param name="e">Holds the event data.</param>
        private void Add_Form_Closed(object sender, FormClosedEventArgs e)
        {
            AddOrEditAlarms currentAddOrEdit = (AddOrEditAlarms)sender;
            if (currentExitReason.Equals("Set"))
            {
                Alarm a = new Alarm();
                a.AlarmTime = currentAddOrEdit.clockTimePicker.Value;
                a.Status = "Turned off";
                a.SnoozePeriod = (int)currentAddOrEdit.snoozePeriodUpDown.Value;
                a.IsOn = currentAddOrEdit.onCheckBox.Checked;
                if (currentAddOrEdit.alarmSoundComboBox.SelectedItem == null)
                {
                    a.AlarmSound = "None";
                }
                else
                {
                    a.AlarmSound = currentAddOrEdit.alarmSoundComboBox.SelectedItem.ToString();
                }
                alarms.Add(a);
                string onCheckBoxValue = "Off";
                if (a.IsOn == true)
                {
                    a.Status = "Turned on";
                    onCheckBoxValue = "On";
                }
                DateTime time = currentAddOrEdit.clockTimePicker.Value;
                addToListBoxMethod(time.ToString("hh:mm tt") + " " + onCheckBoxValue, a, 0);
                if (alarms.Count > 4)
                {
                    disableAddAlarmButtonMethod("", a, 0);
                }            
            }
        }

        /// <summary>
        /// A method for handling the functionality of the snooze button. It resets the alarm time to the current time
        /// plus the number of minutes the user set as their snooze period.
        /// </summary>
        /// <param name="selectedIndex">The index of the alarm that's being snoozed in the alarmListBox control.</param>
        public void HandleSnooze(int selectedIndex)
        {
            alarms[selectedIndex].PreviousTime = alarms[selectedIndex].AlarmTime;
            alarms[selectedIndex].GoingOff = false;
            if (alarms[selectedIndex].SnoozePeriod == 0)
            {
                alarms[selectedIndex].AlarmTime = DateTime.Now.AddSeconds(1);
            }
            else
            {
                alarms[selectedIndex].AlarmTime = DateTime.Now.AddMinutes(alarms[selectedIndex].SnoozePeriod);
            }
            
            alarms[selectedIndex].Status = "Snoozed";
            setWentOffLabelTextMethod(alarms[selectedIndex].Status, new Alarm(), 0);
        }

        /// <summary>
        /// A method for handling the functionality of the stop button. It labels the alarm as no longer going off,
        /// changes the alarm's status to reflect this change, and returns a string containing the alarm's time
        /// and "Off" so that the user can know that the alarm was turned off.
        /// </summary>
        /// <param name="selectedIndex">The index of the alarm that's being stopped in the alarmListBox control.</param>
        /// <returns>The time of the alarm, plus "Off."</returns>
        public string HandleStop(int selectedIndex)
        {
            alarms[selectedIndex].IsOn = false;
            alarms[selectedIndex].GoingOff = false;
            DateTime timer = alarms[selectedIndex].PreviousTime;
            alarms[selectedIndex].Status = "Stopped";
            return timer.ToString("hh:mm tt") + " Off";
        }

        /// <summary>
        /// A method for handling the functionality required for whenever the output view form loads in. It retrieves all
        /// the alarms in the "Alarms.txt" file and displays them to the user.
        /// </summary>
        /// <returns>A list of the alarm times listed in the Alarms.txt file.</returns>
        public List<string> HandleFormLoad()
        {
            List<string> alarmTimes = new List<string>();
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            System.IO.StreamReader file = new System.IO.StreamReader(path + "/Alarms.txt");
            if (file.EndOfStream != true)
            {
                while (file.EndOfStream != true)
                {
                    Alarm a = new Alarm();
                    a.AlarmTime = DateTime.ParseExact(file.ReadLine(), "hh:mm:ss tt", CultureInfo.InvariantCulture);
                    a.GoingOff = false;
                    a.IsOn = false;
                    a.Status = "Turned off";
                    alarms.Add(a);
                    DateTime time = a.AlarmTime;
                    alarmTimes.Add(time.ToString("hh:mm tt") + " " + "Off");
                }
            }
            file.Close();
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            return alarmTimes;
        }

        /// <summary>
        /// A method for handling the functionality required for when the output view form is closed. It saves all of the times listed in
        /// the output view form's alarmListBox control into the "Alarms.txt" file.
        /// </summary>
        public void HandleFormClosed()
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            File.WriteAllText(path + "/Alarms.txt", String.Empty);
            System.IO.StreamWriter file = new System.IO.StreamWriter(path + "/Alarms.txt");
            DateTime time;
            if (alarms.Count > 0)
            {
                foreach (Alarm a in alarms)
                {
                    time = a.AlarmTime;
                    file.WriteLine(time.ToString("hh:mm:ss tt"));
                }
            }
            file.Close();
            timer.Stop(); 
       }

        /// <summary>
        /// A method that passes gets the reason for exiting an input view form so that the program can properly handle the information
        /// that the user put into the form.
        /// </summary>
        /// <param name="s">The reason for exiting the input view form.</param>
        private void SetExitReason(string s)
        {
            currentExitReason = s;
        }

        /// <summary>
        /// An event for when time goes by. It constantly checks whether or not an alarm is going off. If an alarm is going off,
        /// it changes the index of the alarm list box to the alarm that is going off. It also enables the snooze and stop buttons,
        /// and changes the value of the label at the bottom of the screen to show that the alarm is going off.
        /// </summary>
        /// <param name="sender">Contains a reference to the object that raised the event.</param>
        /// <param name="e">Holds the event data.</param>
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (alarms.Count > 0)
            {
                DateTime now;
                DateTime alarm;
                int index = -1;
                foreach (Alarm a in alarms)
                {
                    index++;
                    if (a.IsOn)
                    {
                        now = DateTime.Now;
                        alarm = a.AlarmTime;
                        if (now.Hour == alarm.Hour && now.Minute == alarm.Minute && now.Second == alarm.Second)
                        {
                            a.GoingOff = true;
                            invokeWentOffLabelToConfigureMethod("", a, index);
                            invokeAlarmListBoxToConfigureMethod("", a, 0);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// A method which changes the status of the Alarm variable that was passed in and sets the selected index of the alarmListBox control
        /// in the view.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="index"></param>
        public void SetStatusAndSelectedIndex(Alarm a, int index)
        {
            if (a.AlarmSound.Equals("None"))
            {
                a.Status = "Alarm went off without a sound";
            }
            else if (a.AlarmSound.Equals("Radar"))
            {
                a.Status = "Alarm went off with a radar sound";
            }
            else if (a.AlarmSound.Equals("Beacon"))
            {
                a.Status = "Alarm went off with a beacon sound";
            }
            else if (a.AlarmSound.Equals("Chimes"))
            {
                a.Status = "Alarm went off with a chimes sound";
            }
            else if (a.AlarmSound.Equals("Circuit"))
            {
                a.Status = "Alarm went off with a circuit sound";
            }
            else
            {
                a.Status = "Alarm went off with a reflection sound";
            }
            if (index == currentSelectedIndex)
            {
                setSelectedIndexMethod("", a, -1);
                setSelectedIndexMethod("", a, index);
            }
            else
            {
                setSelectedIndexMethod("", a, alarms.IndexOf(a));
            }
        }
            
        /// <summary>
        /// A method which calls the configureButtonsAndLabel method in the view by using the Update delegate.
        /// </summary>
        /// <param name="a">The alarm that corresponds to the current selected index of the alarmListBox control in the view.</param>
        public void CallConfigureButtonsAndLabel(Alarm a)
        {
            if (alarms.IndexOf(a) == currentSelectedIndex)
            {
                configureButtonsAndLabelMethod("", a, 0);
            }
        }
    }
}