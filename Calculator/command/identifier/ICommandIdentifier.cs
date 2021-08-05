using System.Collections.Generic;

namespace Calculator.command.identifier
{
    public interface ICommandIdentifier<T>
        where T : System.Enum
    {
        T Identify(string commandline);
    }
}
