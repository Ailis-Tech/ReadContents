namespace ReadContents
{
    partial class NumberWindow
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
            this.pictBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictBox
            // 
            this.pictBox.Location = new System.Drawing.Point(81, 359);
            this.pictBox.Name = "pictBox";
            this.pictBox.Size = new System.Drawing.Size(296, 90);
            this.pictBox.TabIndex = 1;
            this.pictBox.TabStop = false;
            // 
            // NumberWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 461);
            this.Controls.Add(this.pictBox);
            this.Name = "NumberWindow";
            this.Text = "すうじのよみかた";
            ((System.ComponentModel.ISupportInitialize)(this.pictBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictBox;
    }
}