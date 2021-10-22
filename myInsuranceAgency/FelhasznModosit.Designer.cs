
namespace myInsuranceAgency
{
    partial class FelhasznModosit
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
            this.btnFelhasznMod = new System.Windows.Forms.Button();
            this.comboBoxAdmin = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textJelszo2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textJelszo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxFelhaszn = new System.Windows.Forms.ComboBox();
            this.btnTorol = new System.Windows.Forms.Button();
            this.textFelhasznNev = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnJelszoMod = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFelhasznMod
            // 
            this.btnFelhasznMod.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnFelhasznMod.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFelhasznMod.ForeColor = System.Drawing.Color.White;
            this.btnFelhasznMod.Location = new System.Drawing.Point(708, 407);
            this.btnFelhasznMod.Name = "btnFelhasznMod";
            this.btnFelhasznMod.Size = new System.Drawing.Size(170, 50);
            this.btnFelhasznMod.TabIndex = 28;
            this.btnFelhasznMod.Text = "Módosítás";
            this.btnFelhasznMod.UseVisualStyleBackColor = false;
            this.btnFelhasznMod.Click += new System.EventHandler(this.btnFelhasznMod_Click);
            // 
            // comboBoxAdmin
            // 
            this.comboBoxAdmin.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxAdmin.FormattingEnabled = true;
            this.comboBoxAdmin.Items.AddRange(new object[] {
            "nincs",
            "van"});
            this.comboBoxAdmin.Location = new System.Drawing.Point(616, 355);
            this.comboBoxAdmin.Name = "comboBoxAdmin";
            this.comboBoxAdmin.Size = new System.Drawing.Size(262, 36);
            this.comboBoxAdmin.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(310, 358);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(287, 29);
            this.label5.TabIndex = 26;
            this.label5.Text = "Adminisztrátori jogosultság:";
            // 
            // textJelszo2
            // 
            this.textJelszo2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textJelszo2.Location = new System.Drawing.Point(616, 571);
            this.textJelszo2.Name = "textJelszo2";
            this.textJelszo2.PasswordChar = '*';
            this.textJelszo2.Size = new System.Drawing.Size(262, 36);
            this.textJelszo2.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(310, 571);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 29);
            this.label4.TabIndex = 24;
            this.label4.Text = "Jelszó ismételt megadása:";
            // 
            // textJelszo
            // 
            this.textJelszo.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textJelszo.Location = new System.Drawing.Point(616, 519);
            this.textJelszo.Name = "textJelszo";
            this.textJelszo.PasswordChar = '*';
            this.textJelszo.Size = new System.Drawing.Size(262, 36);
            this.textJelszo.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(310, 519);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 29);
            this.label3.TabIndex = 22;
            this.label3.Text = "Jelszó:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(310, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 29);
            this.label2.TabIndex = 20;
            this.label2.Text = "Felhasználónév:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(196, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 37);
            this.label1.TabIndex = 19;
            this.label1.Text = "Felhasználó módosítás";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.label6.Location = new System.Drawing.Point(240, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(449, 29);
            this.label6.TabIndex = 29;
            this.label6.Text = "Válassza ki a módosítani kívánt felhasználót!";
            // 
            // comboBoxFelhaszn
            // 
            this.comboBoxFelhaszn.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.comboBoxFelhaszn.FormattingEnabled = true;
            this.comboBoxFelhaszn.Location = new System.Drawing.Point(616, 175);
            this.comboBoxFelhaszn.Name = "comboBoxFelhaszn";
            this.comboBoxFelhaszn.Size = new System.Drawing.Size(262, 36);
            this.comboBoxFelhaszn.TabIndex = 30;
            this.comboBoxFelhaszn.SelectedIndexChanged += new System.EventHandler(this.comboBoxFelhaszn_SelectedIndexChanged);
            // 
            // btnTorol
            // 
            this.btnTorol.BackColor = System.Drawing.Color.Red;
            this.btnTorol.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTorol.ForeColor = System.Drawing.Color.White;
            this.btnTorol.Location = new System.Drawing.Point(708, 725);
            this.btnTorol.Name = "btnTorol";
            this.btnTorol.Size = new System.Drawing.Size(170, 50);
            this.btnTorol.TabIndex = 31;
            this.btnTorol.Text = "Törlés";
            this.btnTorol.UseVisualStyleBackColor = false;
            this.btnTorol.Click += new System.EventHandler(this.btnTorol_Click);
            // 
            // textFelhasznNev
            // 
            this.textFelhasznNev.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textFelhasznNev.Location = new System.Drawing.Point(616, 299);
            this.textFelhasznNev.Name = "textFelhasznNev";
            this.textFelhasznNev.Size = new System.Drawing.Size(262, 36);
            this.textFelhasznNev.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.label7.Location = new System.Drawing.Point(240, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(480, 29);
            this.label7.TabIndex = 33;
            this.label7.Text = "Felhasználónév és/vagy jogosultság módosítása";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.label8.Location = new System.Drawing.Point(240, 471);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(485, 29);
            this.label8.TabIndex = 34;
            this.label8.Text = "Felhasználó jelszavának módosítása módosítása";
            // 
            // btnJelszoMod
            // 
            this.btnJelszoMod.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnJelszoMod.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnJelszoMod.ForeColor = System.Drawing.Color.White;
            this.btnJelszoMod.Location = new System.Drawing.Point(708, 623);
            this.btnJelszoMod.Name = "btnJelszoMod";
            this.btnJelszoMod.Size = new System.Drawing.Size(170, 50);
            this.btnJelszoMod.TabIndex = 35;
            this.btnJelszoMod.Text = "Módosítás";
            this.btnJelszoMod.UseVisualStyleBackColor = false;
            this.btnJelszoMod.Click += new System.EventHandler(this.btnJelszoMod_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 13.8F);
            this.label9.Location = new System.Drawing.Point(240, 725);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(202, 29);
            this.label9.TabIndex = 36;
            this.label9.Text = "Felhasználó törlése";
            // 
            // FelhasznModosit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnJelszoMod);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textFelhasznNev);
            this.Controls.Add(this.btnTorol);
            this.Controls.Add(this.comboBoxFelhaszn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnFelhasznMod);
            this.Controls.Add(this.comboBoxAdmin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textJelszo2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textJelszo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FelhasznModosit";
            this.Size = new System.Drawing.Size(1150, 850);
            this.Load += new System.EventHandler(this.FelhasznModosit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFelhasznMod;
        private System.Windows.Forms.ComboBox comboBoxAdmin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textJelszo2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textJelszo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxFelhaszn;
        private System.Windows.Forms.Button btnTorol;
        private System.Windows.Forms.TextBox textFelhasznNev;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnJelszoMod;
        private System.Windows.Forms.Label label9;
    }
}
