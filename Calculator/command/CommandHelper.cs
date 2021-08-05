namespace Calculator.command
{
    class CommandHelper
    {
        public static ICommand<CommandTypes> CreateCommand(CommandTypes commandType, string commandline)
        {
            ICommand<CommandTypes> command;

            switch (commandType) {
                case CommandTypes.MATH_ADD:
                    command = new MathAddCommand(commandline);
                    break;

                case CommandTypes.MATH_MULT:
                    command = new MathMultCommand(commandline);
                    break;

                case CommandTypes.MATH_SUB:
                    command = new MathSubCommand(commandline);
                    break;

                case CommandTypes.PRINT:
                    command = new PrintCommand(commandline);
                    break;

                default: // CommandTypes.UNKNOWN
                    command = new UnknownCommand(commandline);
                    break;
            }

            return command;
        }
    }
}
