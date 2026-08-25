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
-- Table structure for table `tbl_rera_project_projectfactsadditionalslogs`
--

DROP TABLE IF EXISTS `tbl_rera_project_projectfactsadditionalslogs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_project_projectfactsadditionalslogs` (
  `ProjectFactsAdditionals_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ProjectFactsAdditionals_ID` bigint(20) NOT NULL,
  `Related_ProjectID` bigint(20) NOT NULL,
  `Related_PromoterID` bigint(20) NOT NULL,
  `Project_Status` varchar(50) NOT NULL,
  `ProjectStart_Date` datetime(3) NOT NULL,
  `ProjectCompletion_ProposedDate` datetime(3) NOT NULL,
  `ProjectCompletion_OriginalDate` datetime(3) NOT NULL,
  `ProjectRegistrationProvided_Duration` varchar(90) NOT NULL,
  `ProjectDelayReason_IfAny` varchar(255) DEFAULT NULL,
  `ProjectCostINR` decimal(18,2) NOT NULL,
  `Project_RegNumberRERA_IfAny` varchar(100) DEFAULT NULL,
  `Account_FormDate` datetime(3) NOT NULL,
  `Account_ToDate` datetime(3) NOT NULL,
  `Account_ModeFlag` varchar(100) NOT NULL,
  `Remarks_IfAny` varchar(150) DEFAULT NULL,
  `A_column` varchar(50) DEFAULT NULL,
  `B_column` varchar(50) DEFAULT NULL,
  `C_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `IsApproved` int(11) NOT NULL,
  `Account_ApprovedDate` datetime(3) NOT NULL,
  `IsMemberApproved` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ProjectFactsAdditionals_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=1003 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_project_projectfactsadditionalslogs`
--

LOCK TABLES `tbl_rera_project_projectfactsadditionalslogs` WRITE;
/*!40000 ALTER TABLE `tbl_rera_project_projectfactsadditionalslogs` DISABLE KEYS */;
INSERT INTO `tbl_rera_project_projectfactsadditionalslogs` VALUES (1001,1001,11111,1940,'On-going','2005-06-07 00:00:00.000','2020-03-31 00:00:00.000','2020-03-31 00:00:00.000','0 year(s) 0 month(s) 1 day(s)',NULL,43765450.00,NULL,'2020-01-08 16:18:25.000','2020-05-11 11:18:25.000','OnlineRegData',NULL,NULL,NULL,NULL,1,1,1,1,'2020-05-11 11:18:25.000',1,'sysadmin','2020-05-11 11:18:25.000','sysadmin','2020-05-11 11:18:25.000'),(1002,1002,11029,1867,'Complete','2019-04-24 00:00:00.000','2026-06-30 00:00:00.000','2026-06-30 00:00:00.000','0 year(s) 0 month(s) 1 day(s)',NULL,500000000.00,NULL,'2019-10-19 16:04:50.000','2020-05-12 00:00:00.000','OnlineRegData',NULL,NULL,NULL,NULL,1,1,1,1,'2020-05-12 00:00:00.000',1,'sysadmin','2020-05-12 00:00:00.000','sysadmin','2020-05-12 00:00:00.000');
/*!40000 ALTER TABLE `tbl_rera_project_projectfactsadditionalslogs` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:19
