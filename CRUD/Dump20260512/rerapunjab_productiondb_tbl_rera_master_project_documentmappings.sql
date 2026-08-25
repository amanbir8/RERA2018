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
-- Table structure for table `tbl_rera_master_project_documentmappings`
--

DROP TABLE IF EXISTS `tbl_rera_master_project_documentmappings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_project_documentmappings` (
  `ProjectDocMasterMapping_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `RelatedProjectDocMaster_InfoCode` int(11) NOT NULL,
  `KeyCode` int(11) NOT NULL,
  `OrderCode` int(11) NOT NULL,
  `Column_A` varchar(100) NOT NULL,
  `Column_B` varchar(100) NOT NULL,
  `Column_C` varchar(100) NOT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ProjectDocMasterMapping_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_project_documentmappings`
--

LOCK TABLES `tbl_rera_master_project_documentmappings` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_project_documentmappings` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_project_documentmappings` VALUES (1,0,159,999,'Special bank Account Details and Cancelled Cheque Scan Copy','0','999',1,0,'sysadmin','2018-11-14 13:08:00.000','sysadmin','2018-11-14 13:08:00.000'),(2,1011,155,20,'Land Title Search Report','100250','1',1,0,'sysadmin','2018-11-14 13:08:00.000','sysadmin','2018-11-14 13:08:00.000'),(3,1014,155,22,'Details of Land Encumbrances','100248','1',1,0,'sysadmin','2018-11-14 13:08:00.000','sysadmin','2018-11-14 13:08:00.000'),(4,1015,155,21,'Non Encumbrance Certificate','100248','1',1,0,'sysadmin','2018-11-14 13:08:00.000','sysadmin','2018-11-14 13:08:00.000'),(5,1020,155,17,'Legal Title Deed(s) - In case Land is owned by Promoter','100242','1',1,0,'sysadmin','2018-11-14 13:08:00.000','sysadmin','2018-11-14 13:08:00.000'),(6,1021,155,19,'Latest Jamabandi Document','100243','1',1,0,'sysadmin','2018-11-14 13:08:00.000','sysadmin','2018-11-14 13:08:00.000'),(7,1022,155,24,'Consent details of actual owner of Land','100244','1',1,0,'sysadmin','2018-11-14 13:08:00.000','sysadmin','2018-11-14 13:08:00.000'),(8,1023,155,23,'Collaboration or Joint Development Agreement','100245','1',1,0,'sysadmin','2018-11-14 13:08:00.000','sysadmin','2018-11-14 13:08:00.000'),(9,1024,155,18,'Land Title Deed(s) - In case land is not owned by Promoter','100246','1',1,0,'sysadmin','2018-11-14 13:08:00.000','sysadmin','2018-11-14 13:08:00.000'),(10,1028,156,25,'Project Land Khasra Report or Plan','100241','1',1,0,'sysadmin','2018-11-14 13:08:00.000','sysadmin','2018-11-14 13:08:00.000'),(11,0,163,999,'Online Payment/ Demand Draft for the sum calculated as per schedule - I','0','999',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(12,0,170,999,'Litigations Details wrt said Project','0','999',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(13,1001,154,8,'Authenticated Copy of Form B','100225','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(14,1009,154,14,'Draft Agreement of Sale highlighting the changes','100237','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(15,1025,154,9,'Architects Certificate (Form 1)','100259','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(16,1026,154,10,'Engineers Certificate (Form 2)','100260','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(17,1027,154,11,'CA Certificate (Form 3)','100261','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(18,1029,157,16,'Declaration for AFS, CD and Allottment Letter','10023789','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(19,1016,157,4,'Commencement Certificate (Mega Project Category)','100254','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(20,1018,157,2,'CLU Certificate','100256','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(21,1019,157,3,'License to develop colony or society from Competent Authority','100257','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(22,1017,157,1,'Copy of Registration as Promoter','100255','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(23,1010,171,5,'Approved Layout Plan','100252','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(24,1010,172,5,'Approved Layout Plan','100252','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(25,1012,171,6,'Approved Project Site OR Location Map','100253','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(26,1012,172,6,'Approved Project Site OR Location Map','100253','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(27,1013,171,7,'Sanctioned Building Plan','100251','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(28,1013,172,7,'Sanctioned Building Plan','100251','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(29,1025,161,9,'Architects Certificate (Form 1)','100259','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(30,1026,161,10,'Engineers Certificate (Form 2)','100260','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(31,1027,161,11,'CA Certificate (Form 3)','100261','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(32,1001,157,8,'Authenticated Copy of Form B','100225','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(33,1002,158,12,'Pro forma of Allotment Letter to be provided to allottees','100238','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(34,1006,158,15,'Pro forma of Conveyance Deed to be signed with allottees','100239','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000'),(35,1008,158,13,'Pro forma Agreement of Sale to be signed with allottees','100237','1',1,0,'sysadmin','2018-11-15 13:08:00.000','sysadmin','2018-11-15 13:08:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_project_documentmappings` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:42
