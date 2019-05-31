using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Models
{
    public class GeneralInformation
    {
        // Id from the IModel interface
        public int Id { set; get; }

        public string Name { get; set; }
        public string Information { get; set; }
    }
}
