namespace Raketa
{
    partial class PostavkeForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.brzinaBrodaComboBox = new System.Windows.Forms.ComboBox();
            this.gumbSpremi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.kolicinaKometaComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.odabirLetjeliceComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Promjena brzine igre:";
            // 
            // brzinaBrodaComboBox
            // 
            this.brzinaBrodaComboBox.FormattingEnabled = true;
            this.brzinaBrodaComboBox.Items.AddRange(new object[] {
            "3",
            "5",
            "7"});
            this.brzinaBrodaComboBox.Location = new System.Drawing.Point(50, 99);
            this.brzinaBrodaComboBox.Name = "brzinaBrodaComboBox";
            this.brzinaBrodaComboBox.Size = new System.Drawing.Size(121, 28);
            this.brzinaBrodaComboBox.TabIndex = 2;
            this.brzinaBrodaComboBox.SelectedIndexChanged += new System.EventHandler(this.brzinaBrodaComboBox_SelectedIndexChanged);
            // 
            // gumbSpremi
            // 
            this.gumbSpremi.AutoSize = true;
            this.gumbSpremi.Location = new System.Drawing.Point(255, 381);
            this.gumbSpremi.Name = "gumbSpremi";
            this.gumbSpremi.Size = new System.Drawing.Size(75, 30);
            this.gumbSpremi.TabIndex = 3;
            this.gumbSpremi.Text = "Spremi";
            this.gumbSpremi.UseVisualStyleBackColor = true;
            this.gumbSpremi.Click += new System.EventHandler(this.gumbSpremi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Promjena količine kometa:";
            // 
            // kolicinaKometaComboBox
            // 
            this.kolicinaKometaComboBox.FormattingEnabled = true;
            this.kolicinaKometaComboBox.Items.AddRange(new object[] {
            "bez kometa",
            "x1",
            "x2"});
            this.kolicinaKometaComboBox.Location = new System.Drawing.Point(50, 213);
            this.kolicinaKometaComboBox.Name = "kolicinaKometaComboBox";
            this.kolicinaKometaComboBox.Size = new System.Drawing.Size(121, 28);
            this.kolicinaKometaComboBox.TabIndex = 5;
            this.kolicinaKometaComboBox.SelectedIndexChanged += new System.EventHandler(this.kolicinaKometaComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Odabir letjelice:";
            // 
            // odabirLetjeliceComboBox
            // 
            this.odabirLetjeliceComboBox.FormattingEnabled = true;
            this.odabirLetjeliceComboBox.Items.AddRange(new object[] {
            "vanzemaljac",
            "raketa"});
            this.odabirLetjeliceComboBox.Location = new System.Drawing.Point(50, 325);
            this.odabirLetjeliceComboBox.Name = "odabirLetjeliceComboBox";
            this.odabirLetjeliceComboBox.Size = new System.Drawing.Size(121, 28);
            this.odabirLetjeliceComboBox.TabIndex = 7;
            this.odabirLetjeliceComboBox.SelectedIndexChanged += new System.EventHandler(this.odabirLetjeliceComboBox_SelectedIndexChanged);
            // 
            // PostavkeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 433);
            this.Controls.Add(this.odabirLetjeliceComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.kolicinaKometaComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gumbSpremi);
            this.Controls.Add(this.brzinaBrodaComboBox);
            this.Controls.Add(this.label2);
            this.Name = "PostavkeForm";
            this.Text = "Postavke";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox brzinaBrodaComboBox;
        private System.Windows.Forms.Button gumbSpremi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox kolicinaKometaComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox odabirLetjeliceComboBox;
    }
}