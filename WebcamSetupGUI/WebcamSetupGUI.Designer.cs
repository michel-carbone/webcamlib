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
            this.get_parameters_button = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label_top_value_read_only6 = new Arsalis.WebcamLibrary.label_top_value_read_only();
            this.label_top_value_read_only5 = new Arsalis.WebcamLibrary.label_top_value_read_only();
            this.label_top_value_read_only4 = new Arsalis.WebcamLibrary.label_top_value_read_only();
            this.label_top_value_read_only3 = new Arsalis.WebcamLibrary.label_top_value_read_only();
            this.label_top_value_read_only2 = new Arsalis.WebcamLibrary.label_top_value_read_only();
            this.label_top_value_read_only1 = new Arsalis.WebcamLibrary.label_top_value_read_only();
            this.groupBox_selectWebcam.SuspendLayout();
            this.groupBox_setParameter.SuspendLayout();
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
            // label_top_value_read_only6
            // 
            this.label_top_value_read_only6.Location = new System.Drawing.Point(437, 48);
            this.label_top_value_read_only6.Name = "label_top_value_read_only6";
            this.label_top_value_read_only6.Size = new System.Drawing.Size(80, 45);
            this.label_top_value_read_only6.TabIndex = 7;
            // 
            // label_top_value_read_only5
            // 
            this.label_top_value_read_only5.Location = new System.Drawing.Point(351, 48);
            this.label_top_value_read_only5.Name = "label_top_value_read_only5";
            this.label_top_value_read_only5.Size = new System.Drawing.Size(80, 45);
            this.label_top_value_read_only5.TabIndex = 6;
            // 
            // label_top_value_read_only4
            // 
            this.label_top_value_read_only4.Location = new System.Drawing.Point(265, 48);
            this.label_top_value_read_only4.Name = "label_top_value_read_only4";
            this.label_top_value_read_only4.Size = new System.Drawing.Size(80, 45);
            this.label_top_value_read_only4.TabIndex = 5;
            // 
            // label_top_value_read_only3
            // 
            this.label_top_value_read_only3.Location = new System.Drawing.Point(179, 48);
            this.label_top_value_read_only3.Name = "label_top_value_read_only3";
            this.label_top_value_read_only3.Size = new System.Drawing.Size(80, 45);
            this.label_top_value_read_only3.TabIndex = 4;
            // 
            // label_top_value_read_only2
            // 
            this.label_top_value_read_only2.Location = new System.Drawing.Point(93, 48);
            this.label_top_value_read_only2.Name = "label_top_value_read_only2";
            this.label_top_value_read_only2.Size = new System.Drawing.Size(80, 45);
            this.label_top_value_read_only2.TabIndex = 3;
            // 
            // label_top_value_read_only1
            // 
            this.label_top_value_read_only1.Location = new System.Drawing.Point(7, 48);
            this.label_top_value_read_only1.Name = "label_top_value_read_only1";
            this.label_top_value_read_only1.Size = new System.Drawing.Size(80, 45);
            this.label_top_value_read_only1.TabIndex = 2;
            // 
            // WebcamSetupGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 266);
            this.Controls.Add(this.groupBox_setParameter);
            this.Controls.Add(this.groupBox_selectWebcam);
            this.Name = "WebcamSetupGUI";
            this.Text = "WebcamSetupGUI";
            this.Load += new System.EventHandler(this.WebcamSetupGUI_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WebcamSetupGUI_FormClosed);
            this.groupBox_selectWebcam.ResumeLayout(false);
            this.groupBox_setParameter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

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
        
    }
}

