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
-- Table structure for table `tbl_rera_project_quarterlyupdate_regdiarynumberprovider`
--

DROP TABLE IF EXISTS `tbl_rera_project_quarterlyupdate_regdiarynumberprovider`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_project_quarterlyupdate_regdiarynumberprovider` (
  `QUpdateProject_RegDNProvider_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `QUpdateProject_RegDNProvider_ID` bigint(20) NOT NULL,
  `QUpdateProject_Year` int(11) NOT NULL,
  `QUpdateProject_QuarterName` varchar(100) NOT NULL,
  `UserID` varchar(50) NOT NULL,
  `PromoterID` bigint(20) NOT NULL,
  `ProjectID` bigint(20) NOT NULL,
  `Remarks_IfAny` varchar(250) DEFAULT NULL,
  `A_column` varchar(50) DEFAULT NULL,
  `B_column` varchar(50) DEFAULT NULL,
  `C_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsDraftSecMember` int(11) NOT NULL,
  `IsDraftMember` int(11) NOT NULL,
  `IsActiveProvider` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`QUpdateProject_RegDNProvider_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_project_quarterlyupdate_regdiarynumberprovider`
--

LOCK TABLES `tbl_rera_project_quarterlyupdate_regdiarynumberprovider` WRITE;
/*!40000 ALTER TABLE `tbl_rera_project_quarterlyupdate_regdiarynumberprovider` DISABLE KEYS */;
INSERT INTO `tbl_rera_project_quarterlyupdate_regdiarynumberprovider` VALUES (1,1,2020,'SecondQTR','A',0,0,'web-portal quarterly updates','2021-12-31 00:00:00.000','','',1,0,0,0,1,0,'sysadmin','2020-06-11 17:34:14.000','sysadmin','2020-06-11 17:34:14.000'),(2,2,2020,'FourthQTR','A',0,0,'web-portal quarterly updates','2021-12-31 00:00:00.000','','',1,0,0,0,1,0,'sysadmin','2020-06-11 17:34:14.000','sysadmin','2020-06-11 17:34:14.000'),(3,3,2020,'ThirdQTR','A',0,0,'web-portal quarterly updates','2021-12-31 00:00:00.000','','',1,0,0,0,1,0,'sysadmin','2020-06-11 17:34:14.000','sysadmin','2020-06-11 17:34:14.000'),(4,4,2021,'SecondQTR','A',0,0,'','2021-08-02 12:18:29','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(5,5,2021,'ThirdQTR','A',0,0,'','2021-11-04 15:22:02','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(6,6,2021,'FourthQTR','A',0,0,'','2022-02-04 11:53:40','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(7,7,2021,'FirstQTR','A',0,0,'web-portal quarterly updates','2021-12-31 00:00:00.000','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(8,8,2022,'FirstQTR','A',0,0,'','2022-05-05 10:40:24','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(9,9,2022,'SecondQTR','A',0,0,'','2022-05-05 10:40:35','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(10,10,2022,'ThirdQTR','A',0,0,'','2022-10-29 19:43:34','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(11,11,2022,'FourthQTR','A',0,0,'','2023-02-04 13:14:26','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(12,12,2023,'FirstQTR','A',0,0,'','2023-05-04 11:22:24','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(13,13,2023,'SecondQTR','A',0,0,'','2023-08-03 14:48:42','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(14,14,2023,'ThirdQTR','A',0,0,'','2023-11-03 12:39:30','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(15,15,2023,'FourthQTR','A',0,0,'','2024-02-03 13:18:29','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(16,16,2024,'FirstQTR','A',0,0,'','2024-05-02 12:23:40','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(17,17,2024,'SecondQTR','A',0,0,'','2024-08-01 13:11:30','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(18,18,2024,'ThirdQTR','A',0,0,'','2024-11-02 15:31:44','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(19,19,2024,'FourthQTR','A',0,0,'','2025-02-02 10:39:32','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(20,20,2025,'FirstQTR','A',0,0,'','2025-05-02 11:43:48','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(21,21,2025,'SecondQTR','A',0,0,'','2025-08-02 10:12:38','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(22,22,2025,'ThirdQTR','A',0,0,'','2025-11-01 11:13:37','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(23,23,2025,'FourthQTR','A',0,0,'','2026-02-02 10:32:13','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(24,24,2026,'FirstQTR','A',0,0,'','2026-05-01 17:13:15','','',1,0,0,0,1,0,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(25,25,2026,'SecondQTR','A',0,0,'','2026-07-31 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(26,26,2026,'ThirdQTR','A',0,0,'','2026-10-31 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(27,27,2026,'FourthQTR','A',0,0,'','2027-01-31 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(28,28,2027,'FirstQTR','A',0,0,'','2027-04-30 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(29,29,2027,'SecondQTR','A',0,0,'','2027-07-31 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(30,30,2027,'ThirdQTR','A',0,0,'','2027-10-31 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(31,31,2027,'FourthQTR','A',0,0,'','2028-01-31 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(32,32,2028,'FirstQTR','A',0,0,'','2028-04-30 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(33,33,2028,'SecondQTR','A',0,0,'','2028-07-31 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(34,34,2028,'ThirdQTR','A',0,0,'','2028-10-31 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(35,35,2028,'FourthQTR','A',0,0,'','2029-01-31 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(36,36,2029,'FirstQTR','A',0,0,'','2029-04-30 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(37,37,2029,'SecondQTR','A',0,0,'','2029-07-31 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(38,38,2029,'ThirdQTR','A',0,0,'','2029-10-31 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(39,39,2029,'FourthQTR','A',0,0,'','2030-01-31 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2020-12-28 10:10:00.000','sysadmin','2020-12-28 10:10:00.000'),(40,40,2030,'FirstQTR','A',0,0,'','2030-04-30 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(41,41,2030,'SecondQTR','A',0,0,'','2030-07-31 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(42,42,2030,'ThirdQTR','A',0,0,'','2030-10-31 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(43,43,2030,'FourthQTR','A',0,0,'','2031-01-31 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(44,44,2020,'FirstQTR','A',0,0,'web-portal quarterly updates','2021-12-31 00:00:00.000','','',1,0,0,0,1,0,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(45,45,2019,'FirstQTR','A',0,0,'web-portal quarterly updates','2021-12-31 00:00:00.000','','',1,0,0,0,1,0,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(46,46,2019,'SecondQTR','A',0,0,'web-portal quarterly updates','2021-12-31 00:00:00.000','','',1,0,0,0,1,0,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(47,47,2019,'ThirdQTR','A',0,0,'web-portal quarterly updates','2021-12-31 00:00:00.000','','',1,0,0,0,1,0,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(48,48,2019,'FourthQTR','A',0,0,'web-portal quarterly updates','2021-12-31 00:00:00.000','','',1,0,0,0,1,0,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(49,49,2018,'FirstQTR','A',0,0,'web-portal quarterly updates','2021-12-31 00:00:00.000','','',1,0,0,0,1,0,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(50,50,2018,'SecondQTR','A',0,0,'web-portal quarterly updates','2021-12-31 00:00:00.000','','',1,0,0,0,1,0,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(51,51,2018,'ThirdQTR','A',0,0,'web-portal quarterly updates','2021-12-31 00:00:00.000','','',1,0,0,0,1,0,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(52,52,2018,'FourthQTR','A',0,0,'web-portal quarterly updates','2021-12-31 00:00:00.000','','',1,0,0,0,1,0,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(53,53,2017,'FirstQTR','A',0,0,'','2017-04-30 17:34:14.000','','',1,0,0,0,0,1,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(54,54,2017,'SecondQTR','A',0,0,'','2017-07-31 17:34:14.000','','',1,0,0,0,0,1,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(55,55,2017,'ThirdQTR','A',0,0,'','2017-10-31 17:34:14.000','','',1,0,0,0,0,1,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(56,56,2017,'FourthQTR','A',0,0,'','2024-01-27 13:12:35','','',1,0,0,0,0,0,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(57,57,2016,'FirstQTR','A',0,0,'','2016-04-30 00:00:00.000','','',1,0,0,0,0,1,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(58,58,2016,'SecondQTR','A',0,0,'','2016-07-31 17:34:14.000','','',1,0,0,0,0,1,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(59,59,2016,'ThirdQTR','A',0,0,'','2016-10-31 17:34:14.000','','',1,0,0,0,0,1,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000'),(60,60,2016,'FourthQTR','A',0,0,'','2017-01-31 17:34:14.000','','',1,0,0,0,0,1,'sysadmin','2021-01-01 21:13:55.000','sysadmin','2021-01-01 21:13:55.000');
/*!40000 ALTER TABLE `tbl_rera_project_quarterlyupdate_regdiarynumberprovider` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:52
