using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Contracts.DataAnnotation
{

   
    public  class Annotation
    {
        public Annotation() 
        { 

        }

        public Annotation IsRequired()
        {
            return this;
        }
        public Annotation HasMaxLength()
        {
            return this;
        } 
        public Annotation HasEmailAddress()
        {
            return this;
        } 
    }
}
