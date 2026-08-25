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
-- Table structure for table `tbl_rera_master_complaint_courtcasetypes`
--

DROP TABLE IF EXISTS `tbl_rera_master_complaint_courtcasetypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_complaint_courtcasetypes` (
  `CaseType_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `CaseType_ID` int(11) NOT NULL,
  `CaseType_SerialOrder` int(11) NOT NULL,
  `CaseTypeCode` int(11) NOT NULL,
  `CaseTypeName` varchar(150) NOT NULL,
  `Category` varchar(150) NOT NULL,
  `CaseTypeDescription` varchar(250) NOT NULL,
  `Remarks_IfAny` varchar(250) NOT NULL,
  `A_column` varchar(100) DEFAULT NULL,
  `B_column` varchar(100) DEFAULT NULL,
  `C_column` varchar(100) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `IsFlag` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`CaseType_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_complaint_courtcasetypes`
--

LOCK TABLES `tbl_rera_master_complaint_courtcasetypes` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_complaint_courtcasetypes` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_complaint_courtcasetypes` VALUES (1,5001,1,5001,'Complaint Case','FormMN','Complaint filed before RERA Punjab','','Order',NULL,NULL,1,1,0,0,'sysadmin','2021-08-01 10:10:00.000','sysadmin','2021-08-01 10:10:00.000'),(2,5002,2,5002,'Review Application Case','FormMN','Review Application Case in the complaint filed before RERA Punjab','','Order (Review Case)',NULL,NULL,1,1,0,0,'sysadmin','2021-08-01 10:10:00.000','sysadmin','2021-08-01 10:10:00.000'),(3,5003,3,5003,'Re-Open Application Case','FormMN','ReOpen Application Case in the complaint filed before RERA Punjab','','Order (Re-Open Case)',NULL,NULL,1,1,0,0,'sysadmin','2021-08-01 10:10:00.000','sysadmin','2021-08-01 10:10:00.000'),(4,5004,4,5004,'Execution Application Case','FormMN','Execution Application Case in the complaint filed before RERA Punjab','','Order (Execution Application)',NULL,NULL,1,1,0,0,'sysadmin','2021-08-01 10:10:00.000','sysadmin','2021-08-01 10:10:00.000'),(5,5005,5,5005,'Miscellaneous Application Case','FormMN','Miscellaneous Application Case in the complaint filed before RERA Punjab','','Order (Miscellaneous Application)',NULL,NULL,1,1,0,0,'sysadmin','2022-03-17 10:10:00.000','sysadmin','2022-03-17 10:10:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_complaint_courtcasetypes` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:20
