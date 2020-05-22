using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnidadData
    {
        private Data data = Data.Instance();

        private static volatile UnidadData instance = null;
        private static readonly object padlock = new object();

        private UnidadData() { }

        public static UnidadData Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new UnidadData();
            return instance;
        }

        public List<Unidad> GetAll()
        {
            try
            {
                DataTable response = data.Query("stp_Unidades_GetAll");
                List<Unidad> lstUnidades = new List<Unidad>();
                foreach (DataRow item in response.Rows)
                {
                    lstUnidades.Add(new Unidad()
                    {
                        UnidadId = Convert.ToByte(item["UnidadId"]),
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
