namespace Carly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a7af0815-af94-4f5a-9e47-22689e444872', N'admin@carly.com', 0, N'AHUQkw187+HDY8SUMpyz1qF7CoiuemNW6Wj8aDWVQwNfG7PIT1ipY++LHdpZrMZw1A==', N'5403055a-c1b8-4e0a-a64b-c8f45c30951f', NULL, 0, 0, NULL, 1, 0, N'admin@carly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd80e6476-d629-4b4c-8c32-ebe5abe2dceb', N'guest@carly.com', 0, N'ADHngkvyoideV1AoTIfFJ9ex6O6BXVBcce1Uevpnn76a6PnsQJW30uU9LZTWWU4YWg==', N'3f87fde4-1336-437c-83dd-b81a22b5a647', NULL, 0, 0, NULL, 1, 0, N'guest@carly.com')
            
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd10ae2c8-3c1f-4cd2-8e15-b62435a33b0f', N'CanManageMovies')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a7af0815-af94-4f5a-9e47-22689e444872', N'd10ae2c8-3c1f-4cd2-8e15-b62435a33b0f')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
