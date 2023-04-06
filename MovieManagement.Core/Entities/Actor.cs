using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Core.Entities
{
    public class Actor
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        //actor can be in many  movies one to many relationship
        public List<Movie>? Movies { get; set; }    

        //one to one relationshio an actor can have atleast one biography

        public Biography? Biography { get; set; }    
    }
}
