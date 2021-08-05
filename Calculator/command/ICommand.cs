using System.Collections.Generic;

namespace Calculator.command
{
    public enum CommandTypes
    {
        UNKNOWN, MATH_ADD, MATH_SUB, MATH_MULT, PRINT
    }

    public interface ICommand<T>
        where T : System.Enum
    {
        string Command { get; }
        string RegisterName { get; }
        string Value { get; }
        T CommandType { get; }

        Dictionary<string, int> Execute(Dictionary<string, int> register);
    }
}
