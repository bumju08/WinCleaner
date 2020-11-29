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
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Management;
using Shell32;
using System.Drawing.Imaging;
using Microsoft.Win32;



namespace WinCleaner
{
    public partial class MainForm : Form
    {
        // API
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn (int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);



        // 공용 변수
        private bool dragging = false;
        private Point CursorPoint, FormPoint;

        private string[] memExcept = new string[]{"csrss", "dasHost", "dllHost", "dwm", "explorer", "fontdrvhost", "audiodg", "lsass", "MsMpEng", "NisSrv", "Registry", "ntoskrnl", "RuntimeBroker", "SecurityHealthService", "services", "SgrmBroker", "sihost", "svchost", "smss", "spoolsv", "System", "taskhostw", "winlogon", "wininit", "Taskmgr" };
        private string processName;
        private string appVersion = "0.01";












        public static string GetShortcutTargetFile(string shortcutFilename)
        {
            string pathOnly = Path.GetDirectoryName(shortcutFilename);
            string filenameOnly = Path.GetFileName(shortcutFilename);

            Shell shell = new Shell();
            Folder folder = shell.NameSpace(pathOnly);
            FolderItem folderItem = folder.ParseName(filenameOnly);
            if (folderItem != null)
            {
                ShellLinkObject link = (ShellLinkObject)folderItem.GetLink;
                return link.Path;
            }

            return string.Empty;
        }


















        public MainForm()
        {
            InitializeComponent();

            //표면 둥글게
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 5, 5));
        }








        private void MainForm_Load(object sender, EventArgs e)
        {

            //중복실행 시 종료
            Process[] proc1 = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName.ToUpper());
            if (proc1.Length > 1)
            {Environment.Exit(0); }
            proc1 = null;

            processName = Application.ExecutablePath.Remove(0, Application.StartupPath.Length + 1);
            processName = processName.Remove(processName.Length - 4, 4);

            //프로그램 락
            FileStream lock1 = File.Open(Application.ExecutablePath, FileMode.Open, FileAccess.Read, FileShare.Read);


            //메모리 탭 선택
            memPanel.Location = new Point(224, 41);
            startupPanel.Location = new Point(224, 41);
            memPanel.BringToFront();



            //시작프로그램 - 레지스트리 열거
            StringBuilder tempArg = new StringBuilder(null), icoPath = new StringBuilder(null);
            string Path = @"Software\Microsoft\Windows\CurrentVersion\Run", arguments = null;
            RegistryKey rootKey = Registry.LocalMachine.OpenSubKey(Path);
            foreach (string keyName in rootKey.GetValueNames())
            {

                arguments = (string)rootKey.GetValue(keyName, null);

                if (arguments.Contains("\""))
                { // 레지스트리 값 ("파일경로" /명령어) 부분에서 파일경로만 가져오기 
                    tempArg.Clear(); icoPath.Clear();
                    tempArg.Append(arguments);
                    tempArg.Remove(0, 1);
                    icoPath.Append(tempArg.ToString().Substring(0, tempArg.ToString().IndexOf("\"")));
                }

                if (!File.Exists(icoPath.ToString()))
                { //파일경로 가져왔는데 없는 파일이면 기본아이콘 표시
                    Icon icon2 = new Icon(SystemIcons.Application, 16, 16);
                    imgList.Images.Add(icon2);
                }
                else
                { //있으면 아이콘 추출
                    Icon icon = Icon.ExtractAssociatedIcon(icoPath.ToString());
                    imgList.Images.Add(icon);
                }

                startList.Items.Add(new ListViewItem(new string[] { keyName, arguments, "HKEY_LOCAL_MACHINE\\" + Path, "Registry - All" }, imgList.Images.Count - 1));
            }


            Path = @"Software\Microsoft\Windows\CurrentVersion\Run";
            rootKey = Registry.CurrentUser.OpenSubKey(Path);
            foreach (string keyName in rootKey.GetValueNames())
            {

                arguments = (string)rootKey.GetValue(keyName, null);

                if (arguments.Contains("\""))
                { // 레지스트리 값 ("파일경로" /명령어) 부분에서 파일경로만 가져오기 
                    tempArg.Clear(); icoPath.Clear();
                    tempArg.Append(arguments);
                    tempArg.Remove(0, 1);
                    icoPath.Append(tempArg.ToString().Substring(0, tempArg.ToString().IndexOf("\"")));
                }

                if (!File.Exists(icoPath.ToString()))
                { //파일경로 가져왔는데 없는 파일이면 기본아이콘 표시
                    Icon icon2 = new Icon(SystemIcons.Application, 16, 16);
                    imgList.Images.Add(icon2);
                }
                else
                { //있으면 아이콘 추출
                    Icon icon = Icon.ExtractAssociatedIcon(icoPath.ToString());
                    imgList.Images.Add(icon);
                }

                startList.Items.Add(new ListViewItem(new string[] { keyName, arguments, "HKEY_CURRENT_USER\\" + Path, "Registry - User" }, imgList.Images.Count - 1));
            }



            //시작프로그램 - 폴더 열거
            Path = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup";
            DirectoryInfo di = new DirectoryInfo(Path);

            foreach (var item in di.GetFiles())
            {
                if (item.Name != "desktop.ini")
                {
                    Icon icon = Icon.ExtractAssociatedIcon(item.FullName);
                    imgList.Images.Add(icon);
                    
                    if (item.Extension == ".lnk") { arguments = GetShortcutTargetFile(Path + "\\" + item.Name); }
                    else { arguments = item.FullName; }
                    startList.Items.Add(new ListViewItem(new string[] { item.Name, arguments, Path, "Folder - All" }, imgList.Images.Count - 1));
                }
            }

            Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Start Menu\Programs\Startup";
            di = new DirectoryInfo(Path);
            foreach (var item in di.GetFiles())
            {
                if (item.Name != "desktop.ini") 
                {
                    Icon icon = Icon.ExtractAssociatedIcon(item.FullName);
                    imgList.Images.Add(icon);
                    //바로가기(.lnk) 파일은 대상파일+명령어 가져오기
                    if (item.Extension == ".lnk") { arguments = GetShortcutTargetFile(Path + "\\" + item.Name); }
                    else { arguments = item.FullName; }
                    startList.Items.Add(new ListViewItem(new string[] { item.Name, arguments, Path, "Folder - User" }, imgList.Images.Count - 1));
                }
            }


            //목록 넓이 조정
            startList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            startList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);



            //표시
            this.Text = "WinCleaner " + appVersion;
            FrmName.Text = "WinCleaner " + appVersion;

            menuRam.Focus();
            
        }



        


        ///                                              /// 
        /// 상단 패널,라벨 마우스로 움직이면 폼 움직이기 ///
        ///                                              ///
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
        { dragging = false; }

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
        { dragging = false; }








        ///                              ///
        /// 프로그램 최소화 및 종료 버튼 ///
        ///                              ///
        private void closeApp_MouseClick(object sender, MouseEventArgs e)
        { Environment.Exit(0);  }

        private void minApp_Click(object sender, EventArgs e)
        {  this.WindowState = FormWindowState.Minimized; }






        ///      ///
        /// 메뉴 ///
        ///      ///
        private void menuRam_Click(object sender, EventArgs e)
        {
            side1.BackColor = Color.FromArgb(255, 40, 40);
            side2.BackColor = Color.FromArgb(0, 110, 200);
            memPanel.BringToFront();
        }

        private void menuStartup_Click(object sender, EventArgs e)
        {
            side1.BackColor = Color.FromArgb(0, 110, 200);
            side2.BackColor = Color.FromArgb(255, 40, 40);
            startupPanel.BringToFront();
        }





        ///             ///
        /// 블로그 이동 ///
        ///             ///
        private void goWeb_Click(object sender, EventArgs e)
        {
            Process.Start("https://blog.naver.com/debugprov");
        }










        ///      ///
        /// 기능 ///
        ///      ///

        //메모리 정리
        private void cleanMem_Click(object sender, EventArgs e)
        {
            bool ifsigProcess = false;

            Process[] processCollection = Process.GetProcesses();
            foreach (Process p in processCollection)
            {
                ifsigProcess = false;

                // 윈도우 구동에 필요한 프로세스인지 확인
                for (int i1 = 0; i1 < memExcept.Length; i1++)
                {
                    if (memExcept[i1] == p.ProcessName) { ifsigProcess = true; break; }
                }

                // 나 자신인지 확인
                if (processName == p.ProcessName) { ifsigProcess = true; }

                // 사용자가 따로 예외처리한 프로세스인지 확인
                if (File.Exists(Application.StartupPath + "\\mcExcept.ini"))
                {
                    string[] eFile = File.ReadAllLines(Application.StartupPath + "\\mcExcept.ini", Encoding.Default);

                    for (int i2=0; i2 < eFile.Length; i2++)
                    {
                        //예외처리 확인
                        if (eFile[i2].Length > 0 && eFile[i2].Substring(0,1) != "#" && eFile[i2].ToLower() == p.ProcessName.ToLower())
                        {
                            ifsigProcess = true;
                        }
                    }
                }

                // 세가지 유형에 포함되지 않는 프로세스는 종료
                if (ifsigProcess == false)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch (Exception e1) { }
                }
            }

            processCollection = null;
        }



        //시작프로그램 목록 클릭
        private void startList_MouseClick(object sender, MouseEventArgs e)
        {
            if (startList.SelectedItems.Count > 0)
            {
                for (int i1=0; i1<startList.Items.Count; i1++)
                {
                    if (startList.Items[i1].Selected) { startList.Items[i1].Checked = !startList.Items[i1].Checked; }
                }
            }
        }

        //시작프로그램 삭제
        private void delstartApp_Click(object sender, EventArgs e)
        {
            if (startList.CheckedItems.Count > 0) //하나라도 선택해야 발동
            {
                for (int i1=0; i1<startList.Items.Count; i1++) //처음부터 끝까지 선택여부 확인 반복
                {
                    if (startList.Items[i1].Checked) //만약 선택했다면
                    {                     
                        RegistryKey rootKey = null;
                        switch (startList.Items[i1].SubItems[3].Text)
                        {
                            case "Registry - All":
                                rootKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                                rootKey.DeleteValue(startList.Items[i1].Text);
                                startList.Items[i1].Remove(); i1--;
                                break;

                            case "Registry - User":
                                rootKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                                rootKey.DeleteValue(startList.Items[i1].Text);
                                startList.Items[i1].Remove(); i1--;
                                break;

                            default:
                                try { File.Delete(startList.Items[i1].SubItems[2].Text + "\\" + startList.Items[i1].Text); } catch (Exception e1) { }
                                startList.Items[i1].Remove(); i1--;
                                break;
                        }
                    }
                }
            } 

            
        }






        // 예외항목 설정
        private void openmExcept_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Application.StartupPath + "\\mcExcept.ini"))
            {
                if (MessageBox.Show("예외항목 파일이 존재하지 않습니다. 새로 생성하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.WriteAllText(Application.StartupPath + "\\mcExcept.ini", "# 예외처리할 항목을 한 줄에 하나씩 써주세요.\r\n# 확장자를 제외하고 이름만 써주셔야 합니다.\r\n# test.exe의 경우 test만 입력하세요.\r\n# 대소문자를 구별하지 않으셔도 됩니다. (Test나 test나 동일)\r\n# 가장 앞에 #을 붙인 줄은 주석처리 되어 무시됩니다.\r\n\r\n# -------------------\r\n# ---이 밑에 입력---\r\n# -------------------\r\n\r\n\r\n", Encoding.Default);
                } else { return;  }
            }

    
                Process.Start("notepad.exe", Application.StartupPath + "\\mcExcept.ini");

        }







    }
}
