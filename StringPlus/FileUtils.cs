using System.IO;


namespace StringPlus
{
    public static class FileUtils
    {
        private const int DirToSolutionRoot = 3;
        private const char PathSeparator = '\\';
        private static string SolutionDir = FindSolutionDir();

        public static string ReadFile(string FileName)
        {
            string path = SolutionDir + FileName;
            return File.ReadAllText(path);
        }
        public static bool Write(string FileName, string text)
        {
            StreamWriter swFile = File.CreateText(SolutionDir + FileName);
            swFile.WriteLine(text);
            swFile.Close();
            return true;
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
    }
}
