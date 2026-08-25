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
-- Table structure for table `tbl_rera_master_puc_category_changerequestfor`
--

DROP TABLE IF EXISTS `tbl_rera_master_puc_category_changerequestfor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_puc_category_changerequestfor` (
  `ChangeRequest_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ChangeRequest_Code` bigint(20) NOT NULL,
  `ChangeRequest_ApplicableFor` varchar(50) NOT NULL,
  `ChangeRequest_SubApplicableFor` varchar(50) NOT NULL,
  `ChangeRequest_Aggregate` varchar(100) NOT NULL,
  `ChangeRequest_Description` varchar(300) NOT NULL,
  `Target_ResolutionDuration` int(11) NOT NULL,
  `Target_ResolutionSummary` varchar(100) NOT NULL,
  `ChangeRequest_ValidCode` int(11) NOT NULL,
  `ChangeRequest_IsGroup` int(11) NOT NULL,
  `ChangeRequest_IsMandatory` int(11) NOT NULL,
  `A_column` varchar(250) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ChangeRequest_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_puc_category_changerequestfor`
--

LOCK TABLES `tbl_rera_master_puc_category_changerequestfor` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_puc_category_changerequestfor` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_puc_category_changerequestfor` VALUES (1,601,'Project','7b9d725a-b33c-4aba-934a-bee1ec13f684','Special Bank Account','Application Change Rquest for Special Bank Account',3,'Approval Process',1,1,1,'PSpBankAC',1,'sysadmin','2020-06-16 16:35:35.000','sysadmin','2020-06-16 16:35:35.000'),(2,602,'Project','7b9d725a-b33c-4aba-934a-bee1ec13f684','Project Name','Application Change Rquest for Project Name',3,'Approval Process',1,1,1,'PNam',1,'sysadmin','2020-06-16 16:35:35.000','sysadmin','2020-06-16 16:35:35.000'),(3,603,'Project','7b9d725a-b33c-4aba-934a-bee1ec13f684','Promoter Name','Application Change Rquest for Promoter Name',3,'Approval Process',1,1,1,'PrmNam',1,'sysadmin','2020-06-16 16:35:35.000','sysadmin','2020-06-16 16:35:35.000'),(4,604,'Project','7b9d725a-b33c-4aba-934a-bee1ec13f684','Authorized Person of Promoter','Application Change Rquest for Authorized Person of Promoter',3,'Approval Process',1,1,1,'PAuthPn',1,'sysadmin','2020-06-16 16:35:35.000','sysadmin','2020-06-16 16:35:35.000'),(5,605,'Project','7b9d725a-b33c-4aba-934a-bee1ec13f684','Contact Person of Project','Application Change Rquest for Contact Person of Project',3,'Approval Process',1,1,1,'PrmAuthPn',1,'sysadmin','2020-06-16 16:35:35.000','sysadmin','2020-06-16 16:35:35.000'),(6,606,'Project','7b9d725a-b33c-4aba-934a-bee1ec13f684','Promoter Type (Individual/OTI)','Application Change Rquest for Promoter Type (Individual/Other Than Individual)',3,'Approval Process',1,1,1,'PTypeInd2OTI',1,'sysadmin','2020-06-16 16:35:35.000','sysadmin','2020-06-16 16:35:35.000'),(7,607,'Project','7b9d725a-b33c-4aba-934a-bee1ec13f684','Project Address','Application Change Rquest for Project Address Details',3,'Approval Process',1,1,1,'PrjAddress',1,'sysadmin','2020-11-02 09:13:54.000','sysadmin','2020-11-02 09:13:54.000'),(8,608,'Project','7b9d725a-b33c-4aba-934a-bee1ec13f684','Promoter Address','Application Change Rquest for Promoter Address Details',3,'Approval Process',1,1,1,'PrmtrAddress',1,'sysadmin','2020-11-02 09:13:54.000','sysadmin','2020-11-02 09:13:54.000'),(9,609,'Project','7b9d725a-b33c-4aba-934a-bee1ec13f684','Correction of Date (Form-B)','Application Change Rquest for Correction of Date (Form-B)',3,'Approval Process',1,1,1,'PrjDtFormB',1,'sysadmin','2020-11-02 09:13:54.000','sysadmin','2020-11-02 09:13:54.000'),(10,610,'Project','7b9d725a-b33c-4aba-934a-bee1ec13f684','Correction of Project Facts','Application Change Rquest for Correction of Project Facts',3,'Approval Process',1,1,1,'PrjFact',1,'sysadmin','2020-11-02 09:13:54.000','sysadmin','2020-11-02 09:13:54.000'),(11,611,'Project','7b9d725a-b33c-4aba-934a-bee1ec13f684','Change of Project Land Details','Application Change Rquest for Project Land Details',3,'Approval Process',1,1,1,'PrjLand',1,'sysadmin','2020-11-02 09:13:54.000','sysadmin','2020-11-02 09:13:54.000'),(12,612,'Project','7b9d725a-b33c-4aba-934a-bee1ec13f684','File Correction (PUC)(Return to Promoter)','File Correction (PUC) (Complete Return to Promoter)',15,'Approval Process',1,1,1,'FileCorrectPUC',1,'sysadmin','2020-11-02 09:13:54.000','sysadmin','2020-11-02 09:13:54.000');
/*!40000 ALTER TABLE `tbl_rera_master_puc_category_changerequestfor` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:50
