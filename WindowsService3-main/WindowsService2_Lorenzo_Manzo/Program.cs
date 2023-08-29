using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WindowsService_Lorenzo_Manzo;

namespace WindowsService1_Lorenzo_Manzo
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Crear una instancia del servicio
                IncrementService service = new IncrementService();

                //Ejecutar el servicio
                ServiceBase.Run(service);

                GrabarLogs.GrabarLog("Log", "Inicio del Servicio", "Servicio Iniciado");
            }
            catch (Exception e)
            {
                GrabarLogs.GrabarLog("Log", "Service_Error al crear servicio", e.Message);
            }

        }
    }
}

    
