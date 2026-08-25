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
-- Table structure for table `tbl_rera_master_project_photographstatustitlelist`
--

DROP TABLE IF EXISTS `tbl_rera_master_project_photographstatustitlelist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_project_photographstatustitlelist` (
  `StatusTitleList_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `StatusTitleList_ID` int(11) NOT NULL,
  `StatusTitleListName` varchar(200) NOT NULL,
  `StatusTitleListDescription` varchar(500) DEFAULT NULL,
  `StatusImg_RelatedSectionName` varchar(90) NOT NULL,
  `StatusImg_SetFileSize` varchar(50) NOT NULL,
  `StatusImg_SetFileFormat` varchar(50) NOT NULL,
  `StatusImg_SetFilePath` varchar(250) NOT NULL,
  `StatusTitleFlag` int(11) NOT NULL,
  `StatusImg_ValidCode` int(11) NOT NULL,
  `StatusImg_ValidSubCode` int(11) NOT NULL,
  `IsGroup` int(11) NOT NULL,
  `IsMandatory` varchar(10) NOT NULL,
  `A_column` varchar(500) DEFAULT NULL,
  `B_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` varchar(90) DEFAULT NULL,
  `CreatedOn` datetime(3) DEFAULT NULL,
  `ModifyBy` varchar(90) DEFAULT NULL,
  `ModifyOn` datetime(3) DEFAULT NULL,
  PRIMARY KEY (`StatusTitleList_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_project_photographstatustitlelist`
--

LOCK TABLES `tbl_rera_master_project_photographstatustitlelist` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_project_photographstatustitlelist` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_project_photographstatustitlelist` VALUES (1,5001,'Stage 1: Site Works','Stage 1: Site Works','Quarterly Update Registered Project','512048','JPEG/JPG','rwQUPrjGeoImg',1,0,0,4,'1','10','5242880',1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(2,5002,'Stage 2: Slab Down','Stage 2: Slab Down','Quarterly Update Registered Project','512048','JPEG/JPG','rwQUPrjGeoImg',2,0,0,4,'1','10','5242880',1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(3,5003,'Stage 3: Plate High','Stage 3: Plate High','Quarterly Update Registered Project','512048','JPEG/JPG','rwQUPrjGeoImg',3,0,0,4,'1','10','5242880',1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(4,5004,'Stage 4: Roof Completion','Stage 4: Roof Completion','Quarterly Update Registered Project','512048','JPEG/JPG','rwQUPrjGeoImg',4,0,0,4,'1','10','5242880',1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(5,5005,'Stage 5: Lockup','Stage 5: Lockup','Quarterly Update Registered Project','512048','JPEG/JPG','rwQUPrjGeoImg',5,0,0,4,'1','10','5242880',1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(6,5006,'Stage 6: Cabinets, Fixtures and Fittings','Stage 6: Cabinets, Fixtures and Fittings','Quarterly Update Registered Project','512048','JPEG/JPG','rwQUPrjGeoImg',6,0,0,4,'1','10','5242880',1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(7,5007,'Stage 7: Practical Completion','Stage 7: Practical Completion','Quarterly Update Registered Project','512048','JPEG/JPG','rwQUPrjGeoImg',7,0,0,4,'1','10','5242880',1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(8,5008,'Stage 8: Handover','Stage 8: Handover','Quarterly Update Registered Project','512048','JPEG/JPG/PDF','rwQUPrjGeoImg',8,0,0,4,'1','10','5242880',1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(9,5009,'Other: Front View','Other: Front View','Quarterly Update Registered Project','512048','JPEG/JPG','rwQUPrjGeoImg',9,0,0,4,'1','10','5242880',1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(10,5010,'Other: Side View','Other: Side View','Quarterly Update Registered Project','512048','JPEG/JPG','rwQUPrjGeoImg',10,0,0,4,'1','10','5242880',1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(11,5011,'Other: Floor Wise View','Other: Floor Wise View','Quarterly Update Registered Project','512048','JPEG/JPG','rwQUPrjGeoImg',11,0,0,4,'1','10','5242880',1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(12,5012,'Other: lnternal Roads & Footpaths','Other: lnternal Roads & Footpaths','Quarterly Update Registered Project','512048','JPEG/JPG','rwQUPrjGeoImg',12,0,0,4,'1','10','5242880',1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(13,5013,'Other: Street Lights','Other: Street Lights','Quarterly Update Registered Project','512048','JPEG/JPG','rwQUPrjGeoImg',13,0,0,4,'1','10','5242880',1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(14,5014,'Other: Hookup to water main, or well drilling','Other: Hookup to water main, or well drilling','Quarterly Update Registered Project','512048','JPEG/JPG','rwQUPrjGeoImg',14,0,0,4,'1','10','5242880',1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(15,5015,'Other: Hookup to sewer or installation of a septic system','Other: Hookup to sewer or installation of a septic system','Quarterly Update Registered Project','512048','JPEG/JPG','rwQUPrjGeoImg',15,0,0,4,'1','10','5242880',1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(16,5016,'Other: Installation of Lift','Other: Installation of Lift','Quarterly Update Registered Project','512048','JPEG/JPG','rwQUPrjGeoImg',16,0,0,4,'1','10','5242880',1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(17,5017,'Other: Open or Covered Parking /Garages','Other: Open or Covered Parking /Garages','Quarterly Update Registered Project','512048','JPEG/JPG','rwQUPrjGeoImg',17,0,0,4,'1','10','5242880',1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_project_photographstatustitlelist` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:25
