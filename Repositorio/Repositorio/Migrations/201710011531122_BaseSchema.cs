namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        Street = c.String(maxLength: 250),
                        Number = c.Int(nullable: false),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Type = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        Usuario_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .ForeignKey("dbo.Usuarios", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Age = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "UserId", "dbo.Usuarios");
            DropForeignKey("dbo.Addresses", "Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.Addresses", new[] { "Usuario_Id" });
            DropIndex("dbo.Addresses", new[] { "UserId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Addresses");
        }
    }
}
