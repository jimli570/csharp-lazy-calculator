using NUnit.Framework;
using Calculator.command;

namespace UnknowCommandTest
{
    class UnknownCommandTest
    {
        [TestCase("abcd", "abcd")]
        [TestCase("invalid command", "invalid command")]
        public void UnknownCommandCommandTest(string commandline, string expected)
        {
            UnknownCommand command = new UnknownCommand(commandline);

            Assert.That(command.Command, Is.EqualTo(expected));
        }
    }
}
