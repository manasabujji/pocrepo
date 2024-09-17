using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sujitha_POC.FileHandler
{
    public class FileLocations
    {
        public static string DownloadLocation;
        public static string GetFilesDownloadLoation()
        {

            try
            {
                DownloadLocation = GetProjectDirectory() + Path.DirectorySeparatorChar + "Downloads" + Path.DirectorySeparatorChar;
                if (!Directory.Exists(DownloadLocation))
                {
                    Directory.CreateDirectory(DownloadLocation);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }


            return DownloadLocation;
        }
        public static string GetProjectDirectory()
        {
            return Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        }
    }
}
