namespace NHibernate.MiniProfiler.MySql.Tests
{
    using StackExchange.Profiling.Data;

    using Xunit;

    public class ProfiledMySqlClientDriverTests
    {
        [Fact]
        public void CreateCommandReturnsProfiledDbCommand()
        {
            // Arrange
            var clientDriver = new ProfiledMySqlClientDriver();

            // Act
            var command = clientDriver.CreateCommand();

            // Assert
            Assert.IsType<ProfiledDbCommand>(command);
        }

        [Fact]
        public void CreateConnectionReturnsProfiledDbConnection()
        {
            // Arrange
            var clientDriver = new ProfiledMySqlClientDriver();

            // Act
            var connection = clientDriver.CreateConnection();

            // Assert
            Assert.IsType<ProfiledDbConnection>(connection);
        }
    }
}