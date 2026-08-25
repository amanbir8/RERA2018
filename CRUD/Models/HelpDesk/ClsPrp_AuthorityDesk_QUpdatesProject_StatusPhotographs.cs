using CRUD.Models.Promoter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.HelpDesk
{
    public class ClsPrp_AuthorityDesk_QUpdatesProject_StatusPhotographs
    {
        public long QUpdateProjectPhotographs_IndexID { get; set; }
        public long QUpdateProjectPhotographs_ID { get; set; }

        public long Related_ProjectPhotographsIndexID { get; set; }
        public long Related_ProjectPhotographsID { get; set; }

        [Display(Name = "Upload Status")]
        public int IsQuarterlyData { get; set; }
        public int IsQuarterlyDataValid { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public long ProjectPhotographsRelated_Project_ID { get; set; }

        [Required]
        [Display(Name = "Year Option")]
        public string QUpdatePhotographs_Year { get; set; }

        [Required]
        [Display(Name = "Quarterly Option")]
        public string QUpdatePhotographs_QuarterName { get; set; }

        public long Related_Promoter_ID { get; set; }

        [Required]
        [Display(Name = "Select Option")]
        public int BuildingTowerBlock_ComArea_ConStatusCode { get; set; }
        [Required]
        [Display(Name = "Type Name")]
        public string BuildingTowerBlock_ComArea_ConStatusName { get; set; }

        [Display(Name = "Building/ Tower/ Block Name")]
        public string BuildingTowerBlock_InfoCode { get; set; }
        [Display(Name = "Construction Title")]
        public string BuildingTowerBlock_InfoName { get; set; }
        [Display(Name = "Building/ Tower/ Block Floors Number")]
        [Range(0,500)]
        public int BuildingTowerBlock_FloorsNumber { get; set; }

        //[Required]
        [Display(Name = "Type of Building/ Tower/ Block")]
        [StringLength(150)]
        public string BuildingTowerBlock_Type { get; set; }

        [Display(Name = "Photograph Category")]
        [StringLength(150)]
        public string BuildingTowerBlock_PhotographType { get; set; }

        [Required]
        [Display(Name = "Photograph Title (Status)")]
        [StringLength(150)]        
        public string Photographs_Title { get; set; }

        [Required]
        [Display(Name = "Status of Construction")]
        [StringLength(150)]
        public string Photographs_Status { get; set; }

        //[Required]
        [Display(Name = "Date of Geo-location Points (Photograph)")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Photographs_ClickDate { get; set; }

        public string Photographs_FileSize { get; set; }
        public string Photographs_FileFormat { get; set; }
        public string Photographs_FilePath { get; set; }
        public string Photographs_FileName { get; set; }
        public int Photographs_IsGroup { get; set; }

        public string PhotoGeoPoint_Navigator { get; set; }
        public string PhotoGeoPoint_Reference { get; set; }
        public string PhotoGeoPoint_Bounds { get; set; }
        public string PhotoGeoPoint_GeometryType { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Invalid Longitude; Maximum Six Decimal Points.")]
        [Range(50, 999999.999999)]
        [Display(Name = "Longitude of location (in decimal)")]
        public double PhotoGeoPoint_Longitude { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Invalid Latitude; Maximum Six Decimal Points.")]
        [Range(25, 999999.999999)]
        [Display(Name = "Latitude of location (in decimal)")]
        public double PhotoGeoPoint_Latitude { get; set; }

        [Required]
        [StringLength(90)]
        [Display(Name = "Longitude of location (in degree)")]
        public string PhotoGeoPoint_LongitudeX { get; set; }

        [Required]
        [StringLength(90)]
        [Display(Name = "Latitude of location (in degree)")]
        public string PhotoGeoPoint_LatitudeX { get; set; }

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
        public int IsLock { get; set; }
        public int IsRegisteredDiaryNumberLock { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifyBy { get; set; }
        public System.DateTime ModifyOn { get; set; }


        [Display(Name = "Quarter Name")]
        public string setQUpdateProject_QuarterName { get; set; }

        public long zipRelated_Promoter_ID { get; set; }
        public long zipRelated_Project_ID { get; set; }
        [Display(Name = "Project Diary Number")]
        public string zipProject_DiaryNumber { get; set; }
        [Display(Name = "Project Name")]
        public string zipProjectName { get; set; }
        [Display(Name = "Last Modified On")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? zipProjectLastModifiedOn { get; set; }
        public long zipQUpdateProject_RegDiaryNumber_ID { get; set; }
        [Display(Name = "QUP Diary Number")]
        public string zipQUpdateProject_RegDiaryNumber_Name { get; set; }
        [Display(Name = "Quarter Year")]
        public string zipQUpdateProject_Year { get; set; }
        [Display(Name = "Quarter Name")]
        public string zipQUpdateProject_QuarterName { get; set; }

        public Int32 zipQUpdateProject_YearValue { get; set; }
        public string zipQUpdateProject_QuarterNameValue { get; set; }
        [Display(Name = "Registration Number")]
        public string zipProject_RERAregistrationNumber { get; set; }
        [Display(Name = "Promoter Diary Number")]
        public string zipPromoter_DiaryNumber { get; set; }


        [Display(Name = "Range Option")]
        public int IsRangeValueDateInputFlag { get; set; }
        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_FromDate { get; set; }
        [Display(Name = "To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InputEntry_ToDate { get; set; }

        [Display(Name = "Select Quarter")]
        public int EventQuarter { get; set; }
        [Display(Name = "Select Year")]
        public int EventYear { get; set; }

        public List<ClsPrp_AuthorityDesk_QUpdatesProject_StatusPhotographs> prpongoing { get; set; }
        public ClsPrp_AuthorityDesk_QUpdatesProject_StatusPhotographs()
        {
            prpongoing = new List<ClsPrp_AuthorityDesk_QUpdatesProject_StatusPhotographs>();
        }
        
        //public List<ClsPrp_Project_BuildingTowerBlock_Construction> MasterBuilding { get; set; }

        //public List<Clsprp_Master_Project_InventoryList> MasterProjectInventoryList { get; set; }
        //public List<Clsprp_Master_Project_InventoryList> MasterProjectInventoryICommonList { get; set; }
        //public List<Clsprp_Master_Project_PhotographStatusTitleList> MasterProjectPhotographStatusList { get; set; }        
    }
}