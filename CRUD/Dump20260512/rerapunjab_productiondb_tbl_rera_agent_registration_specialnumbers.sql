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
-- Table structure for table `tbl_rera_agent_registration_specialnumbers`
--

DROP TABLE IF EXISTS `tbl_rera_agent_registration_specialnumbers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_agent_registration_specialnumbers` (
  `SpecialNumber_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `SpecialNumber_ID` bigint(20) NOT NULL,
  `Reference_AgentStateType` varchar(50) NOT NULL,
  `SpecialNumber` bigint(20) NOT NULL,
  `VVIPcategory` int(11) NOT NULL,
  `PriceValue` decimal(18,2) NOT NULL,
  `Remarks_IfAny` varchar(300) DEFAULT NULL,
  `A_column` varchar(50) DEFAULT NULL,
  `B_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsAllotted` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`SpecialNumber_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_agent_registration_specialnumbers`
--

LOCK TABLES `tbl_rera_agent_registration_specialnumbers` WRITE;
/*!40000 ALTER TABLE `tbl_rera_agent_registration_specialnumbers` DISABLE KEYS */;
INSERT INTO `tbl_rera_agent_registration_specialnumbers` VALUES (1,107,'PUN',2000,1,0.00,NULL,NULL,NULL,2,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(2,108,'PUN',2100,1,0.00,NULL,NULL,NULL,2,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(3,109,'PUN',2200,1,0.00,NULL,NULL,NULL,1,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(4,110,'PUN',2222,1,0.00,NULL,NULL,NULL,1,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(5,111,'CHD',500,1,0.00,NULL,NULL,NULL,2,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(6,112,'CHD',555,1,0.00,NULL,NULL,NULL,2,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(7,113,'CHD',600,1,0.00,NULL,NULL,NULL,2,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(8,114,'CHD',666,1,0.00,NULL,NULL,NULL,1,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(9,115,'HIM',500,1,0.00,NULL,NULL,NULL,2,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(10,116,'HIM',555,1,0.00,NULL,NULL,NULL,2,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(11,117,'HIM',600,1,0.00,NULL,NULL,NULL,1,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(12,118,'HIM',666,1,0.00,NULL,NULL,NULL,1,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(13,119,'HRY',300,1,0.00,NULL,NULL,NULL,2,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(14,120,'HRY',333,1,0.00,NULL,NULL,NULL,2,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(15,121,'HRY',400,1,0.00,NULL,NULL,NULL,2,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(16,122,'HRY',444,1,0.00,NULL,NULL,NULL,1,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(17,123,'OTH',666,1,0.00,NULL,NULL,NULL,2,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(18,124,'OTH',777,1,0.00,NULL,NULL,NULL,2,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(19,125,'OTH',888,1,0.00,NULL,NULL,NULL,1,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(20,126,'OTH',999,1,0.00,NULL,NULL,NULL,1,0,0,0,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000');
/*!40000 ALTER TABLE `tbl_rera_agent_registration_specialnumbers` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:37
