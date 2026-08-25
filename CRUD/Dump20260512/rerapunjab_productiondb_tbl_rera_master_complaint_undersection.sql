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
-- Table structure for table `tbl_rera_master_complaint_undersection`
--

DROP TABLE IF EXISTS `tbl_rera_master_complaint_undersection`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_complaint_undersection` (
  `UnderSection_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `UnderSection_ID` int(11) NOT NULL,
  `UnderSection_SerialOrder` int(11) NOT NULL,
  `UnderSectionCode` int(11) NOT NULL,
  `UnderSectionName` varchar(150) NOT NULL,
  `UnderSectionYear` int(11) NOT NULL,
  `UnderSectionType` varchar(150) NOT NULL,
  `UnderSectionDescription` varchar(250) NOT NULL,
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
  PRIMARY KEY (`UnderSection_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_complaint_undersection`
--

LOCK TABLES `tbl_rera_master_complaint_undersection` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_complaint_undersection` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_complaint_undersection` VALUES (1,6001,9,6001,'Section 67',2016,'Act','Penalty for failure to comply with orders of Authority by allottee.','',NULL,NULL,NULL,1,1,0,0,'sysadmin','2021-08-01 10:10:00.000','sysadmin','2021-08-01 10:10:00.000'),(2,6002,8,6002,'Section 65',2016,'Act','Penalty for failure to comply with orders of Authority by real estate agent.','',NULL,NULL,NULL,1,1,0,0,'sysadmin','2021-08-01 10:10:00.000','sysadmin','2021-08-01 10:10:00.000'),(3,6003,7,6003,'Section 63',2016,'Act','Penalty for failure to comply with orders of Authority by promoter.','',NULL,NULL,NULL,1,1,0,0,'sysadmin','2021-08-01 10:10:00.000','sysadmin','2021-08-01 10:10:00.000'),(4,6004,2,6004,'Section 40',2016,'Act','Recovery of interest or penalty or compensation and enforcement of order, etc.','',NULL,NULL,NULL,1,1,0,0,'sysadmin','2021-08-01 10:10:00.000','sysadmin','2021-08-01 10:10:00.000'),(5,6005,1,6005,'Section 31',2016,'Act','Filing of complaints with the Authority or the adjudicating officer.','',NULL,NULL,NULL,1,1,0,0,'sysadmin','2021-08-01 10:10:00.000','sysadmin','2021-08-01 10:10:00.000'),(6,6006,5,6006,'Section 61',2016,'Act','Penalty for contravention of other provisions of this Act.','',NULL,NULL,NULL,1,1,0,0,'sysadmin','2021-08-01 10:10:00.000','sysadmin','2021-08-01 10:10:00.000'),(7,6007,6,6007,'Section 62',2016,'Act','Penalty for nonregistration and contravention under sections 9 and 10.','',NULL,NULL,NULL,1,1,0,0,'sysadmin','2021-08-01 10:10:00.000','sysadmin','2021-08-01 10:10:00.000'),(8,6999,10,6999,'Other',2016,'Act','Any Other','',NULL,NULL,NULL,1,1,0,0,'sysadmin','2021-08-01 10:10:00.000','sysadmin','2021-08-01 10:10:00.000'),(9,6008,3,6008,'Section 59',2016,'Act','Punishment for non registration under section 3.','',NULL,NULL,NULL,1,1,0,0,'sysadmin','2022-07-01 10:10:00.000','sysadmin','2022-07-01 10:10:00.000'),(10,6009,4,6009,'Section 60',2016,'Act','Punishment for registration under section 60.','',NULL,NULL,NULL,1,1,0,0,'sysadmin','2022-12-15 10:10:00.000','sysadmin','2022-12-15 10:10:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_complaint_undersection` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:22
