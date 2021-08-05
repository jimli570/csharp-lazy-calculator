using NUnit.Framework;
using Calculator.command;
using System.Collections.Generic;

namespace MathMultCommandTest
{
    [TestFixture]
    class MathMultCommandTest
    {
        [TestCase("b multiply a", "b")]
        [TestCase("c multiply b", "c")]
        public void MathMultCommandRegisterNameTest(string commandline, string expected)
        {
            MathMultCommand command = new MathMultCommand(commandline);
            Assert.That(command.RegisterName, Is.EqualTo(expected));
        }

        [TestCase("a multiply a", "a")]
        [TestCase("a multiply b", "b")]
        public void MathMultCommandValueTest(string commandline, string expected)
        {
            MathMultCommand command = new MathMultCommand(commandline);
            Assert.That(command.Value, Is.EqualTo(expected));
        }


        [TestCase("a multiply b",  0,  5,   0)]
        [TestCase("a multiply b",  5,  0,   0)]
        [TestCase("a multiply b",  5,  5,  25)]
        [TestCase("a multiply b", -5,  5, -25)]
        [TestCase("a multiply b",  5, -5, -25)]
        [TestCase("a multiply b", -5, -5,  25)]
        public void MathMultCommandExecuteTest(string commandline, int aValue, int bValue, int expected)
        {
            MathMultCommand command = new MathMultCommand(commandline);

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
