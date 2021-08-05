using NUnit.Framework;
using Calculator.command;

namespace PrintCommandTest
{
    [TestFixture]
    class PrintCommandTest
    {
        [TestCase("print a", "")]
        [TestCase("print b", "")]
        public void PrintCommandValueTest(string commandline, string expected)
        {
            PrintCommand command = new PrintCommand(commandline);

            Assert.That(command.Value, Is.EqualTo(expected));
        }

        [TestCase("print a", "a")]
        [TestCase("print b", "b")]
        public void PrintCommandRegisterNameTest(string commandline, string expected)
        {
            PrintCommand command = new PrintCommand(commandline);

            Assert.That(command.RegisterName, Is.EqualTo(expected));
        }
    }
}
