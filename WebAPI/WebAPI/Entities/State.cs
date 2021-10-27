using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Entities
{
    public partial class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public string QualifiedLizards { get; set; }
    }
}
