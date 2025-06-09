using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace litfibretestapi.Models.Data
{
    public abstract class DatabaseObject
    {
        public abstract string Id { get; set; }
    }
}