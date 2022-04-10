using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoClocker.Models.Configs
{
    internal class SuccessItemConfig : IEntityTypeConfiguration<SuccessItem>
    {
        public void Configure(EntityTypeBuilder<SuccessItem> builder)
        {
            builder.ToTable("T_SuccessItems");
            builder.HasKey(x => x.Id);  
            builder.HasOne<DayCount>(s=>s.DayCount).WithMany(d=>d.SuccessItems).IsRequired();
        }
    }
}
