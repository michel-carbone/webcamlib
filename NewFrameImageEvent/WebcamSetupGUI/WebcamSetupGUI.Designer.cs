namespace Arsalis.WebcamLibrary
{
    partial class WebcamSetupGUI
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
            this.groupBox_selectWebcam = new System.Windows.Forms.GroupBox();
            this.select_webcam_button = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox_setParameter = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_top_value_read_only6 = new Arsalis.WebcamLibrary.label_top_value_read_only();
            this.label_top_value_read_only5 = new Arsalis.WebcamLibrary.label_top_value_read_only();
            this.label_top_value_read_only4 = new Arsalis.WebcamLibrary.label_top_value_read_only();
            this.label_top_value_read_only3 = new Arsalis.WebcamLibrary.label_top_value_read_only();
            this.label_top_value_read_only2 = new Arsalis.WebcamLibrary.label_top_value_read_only();
            this.label_top_value_read_only1 = new Arsalis.WebcamLibrary.label_top_value_read_only();
            this.get_parameters_button = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox_set_resolution = new System.Windows.Forms.GroupBox();
            this.label_top_value_read_only7 = new Arsalis.WebcamLibrary.label_top_value_read_only();
            this.set_resolution_button = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.start_webcam_button = new System.Windows.Forms.Button();
            this.stop_webcam_button = new System.Windows.Forms.Button();
            this.groupBox_set_parameter = new System.Windows.Forms.GroupBox();
            this.label_top_numeric1 = new Arsalis.WebcamLibrary.label_top_numeric();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.set_parameter_button = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.refresh_webcamList_button = new System.Windows.Forms.Button();
            this.groupBox_selectWebcam.SuspendLayout();
            this.groupBox_setParameter.SuspendLayout();
            this.groupBox_set_resolution.SuspendLayout();
            this.groupBox_set_parameter.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_selectWebcam
            // 
            this.groupBox_selectWebcam.Controls.Add(this.select_webcam_button);
            this.groupBox_selectWebcam.Controls.Add(this.comboBox1);
            this.groupBox_selectWebcam.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_selectWebcam.Location = new System.Drawing.Point(0, 0);
            this.groupBox_selectWebcam.Name = "groupBox_selectWebcam";
            this.groupBox_selectWebcam.Size = new System.Drawing.Size(608, 53);
            this.groupBox_selectWebcam.TabIndex = 0;
            this.groupBox_selectWebcam.TabStop = false;
            this.groupBox_selectWebcam.Text = "Select and set webcam";
            // 
            // select_webcam_button
            // 
            this.select_webcam_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.select_webcam_button.Location = new System.Drawing.Point(521, 18);
            this.select_webcam_button.Name = "select_webcam_button";
            this.select_webcam_button.Size = new System.Drawing.Size(75, 23);
            this.select_webcam_button.TabIndex = 1;
            this.select_webcam_button.Text = "Set";
            this.select_webcam_button.UseVisualStyleBackColor = true;
            this.select_webcam_button.Click += new System.EventHandler(this.select_webcam_button_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(502, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // groupBox_setParameter
            // 
            this.groupBox_setParameter.Controls.Add(this.label1);
            this.groupBox_setParameter.Controls.Add(this.label_top_value_read_only6);
            this.groupBox_setParameter.Controls.Add(this.label_top_value_read_only5);
            this.groupBox_setParameter.Controls.Add(this.label_top_value_read_only4);
            this.groupBox_setParameter.Controls.Add(this.label_top_value_read_only3);
            this.groupBox_setParameter.Controls.Add(this.label_top_value_read_only2);
            this.groupBox_setParameter.Controls.Add(this.label_top_value_read_only1);
            this.groupBox_setParameter.Controls.Add(this.get_parameters_button);
            this.groupBox_setParameter.Controls.Add(this.comboBox2);
            this.groupBox_setParameter.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_setParameter.Location = new System.Drawing.Point(0, 53);
            this.groupBox_setParameter.Name = "groupBox_setParameter";
            this.groupBox_setParameter.Size = new System.Drawing.Size(608, 99);
            this.groupBox_setParameter.TabIndex = 2;
            this.groupBox_setParameter.TabStop = false;
            this.groupBox_setParameter.Text = "Select parameter and get values";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(519, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // label_top_value_read_only6
            // 
            this.label_top_value_read_only6.LabelText = "label1";
            this.label_top_value_read_only6.Location = new System.Drawing.Point(442, 48);
            this.label_top_value_read_only6.Name = "label_top_value_read_only6";
            this.label_top_value_read_only6.Size = new System.Drawing.Size(80, 45);
            this.label_top_value_read_only6.TabIndex = 7;
            // 
            // label_top_value_read_only5
            // 
            this.label_top_value_read_only5.LabelText = "label1";
            this.label_top_value_read_only5.Location = new System.Drawing.Point(356, 48);
            this.label_top_value_read_only5.Name = "label_top_value_read_only5";
            this.label_top_value_read_only5.Size = new System.Drawing.Size(80, 45);
            this.label_top_value_read_only5.TabIndex = 6;
            // 
            // label_top_value_read_only4
            // 
            this.label_top_value_read_only4.LabelText = "label1";
            this.label_top_value_read_only4.Location = new System.Drawing.Point(270, 48);
            this.label_top_value_read_only4.Name = "label_top_value_read_only4";
            this.label_top_value_read_only4.Size = new System.Drawing.Size(80, 45);
            this.label_top_value_read_only4.TabIndex = 5;
            // 
            // label_top_value_read_only3
            // 
            this.label_top_value_read_only3.LabelText = "label1";
            this.label_top_value_read_only3.Location = new System.Drawing.Point(184, 48);
            this.label_top_value_read_only3.Name = "label_top_value_read_only3";
            this.label_top_value_read_only3.Size = new System.Drawing.Size(80, 45);
            this.label_top_value_read_only3.TabIndex = 4;
            // 
            // label_top_value_read_only2
            // 
            this.label_top_value_read_only2.LabelText = "label1";
            this.label_top_value_read_only2.Location = new System.Drawing.Point(98, 48);
            this.label_top_value_read_only2.Name = "label_top_value_read_only2";
            this.label_top_value_read_only2.Size = new System.Drawing.Size(80, 45);
            this.label_top_value_read_only2.TabIndex = 3;
            // 
            // label_top_value_read_only1
            // 
            this.label_top_value_read_only1.LabelText = "label1";
            this.label_top_value_read_only1.Location = new System.Drawing.Point(12, 48);
            this.label_top_value_read_only1.Name = "label_top_value_read_only1";
            this.label_top_value_read_only1.Size = new System.Drawing.Size(80, 45);
            this.label_top_value_read_only1.TabIndex = 2;
            // 
            // get_parameters_button
            // 
            this.get_parameters_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.get_parameters_button.Enabled = false;
            this.get_parameters_button.Location = new System.Drawing.Point(521, 18);
            this.get_parameters_button.Name = "get_parameters_button";
            this.get_parameters_button.Size = new System.Drawing.Size(75, 23);
            this.get_parameters_button.TabIndex = 1;
            this.get_parameters_button.Text = "Get";
            this.get_parameters_button.UseVisualStyleBackColor = true;
            this.get_parameters_button.Click += new System.EventHandler(this.get_parameters_button_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(13, 20);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(502, 21);
            this.comboBox2.TabIndex = 0;
            // 
            // groupBox_set_resolution
            // 
            this.groupBox_set_resolution.Controls.Add(this.label_top_value_read_only7);
            this.groupBox_set_resolution.Controls.Add(this.set_resolution_button);
            this.groupBox_set_resolution.Controls.Add(this.comboBox3);
            this.groupBox_set_resolution.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_set_resolution.Location = new System.Drawing.Point(0, 152);
            this.groupBox_set_resolution.Name = "groupBox_set_resolution";
            this.groupBox_set_resolution.Size = new System.Drawing.Size(608, 99);
            this.groupBox_set_resolution.TabIndex = 3;
            this.groupBox_set_resolution.TabStop = false;
            this.groupBox_set_resolution.Text = "Set webcam resolution";
            // 
            // label_top_value_read_only7
            // 
            this.label_top_value_read_only7.LabelText = "label1";
            this.label_top_value_read_only7.Location = new System.Drawing.Point(12, 47);
            this.label_top_value_read_only7.Name = "label_top_value_read_only7";
            this.label_top_value_read_only7.Size = new System.Drawing.Size(508, 45);
            this.label_top_value_read_only7.TabIndex = 3;
            // 
            // set_resolution_button
            // 
            this.set_resolution_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.set_resolution_button.Enabled = false;
            this.set_resolution_button.Location = new System.Drawing.Point(521, 18);
            this.set_resolution_button.Name = "set_resolution_button";
            this.set_resolution_button.Size = new System.Drawing.Size(75, 23);
            this.set_resolution_button.TabIndex = 1;
            this.set_resolution_button.Text = "Set";
            this.set_resolution_button.UseVisualStyleBackColor = true;
            this.set_resolution_button.Click += new System.EventHandler(this.set_resolution_button_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox3.Enabled = false;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(13, 20);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(502, 21);
            this.comboBox3.TabIndex = 0;
            // 
            // start_webcam_button
            // 
            this.start_webcam_button.Location = new System.Drawing.Point(521, 358);
            this.start_webcam_button.Name = "start_webcam_button";
            this.start_webcam_button.Size = new System.Drawing.Size(75, 23);
            this.start_webcam_button.TabIndex = 4;
            this.start_webcam_button.Text = "Start webcam";
            this.start_webcam_button.UseVisualStyleBackColor = true;
            this.start_webcam_button.Click += new System.EventHandler(this.start_webcam_button_Click);
            // 
            // stop_webcam_button
            // 
            this.stop_webcam_button.Enabled = false;
            this.stop_webcam_button.Location = new System.Drawing.Point(521, 388);
            this.stop_webcam_button.Name = "stop_webcam_button";
            this.stop_webcam_button.Size = new System.Drawing.Size(75, 23);
            this.stop_webcam_button.TabIndex = 5;
            this.stop_webcam_button.Text = "Stop webcam";
            this.stop_webcam_button.UseVisualStyleBackColor = true;
            this.stop_webcam_button.Click += new System.EventHandler(this.stop_webcam_button_Click);
            // 
            // groupBox_set_parameter
            // 
            this.groupBox_set_parameter.Controls.Add(this.label_top_numeric1);
            this.groupBox_set_parameter.Controls.Add(this.label3);
            this.groupBox_set_parameter.Controls.Add(this.comboBox5);
            this.groupBox_set_parameter.Controls.Add(this.label2);
            this.groupBox_set_parameter.Controls.Add(this.set_parameter_button);
            this.groupBox_set_parameter.Controls.Add(this.comboBox4);
            this.groupBox_set_parameter.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_set_parameter.Location = new System.Drawing.Point(0, 251);
            this.groupBox_set_parameter.Name = "groupBox_set_parameter";
            this.groupBox_set_parameter.Size = new System.Drawing.Size(608, 99);
            this.groupBox_set_parameter.TabIndex = 6;
            this.groupBox_set_parameter.TabStop = false;
            this.groupBox_set_parameter.Text = "Select parameter and set values";
            // 
            // label_top_numeric1
            // 
            this.label_top_numeric1.LabelText = "Param value";
            this.label_top_numeric1.Location = new System.Drawing.Point(12, 47);
            this.label_top_numeric1.Name = "label_top_numeric1";
            this.label_top_numeric1.Size = new System.Drawing.Size(80, 45);
            this.label_top_numeric1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Flag";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(98, 66);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(121, 21);
            this.comboBox5.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.Location = new System.Drawing.Point(514, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            // 
            // set_parameter_button
            // 
            this.set_parameter_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.set_parameter_button.Enabled = false;
            this.set_parameter_button.Location = new System.Drawing.Point(521, 18);
            this.set_parameter_button.Name = "set_parameter_button";
            this.set_parameter_button.Size = new System.Drawing.Size(75, 23);
            this.set_parameter_button.TabIndex = 1;
            this.set_parameter_button.Text = "Set";
            this.set_parameter_button.UseVisualStyleBackColor = true;
            this.set_parameter_button.Click += new System.EventHandler(this.set_parameter_button_Click);
            // 
            // comboBox4
            // 
            this.comboBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox4.Enabled = false;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(13, 20);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(502, 21);
            this.comboBox4.TabIndex = 0;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // refresh_webcamList_button
            // 
            this.refresh_webcamList_button.Location = new System.Drawing.Point(12, 388);
            this.refresh_webcamList_button.Name = "refresh_webcamList_button";
            this.refresh_webcamList_button.Size = new System.Drawing.Size(75, 23);
            this.refresh_webcamList_button.TabIndex = 7;
            this.refresh_webcamList_button.Tag = "";
            this.refresh_webcamList_button.Text = "Refresh";
            this.refresh_webcamList_button.UseVisualStyleBackColor = true;
            this.refresh_webcamList_button.Click += new System.EventHandler(this.refresh_webcamList_button_Click);
            // 
            // WebcamSetupGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 423);
            this.Controls.Add(this.refresh_webcamList_button);
            this.Controls.Add(this.groupBox_set_parameter);
            this.Controls.Add(this.stop_webcam_button);
            this.Controls.Add(this.start_webcam_button);
            this.Controls.Add(this.groupBox_set_resolution);
            this.Controls.Add(this.groupBox_setParameter);
            this.Controls.Add(this.groupBox_selectWebcam);
            this.Name = "WebcamSetupGUI";
            this.Text = "WebcamSetupGUI";
            this.Load += new System.EventHandler(this.WebcamSetupGUI_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WebcamSetupGUI_FormClosed);
            this.groupBox_selectWebcam.ResumeLayout(false);
            this.groupBox_setParameter.ResumeLayout(false);
            this.groupBox_set_resolution.ResumeLayout(false);
            this.groupBox_set_parameter.ResumeLayout(false);
            this.groupBox_set_parameter.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Label label1;

        #endregion

        private System.Windows.Forms.GroupBox groupBox_selectWebcam;
        private System.Windows.Forms.Button select_webcam_button;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox_setParameter;
        private System.Windows.Forms.Button get_parameters_button;
        private System.Windows.Forms.ComboBox comboBox2;
        private label_top_value_read_only label_top_value_read_only3;
        private label_top_value_read_only label_top_value_read_only2;
        private label_top_value_read_only label_top_value_read_only1;
        private label_top_value_read_only label_top_value_read_only4;
        private label_top_value_read_only label_top_value_read_only6;
        private label_top_value_read_only label_top_value_read_only5;
        private System.Windows.Forms.GroupBox groupBox_set_resolution;
        private System.Windows.Forms.Button set_resolution_button;
        private System.Windows.Forms.ComboBox comboBox3;
        private label_top_value_read_only label_top_value_read_only7;
        private System.Windows.Forms.Button start_webcam_button;
        private System.Windows.Forms.Button stop_webcam_button;
        private System.Windows.Forms.GroupBox groupBox_set_parameter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button set_parameter_button;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Button refresh_webcamList_button;
        private label_top_numeric label_top_numeric1;
        
    }
}

