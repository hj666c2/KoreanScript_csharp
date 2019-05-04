using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace koreanscript_csharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public async Task 변수쓰기(string 한줄, string[] 띄어쓰기, int 계수기)
        {
            try
            {
                string 변수읽기 = File.ReadAllText("변수.json");
                JObject 검사 = JObject.Parse(변수읽기);
                string 같은이름 = 검사[띄어쓰기[1]]["value"].ToString();
                File.WriteAllText("err.log", $"{File.ReadAllText("err.log")}{계수기}번째 줄, 이미 같은 이름의 변수가 존재합니다.");
            }
            catch
            {
                decimal outdecimal;
                string read = File.ReadAllText("변수.json");
                JObject json = JObject.Parse(read);
                string type = "";
                switch (띄어쓰기[0])
                {
                    case "정수변수":
                        type = "int";
                        break;
                    case "문자변수":
                        type = "string";
                        break;
                    case "실수변수":
                        type = "decimal";
                        break;
                }
                string 쓸값 = "";
                string[] 값부분 = new string[띄어쓰기.Length - 2];
                Array.Copy(띄어쓰기, 2, 값부분, 0, 띄어쓰기.Length - 2);
                int outint = 0;
                if (type == "int")
                {
                    if (int.TryParse(띄어쓰기[2], out outint))
                    {
                        try
                        {
                            int 테에스트 = int.Parse(띄어쓰기[2]);
                            JObject writeint = new JObject();
                            writeint.Add("value", 띄어쓰기[2]);
                            writeint.Add("type", type);
                            json.Add(띄어쓰기[1], writeint);
                            File.WriteAllText("변수.json", json.ToString());
                        }
                        catch
                        {
                            File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 정수변수의 범위는 –2,147,483,648 ~ 2,147,483,647입니다. (범위를 초과하였습니다)\n");
                        }

                    }
                    else
                    {
                        File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 정수변수 안에 실수 혹은 문자를 넣을 수 없습니다.\n");
                    }
                }
                else if (type == "string")
                {
                    if (값부분[0].IndexOf("\"") == 0)
                    {
                        if (값부분[값부분.Length - 1].LastIndexOf("\"") == 값부분[값부분.Length - 1].Length - 1)
                        {
                            값부분[0] = 값부분[0].Substring(1);
                            값부분[값부분.Length - 1] = 값부분[값부분.Length - 1].Substring(0, 값부분[값부분.Length - 1].Length - 1);
                            쓸값 = string.Join(" ", 값부분);
                            JObject writeint = new JObject();
                            writeint.Add("value", 쓸값);
                            writeint.Add("type", type);
                            json.Add(띄어쓰기[1], writeint);
                            File.WriteAllText("변수.json", json.ToString());
                        }
                        else
                        {
                            File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 문자변수는 시작과 끝에 \"가 있어야 합니다.\n");
                        }
                    }
                    else
                    {
                        File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 문자변수는 시작과 끝에 \"가 있어야 합니다.\n");
                    }
                }
                else if (type == "decimal")
                {
                    if (decimal.TryParse(띄어쓰기[2], out outdecimal))
                    {
                        JObject writeint = new JObject();
                        writeint.Add("value", 띄어쓰기[2]);
                        writeint.Add("type", type);
                        json.Add(띄어쓰기[1], writeint);
                        File.WriteAllText("변수.json", json.ToString());
                    }
                    else
                    {
                        File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 실수변수 안에 문자를 넣을 수 없습니다.\n");
                    }
                }
            }
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
                }
            }
            catch
            {

            }
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                SaveFileDialog save = new SaveFileDialog();
                saveFileDialog1.Filter = "한글스크립트 파일|*.kost|메모장 파일|*.txt";
                saveFileDialog1.Title = "소스코드 저장";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                }
            }
            catch { }
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

        private async void 시작ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "기다려 주세요...";
            if (richTextBox1.Text == "") { richTextBox2.Text = "명령어를 입력해 주세요."; }
            else
            {
                File.WriteAllText("변수.json", "{\n\n}"); //변수초기화
                File.WriteAllText("err.log", "");
                string 출력 = null;
                string 입력 = richTextBox1.Text;
                string[] 한줄 = 입력.Split('\n');
                string[] 띄어쓰기 = new string[] { };
                int 계수기와1 = 0;
                for (int 계수기 = 0; 계수기 < 한줄.Length; 계수기++)
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
                            await 변수쓰기(한줄[계수기], 띄어쓰기, 계수기와1);
                        }
                        else if (띄어쓰기[0] == "말하기")
                        {
                            string 변수읽기 = File.ReadAllText("변수.json");
                            JObject 변수들 = JObject.Parse(변수읽기);
                            try
                            {
                                string 변수 = 변수들[띄어쓰기[1]]["value"].ToString();
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
                            변수.값지정(띄어쓰기, 계수기와1);
                        }
                        else
                        {
                            File.WriteAllText("err.log", $"{File.ReadAllText("err.log")}{계수기와1}번째 줄, 해당하는 명령어가 존재하지 않습니다.\n");
                        }
                    }
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
    }
}
