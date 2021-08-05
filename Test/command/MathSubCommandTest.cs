using NUnit.Framework;
using Calculator.command;
using System.Collections.Generic;

namespace MathSubCommandTest
{
    [TestFixture]
    class MathSubCommandTest
    {
        [TestCase("b add a", "b")]
        [TestCase("c add b", "c")]
        public void MathSubCommandRegisterNameTest(string commandline, string expected)
        {
            MathSubCommand command = new MathSubCommand(commandline);
            Assert.That(command.RegisterName, Is.EqualTo(expected));
        }

        [TestCase("a substract a", "a")]
        [TestCase("a substract b", "b")]
        public void MathSubCommandValueTest(string commandline, string expected)
        {
            MathSubCommand command = new MathSubCommand(commandline);
            Assert.That(command.Value, Is.EqualTo(expected));
        }


        [TestCase("a substract b",  0,  5, -5)]
        [TestCase("a substract b",  5,  0,  5)]
        [TestCase("a substract b", -5, -5,  0)]
        [TestCase("a substract b", -5,  0, -5)]
        [TestCase("a substract b",  0, -5,  5)]
        public void MathSubCommandExecuteTest(string commandline, int aValue, int bValue, int expected)
        {
            MathSubCommand command = new MathSubCommand(commandline);

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
