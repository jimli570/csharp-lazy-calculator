using System.Collections.Generic;

namespace Calculator.command
{
    public class PrintCommand : ICommand<CommandTypes>
    {
        public string Command { get; private set; }
        public string RegisterName { get; private set; }
        public string Value { get; private set; }

        public CommandTypes CommandType { get; private set; }

        public PrintCommand(string command)
        {
            Command = command;
            RegisterName = Command.Split(" ")[1];
            Value = "";

            CommandType = CommandTypes.PRINT;
        }

        // Just to comply with interface
        public Dictionary<string, int> Execute(Dictionary<string, int> register)
        {
            return register;
        }
    }
}
