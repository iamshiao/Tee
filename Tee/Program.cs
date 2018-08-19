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

                string sentence = "";
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    for (int value; (value = Console.In.Read()) != -1;)
                    {
                        var word = Char.ConvertFromUtf32(value);

                        if (word == "\n" && Console.In.Peek() == -1)
                        {
                            writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss : ") + sentence);
                            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss : ") + sentence);
                            sentence = "";
                        }
                        else
                        {
                            sentence += word;
                        }
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
