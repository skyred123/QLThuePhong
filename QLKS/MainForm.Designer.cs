namespace QLKS
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel_NhanVien = new System.Windows.Forms.Panel();
            this.btn_ChinhSuaTK = new System.Windows.Forms.Button();
            this.btn_TTNhanVien = new System.Windows.Forms.Button();
            this.btn_NhanVien = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.image_Avatar = new System.Windows.Forms.PictureBox();
            this.panel_View = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel_NhanVien.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_Avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.panel_NhanVien);
            this.panel1.Controls.Add(this.btn_NhanVien);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 537);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(0, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(220, 39);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel_NhanVien
            // 
            this.panel_NhanVien.AutoSize = true;
            this.panel_NhanVien.Controls.Add(this.btn_ChinhSuaTK);
            this.panel_NhanVien.Controls.Add(this.btn_TTNhanVien);
            this.panel_NhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_NhanVien.Location = new System.Drawing.Point(0, 170);
            this.panel_NhanVien.Name = "panel_NhanVien";
            this.panel_NhanVien.Size = new System.Drawing.Size(220, 110);
            this.panel_NhanVien.TabIndex = 2;
            // 
            // btn_ChinhSuaTK
            // 
            this.btn_ChinhSuaTK.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_ChinhSuaTK.Location = new System.Drawing.Point(0, 55);
            this.btn_ChinhSuaTK.Name = "btn_ChinhSuaTK";
            this.btn_ChinhSuaTK.Size = new System.Drawing.Size(220, 55);
            this.btn_ChinhSuaTK.TabIndex = 1;
            this.btn_ChinhSuaTK.Text = "Chỉnh Sửa Tài Khoản";
            this.btn_ChinhSuaTK.UseVisualStyleBackColor = true;
            this.btn_ChinhSuaTK.Click += new System.EventHandler(this.btn_ChinhSuaTK_Click);
            // 
            // btn_TTNhanVien
            // 
            this.btn_TTNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_TTNhanVien.Location = new System.Drawing.Point(0, 0);
            this.btn_TTNhanVien.Name = "btn_TTNhanVien";
            this.btn_TTNhanVien.Size = new System.Drawing.Size(220, 55);
            this.btn_TTNhanVien.TabIndex = 0;
            this.btn_TTNhanVien.Text = "Thông Tin";
            this.btn_TTNhanVien.UseVisualStyleBackColor = true;
            this.btn_TTNhanVien.Click += new System.EventHandler(this.btn_TTNhanVien_Click);
            // 
            // btn_NhanVien
            // 
            this.btn_NhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_NhanVien.Location = new System.Drawing.Point(0, 115);
            this.btn_NhanVien.Name = "btn_NhanVien";
            this.btn_NhanVien.Size = new System.Drawing.Size(220, 55);
            this.btn_NhanVien.TabIndex = 1;
            this.btn_NhanVien.Text = "Nhân Viên";
            this.btn_NhanVien.UseVisualStyleBackColor = true;
            this.btn_NhanVien.Click += new System.EventHandler(this.btn_NhanVien_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.image_Avatar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 115);
            this.panel2.TabIndex = 0;
            // 
            // image_Avatar
            // 
            this.image_Avatar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.image_Avatar.Location = new System.Drawing.Point(38, 12);
            this.image_Avatar.Name = "image_Avatar";
            this.image_Avatar.Size = new System.Drawing.Size(130, 90);
            this.image_Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image_Avatar.TabIndex = 0;
            this.image_Avatar.TabStop = false;
            // 
            // panel_View
            // 
            this.panel_View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_View.Location = new System.Drawing.Point(220, 0);
            this.panel_View.Name = "panel_View";
            this.panel_View.Size = new System.Drawing.Size(668, 537);
            this.panel_View.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 537);
            this.Controls.Add(this.panel_View);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_NhanVien.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.image_Avatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btn_NhanVien;
        private Panel panel2;
        private Button button2;
        private Panel panel_View;
        private Button btn_ChinhSuaTK;
        private Button btn_TTNhanVien;
        private Panel panel_NhanVien;
        private PictureBox image_Avatar;
    }
}