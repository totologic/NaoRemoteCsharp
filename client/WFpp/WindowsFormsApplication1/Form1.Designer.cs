namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.listBehaviors = new System.Windows.Forms.ListView();
            this.logOutput = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IPinput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectButton.Location = new System.Drawing.Point(13, 47);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(233, 53);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = false;
            this.ConnectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DisconnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisconnectButton.Location = new System.Drawing.Point(13, 112);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(233, 53);
            this.DisconnectButton.TabIndex = 1;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = false;
            this.DisconnectButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBehaviors
            // 
            this.listBehaviors.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listBehaviors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBehaviors.Location = new System.Drawing.Point(13, 214);
            this.listBehaviors.Name = "listBehaviors";
            this.listBehaviors.Size = new System.Drawing.Size(233, 236);
            this.listBehaviors.TabIndex = 2;
            this.listBehaviors.UseCompatibleStateImageBehavior = false;
            this.listBehaviors.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // logOutput
            // 
            this.logOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutput.Location = new System.Drawing.Point(266, 196);
            this.logOutput.Name = "logOutput";
            this.logOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.logOutput.Size = new System.Drawing.Size(464, 254);
            this.logOutput.TabIndex = 3;
            this.logOutput.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Behaviors :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(262, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Log :";
            // 
            // IPinput
            // 
            this.IPinput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPinput.Location = new System.Drawing.Point(54, 7);
            this.IPinput.Name = "IPinput";
            this.IPinput.Size = new System.Drawing.Size(192, 29);
            this.IPinput.TabIndex = 6;
            this.IPinput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "IP :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(333, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(61, 26);
            this.textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(400, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(61, 26);
            this.textBox2.TabIndex = 9;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(467, 13);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(61, 26);
            this.textBox3.TabIndex = 10;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(534, 13);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(61, 26);
            this.textBox4.TabIndex = 11;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(601, 13);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(61, 26);
            this.textBox5.TabIndex = 12;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(668, 13);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(61, 26);
            this.textBox6.TabIndex = 13;
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(668, 47);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(61, 26);
            this.textBox7.TabIndex = 19;
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(601, 47);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(61, 26);
            this.textBox8.TabIndex = 18;
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(534, 47);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(61, 26);
            this.textBox9.TabIndex = 17;
            // 
            // textBox10
            // 
            this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(467, 47);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(61, 26);
            this.textBox10.TabIndex = 16;
            // 
            // textBox11
            // 
            this.textBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(400, 47);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(61, 26);
            this.textBox11.TabIndex = 15;
            // 
            // textBox12
            // 
            this.textBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.Location = new System.Drawing.Point(333, 47);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(61, 26);
            this.textBox12.TabIndex = 14;
            // 
            // textBox13
            // 
            this.textBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.Location = new System.Drawing.Point(668, 79);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(61, 26);
            this.textBox13.TabIndex = 25;
            // 
            // textBox14
            // 
            this.textBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox14.Location = new System.Drawing.Point(601, 79);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(61, 26);
            this.textBox14.TabIndex = 24;
            // 
            // textBox15
            // 
            this.textBox15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox15.Location = new System.Drawing.Point(534, 79);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(61, 26);
            this.textBox15.TabIndex = 23;
            // 
            // textBox16
            // 
            this.textBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.Location = new System.Drawing.Point(467, 79);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(61, 26);
            this.textBox16.TabIndex = 22;
            // 
            // textBox17
            // 
            this.textBox17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox17.Location = new System.Drawing.Point(400, 79);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(61, 26);
            this.textBox17.TabIndex = 21;
            // 
            // textBox18
            // 
            this.textBox18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox18.Location = new System.Drawing.Point(333, 79);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(61, 26);
            this.textBox18.TabIndex = 20;
            // 
            // textBox19
            // 
            this.textBox19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox19.Location = new System.Drawing.Point(668, 112);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(61, 26);
            this.textBox19.TabIndex = 31;
            // 
            // textBox20
            // 
            this.textBox20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox20.Location = new System.Drawing.Point(601, 112);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(61, 26);
            this.textBox20.TabIndex = 30;
            // 
            // textBox21
            // 
            this.textBox21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox21.Location = new System.Drawing.Point(534, 112);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(61, 26);
            this.textBox21.TabIndex = 29;
            // 
            // textBox22
            // 
            this.textBox22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox22.Location = new System.Drawing.Point(467, 112);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(61, 26);
            this.textBox22.TabIndex = 28;
            // 
            // textBox23
            // 
            this.textBox23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox23.Location = new System.Drawing.Point(400, 112);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(61, 26);
            this.textBox23.TabIndex = 27;
            // 
            // textBox24
            // 
            this.textBox24.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox24.Location = new System.Drawing.Point(333, 112);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(61, 26);
            this.textBox24.TabIndex = 26;
            // 
            // textBox25
            // 
            this.textBox25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox25.Location = new System.Drawing.Point(266, 13);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(61, 26);
            this.textBox25.TabIndex = 32;
            // 
            // textBox26
            // 
            this.textBox26.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox26.Location = new System.Drawing.Point(266, 47);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(61, 26);
            this.textBox26.TabIndex = 33;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 999999;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 462);
            this.Controls.Add(this.textBox26);
            this.Controls.Add(this.textBox25);
            this.Controls.Add(this.textBox19);
            this.Controls.Add(this.textBox20);
            this.Controls.Add(this.textBox21);
            this.Controls.Add(this.textBox22);
            this.Controls.Add(this.textBox23);
            this.Controls.Add(this.textBox24);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IPinput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logOutput);
            this.Controls.Add(this.listBehaviors);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.ConnectButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.ListView listBehaviors;
        private System.Windows.Forms.RichTextBox logOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IPinput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.TextBox textBox25;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.Timer timer1;
    }
}

