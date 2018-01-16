namespace SmileFace
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.imageBox_cap = new Emgu.CV.UI.ImageBox();
            this.tb_tel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_depart = new System.Windows.Forms.Label();
            this.lb_company = new System.Windows.Forms.Label();
            this.lb_name = new System.Windows.Forms.Label();
            this.lb_tip = new System.Windows.Forms.Label();
            this.lb_num = new System.Windows.Forms.Label();
            this.imageBox_pic = new Emgu.CV.UI.ImageBox();
            this.pb_save = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pb_mengban = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_cap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_mengban)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox_cap
            // 
            this.imageBox_cap.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox_cap.Location = new System.Drawing.Point(73, 167);
            this.imageBox_cap.Name = "imageBox_cap";
            this.imageBox_cap.Size = new System.Drawing.Size(640, 480);
            this.imageBox_cap.TabIndex = 2;
            this.imageBox_cap.TabStop = false;
            // 
            // tb_tel
            // 
            this.tb_tel.BackColor = System.Drawing.SystemColors.Window;
            this.tb_tel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_tel.Font = new System.Drawing.Font("宋体", 29F);
            this.tb_tel.Location = new System.Drawing.Point(807, 673);
            this.tb_tel.Name = "tb_tel";
            this.tb_tel.Size = new System.Drawing.Size(290, 45);
            this.tb_tel.TabIndex = 4;
            this.tb_tel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_tel_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(37, 694);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "姓名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(228, 694);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "公司：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(465, 694);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "部门：";
            // 
            // lb_depart
            // 
            this.lb_depart.AutoSize = true;
            this.lb_depart.BackColor = System.Drawing.Color.Transparent;
            this.lb_depart.Font = new System.Drawing.Font("微软雅黑", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_depart.Location = new System.Drawing.Point(550, 694);
            this.lb_depart.Name = "lb_depart";
            this.lb_depart.Size = new System.Drawing.Size(0, 32);
            this.lb_depart.TabIndex = 10;
            // 
            // lb_company
            // 
            this.lb_company.AutoSize = true;
            this.lb_company.BackColor = System.Drawing.Color.Transparent;
            this.lb_company.Font = new System.Drawing.Font("微软雅黑", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_company.Location = new System.Drawing.Point(307, 694);
            this.lb_company.Name = "lb_company";
            this.lb_company.Size = new System.Drawing.Size(0, 32);
            this.lb_company.TabIndex = 9;
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.BackColor = System.Drawing.Color.Transparent;
            this.lb_name.Font = new System.Drawing.Font("微软雅黑", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_name.Location = new System.Drawing.Point(124, 694);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(0, 32);
            this.lb_name.TabIndex = 8;
            // 
            // lb_tip
            // 
            this.lb_tip.AutoSize = true;
            this.lb_tip.BackColor = System.Drawing.Color.Transparent;
            this.lb_tip.Font = new System.Drawing.Font("微软雅黑", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_tip.ForeColor = System.Drawing.Color.Black;
            this.lb_tip.Location = new System.Drawing.Point(199, 73);
            this.lb_tip.Name = "lb_tip";
            this.lb_tip.Size = new System.Drawing.Size(495, 60);
            this.lb_tip.TabIndex = 11;
            this.lb_tip.Text = "微笑打卡，不然打不上";
            // 
            // lb_num
            // 
            this.lb_num.AutoSize = true;
            this.lb_num.BackColor = System.Drawing.Color.Transparent;
            this.lb_num.Font = new System.Drawing.Font("微软雅黑", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_num.Location = new System.Drawing.Point(764, 306);
            this.lb_num.Name = "lb_num";
            this.lb_num.Size = new System.Drawing.Size(92, 104);
            this.lb_num.TabIndex = 12;
            this.lb_num.Text = "4";
            this.lb_num.Visible = false;
            // 
            // imageBox_pic
            // 
            this.imageBox_pic.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox_pic.InitialImage = ((System.Drawing.Image)(resources.GetObject("imageBox_pic.InitialImage")));
            this.imageBox_pic.Location = new System.Drawing.Point(903, 166);
            this.imageBox_pic.Name = "imageBox_pic";
            this.imageBox_pic.Size = new System.Drawing.Size(300, 400);
            this.imageBox_pic.TabIndex = 2;
            this.imageBox_pic.TabStop = false;
            // 
            // pb_save
            // 
            this.pb_save.BackColor = System.Drawing.Color.Transparent;
            this.pb_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pb_save.Image = ((System.Drawing.Image)(resources.GetObject("pb_save.Image")));
            this.pb_save.Location = new System.Drawing.Point(1103, 662);
            this.pb_save.Name = "pb_save";
            this.pb_save.Size = new System.Drawing.Size(144, 72);
            this.pb_save.TabIndex = 14;
            this.pb_save.TabStop = false;
            this.pb_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(944, 574);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 73);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btn_restart_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(158, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(126, 66);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pb_mengban
            // 
            this.pb_mengban.BackColor = System.Drawing.Color.Transparent;
            this.pb_mengban.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pb_mengban.Image = ((System.Drawing.Image)(resources.GetObject("pb_mengban.Image")));
            this.pb_mengban.Location = new System.Drawing.Point(73, 166);
            this.pb_mengban.Name = "pb_mengban";
            this.pb_mengban.Size = new System.Drawing.Size(640, 480);
            this.pb_mengban.TabIndex = 17;
            this.pb_mengban.TabStop = false;
            this.pb_mengban.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1259, 768);
            this.Controls.Add(this.pb_mengban);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pb_save);
            this.Controls.Add(this.imageBox_pic);
            this.Controls.Add(this.lb_num);
            this.Controls.Add(this.lb_tip);
            this.Controls.Add(this.lb_depart);
            this.Controls.Add(this.lb_company);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_tel);
            this.Controls.Add(this.imageBox_cap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "签到-豆包酷讯";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_cap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_mengban)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox_cap;
        private System.Windows.Forms.TextBox tb_tel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_depart;
        private System.Windows.Forms.Label lb_company;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Label lb_tip;
        private System.Windows.Forms.Label lb_num;
        private Emgu.CV.UI.ImageBox imageBox_pic;
        private System.Windows.Forms.PictureBox pb_save;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pb_mengban;
    }
}

