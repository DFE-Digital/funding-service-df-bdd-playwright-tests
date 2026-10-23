using NUnit.Framework;

namespace DigitalForm_AutomationSuite.Helper
{
    public class AssertionHelper
    {
        public static void AssertTextEquals(string actual, string expected, string message = "")
        {
            Assert.That(actual.ToString(), Is.EqualTo(expected), message);
        }

        public static void AssertContains(string actual, string substring, string message = "")
        {
            Assert.That(actual, Does.Contain(substring).IgnoreCase);
        }

        public static void AssertTrue(bool condition, string message = "")
        {
            Assert.That(condition, Is.True, message);
        }

        public static void AssertEquals(string actual, string expected, string message = "")
        {
            Assert.That(actual, Is.EqualTo(expected), message);
        }

        public static void AssertNotEquals(string actual, string expected, string message = "")
        {
            Assert.That(actual, Is.Not.EqualTo(expected), message);
        }

        public static void AssertFalse(bool condition, string message = "")
        {
            Assert.That(condition, Is.False, message);
        }
    }
}

