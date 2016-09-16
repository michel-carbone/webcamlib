/*
 * Created by SharpDevelop.
 * User: michel
 * Date: 12/09/2016
 * Time: 16:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Arsalis.WebcamLibrary.Test
{
	partial class GUI
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
		    this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
		    this.pictureBox1 = new System.Windows.Forms.PictureBox();
		    ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
		    this.SuspendLayout();
		    // 
		    // videoSourcePlayer1
		    // 
		    this.videoSourcePlayer1.KeepAspectRatio = true;
		    this.videoSourcePlayer1.Location = new System.Drawing.Point(12, 12);
		    this.videoSourcePlayer1.Name = "videoSourcePlayer1";
		    this.videoSourcePlayer1.Size = new System.Drawing.Size(219, 292);
		    this.videoSourcePlayer1.TabIndex = 0;
		    this.videoSourcePlayer1.Text = "videoSourcePlayer1";
		    this.videoSourcePlayer1.VideoSource = null;
		    this.videoSourcePlayer1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.VideoSourcePlayer1NewFrame);
		    // 
		    // pictureBox1
		    // 
		    this.pictureBox1.Location = new System.Drawing.Point(265, 12);
		    this.pictureBox1.Name = "pictureBox1";
		    this.pictureBox1.Size = new System.Drawing.Size(435, 292);
		    this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		    this.pictureBox1.TabIndex = 1;
		    this.pictureBox1.TabStop = false;
		    // 
		    // GUI
		    // 
		    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		    this.ClientSize = new System.Drawing.Size(658, 292);
		    this.Controls.Add(this.pictureBox1);
		    this.Controls.Add(this.videoSourcePlayer1);
		    this.Name = "GUI";
		    this.Text = "GUI";
		    ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
		    this.ResumeLayout(false);
		    this.PerformLayout();
		}
		private System.Windows.Forms.PictureBox pictureBox1;
		public AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
		
	}
}
