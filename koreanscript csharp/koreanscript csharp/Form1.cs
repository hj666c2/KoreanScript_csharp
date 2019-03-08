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

namespace koreanscript_csharp
{
    public class variable
    {
        public string name { get; set; }
        public string value { get; set; }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText("변수.kova",""); //변수초기화
            string output;
            string 입력 = richTextBox1.Text;
            string[] 한줄 = 입력.Split('\n');
            string[] 띄어쓰기 = null;
            int 계수기와1 = 0;
            for (int 계수기 = 0; 계수기 < 한줄.Length;계수기++)
            {
                띄어쓰기 = 한줄[계수기].Split(' ');
                계수기와1 = 계수기 + 1;
                if (띄어쓰기[0] == "정수변수")
                {
                    try
                    {
                        variable pObj = JsonConvert.DeserializeObject<variable>(띄어쓰기[1]);
                        goto stop;
                    }
                    catch
                    {
                        var vari = new variable { name = 띄어쓰기[1], value = 띄어쓰기[2] };
                    }
                }
                else if (띄어쓰기[0] == "문자변수") { }
                else if (띄어쓰기[0] == "실수변수") { }
                else if (띄어쓰기[0] == "말하기") { }
            }
            goto go;
        stop:
            output = "오류" + 계수기와1.ToString() + "번째 줄에 잘못된 구문이 있습니다 확인 후 다시 시도하십시오";
            goto final;
        go:
        final:;
        }
    }
}
