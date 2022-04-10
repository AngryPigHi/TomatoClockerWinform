using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoClocker.Models.Configs
{
    internal class FailedItemConfig : IEntityTypeConfiguration<FailedItem>
    {
        public void Configure(EntityTypeBuilder<FailedItem> builder)
        {
            builder.ToTable("T_FailedItems");
            builder.HasKey(x => x.Id);
            builder.HasOne<DayCount>(d => d.DayCount).WithMany(d=>d.FailedItems).IsRequired();
        }
    }
}
