using DataModel.RatingEntities;
using System;

namespace DataModel.OccupationEntities
{
    public class Occupation
    {
        public int OccupationId { get; set; } // OccupationId (Primary key)
        public string OccupationName { get; set; } // Occupation (length: 50)
        public int? RatingId { get; set; } // RatingId
        public string CreatedBy { get; set; } // CreatedBy (length: 50)
        public DateTime? CreatedDate { get; set; } // CreatedDate

        // Foreign keys

        /// <summary>
        /// Parent tblRating pointed by [tblOccupation].([RatingId]) (FK_tblOccupation_tblRating)
        /// </summary>
        public virtual Rating Ratings { get; set; } // FK_tblOccupation_tblRating

        public Occupation()
        {
            CreatedBy = "suser_sname()";
            CreatedDate = DateTime.Now;
        }
    }
}
