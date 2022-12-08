using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoClocker.Models.Configs
{
    internal class DayCountConfig : IEntityTypeConfiguration<DayCount>
    {
        public void Configure(EntityTypeBuilder<DayCount> builder)
        {
            builder.ToTable("T_DayCount");
            builder.HasKey(x => x.Id);
        }
    }
}
