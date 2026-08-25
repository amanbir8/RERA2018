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
-- Table structure for table `tbl_rera_ldr_project_reranumber_revokedetails`
--

DROP TABLE IF EXISTS `tbl_rera_ldr_project_reranumber_revokedetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_ldr_project_reranumber_revokedetails` (
  `RevokeProject_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `RevokeProject_ID` bigint(20) NOT NULL,
  `ProjectRegDiaryNumber_Name` varchar(60) NOT NULL,
  `ExtnRegDiaryNumber_Name` varchar(60) NOT NULL,
  `RevokesRegDiaryNumber_Name` varchar(60) NOT NULL,
  `Promoter_ID` bigint(20) NOT NULL,
  `Project_ID` bigint(20) NOT NULL,
  `User_ID` varchar(50) NOT NULL,
  `RERAnumberRegistration` varchar(200) NOT NULL,
  `RERAnumberIssueDate` datetime(3) NOT NULL,
  `RERAnumberRegUptoDate` datetime(3) NOT NULL,
  `IsExtensionRegistration` int(11) NOT NULL,
  `RERAnumberExtensionRegUptoDate` datetime(3) NOT NULL,
  `ProjectName` varchar(250) NOT NULL,
  `PromoterName` varchar(250) NOT NULL,
  `ProjectAddressDistrict` varchar(250) DEFAULT NULL,
  `DName` varchar(250) DEFAULT NULL,
  `ProjectType` varchar(250) NOT NULL,
  `Revoke_InfoDetails` varchar(250) DEFAULT NULL,
  `Revoke_IssueAuthority` varchar(250) DEFAULT NULL,
  `Revoke_ReferenceName` varchar(250) DEFAULT NULL,
  `Revoke_ReferenceDate` datetime(3) NOT NULL,
  `Revoke_Type` varchar(200) NOT NULL,
  `Revoke_Category` varchar(400) NOT NULL,
  `Revoke_Status` varchar(200) NOT NULL,
  `Revoke_ReceiptDatePlanned_DateExpected` datetime(3) NOT NULL,
  `Revoke_ReciptType` varchar(200) NOT NULL,
  `Revoke_Reasons` varchar(1250) DEFAULT NULL,
  `RemarksIfAny` varchar(1250) DEFAULT NULL,
  `Extra1` varchar(200) DEFAULT NULL,
  `Extra2` varchar(200) DEFAULT NULL,
  `Extra3` varchar(200) DEFAULT NULL,
  `Extra4` varchar(200) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `IsDraftHelpDesk` int(11) NOT NULL,
  `IsDraftEvaluation` int(11) NOT NULL,
  `IsDraftSecMember` int(11) NOT NULL,
  `IsDraftMember` int(11) NOT NULL,
  `IsConditional` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`RevokeProject_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=111 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_ldr_project_reranumber_revokedetails`
--

LOCK TABLES `tbl_rera_ldr_project_reranumber_revokedetails` WRITE;
/*!40000 ALTER TABLE `tbl_rera_ldr_project_reranumber_revokedetails` DISABLE KEYS */;
INSERT INTO `tbl_rera_ldr_project_reranumber_revokedetails` VALUES (101,1001,'PRJ2020SAS2011','FormE2023SAS0037','PRevNo00062024',2022,11191,'f193be5c-b13c-42ce-8d73-4a045acb493b','PBRERA-SAS80-PC0155','2021-08-19 00:00:00.000','2023-03-20 00:00:00.000',1,'2024-03-20 00:00:00.000','District Seven','VRS Townships Private LImited (Other than Individual)','507','','PC','License to Develop colony cancelled by Competent Authority i.e. GMADA','GMADA','RERA-Pb-Legal-2024-8823-8824','2024-09-06 00:00:00.000','Revoked Registration','Revoked Registration','License to Develop colony cancelled by Competent Authority i.e. GMADA','2024-09-24 17:04:09.000','Offline','License to Develop colony cancelled by Competent Authority i.e. GMADA',NULL,NULL,NULL,NULL,NULL,1,1,1,0,0,0,0,0,1,'admprogrammer.rera','2024-09-24 17:04:09.000','admprogrammer.rera','2024-09-24 17:04:09.000'),(102,1002,'PRJ2018SAS1416','FormE2021SAS0045','PRevNo00052024',1475,10573,'f193be5c-b13c-42ce-8d73-4a045acb493b','PBRERA-SAS80-PM0045','2018-03-06 00:00:00.000','2020-11-08 00:00:00.000',1,'2023-03-19 00:00:00.000','Suntec City','The Indian Co-operative House Building Society (Other than Individual)','507','','PM','License to Develop colony cancelled by Competent Authority i.e. GMADA','GMADA','RERA-Pb-Legal-2024-8821-8822','2024-09-06 00:00:00.000','Revoked Registration','Revoked Registration','License to Develop colony cancelled by Competent Authority i.e. GMADA','2024-09-24 17:04:09.000','Offline','License to Develop colony cancelled by Competent Authority i.e. GMADA',NULL,NULL,NULL,NULL,NULL,1,1,1,0,0,0,0,0,1,'admprogrammer.rera','2024-09-23 13:11:22.000','admprogrammer.rera','2024-09-23 13:11:22.000'),(103,1003,'PRJ2018SAS1146','','PRevNo00012023',1072,10144,'f193be5c-b13c-42ce-8d73-4a045acb493b','PBRERA-SAS80-PR0035','2017-09-06 00:00:00.000','2019-07-31 00:00:00.000',0,'0001-01-01 00:00:00.000','INTEGRATED RESIDENTIAL TOWNSHIP PHASE-5','OMAXE CHANDIGARH EXTENSION DEVELOPERS PRIVATE LIMITED (Other than Individual)','507','','PR','Registration withdrawn as per meeting of authority dated 09.03.2023','RERA','4917','2021-11-30 00:00:00.000','Withdrawn Registration','Withdrawn Registration','Due to change in planning the promoter wants to deregister its project.','0001-01-01 00:00:00.000','Offline','Due to change in planning the promoter wants to deregister its project.',NULL,NULL,NULL,NULL,NULL,1,1,1,0,0,0,0,0,1,'admprogrammer.rera','2023-03-22 13:07:55.000','admprogrammer.rera','2023-03-22 13:07:55.000'),(104,1004,'PRJ2022SAS0157','','PRevNo00042024',2022,11568,'f193be5c-b13c-42ce-8d73-4a045acb493b','PBRERA-SAS80-PR0886','2024-01-08 00:00:00.000','2025-03-31 00:00:00.000',0,'0001-01-01 00:00:00.000','LA-CANELA','ABS Townships Private LImited (Other than Individual)','507','','PR','License to Develop colony cancelled by Competent Authority i.e. GMADA','GMADA','RERA-Pb-Legal-2024-8821-8822','2024-09-06 00:00:00.000','Revoked Registration','Revoked Registration','License to Develop colony cancelled by Competent Authority i.e. GMADA','0001-01-01 00:00:00.000','Offline','License to Develop colony cancelled by Competent Authority i.e. GMADA',NULL,NULL,NULL,NULL,NULL,1,1,1,0,0,0,0,0,1,'admprogrammer.rera','2024-09-23 13:09:09.000','admprogrammer.rera','2024-09-23 13:09:09.000'),(105,1005,'PRJ2018SAS1114','','PRevNo00022022',1073,10174,'f193be5c-b13c-42ce-8d73-4a045acb493b','PBRERA-SAS81-PR0015','2017-09-01 00:00:00.000','2020-09-30 00:00:00.000',0,'0001-01-01 00:00:00.000','Project-Galaxy Heights Apartments Pocket 2B','Janta Land Promoters Pvt. Ltd.  (Other than Individual)','507','','PR','Promoter requested for Deregistration of project','RERA','4032','2021-10-01 00:00:00.000','Withdrawn Registration','Withdrawn Registration','Promoter requested for Deregistration of project vide orders dated 11.10.2021','0001-01-01 00:00:00.000','Offline','Promoter requested for Deregistration of project vide orders dated 11.10.2021',NULL,NULL,NULL,NULL,NULL,1,1,1,0,0,0,0,0,1,'admprogrammer.rera','2022-06-10 17:20:29.000','admprogrammer.rera','2022-06-10 17:20:29.000'),(106,1006,'PRJ2019SAS1662','','PRevNo00012022',1017,10840,'f193be5c-b13c-42ce-8d73-4a045acb493b','PBRERA-SAS79-PR0467','2019-05-31 00:00:00.000','2024-03-28 00:00:00.000',0,'0001-01-01 00:00:00.000','DREAM HOMES Phase-1 (Part-A)','COUNTRY COLONISERS PRIVATE LIMITED (Other than Individual)','507','','PR','Promoter requested for Deregistration of project','RERA','3955','2021-09-29 00:00:00.000','Withdrawn Registration','Withdrawn Registration','Promoter requested for Deregistration of project vide letter dated 24.03.2022','0001-01-01 00:00:00.000','Offline','Promoter requested for Deregistration of project vide letter dated 24.03.2022',NULL,NULL,NULL,NULL,NULL,1,1,1,0,0,0,0,0,1,'admprogrammer.rera','2022-06-10 17:07:37.000','admprogrammer.rera','2022-06-10 17:07:37.000'),(107,1007,'PRJ2018SAS1272','','PRevNo00012024',1080,10367,'f193be5c-b13c-42ce-8d73-4a045acb493b','PBRERA-SAS81-PC0074','2018-05-08 00:00:00.000','2022-12-31 00:00:00.000',0,'0001-01-01 00:00:00.000','WTC CHANDIGARH (OFFICES & RETAIL OUTLETS)','WTC Chandigarh Development Company Pvt. Ltd. (Other than Individual)','507','','PC','Allotment of project site cancelled by Competent Authority i.e. GMADA','GMADA','RERA-Pb-EG-T-2024-4968','2024-05-16 00:00:00.000','Revoked Registration','Revoked Registration','Allotment of project site canceled by Competent Authority i.e. GMADA','0001-01-01 00:00:00.000','Offline','Allotment of project site canceled by Competent Authority i.e. GMADA',NULL,NULL,NULL,NULL,NULL,1,1,1,0,0,0,0,0,1,'admprogrammer.rera','2025-01-28 11:00:58.000','admprogrammer.rera','2025-01-28 11:00:58.000'),(108,1008,'PRJ2018SAS1291','','PRevNo00022024',1080,10455,'f193be5c-b13c-42ce-8d73-4a045acb493b','PBRERA-SAS81-PC0073','2018-05-23 00:00:00.000','2023-12-31 00:00:00.000',0,'0001-01-01 00:00:00.000','WTC CHANDIGARH (SIGNATURE TOWER)','WTC Noida Development Company Pvt. Ltd. (Other than Individual)','507','','PC','Allotment of project site cancelled by Competent Authority i.e. GMADA','GMADA','RERA-Pb-EG-T-2024-4968','2024-05-16 00:00:00.000','Revoked Registration','Revoked Registration','Allotment of project site canceled by Competent Authority i.e. GMADA','0001-01-01 00:00:00.000','Offline','Allotment of project site canceled by Competent Authority i.e. GMADA',NULL,NULL,NULL,NULL,NULL,1,1,1,0,0,0,0,0,1,'admprogrammer.rera','2025-01-28 11:00:58.000','admprogrammer.rera','2025-01-28 11:00:58.000'),(109,1009,'PRJ2018SAS1281','','PRevNo00032024',1080,10437,'f193be5c-b13c-42ce-8d73-4a045acb493b','PBRERA-SAS81-PC0075','2018-03-06 00:00:00.000','2023-12-31 00:00:00.000',0,'0001-01-01 00:00:00.000','WTC CHANDIGARH (SUITES)','Erika Infracon India Pvt. Ltd (Other than Individual)','507','','PC','Allotment of project site cancelled by Competent Authority i.e. GMADA','GMADA','RERA-Pb-EG-T-2024-4968','2024-05-16 00:00:00.000','Revoked Registration','Revoked Registration','Allotment of project site canceled by Competent Authority i.e. GMADA','0001-01-01 00:00:00.000','Offline','Allotment of project site canceled by Competent Authority i.e. GMADA',NULL,NULL,NULL,NULL,NULL,1,1,1,0,0,0,0,0,1,'admprogrammer.rera','2025-01-28 11:00:58.000','admprogrammer.rera','2025-01-28 11:00:58.000'),(110,1010,'PRJ2018LDH1208','','PRevNo00012026',1300,10343,'f193be5c-b13c-42ce-8d73-4a045acb493b','PBRERA-LDH45-PR0683','2018-03-06 00:00:00.000','2023-09-30 00:00:00.000',0,'0001-01-01 00:00:00.000','ECO POLIS','Shri Ramdas Infrastructure Private Limited (Other than Individual)','507','','PR','Registration withdrawn as per meeting of authority.','RERA','NA','2026-04-27 00:00:00.000','Withdrawn Registration','Withdrawn Registration','Registration withdrawn as per meeting of authority.','0001-01-01 00:00:00.000','Offline','Registration withdrawn as per meeting of authority.',NULL,NULL,NULL,NULL,NULL,1,1,1,0,0,0,0,0,1,'admprogrammer.rera','2026-04-27 11:00:58.000','admprogrammer.rera','2026-04-27 11:00:58.000');
/*!40000 ALTER TABLE `tbl_rera_ldr_project_reranumber_revokedetails` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:18
