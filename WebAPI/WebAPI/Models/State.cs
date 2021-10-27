using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public string QualifiedLizards { get; set; }

        public State(int id, string stateName, string qualifiedLizards)
        {
            Id = id;
            StateName = stateName;
            QualifiedLizards = qualifiedLizards;


        }
        public State()
        {

        }


    }



}
