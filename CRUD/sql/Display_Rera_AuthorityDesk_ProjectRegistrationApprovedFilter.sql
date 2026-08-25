DROP PROCEDURE IF EXISTS `Display_Rera_AuthorityDesk_ProjectRegistrationApprovedFilter`;
DELIMITER //
CREATE PROCEDURE `Display_Rera_AuthorityDesk_ProjectRegistrationApprovedFilter`(
    IN p_currectYear INT,
    IN p_fromDate DATE,
    IN p_toDate DATE,
    IN p_UserRole VARCHAR(50)
)
BEGIN
    SELECT
        a.Project_RegDiaryNumber_IndexID,
        a.Project_RegDiaryNumber_ID,
        a.PromoterRegDiaryNumber_Name,
        a.PromoterRegDiaryNumber_NameYear,
        a.UserID,
        a.Promoter_ID,
        a.Project_ID,
        a.LandDetailsCount,
        a.KhasraAreaDetailsCount,
        a.LitigationsCount,
        a.ApprovalDetailsCount,
        a.PaymentDetailsCount,
        a.SpecialBankAccountDetailsCount,
        a.ProjectDocumentCount,
        a.IsRegistration,
        a.CurrentEventcode,
        a.EventCodeDetails_indexID,
        a.Extra2,
        a.Extra3,
        a.Extra4,
        a.Remarks_IfAny,
        a.IsActive,
        a.IsDraft,
        a.IsDraftHelpDesk,
        a.IsDraftEvaluation,
        a.IsDraftSecMember,
        a.IsDraftMember,
        a.CreatedBy,
        udfn_GetProjectApplicationDate(a.Project_ID, a.Promoter_ID) AS CreatedOn,
        a.ModifyBy,
        a.ModifyOn,
        udfn_GetProjectName(a.Project_ID) AS Project_Name,
        udfn_GetPromoterName(a.Promoter_ID) AS Promoter_Name,
        udfn_GetProjectAddressDistrictName(a.Project_ID) AS Project_AddressDistrictName,
        '--' AS Project_RERAregistrationNumber,
        c.EventAction_Type,
        c.EventAction_Type AS EventAction_TypeName,
        c.EventAction_IdentifiedOn,
        c.EventAction_Aggregate,
        c.Target_ResolutionDate,
        c.Remarks_IfAny AS EventRemarks_IfAny,
        c.EventAction_Summary
    FROM tbl_RERA_Project_RegDiaryNumber a
    INNER JOIN tbl_RERA_Project_Promoter_EventAction c
        ON a.PromoterRegDiaryNumber_Name = c.Project_DiaryNumber
        AND a.Project_ID = c.Related_Project_ID
    WHERE c.IsActive = 1
        AND a.IsActive = 1
        AND a.Project_ID IN (
            SELECT ProjectRegistration_ID
            FROM tbl_rera_project_registration
            WHERE IsAlready_RERANumber = 'N' AND IsActive = 1
        )
        AND c.EventAction_Type IN (110017, 110020, 110021)
        AND (
            (
                p_fromDate IS NOT NULL
                AND p_toDate IS NOT NULL
                AND DATE(c.EventAction_IdentifiedOn) BETWEEN LEAST(p_fromDate, p_toDate) AND GREATEST(p_fromDate, p_toDate)
            )
            OR
            (
                (p_fromDate IS NULL OR p_toDate IS NULL)
                AND YEAR(c.EventAction_IdentifiedOn) = p_currectYear
            )
        )
    ORDER BY c.EventAction_IdentifiedOn DESC
    LIMIT 1950;
END //
DELIMITER ;

