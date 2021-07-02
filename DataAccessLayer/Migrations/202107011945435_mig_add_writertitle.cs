namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_writertitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterTitle", c => c.String(maxLength: 50));
            DropColumn("dbo.Writers", "WriterTitel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterTitel", c => c.String(maxLength: 50));
            DropColumn("dbo.Writers", "WriterTitle");
        }
    }
}
