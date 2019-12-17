using System.IO;

namespace Auto1
{
    public class FileUtils
    {
        private const int DirToSolutionRoot = 3;
        private const char PathSeparator = '\\';
        public static string SolutionDir { get; private set; } = FindSolutionDir();


        public static string[] ReadText(string InputFileName)
        {
             return File.ReadAllLines(SolutionDir+ InputFileName);
        }

        private static string FindSolutionDir()
        {
            string[] path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).Split(PathSeparator);
            string directory = null;
            if (path.Length > DirToSolutionRoot)
            {
                for (int i = 0; i < path.Length - DirToSolutionRoot; i++)
                {
                    directory += path[i] + PathSeparator;
                }
            }
            return directory;
        }

        public static void WriteText(string Text, string FileName)
        {
            StreamWriter SW = File.CreateText(SolutionDir + FileName);
            SW.WriteLine(Text);
            SW.Close();
        }
    }
}
