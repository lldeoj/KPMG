using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace KPMG.API.Satelite.Data
{

    public class Context
    {
        private static List<KPMG.Domain.Models.GameResultModel> Lst_GR;

        private static int limit;
        
        public Context()
        {
            if (Lst_GR == null)
            {
                Lst_GR = new List<Domain.Models.GameResultModel>();
                limit = new int();
                limit = 100;
            }

        }

        public bool Add(KPMG.Domain.Models.GameResultModel gr)
        {
            Lst_GR.Add(gr);
            if(Lst_GR.Count >= limit)
            {

            }
            return true;
        }

        public List<KPMG.Domain.Models.GameResultModel> get()
        { return Lst_GR; }

        public bool Limit(int qtd)
        {
            limit = qtd;
            return true;
        }

        private async bool call_API()
        {
            HttpClient client = new HttpClient();

            List<Domain.Models.GameResultModel> lst_help = new List<Domain.Models.GameResultModel>();

            foreach (var item in Lst_GR)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/GetGameResult", item);

                if(!response.IsSuccessStatusCode)
                {
                    lst_help.Add(item);
                }
            }

            Lst_GR.Clear();
            foreach (var item in lst_help)
            {
                Lst_GR.Add(item);
            }


            // return URI of the created resource.
            return true;
        }


    }
}
