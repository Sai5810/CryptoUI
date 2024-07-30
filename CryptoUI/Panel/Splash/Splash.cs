using CryptoUI.Properties;
using System;

public partial class Splash : System.Windows.Forms.Form
{
    public Splash()
    {
        InitializeComponent();
    }

    private void landingPictureBox_Click(object sender, EventArgs e)
    {

    }
}

partial class Splash
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    public void Update(string msg)
    {
        this.progress.Description = msg;
        this.progress.Refresh();
    }

    private void InitializeComponent()
    {
        this.landingPictureBox = new System.Windows.Forms.PictureBox();
        this.progress = new DevExpress.XtraWaitForm.ProgressPanel();
        ((System.ComponentModel.ISupportInitialize)(this.landingPictureBox)).BeginInit();
        this.SuspendLayout();
        // 
        // landing
        // 
        this.landingPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
        this.landingPictureBox.Image = Resources.landing;
        this.landingPictureBox.Location = new System.Drawing.Point(0, 0);
        this.landingPictureBox.Name = "LandingBox";
        this.landingPictureBox.Size = new System.Drawing.Size(480, 270);
        this.landingPictureBox.TabIndex = 0;
        this.landingPictureBox.TabStop = false;
        this.landingPictureBox.Click += new System.EventHandler(this.landingPictureBox_Click);
        // 
        // progress
        // 
        this.progress.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.progress.WaitAnimationType = DevExpress.Utils.Animation.WaitingAnimatorType.Line;
        this.progress.LineAnimationElementHeight = 0;
        this.progress.Caption = "CryptoUI Loading...";
        this.progress.Description = "Python reference data loading";
        this.progress.AppearanceCaption.Font = new System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, 7);
        this.progress.AppearanceDescription.Font = new System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, 6);
        this.progress.Location = new System.Drawing.Point(0, 0);
        this.progress.Name = "Progress";
        this.progress.Size = new System.Drawing.Size(480, 40);
        this.progress.TabIndex = 0;
        this.progress.TabStop = false;
        // 
        // Splash
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(480, 310);
        this.ControlBox = false;
        this.Controls.Add(this.landingPictureBox);
        this.Controls.Add(this.progress);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "Splash";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Splash";
        ((System.ComponentModel.ISupportInitialize)(this.landingPictureBox)).EndInit();
        this.ResumeLayout(false);

    }

    private System.Windows.Forms.PictureBox landingPictureBox;
    private DevExpress.XtraWaitForm.ProgressPanel progress;
}