using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace koreanscript_csharp
{
    class 변수제어 : Form1
    {
        public async Task 변수쓰기(string 한줄, string[] 띄어쓰기, int 계수기, Hashtable 값, Hashtable 형식)
        {
            try
            {
                string 겁사 = 형식[띄어쓰기[1]].ToString();
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
                                정수값 += outint;
                                형식.Add(띄어쓰기[1], "int");
                                값.Add(띄어쓰기[1], 정수값);
                            }
                            else
                            {
                                try
                                {
                                    if (형식[띄어쓰기[2]].ToString() != "int")
                                    { File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 정수변수에는 실수 혹은 문자를 넣을 수 없습니다.\n"); }
                                    else
                                    {
                                        정수값 += (int)값[띄어쓰기[2]];
                                    }
                                    형식.Add(띄어쓰기[1], "int");
                                    값.Add(띄어쓰기[1], 정수값);

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
                                { 정수값 += outint; }
                                else File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 연산자는 존재하지 않습니다.\n");
                            }
                            else
                            {
                                if (형식[띄어쓰기[2]].ToString() != "int")
                                { File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 정수변수에는 실수 혹은 문자를 넣을 수 없습니다.\n"); }
                                else
                                {
                                    try
                                    {
                                        if (형식[띄어쓰기[2]].ToString() != "int")
                                        { File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 정수변수에는 실수 혹은 문자를 넣을 수 없습니다.\n"); }
                                        else
                                        {
                                            if (띄어쓰기[3] == "+" || 띄어쓰기[3] == "-" || 띄어쓰기[3] == "*" || 띄어쓰기[3] == "/" || 띄어쓰기[3] == "%")
                                            { 정수값 += (int)값[띄어쓰기[2]]; }
                                            else File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 연산자는 존재하지 않습니다.\n");
                                        }
                                    }
                                    catch
                                    {
                                        File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 변수가 존재하지 않습니다.\n");
                                    }
                                }
                            }
                            if (int.TryParse(띄어쓰기[4], out outint))
                            {
                                switch (띄어쓰기[3])
                                {
                                    case "+":
                                        정수값 = 정수값 + outint;
                                        형식.Add(띄어쓰기[1], "int");
                                        값.Add(띄어쓰기[1], 정수값);
                                        break;
                                    case "-":
                                        정수값 = 정수값 - outint;
                                        형식.Add(띄어쓰기[1], "int");
                                        값.Add(띄어쓰기[1], 정수값);
                                        break;
                                    case "*":
                                        정수값 = 정수값 * outint;
                                        형식.Add(띄어쓰기[1], "int");
                                        값.Add(띄어쓰기[1], 정수값);
                                        break;
                                    case "/":
                                        try
                                        {
                                            정수값 = 정수값 / outint;
                                            형식.Add(띄어쓰기[1], "int");
                                            값.Add(띄어쓰기[1], 정수값);
                                        }
                                        catch
                                        {
                                            File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 0으로 나눌 수 없습니다.\n");
                                        }
                                        break;
                                    case "%":
                                        try
                                        {
                                            정수값 = 정수값 % outint;
                                            형식.Add(띄어쓰기[1], "int");
                                            값.Add(띄어쓰기[1], 정수값);
                                        }
                                        catch
                                        {
                                            File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 0으로 나눌 수 없습니다.\n");
                                        }
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
                                    if (형식[띄어쓰기[4]].ToString() == "int")
                                    {
                                        switch (띄어쓰기[3])
                                        {
                                            case "+":
                                                정수값 += (int)값[띄어쓰기[4]];
                                                형식.Add(띄어쓰기[1], "int");
                                                값.Add(띄어쓰기[1], 정수값);
                                                break;
                                            case "-":
                                                정수값 -= (int)값[띄어쓰기[4]];
                                                형식.Add(띄어쓰기[1], "int");
                                                값.Add(띄어쓰기[1], 정수값);
                                                break;
                                            case "*":
                                                정수값 *= (int)값[띄어쓰기[4]];
                                                형식.Add(띄어쓰기[1], "int");
                                                값.Add(띄어쓰기[1], 정수값);
                                                break;
                                            case "/":
                                                try
                                                {
                                                    정수값 /= (int)값[띄어쓰기[4]];
                                                    형식.Add(띄어쓰기[1], "int");
                                                    값.Add(띄어쓰기[1], 정수값);
                                                }
                                                catch
                                                {
                                                    File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 0으로 나눌 수 없습니다.\n");
                                                }
                                                break;
                                            case "%":
                                                try
                                                {
                                                    정수값 %= (int)값[띄어쓰기[4]];
                                                    형식.Add(띄어쓰기[1], "int");
                                                    값.Add(띄어쓰기[1], 정수값);
                                                }
                                                catch
                                                {
                                                    File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 0으로 나눌 수 없습니다.\n");
                                                }
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
                        if (값부분[0].IndexOf("\"") == 0 && (값부분[값부분.Length - 1].LastIndexOf("\"") == 값부분[값부분.Length - 1].Length - 1))
                        {
                            string 쓸값 = null;
                            값부분[0] = 값부분[0].Substring(1);
                            값부분[값부분.Length - 1] = 값부분[값부분.Length - 1].Substring(0, 값부분[값부분.Length - 1].Length - 1);
                            쓸값 = string.Join(" ", 값부분);
                            형식.Add(띄어쓰기[1], "string");
                            값.Add(띄어쓰기[1], 쓸값);
                        }
                        else
                        {
                            string 쓸문자 = "";
                            if (띄어쓰기[3] == "+")
                            {
                                try
                                {
                                    쓸문자 = 값[띄어쓰기[2]].ToString() + 값[띄어쓰기[4]].ToString();
                                    형식.Add(띄어쓰기[1], "string");
                                    값.Add(띄어쓰기[1], 쓸문자);
                                }
                                catch
                                {
                                    File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 변수가 없습니다.\n");
                                }
                            }
                        }
                    }
                    else if (type == "decimal")
                    {
                    { 
                        decimal 실수값 = 0;
                        if (띄어쓰기.Length == 3)
                        {
                            if (decimal.TryParse(띄어쓰기[2], out outdecimal))
                            {
                                실수값 += outdecimal;
                                형식.Add(띄어쓰기[1], "decimal");
                                값.Add(띄어쓰기[1], 실수값);
                            }
                            else
                            {
                                try
                                {
                                    if (형식[띄어쓰기[2]].ToString() == "string")
                                    { File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 실수변수에는 문자를 넣을 수 없습니다.\n"); }
                                    else
                                    {
                                        실수값 += (decimal)값[띄어쓰기[2]];
                                    }
                                    형식.Add(띄어쓰기[1], "int");
                                    값.Add(띄어쓰기[1], 실수값.ToString());
                                }
                                catch
                                {
                                    File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 변수가 존재하지 않습니다.\n");
                                }
                            }
                        }
                        else if (띄어쓰기.Length == 5)
                        {
                            if (decimal.TryParse(띄어쓰기[2], out outdecimal))
                            {
                                if (띄어쓰기[3] == "+" || 띄어쓰기[3] == "-" || 띄어쓰기[3] == "*" || 띄어쓰기[3] == "/" || 띄어쓰기[3] == "%")
                                { 실수값 += outdecimal; }
                                else File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 연산자는 존재하지 않습니다.\n");
                            }
                            else
                            {
                                try
                                {
                                    if (형식[띄어쓰기[2]].ToString() == "string")
                                        { File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 실수변수에는 혹은 문자를 넣을 수 없습니다.\n"); }
                                    else
                                    {
                                        if (띄어쓰기[3] == "+" || 띄어쓰기[3] == "-" || 띄어쓰기[3] == "*" || 띄어쓰기[3] == "/" || 띄어쓰기[3] == "%")
                                        { 실수값 += (decimal)값[띄어쓰기[2]]; }
                                        else File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 연산자는 존재하지 않습니다.\n");
                                    }
                                }
                                catch
                                {
                                    File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 변수가 존재하지 않습니다.\n");
                                }
                            }
                            if (decimal.TryParse(띄어쓰기[4], out outdecimal))
                            {
                                switch (띄어쓰기[3])
                                {
                                    case "+":
                                        실수값 += outdecimal;
                                        형식.Add(띄어쓰기[1], "decimal");
                                        값.Add(띄어쓰기[1], 실수값);
                                        break;
                                    case "-":
                                        실수값 -= outdecimal;
                                        형식.Add(띄어쓰기[1], "decimal");
                                        값.Add(띄어쓰기[1], 실수값);
                                        break;
                                    case "*":
                                        실수값 *= outdecimal;
                                        형식.Add(띄어쓰기[1], "decimal");
                                        값.Add(띄어쓰기[1], 실수값);
                                        break;
                                    case "/":
                                        실수값 /= outdecimal;
                                        형식.Add(띄어쓰기[1], "decimal");
                                        값.Add(띄어쓰기[1], 실수값);
                                        break;
                                    case "%":
                                        실수값 %= outdecimal;
                                        형식.Add(띄어쓰기[1], "decimal");
                                        값.Add(띄어쓰기[1], 실수값);
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
                                    if (형식[띄어쓰기[4]].ToString() == "decimal")
                                    {
                                        switch (띄어쓰기[3])
                                        {
                                            case "+":
                                                실수값 += (decimal)값[띄어쓰기[4]];
                                                형식.Add(띄어쓰기[1], "decimal");
                                                값.Add(띄어쓰기[1], 실수값);
                                                break;
                                            case "-":
                                                실수값 -= (decimal)값[띄어쓰기[4]];
                                                형식.Add(띄어쓰기[1], "decimal");
                                                값.Add(띄어쓰기[1], 실수값);
                                                break;
                                            case "*":
                                                실수값 *= (decimal)값[띄어쓰기[4]];
                                                형식.Add(띄어쓰기[1], "decimal");
                                                값.Add(띄어쓰기[1], 실수값);
                                                break;
                                            case "/":
                                                try
                                                {
                                                    실수값 /= (decimal)값[띄어쓰기[4]];
                                                    형식.Add(띄어쓰기[1], "decimal");
                                                    값.Add(띄어쓰기[1], 실수값);
                                                }
                                                catch
                                                {
                                                    File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 0으로 나눌 수 없습니다.\n");
                                                }
                                                    break;
                                            case "%":
                                                    try
                                                    {
                                                        실수값 %= (decimal)값[띄어쓰기[4]];
                                                        형식.Add(띄어쓰기[1], "decimal");
                                                        값.Add(띄어쓰기[1], 실수값);
                                                    }
                                                    catch
                                                    {
                                                        File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 0으로 나눌 수 없습니다.\n");
                                                    }
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
                }
                }

            }
        }










        public async Task 값지정(string 한줄, string[] 띄어쓰기, int 계수기, Hashtable 값, Hashtable 형식)
        {
            try
            {
                string 겁사 = 형식[띄어쓰기[1]].ToString();
                if (Char.IsNumber(띄어쓰기[1][0]) || 띄어쓰기[1][0] == '\"')
                {
                    File.WriteAllText("err.log", $"{File.ReadAllText("err.log")}{계수기}번째 줄, 변수 이름 첫 글자에는 \"와 숫자를 넣을 수 없습니다.");
                }
                else
                {
                    decimal outdecimal;
                    string type = 형식[띄어쓰기[1]].ToString();
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
                                정수값 += outint;
                                값[띄어쓰기[1]] = 정수값;
                            }
                            else
                            {
                                try
                                {
                                    if (형식[띄어쓰기[2]].ToString() != "int")
                                    { File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 정수변수에는 실수 혹은 문자를 넣을 수 없습니다.\n"); }
                                    else
                                    {
                                        정수값 += (int)값[띄어쓰기[2]];
                                    }
                                    값[띄어쓰기[1]] = 정수값;
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
                                { 정수값 += outint; }
                                else File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 연산자는 존재하지 않습니다.\n");
                            }
                            else
                            {
                                if (형식[띄어쓰기[2]].ToString() != "int")
                                { File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 정수변수에는 실수 혹은 문자를 넣을 수 없습니다.\n"); }
                                else
                                {
                                    try
                                    {
                                        if (형식[띄어쓰기[2]].ToString() != "int")
                                        { File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 정수변수에는 실수 혹은 문자를 넣을 수 없습니다.\n"); }
                                        else
                                        {
                                            if (띄어쓰기[3] == "+" || 띄어쓰기[3] == "-" || 띄어쓰기[3] == "*" || 띄어쓰기[3] == "/" || 띄어쓰기[3] == "%")
                                            { 정수값 += (int)값[띄어쓰기[2]]; }
                                            else File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 연산자는 존재하지 않습니다.\n");
                                        }
                                    }
                                    catch
                                    {
                                        File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 변수가 존재하지 않습니다.\n");
                                    }
                                }
                            }
                            if (int.TryParse(띄어쓰기[4], out outint))
                            {
                                switch (띄어쓰기[3])
                                {
                                    case "+":
                                        정수값 = 정수값 + outint;
                                        값[띄어쓰기[1]] = 정수값;
                                        break;
                                    case "-":
                                        정수값 = 정수값 - outint;
                                        값[띄어쓰기[1]] = 정수값;
                                        break;
                                    case "*":
                                        정수값 = 정수값 * outint;
                                        값[띄어쓰기[1]] = 정수값;
                                        break;
                                    case "/":
                                        try
                                        {
                                            정수값 = 정수값 / outint;
                                            값[띄어쓰기[1]] = 정수값;
                                        }
                                        catch
                                        {
                                            File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 0으로 나눌 수 없습니다.\n");
                                        }
                                        break;
                                    case "%":
                                        try
                                        {
                                            정수값 = 정수값 % outint;
                                            값[띄어쓰기[1]] = 정수값;
                                        }
                                        catch
                                        {
                                            File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 0으로 나눌 수 없습니다.\n");
                                        }
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
                                    if (형식[띄어쓰기[4]].ToString() == "int")
                                    {
                                        switch (띄어쓰기[3])
                                        {
                                            case "+":
                                                정수값 += (int)값[띄어쓰기[4]];
                                                값[띄어쓰기[1]] = 정수값;
                                                break;
                                            case "-":
                                                정수값 -= (int)값[띄어쓰기[4]];
                                                값[띄어쓰기[1]] = 정수값;
                                                break;
                                            case "*":
                                                정수값 *= (int)값[띄어쓰기[4]];
                                                값[띄어쓰기[1]] = 정수값;
                                                break;
                                            case "/":
                                                try
                                                {
                                                    정수값 /= (int)값[띄어쓰기[4]];
                                                    값[띄어쓰기[1]] = 정수값;
                                                }
                                                catch
                                                {
                                                    File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 0으로 나눌 수 없습니다.\n");
                                                }
                                                break;
                                            case "%":
                                                try
                                                {
                                                    정수값 %= (int)값[띄어쓰기[4]];
                                                    값[띄어쓰기[1]] = 정수값;
                                                }
                                                catch
                                                {
                                                    File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 0으로 나눌 수 없습니다.\n");
                                                }
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
                        if (값부분[0].IndexOf("\"") == 0 && (값부분[값부분.Length - 1].LastIndexOf("\"") == 값부분[값부분.Length - 1].Length - 1))
                        {
                            string 쓸값 = null;
                            값부분[0] = 값부분[0].Substring(1);
                            값부분[값부분.Length - 1] = 값부분[값부분.Length - 1].Substring(0, 값부분[값부분.Length - 1].Length - 1);
                            쓸값 = string.Join(" ", 값부분);
                            값[띄어쓰기[1]] = 쓸값;
                        }
                        else
                        {
                            string 쓸문자 = "";
                            if (띄어쓰기[3] == "+")
                            {
                                try
                                {
                                    쓸문자 = 값[띄어쓰기[2]].ToString() + 값[띄어쓰기[4]].ToString();
                                    값[띄어쓰기[1]] = 쓸문자;
                                }
                                catch
                                {
                                    File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 변수가 없습니다.\n");
                                }
                            }
                        }
                    }
                    else if (type == "decimal")
                    {
                        {
                            decimal 실수값 = 0;
                            if (띄어쓰기.Length == 3)
                            {
                                if (decimal.TryParse(띄어쓰기[2], out outdecimal))
                                {
                                    실수값 += outdecimal;
                                    값[띄어쓰기[1]] = 실수값;
                                }
                                else
                                {
                                    try
                                    {
                                        if (형식[띄어쓰기[2]].ToString() == "string")
                                        { File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 실수변수에는 문자를 넣을 수 없습니다.\n"); }
                                        else
                                        {
                                            실수값 += (decimal)값[띄어쓰기[2]];
                                        }
                                        값[띄어쓰기[1]] = 실수값; //
                                    }
                                    catch
                                    {
                                        File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 변수가 존재하지 않습니다.\n");
                                    }
                                }
                            }
                            else if (띄어쓰기.Length == 5)
                            {
                                if (decimal.TryParse(띄어쓰기[2], out outdecimal))
                                {
                                    if (띄어쓰기[3] == "+" || 띄어쓰기[3] == "-" || 띄어쓰기[3] == "*" || 띄어쓰기[3] == "/" || 띄어쓰기[3] == "%")
                                    { 실수값 += outdecimal; }
                                    else File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 연산자는 존재하지 않습니다.\n");
                                }
                                else
                                {
                                    try
                                    {
                                        if (형식[띄어쓰기[2]].ToString() == "string")
                                        { File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 실수변수에는 혹은 문자를 넣을 수 없습니다.\n"); }
                                        else
                                        {
                                            if (띄어쓰기[3] == "+" || 띄어쓰기[3] == "-" || 띄어쓰기[3] == "*" || 띄어쓰기[3] == "/" || 띄어쓰기[3] == "%")
                                            { 실수값 += (decimal)값[띄어쓰기[2]]; }
                                            else File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 연산자는 존재하지 않습니다.\n");
                                        }
                                    }
                                    catch
                                    {
                                        File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 해당하는 변수가 존재하지 않습니다.\n");
                                    }
                                }
                                if (decimal.TryParse(띄어쓰기[4], out outdecimal))
                                {
                                    switch (띄어쓰기[3])
                                    {
                                        case "+":
                                            실수값 += outdecimal;
                                            값[띄어쓰기[1]] = 실수값;
                                            break;
                                        case "-":
                                            실수값 -= outdecimal;
                                            값[띄어쓰기[1]] = 실수값;
                                            break;
                                        case "*":
                                            실수값 *= outdecimal;
                                            값[띄어쓰기[1]] = 실수값;
                                            break;
                                        case "/":
                                            실수값 /= outdecimal;
                                            값[띄어쓰기[1]] = 실수값;
                                            break;
                                        case "%":
                                            실수값 %= outdecimal;
                                            값[띄어쓰기[1]] = 실수값;
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
                                        if (형식[띄어쓰기[4]].ToString() == "decimal")
                                        {
                                            switch (띄어쓰기[3])
                                            {
                                                case "+":
                                                    실수값 += (decimal)값[띄어쓰기[4]];
                                                    값[띄어쓰기[1]] = 실수값;
                                                    break;
                                                case "-":
                                                    실수값 -= (decimal)값[띄어쓰기[4]];
                                                    값[띄어쓰기[1]] = 실수값;
                                                    break;
                                                case "*":
                                                    실수값 *= (decimal)값[띄어쓰기[4]];
                                                    값[띄어쓰기[1]] = 실수값;
                                                    break;
                                                case "/":
                                                    try
                                                    {
                                                        실수값 /= (decimal)값[띄어쓰기[4]];
                                                        값[띄어쓰기[1]] = 실수값;
                                                    }
                                                    catch
                                                    {
                                                        File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 0으로 나눌 수 없습니다.\n");
                                                    }
                                                    break;
                                                case "%":
                                                    try
                                                    {
                                                        실수값 %= (decimal)값[띄어쓰기[4]];
                                                        값[띄어쓰기[1]] = 실수값;
                                                    }
                                                    catch
                                                    {
                                                        File.WriteAllText("err.log", File.ReadAllText("err.log") + 계수기 + "번째 줄: 0으로 나눌 수 없습니다.\n");
                                                    }
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
                    }
                }
            }
            catch
            {
                File.WriteAllText("err.log", $"{File.ReadAllText("err.log")}{계수기}번째 줄, 변수가 존재하지 않습니다.\n");
            }
        }
        public async Task 변수제거(string[] 띄어쓰기,int 계수기,Hashtable 변수값, Hashtable 변수형식)
        {
            if (띄어쓰기[1] == "\"모두")
            {
                변수값.Clear();
                변수형식.Clear();
            }
            else
            {
                try
                {
                    변수값.Remove(띄어쓰기[1]);
                    변수형식.Remove(띄어쓰기[1]);
                }
                catch
                {
                    File.WriteAllText("err.log", $"{File.ReadAllText("err.log")}{계수기}번째 줄, 변수가 존재하지 않습니다.\n");
                }
            }
        }
    }
}
