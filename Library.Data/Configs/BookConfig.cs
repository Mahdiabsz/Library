using Library.DomainClasses.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Configs
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //builder.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            //builder.HasOne(x => x.Professor).WithOne(x => x.ProfessorDetail).HasForeignKey<ProfessorDetail>(b => b.ProfessorId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.Name)
                .HasMaxLength(100);
        }
    }
}
