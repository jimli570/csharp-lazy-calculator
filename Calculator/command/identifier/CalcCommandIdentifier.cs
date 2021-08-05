using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Calculator.command.identifier
{
    // Regexps for selecting 1st, 2nd & 3d word/command/value
    //List<string> selectWord = new List<string>() { @"^([\w\-]+)", @"^([\w\-]+)", @"^([\w\-]+)" };

    public class CalcCommandIdentifier : ICommandIdentifier<CommandTypes>
    {
        public readonly static Dictionary<CommandTypes, string> TYPE_COMMAND = new Dictionary<CommandTypes, string> {
            { CommandTypes.MATH_ADD,    "add" },
            { CommandTypes.MATH_SUB,    "substract" },
            { CommandTypes.MATH_MULT,   "multiply" },
            { CommandTypes.PRINT,       "print" }
        };

        public readonly static Dictionary<string, CommandTypes> COMMAND_TYPE = new Dictionary<string, CommandTypes> {
            { TYPE_COMMAND[CommandTypes.MATH_ADD],  CommandTypes.MATH_ADD },
            { TYPE_COMMAND[CommandTypes.MATH_SUB],  CommandTypes.MATH_SUB },
            { TYPE_COMMAND[CommandTypes.MATH_MULT], CommandTypes.MATH_MULT },
            { TYPE_COMMAND[CommandTypes.PRINT],     CommandTypes.PRINT }
        };

        public readonly static Dictionary<string, int> COMMAND_POSITION = new Dictionary<string, int> {
            { TYPE_COMMAND[CommandTypes.MATH_ADD],  1 },
            { TYPE_COMMAND[CommandTypes.MATH_SUB],  1 },
            { TYPE_COMMAND[CommandTypes.MATH_MULT], 1 },
            { TYPE_COMMAND[CommandTypes.PRINT],     0 },
        };

        public readonly static Dictionary<int, List<string>> COMMAND_LEN = new Dictionary<int, List<string>> {
            { 2, new List<string> { TYPE_COMMAND[CommandTypes.PRINT] } },
            { 3, new List<string> {
                TYPE_COMMAND[CommandTypes.MATH_ADD],
                TYPE_COMMAND[CommandTypes.MATH_SUB],
                TYPE_COMMAND[CommandTypes.MATH_MULT] } }
        };

        public CommandTypes Identify(string commandline)
        {
            string[] commandlineArr = commandline.Split(" ");

            int commandLen = commandlineArr.Length;
            bool validLength = COMMAND_LEN.ContainsKey(commandLen);
            bool isAlphaNumerical = Regex.IsMatch(commandline.Replace(" ", ""), "^[a-zA-Z0-9]*$");

            bool commandFound = false;
            string foundCommand = "";

            if (validLength && isAlphaNumerical) {
                List<string> potentiallyValidCommands = COMMAND_LEN[commandLen];

                foreach (string potentialCommand in potentiallyValidCommands) {
                    commandFound = CheckPotentialCommand(potentialCommand, commandlineArr);

                    if(commandFound) {
                        foundCommand = potentialCommand;
                        break;
                    }
                }
            }

            CommandTypes commandType = commandFound ? 
                COMMAND_TYPE[foundCommand] : CommandTypes.UNKNOWN;

            return commandType;
        }

        private bool CheckPotentialCommand(string potentialCommand, string[] commandlineArr)
        {
            string commandStr = commandlineArr[COMMAND_POSITION[potentialCommand]];
            bool validCommand = (potentialCommand == commandStr);

            return validCommand;
        }
    }
}
