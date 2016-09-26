namespace ProjetoDDD.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Firts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Senha = c.String(maxLength: 100, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Telefone = c.String(nullable: false, maxLength: 10, unicode: false),
                        Cidade = c.String(maxLength: 100, unicode: false),
                        Bairro = c.String(maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Livros",
                c => new
                    {
                        LivroId = c.Guid(nullable: false),
                        Titulo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Autor = c.String(nullable: false, maxLength: 100, unicode: false),
                        AnoLetivo = c.String(nullable: false, maxLength: 10, unicode: false),
                        Disciplina = c.String(nullable: false, maxLength: 50, unicode: false),
                        Disponível = c.Boolean(nullable: false),
                        ClienteId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.LivroId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livros", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Livros", new[] { "ClienteId" });
            DropTable("dbo.Livros");
            DropTable("dbo.Clientes");
        }
    }
}
