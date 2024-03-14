namespace MenuTest
{
    partial class Start
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.NameString = new System.Windows.Forms.TextBox();
            this.EnteringName = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(282, 36);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(305, 105);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // NameString
            // 
            this.NameString.Location = new System.Drawing.Point(282, 176);
            this.NameString.Name = "NameString";
            this.NameString.Size = new System.Drawing.Size(305, 20);
            this.NameString.TabIndex = 4;
            this.NameString.TextChanged += new System.EventHandler(this.NameString_TextChanged);
            // 
            // EnteringName
            // 
            this.EnteringName.Location = new System.Drawing.Point(364, 202);
            this.EnteringName.Name = "EnteringName";
            this.EnteringName.Size = new System.Drawing.Size(137, 23);
            this.EnteringName.TabIndex = 5;
            this.EnteringName.Text = " Да, меня так зовут!";
            this.EnteringName.UseVisualStyleBackColor = true;
            this.EnteringName.Click += new System.EventHandler(this.EnteringName_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(824, 381);
            this.Controls.Add(this.EnteringName);
            this.Controls.Add(this.NameString);
            this.Controls.Add(this.pictureBox2);
            this.MaximumSize = new System.Drawing.Size(840, 420);
            this.MinimumSize = new System.Drawing.Size(840, 420);
            this.Name = "Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Морской Бой";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox NameString;
        private System.Windows.Forms.Button EnteringName;
    }
}