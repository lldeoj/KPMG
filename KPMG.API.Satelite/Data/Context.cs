using System.Collections.Generic;

namespace KPMG.API.Satelite.Data
{

    public class Context
    {
        private static List<KPMG.Domain.Models.GameResultModel> Lst_GR;
        
        public Context()
        {
            if (Lst_GR == null)
            {
                Lst_GR = new List<Domain.Models.GameResultModel>();
            }

        }

        public bool Add(KPMG.Domain.Models.GameResultModel gr)
        {
            Lst_GR.Add(gr);
            return true;
        }

        public List<KPMG.Domain.Models.GameResultModel> get()
        { return Lst_GR; }


    }
}
