using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace koreanscript_csharp
{
    class 변수제어 : Form1
    {
        public async Task 변수쓰기(string 한줄, string[] 띄어쓰기, int 계수기)
        {
            try
            {
                string 겁사 = 변수형식[띄어쓰기[1]].ToString();
                File.WriteAllText("err.log", $"{File.ReadAllText("err.log")}{계수기}번째 줄, 이미 같은 이름의 변수가 존재합니다.\n");
            }
            catch
            {
                if (Char.IsNumber(띄어쓰기[1][0]) || 띄어쓰기[1][0] == '\"')
                {
                    File.WriteAllText("err.log", $"{File.ReadAllText("err.log")}{계수기}번째 줄, 변수 이름 첫 글자에는 \"와 숫자를 넣을 수 없습니다.");
                }
                else
                {
                    decimal outdecimal;
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
                    string[] 값부분 = new string[띄어쓰기.Length - 2];
                    Array.Copy(띄어쓰기, 2, 값부분, 0, 띄어쓰기.Length - 2);
                    int outint = 0;
                    if (type == "int")
                    {
                        int 정수값 = 0;
                        if (띄어쓰기.Length == 3)
                        {
                            if (int.TryParse(띄어쓰기[2], out outint))
                            {
                                정수값 += int.Parse(띄어쓰기[2]);
                                변수형식.Add(띄어쓰기[1], "int");
                                변수값.Add(띄어쓰기[1], 정수값.ToString());
                            }
                            else
                            {
                                try
                                {
                                    if (변수형식[띄어쓰기[2]].ToString() != "int")
                                    { File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 정수변수에는 실수 혹은 문자를 넣을 수 없습니다.\n"); }
                                    else
                                    {
                                        정수값 += int.Parse(변수값[띄어쓰기[2]].ToString());
                                    }
                                    변수형식.Add(띄어쓰기[1], "int");
                                    변수값.Add(띄어쓰기[1], 정수값.ToString());
                                }
                                catch
                                {
                                    File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 변수가 존재하지 않습니다.\n");
                                }
                            }
                        }
                        else if (띄어쓰기.Length == 5)
                        {
                            if (int.TryParse(띄어쓰기[2], out outint))
                            {
                                if (띄어쓰기[3] == "+" || 띄어쓰기[3] == "-" || 띄어쓰기[3] == "*" || 띄어쓰기[3] == "/" || 띄어쓰기[3] == "%")
                                { 정수값 += int.Parse(띄어쓰기[2]); }
                                else File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 연산자는 존재하지 않습니다.\n");
                            }
                            else
                            {
                                try
                                {
                                    if (변수형식[띄어쓰기[2]].ToString() != "int")
                                    { File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 정수변수에는 실수 혹은 문자를 넣을 수 없습니다.\n"); }
                                    else
                                    {
                                        if (띄어쓰기[3] == "+" || 띄어쓰기[3] == "-" || 띄어쓰기[3] == "*" || 띄어쓰기[3] == "/" || 띄어쓰기[3] == "%")
                                        { 정수값 += int.Parse(변수값[띄어쓰기[2]].ToString()); }
                                        else File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 연산자는 존재하지 않습니다.\n");
                                    }
                                }
                                catch
                                {
                                    File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 변수가 존재하지 않습니다.\n");
                                }
                            }
                            if (int.TryParse(띄어쓰기[4], out outint))
                            {
                                switch (띄어쓰기[3])
                                {
                                    case "+":
                                        정수값 += int.Parse(띄어쓰기[4]);
                                        변수형식.Add(띄어쓰기[1], "int");
                                        변수값.Add(띄어쓰기[1], 정수값.ToString());
                                        break;
                                    case "-":
                                        정수값 -= int.Parse(띄어쓰기[4]);
                                        변수형식.Add(띄어쓰기[1], "int");
                                        변수값.Add(띄어쓰기[1], 정수값.ToString());
                                        break;
                                    case "*":
                                        정수값 *= int.Parse(띄어쓰기[4]);
                                        변수형식.Add(띄어쓰기[1], "int");
                                        변수값.Add(띄어쓰기[1], 정수값.ToString());
                                        break;
                                    case "/":
                                        정수값 /= int.Parse(띄어쓰기[4]);
                                        변수형식.Add(띄어쓰기[1], "int");
                                        변수값.Add(띄어쓰기[1], 정수값.ToString());
                                        break;
                                    case "%":
                                        정수값 %= int.Parse(띄어쓰기[4]);
                                        변수형식.Add(띄어쓰기[1], "int");
                                        변수값.Add(띄어쓰기[1], 정수값.ToString());
                                        break;
                                    default:
                                        File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 연산자는 존재하지 않습니다.\n");
                                        break;
                                }
                            }
                            else
                            {
                                try
                                {
                                    if (변수형식[띄어쓰기[4]].ToString() == "int")
                                    {
                                        switch (띄어쓰기[3])
                                        {
                                            case "+":
                                                정수값 += int.Parse(변수값[띄어쓰기[4]].ToString());
                                                변수형식.Add(띄어쓰기[1], "int");
                                                변수값.Add(띄어쓰기[1], 정수값.ToString());
                                                break;
                                            case "-":
                                                정수값 -= int.Parse(변수값[띄어쓰기[4]].ToString());
                                                변수형식.Add(띄어쓰기[1], "int");
                                                변수값.Add(띄어쓰기[1], 정수값.ToString());
                                                break;
                                            case "*":
                                                정수값 *= int.Parse(변수값[띄어쓰기[4]].ToString());
                                                변수형식.Add(띄어쓰기[1], "int");
                                                변수값.Add(띄어쓰기[1], 정수값.ToString());
                                                break;
                                            case "/":
                                                정수값 /= int.Parse(변수값[띄어쓰기[4]].ToString());
                                                변수형식.Add(띄어쓰기[1], "int");
                                                변수값.Add(띄어쓰기[1], 정수값.ToString());
                                                break;
                                            case "%":
                                                정수값 %= int.Parse(변수값[띄어쓰기[4]].ToString());
                                                변수형식.Add(띄어쓰기[1], "int");
                                                변수값.Add(띄어쓰기[1], 정수값.ToString());
                                                break;
                                            default:
                                                File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 연산자는 존재하지 않습니다.\n");
                                                break;
                                        }
                                    }
                                }
                                catch
                                {
                                    File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 변수가 존재하지 않습니다.\n");
                                }
                            }
                        }
                    }
                    else if (type == "string")
                    {
                        if (값부분[0].IndexOf("\"") != 0 || (값부분[값부분.Length - 1].LastIndexOf("\"") != 값부분[값부분.Length - 1].Length - 1))
                        {
                            string 쓸문자 = "";
                            if (띄어쓰기[3] == "+")
                            {
                                try
                                {
                                    쓸문자 = 변수값[띄어쓰기[2]].ToString() + 변수값[띄어쓰기[4]].ToString();
                                    변수형식.Add(띄어쓰기[1], "string");
                                    변수값.Add(띄어쓰기[1], 쓸문자);
                                }
                                catch
                                {
                                    File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 변수가 없습니다.\n");
                                }
                            }
                        }
                        else
                        {
                            string 쓸값 = null;
                            값부분[0] = 값부분[0].Substring(1);
                            값부분[값부분.Length - 1] = 값부분[값부분.Length - 1].Substring(0, 값부분[값부분.Length - 1].Length - 1);
                            쓸값 = string.Join(" ", 값부분);
                            변수형식.Add(띄어쓰기[1], "string");
                            변수값.Add(띄어쓰기[1], 쓸값);
                        }
                    }
                    else if (type == "decimal")
                    {
                        if (decimal.TryParse(띄어쓰기[2], out outdecimal))
                        {
                            변수값.Add(띄어쓰기[1], 띄어쓰기[2]);
                            변수형식.Add(띄어쓰기[1], "decimal");
                        }
                        else
                        {
                            File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 실수변수 안에 문자를 넣을 수 없습니다.\n");
                        }
                    }
                }
            }
        }










        public void 값지정(string[] 띄어쓰기, int 계수기)
        {
            try
            {
                int 정수출력;
                decimal 실수출력;
                string 문자출력;
                switch(변수형식[띄어쓰기[1]])
                {
                    case "int":
                        if (int.TryParse(띄어쓰기[2], out 정수출력))
                        {
                            변수값[띄어쓰기[2]] = 띄어쓰기[3];
                        }
                        else
                        {
                            File.WriteAllText("err.log", $"{File.ReadAllText("err.log")}{계수기}번째 줄, 정수변수 안에 문자 혹은 실수를 넣을 수 없습니다.\n");
                        }
                        break;
                    case "decimal":
                        if (decimal.TryParse(띄어쓰기[2], out 실수출력))
                        {
                            변수값[띄어쓰기[1]] = 띄어쓰기[2];
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
                            변수값[띄어쓰기[1]] = 쓰기;
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
