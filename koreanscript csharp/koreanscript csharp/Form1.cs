using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
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

        private async void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText("변수.json","{\n\n}"); //변수초기화
            File.WriteAllText("err.log", "");
            string output = null;
            string 입력 = richTextBox1.Text;
            string[] 한줄 = 입력.Split('\n');
            string[] 띄어쓰기 = null;
            int 계수기와1 = 0;
            for (int 계수기 = 0; 계수기 < 한줄.Length;계수기++)
            {
                띄어쓰기 = 한줄[계수기].Split(' ');
                계수기와1 = 계수기 + 1;
                if (띄어쓰기[0] == "정수변수" || 띄어쓰기[0] == "문자변수" || 띄어쓰기[0] == "실수변수")
                {
                    await 변수쓰기(한줄[계수기],띄어쓰기,계수기와1);
                }
                else if (띄어쓰기[0] == "말하기")
                {
                    output += 띄어쓰기[1];
                    for (int a = 2; a <= 띄어쓰기.Length - 1; a++)
                    {
                        output = output + " " + 띄어쓰기[a];
                    }
                }
            }
            if (File.ReadAllText("err.log") != "")
            {
                richTextBox2.Text = File.ReadAllText("err.log");
                goto final;
            }
            else
            {
                richTextBox2.Text = output;
            }

        final:;
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
                int outint;
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
                if (type == "int")
                {
                    if (int.TryParse(띄어쓰기[2], out outint))
                    {
                        JObject writeint = new JObject();
                        writeint.Add("value", 띄어쓰기[2]);
                        writeint.Add("type", type);
                        json.Add(띄어쓰기[1], writeint);
                        File.WriteAllText("변수.json", json.ToString());

                    }
                    else
                    {
                        File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 정수변수 안에 실수 혹은 문자를 넣을 수 없습니다.\n");
                    }
                }
                else if (type == "string")
                {
                    string 쓸값 = "";
                    string[] 값부분 = new string[띄어쓰기.Length - 2];
                    Array.Copy(띄어쓰기, 2, 값부분, 0, 띄어쓰기.Length - 2);

                    if (값부분[0].Contains("\""))
                    {
                        if (값부분[값부분.Length - 1].Contains("\""))
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

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            saveFileDialog1.Filter = "한글스크립트 파일|*.kost|메모장 파일|*.txt";
            saveFileDialog1.Title = "소스코드 저장";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                File.WriteAllText(saveFileDialog1.FileName,richTextBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
    }
}
