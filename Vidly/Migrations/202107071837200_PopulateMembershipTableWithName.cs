namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTableWithName : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET Name = 'Pay as You Go' WHERE Id = 1");
            Sql("Update MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
            Sql("Update MembershipTypes SET Name = 'Trimesterly' WHERE Id = 3");
            Sql("Update MembershipTypes SET Name = 'Anually' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
