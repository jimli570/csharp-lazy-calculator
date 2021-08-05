using NUnit.Framework;
using Calculator.command;
using Calculator.command.identifier;

namespace CalcCommandIdentifierTest
{
    class CalcCommandIdentifierTest
    {
        private ICommandIdentifier<CommandTypes> m_commandIdentifier;

        [SetUp]
        public void Setup()
        {
            m_commandIdentifier = new CalcCommandIdentifier();
        }

        [TestCase("a add 10",       CommandTypes.MATH_ADD)]
        [TestCase("b substract a",  CommandTypes.MATH_SUB)]
        [TestCase("b multiply a",   CommandTypes.MATH_MULT)]
        [TestCase("print b",        CommandTypes.PRINT)]
        [TestCase("    ",           CommandTypes.UNKNOWN)]
        [TestCase("b print",        CommandTypes.UNKNOWN)]
        [TestCase("multiply",       CommandTypes.UNKNOWN)]
        [TestCase("add saf asf",    CommandTypes.UNKNOWN)]
        [TestCase("b£ add 10",      CommandTypes.UNKNOWN)]
        public void IdentifyMathAddTest(string commandline, CommandTypes expected)
        {
            CommandTypes commandType = m_commandIdentifier.Identify(commandline);
            Assert.That(commandType, Is.EqualTo(expected));
        }
    }
}
