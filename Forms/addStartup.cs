using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;


namespace WinCleaner
{
    public partial class addStartup : Form
    {

        private bool dragging = false;
        private Point CursorPoint, FormPoint;






        private void CreateShortcut(string Path, string Name, string targetFileLocation, string argMents)
        {
            WshShell shell = new WshShell();
            IWshShortcut shortcut = shell.CreateShortcut(Path + "\\" + Name + ".lnk") as IWshShortcut;

            shortcut.Arguments = argMents;
            shortcut.TargetPath = targetFileLocation;
            // not sure about what this is for
            shortcut.WindowStyle = 1;
            shortcut.Description = "WCleaner에 의해 생성된 바로가기";
            shortcut.WorkingDirectory = Path;
            shortcut.IconLocation = targetFileLocation;
            shortcut.Save();
        }









        public addStartup()
        {
            InitializeComponent();
            (new Core.DropShadow()).ApplyShadows(this);
            //re-focus 되어도 사라지지 않는 그림자 생성, 대신 둥근 표면은 불가
        }




        // 취소 시 폼 닫기
        private void closeApp_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void exitForm_MouseClick(object sender, MouseEventArgs e)
        { // 폼 종료
            this.Close();
        }



        ///                                               ///
        /// 상단 패널, 라벨 마우스로 움직이면 폼 움직이기 ///
        ///                                               ///

        private void FrmName_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            CursorPoint = Cursor.Position;
            FormPoint = this.Location;
        }

        private void FrmName_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(CursorPoint));
                this.Location = Point.Add(FormPoint, new Size(diff));
            }
        }

        private void FrmName_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            CursorPoint = Cursor.Position;
            FormPoint = this.Location;
        }

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(CursorPoint));
                this.Location = Point.Add(FormPoint, new Size(diff));
            }
        }

        private void topPanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }




        //파일 찾기
        private void browseFile_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Title = "시작프로그램에 등록할 파일 선택";
            openFileDialog.ShowDialog();

            filePath.Text = openFileDialog.FileName;
        }

        private void addApp_Click(object sender, EventArgs e)
        {
            bool canCreate = true;

            if (!System.IO.File.Exists(filePath.Text))
            { //존재하지 않는 파일 입력 시 취소
                fileLB.ForeColor = Color.FromArgb(255, 50, 50);
                fileLB.Text = "존재하지 않는 파일입니다.";
                canCreate = false;
            } else  {
                fileLB.ForeColor = Color.FromArgb(0, 150, 0);
                fileLB.Text = "이대로 진행하셔도 좋습니다!";
            }


            if (name.Text.Contains("\\") || name.Text.Contains("/") || name.Text.Contains(":") || name.Text.Contains("*") || name.Text.Contains("?") || name.Text.Contains("\"") || name.Text.Contains("<") || name.Text.Contains(">") || name.Text.Contains("|"))
            { //윈도우에서 파일,폴더 이름에 금하는 특수문자 사용 시 취소
                nameLB.ForeColor = Color.FromArgb(255, 50, 50);
                nameLB.Text = "\\ / : * ? \" < > |  의 특수문자를 사용할 수 없습니다.";
                canCreate = false;
            }

            else if (name.Text.Length == 0)
            { //이름 미입력 시 취소
                nameLB.ForeColor = Color.FromArgb(255, 50, 50);
                nameLB.Text = "꼭 입력하셔야 합니다.";
                canCreate = false;
            }
            else
            {
                nameLB.ForeColor = Color.FromArgb(0, 150, 0);
                nameLB.Text = "이대로 진행하셔도 좋습니다!";
            }


            if (type.Text.Length == 0)
            { //유형 미선택 시 취소
                typeLB.ForeColor = Color.FromArgb(255, 50, 50);
                typeLB.Text = "꼭 선택해야 합니다.";
                canCreate = false;
            } else {
                typeLB.ForeColor = Color.FromArgb(0, 150, 0);
                typeLB.Text = "이대로 진행하셔도 좋습니다!";
            }

            if (argLB.Text == "생성되었습니다!")
            {
                argLB.ForeColor = Color.FromArgb(0, 150, 0);
                argLB.Text = "이대로 진행하셔도 좋습니다!";
            }

            if (!canCreate) { return; }
            //조건에 부합하지 않으면 취소



            //시작프로그램 추가 진행
            switch (type.Text)
            {
                case "레지스트리 - 모든 사용자":
                    if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Run", name.Text, null) != null)
                    {
                        nameLB.ForeColor = Color.FromArgb(255, 50, 50);
                        nameLB.Text = "이미 존재하는 이름입니다.";
                        return;
                    }
                    Registry.SetValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Run", name.Text, "\"" + filePath.Text + "\" " + arguments.Text);
                    break;


                case "레지스트리 - 현재 사용자":
                    if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", name.Text, null) != null)
                    {
                        nameLB.ForeColor = Color.FromArgb(255, 50, 50);
                        nameLB.Text = "이미 존재하는 이름입니다.";
                        return;
                    }
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", name.Text, "\"" + filePath.Text + "\" " + arguments.Text);
                    break;


                case "(1회성)레지스트리 - 모든 사용자":
                    if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\RunOnce", name.Text, null) != null)
                    {
                        nameLB.ForeColor = Color.FromArgb(255, 50, 50);
                        nameLB.Text = "이미 존재하는 이름입니다.";
                        return;
                    }
                    Registry.SetValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\RunOnce", name.Text, "\"" + filePath.Text + "\" " + arguments.Text);
                    break;


                case "(1회성)레지스트리 - 현재 사용자":
                    if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\RunOnce", name.Text, null) != null)
                    {
                        nameLB.ForeColor = Color.FromArgb(255, 50, 50);
                        nameLB.Text = "이미 존재하는 이름입니다.";
                        return;
                    }
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\RunOnce", name.Text, "\"" + filePath.Text + "\" " + arguments.Text);
                    break;


                case "(32비트)레지스트리 - 모든 사용자":
                    if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Run", name.Text, null) != null)
                    {
                        nameLB.ForeColor = Color.FromArgb(255, 50, 50);
                        nameLB.Text = "이미 존재하는 이름입니다.";
                        return;
                    }
                    Registry.SetValue(@"HKEY_LOCAL_MACHINE\Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Run", name.Text, "\"" + filePath.Text + "\" " + arguments.Text);
                    break;




                case "폴더 - 모든 사용자":
                    if (System.IO.File.Exists(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup\" + name.Text + ".lnk"))
                    {
                        nameLB.ForeColor = Color.FromArgb(255, 50, 50);
                        nameLB.Text = "이미 존재하는 이름입니다.";
                        return;
                    }
                    CreateShortcut(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup", name.Text, "\"" + filePath.Text + "\"", arguments.Text);
                    break;


                case "폴더 - 현재 사용자":
                    if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Start Menu\Programs\Startup\" + name.Text + ".lnk"))
                    {  
                        nameLB.ForeColor = Color.FromArgb(255, 50, 50);
                        nameLB.Text = "이미 존재하는 이름입니다.";
                        return;
                    }
                    CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Start Menu\Programs\Startup", name.Text, "\"" + filePath.Text + "\"", arguments.Text);
                    break;
            }

            typeLB.ForeColor = Color.FromArgb(0, 150, 0);
            nameLB.ForeColor = Color.FromArgb(0, 150, 0);
            fileLB.ForeColor = Color.FromArgb(0, 150, 0);
            argLB.ForeColor = Color.FromArgb(0, 150, 0);

            typeLB.Text = "생성되었습니다!";
            nameLB.Text = "생성되었습니다!";
            fileLB.Text = "생성되었습니다!";
            argLB.Text = "생성되었습니다!";
        }




        //유형 키입력 방지
        private void type_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
