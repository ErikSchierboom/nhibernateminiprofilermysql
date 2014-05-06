# NHibernate MySQL MiniProfiler driver
The [MiniProfiler](http://miniprofiler.com/) library allows you to easily profile your application. It also has support for database profiles, but out of the box only Entity Framework and ADO.NET are supported. This leaves out [NHibernate](http://nhforge.org/). This project shows how to allow allow MiniProfiler to also integrate with NHibernate. The project includes a client driver for MySQL, but it is easy to modify this code to support any client NHibernate supports.

## Implementation
As this library is meant to connect NHibernate with the MiniProfiler, you first have to have a project that references both libraries. You can install them using NuGet as follows:

    Install-Package NHibernate
    Install-Package MiniProfiler 

Then you need to include this project in your project. You can choose between two paths:

 1. You compile the **NHibernate.MiniProfiler.MySql** and reference the built DLL from your project
 2. You include the [ProfiledMySqlClientDriver](NHibernate.MiniProfiler.MySql/ProfiledMySqlClientDriver.cs) file in your project.

After you have finished these steps, you need to do just one more thing: let NHibernate know it should use our custom `ProfiledMySqlClientDriver` as the driver for MySQL connections. You can do this by setting the `Driver` property of the `Configuration` instance you are using. This can look something like this: 

```c#
var mySqlConfiguration = new Configuration();
mySqlConfiguration.DataBaseIntegration(c =>
    {
        c.Dialect<NHibernate.Dialect.MySQL5Dialect>();
        c.Driver<ProfiledMySqlClientDriver>();
        c.ConnectionStringName = this.ConnectionStringName;
    });
```

And you are ready to go! Any MySQL queries executed by NHibernate will now automatically be profiled by the MiniProfiler.

## License
[Apache License 2.0](LICENSE.md)
