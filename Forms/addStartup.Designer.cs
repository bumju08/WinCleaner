
namespace WinCleaner
{
    partial class addStartup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addStartup));
            this.topPanel = new System.Windows.Forms.Panel();
            this.FrmName = new System.Windows.Forms.Label();
            this.addApp = new System.Windows.Forms.Button();
            this.closeApp = new System.Windows.Forms.Button();
            this.lb1 = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.ComboBox();
            this.lb3 = new System.Windows.Forms.Label();
            this.filePath = new System.Windows.Forms.TextBox();
            this.browseFile = new System.Windows.Forms.Button();
            this.fileLB = new System.Windows.Forms.Label();
            this.arguments = new System.Windows.Forms.TextBox();
            this.lb4 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.lb2 = new System.Windows.Forms.Label();
            this.typeLB = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.nameLB = new System.Windows.Forms.Label();
            this.argLB = new System.Windows.Forms.Label();
            this.exitForm = new System.Windows.Forms.Button();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(200)))));
            this.topPanel.Controls.Add(this.exitForm);
            this.topPanel.Controls.Add(this.FrmName);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(402, 35);
            this.topPanel.TabIndex = 7;
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
            this.FrmName.Size = new System.Drawing.Size(195, 15);
            this.FrmName.TabIndex = 1;
            this.FrmName.Text = "새로운 시작프로그램 추가";
            this.FrmName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmName_MouseDown);
            this.FrmName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmName_MouseMove);
            this.FrmName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmName_MouseUp);
            // 
            // addApp
            // 
            this.addApp.BackColor = System.Drawing.Color.White;
            this.addApp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.addApp.FlatAppearance.BorderSize = 0;
            this.addApp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.addApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.addApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addApp.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addApp.ForeColor = System.Drawing.Color.Black;
            this.addApp.Image = ((System.Drawing.Image)(resources.GetObject("addApp.Image")));
            this.addApp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addApp.Location = new System.Drawing.Point(111, 298);
            this.addApp.Name = "addApp";
            this.addApp.Size = new System.Drawing.Size(78, 30);
            this.addApp.TabIndex = 9;
            this.addApp.Text = "추가";
            this.addApp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addApp.UseVisualStyleBackColor = false;
            this.addApp.Click += new System.EventHandler(this.addApp_Click);
            // 
            // closeApp
            // 
            this.closeApp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.closeApp.FlatAppearance.BorderSize = 0;
            this.closeApp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.closeApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.closeApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeApp.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeApp.ForeColor = System.Drawing.Color.Black;
            this.closeApp.Image = ((System.Drawing.Image)(resources.GetObject("closeApp.Image")));
            this.closeApp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeApp.Location = new System.Drawing.Point(214, 298);
            this.closeApp.Name = "closeApp";
            this.closeApp.Size = new System.Drawing.Size(78, 30);
            this.closeApp.TabIndex = 8;
            this.closeApp.Text = "종료";
            this.closeApp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeApp.UseVisualStyleBackColor = false;
            this.closeApp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.closeApp_MouseClick);
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb1.ForeColor = System.Drawing.Color.Black;
            this.lb1.Location = new System.Drawing.Point(12, 52);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(33, 12);
            this.lb1.TabIndex = 10;
            this.lb1.Text = "유형:";
            // 
            // type
            // 
            this.type.FormattingEnabled = true;
            this.type.Items.AddRange(new object[] {
            "레지스트리 - 모든 사용자",
            "레지스트리 - 현재 사용자",
            "(1회성)레지스트리 - 모든 사용자",
            "(1회성)레지스트리 - 현재 사용자",
            "(32비트)레지스트리 - 모든 사용자",
            "",
            "폴더 - 모든 사용자",
            "폴더 - 현재 사용자"});
            this.type.Location = new System.Drawing.Point(78, 49);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(237, 20);
            this.type.TabIndex = 11;
            this.type.Text = "레지스트리 - 모든 사용자";
            this.type.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.type_KeyPress);
            // 
            // lb3
            // 
            this.lb3.AutoSize = true;
            this.lb3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb3.ForeColor = System.Drawing.Color.Black;
            this.lb3.Location = new System.Drawing.Point(12, 176);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(33, 12);
            this.lb3.TabIndex = 12;
            this.lb3.Text = "파일:";
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(78, 173);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(237, 21);
            this.filePath.TabIndex = 13;
            // 
            // browseFile
            // 
            this.browseFile.BackColor = System.Drawing.Color.White;
            this.browseFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.browseFile.FlatAppearance.BorderSize = 0;
            this.browseFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.browseFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.browseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseFile.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseFile.ForeColor = System.Drawing.Color.Black;
            this.browseFile.Image = ((System.Drawing.Image)(resources.GetObject("browseFile.Image")));
            this.browseFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.browseFile.Location = new System.Drawing.Point(321, 167);
            this.browseFile.Name = "browseFile";
            this.browseFile.Size = new System.Drawing.Size(64, 30);
            this.browseFile.TabIndex = 14;
            this.browseFile.Text = "찾기";
            this.browseFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.browseFile.UseVisualStyleBackColor = false;
            this.browseFile.Click += new System.EventHandler(this.browseFile_Click);
            // 
            // fileLB
            // 
            this.fileLB.AutoSize = true;
            this.fileLB.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.fileLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.fileLB.Location = new System.Drawing.Point(76, 197);
            this.fileLB.Name = "fileLB";
            this.fileLB.Size = new System.Drawing.Size(113, 12);
            this.fileLB.TabIndex = 15;
            this.fileLB.Text = "꼭 입력해야 합니다.";
            // 
            // arguments
            // 
            this.arguments.Location = new System.Drawing.Point(78, 221);
            this.arguments.Name = "arguments";
            this.arguments.Size = new System.Drawing.Size(237, 21);
            this.arguments.TabIndex = 17;
            // 
            // lb4
            // 
            this.lb4.AutoSize = true;
            this.lb4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb4.ForeColor = System.Drawing.Color.Black;
            this.lb4.Location = new System.Drawing.Point(12, 224);
            this.lb4.Name = "lb4";
            this.lb4.Size = new System.Drawing.Size(45, 12);
            this.lb4.TabIndex = 16;
            this.lb4.Text = "명령어:";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(78, 126);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(237, 21);
            this.name.TabIndex = 20;
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb2.ForeColor = System.Drawing.Color.Black;
            this.lb2.Location = new System.Drawing.Point(12, 129);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(33, 12);
            this.lb2.TabIndex = 19;
            this.lb2.Text = "이름:";
            // 
            // typeLB
            // 
            this.typeLB.AutoSize = true;
            this.typeLB.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.typeLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.typeLB.Location = new System.Drawing.Point(76, 72);
            this.typeLB.Name = "typeLB";
            this.typeLB.Size = new System.Drawing.Size(161, 12);
            this.typeLB.TabIndex = 22;
            this.typeLB.Text = "이대로 진행하셔도 좋습니다!";
            // 
            // openFileDialog
            // 
            this.openFileDialog.InitialDirectory = "C:";
            // 
            // nameLB
            // 
            this.nameLB.AutoSize = true;
            this.nameLB.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nameLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.nameLB.Location = new System.Drawing.Point(76, 150);
            this.nameLB.Name = "nameLB";
            this.nameLB.Size = new System.Drawing.Size(113, 12);
            this.nameLB.TabIndex = 23;
            this.nameLB.Text = "꼭 입력해야 합니다.";
            // 
            // argLB
            // 
            this.argLB.AutoSize = true;
            this.argLB.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.argLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.argLB.Location = new System.Drawing.Point(76, 245);
            this.argLB.Name = "argLB";
            this.argLB.Size = new System.Drawing.Size(161, 12);
            this.argLB.TabIndex = 24;
            this.argLB.Text = "이대로 진행하셔도 좋습니다!";
            // 
            // exitForm
            // 
            this.exitForm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.exitForm.FlatAppearance.BorderSize = 0;
            this.exitForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(160)))), ((int)(((byte)(250)))));
            this.exitForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.exitForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitForm.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitForm.ForeColor = System.Drawing.Color.White;
            this.exitForm.Image = ((System.Drawing.Image)(resources.GetObject("exitForm.Image")));
            this.exitForm.Location = new System.Drawing.Point(369, 2);
            this.exitForm.Name = "exitForm";
            this.exitForm.Size = new System.Drawing.Size(30, 30);
            this.exitForm.TabIndex = 25;
            this.exitForm.UseVisualStyleBackColor = false;
            this.exitForm.MouseClick += new System.Windows.Forms.MouseEventHandler(this.exitForm_MouseClick);
            // 
            // addStartup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(402, 346);
            this.Controls.Add(this.argLB);
            this.Controls.Add(this.nameLB);
            this.Controls.Add(this.typeLB);
            this.Controls.Add(this.name);
            this.Controls.Add(this.lb2);
            this.Controls.Add(this.arguments);
            this.Controls.Add(this.lb4);
            this.Controls.Add(this.fileLB);
            this.Controls.Add(this.browseFile);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.lb3);
            this.Controls.Add(this.type);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.addApp);
            this.Controls.Add(this.closeApp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "addStartup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddStartup";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label FrmName;
        private System.Windows.Forms.Button addApp;
        private System.Windows.Forms.Button closeApp;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.Label lb3;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Button browseFile;
        private System.Windows.Forms.Label fileLB;
        private System.Windows.Forms.TextBox arguments;
        private System.Windows.Forms.Label lb4;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.Label typeLB;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label nameLB;
        private System.Windows.Forms.Label argLB;
        private System.Windows.Forms.Button exitForm;
    }
}