using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Web;
using libComunes.CapaObjetos;

namespace pAplicacionesWEB.Comunes
{
    /// <summary>
    /// Descripción breve de ControladorCombos
    /// </summary>
    public class ControladorCombos : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string DatosCombo;
            StreamReader reader = new StreamReader(context.Request.InputStream);
            DatosCombo = reader.ReadToEnd();

            viewCombo vCombo = JsonConvert.DeserializeObject<viewCombo>(DatosCombo);
            string Respuesta;

            switch (vCombo.Comando.ToUpper())
            {
                case "PROVEEDOR":
                    Respuesta = LlenarCombo(vCombo, "SECTOR_LLENARCOMBO");
                    break;
                case "PRODUCTO_PROVEEDOR":
                    Respuesta = LlenarCombo(vCombo, "PRODUCTO_LLENAR_COMBO");
                    break;
                case "VENTA_CLIENTE":
                    Respuesta = LlenarCombo(vCombo, "VENTA_CLIENTE_LLENAR_COMBO");
                    break;
                case "VENTA_PROVEEDOR":
                    Respuesta = LlenarCombo(vCombo, "VENTA_PROVEEDOR_LLENAR_COMBO");
                    break;
                case "VENTA_PRODUCTO":
                    Respuesta = LlenarCombo(vCombo, "VENTA_PRODUCTO_LLENAR_COMBO");
                    break;
                case "VENTA_PRODUCTO_CAMBIO":
                    Respuesta = LlenarCombo(vCombo, "VENTA_PRODUCTO_LLENAR_COMBO_CAMBIO");
                    break;
                case "VENTA_GARANTIA":
                    Respuesta = LlenarCombo(vCombo, "VENTA_GARANTIA_LLENAR_COMBO");
                    break;
                default:
                    Respuesta = "Comando sin definir";
                    break;
            }

            context.Response.Write(Respuesta);
        }
        private string LlenarCombo(viewCombo vCombo, string SQL)
        {
            vCombo.SQL = SQL;
            clsComboListas oCombo = new clsComboListas();
            oCombo.vCombo = vCombo;
            return JsonConvert.SerializeObject(oCombo.ListarCombos());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}