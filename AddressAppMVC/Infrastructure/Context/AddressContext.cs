using AddressAppMVC.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AddressAppMVC.Infrastructure.Context
{
    public class AddressContext : DbContext
    {
        public AddressContext() : base("AddressContext")
        {

        }
        public virtual DbSet<Address> Addresses{ get; set; }
    }
}