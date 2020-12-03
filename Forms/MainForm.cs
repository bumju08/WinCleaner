//
//
//  Github: https://github.com/bumju08/WinCleaner
//  Developed by debugprov@naver.com
//
//




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
using System.Threading;


namespace WinCleaner
{
    public partial class MainForm : Form
    {
        // API
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn (int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);


        // 공용 변수
        private bool dragging = false;
        private Point CursorPoint, FormPoint;

        addStartup asForm;

        private string processName;
        private readonly string[] memExcept = new string[]{"csrss", "dasHost", "dllHost", "dwm", "explorer", "fontdrvhost", "audiodg", "lsass", "MsMpEng", "NisSrv", "Registry", "ntoskrnl", "RuntimeBroker", "SecurityHealthService", "services", "SgrmBroker", "sihost", "svchost", "smss", "spoolsv", "System", "taskhostw", "winlogon", "wininit", "Taskmgr", "Idle" };
        private readonly string appVersion = "0.02";






        private static string GetShortcutTargetFile(string shortcutFilename)
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


        private void SearchStartupReg(byte rootType, string regPath, string PathStart, string startupType)
        {
            try
            {
                //시작프로그램 - 레지스트리 열거 함수
                //
                // 첫째 인자:  0-> HKEY_LOCAL_MACHINE       1->HKEY_CURRENT_USER
                // 둘째 인자:  첫폴더를 제외한 나머지 경로 HKEY_어쩌구\ 를 제외
                // 셋째 인자: HKEY_LOCAL_MACHINE 혹은 HKEY_CURRENT_USER 입력. 리스트에 표시할 경로
                // 넷째 인자: 리스트에 표시할 유형.
                string Path = regPath, arguments, tempArg, icoPath;
                RegistryKey rootKey = null;

                if (rootType == 0) { rootKey = Registry.LocalMachine.OpenSubKey(Path); }
                else if (rootType == 1) { rootKey = Registry.CurrentUser.OpenSubKey(Path); }

                foreach (string keyName in rootKey.GetValueNames())
                {
                    arguments = (string)rootKey.GetValue(keyName, null);

                    // 레지스트리 값 (파일경로 /명령어) 부분에서 파일경로만 가져오기
                    tempArg = arguments; icoPath = null;
                    tempArg = tempArg.Replace("\"", null); // " 제거 후 파일 존재하는지 확인

                    if (File.Exists(tempArg))
                    { icoPath = tempArg; } // 존재하면 그대로 사용하여 아이콘 추출

                    else //존재하지 않으면
                    {
                        string[] splitBySpace = tempArg.Split(' '); //공백으로 분할

                        for (int i1 = 0; i1 < splitBySpace.Length; i1++)
                        {
                            icoPath += splitBySpace[i1]; //분할한 것을 하나씩 이어붙이고

                            if (File.Exists(icoPath)) { break; } //존재하는 파일인지 확인하여 존재하면 탈출
                        }
                    }
                    if (!File.Exists(icoPath))
                    { //파일경로 가져왔는데 없는 파일이면 기본아이콘 표시
                        Icon icon2 = new Icon(SystemIcons.Application, 16, 16);
                        imgList.Images.Add(icon2);
                    }
                    else
                    { //있으면 아이콘 추출
                        Icon icon = Icon.ExtractAssociatedIcon(icoPath);
                        imgList.Images.Add(icon);
                    }

                    startList.Items.Add(new ListViewItem(new string[] { keyName, arguments, PathStart + "\\" + Path, startupType }, imgList.Images.Count - 1));
                }
            } catch (NullReferenceException e1) { }
        }


        private void SearchStartupFolder(string FolderPath, string startupType)
        {
            string Path = FolderPath, arguments;
            DirectoryInfo di = new DirectoryInfo(Path);

            foreach (var item in di.GetFiles())
            {
                if (item.Name != "desktop.ini")
                {
                    Icon icon = Icon.ExtractAssociatedIcon(item.FullName);
                    imgList.Images.Add(icon);

                    if (item.Extension == ".lnk") { arguments = GetShortcutTargetFile(Path + "\\" + item.Name); }
                    else { arguments = item.FullName; }
                    startList.Items.Add(new ListViewItem(new string[] { item.Name, arguments, Path, startupType }, imgList.Images.Count - 1));
                }
            }
        }



        private string[] cleanMemory(bool killAll)
        {
            bool ifsigProcess;
            ushort procCount = 0;

            Process[] processCollection = Process.GetProcesses();
            string[] procList = new string[processCollection.Length];
            // 함수가 반환할 값을 임시로 모아 저장해둘 변수

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

                    for (int i2 = 0; i2 < eFile.Length; i2++)
                    {
                        //예외처리 확인
                        if (eFile[i2].Length > 0 && eFile[i2].Substring(0, 1) != "#" && eFile[i2].ToLower() == p.ProcessName.ToLower())
                        {
                            ifsigProcess = true;
                        }
                    }
                }

                // 세가지 유형에 포함되지 않는 프로세스는 종료
                if (ifsigProcess == false)
                {
                    if (killAll)
                    { // 첫째 인자 true일 경우 프로세스 종료(메모리 정리)
                        try
                        {
                            p.Kill();
                        }
                        catch (Exception e1) { }
                    }

                    else 
                    { // 첫째 인자 false일 경우 프로세스 이름값 저장
                        procList[procCount] = p.ProcessName;
                        procCount++;
                    }

                }
            }

            if (killAll) { return null; } //메모리 정리가 목표이면 null 반환
            else { return procList; } //예외처리할 프로세스 목록 가져오기가 목표이면 배열 반환
        }







        public MainForm()
        {
            InitializeComponent();
            
            //표면 둥글게
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 5, 5));

           
        }

           protected override CreateParams CreateParams
            { //그림자 생성
                get
                {
                    CreateParams crp = base.CreateParams;
                    crp.ClassStyle = 0x00020000;
                    return crp;
                }
            }
     


        private void MainForm_Load(object sender, EventArgs e)
        {

            //중복실행 시 종료
            Process[] proc1 = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName.ToUpper());
            if (proc1.Length > 1)
            {Environment.Exit(0); }
            
            processName = Path.GetFileNameWithoutExtension(Application.ExecutablePath);

            //프로그램 락
            File.Open(Application.ExecutablePath, FileMode.Open, FileAccess.Read, FileShare.Read);


            //메모리 탭 선택
            memPanel.Location = new Point(224, 41);
            startupPanel.Location = new Point(224, 41);
            memPanel.BringToFront();


            //시작프로그램 열거
            refreshStartApp_Click(new object(), new EventArgs());



            //표시
            this.Text = "WinCleaner " + appVersion;
            FrmName.Text = "WinCleaner " + appVersion;

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
            cleanMemory(true);

            MessageBox.Show("윈도우 기본 프로세스, 사용자가 예외처리한 프로세스만 남기고 모두 종료했습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 예외항목 설정
        private void openmExcept_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Application.StartupPath + "\\mcExcept.ini"))
            {
                if (MessageBox.Show("예외항목 파일이 존재하지 않습니다. 새로 생성하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.WriteAllText(Application.StartupPath + "\\mcExcept.ini", "# 예외처리할 항목을 한 줄에 하나씩 써주세요.\r\n# 확장자를 제외하고 이름만 써주셔야 합니다.\r\n# KakaoTalk.exe의 경우 KakaoTalk만 입력하세요.\r\n# 대소문자를 구별하지 않으셔도 됩니다. (KakaoTalk이나 kakaotalk이나 동일)\r\n# 가장 앞에 #을 붙인 줄은 주석처리 되어 무시됩니다.\r\n\r\n# -------------------\r\n# ---이 밑에 입력---\r\n# -------------------\r\n\r\n\r\n", Encoding.Default);
                }
                else { return; }
            }

            Process.Start("notepad.exe", Application.StartupPath + "\\mcExcept.ini");
        }


        //현재 켜진 모든 프로세스 예외항목으로 처리
        private void exceptAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("기존 예외항목 파일(mcExcept.ini)이 초기화됩니다.\r\n진행 하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            { return; }

            //기존 파일 존재하면 삭제
            if (File.Exists(Application.StartupPath + "\\mcExcept.ini")) { File.Delete(Application.StartupPath + "\\mcExcept.ini"); }

            //예외처리할 모든 프로세스 반환
            string[] procLists = cleanMemory(false);

            //만약 예외처리할 프로세스가 없다면 종료
            if (procLists[0] == null) { MessageBox.Show("예외처리할 프로세스가 1개도 구동되고 있지 않습니다.", "처리 불가", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            StringBuilder ftWriter = new StringBuilder(null);
            ftWriter.Append("# 예외처리할 항목을 한 줄에 하나씩 써주세요.\r\n# 확장자를 제외하고 이름만 써주셔야 합니다.\r\n# KakaoTalk.exe의 경우 KakaoTalk만 입력하세요.\r\n# 대소문자를 구별하지 않으셔도 됩니다. (KakaoTalk이나 kakaotalk이나 동일)\r\n# 가장 앞에 #을 붙인 줄은 주석처리 되어 무시됩니다.\r\n\r\n# -------------------\r\n# ---이 밑에 입력---\r\n# -------------------\r\n\r\n\r\n");
            //null값의 StringBuilder 클래스 변수에 기본 양식 작성

            for (int i1=0; i1<procLists.Length; i1++)
            {
                bool ifNested = false;
                for (int i2=0; i2<i1; i2++)
                {
                    if (procLists[i2] == procLists[i1]) { ifNested = true; break; }
                } //만약 여태까지 작성한 프로세스 중 중복되는 것이 있다면 다음 항목으로 스킵

                if (!ifNested) { ftWriter.Append(procLists[i1] + "\r\n"); }
            }
            //예외처리할 프로세스 한 줄에 하나씩 작성

            File.WriteAllText(Application.StartupPath + "\\mcExcept.ini", ftWriter.ToString(), Encoding.Default);

            if (MessageBox.Show("작업이 완료되었습니다. 예외항목 파일을 열어보시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { Process.Start("notepad.exe", Application.StartupPath + "\\mcExcept.ini"); }

        }





        //시작프로그램 목록 클릭
        private void startList_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i1=0; i1<startList.Items.Count; i1++)
            {
                if (startList.Items[i1].Selected) { startList.Items[i1].Checked = !startList.Items[i1].Checked; }
            }
        }






        //시작프로그램 키보드 입력
        private void startList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    refreshStartApp_Click(new object(), new EventArgs());
                    break;

                case Keys.Insert:
                    insertStartApp_Click(new object(), new EventArgs());
                    break;

                case Keys.Delete:
                    delstartApp_Click(new object(), new EventArgs());
                    break;


                default:
                    break;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (side2.BackColor == Color.FromArgb(255,40,40))
            { //시작프로그램 탭이면

                switch (e.KeyCode)
                {
                    case Keys.F5:
                        refreshStartApp_Click(new object(), new EventArgs());
                        break;

                    case Keys.Insert:
                        insertStartApp_Click(new object(), new EventArgs());
                        break;

                    case Keys.Delete:
                        delstartApp_Click(new object(), new EventArgs());
                        break;


                    default:
                        break;
                }
            }
        }

        private void menuStartup_KeyDown(object sender, KeyEventArgs e)
        {
            if (side2.BackColor == Color.FromArgb(255, 40, 40))
            { //시작프로그램 탭이면

                switch (e.KeyCode)
                {
                    case Keys.F5:
                        refreshStartApp_Click(new object(), new EventArgs());
                        break;

                    case Keys.Insert:
                        insertStartApp_Click(new object(), new EventArgs());
                        break;

                    case Keys.Delete:
                        delstartApp_Click(new object(), new EventArgs());
                        break;


                    default:
                        break;
                }
            }
        }



        //시작프로그램 삭제
        private void delstartApp_Click(object sender, EventArgs e)
        {
            if (startList.CheckedItems.Count > 0) //하나라도 선택해야 발동
            {
                for (int i1 = 0; i1 < startList.Items.Count; i1++) //처음부터 끝까지 선택여부 확인 반복
                {
                    if (startList.Items[i1].Checked) //만약 선택했다면
                    {
                        RegistryKey rootKey;
                        switch (startList.Items[i1].SubItems[3].Text)
                        {
                            case "레지스트리 - 모든 사용자":
                                try
                                {
                                    rootKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                                    rootKey.DeleteValue(startList.Items[i1].Text, false);
                                }
                                catch (Exception e1) { }
                                break;

                            case "레지스트리 - 현재 사용자":
                                try
                                {
                                    rootKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                                    rootKey.DeleteValue(startList.Items[i1].Text, false);
                                }
                                catch (Exception e1) { }
                                break;

                            case "(1회성)레지스트리 - 모든 사용자":
                                try
                                {
                                    rootKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\RunOnce", true);
                                    rootKey.DeleteValue(startList.Items[i1].Text, false);
                                }
                                catch (Exception e1) { }
                                break;

                            case "(1회성)레지스트리 - 현재 사용자":
                                try
                                {
                                    rootKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\RunOnce", true);
                                    rootKey.DeleteValue(startList.Items[i1].Text, false);
                                }
                                catch (Exception e1) { }
                                break;

                            case "(32비트)레지스트리 - 모든 사용자":
                                try
                                {
                                    rootKey = Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Run", true);
                                    rootKey.DeleteValue(startList.Items[i1].Text, false);
                                }
                                catch (Exception e1) { }
                                break;

                            //폴더 처리
                            default:
                                try { File.Delete(startList.Items[i1].SubItems[2].Text + "\\" + startList.Items[i1].Text); } catch (Exception e1) { }
                                break;
                        }

                        startList.Items[i1].Remove(); i1--;
                    }
                }
            }
        }


        private void insertStartApp_Click(object sender, EventArgs e)
        {
            asForm = new addStartup();
            asForm.ShowDialog();
        }

        private void refreshStartApp_Click(object sender, EventArgs e)
        {
            startList.BeginUpdate();
            startList.Items.Clear();

            //시작프로그램 - 레지스트리 열거
            SearchStartupReg(0, @"Software\Microsoft\Windows\CurrentVersion\Run", "HKEY_LOCAL_MACHINE", "레지스트리 - 모든 사용자");
            SearchStartupReg(1, @"Software\Microsoft\Windows\CurrentVersion\Run", "HKEY_CURRENT_USER", "레지스트리 - 현재 사용자");
            SearchStartupReg(0, @"Software\Microsoft\Windows\CurrentVersion\RunOnce", "HKEY_LOCAL_MACHINE", "(1회성)레지스트리 - 모든 사용자");
            SearchStartupReg(1, @"Software\Microsoft\Windows\CurrentVersion\RunOnce", "HKEY_CURRENT_USER", "(1회성)레지스트리 - 현재 사용자");
            SearchStartupReg(0, @"Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Run", "HKEY_LOCAL_MACHINE", "(32비트)레지스트리 - 모든 사용자");

            

            //시작프로그램 - 폴더 열거
            SearchStartupFolder(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup", "폴더 - 전체 사용자");
            SearchStartupFolder(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Start Menu\Programs\Startup", "폴더 - 현재 사용자");


            //목록 넓이 조정
            startList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            startList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            startList.EndUpdate();
        }





    }
}
