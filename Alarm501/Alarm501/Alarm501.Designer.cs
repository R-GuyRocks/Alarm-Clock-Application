
namespace Alarm501
{
    partial class Alarm501
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.alarmListBox = new System.Windows.Forms.ListBox();
            this.editButton = new System.Windows.Forms.Button();
            this.addAlarmButton = new System.Windows.Forms.Button();
            this.snoozeButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.wentOffLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // alarmListBox
            // 
            this.alarmListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmListBox.FormattingEnabled = true;
            this.alarmListBox.ItemHeight = 29;
            this.alarmListBox.Location = new System.Drawing.Point(33, 94);
            this.alarmListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.alarmListBox.Name = "alarmListBox";
            this.alarmListBox.Size = new System.Drawing.Size(229, 149);
            this.alarmListBox.TabIndex = 1;
            this.alarmListBox.SelectedIndexChanged += new System.EventHandler(this.alarmListBox_SelectedIndexChanged);
            // 
            // editButton
            // 
            this.editButton.Enabled = false;
            this.editButton.Location = new System.Drawing.Point(33, 26);
            this.editButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(87, 38);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // addAlarmButton
            // 
            this.addAlarmButton.Location = new System.Drawing.Point(175, 26);
            this.addAlarmButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addAlarmButton.Name = "addAlarmButton";
            this.addAlarmButton.Size = new System.Drawing.Size(87, 38);
            this.addAlarmButton.TabIndex = 3;
            this.addAlarmButton.Text = "+";
            this.addAlarmButton.UseVisualStyleBackColor = true;
            this.addAlarmButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // snoozeButton
            // 
            this.snoozeButton.Enabled = false;
            this.snoozeButton.Location = new System.Drawing.Point(33, 327);
            this.snoozeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.snoozeButton.Name = "snoozeButton";
            this.snoozeButton.Size = new System.Drawing.Size(87, 38);
            this.snoozeButton.TabIndex = 4;
            this.snoozeButton.Text = "Snooze";
            this.snoozeButton.UseVisualStyleBackColor = true;
            this.snoozeButton.Click += new System.EventHandler(this.snoozeButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(175, 327);
            this.stopButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(87, 38);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // wentOffLabel
            // 
            this.wentOffLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wentOffLabel.Location = new System.Drawing.Point(33, 254);
            this.wentOffLabel.Name = "wentOffLabel";
            this.wentOffLabel.Size = new System.Drawing.Size(229, 58);
            this.wentOffLabel.TabIndex = 7;
            this.wentOffLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.wentOffLabel.Visible = false;
            // 
            // Alarm501
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 391);
            this.Controls.Add(this.wentOffLabel);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.snoozeButton);
            this.Controls.Add(this.addAlarmButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.alarmListBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Alarm501";
            this.Text = "Alarm501";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button addAlarmButton;
        public System.Windows.Forms.ListBox alarmListBox;
        public System.Windows.Forms.Button editButton;
        public System.Windows.Forms.Button snoozeButton;
        public System.Windows.Forms.Button stopButton;
        public System.Windows.Forms.Label wentOffLabel;
    }
}

