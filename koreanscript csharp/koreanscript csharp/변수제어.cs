using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;

namespace koreanscript_csharp
{
    class 변수제어
    {
        public void 값지정(string[] 띄어쓰기, int 계수기)
        {
            Form1 form1 = new Form1();
            try
            {
                int 정수출력;
                decimal 실수출력;
                string 문자출력;
                switch(form1.변수형식[띄어쓰기[1]])
                {
                    case "int":
                        if (int.TryParse(띄어쓰기[2], out 정수출력))
                        {
                            form1.변수값[띄어쓰기[2]] = 띄어쓰기[3];
                        }
                        else
                        {
                            File.WriteAllText("err.log", $"{File.ReadAllText("err.log")}{계수기}번째 줄, 정수변수 안에 문자 혹은 실수를 넣을 수 없습니다.\n");
                        }
                        break;
                    case "decimal":
                        if (decimal.TryParse(띄어쓰기[2], out 실수출력))
                        {
                            form1.변수값[띄어쓰기[1]] = 띄어쓰기[2];
                        }
                        else
                        {
                            File.WriteAllText("err.log", $"{File.ReadAllText("err.log")}{계수기}번째 줄, 실수변수 안에 문자를 넣을 수 없습니다.\n");
                        }
                        break;
                    case "string":
                        if (띄어쓰기[2].IndexOf("\"") == 0 && 띄어쓰기[띄어쓰기.Length-1].LastIndexOf("\"") == 띄어쓰기[띄어쓰기.Length - 1].Length-1)
                        {
                            string[] 값부분 = new string[띄어쓰기.Length - 2];
                            Array.Copy(띄어쓰기, 2, 값부분, 0, 띄어쓰기.Length - 2);
                            string 쓰기 = string.Join(" ", 값부분);
                            쓰기.Substring(0);
                            쓰기.Substring(쓰기.Length-1);
                            form1.변수값[띄어쓰기[1]] = 쓰기;
                        }
                        else
                        {
                            File.WriteAllText("err.log", $"{File.ReadAllText("err.log")}{계수기}번째 줄, 문자변수값의 시작과 끝에는 \"이 필요합니다.\n");
                        }
                        break;
                }
            }
            catch
            {
                File.WriteAllText("err.log",$"{File.ReadAllText("err.log")}{계수기}번째 줄, 현재 그 이름의 변수는 존재하지 않습니다.");
            }
        }
    }
}
