using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
namespace Tetris
{
    class Serializer
    {
        public static int getHighScore()
        {
            int data = 0;
            try
            {

                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Mabat\Tetris", true);
                data = (int)key.GetValue("highscore");
                key.Close();
            }
            catch
            {
                ConfigureDirectory();
            }
            return data;
        }
        public static void setHighScore(int s)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Mabat\Tetris", true);
                key.SetValue("highscore", s);
            }
            catch
            {
                ConfigureDirectory();
            }
        }
        private static void ConfigureDirectory()
        {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software", true);
                key.CreateSubKey("Mabat");
                key = Registry.CurrentUser.OpenSubKey(@"Software\Mabat", true);
                key.CreateSubKey("Tetris");
                key = Registry.CurrentUser.OpenSubKey(@"Software\Mabat\Tetris", true);
                key.SetValue("highscore", 0);
                key.Close();
        }
        //public static int getHighScore()
        //{
        //    if (!File.Exists("highscore.txt")) {
        //        File.Create("highscore.txt");
        //        return 0;
        //    }
        //    try
        //    {
        //        StreamReader sr = new StreamReader("highscore.txt");
        //        string line = sr.ReadLine();
        //        sr.Close();
        //        return Int32.Parse(line);
        //    }
        //    catch { }return 0;
        //}
        //public static void setHighScore(int s)
        //{
        //    StreamWriter sw = new StreamWriter("highscore.txt");
        //    sw.WriteLine(s.ToString());
        //    sw.Close();
        //}
    }
}
