using System.Collections.Generic;

namespace Calculator.command
{
    public class UnknownCommand : ICommand<CommandTypes>
    {
        public string Command { get; private set; }
        public string RegisterName { get; private set; }
        public string Value { get; private set; }

        public CommandTypes CommandType { get; private set; }

        public UnknownCommand(string command)
        {
            Command = command;
            CommandType = CommandTypes.UNKNOWN;
        }

        // Just to comply with interface
        public Dictionary<string, int> Execute(System.Collections.Generic.Dictionary<string, int> register)
        {
            return register;
        }
    }
}
