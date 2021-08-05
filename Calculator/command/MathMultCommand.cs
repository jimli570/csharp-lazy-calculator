using System.Collections.Generic;

namespace Calculator.command
{
    public class MathMultCommand : ICommand<CommandTypes>
    {
        public string Command { get; private set; }
        public string RegisterName { get; private set; }
        public string Value { get; private set; }

        public CommandTypes CommandType { get; private set; }

        public MathMultCommand(string command)
        {
            Command = command;
            string[] commandArr = Command.Split(" ");
            RegisterName = commandArr[0];
            Value = commandArr[2];

            CommandType = CommandTypes.MATH_MULT;
        }

        public Dictionary<string, int> Execute(Dictionary<string, int> register)
        {
            int lTerm = register.ContainsKey(RegisterName) ?
                register[RegisterName] : 0;

            int rTerm = register.ContainsKey(Value) ?
                register[Value] : int.Parse(Value);

            register[RegisterName] = lTerm * rTerm;

            return register;
        }
    }
}
