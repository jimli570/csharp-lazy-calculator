using NUnit.Framework;
using Calculator.command;
using System.Collections.Generic;

namespace CalcCommandIdentifierTest
{
    [TestFixture]
    class MathAddCommandTest
    {
        [TestCase("b add a", "b")]
        [TestCase("c add b", "c")]
        public void MathAddCommandRegisterNameTest(string commandline, string expected)
        {
            MathAddCommand command = new MathAddCommand(commandline);
            Assert.That(command.RegisterName, Is.EqualTo(expected));
        }

        [TestCase("a add a", "a")]
        [TestCase("a add b", "b")]
        public void MathAddCommandValueTest(string commandline, string expected)
        {
            MathAddCommand command = new MathAddCommand(commandline);
            Assert.That(command.Value, Is.EqualTo(expected));
        }


        [TestCase("a add b", 0,   5,   5)]
        [TestCase("a add b", 0,   0,   0)]
        [TestCase("a add b", 0,  -5,  -5)]
        [TestCase("a add b", 5,   5,  10)]
        [TestCase("a add b", 0,   5,   5)]
        [TestCase("a add b", 0,  -5,  -5)]
        [TestCase("a add b", -5, -5, -10)]
        public void MathAddCommandExecuteTest(string commandline, int aValue, int bValue, int expected)
        {
            MathAddCommand command = new MathAddCommand(commandline);

            Dictionary<string, int> register = new Dictionary<string, int>
            {
                [command.Value] = bValue,
                [command.RegisterName] = aValue
            };

            register = command.Execute(register);
            int result = register[command.RegisterName];

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
