using System.IO;

namespace Tetris
{
    class Serializer
    {
        public static int getHighScore()
        {
            if (!File.Exists("highscore.txt")) return 0;
            StreamReader sr = new StreamReader("highscore.txt");
            return int.Parse(sr.ReadLine());
        }
        public static void setHighScore(int s)
        {
            StreamWriter sw = new StreamWriter("highscore.txt");
            sw.WriteLine(s);
            sw.Close();
        }
    }
}
