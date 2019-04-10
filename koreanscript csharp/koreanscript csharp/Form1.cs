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
                    await writevar(띄어쓰기[0],띄어쓰기[1], 띄어쓰기[2],계수기와1, 띄어쓰기);
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
                richTextBox2.Text = "";
                richTextBox2.Text = output;
            }

        final:;
        }


        public async Task writevar(string type,string name, string value, int 계수기, string[] 띄어쓰기)
        {
            await Task.Delay(1);
            int outint;
            decimal outdecimal;
            string read = File.ReadAllText("변수.json");
            JObject json = JObject.Parse(read);
            switch (type)
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
                if (int.TryParse(value, out outint))
                {
                    JObject writeint = new JObject();
                    writeint.Add("value", value);
                    writeint.Add("type", type);
                    json.Add(name,writeint);
                    File.WriteAllText("변수.json",json.ToString());

                }
                else
                {
                    File.WriteAllText("err.log",File.ReadAllText("err.log") + "\n" + 계수기 + "번째 줄: 정수변수 안에 실수 혹은 문자를 넣을 수 없습니다.");
                }
            }
            else if (type == "string")
            {
                string vvalue = "";
                for(int a = 2;a < 띄어쓰기.Length ; a++)
                {
                    vvalue += " " + 띄어쓰기[a];
                }
                char[] split = vvalue.ToCharArray();
                split[0] = '\0';
                vvalue = new string(split);
                JObject writeint = new JObject();
                writeint.Add("value", vvalue);
                writeint.Add("type", type);
                json.Add(name, writeint);
                File.WriteAllText("변수.json", json.ToString());

            }
            else if (type == "decimal")
            {
                if (decimal.TryParse(value, out outdecimal))
                {
                    JObject writeint = new JObject();
                    writeint.Add("value", value);
                    writeint.Add("type", type);
                    json.Add(name, writeint);
                    File.WriteAllText("변수.json", json.ToString());
                }
                else
                {
                    File.WriteAllText("err.log", File.ReadAllText("err.log") + "\n" + 계수기 + "번째 줄: 실수변수 안에 문자를 넣을 수 없습니다.");
                }
            }
        }
    }
}
