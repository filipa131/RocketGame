namespace Raketa1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.brod = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelaBodovi = new System.Windows.Forms.Label();
            this.prepreka1 = new System.Windows.Forms.PictureBox();
            this.prepreka2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.brod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prepreka1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prepreka2)).BeginInit();
            this.SuspendLayout();
            // 
            // brod
            // 
            this.brod.BackColor = System.Drawing.Color.Transparent;
            this.brod.Image = global::Raketa1.Properties.Resources.brod;
            this.brod.Location = new System.Drawing.Point(241, 509);
            this.brod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.brod.Name = "brod";
            this.brod.Size = new System.Drawing.Size(84, 168);
            this.brod.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.brod.TabIndex = 0;
            this.brod.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelaBodovi
            // 
            this.labelaBodovi.AutoSize = true;
            this.labelaBodovi.BackColor = System.Drawing.Color.Transparent;
            this.labelaBodovi.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelaBodovi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelaBodovi.Location = new System.Drawing.Point(14, 11);
            this.labelaBodovi.Name = "labelaBodovi";
            this.labelaBodovi.Size = new System.Drawing.Size(187, 46);
            this.labelaBodovi.TabIndex = 1;
            this.labelaBodovi.Text = "Bodovi: 0";
            // 
            // prepreka1
            // 
            this.prepreka1.Image = global::Raketa1.Properties.Resources.prepreka;
            this.prepreka1.Location = new System.Drawing.Point(14, 326);
            this.prepreka1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prepreka1.Name = "prepreka1";
            this.prepreka1.Size = new System.Drawing.Size(280, 62);
            this.prepreka1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.prepreka1.TabIndex = 2;
            this.prepreka1.TabStop = false;
            // 
            // prepreka2
            // 
            this.prepreka2.Image = global::Raketa1.Properties.Resources.prepreka;
            this.prepreka2.Location = new System.Drawing.Point(305, 15);
            this.prepreka2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prepreka2.Name = "prepreka2";
            this.prepreka2.Size = new System.Drawing.Size(280, 62);
            this.prepreka2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.prepreka2.TabIndex = 3;
            this.prepreka2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(598, 691);
            this.Controls.Add(this.prepreka2);
            this.Controls.Add(this.prepreka1);
            this.Controls.Add(this.labelaBodovi);
            this.Controls.Add(this.brod);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raketa";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.brod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prepreka1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prepreka2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox brod;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelaBodovi;
        private System.Windows.Forms.PictureBox prepreka1;
        private System.Windows.Forms.PictureBox prepreka2;
    }
}

