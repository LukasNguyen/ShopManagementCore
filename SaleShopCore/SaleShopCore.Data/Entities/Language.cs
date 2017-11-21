using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SaleShopCore.Data.Enums;
using SaleShopCore.Data.Interfaces;
using SaleShopCore.Infrastructure.SharedKernel;

namespace SaleShopCore.Data.Entities
{
    [Table("Languages")]
    public class Language : DomainEntity<string>, ISwitchable
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public string Resources { get; set; }

        public Status Status { get; set; }
    }
}
