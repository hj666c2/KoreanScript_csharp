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
                    await writevar(띄어쓰기[0],띄어쓰기[1], 띄어쓰기[2],계수기와1);
                }
                else if (띄어쓰기[0] == "말하기") { }
                richTextBox2.Text = richTextBox2.Text + "\n완료";
            }
            goto go;
        go:;
        }


        public async Task writevar(string type,string name, string value, int 계수기)
        {
            await Task.Delay(1);
            string read = File.ReadAllText("변수.json");
            switch (type)
            {
                case "정수변수":
                    type = "int";
                    try { int a = int.Parse(value); }
                    catch { File.WriteAllText("error.log", File.ReadAllText("error.log") + "\n" + 계수기 + "번째 줄: 변수 타입과 변수에 들어가는 값이 맞지 않습니다"); }
                    break;
                case "문자변수":
                    type = "string";
                    break;
                case "실수변수":
                    type = "decimal";
                    break;
            }
            if (type == "int" && value != "") { }

            JObject jObject = new JObject(
                new JProperty(name, value, type));
            char[] split = read.ToCharArray();
            split[split.Length - 1] = ',';
            split[3] = ' ';
            string writeone = new string(split);
            char[] splitt = jObject.ToString().ToCharArray();
            splitt[0] = ' ';
            string writetwo = new string(splitt);
            File.WriteAllText("변수.json", writeone + writetwo);
        final:;
        }
    }
}
