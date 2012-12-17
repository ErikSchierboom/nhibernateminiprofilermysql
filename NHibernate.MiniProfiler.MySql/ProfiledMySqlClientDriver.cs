namespace NHibernate.MiniProfiler.MySql
{
    using System.Data;
    using System.Data.Common;

    using NHibernate.Driver;

    using StackExchange.Profiling;
    using StackExchange.Profiling.Data;

    public class ProfiledMySqlClientDriver : MySqlDataDriver
    {
        public override IDbCommand CreateCommand()
        {
            return new ProfiledDbCommand(base.CreateCommand() as DbCommand, null, MiniProfiler.Current);
        }

        public override IDbConnection CreateConnection()
        {
            return new ProfiledDbConnection(base.CreateConnection() as DbConnection, MiniProfiler.Current);
        }
    }
}