using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Infra.Data.SqlServer.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<FuncionarioEntity>
    {
        public void Configure(EntityTypeBuilder<FuncionarioEntity> builder)
        {
            builder.ToTable("Funcionario");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnName("Id");

            builder.Property(f => f.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(f => f.Sexo)
                .HasColumnName("Sexo")
                .IsRequired();

            builder.Property(f => f.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(f => f.Cpf)
                .HasColumnName("Cpf")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(f => f.DataAdmissao)
                .HasColumnName("DataAdmissao")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(f => f.Situacao)
                .HasColumnName("Situacao")
                .IsRequired();

            builder.Property(f => f.EmpresaId)
                .HasColumnName("EmpresaId")
                .IsRequired();

            #region Relacionamentos

            builder.HasOne(f => f.Empresa) //Funcionario TEM 1 Empresa
                .WithMany(e => e.Funcionarios) //Empresa TEM N Funcionarios
                .HasForeignKey(f => f.EmpresaId); //Chave estrangeira

            #endregion
        }
    }
}
