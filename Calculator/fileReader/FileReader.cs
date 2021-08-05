using System.Collections.Generic;
using System.Text;

namespace Calculator.fileReader
{
    /* Reads textfiles, where each line corresponds to one command */
    public class FileReader : IReader<string>
    {
        private readonly static Encoding encoding = Encoding.UTF8;

        public List<string> Read(string filePath)
        {
            System.IO.StreamReader fileReader = new System.IO.StreamReader( filePath, encoding );
            List<string> commands = ReadLines( fileReader );

            return commands;
        }

        private List<string> ReadLines(System.IO.StreamReader fileReader)
        {
            List<string> commands = new List<string>();

            string line;
            while ( (line = fileReader.ReadLine()) != null ) {
                commands.Add( line );
            }

            return commands;
        }
    }
}
