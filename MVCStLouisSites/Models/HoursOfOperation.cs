using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Models
{
    public class HoursOfOperation : IModel
    {
        // Id from the IModel interface
        public int Id { set; get; }

        public string DayOfWeek { get; set; }
        public string OpenTime1 { get; set; }
        public string CloseTime1 { get; set; }
        public string OpenTime2 { get; set; }
        public string CloseTime2 { get; set; }
        public string OpenTime3 { get; set; }
        public string CloseTime3 { get; set; }

        // foreign key
        //public int AttractionId { get; set; }
        // navigation property
        //public Attraction Attaction { get; set; }
    }
}
