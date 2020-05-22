using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FamiliaData
    {
        private Data data = Data.Instance();

        private static volatile FamiliaData instance = null;
        private static readonly object padlock = new object();

        private FamiliaData() { }

        public static FamiliaData Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new FamiliaData();
            return instance;
        }

        public List<TipoMaterial> GetAll()
        {
            try
            {
                DataTable response = data.Query("stp_Familia_GetAll");
                List<TipoMaterial> lstUnidades = new List<TipoMaterial>();
                foreach (DataRow item in response.Rows)
                {
                    lstUnidades.Add(new TipoMaterial()
                    {
                        TipoMaterialId = Convert.ToByte(item["TipoMaterialId"]),
                        Descripcion = Convert.ToString(item["Descripcion"]),
                        EstatusId = Convert.ToByte(item["EstatusId"])
                    });
                }

                return lstUnidades;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
