using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Config
{
    public class TodoInfoConfig : BaseConfig, IEntityTypeConfiguration<ToDoInfo>
    {
        public void Configure(EntityTypeBuilder<ToDoInfo> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(x => x.Description)
                .HasMaxLength(500);
        }
    }
}
