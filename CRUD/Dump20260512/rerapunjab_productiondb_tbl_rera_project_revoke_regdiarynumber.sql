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
-- Table structure for table `tbl_rera_project_revoke_regdiarynumber`
--

DROP TABLE IF EXISTS `tbl_rera_project_revoke_regdiarynumber`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_project_revoke_regdiarynumber` (
  `Revoke_RegDiaryNumber_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `Revoke_RegDiaryNumber_ID` bigint(20) NOT NULL,
  `Revoke_RegDiaryNumber_Name` varchar(50) NOT NULL,
  `Revoke_RegDiaryNumber_NameYear` varchar(50) NOT NULL,
  `UserID` varchar(50) NOT NULL,
  `Promoter_ID` bigint(20) NOT NULL,
  `Project_ID` bigint(20) NOT NULL,
  `ProjectRegDiaryNumber_Name` varchar(60) NOT NULL,
  `ExtnRegDiaryNumber_Name` varchar(60) NOT NULL,
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
  `Revoke_ReferenceName` varchar(250) DEFAULT NULL,
  `Revoke_ReferenceDate` datetime(3) NOT NULL,
  `Revoke_Category` varchar(400) NOT NULL,
  `Revoke_ReciptType` varchar(200) NOT NULL,
  `Revoke_Reasons` varchar(1250) DEFAULT NULL,
  `Remarks_IfAny` varchar(250) DEFAULT NULL,
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
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`Revoke_RegDiaryNumber_IndexID`),
  KEY `index_tbl_rera_project_revoke_regdiarynumber` (`Promoter_ID`,`Project_ID`,`Revoke_RegDiaryNumber_Name`,`RERAnumberRegistration`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_project_revoke_regdiarynumber`
--

LOCK TABLES `tbl_rera_project_revoke_regdiarynumber` WRITE;
/*!40000 ALTER TABLE `tbl_rera_project_revoke_regdiarynumber` DISABLE KEYS */;
INSERT INTO `tbl_rera_project_revoke_regdiarynumber` VALUES (1,1,'PRevNo00012022','2022','f193be5c-b13c-42ce-8d73-4a045acb493b',1017,10840,'PRJ2019SAS1662','','PBRERA-SAS79-PR0467','2019-05-31 00:00:00.000','2024-03-28 00:00:00.000',0,'0001-01-01 00:00:00.000','DREAM HOMES Phase-1 (Part-A)','COUNTRY COLONISERS PRIVATE LIMITED (Other than Individual)','507','','PR','Promoter requested for Deregistration of project','3955','2021-09-29 00:00:00.000','Withdrawn Registration','Offline','Promoter requested for Deregistration of project vide letter dated 24.03.2022','','','','','',1,1,1,0,0,0,0,'admprogrammer.rera','2022-06-10 17:07:37.000','admprogrammer.rera','2022-06-10 17:07:37.000'),(2,2,'PRevNo00022022','2022','f193be5c-b13c-42ce-8d73-4a045acb493b',1073,10174,'PRJ2018SAS1114','','PBRERA-SAS81-PR0015','2017-09-01 00:00:00.000','2020-09-30 00:00:00.000',0,'0001-01-01 00:00:00.000','Project-Galaxy Heights Apartments Pocket 2B ','Janta Land Promoters Pvt. Ltd.  (Other than Individual)','507','','PR','Promoter requested for Deregistration of project','4032','2021-10-01 00:00:00.000','Withdrawn Registration','Offline','Promoter requested for Deregistration of project vide orders dated 11.10.2021','','','','','',1,1,1,0,0,0,0,'admprogrammer.rera','2022-06-10 17:20:29.000','admprogrammer.rera','2022-06-10 17:20:29.000'),(3,1,'PRevNo00012023','2023','f193be5c-b13c-42ce-8d73-4a045acb493b',1072,10144,'PRJ2018SAS1146','','PBRERA-SAS80-PR0035','2017-09-06 00:00:00.000','2019-07-31 00:00:00.000',0,'0001-01-01 00:00:00.000','INTEGRATED RESIDENTIAL TOWNSHIP PHASE-5','OMAXE CHANDIGARH EXTENSION DEVELOPERS PRIVATE LIMITED (Other than Individual)','507','','PR','Registration withdrawn as per meeting of authority dated 09.03.2023','4917','2021-11-30 00:00:00.000','Withdrawn Registration','Offline','Due to change in planning the promoter wants to deregister its project.','','','','','',1,1,1,0,1,0,0,'admprogrammer.rera','2023-03-22 13:07:55.000','admprogrammer.rera','2023-03-22 13:07:55.000'),(4,1,'PRevNo00012024','2024','f193be5c-b13c-42ce-8d73-4a045acb493b',1080,10367,'PRJ2018SAS1272','','PBRERA-SAS81-PC0074','2018-05-08 00:00:00.000','2022-12-31 00:00:00.000',0,'0001-01-01 00:00:00.000','WTC CHANDIGARH (OFFICES & RETAIL OUTLETS)',' WTC Chandigarh Development Company Pvt. Ltd. (Other than Individual)','507','','PC','Allotment of project site cancelled by Competent Authority i.e. GMADA','RERA-Pb-EG-T-2024-4968','2024-05-16 00:00:00.000','Revoked Registration','Offline','Allotment of project site canceled by Competent Authority i.e. GMADA','','','','','',1,1,1,0,0,0,0,'admprogrammer.rera','2024-09-10 12:17:56.000','admprogrammer.rera','2024-09-10 12:17:56.000'),(6,2,'PRevNo00022024','2024','f193be5c-b13c-42ce-8d73-4a045acb493b',1080,10455,'PRJ2018SAS1291','','PBRERA-SAS81-PC0073','2018-05-23 00:00:00.000','2023-12-31 00:00:00.000',0,'0001-01-01 00:00:00.000','WTC CHANDIGARH (SIGNATURE TOWER)','WTC Noida Development Company Pvt. Ltd. (Other than Individual)','507','','PC','Allotment of project site cancelled by Competent Authority i.e. GMADA ','rera-Pb-EGT-2024-4968','2024-05-16 00:00:00.000','Revoked Registration','Offline','Allotment of project site cancelled by Competent Authority i.e. GMADA ','','','','','',1,1,1,0,0,0,0,'admprogrammer.rera','2024-09-10 12:21:08.000','admprogrammer.rera','2024-09-10 12:21:08.000'),(7,3,'PRevNo00032024','2024','f193be5c-b13c-42ce-8d73-4a045acb493b',1080,10437,'PRJ2018SAS1281','','PBRERA-SAS81-PC0075','2018-03-06 00:00:00.000','2024-12-31 00:00:00.000',0,'0001-01-01 00:00:00.000','WTC CHANDIGARH (SUITES)','Erika Infracon India Pvt. Ltd (Other than Individual)','507','','PC','Allotment of project site cancelled by Competent Authority i.e. GMADA','RERA-Pb-EG-T-2024-4968','2024-05-16 00:00:00.000','Revoked Registration','Offline','Allotment of project site canceled by Competent Authority i.e. GMADA','','','','','',1,1,1,0,0,0,0,'admprogrammer.rera','2024-09-17 10:53:05.000','admprogrammer.rera','2024-09-17 10:53:05.000'),(8,4,'PRevNo00042024','2024','f193be5c-b13c-42ce-8d73-4a045acb493b',2022,11568,'PRJ2022SAS0157','','PBRERA-SAS80-PR0886','2024-01-08 00:00:00.000','2025-03-31 00:00:00.000',0,'0001-01-01 00:00:00.000','LA-CANELA','ABS Townships Private LImited (Other than Individual)','507','','PR','License to Develop colony cancelled by Competent Authority i.e. GMADA','RERA-Pb-Legal-2024-8821-8822','2024-09-06 00:00:00.000','Revoked Registration','Offline','License to Develop colony cancelled by Competent Authority i.e. GMADA','','','','','',1,1,1,0,0,0,0,'admprogrammer.rera','2024-09-23 13:09:09.000','admprogrammer.rera','2024-09-23 13:09:09.000'),(9,5,'PRevNo00052024','2024','f193be5c-b13c-42ce-8d73-4a045acb493b',1475,10573,'PRJ2018SAS1416','FormE2021SAS0045','PBRERA-SAS80-PM0045','2018-03-06 00:00:00.000','2020-11-08 00:00:00.000',1,'2023-03-19 00:00:00.000','Suntec City','The Indian Co-operative House Building Society (Other than Individual)','507','','PM','License to Develop colony cancelled by Competent Authority i.e. GMADA','RERA-Pb-Legal-2024-8821-8822','2024-09-06 00:00:00.000','Revoked Registration','Offline','License to Develop colony cancelled by Competent Authority i.e. GMADA','','','','','',1,1,1,0,0,0,0,'admprogrammer.rera','2024-09-23 13:11:22.000','admprogrammer.rera','2024-09-23 13:11:22.000'),(10,6,'PRevNo00062024','2024','f193be5c-b13c-42ce-8d73-4a045acb493b',2022,11191,'PRJ2020SAS2011','FormE2023SAS0037','PBRERA-SAS80-PC0155','2021-08-19 00:00:00.000','2023-03-20 00:00:00.000',1,'2024-03-20 00:00:00.000','District Seven','VRS Townships Private LImited (Other than Individual)','507','','PC','License to Develop colony cancelled by Competent Authority i.e. GMADA','RERA-Pb-Legal-2024-8823-8824','2024-09-06 00:00:00.000','Revoked Registration','Offline','License to Develop colony cancelled by Competent Authority i.e. GMADA','','','','','',1,1,1,0,0,0,0,'admprogrammer.rera','2024-09-24 17:04:09.000','admprogrammer.rera','2024-09-24 17:04:09.000'),(11,1,'PRevNo00012026','2026','f193be5c-b13c-42ce-8d73-4a045acb493b',1300,10343,'PRJ2018LDH1208','','PBRERA-LDH45-PR0683','2021-01-04 00:00:00.000','2023-09-30 00:00:00.000',0,'0001-01-01 00:00:00.000','ECO POLIS ','Shri Ramdas Infrastructure Private Limited (Other than Individual)','366','','PR','Request for de-registration of the project','2409','2026-01-02 00:00:00.000','Withdrawn Registration','Offline','Request for the de-registration as per minutes of the meeting dated 25.02.2026.','','','','','',1,1,1,0,1,0,0,'admprogrammer.rera','2026-04-15 16:18:17.000','admprogrammer.rera','2026-04-15 16:18:17.000');
/*!40000 ALTER TABLE `tbl_rera_project_revoke_regdiarynumber` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:31
