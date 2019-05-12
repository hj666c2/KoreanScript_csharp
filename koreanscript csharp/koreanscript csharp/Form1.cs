using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace koreanscript_csharp
{
    public partial class Form1 : Form
    {
        public Hashtable 변수값 = new Hashtable();
        public Hashtable 변수형식 = new Hashtable();
        public int 계수기 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                openFileDialog1.Filter = "한글스크립트 파일|*.kost|메모장 파일|*.txt";
                openFileDialog1.Title = "소스코드 열기";
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != "")
                {
                    richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                    Text = "한글스크립트 " + openFileDialog1.FileName;
                }
            }
            catch
            {
                richTextBox1.Text = "해당 파일이 존재하지 않습니다.";
            }
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                if (Text != "한글스크립트")
                {
                    string filename = Text;
                    filename = filename.Substring(6);
                File.WriteAllText(filename, richTextBox1.Text);
                }
                else
                {
                    SaveFileDialog save = new SaveFileDialog();
                    saveFileDialog1.Filter = "한글스크립트 파일|*.kost|메모장 파일|*.txt";
                    saveFileDialog1.Title = "소스코드 저장";
                    saveFileDialog1.ShowDialog();
                    if (saveFileDialog1.FileName != "")
                    {
                        File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                        Text = "한글스크립트 " + saveFileDialog1.FileName;
                    }
                }
        }

        private void 도움말보기전체ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "한글스크립트 C#버전 사용법\n" +
                "주석 달기: //[내용] (예: //이것은 아무런 뜻 없는 주석)\n\n" +
                "변수 선언\n" +
                "  정수: 정수변수 [이름] [값] (예: 정수변수 정수 20)\n" +
                "  실수: 실수변수 [이름] [값] (예: 실수변수 실수 15.8)\n" +
                "  문자: 문자변수 [이름] \"[값]\" (예: 문자변수 문자 \"문자다\")\n\n" +
                "값지정: 값지정 [변수이름] [값]\n\n" +
                "말하기: 말하기 [변수이름] (예: 말하기 문자)\n";
        }

        private void 도움말보기변수ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "변수 도움말\n\n" +
                "변수 선언\n" +
                "정수변수: 정수로 된 변수들을 넣을 수 있습니다. –2,147,483,648 ~ 2,147,483,647까지 넣을 수 있습니다.\n (사용 예시: 정수변수 정수 20)" +
                "실수변수: 실수로 된 변수들을 넣을 수 있습니다. -79,228,162,514,264,337,593,543,950,335 ~ 79,228,16,514,264,337,593,543,950,335까지 넣을 수 있으며 소수점은 28자리까지 표현 가능합니다 (사용 예시: 실수변수 실수 20.245)\n" +
                "문자변수: 문자로 된 변수들을 넣을 수 있습니다 값을 지정할 때 시작과 끝에 \"을 넣어줘야 합니다. (사용 예시: 문자변수 문자 \"문자임\")\n\n" +
                "변수 값 지정\n" +
                "정수변수: 정수로 된 변수들의 값을 바꿉니다. (사용 예시: 값지정 정수 51)\n" +
                "실수변수: 실수로 된 변수들의 값을 바꿉니다. (사용 예시: 값지정 실수 500.5981)\n" +
                "문자변수: 문자로 된 변수들의 값을 바꿉니다. (사용 예시: 값지정 문자 \"문문자자\")";
        }

        private void 도움말보기단축키ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "단축키 도움말 \n\n" +
                "Ctrl + ?\n" +
                "O: 파일 열기\n" +
                "S: 파일 저장\n" +
                "B: 프로그램 시작\n" +
                "F: 프로그램 종료\n\n" +
                "Alt + ?\n" +
                "F: 파일\n" +
                "Q: 도움말\n" +
                "P: 프로그램";
        }

        private async void 시작ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "기다려 주세요...";
            변수값.Clear();
            변수형식.Clear();
            if (richTextBox1.Text == "") { richTextBox2.Text = "명령어를 입력해 주세요."; }
            else
            {
                File.WriteAllText("err.log", "");
                string 출력 = null;
                string 입력 = richTextBox1.Text;
                string[] 한줄 = 입력.Split('\n');
                string[] 띄어쓰기 = new string[] { };
                int 계수기와1 = 0;
                for (계수기 = 0; 계수기 <= 한줄.Length; 계수기++)
                {
                    try
                    {
                        띄어쓰기 = 한줄[계수기].Split(' ');
                        계수기와1 = 계수기 + 1;
                        if (한줄[계수기] == "")
                        {
                            File.WriteAllText("err.log", $"{File.ReadAllText("err.log")}{계수기와1}번째 줄, 명령어를 입력해 주세요.\n");
                        }
                        else
                        {

                            if (띄어쓰기[0].IndexOf(@"//") == 0)
                            {
                                continue;
                            }
                            else if (띄어쓰기[0] == "정수변수" || 띄어쓰기[0] == "문자변수" || 띄어쓰기[0] == "실수변수")
                            {
                                변수제어 변수제어 = new 변수제어();
                                await 변수제어.변수쓰기(한줄[계수기], 띄어쓰기, 계수기와1, 변수값, 변수형식);
                                변수값 = 변수제어.값;
                                변수형식 = 변수제어.형식;
                            }
                            else if (띄어쓰기[0] == "말하기")
                            {
                                try
                                {
                                    string 변수 = 변수값[띄어쓰기[1]].ToString();
                                    if (변수.Contains(@"\줄"))
                                    {
                                        string[] 줄나누기 = 변수.Split(new string[] { @"\줄" }, StringSplitOptions.None);
                                        변수 = string.Join("\n", 줄나누기);
                                    }
                                    출력 += 변수;
                                }
                                catch
                                {
                                    File.WriteAllText("err.log", $"{File.ReadAllText("err.log")}{계수기와1}번째 줄, 해당하는 변수가 존재하지 않습니다.\n");
                                }
                            }
                            else if (띄어쓰기[0] == "값지정")
                            {
                                변수제어 변수 = new 변수제어();
                                await 변수.값지정(한줄[계수기], 띄어쓰기, 계수기와1, 변수값, 변수형식);
                                변수값 = 변수.값;
                                변수형식 = 변수.형식;
                            }
                            else if (띄어쓰기[0] == "만약")
                            {
                                조건문 조건문 = new 조건문();
                                await 조건문.만약에(띄어쓰기, 계수기와1, 변수형식, 변수값);
                                계수기 = 조건문.바꾸는계수기;
                            }
                            else if (띄어쓰기[0] == "이동") { await Task.Delay(1); 계수기 = int.Parse(띄어쓰기[1]) - 2; }
                            else
                            {
                                File.WriteAllText("err.log", $"{File.ReadAllText("err.log")}{계수기와1}번째 줄, 해당하는 명령어가 존재하지 않습니다.\n");
                            }
                        }
                    }
                    catch
                    {
                      break;
                    }
                    richTextBox2.Text = $"{richTextBox2.Text}{계수기와1}번째줄 연산 완료 \n";
                }
                if (File.ReadAllText("err.log") != "")
                {
                    richTextBox2.Text = File.ReadAllText("err.log");
                }
                else
                {
                    richTextBox2.Text = 출력;
                }
            }
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            계수기 = 2147483647;
            richTextBox2.Text = "";
        }

        private void 프로그램재시작ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
