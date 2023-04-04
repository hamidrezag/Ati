using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Config
{
    public abstract class BaseConfig
    {
        public virtual void ConfigureEntity<T>(EntityTypeBuilder<T> builder) where T : class, IBaseModel, new()
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreateDateTime).HasDefaultValueSql("getdate()");
        }
    }
}
