using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Infra.Data.SqlServer.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            //nome da tabela
            builder.ToTable("Usuario");

            //chave primária
            builder.HasKey(u => u.Id);

            //mapeamento dos campos
            builder.Property(u => u.Id)
                .HasColumnName("Id");

            builder.Property(u => u.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasColumnName("Senha")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.DataCriacao)
                .HasColumnName("DataCriacao")
                .HasColumnType("date")
                .IsRequired();
        }
    }
}
