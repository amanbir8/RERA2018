-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: 10.228.0.96    Database: rerapunjab_productiondb
-- ------------------------------------------------------
-- Server version	5.7.17-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tbl_rera_hdcr_project_promoternamedetails`
--

DROP TABLE IF EXISTS `tbl_rera_hdcr_project_promoternamedetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_hdcr_project_promoternamedetails` (
  `ProjectPUC_PromoterName_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ProjectPUC_PromoterName_ID` bigint(20) NOT NULL,
  `Related_Promoter_ID` bigint(20) NOT NULL,
  `Related_Project_ID` bigint(20) NOT NULL,
  `RelatedApplicationPUC_ID` bigint(20) NOT NULL,
  `PUC_DiaryNumber` varchar(100) NOT NULL,
  `PUC_ReferencePUC_Name` varchar(100) NOT NULL,
  `PUC_ReferencePUC_Date` datetime(3) NOT NULL,
  `PUC_RequestCategoryID` bigint(20) NOT NULL,
  `RERAnumberRegistration` varchar(100) NOT NULL,
  `ProjectDiaryNumber` varchar(100) NOT NULL,
  `ExtensionRegdDiaryNumber` varchar(100) NOT NULL,
  `IsConditionAnnexure` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `IsApproved` int(11) NOT NULL,
  `IsMemberApproved` int(11) NOT NULL,
  `Account_FormDate` datetime(3) NOT NULL,
  `Account_ToDate` datetime(3) NOT NULL,
  `Approved_AccountDate` datetime(3) NOT NULL,
  `Approved_AccountBy` varchar(50) NOT NULL,
  `ACR_AccountDate` datetime(3) NOT NULL,
  `ACR_AccountBy` varchar(50) NOT NULL,
  `PUC_Doc_ReferenceTitle` varchar(250) NOT NULL,
  `PUC_Doc_ReferenceNumber` varchar(250) DEFAULT NULL,
  `PUC_ReferenceDetailsIfAny` varchar(250) DEFAULT NULL,
  `promoter_Id` int(11) NOT NULL,
  `promoter_Application_id` bigint(20) NOT NULL,
  `promoter_First_Name` varchar(200) DEFAULT NULL,
  `promoter_Middle_Name` varchar(200) DEFAULT NULL,
  `promoter_Last_Name` varchar(200) DEFAULT NULL,
  `promoter_Org_Name` varchar(500) DEFAULT NULL,
  `promoter_Org_Type` varchar(100) DEFAULT NULL,
  `promoter_Org_Objects` varchar(500) DEFAULT NULL,
  `promoter_Fath_First_Name` varchar(200) DEFAULT NULL,
  `promoter_Fath_Middle_Name` varchar(200) DEFAULT NULL,
  `promoter_Fath_Last_Name` varchar(200) DEFAULT NULL,
  `promoter_Occupation` varchar(200) DEFAULT NULL,
  `promoter_Address_Line1` varchar(500) NOT NULL,
  `promoter_Address_Line2` varchar(500) DEFAULT NULL,
  `promoter_State` varchar(200) NOT NULL,
  `promoter_District` varchar(200) NOT NULL,
  `promoter_Pin_Code` bigint(20) NOT NULL,
  `promoter_Org_Address_Line1` varchar(500) DEFAULT NULL,
  `promoter_Org_Address_Line2` varchar(500) DEFAULT NULL,
  `promoter_Org_State` varchar(200) DEFAULT NULL,
  `promoter_Org_District` varchar(200) DEFAULT NULL,
  `promoter_Org_Pin_Code` bigint(20) DEFAULT NULL,
  `promoter_Mobile_no` bigint(20) NOT NULL,
  `promoter_Phone_No_STD` bigint(20) DEFAULT NULL,
  `promoter_Phone_No` bigint(20) DEFAULT NULL,
  `promoter_Email` varchar(100) NOT NULL,
  `promoter_WebLink_Promoter_website` varchar(200) DEFAULT NULL,
  `promoter_New_InCorp_Parnt_Entity_Name` varchar(200) DEFAULT NULL,
  `promoter_New_InCorp_TypeOf_Enterprise` varchar(100) DEFAULT NULL,
  `promoter_New_InCorp_Parent_Entity_Objects` varchar(200) DEFAULT NULL,
  `promoter_New_Incorp_Parent_Address_Line1` varchar(500) DEFAULT NULL,
  `promoter_New_Incorp_Parent_Address_Line2` varchar(500) DEFAULT NULL,
  `promoter_New_Incorp_Parent_Org_State` varchar(200) DEFAULT NULL,
  `promoter_New_Incorp_Parent_Org_District` varchar(200) DEFAULT NULL,
  `promoter_New_Incorp_Parent_Org_Pin_Code` bigint(20) DEFAULT NULL,
  `promoter_Past_Exp_Punjab` int(11) NOT NULL,
  `promoter_Past_Exp_Other_States` int(11) NOT NULL,
  `promoter_PAN_No` varchar(100) NOT NULL,
  `promoter_PAN_Doc_Address` varchar(500) DEFAULT NULL,
  `promoter_Photo_Address` varchar(500) DEFAULT NULL,
  `promoter_Image_FileName` varchar(200) DEFAULT NULL,
  `promoter_Org_Reg_Certificate` varchar(500) DEFAULT NULL,
  `promoter_New_InCorp_Parnt_Reg_Certificate` varchar(500) DEFAULT NULL,
  `promoter_Aadhaar` bigint(20) DEFAULT NULL,
  `promoter_Experience` varchar(100) DEFAULT NULL,
  `promoter_IsOtherOrganizationMembers` varchar(50) DEFAULT NULL,
  `promoter_Ind_Org_CompltdProj_FiveYrs` int(11) DEFAULT NULL,
  `promoter_Ind_Org_TotalArea_Constructed` decimal(18,2) DEFAULT NULL,
  `promoter_Ind_Org_OngoingProjects` int(11) DEFAULT NULL,
  `promoter_Ind_Org_AreaToBe_Constructed` decimal(18,2) DEFAULT NULL,
  `promoter_IsActive` int(11) NOT NULL,
  `promoter_IsDraft` int(11) DEFAULT NULL,
  `promoter_Created_By` varchar(100) NOT NULL,
  `promoter_Created_On` datetime(3) NOT NULL,
  `promoter_Modify_By` varchar(100) DEFAULT NULL,
  `promoter_Modified_On` datetime(3) DEFAULT NULL,
  `promoter_Flag` int(11) NOT NULL,
  `promoter_Last_FiveYr_Exp` varchar(100) DEFAULT NULL,
  `promoter_Ongoing_Exp` varchar(100) DEFAULT NULL,
  `promoter_Org_Parent_Entity` varchar(100) DEFAULT NULL,
  `promoter_IsLitigation_RelatedProject` varchar(50) DEFAULT NULL,
  `promoter_Extra1` varchar(200) DEFAULT NULL,
  `promoter_Extra2` varchar(200) DEFAULT NULL,
  `promoter_Extra3` varchar(200) DEFAULT NULL,
  `promoter_Extra4` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`ProjectPUC_PromoterName_IndexID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_hdcr_project_promoternamedetails`
--

LOCK TABLES `tbl_rera_hdcr_project_promoternamedetails` WRITE;
/*!40000 ALTER TABLE `tbl_rera_hdcr_project_promoternamedetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_hdcr_project_promoternamedetails` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:52
