using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Infra.Data.SqlServer.Mappings
{
    public class EmpresaMap : IEntityTypeConfiguration<EmpresaEntity>
    {
        public void Configure(EntityTypeBuilder<EmpresaEntity> builder)
        {
            //nome da tabela
            builder.ToTable("Empresa");

            //chave primária
            builder.HasKey(e => e.Id);

            //campos
            builder.Property(e => e.Id)
                .HasColumnName("Id");

            builder.Property(e => e.RazaoSocial)
                .HasColumnName("RazaoSocial")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.NomeFantasia)
                .HasColumnName("NomeFantasia")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Cnpj)
                .HasColumnName("Cnpj")
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}
