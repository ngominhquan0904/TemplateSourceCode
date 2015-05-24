using System.Configuration;
using System.IO;

namespace WindowServiceTemplate
{
    public class EdiFtpService : IEdiFtpService
    {
        /// <summary>
        /// orderLocation
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="mes"></param>
        /// <returns></returns>
        public string WriteOrderMessageFile(string fName, string mes)
        {
            //Save file to local computer
            var orderLocation = GetOrderLocation() + fName;
            FtpFileManager.FtpSynchManager.Instance.UploadFtpFile(orderLocation, mes);
            return orderLocation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scriptName"></param>
        /// <param name="script"></param>
        /// <returns>scriptLocation</returns>
        public string WriteTestScriptFile(string scriptName, string script)
        {
            var scriptLocation = GetOrderLocation() + scriptName;
            FtpFileManager.FtpSynchManager.Instance.UploadFtpFile(scriptLocation, script);
            return scriptLocation;
        }

        private static string GetOrderLocation()
        {
            var local = ConfigurationManager.AppSettings["localOrderFolder"];
            if (!Directory.Exists(local))
            {
                Directory.CreateDirectory(local);
            }
            return local;
        }

    }
}