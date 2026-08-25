using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthDesk_View_ProjectConstructionStatusPhotographs
    {
        public long ProjectPhotographs_IndexID { get; set; }
        public long ProjectPhotographs_ID { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public long ProjectPhotographsRelated_Project_ID { get; set; }
        
        public long Promoter_ID { get; set; }

        [Required]
        [Display(Name = "Select Option")]
        public int TypeRelated_BuildingTowerBlock_ComArea_AdvtProspectus_Code { get; set; }
        [Required]
        [Display(Name = "Type Name")]
        public string TypeRelated_BuildingTowerBlock_ComArea_AdvtProspectus_Name { get; set; }

        [Display(Name = "Building/ Tower/ Block Name")]
        public string BuildingTowerBlock_InfoCode { get; set; }
        [Display(Name = "Construction Title")]
        public string BuildingTowerBlock_InfoName { get; set; }
        [Display(Name = "Building/ Tower/ Block Floors Number")]
        [Range(0,500)]
        public int BuildingTowerBlock_FloorsNumber { get; set; }
        [Display(Name = "Photograph of Floors Type")]
        public string BuildingTowerBlock_PhotographType { get; set; }

        [Required]
        [Display(Name = "Photograph Title")]
        [StringLength(150, MinimumLength = 4)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,.\s]{1,150}$", ErrorMessage = "Special characters are not allowed. Maximum length is 150")]
        public string Photographs_Title { get; set; }

        //[Required]
        [Display(Name = "Photograph Click Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Photographs_ClickDate { get; set; }

        public string Photographs_FileSize { get; set; }
        public string Photographs_FileFormat { get; set; }
        public string Photographs_FilePath { get; set; }
        public string Photographs_FileName { get; set; }
        public int Photographs_IsGroup { get; set; } 

        [Display(Name = "Remarks If Any")]
        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        [RegularExpression(@"^[/\0-9a-zA-Z''-'-,\s]{1,300}$", ErrorMessage = "Special characters are not allowed. Maximum length is 300")]
        public string Remarks_IfAny { get; set; }

        public string A_column { get; set; }
        public string B_column { get; set; }
        public string C_column { get; set; }
        public long D_column { get; set; }

        public int IsActive { get; set; }
        public int IsDraft { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }

        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }


        public int IsDraftListAdvtPhotograph { get; set; }  
              

        public List<ClsPrp_AuthDesk_View_ProjectConstructionStatusPhotographs> prpongoing { get; set; }
        public ClsPrp_AuthDesk_View_ProjectConstructionStatusPhotographs()
        {
            prpongoing = new List<ClsPrp_AuthDesk_View_ProjectConstructionStatusPhotographs>();
        }
        public List<Clsprp_AuthDesk_View_ProjectDocuments> ProjectDocumentsList { get; set; }
    }
}