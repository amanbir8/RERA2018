using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRUD.Models.Promoter;

namespace CRUD.Models.Complaint
{
    public class ClsPrp_ComplaintForm_ProjectStatusRegdUnRegd
    {
        public long Complaint_IndexID { get; set; }
        public string ComplaintProjectStatus { get; set; }
        public string ComplaintDocumentTrack { get; set; }
        public string ColumnA { get; set; }

        public List<ClsPrp_ComplaintForm_ProjectStatusRegdUnRegd> ProjectProjectStatusRegdUnRegd { get; set; }
        public ClsPrp_ComplaintForm_ProjectStatusRegdUnRegd()
        {
            ProjectProjectStatusRegdUnRegd = new List<ClsPrp_ComplaintForm_ProjectStatusRegdUnRegd>();
        }
    }
}