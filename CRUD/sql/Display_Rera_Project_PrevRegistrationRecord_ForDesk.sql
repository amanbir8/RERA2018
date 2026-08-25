DROP PROCEDURE IF EXISTS `Display_Rera_Project_PrevRegistrationRecord_ForDesk`;
DELIMITER ;;

CREATE DEFINER=`sa`@`%` PROCEDURE `Display_Rera_Project_PrevRegistrationRecord_ForDesk`(
    IN p_ProjectID BIGINT,
    IN p_PromoterID BIGINT,
    IN p_RefRegistrationID BIGINT,
    IN p_Project_FlagCode VARCHAR(20),
    IN p_UserRole VARCHAR(120)
)
BEGIN

    IF (p_Project_FlagCode = '101') THEN
        SELECT
            a.Project_RERAnumber_DiaryNumber_IndexID AS Ref_IndexID,
            a.Project_RERAnumber_DiaryNumber_ID AS Ref_ID,
            p_Project_FlagCode AS Project_Format_CODE,

            a.Project_ID AS Related_Project_ID,
            a.Promoter_ID AS Related_Promoter_ID,
            a.User_ID AS Related_UserID,
            a.RERAnumberRegistration AS Related_RERAnumberRegistration,
            a.RERAnumberIssueDate AS Related_RERAnumberIssueDate,
            a.RERAnumberRegUptoDate AS Related_RERAnumberRegUptoDate,

            a.RERAnumberRegistration AS RERAregistration_Number,
            a.RERAnumberIssueDate AS RERAregistration_IssueDate,
            a.RERAnumberRegUptoDate AS RERAregistration_ExpiryDate,

            a.ProjectRegDiaryNumber_Name AS Project_Reference_DiaryNumber,
            a.ProjectName AS Project_Name,
            a.PromoterName AS Promoter_Name,

            IFNULL(a.ProjectAddressLine1, '') AS ProjectAddressLine1,
            IFNULL(a.ProjectAddressLine2, '') AS ProjectAddressLine2,
            IFNULL(a.ProjectAddressDistrict, '') AS ProjectAddressDistrict,
            IFNULL(a.ProjectAddressState, '') AS ProjectAddressState,
            IFNULL(a.ProjectAddressSubDivision, '') AS ProjectAddressSubDivision,
            IFNULL(a.ProjectAddressPIN, '') AS ProjectAddressPIN,
            IFNULL(a.ProjectPotentialZone, '') AS ProjectPotentialZone,
            IFNULL(a.ProjectWebLink, '') AS ProjectWebLink,

            IFNULL(a.AuthorizedPerson_FirstName, '') AS AuthorizedPerson_FirstName,
            IFNULL(a.AuthorizedPerson_LastName, '') AS AuthorizedPerson_LastName,
            IFNULL(a.AuthorizedPerson_AddressLine1, '') AS AuthorizedPerson_AddressLine1,
            IFNULL(a.AuthorizedPerson_AddressLine2, '') AS AuthorizedPerson_AddressLine2,
            IFNULL(a.AuthorizedPerson_District, '') AS AuthorizedPerson_District,
            IFNULL(a.AuthorizedPerson_State, '') AS AuthorizedPerson_State,
            IFNULL(a.AuthorizedPerson_PIN, '') AS AuthorizedPerson_PIN,
            IFNULL(a.AuthorizedPerson_Email, '') AS AuthorizedPerson_Email,
            IFNULL(a.AuthorizedPerson_Mobile, '') AS AuthorizedPerson_Mobile,

            IFNULL(a.RemarksIfAny, '') AS RemarksIfAny,
            a.IsActive,
            a.IsDraft,
            a.IsPublicView,
            a.CreatedOn,
            a.CreatedBy,
            a.ModifyOn,
            a.ModifyBy
        FROM tbl_rera_ldr_project_reranumber_diarynumber a
        WHERE a.Project_ID = p_ProjectID
          AND a.Promoter_ID = p_PromoterID
          AND a.Project_RERAnumber_DiaryNumber_ID = p_RefRegistrationID
          AND a.IsActive = 1
        LIMIT 1;

    ELSEIF (p_Project_FlagCode = '102') THEN
        SELECT
            o.OfflineProjects_IndexID AS Ref_IndexID,
            o.OfflineProjects_ID AS Ref_ID,
            p_Project_FlagCode AS Project_Format_CODE,

            p_ProjectID AS Related_Project_ID,
            p_PromoterID AS Related_Promoter_ID,
            o.CreatedBy AS Related_UserID,
            o.OfflineProjects_RERAregistrationNumber AS Related_RERAnumberRegistration,
            o.RegistrationIssueDate AS Related_RERAnumberIssueDate,
            o.RegistrationValidUptoDate AS Related_RERAnumberRegUptoDate,

            o.OfflineProjects_RERAregistrationNumber AS RERAregistration_Number,
            o.RegistrationIssueDate AS RERAregistration_IssueDate,
            o.RegistrationValidUptoDate AS RERAregistration_ExpiryDate,

            CONCAT('Offline (', IFNULL(o.OfflineProjects_ReferenceNumber,''), ')') AS Project_Reference_DiaryNumber,
            o.OfflineProjects_ProjectName AS Project_Name,
            o.OfflineProjects_PromoterName AS Promoter_Name,

            IFNULL(o.OfflineProjects_ProjectLocation, '') AS ProjectAddressLine1,
            '' AS ProjectAddressLine2,
            IFNULL(o.OfflineProjects_DistrictName, '') AS ProjectAddressDistrict,
            '' AS ProjectAddressState,
            '' AS ProjectAddressSubDivision,
            '' AS ProjectAddressPIN,
            IFNULL(o.OfflineProjects_TypeofProject, '') AS ProjectPotentialZone,
            '' AS ProjectWebLink,

            '' AS AuthorizedPerson_FirstName,
            '' AS AuthorizedPerson_LastName,
            IFNULL(o.OfflineProjects_PromoterAddress, '') AS AuthorizedPerson_AddressLine1,
            '' AS AuthorizedPerson_AddressLine2,
            IFNULL(o.OfflineProjects_DistrictName, '') AS AuthorizedPerson_District,
            '' AS AuthorizedPerson_State,
            '' AS AuthorizedPerson_PIN,
            '' AS AuthorizedPerson_Email,
            IFNULL(o.OfflineProjects_PromoterContactDetails, '') AS AuthorizedPerson_Mobile,

            '' AS RemarksIfAny,
            o.IsActive,
            o.IsDraft,
            1 AS IsPublicView,
            o.CreatedOn,
            o.CreatedBy,
            o.ModifyOn,
            o.ModifyBy
        FROM tbl_rera_project_offlineprojects_pendinguploads o
        WHERE o.OfflineProjects_ID = p_RefRegistrationID
          AND o.IsActive = 1
        LIMIT 1;

    ELSEIF (p_Project_FlagCode = '103') THEN
        SELECT
            e.Project_ExtnRegd_DiaryNumber_IndexID AS Ref_IndexID,
            e.Project_ExtnRegd_DiaryNumber_ID AS Ref_ID,
            p_Project_FlagCode AS Project_Format_CODE,

            e.RelatedProject_ID AS Related_Project_ID,
            e.RelatedPromoter_ID AS Related_Promoter_ID,
            e.User_ID AS Related_UserID,
            e.ExtnRegistrationNumber AS Related_RERAnumberRegistration,
            e.ExtnRegistrationIssueDate AS Related_RERAnumberIssueDate,
            e.ExtnRegistrationRegUptoDate AS Related_RERAnumberRegUptoDate,

            e.ExtnRegistrationNumber AS RERAregistration_Number,
            e.ExtnRegistrationIssueDate AS RERAregistration_IssueDate,
            e.ExtnRegistrationRegUptoDate AS RERAregistration_ExpiryDate,

            e.RelatedExtnRegDiaryNumber_Name AS Project_Reference_DiaryNumber,
            e.ProjectName AS Project_Name,
            e.PromoterName AS Promoter_Name,

            IFNULL(e.ProjectAddressLine1, '') AS ProjectAddressLine1,
            IFNULL(e.ProjectAddressLine2, '') AS ProjectAddressLine2,
            IFNULL(e.ProjectAddressDistrict, '') AS ProjectAddressDistrict,
            IFNULL(e.ProjectAddressState, '') AS ProjectAddressState,
            IFNULL(e.ProjectAddressSubDivision, '') AS ProjectAddressSubDivision,
            IFNULL(e.ProjectAddressPIN, '') AS ProjectAddressPIN,
            IFNULL(e.ProjectPotentialZone, '') AS ProjectPotentialZone,
            IFNULL(e.ProjectWebLink, '') AS ProjectWebLink,

            IFNULL(e.AuthorizedPerson_FirstName, '') AS AuthorizedPerson_FirstName,
            IFNULL(e.AuthorizedPerson_LastName, '') AS AuthorizedPerson_LastName,
            IFNULL(e.AuthorizedPerson_AddressLine1, '') AS AuthorizedPerson_AddressLine1,
            IFNULL(e.AuthorizedPerson_AddressLine2, '') AS AuthorizedPerson_AddressLine2,
            IFNULL(e.AuthorizedPerson_District, '') AS AuthorizedPerson_District,
            IFNULL(e.AuthorizedPerson_State, '') AS AuthorizedPerson_State,
            IFNULL(e.AuthorizedPerson_PIN, '') AS AuthorizedPerson_PIN,
            IFNULL(e.AuthorizedPerson_Email, '') AS AuthorizedPerson_Email,
            IFNULL(e.AuthorizedPerson_Mobile, '') AS AuthorizedPerson_Mobile,

            IFNULL(e.RemarksIfAny, '') AS RemarksIfAny,
            e.IsActive,
            e.IsDraft,
            e.IsPublicView,
            e.CreatedOn,
            e.CreatedBy,
            e.ModifyOn,
            e.ModifyBy
        FROM tbl_rera_ldr_project_reranumber_extensionform e
        WHERE e.RelatedProject_ID = p_ProjectID
          AND e.RelatedPromoter_ID = p_PromoterID
          AND e.Project_ExtnRegd_DiaryNumber_ID = p_RefRegistrationID
          AND e.IsActive IN (1,2)
        ORDER BY e.Project_ExtnRegd_DiaryNumber_IndexID DESC
        LIMIT 1;

    END IF;

END ;;
DELIMITER ;
