DROP PROCEDURE IF EXISTS `Display_Rera_Project_RefRegistrationsRERADetail_ForDesk`;
DELIMITER ;;
CREATE DEFINER=`sa`@`%` PROCEDURE `Display_Rera_Project_RefRegistrationsRERADetail_ForDesk`(
   p_ProjectID bigint,
   p_PromoterID bigint,
   p_ProjectDiaryNumber varchar(120),
   p_ProjectName varchar(120),
   p_UserRole varchar(120)
)
BEGIN

-- ONLINE REGISTERED PROJECT CASE
select
    a.Project_RERAnumber_DiaryNumber_IndexID as Project_RefRegistration_regRERA_IndexID,
    a.Project_RERAnumber_DiaryNumber_ID as Project_RefRegistration_regRERA_ID,
    a.ProjectRegDiaryNumber_ID as ProjectRef_ID,
    a.ProjectRegDiaryNumber_Name as ProjectRef_Sequence,
    a.ProjectRegDiaryNumber_NameYear as RelatedProject_Year,
    a.Project_ID as Related_Project_ID,
    a.Promoter_ID as Related_Promoter_ID,
    a.Project_ID as Related_Project_Type,
    a.User_ID as Related_UserID,
    a.ExistingRegistration as Related_RERAnumberRegistration,
    202 as Related_Project_RefRegistrations_RERA_ID,
    a.RERAnumberRegistration as RERAregistration_Number,
    a.RERAnumberIssueDate as RERAregistration_IssueDate,
    a.RERAnumberRegUptoDate as RERAregistration_ExpiryDate,
    a.RemarksIfAny as RemarksIfAny,
    a.IsActive as IsActive,
    a.IsDraft as IsDraft,
    a.IsPublicView as IsPublicView,
    a.CreatedOn as CreatedOn,
    a.CreatedBy as CreatedBy,
    a.ModifyOn as ModifyOn,
    a.ModifyBy as ModifyBy
from tbl_rera_ldr_project_reranumber_diarynumber a
where a.Project_ID=p_ProjectID
  and a.Promoter_ID=p_PromoterID
  and a.IsActive=1
  and a.IsPublicView in (0,1)

UNION

-- OFFLINE PROJECT CASE
select
    o.OfflineProjects_IndexID as Project_RefRegistration_regRERA_IndexID,
    o.OfflineProjects_ID as Project_RefRegistration_regRERA_ID,
    0 as ProjectRef_ID,
    '' as ProjectRef_Sequence,
    '' as RelatedProject_Year,
    p_ProjectID as Related_Project_ID,
    p_PromoterID as Related_Promoter_ID,
    p_ProjectID as Related_Project_Type,
    o.CreatedBy as Related_UserID,
    o.OfflineProjects_RERAregistrationNumber as Related_RERAnumberRegistration,
    201 as Related_Project_RefRegistrations_RERA_ID,
    o.OfflineProjects_RERAregistrationNumber as RERAregistration_Number,
    o.RegistrationIssueDate as RERAregistration_IssueDate,
    o.RegistrationValidUptoDate as RERAregistration_ExpiryDate,
    '' as RemarksIfAny,
    o.IsActive as IsActive,
    o.IsDraft as IsDraft,
    1 as IsPublicView,
    o.CreatedOn as CreatedOn,
    o.CreatedBy as CreatedBy,
    o.ModifyOn as ModifyOn,
    o.ModifyBy as ModifyBy
from tbl_rera_project_offlineprojects_pendinguploads o
where o.IsActive=1
  and o.OfflineProjects_RERAregistrationNumber in
  (
      select r.Existing_RERANumber
      from tbl_rera_project_registration r
      where r.ProjectRegistration_ID=p_ProjectID
        and r.Promoter_ID=p_PromoterID
        and r.IsActive=1
  )

UNION

-- PROJECT EXTENSION (RENEWAL-LIKE) CASE
select
    e.Project_ExtnRegd_DiaryNumber_IndexID as Project_RefRegistration_regRERA_IndexID,
    e.Project_ExtnRegd_DiaryNumber_ID as Project_RefRegistration_regRERA_ID,
    e.RelatedExtnRegDiaryNumber_ID as ProjectRef_ID,
    e.RelatedExtnRegDiaryNumber_Name as ProjectRef_Sequence,
    e.RelatedExtnRegDiaryNumber_NameYear as RelatedProject_Year,
    e.RelatedProject_ID as Related_Project_ID,
    e.RelatedPromoter_ID as Related_Promoter_ID,
    e.RelatedProject_ID as Related_Project_Type,
    e.User_ID as Related_UserID,
    e.ExistingRegistration as Related_RERAnumberRegistration,
    212 as Related_Project_RefRegistrations_RERA_ID,
    e.ExtnRegistrationNumber as RERAregistration_Number,
    e.ExtnRegistrationIssueDate as RERAregistration_IssueDate,
    e.ExtnRegistrationRegUptoDate as RERAregistration_ExpiryDate,
    e.RemarksIfAny as RemarksIfAny,
    e.IsActive as IsActive,
    e.IsDraft as IsDraft,
    e.IsPublicView as IsPublicView,
    e.CreatedOn as CreatedOn,
    e.CreatedBy as CreatedBy,
    e.ModifyOn as ModifyOn,
    e.ModifyBy as ModifyBy
from tbl_rera_ldr_project_reranumber_extensionform e
where e.RelatedProject_ID=p_ProjectID
  and e.RelatedPromoter_ID=p_PromoterID
  and e.IsActive=1
  and e.IsDraft in (0,1,4,5,6)
  and e.IsPublicView in (0,1);

END ;;
DELIMITER ;
