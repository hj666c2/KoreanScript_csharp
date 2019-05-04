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
        public void 값지정(string[] 띄어쓰기)
        {
            string 변수 = File.ReadAllText("변수.json");
            JObject 변수읽기 = JObject.Parse(변수);
            try
            {
                int 정수출력;
                decimal 실수출력;
                string 문자출력;
                string 타입 = 변수읽기[띄어쓰기[1]]["type"].ToString();
                string 값 = 변수읽기[띄어쓰기[1]]["value"].ToString();
                switch(타입)
                {
                    case "int":
                        if (int.TryParse(값, out 정수출력))
                        {

                        }
                        break;
                }
            }
            catch { }
        }
    }
}
