namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdddressNumberFieldChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "Number", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "Number", c => c.Int(nullable: false));
        }
    }
}
