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
-- Table structure for table `tbl_rera_master_agent_checklist`
--

DROP TABLE IF EXISTS `tbl_rera_master_agent_checklist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_agent_checklist` (
  `CheckList_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `CheckList_Code` int(11) NOT NULL,
  `CheckList_Name` varchar(200) NOT NULL,
  `CheckList_Head` varchar(100) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`CheckList_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_agent_checklist`
--

LOCK TABLES `tbl_rera_master_agent_checklist` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_agent_checklist` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_agent_checklist` VALUES (1,501,'Form G as defined in the Rules','Profile',2,'sysadmin','2018-04-01 14:12:03.000','sysadmin','2018-04-01 14:12:03.000'),(2,502,'Name, photograph, contact details and address','Profile',2,'sysadmin','2018-04-01 14:12:38.000','sysadmin','2018-04-01 14:12:38.000'),(3,503,'Agent enterprise details','Profile',2,'sysadmin','2018-04-01 14:13:06.000','sysadmin','2018-04-01 14:13:06.000'),(4,504,'Copy of Address proof','Agent Documents',2,'sysadmin','2018-04-01 14:13:15.000','sysadmin','2018-04-01 14:13:15.000'),(5,505,'PAN Card of the real estate agent','Agent Documents',2,'sysadmin','2018-04-01 14:13:22.000','sysadmin','2018-04-01 14:13:22.000'),(6,506,'Income Tax Returns','Agent Documents',2,'sysadmin','2018-04-01 14:14:11.000','sysadmin','2018-04-01 14:14:11.000'),(7,507,'Registration Fee','Agent Payment',2,'sysadmin','2018-04-01 14:14:14.000','sysadmin','2018-04-01 14:14:14.000'),(8,510,'Agent (Individual Profile) Details','Agent Profile',2,'sysadmin','2018-04-01 14:14:14.000','sysadmin','2018-04-01 14:14:14.000'),(9,511,'Agent Profile','Agent Profile',1,'sysadmin','2018-04-01 14:14:14.000','sysadmin','2018-04-27 14:14:14.000'),(10,512,'Payment Details','Agent Profile',1,'sysadmin','2018-04-01 14:14:14.000','sysadmin','2018-04-01 14:14:14.000'),(11,513,'Agent Documents','Agent Profile',1,'sysadmin','2018-04-01 14:14:14.000','sysadmin','2018-04-01 14:14:14.000'),(12,514,'RERA Registration with other State/UT','Agent Profile',1,'sysadmin','2018-04-01 14:14:14.000','sysadmin','2018-04-01 14:14:14.000');
/*!40000 ALTER TABLE `tbl_rera_master_agent_checklist` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:12
