using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Models
{
    public class IconImage : IModel
    {
        // Id from the IModel interface
        public int Id { set; get; }

        public string IconImageFileName { get; set; }

        // navigation property - one IconImage-to-many-attractions
        public IList<Attraction> Attractions { get; set; }

    }
}
