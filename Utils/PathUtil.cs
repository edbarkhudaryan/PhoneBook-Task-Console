using System;
using System.IO;

namespace PhoneBook.Utils
{
	public class PathUtil
	{
        public static string GetFilePath(string filename)
        {
            var directory = System.AppContext.BaseDirectory.Split(Path.DirectorySeparatorChar);
            var slice = new ArraySegment<string>(directory, 0, directory.Length - 4);
            var path = Path.Combine(slice.ToArray());
            return "/" + path + "/" + filename;
        }

      
	}
}

