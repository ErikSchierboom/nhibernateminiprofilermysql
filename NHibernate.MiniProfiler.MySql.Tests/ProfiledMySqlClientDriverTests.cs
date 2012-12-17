namespace NHibernate.MiniProfiler.MySql.Tests
{
    using NUnit.Framework;

    using StackExchange.Profiling.Data;

    [TestFixture]
    public class ProfiledMySqlClientDriverTests
    {
        [Test]
        public void CreateCommandReturnsProfiledDbCommand()
        {
            // Arrange
            var clientDriver = new ProfiledMySqlClientDriver();

            // Act
            var command = clientDriver.CreateCommand();

            // Assert
            Assert.IsInstanceOf<ProfiledDbCommand>(command);
        }

        [Test]
        public void CreateConnectionReturnsProfiledDbConnection()
        {
            // Arrange
            var clientDriver = new ProfiledMySqlClientDriver();

            // Act
            var connection = clientDriver.CreateConnection();

            // Assert
            Assert.IsInstanceOf<ProfiledDbConnection>(connection);
        }
    }
}