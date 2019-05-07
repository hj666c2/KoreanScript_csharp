using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace koreanscript_csharp
{
    class 조건문
    {
        public async Task 만약에(string[] 띄어쓰기, int 계수기)
        {
            bool 참거짓 = false;
            string 변수읽기 = File.ReadAllText("변수.json");
            try
            {
                JObject 변수들 = JObject.Parse(변수읽기);
                string 변수1 = 변수들[띄어쓰기[1]]["type"].ToString();
                string 변수2 = 변수들[띄어쓰기[3]]["type"].ToString();
                if (변수1 != 변수2)
                {
                    File.WriteAllText("err.log", $"{File.ReadAllText("err.log")}{계수기}번째 줄: 변수가 서로 다른 타입입니다.\n");
                }
                else
                {
                    변수1 = 변수들[띄어쓰기[1]]["value"].ToString();
                    변수2 = 변수들[띄어쓰기[3]]["value"].ToString();
                    if (변수들[띄어쓰기[1]]["type"].ToString() == "string")
                    {
                        switch (띄어쓰기[2])
                        {
                            case "==":
                                if (변수1 == 변수2) 참거짓 = true;
                                else 참거짓 = false;
                                break;
                            case "!=":
                                if (변수1 != 변수2) 참거짓 = true;
                                else 참거짓 = false;
                                break;
                            default:
                                File.WriteAllText("err.log", $"{File.ReadAllText("err.log")}{계수기}번째 줄: 해당하는 연산자는 없는 연산자이거나 이 변수 타입(문자)에 사용 할 수 없습니다.\n");
                                break;
                        }
                    }
                    else if (변수들[띄어쓰기[1]]["type"].ToString() == "int")
                    {
                        switch (띄어쓰기[2])
                        {
                            case "==":
                                if (변수1 == 변수2) 참거짓 = true;
                                else 참거짓 = false;
                                break;
                            case "!=":
                                if (변수1 != 변수2) 참거짓 = true;
                                else 참거짓 = false;
                                break;
                            case ">=":
                                if (int.Parse(변수1) >= int.Parse(변수2)) 참거짓 = true;
                                else 참거짓 = false;
                                break;
                            case "<=":
                                if (int.Parse(변수1) >= int.Parse(변수2)) 참거짓 = true;
                                else 참거짓 = false;
                                break;
                            case "<":
                                if (int.Parse(변수1) < int.Parse(변수2)) 참거짓 = true;
                                else 참거짓 = false;
                                break;
                            case ">":
                                if (int.Parse(변수1) > int.Parse(변수2)) 참거짓 = true;
                                else 참거짓 = false;
                                break;
                            default:
                                File.WriteAllText("err.log", $"{File.ReadAllText("err.log")}{계수기}번째 줄: 해당하는 연산자는 없는 연산자 입니다.\n");
                                break;
                        }
                    }
                    else if (변수들[띄어쓰기[1]]["type"].ToString() == "decimal")
                    {
                        switch (띄어쓰기[2])
                        {
                            case "==":
                                if (변수1 == 변수2) 참거짓 = true;
                                else 참거짓 = false;
                                break;
                            case "!=":
                                if (변수1 != 변수2) 참거짓 = true;
                                else 참거짓 = false;
                                break;
                            case ">=":
                                if (decimal.Parse(변수1) >= decimal.Parse(변수2)) 참거짓 = true;
                                else 참거짓 = false;
                                break;
                            case "<=":
                                if (decimal.Parse(변수1) >= decimal.Parse(변수2)) 참거짓 = true;
                                else 참거짓 = false;
                                break;
                            case "<":
                                if (decimal.Parse(변수1) < decimal.Parse(변수2)) 참거짓 = true;
                                else 참거짓 = false;
                                break;
                            case ">":
                                if (decimal.Parse(변수1) > decimal.Parse(변수2)) 참거짓 = true;
                                else 참거짓 = false;
                                break;
                            default:
                                File.WriteAllText("err.log", $"{File.ReadAllText("err.log")}{계수기}번째 줄: 해당하는 연산자는 없는 연산자 입니다.\n");
                                break;
                        }
                    }
                    if (참거짓 == false) 계수기 += int.Parse(띄어쓰기[4]);
                }
            }
            catch { File.WriteAllText("err.log", $"{File.ReadAllText("err.log")}{계수기}번째 줄: 변수가 없거나 줄 수를 숫자가 아닌 것을 입력했습니다.\n"); }
        }
    }
}
