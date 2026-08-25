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
-- Table structure for table `tbl_rera_master_project_formextension_checklistmappings`
--

DROP TABLE IF EXISTS `tbl_rera_master_project_formextension_checklistmappings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_project_formextension_checklistmappings` (
  `ChecklistMasterMapping_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `RelatedSubChecklist_ID` int(11) NOT NULL,
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
  PRIMARY KEY (`ChecklistMasterMapping_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_project_formextension_checklistmappings`
--

LOCK TABLES `tbl_rera_master_project_formextension_checklistmappings` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_project_formextension_checklistmappings` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_project_formextension_checklistmappings` VALUES (1,9101,501,19,'Authenticated Plan of the project development works','0','0',1,0,'sysadmin','2018-11-14 13:08:00.000','sysadmin','2018-11-14 13:08:00.000'),(2,9102,502,21,'State of development work and reason for not completing (explanatory note)','0','0',1,0,'sysadmin','2018-11-14 13:08:00.000','sysadmin','2018-11-14 13:08:00.000'),(3,9103,503,29,'RERA Registration Certificate','0','0',1,0,'sysadmin','2018-11-14 13:08:00.000','sysadmin','2018-11-14 13:08:00.000'),(4,9104,504,22,'Valid License to develop colony/ project or Regularization Certificate','0','0',1,0,'sysadmin','2018-11-14 13:08:00.000','sysadmin','2018-11-14 13:08:00.000'),(5,9105,505,30,'Demand Draft for the sum calculated or Copy of Demand Draft to be annexed in the file','0','0',1,0,'sysadmin','2018-11-14 13:08:00.000','sysadmin','2018-11-14 13:08:00.000'),(6,9106,506,18,'Form-E Application Details','0','0',1,0,'sysadmin','2018-11-14 13:08:00.000','sysadmin','2018-11-14 13:08:00.000'),(7,9107,507,20,'Authenticated Plan of the project development works','0','0',1,0,'sysadmin','2019-08-07 11:15:00.000','sysadmin','2019-08-07 11:15:00.000'),(8,9108,508,31,'Proforma for Undertaking- cum-Indemnity Bond','0','0',1,0,'sysadmin','2022-12-12 10:10:00.000','sysadmin','2022-12-12 10:10:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_project_formextension_checklistmappings` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:37
