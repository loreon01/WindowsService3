using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsService1_Lorenzo_Manzo
{
    public static class GrabarLogs
    {
        public static void GrabarLog(string sistema, string titulo, string texto)
        {
            string logFolderPath = ObtenerRutaCarpetaLog();
            string logFilePath = ObtenerRutaArchivoLog(logFolderPath);

            string logMessage = $"{DateTime.Now} - {sistema} - {titulo}: {texto}";

            try
            {
                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine(logMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir en el archivo de registro: {ex.Message}");
            }
        }

        private static string ObtenerRutaCarpetaLog()
        {
            string rutaCarpetaLog = "C:\\Logs";

            return rutaCarpetaLog;
        }

        private static string ObtenerRutaArchivoLog(string logFolderPath)
        {
            string logFileName = $"log_{DateTime.Now.ToString("yyyyMMdd")}.txt";
            string logFilePath = Path.Combine(logFolderPath, logFileName);

            if (!Directory.Exists(logFolderPath))
            {
                Directory.CreateDirectory(logFolderPath);
            }

            return logFilePath;
        }
    }
}
