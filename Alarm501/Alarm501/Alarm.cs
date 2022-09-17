/* Alarm.cs
 * Author: Riley Smith
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm501
{
    /// <summary>
    /// A class which holds the data for individual alarms. This class acts as the model in this program's MVC design.
    /// </summary>
    public class Alarm
    {
        DateTime alarmTime = new DateTime();
        DateTime previousTime = new DateTime();
        bool goingOff = false;
        string status = "Turned off";
        bool isOn = false;
        int snoozePeriod = 0;
        string alarmSound = "None";

        /// <summary>
        /// A getter and setter for alarmTime;
        /// </summary>
        public DateTime AlarmTime 
        {
            get { return alarmTime; }
            set { alarmTime = value; }
        }

        /// <summary>
        /// A getter and setter for previousTime;
        /// </summary>
        public DateTime PreviousTime
        {
            get { return previousTime; }
            set { previousTime = value; }
        }

        /// <summary>
        /// A getter and setter for goingOff;
        /// </summary>
        public bool GoingOff 
        {
            get { return goingOff; }
            set { goingOff = value; }
        }

        /// <summary>
        /// A getter and setter for status.
        /// </summary>
        public string Status 
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// A getter and setter for isOn.
        /// </summary>
        public bool IsOn 
        {
            get { return isOn; }
            set { isOn = value; }
        }

        /// <summary>
        /// A getter and setter for snoozePeriod.
        /// </summary>
        public int SnoozePeriod 
        {
            get { return snoozePeriod; }
            set { snoozePeriod = value; }
        }

        /// <summary>
        /// A getter and setter for alarmSound.
        /// </summary>
        public string AlarmSound 
        {
            get { return alarmSound; }
            set { alarmSound = value; }
        }

    }
}