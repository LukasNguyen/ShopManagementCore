﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleShopCore.Data.EF.Extensions;
using SaleShopCore.Data.Entities;

namespace SaleShopCore.Data.EF.Configurations
{
    public class PageConfiguration : DbEntityConfiguration<Page>
    {
        public override void Configure(EntityTypeBuilder<Page> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasMaxLength(255).IsRequired();
        }
    }
}
