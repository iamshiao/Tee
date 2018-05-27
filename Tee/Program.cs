using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tee
{
    class Tee
    {
        static int Main(string[] args)
        {
            try
            {
                string logFilePath = Path.GetFullPath(args[0]);

                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    for (int value; (value = Console.In.Read()) != -1;)
                    {
                        var word = Char.ConvertFromUtf32(value);
                        Console.Write(word);
                        writer.Write(word);
                    }
                }
            }
            catch (Exception)
            {
                return 1;
            }
            return 0;
        }
    }
}
