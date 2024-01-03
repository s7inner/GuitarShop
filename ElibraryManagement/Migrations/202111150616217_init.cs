namespace ElibraryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.guitar_fav_master_tbl",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        guitar_name = c.String(),
                        guitar_type = c.String(),
                        guitar_color = c.String(),
                        guitar_weight = c.String(),
                        guitar_material = c.String(),
                        number_of_strings = c.String(),
                        guitar_price = c.String(),
                        guitar_img_link = c.String(),
                        publisher_name = c.String(),
                        publish_date = c.String(),
                        guitar_description = c.String(),
                        sessionUsername = c.String(),
                        main_table_id = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.guitar_master_tbl",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        guitar_name = c.String(),
                        guitar_type = c.String(),
                        guitar_color = c.String(),
                        guitar_weight = c.String(),
                        guitar_material = c.String(),
                        number_of_strings = c.String(),
                        guitar_price = c.String(),
                        guitar_img_link = c.String(),
                        publisher_name = c.String(),
                        publish_date = c.String(),
                        guitar_description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.guitar_master_tbl");
            DropTable("dbo.guitar_fav_master_tbl");
        }
    }
}
