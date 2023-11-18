using DataModel.OccupationEntities;
using System;
using System.Collections.Generic;

namespace DataModel.RatingEntities
{
    public class Rating
    {
        public int RatingId { get; set; } // RatingId (Primary key)
        public string RatingName { get; set; } // Rating (length: 50)
        public decimal? Factor { get; set; } // Factor
        public string CreatedBy { get; set; } // CreatedBy (length: 50)
        public DateTime? CreatedDate { get; set; } // CreatedDate

        // Reverse navigation

        /// <summary>
        /// Child tblOccupations where [tblOccupation].[RatingId] point to this entity (FK_tblOccupation_tblRating)
        /// </summary>
        public virtual ICollection<Occupation> Occupations { get; set; } // tblOccupation.FK_tblOccupation_tblRating

        public Rating()
        {
            CreatedBy = "suser_sname()";
            CreatedDate = DateTime.Now;
            Occupations = new List<Occupation>();
        }
    }
}
