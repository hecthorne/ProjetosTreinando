using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebApp.TratamentoRetornoJson
{
    public class TratarParaJson
    {
        public static string TratarSerializeObjectJson<T>(IList<T> lista)
        {
            //var jsr = new JsonResult() { Data = lista };
            //return JsonConvert.SerializeObject(jsr);
            
            //return new JavaScriptSerializer().Serialize(lista);

            return JsonConvert.SerializeObject(lista);
        }

        public static string TratarSerializeObjectJson<T>(T lista)
        {
            //var jsr = new JsonResult() { Data = lista };
            //return JsonConvert.SerializeObject(jsr);

            //return new JavaScriptSerializer().Serialize(lista);

            return JsonConvert.SerializeObject(lista);
        }
    }
}