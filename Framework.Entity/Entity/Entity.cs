using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Entity.Entity
{
    public class Entity
    {
        public Guid Id { get; set; }
        
    }


    public class Entitybase
    {
        public Guid Id =Guid.NewGuid(); 
    }
}
