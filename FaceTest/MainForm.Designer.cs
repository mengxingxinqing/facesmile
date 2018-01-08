namespace FaceTest
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
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.tb_tel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_depart = new System.Windows.Forms.Label();
            this.lb_company = new System.Windows.Forms.Label();
            this.lb_name = new System.Windows.Forms.Label();
            this.lb_tip = new System.Windows.Forms.Label();
            this.lb_num = new System.Windows.Forms.Label();
            this.btn_restart = new System.Windows.Forms.Button();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox1.Location = new System.Drawing.Point(42, 107);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(640, 480);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("宋体", 19F);
            this.btn_save.Location = new System.Drawing.Point(1103, 638);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(132, 56);
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "签到";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tb_tel
            // 
            this.tb_tel.Font = new System.Drawing.Font("宋体", 29F);
            this.tb_tel.Location = new System.Drawing.Point(807, 638);
            this.tb_tel.Name = "tb_tel";
            this.tb_tel.Size = new System.Drawing.Size(290, 52);
            this.tb_tel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(37, 638);
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
            this.label2.Location = new System.Drawing.Point(228, 638);
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
            this.label3.Location = new System.Drawing.Point(465, 638);
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
            this.lb_depart.Location = new System.Drawing.Point(561, 638);
            this.lb_depart.Name = "lb_depart";
            this.lb_depart.Size = new System.Drawing.Size(98, 32);
            this.lb_depart.TabIndex = 10;
            this.lb_depart.Text = "bumen";
            // 
            // lb_company
            // 
            this.lb_company.AutoSize = true;
            this.lb_company.BackColor = System.Drawing.Color.Transparent;
            this.lb_company.Font = new System.Drawing.Font("微软雅黑", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_company.Location = new System.Drawing.Point(337, 638);
            this.lb_company.Name = "lb_company";
            this.lb_company.Size = new System.Drawing.Size(97, 32);
            this.lb_company.TabIndex = 9;
            this.lb_company.Text = "gongsi";
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.BackColor = System.Drawing.Color.Transparent;
            this.lb_name.Font = new System.Drawing.Font("微软雅黑", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_name.Location = new System.Drawing.Point(133, 638);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(81, 32);
            this.lb_name.TabIndex = 8;
            this.lb_name.Text = "name";
            // 
            // lb_tip
            // 
            this.lb_tip.AutoSize = true;
            this.lb_tip.BackColor = System.Drawing.Color.Transparent;
            this.lb_tip.Font = new System.Drawing.Font("微软雅黑", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_tip.ForeColor = System.Drawing.Color.Black;
            this.lb_tip.Location = new System.Drawing.Point(117, 36);
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
            this.lb_num.Location = new System.Drawing.Point(748, 286);
            this.lb_num.Name = "lb_num";
            this.lb_num.Size = new System.Drawing.Size(92, 104);
            this.lb_num.TabIndex = 12;
            this.lb_num.Text = "3";
            // 
            // btn_restart
            // 
            this.btn_restart.Location = new System.Drawing.Point(1011, 548);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.Size = new System.Drawing.Size(75, 23);
            this.btn_restart.TabIndex = 13;
            this.btn_restart.Text = "重录";
            this.btn_restart.UseVisualStyleBackColor = true;
            this.btn_restart.Click += new System.EventHandler(this.btn_restart_Click);
            // 
            // imageBox2
            // 
            this.imageBox2.InitialImage = global::FaceTest.Properties.Resources.DefaultImg;
            this.imageBox2.Location = new System.Drawing.Point(892, 142);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(300, 400);
            this.imageBox2.TabIndex = 2;
            this.imageBox2.TabStop = false;
            // 
            // MainForm
            // 
            this.AcceptButton = this.btn_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1250, 707);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.btn_restart);
            this.Controls.Add(this.lb_num);
            this.Controls.Add(this.lb_tip);
            this.Controls.Add(this.lb_depart);
            this.Controls.Add(this.lb_company);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_tel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.imageBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "签到-豆包酷讯";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox tb_tel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_depart;
        private System.Windows.Forms.Label lb_company;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Label lb_tip;
        private System.Windows.Forms.Label lb_num;
        private System.Windows.Forms.Button btn_restart;
        private Emgu.CV.UI.ImageBox imageBox2;
    }
}

