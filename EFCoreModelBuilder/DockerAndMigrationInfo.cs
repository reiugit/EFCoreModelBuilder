namespace EFCoreModelBuilder
{
    public static class DockerAndMigrationInfo
    {
        public static object Info => new
        {
            Info = " This application needs a local SqlServer-Database. ",
            _ = "",
            Todo1 = " 1.) Use  'DOCKER compose up --detach'  to create a local SqlServer instance. ",
            Todo2 = " 2.) Use  'EFCore Migrations' to create a valid database: ",
            Todo3 = " -- with  'ef migrations database update'  in EFCore Tools ",
            Todo4 = " -- or  'update-database'  in the Package Manager Console ",
        };
    }
}
