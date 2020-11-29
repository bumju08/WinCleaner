
namespace WinCleaner
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.topPanel = new System.Windows.Forms.Panel();
            this.FrmName = new System.Windows.Forms.Label();
            this.minApp = new System.Windows.Forms.Button();
            this.closeApp = new System.Windows.Forms.Button();
            this.menuRam = new System.Windows.Forms.Button();
            this.memPanel = new System.Windows.Forms.Panel();
            this.openmExcept = new System.Windows.Forms.Button();
            this.cleanMem = new System.Windows.Forms.Button();
            this.side1 = new System.Windows.Forms.Panel();
            this.goWeb = new System.Windows.Forms.Button();
            this.side2 = new System.Windows.Forms.Panel();
            this.menuStartup = new System.Windows.Forms.Button();
            this.startupPanel = new System.Windows.Forms.Panel();
            this.startList = new System.Windows.Forms.ListView();
            this.column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.delstartApp = new System.Windows.Forms.Button();
            this.topPanel.SuspendLayout();
            this.memPanel.SuspendLayout();
            this.startupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(200)))));
            this.topPanel.Controls.Add(this.FrmName);
            this.topPanel.Controls.Add(this.minApp);
            this.topPanel.Controls.Add(this.closeApp);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(728, 35);
            this.topPanel.TabIndex = 0;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseMove);
            this.topPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseUp);
            // 
            // FrmName
            // 
            this.FrmName.AutoSize = true;
            this.FrmName.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FrmName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FrmName.Location = new System.Drawing.Point(7, 10);
            this.FrmName.Name = "FrmName";
            this.FrmName.Size = new System.Drawing.Size(91, 15);
            this.FrmName.TabIndex = 1;
            this.FrmName.Text = "WinCleaner";
            this.FrmName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmName_MouseDown);
            this.FrmName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmName_MouseMove);
            this.FrmName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmName_MouseUp);
            // 
            // minApp
            // 
            this.minApp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.minApp.FlatAppearance.BorderSize = 0;
            this.minApp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(160)))), ((int)(((byte)(250)))));
            this.minApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.minApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minApp.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minApp.ForeColor = System.Drawing.Color.White;
            this.minApp.Image = ((System.Drawing.Image)(resources.GetObject("minApp.Image")));
            this.minApp.Location = new System.Drawing.Point(659, 2);
            this.minApp.Name = "minApp";
            this.minApp.Size = new System.Drawing.Size(30, 30);
            this.minApp.TabIndex = 6;
            this.minApp.UseVisualStyleBackColor = false;
            this.minApp.Click += new System.EventHandler(this.minApp_Click);
            // 
            // closeApp
            // 
            this.closeApp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.closeApp.FlatAppearance.BorderSize = 0;
            this.closeApp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(160)))), ((int)(((byte)(250)))));
            this.closeApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.closeApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeApp.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeApp.ForeColor = System.Drawing.Color.White;
            this.closeApp.Image = ((System.Drawing.Image)(resources.GetObject("closeApp.Image")));
            this.closeApp.Location = new System.Drawing.Point(695, 2);
            this.closeApp.Name = "closeApp";
            this.closeApp.Size = new System.Drawing.Size(30, 30);
            this.closeApp.TabIndex = 5;
            this.closeApp.UseVisualStyleBackColor = false;
            this.closeApp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.closeApp_MouseClick);
            // 
            // menuRam
            // 
            this.menuRam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(200)))));
            this.menuRam.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.menuRam.FlatAppearance.BorderSize = 0;
            this.menuRam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(160)))), ((int)(((byte)(250)))));
            this.menuRam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.menuRam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuRam.Font = new System.Drawing.Font("돋움체", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuRam.ForeColor = System.Drawing.Color.White;
            this.menuRam.Image = ((System.Drawing.Image)(resources.GetObject("menuRam.Image")));
            this.menuRam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuRam.Location = new System.Drawing.Point(10, 41);
            this.menuRam.Name = "menuRam";
            this.menuRam.Size = new System.Drawing.Size(205, 64);
            this.menuRam.TabIndex = 7;
            this.menuRam.Text = "메모리";
            this.menuRam.UseVisualStyleBackColor = false;
            this.menuRam.Click += new System.EventHandler(this.menuRam_Click);
            // 
            // memPanel
            // 
            this.memPanel.BackColor = System.Drawing.Color.White;
            this.memPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.memPanel.Controls.Add(this.openmExcept);
            this.memPanel.Controls.Add(this.cleanMem);
            this.memPanel.Location = new System.Drawing.Point(224, 41);
            this.memPanel.Name = "memPanel";
            this.memPanel.Size = new System.Drawing.Size(504, 371);
            this.memPanel.TabIndex = 8;
            // 
            // openmExcept
            // 
            this.openmExcept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(200)))));
            this.openmExcept.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.openmExcept.FlatAppearance.BorderSize = 0;
            this.openmExcept.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(160)))), ((int)(((byte)(250)))));
            this.openmExcept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.openmExcept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openmExcept.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.openmExcept.ForeColor = System.Drawing.Color.White;
            this.openmExcept.Image = ((System.Drawing.Image)(resources.GetObject("openmExcept.Image")));
            this.openmExcept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openmExcept.Location = new System.Drawing.Point(-1, 69);
            this.openmExcept.Name = "openmExcept";
            this.openmExcept.Size = new System.Drawing.Size(173, 60);
            this.openmExcept.TabIndex = 10;
            this.openmExcept.Text = "예외항목 설정";
            this.openmExcept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.openmExcept.UseVisualStyleBackColor = false;
            this.openmExcept.Click += new System.EventHandler(this.openmExcept_Click);
            // 
            // cleanMem
            // 
            this.cleanMem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(200)))));
            this.cleanMem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.cleanMem.FlatAppearance.BorderSize = 0;
            this.cleanMem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(160)))), ((int)(((byte)(250)))));
            this.cleanMem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.cleanMem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cleanMem.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cleanMem.ForeColor = System.Drawing.Color.White;
            this.cleanMem.Image = ((System.Drawing.Image)(resources.GetObject("cleanMem.Image")));
            this.cleanMem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cleanMem.Location = new System.Drawing.Point(-1, -1);
            this.cleanMem.Name = "cleanMem";
            this.cleanMem.Size = new System.Drawing.Size(504, 64);
            this.cleanMem.TabIndex = 9;
            this.cleanMem.Text = "청소!";
            this.cleanMem.UseVisualStyleBackColor = false;
            this.cleanMem.Click += new System.EventHandler(this.cleanMem_Click);
            // 
            // side1
            // 
            this.side1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.side1.Location = new System.Drawing.Point(0, 41);
            this.side1.Name = "side1";
            this.side1.Size = new System.Drawing.Size(10, 64);
            this.side1.TabIndex = 0;
            // 
            // goWeb
            // 
            this.goWeb.BackColor = System.Drawing.Color.White;
            this.goWeb.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.goWeb.FlatAppearance.BorderSize = 0;
            this.goWeb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.goWeb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.goWeb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goWeb.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.goWeb.ForeColor = System.Drawing.Color.Black;
            this.goWeb.Image = ((System.Drawing.Image)(resources.GetObject("goWeb.Image")));
            this.goWeb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.goWeb.Location = new System.Drawing.Point(221, 418);
            this.goWeb.Name = "goWeb";
            this.goWeb.Size = new System.Drawing.Size(504, 50);
            this.goWeb.TabIndex = 14;
            this.goWeb.Text = "제작자 블로그 이동";
            this.goWeb.UseVisualStyleBackColor = false;
            this.goWeb.Click += new System.EventHandler(this.goWeb_Click);
            // 
            // side2
            // 
            this.side2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(200)))));
            this.side2.Location = new System.Drawing.Point(0, 107);
            this.side2.Name = "side2";
            this.side2.Size = new System.Drawing.Size(10, 64);
            this.side2.TabIndex = 15;
            // 
            // menuStartup
            // 
            this.menuStartup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(200)))));
            this.menuStartup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.menuStartup.FlatAppearance.BorderSize = 0;
            this.menuStartup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(160)))), ((int)(((byte)(250)))));
            this.menuStartup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.menuStartup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuStartup.Font = new System.Drawing.Font("돋움체", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStartup.ForeColor = System.Drawing.Color.White;
            this.menuStartup.Image = ((System.Drawing.Image)(resources.GetObject("menuStartup.Image")));
            this.menuStartup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuStartup.Location = new System.Drawing.Point(10, 107);
            this.menuStartup.Name = "menuStartup";
            this.menuStartup.Size = new System.Drawing.Size(205, 64);
            this.menuStartup.TabIndex = 16;
            this.menuStartup.Text = "시작프로그램";
            this.menuStartup.UseVisualStyleBackColor = false;
            this.menuStartup.Click += new System.EventHandler(this.menuStartup_Click);
            // 
            // startupPanel
            // 
            this.startupPanel.BackColor = System.Drawing.Color.White;
            this.startupPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startupPanel.Controls.Add(this.startList);
            this.startupPanel.Controls.Add(this.delstartApp);
            this.startupPanel.Location = new System.Drawing.Point(201, 177);
            this.startupPanel.Name = "startupPanel";
            this.startupPanel.Size = new System.Drawing.Size(504, 371);
            this.startupPanel.TabIndex = 12;
            // 
            // startList
            // 
            this.startList.CheckBoxes = true;
            this.startList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column1,
            this.column2,
            this.column3,
            this.column4});
            this.startList.FullRowSelect = true;
            this.startList.Location = new System.Drawing.Point(-1, 34);
            this.startList.Name = "startList";
            this.startList.Size = new System.Drawing.Size(504, 336);
            this.startList.SmallImageList = this.imgList;
            this.startList.TabIndex = 10;
            this.startList.UseCompatibleStateImageBehavior = false;
            this.startList.View = System.Windows.Forms.View.Details;
            this.startList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.startList_MouseClick);
            // 
            // column1
            // 
            this.column1.Text = "이름";
            this.column1.Width = 150;
            // 
            // column2
            // 
            this.column2.Text = "실행 명령";
            this.column2.Width = 200;
            // 
            // column3
            // 
            this.column3.Text = "경로";
            this.column3.Width = 250;
            // 
            // column4
            // 
            this.column4.Text = "유형";
            // 
            // imgList
            // 
            this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgList.ImageSize = new System.Drawing.Size(17, 17);
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // delstartApp
            // 
            this.delstartApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(200)))));
            this.delstartApp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.delstartApp.FlatAppearance.BorderSize = 0;
            this.delstartApp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(160)))), ((int)(((byte)(250)))));
            this.delstartApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.delstartApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delstartApp.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.delstartApp.ForeColor = System.Drawing.Color.White;
            this.delstartApp.Image = ((System.Drawing.Image)(resources.GetObject("delstartApp.Image")));
            this.delstartApp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.delstartApp.Location = new System.Drawing.Point(-1, -1);
            this.delstartApp.Name = "delstartApp";
            this.delstartApp.Size = new System.Drawing.Size(504, 29);
            this.delstartApp.TabIndex = 9;
            this.delstartApp.Text = "선택 삭제";
            this.delstartApp.UseVisualStyleBackColor = false;
            this.delstartApp.Click += new System.EventHandler(this.delstartApp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(728, 475);
            this.Controls.Add(this.startupPanel);
            this.Controls.Add(this.side2);
            this.Controls.Add(this.menuStartup);
            this.Controls.Add(this.goWeb);
            this.Controls.Add(this.side1);
            this.Controls.Add(this.memPanel);
            this.Controls.Add(this.menuRam);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "WinCleaner";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.memPanel.ResumeLayout(false);
            this.startupPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button closeApp;
        private System.Windows.Forms.Button minApp;
        private System.Windows.Forms.Label FrmName;
        private System.Windows.Forms.Button menuRam;
        private System.Windows.Forms.Panel memPanel;
        private System.Windows.Forms.Panel side1;
        private System.Windows.Forms.Button cleanMem;
        private System.Windows.Forms.Button openmExcept;
        private System.Windows.Forms.Button goWeb;
        private System.Windows.Forms.Panel side2;
        private System.Windows.Forms.Button menuStartup;
        private System.Windows.Forms.Panel startupPanel;
        private System.Windows.Forms.Button delstartApp;
        private System.Windows.Forms.ListView startList;
        private System.Windows.Forms.ColumnHeader column1;
        private System.Windows.Forms.ColumnHeader column2;
        private System.Windows.Forms.ColumnHeader column3;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ColumnHeader column4;
    }
}

