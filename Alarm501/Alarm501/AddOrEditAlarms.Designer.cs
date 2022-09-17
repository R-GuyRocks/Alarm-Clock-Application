
namespace Alarm501
{
    partial class AddOrEditAlarms
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
            this.clockTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cancelAlarmButton = new System.Windows.Forms.Button();
            this.onCheckBox = new System.Windows.Forms.CheckBox();
            this.setAlarmButton = new System.Windows.Forms.Button();
            this.snoozePeriodLabel = new System.Windows.Forms.Label();
            this.snoozePeriodUpDown = new System.Windows.Forms.NumericUpDown();
            this.alarmSoundComboBox = new System.Windows.Forms.ComboBox();
            this.alarmSoundLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.snoozePeriodUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // clockTimePicker
            // 
            this.clockTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.clockTimePicker.Location = new System.Drawing.Point(31, 46);
            this.clockTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clockTimePicker.Name = "clockTimePicker";
            this.clockTimePicker.Size = new System.Drawing.Size(200, 22);
            this.clockTimePicker.TabIndex = 0;
            this.clockTimePicker.ValueChanged += new System.EventHandler(this.clockTimePicker_ValueChanged);
            // 
            // cancelAlarmButton
            // 
            this.cancelAlarmButton.Location = new System.Drawing.Point(31, 189);
            this.cancelAlarmButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelAlarmButton.Name = "cancelAlarmButton";
            this.cancelAlarmButton.Size = new System.Drawing.Size(84, 41);
            this.cancelAlarmButton.TabIndex = 1;
            this.cancelAlarmButton.Text = "Cancel";
            this.cancelAlarmButton.UseVisualStyleBackColor = true;
            this.cancelAlarmButton.Click += new System.EventHandler(this.cancelAlarmButton_Click);
            // 
            // onCheckBox
            // 
            this.onCheckBox.AutoSize = true;
            this.onCheckBox.Location = new System.Drawing.Point(247, 46);
            this.onCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.onCheckBox.Name = "onCheckBox";
            this.onCheckBox.Size = new System.Drawing.Size(49, 21);
            this.onCheckBox.TabIndex = 2;
            this.onCheckBox.Text = "On";
            this.onCheckBox.UseVisualStyleBackColor = true;
            this.onCheckBox.CheckedChanged += new System.EventHandler(this.onCheckBox_CheckedChanged);
            // 
            // setAlarmButton
            // 
            this.setAlarmButton.Location = new System.Drawing.Point(247, 189);
            this.setAlarmButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.setAlarmButton.Name = "setAlarmButton";
            this.setAlarmButton.Size = new System.Drawing.Size(84, 41);
            this.setAlarmButton.TabIndex = 3;
            this.setAlarmButton.Text = "Set";
            this.setAlarmButton.UseVisualStyleBackColor = true;
            this.setAlarmButton.Click += new System.EventHandler(this.setAlarmButton_Click);
            // 
            // snoozePeriodLabel
            // 
            this.snoozePeriodLabel.AutoSize = true;
            this.snoozePeriodLabel.Location = new System.Drawing.Point(28, 82);
            this.snoozePeriodLabel.Name = "snoozePeriodLabel";
            this.snoozePeriodLabel.Size = new System.Drawing.Size(105, 17);
            this.snoozePeriodLabel.TabIndex = 4;
            this.snoozePeriodLabel.Text = "Snooze Period:";
            this.snoozePeriodLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // snoozePeriodUpDown
            // 
            this.snoozePeriodUpDown.Location = new System.Drawing.Point(150, 80);
            this.snoozePeriodUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.snoozePeriodUpDown.Name = "snoozePeriodUpDown";
            this.snoozePeriodUpDown.Size = new System.Drawing.Size(81, 22);
            this.snoozePeriodUpDown.TabIndex = 5;
            this.snoozePeriodUpDown.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // alarmSoundComboBox
            // 
            this.alarmSoundComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.alarmSoundComboBox.FormattingEnabled = true;
            this.alarmSoundComboBox.Location = new System.Drawing.Point(150, 118);
            this.alarmSoundComboBox.Name = "alarmSoundComboBox";
            this.alarmSoundComboBox.Size = new System.Drawing.Size(121, 24);
            this.alarmSoundComboBox.TabIndex = 6;
            this.alarmSoundComboBox.SelectedIndexChanged += new System.EventHandler(this.alarmSoundComboBox_SelectedIndexChanged);
            // 
            // alarmSoundLabel
            // 
            this.alarmSoundLabel.AutoSize = true;
            this.alarmSoundLabel.Location = new System.Drawing.Point(28, 125);
            this.alarmSoundLabel.Name = "alarmSoundLabel";
            this.alarmSoundLabel.Size = new System.Drawing.Size(93, 17);
            this.alarmSoundLabel.TabIndex = 7;
            this.alarmSoundLabel.Text = "Alarm Sound:";
            this.alarmSoundLabel.Click += new System.EventHandler(this.alarmSoundLabel_Click);
            // 
            // AddOrEditAlarms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 273);
            this.Controls.Add(this.alarmSoundLabel);
            this.Controls.Add(this.alarmSoundComboBox);
            this.Controls.Add(this.snoozePeriodUpDown);
            this.Controls.Add(this.snoozePeriodLabel);
            this.Controls.Add(this.setAlarmButton);
            this.Controls.Add(this.onCheckBox);
            this.Controls.Add(this.cancelAlarmButton);
            this.Controls.Add(this.clockTimePicker);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddOrEditAlarms";
            this.Text = "Add/Edit Alarm";
            ((System.ComponentModel.ISupportInitialize)(this.snoozePeriodUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelAlarmButton;
        private System.Windows.Forms.Button setAlarmButton;
        public System.Windows.Forms.CheckBox onCheckBox;
        public System.Windows.Forms.DateTimePicker clockTimePicker;
        private System.Windows.Forms.Label snoozePeriodLabel;
        public System.Windows.Forms.NumericUpDown snoozePeriodUpDown;
        private System.Windows.Forms.Label alarmSoundLabel;
        public System.Windows.Forms.ComboBox alarmSoundComboBox;
    }
}