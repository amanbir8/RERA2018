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
-- Table structure for table `tbl_rera_hdcr_project_projectnamedetails`
--

DROP TABLE IF EXISTS `tbl_rera_hdcr_project_projectnamedetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_hdcr_project_projectnamedetails` (
  `ProjectPUC_ProjectName_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ProjectPUC_ProjectName_ID` bigint(20) NOT NULL,
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
  `ProjectRegistration_IndexID` bigint(20) NOT NULL,
  `ProjectRegistration_ID` bigint(20) NOT NULL,
  `Project_Name` varchar(90) NOT NULL,
  `Project_Amenities` varchar(500) NOT NULL,
  `IsAlready_RERANumber` varchar(2) NOT NULL,
  `Existing_RERANumber` varchar(50) DEFAULT NULL,
  `ProposedProjectDetail_Structure` varchar(500) NOT NULL,
  `ProposedProjectDetail_Flooring` varchar(500) NOT NULL,
  `ProposedProjectDetail_WallFinishing` varchar(500) NOT NULL,
  `ProposedProjectDetail_SanitaryFittings` varchar(500) NOT NULL,
  `ProposedProjectDetail_ElectricalFittings` varchar(500) NOT NULL,
  `ProposedProjectDetail_Kitchen` varchar(500) NOT NULL,
  `IsProposedProjectDetail_OthersIfAny` varchar(2) NOT NULL,
  `ProposedProjectDetail_OthersIfAnyName` varchar(50) NOT NULL,
  `ProposedProjectDetail_OthersIfAny` varchar(500) NOT NULL,
  `Project_Status` varchar(50) NOT NULL,
  `ProjectStart_Date` datetime(3) NOT NULL,
  `ProjectCompletion_ProposedDate` datetime(3) NOT NULL,
  `ProjectCompletion_OriginalDate` datetime(3) NOT NULL,
  `ProjectRegistrationProvided_Duration` varchar(90) NOT NULL,
  `ProjectDelayReason_IfAny` varchar(255) DEFAULT NULL,
  `Project_AddressLine1` varchar(90) NOT NULL,
  `Project_AddressLine2` varchar(90) NOT NULL,
  `Project_AddressStateCode` int(11) NOT NULL,
  `Project_AddressDistrictCode` int(11) NOT NULL,
  `Project_AddressSubDivisionCode` int(11) NOT NULL,
  `Project_AddressPIN` varchar(10) NOT NULL,
  `Project_PotentialZoneCode` int(11) NOT NULL,
  `ProjectWebsite_WebLink` varchar(90) NOT NULL,
  `AuthorizedPerson_FirstName` varchar(50) NOT NULL,
  `AuthorizedPerson_MiddleName` varchar(50) NOT NULL,
  `AuthorizedPerson_LastName` varchar(50) NOT NULL,
  `AuthorizedPerson_AddressLine1` varchar(90) NOT NULL,
  `AuthorizedPerson_AddressLine2` varchar(90) NOT NULL,
  `AuthorizedPerson_AddressStateCode` int(11) NOT NULL,
  `AuthorizedPerson_AddressDistrictCode` int(11) NOT NULL,
  `AuthorizedPerson_AddressPIN` varchar(10) NOT NULL,
  `AuthorizedPerson_EmailAddress` varchar(100) NOT NULL,
  `AuthorizedPerson_MobileNumber` bigint(20) NOT NULL,
  `IsProForma_AOS_RERAformat_AnnexureA` varchar(2) NOT NULL,
  `IsProForma_AOS_RERAformat_No_IsApproved` varchar(2) NOT NULL,
  `IsProject_MegaProjectCategory` varchar(2) NOT NULL,
  `IsLitigation_RelatedProject` varchar(2) NOT NULL,
  `Remarks_IfAny` varchar(100) DEFAULT NULL,
  `A_column` decimal(18,2) NOT NULL,
  `B_column` varchar(300) DEFAULT NULL,
  `C_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  `Promoter_ID` bigint(20) DEFAULT NULL,
  `Used_ID` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ProjectPUC_ProjectName_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_hdcr_project_projectnamedetails`
--

LOCK TABLES `tbl_rera_hdcr_project_projectnamedetails` WRITE;
/*!40000 ALTER TABLE `tbl_rera_hdcr_project_projectnamedetails` DISABLE KEYS */;
INSERT INTO `tbl_rera_hdcr_project_projectnamedetails` VALUES (1,1001,1056,10040,1093,'PPUC00422022','rera-2021-589','2021-11-01 00:00:00.000',602,'PBRERA-SAS81-PR0331','PRJ2018SAS1027','',0,1,1,1,'2018-09-24 10:14:30.000','2022-07-14 11:12:06.000','2022-07-14 11:12:06.000','f193be5c-b13c-42ce-8d73-4a045acb493b','2022-07-14 11:12:06.000','f193be5c-b13c-42ce-8d73-4a045acb493b','Promoter Reference Letter','rera-2021-589','Revised registration letter issued dated 01.11.2021',817,10040,'One City Hamlet-2','A Residential Plotted Development . Amenities include  Internal Roads , Water Supply Network ,Sewage Network ,Storm Water Drainage System , Street Lighting and Electrical Distribution System.','Y','PBRERA-SAS81-PR0331','N/A','N/A','N/A','N/A','N/A','N/A','N','','','On-going','2013-05-15 00:00:00.000','2021-12-31 00:00:00.000','2021-12-31 00:00:00.000','3 year(s) 7 month(s) 17 day(s)','','IREO Project Office','Sector 99',28,507,23,'140308',1,'','Mudit','','Jain','IREO Project Office','Sector 99,',28,507,'140308','mudit.jain@ireo.in',9312810005,'Y','','Y','N','',0.00,'','C_column',1,1,'Rera.Mohali','2018-09-24 10:14:30.000','Rera.Mohali','2018-09-24 10:14:30.000',1056,'6a2c2ef8-961c-4217-9658-05b29b899c90'),(2,1002,1056,10041,1094,'PPUC00432022','RERA-2021-590','2021-11-01 00:00:00.000',602,'PBRERA-SAS81-PR0330','PRJ2018SAS1028','',0,1,1,1,'2018-05-29 19:10:44.000','2022-07-14 11:55:18.000','2022-07-14 11:55:18.000','f193be5c-b13c-42ce-8d73-4a045acb493b','2022-07-14 11:55:18.000','f193be5c-b13c-42ce-8d73-4a045acb493b','Promoter Reference Letter','RERA-2021-591','RERA-2021-591 dated 01.11.2021',152,10041,'One City Hamlet-4','A Residential Plotted Development . Amenities include  Internal Roads , Water Supply Network ,Sewage Network ,Storm Water Drainage System , Street Lighting and Electrical Distribution System.','Y','PBRERA-SAS81-PR0330','N/A','N/A','N/A','N/A','N/A','N/A','N','','','On-going','2018-03-27 00:00:00.000','2021-12-31 00:00:00.000','2021-12-31 00:00:00.000','3 year(s) 7 month(s) 17 day(s)','','IREO Project Office','Sector 99',28,507,23,'140308',1,'','Mudit','','Jain','IREO Project Office','Sector 99,',28,507,'140308','mudit.jain@ireo.in',9810237279,'Y','','Y','N','',0.00,'','C_column',1,1,'Rera.Mohali','2018-05-29 19:10:44.000','Rera.Mohali','2018-05-29 19:10:44.000',1056,'6a2c2ef8-961c-4217-9658-05b29b899c90'),(3,1003,1056,10038,1095,'PPUC00442022','RERA-2021-591','2021-11-01 00:00:00.000',602,'PBRERA-SAS81-PR0322','PRJ2018SAS1029','',0,1,1,1,'2018-05-29 18:52:30.000','2022-07-14 12:05:36.000','2022-07-14 12:05:36.000','f193be5c-b13c-42ce-8d73-4a045acb493b','2022-07-14 12:05:36.000','f193be5c-b13c-42ce-8d73-4a045acb493b','Promoter Reference Letter','RERA-2021-594','RERA-2021-594 ',149,10038,'One City Hamlet C-1','A Residential Plotted Development . Amenities include  Internal Roads , Water Supply Network ,Sewage Network ,Storm Water Drainage System , Street Lighting and Electrical Distribution System.','Y','PBRERA-SAS81-PR0322','N/A','N/A','N/A','N/A','N/A','N/A','N','','','On-going','2017-03-27 00:00:00.000','2021-12-31 00:00:00.000','2021-12-31 00:00:00.000','3 year(s) 7 month(s) 17 day(s)','','IREO Project Office','Sector 99',28,507,23,'140308',1,'','Mudit','','Jain','Ireo Project Office','Sector 99,',28,507,'140308','mudit.jain@ireo.in',9810237279,'Y','','Y','N','',0.00,'','C_column',1,1,'Rera.Mohali','2018-05-29 18:52:30.000','Rera.Mohali','2018-05-29 18:52:30.000',1056,'6a2c2ef8-961c-4217-9658-05b29b899c90'),(4,1004,3203,12303,1234,'PPUC00312025','7824','2025-11-11 00:00:00.000',602,'PBRERA-SAS79-PR1232','PRJ2025SAS0125','',0,1,1,1,'2025-06-19 13:11:47.000','2025-12-03 11:08:58.000','2025-12-03 11:08:58.000','f193be5c-b13c-42ce-8d73-4a045acb493b','2025-12-03 11:08:58.000','f193be5c-b13c-42ce-8d73-4a045acb493b','Promoter Reference Letter','7824','letter from promoter to update the Project Name as per CLU letter issued.',7541,12303,'AUROVILLE  HEIGHTS ','WATER SUPPLY, STP, ELECTRICITY SUPPLY  , DRAINAGE ETC ','N','','RCC','TILES','RCC','KOHLER','LNT','MODULAR','N','','','Complete','2025-05-16 00:00:00.000','2030-05-15 00:00:00.000','2030-05-15 00:00:00.000','0 year(s) 0 month(s) 1 day(s)','','Village Ramgarh Bhudda  ','Zirakpur ',28,507,21,'140603',1,'','ASHISH','','ARORA','Auroville Heights Site Sales office VIP junction  Zirakpur Patiala Highway ','Adjoining Maple Homes ',28,507,'140603','diyascreation29@gmail.com',9815191718,'Y','','N','N','',885886633.00,'//NREGC////NEXTRA//////','',1,1,'Auroville','2025-06-19 13:11:47.000','Auroville','2025-06-19 13:11:47.000',3203,'74c3a4ae-c792-4aad-85ee-e9c93a3f0b26');
/*!40000 ALTER TABLE `tbl_rera_hdcr_project_projectnamedetails` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:47
