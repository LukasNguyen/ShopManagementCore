﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleShopCore.Data.EF.Extensions;
using SaleShopCore.Data.Entities;

namespace SaleShopCore.Data.EF.Configurations
{
    public class AnnouncementConfiguration : DbEntityConfiguration<Announcement>
    {
        public override void Configure(EntityTypeBuilder<Announcement> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(128).IsRequired();
        }
    }
}
