namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Genres (Name) VALUES('Horror')");
            Sql("Insert Into Genres (Name) VALUES('Drama')");
            Sql("Insert Into Genres (Name) VALUES('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
