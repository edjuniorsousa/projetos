namespace ProjetoDDD.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Experiencia",
                c => new
                    {
                        ExperienciaId = c.Int(nullable: false, identity: true),
                        PessoaId = c.Int(nullable: false),
                        Tecnologia = c.String(nullable: false, maxLength: 150, unicode: false),
                        TempoExperiencia = c.Int(nullable: false),
                        DetalheExperiencia = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ExperienciaId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        PessoaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        ExperienciaTotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaId);
            
            CreateTable(
                "dbo.ExperienciaEmpresa",
                c => new
                    {
                        ExperienciaEmpresaId = c.Int(nullable: false, identity: true),
                        PessoaId = c.Int(nullable: false),
                        Empresa = c.String(nullable: false, maxLength: 150, unicode: false),
                        Cargo = c.String(nullable: false, maxLength: 150, unicode: false),
                        DataInicio = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                        DetalheExperiencia = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ExperienciaEmpresaId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.Formacao",
                c => new
                    {
                        FormacaoId = c.Int(nullable: false, identity: true),
                        PessoaId = c.Int(nullable: false),
                        Curso = c.String(nullable: false, maxLength: 150, unicode: false),
                        Status = c.String(nullable: false, maxLength: 150, unicode: false),
                        DataConclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FormacaoId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .Index(t => t.PessoaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Formacao", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.ExperienciaEmpresa", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Experiencia", "PessoaId", "dbo.Pessoa");
            DropIndex("dbo.Formacao", new[] { "PessoaId" });
            DropIndex("dbo.ExperienciaEmpresa", new[] { "PessoaId" });
            DropIndex("dbo.Experiencia", new[] { "PessoaId" });
            DropTable("dbo.Formacao");
            DropTable("dbo.ExperienciaEmpresa");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Experiencia");
        }
    }
}
