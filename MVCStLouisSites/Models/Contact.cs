using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Models
{
    public class Contact : IModel
    {
        // Id from the IModel interface
        public int Id { set; get; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TitleName { get; set; }
        public string PhonePublic { get; set; }
        public string PhonePrivate { get; set; }
        public string EmailPublic { get; set; }
        public string EmailPrivate { get; set; }

        // foreign key
        //public int AttractionId { get; set; }
        // navigation property
        //public Attraction Attaction { get; set; }
    }
}
