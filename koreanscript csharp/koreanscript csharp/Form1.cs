﻿using System;
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
                    json.Add(띄어쓰기[1],writeint);
                    File.WriteAllText("변수.json",json.ToString());

                }
                else
                {
                    File.WriteAllText("err.log",File.ReadAllText("err.log") + "\n" + 계수기 + "번째 줄: 정수변수 안에 실수 혹은 문자를 넣을 수 없습니다.");
                }
            }
            else if (type == "string")
            {
                string 쓸값 = "";
                string[] 값부분 = new string[띄어쓰기.Length-2];
                Array.Copy(띄어쓰기,2,값부분,0,띄어쓰기.Length-2);

                if(값부분[0].Contains("\""))
                {
                    richTextBox2.Text = "됨";
                    //기능 준비중 (따옴표 있나 확인)
                }
                JObject writeint = new JObject();
                writeint.Add("value", 쓸값);
                writeint.Add("type", type);
                json.Add(띄어쓰기[1], writeint);
                File.WriteAllText("변수.json", json.ToString());

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
                    File.WriteAllText("err.log", File.ReadAllText("err.log") + "\n" + 계수기 + "번째 줄: 실수변수 안에 문자를 넣을 수 없습니다.");
                }
            }
        }
    }
}