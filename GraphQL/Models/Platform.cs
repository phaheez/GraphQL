using HotChocolate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Models
{
    public class Platform
    {
        public Platform()
        {
            Commands = new HashSet<Command>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string LicenseKey { get; set; }

        public virtual ICollection<Command> Commands { get; set; }
    }
}
