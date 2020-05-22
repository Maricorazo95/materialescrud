using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MaterialData
    {
        private Data data = Data.Instance();

        private static volatile MaterialData instance = null;
        private static readonly object padlock = new object();

        private MaterialData() { }

        public static MaterialData Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new MaterialData();
            return instance;
        }

        public int Guardar(Material material)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[8];

                parameters[0] = new SqlParameter("@Nombre", material.Nombre);
                parameters[1] = new SqlParameter("@PiezasUnidad", material.PiezasUnidad);
                parameters[2] = new SqlParameter("@Costo", material.Costo);
                parameters[3] = new SqlParameter("@TipoMaterialId", material.TipoMaterialId);
                parameters[4] = new SqlParameter("@UnidadCompraId", material.UnidadCompraId);
                parameters[5] = new SqlParameter("@UnidadAlmacenId", material.UnidadAlmacenId);
                parameters[6] = new SqlParameter("@FamiliaId", material.FamiliaId);
                parameters[7] = new SqlParameter("@EstatusId", material.EstatusId);

                return data.Execute("stp_Material_Create", parameters); //cambiar por stpz
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public List<Material> GetAll()
        {
            try
            {
                DataTable response = data.Query("stp_Materiales_GetAll");
                List<Material> lstMateriales = new List<Material>();
                foreach (DataRow item in response.Rows)
                {
                    lstMateriales.Add(new Material()
                    {
                        MaterialId = Convert.ToInt32(item["MaterialId"]),
                        Nombre = Convert.ToString(item["Nombre"]),
                        Unidad = new Unidad() {
                            Descripcion = Convert.ToString(item["Unidad"])
                        },
                        TipoMaterial = new TipoMaterial()
                        {
                            Descripcion = Convert.ToString(item["TipoMaterial"])
                        },
                        Familia = new TipoMaterial()
                        {
                            Descripcion = Convert.ToString(item["Familia"])
                        }
                    });
                }

                return lstMateriales;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public int Eliminar(int id)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@MaterialId", id);

                string query = "stp_Material_Delete";

                return data.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public Material ObtenerMaterial(int id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@MaterialId", id);

            String query = "stp_Material_GetById";

            DataTable resultado = data.Query(query, parameters);

            if (resultado.Rows.Count > 0)
            {
                var dataObj = resultado.Rows[0];

                return new Material()
                {
                    MaterialId = (int)dataObj["MaterialId"],
                    Nombre = (string)dataObj["Nombre"],
                    FamiliaId = (short)dataObj["FamiliaId"],
                    UnidadAlmacenId  = (byte)dataObj["UnidadAlmacenId"],
                    UnidadCompraId = (byte)dataObj["UnidadCompraId"],
                    PiezasUnidad = (short)dataObj["PiezasUnidad"],
                    Costo = (decimal)dataObj["Costo"],
                    TipoMaterialId = (short)dataObj["TipoMaterialId"],
                    EstatusId = (byte)dataObj["EstatusId"]
                };
            }
            return null;
        }

        public int Actualizar(Material material)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[9];

                parameters[0] = new SqlParameter("@Nombre", material.Nombre);
                parameters[1] = new SqlParameter("@PiezasUnidad", material.PiezasUnidad);
                parameters[2] = new SqlParameter("@Costo", material.Costo);
                parameters[3] = new SqlParameter("@TipoMaterialId", material.TipoMaterialId);
                parameters[4] = new SqlParameter("@UnidadCompraId", material.UnidadCompraId);
                parameters[5] = new SqlParameter("@UnidadAlmacenId", material.UnidadAlmacenId);
                parameters[6] = new SqlParameter("@FamiliaId", material.FamiliaId);
                parameters[7] = new SqlParameter("@EstatusId", material.EstatusId);
                parameters[8] = new SqlParameter("@MaterialId", material.MaterialId);

                return data.Execute("stp_Material_Update", parameters);
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
    }
}
