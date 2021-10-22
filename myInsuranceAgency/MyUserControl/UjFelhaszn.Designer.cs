
namespace myInsuranceAgency.MyUserControl
{
    partial class UjFelhaszn
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxAdmin = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textJelszo2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textJelszo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textFNev = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRogzit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxAdmin
            // 
            this.comboBoxAdmin.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxAdmin.FormattingEnabled = true;
            this.comboBoxAdmin.Items.AddRange(new object[] {
            "nincs",
            "van"});
            this.comboBoxAdmin.Location = new System.Drawing.Point(595, 516);
            this.comboBoxAdmin.Name = "comboBoxAdmin";
            this.comboBoxAdmin.Size = new System.Drawing.Size(262, 36);
            this.comboBoxAdmin.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(289, 519);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(287, 29);
            this.label5.TabIndex = 16;
            this.label5.Text = "Adminisztrátori jogosultság:";
            // 
            // textJelszo2
            // 
            this.textJelszo2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textJelszo2.Location = new System.Drawing.Point(595, 442);
            this.textJelszo2.Name = "textJelszo2";
            this.textJelszo2.PasswordChar = '*';
            this.textJelszo2.Size = new System.Drawing.Size(262, 36);
            this.textJelszo2.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(289, 442);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 29);
            this.label4.TabIndex = 14;
            this.label4.Text = "Jelszó ismételt megadása:";
            // 
            // textJelszo
            // 
            this.textJelszo.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textJelszo.Location = new System.Drawing.Point(595, 368);
            this.textJelszo.Name = "textJelszo";
            this.textJelszo.PasswordChar = '*';
            this.textJelszo.Size = new System.Drawing.Size(262, 36);
            this.textJelszo.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(289, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 29);
            this.label3.TabIndex = 12;
            this.label3.Text = "Jelszó:";
            // 
            // textFNev
            // 
            this.textFNev.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textFNev.Location = new System.Drawing.Point(595, 295);
            this.textFNev.Name = "textFNev";
            this.textFNev.Size = new System.Drawing.Size(262, 36);
            this.textFNev.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(289, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "Felhasználónév:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(253, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 37);
            this.label1.TabIndex = 9;
            this.label1.Text = "Új felhasználó rögzítése";
            // 
            // btnRogzit
            // 
            this.btnRogzit.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnRogzit.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRogzit.ForeColor = System.Drawing.Color.White;
            this.btnRogzit.Location = new System.Drawing.Point(663, 588);
            this.btnRogzit.Name = "btnRogzit";
            this.btnRogzit.Size = new System.Drawing.Size(194, 60);
            this.btnRogzit.TabIndex = 18;
            this.btnRogzit.Text = "Rögzít";
            this.btnRogzit.UseVisualStyleBackColor = false;
            this.btnRogzit.Click += new System.EventHandler(this.btnRogzit_Click);
            // 
            // UjFelhaszn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnRogzit);
            this.Controls.Add(this.comboBoxAdmin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textJelszo2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textJelszo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textFNev);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UjFelhaszn";
            this.Size = new System.Drawing.Size(1150, 850);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAdmin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textJelszo2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textJelszo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textFNev;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRogzit;
    }
}
