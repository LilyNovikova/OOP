using System.IO;

namespace kurs_part3
{
    public class FileUtils
    {
        private const int DirToSolutionRoot = 3;
        private const char PathSeparator = '\\';
        private static string SolutionDir = FindSolutionDir();

        //чтение содержимого файла
        public static string[] ReadText(string InputFileName)
        {
             return File.ReadAllLines(SolutionDir+ InputFileName);
        }

        //поиск корневой директории проекта
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
