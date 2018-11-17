using System;
using System.IO;

namespace OrbitalDrydock.IO
{
    public class FileUtil
    {
        public static string readFile(string relativePath)
        {
            string pathFile = Path.GetFullPath(relativePath);
            if (File.Exists(pathFile))
            {
                try
                {
                    string fileContents;
                    using (StreamReader streamReader = new StreamReader(pathFile))
                    {
                        fileContents = streamReader.ReadToEnd();
                    }
                    return fileContents;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }
        public static bool write(string relativePath, string text)
        {
            string path = Path.GetFullPath(relativePath);
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path, false))
                {
                    streamWriter.WriteLine(text);
                    streamWriter.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
    }
}
