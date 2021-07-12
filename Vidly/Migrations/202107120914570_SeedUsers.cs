namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'b33f62e2-816c-4c83-9f4d-03e4d51d5d1f', N'administrator@vidly.com', 0, N'AGf46pQvC7tiQmiShc1zIHPwXsz2bXW8/lssv2/FGzBeq3HRQwyxckczYd8LFPhvKg==', N'b2598282-f16a-482d-a565-d8452bdd585c', NULL, 0, 0, NULL, 1, 0, N'administrator@vidly.com');
                    INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'fcb6ad0d-4262-4104-9769-8e521eb4112e', N'guest@vidly.com', 0, N'AFtGIR15mZvumdZEk3GbGjp6FJ7ZR0pKcoyo7WvYnPWwxECnIVJ7EsXE9pxqMTtgTQ==', N'fedb1878-dc09-4664-a3a2-f738ec040402', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com');
                    
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'49ed6617-997e-4b15-a815-d9186fb4acb3', N'CanManageMovies');
                    
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3b693c8c-4430-4deb-8d13-f512c4f53cb2', N'49ed6617-997e-4b15-a815-d9186fb4acb3');
            ");
        }

        public override void Down()
        {
        }
    }
}
