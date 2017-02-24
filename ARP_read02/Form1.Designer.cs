namespace ARP_read02
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pingBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.fetchBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.stopRPC = new MaterialSkin.Controls.MaterialFlatButton();
            this.label1 = new MaterialSkin.Controls.MaterialLabel();
            this.conStatus = new MaterialSkin.Controls.MaterialLabel();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.panel1 = new System.Windows.Forms.Panel();
            this.setMaxIp = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialFlatButton3 = new MaterialSkin.Controls.MaterialFlatButton();
            this.button1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.button2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.button3 = new MaterialSkin.Controls.MaterialFlatButton();
            this.textBox1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pingBtn
            // 
            this.pingBtn.AutoSize = true;
            this.pingBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pingBtn.Depth = 0;
            this.pingBtn.Location = new System.Drawing.Point(30, 125);
            this.pingBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.pingBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.pingBtn.Name = "pingBtn";
            this.pingBtn.Primary = false;
            this.pingBtn.Size = new System.Drawing.Size(44, 36);
            this.pingBtn.TabIndex = 0;
            this.pingBtn.Text = "Ping";
            this.pingBtn.UseVisualStyleBackColor = true;
            this.pingBtn.Click += new System.EventHandler(this.pingBtn_Click);
            // 
            // fetchBtn
            // 
            this.fetchBtn.AutoSize = true;
            this.fetchBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fetchBtn.Depth = 0;
            this.fetchBtn.Location = new System.Drawing.Point(83, 125);
            this.fetchBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.fetchBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.fetchBtn.Name = "fetchBtn";
            this.fetchBtn.Primary = false;
            this.fetchBtn.Size = new System.Drawing.Size(54, 36);
            this.fetchBtn.TabIndex = 1;
            this.fetchBtn.Text = "Fetch";
            this.fetchBtn.UseVisualStyleBackColor = true;
            this.fetchBtn.Click += new System.EventHandler(this.fetchBtn_Click);
            // 
            // stopRPC
            // 
            this.stopRPC.AutoSize = true;
            this.stopRPC.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stopRPC.Depth = 0;
            this.stopRPC.Location = new System.Drawing.Point(147, 125);
            this.stopRPC.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.stopRPC.MouseState = MaterialSkin.MouseState.HOVER;
            this.stopRPC.Name = "stopRPC";
            this.stopRPC.Primary = false;
            this.stopRPC.Size = new System.Drawing.Size(77, 36);
            this.stopRPC.TabIndex = 2;
            this.stopRPC.Text = "Stop RPC";
            this.stopRPC.UseVisualStyleBackColor = true;
            this.stopRPC.Click += new System.EventHandler(this.stopRPC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Depth = 0;
            this.label1.Font = new System.Drawing.Font("Roboto", 11F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.MouseState = MaterialSkin.MouseState.HOVER;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Connected:";
            // 
            // conStatus
            // 
            this.conStatus.AutoSize = true;
            this.conStatus.Depth = 0;
            this.conStatus.Font = new System.Drawing.Font("Roboto", 11F);
            this.conStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.conStatus.Location = new System.Drawing.Point(26, 88);
            this.conStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.conStatus.Name = "conStatus";
            this.conStatus.Size = new System.Drawing.Size(0, 19);
            this.conStatus.TabIndex = 4;
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(317, 73);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(10, 255);
            this.materialDivider1.TabIndex = 5;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(30, 180);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 140);
            this.panel1.TabIndex = 6;
            // 
            // setMaxIp
            // 
            this.setMaxIp.Depth = 0;
            this.setMaxIp.Location = new System.Drawing.Point(231, 132);
            this.setMaxIp.MouseState = MaterialSkin.MouseState.HOVER;
            this.setMaxIp.Name = "setMaxIp";
            this.setMaxIp.Primary = true;
            this.setMaxIp.Size = new System.Drawing.Size(75, 23);
            this.setMaxIp.TabIndex = 7;
            this.setMaxIp.Text = "Max IP";
            this.setMaxIp.UseVisualStyleBackColor = true;
            this.setMaxIp.Click += new System.EventHandler(this.setMaxIp_Click);
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Location = new System.Drawing.Point(371, 124);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(67, 36);
            this.materialFlatButton1.TabIndex = 8;
            this.materialFlatButton1.Text = "Browse";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            // 
            // materialFlatButton2
            // 
            this.materialFlatButton2.AutoSize = true;
            this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.Location = new System.Drawing.Point(451, 125);
            this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Primary = false;
            this.materialFlatButton2.Size = new System.Drawing.Size(82, 36);
            this.materialFlatButton2.TabIndex = 9;
            this.materialFlatButton2.Text = "MAKESAFE";
            this.materialFlatButton2.UseVisualStyleBackColor = true;
            // 
            // materialFlatButton3
            // 
            this.materialFlatButton3.AutoSize = true;
            this.materialFlatButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton3.Depth = 0;
            this.materialFlatButton3.Location = new System.Drawing.Point(553, 124);
            this.materialFlatButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton3.Name = "materialFlatButton3";
            this.materialFlatButton3.Primary = false;
            this.materialFlatButton3.Size = new System.Drawing.Size(72, 36);
            this.materialFlatButton3.TabIndex = 10;
            this.materialFlatButton3.Text = "Decrypt";
            this.materialFlatButton3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Depth = 0;
            this.button1.Location = new System.Drawing.Point(371, 124);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button1.MouseState = MaterialSkin.MouseState.HOVER;
            this.button1.Name = "button1";
            this.button1.Primary = false;
            this.button1.Size = new System.Drawing.Size(67, 36);
            this.button1.TabIndex = 8;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.Depth = 0;
            this.button2.Location = new System.Drawing.Point(457, 125);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button2.MouseState = MaterialSkin.MouseState.HOVER;
            this.button2.Name = "button2";
            this.button2.Primary = false;
            this.button2.Size = new System.Drawing.Size(82, 36);
            this.button2.TabIndex = 9;
            this.button2.Text = "Makesafe";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button3.Depth = 0;
            this.button3.Location = new System.Drawing.Point(553, 124);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button3.MouseState = MaterialSkin.MouseState.HOVER;
            this.button3.Name = "button3";
            this.button3.Primary = false;
            this.button3.Size = new System.Drawing.Size(73, 36);
            this.button3.TabIndex = 10;
            this.button3.Text = "Retrieve";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Depth = 0;
            this.textBox1.Hint = "Key Override";
            this.textBox1.Location = new System.Drawing.Point(420, 213);
            this.textBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.Size = new System.Drawing.Size(151, 23);
            this.textBox1.TabIndex = 11;
            this.textBox1.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(409, 180);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(171, 19);
            this.materialLabel1.TabIndex = 12;
            this.materialLabel1.Text = "Enter Key (8 Characters)";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(3, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(99, 19);
            this.materialLabel2.TabIndex = 13;
            this.materialLabel2.Text = "File Selected:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.materialLabel2);
            this.panel2.Location = new System.Drawing.Point(352, 256);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 64);
            this.panel2.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 339);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.materialFlatButton3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.materialFlatButton2);
            this.Controls.Add(this.materialFlatButton1);
            this.Controls.Add(this.setMaxIp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.conStatus);
            this.Controls.Add(this.stopRPC);
            this.Controls.Add(this.fetchBtn);
            this.Controls.Add(this.pingBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FISSRA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton pingBtn;
        private MaterialSkin.Controls.MaterialFlatButton fetchBtn;
        private MaterialSkin.Controls.MaterialFlatButton stopRPC;
        protected MaterialSkin.Controls.MaterialLabel label1;
        public MaterialSkin.Controls.MaterialLabel conStatus;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialRaisedButton setMaxIp;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton2;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton3;
        private MaterialSkin.Controls.MaterialFlatButton button1;
        private MaterialSkin.Controls.MaterialFlatButton button3;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.Panel panel2;
        public MaterialSkin.Controls.MaterialFlatButton button2;
    }
}

