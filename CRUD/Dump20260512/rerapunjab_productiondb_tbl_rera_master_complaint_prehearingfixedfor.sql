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
-- Table structure for table `tbl_rera_master_complaint_prehearingfixedfor`
--

DROP TABLE IF EXISTS `tbl_rera_master_complaint_prehearingfixedfor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_complaint_prehearingfixedfor` (
  `PreHearingDate_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `PreHearingDate_ID` int(11) NOT NULL,
  `PreHearingFixedForCode` int(11) NOT NULL,
  `PreHearingFixedForName` varchar(150) NOT NULL,
  `PreHearingType` varchar(150) NOT NULL,
  `Remarks_IfAny` varchar(250) NOT NULL,
  `A_column` varchar(100) DEFAULT NULL,
  `B_column` varchar(100) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`PreHearingDate_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_complaint_prehearingfixedfor`
--

LOCK TABLES `tbl_rera_master_complaint_prehearingfixedfor` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_complaint_prehearingfixedfor` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_complaint_prehearingfixedfor` VALUES (1,1101,1101,'Preliminary Hearing','FormM','Preliminary Hearing','1',NULL,1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(2,1102,1102,'Notice for Appearance/Reply','FormM','Notice for Appearance/Reply','3',NULL,1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(3,1103,1103,'Consideration','FormM','Consideration','8',NULL,1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(4,1104,1104,'Rejoinder','FormM','Rejoinder','6',NULL,1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(5,1105,1105,'Additional Evidence','FormM','Additional Evidence','10',NULL,1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(6,1106,1106,'Arguments','FormM','Arguments','12',NULL,1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(7,1107,1107,'Orders','FormM','Orders','14',NULL,1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(8,1108,1108,'Final Order','FormM','Final Order','15',NULL,1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(9,1109,1109,'Arguments','FormM','Arguments','9',NULL,2,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(10,1110,1110,'Orders','FormM','Orders','10',NULL,2,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(11,1111,1111,'Mutual Settlement/Consideration','FormM','Mutual Settlement/Consideration','11',NULL,2,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(12,1112,1112,'Arguments/Final Orders','FormM','Arguments/Final Orders','12',NULL,2,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(13,1113,1113,'Additional Evidence','FormM','Additional Evidence','13',NULL,2,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(14,1114,1114,'Publication/Notice/Munadi','FormM','Publication/Notice/Munadi','14',NULL,2,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(15,1115,1115,'For Arguments/Orders','FormM','For Arguments/Orders',NULL,NULL,2,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(16,1116,1116,'For Hearing','FormM','For Hearing',NULL,NULL,2,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(17,2101,2101,'Preliminary Hearing','FormN','Preliminary Hearing','1',NULL,1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(18,2102,2102,'Notice for Appearance/Reply','FormN','Notice for Appearance/Reply','3',NULL,1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(19,2103,2103,'Consideration','FormN','Consideration','8',NULL,1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(20,2104,2104,'Rejoinder','FormN','Rejoinder','6',NULL,1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(21,2105,2105,'Additional Evidence','FormN','Additional Evidence','10',NULL,1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(22,2106,2106,'Arguments','FormN','Arguments','12',NULL,1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(23,2107,2107,'Orders','FormN','Orders','14',NULL,1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(24,2108,2108,'Final Order','FormN','Final Order','15',NULL,1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(25,2109,2109,'Arguments','FormN','Arguments','9',NULL,2,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(26,2110,2110,'Orders','FormN','Orders','10',NULL,2,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(27,2111,2111,'Mutual Settlement/Consideration','FormN','Mutual Settlement/Consideration','11',NULL,2,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(28,2112,2112,'Arguments/Final Orders','FormN','Arguments/Final Orders','12',NULL,2,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(29,2113,2113,'Additional Evidence','FormN','Additional Evidence','13',NULL,2,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(30,2114,2114,'Publication/Notice/Munadi','FormN','Publication/Notice/Munadi','14',NULL,2,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(31,1117,1117,'Notice for Appearance','FormM','Notice for Appearance','2',NULL,1,1,'sysadmin','2019-03-14 13:08:00.000','sysadmin','2019-03-14 13:08:00.000'),(32,1118,1118,'Notice for Reply','FormM','Notice for Reply','4',NULL,1,1,'sysadmin','2019-03-14 13:08:00.000','sysadmin','2019-03-14 13:08:00.000'),(33,1119,1119,'Withdrawn','FormM','Withdrawn','8',NULL,1,1,'sysadmin','2019-03-14 13:08:00.000','sysadmin','2019-03-14 13:08:00.000'),(34,2117,2117,'Notice for Appearance','FormN','Notice for Appearance','2',NULL,1,1,'sysadmin','2019-03-14 13:08:00.000','sysadmin','2019-03-14 13:08:00.000'),(35,2118,2118,'Notice for Reply','FormN','Notice for Reply','4',NULL,1,1,'sysadmin','2019-03-14 13:08:00.000','sysadmin','2019-03-14 13:08:00.000'),(36,2119,2119,'Withdrawn','FormN','Withdrawn','8',NULL,1,1,'sysadmin','2019-03-14 13:08:00.000','sysadmin','2019-03-14 13:08:00.000'),(37,1120,1120,'Reply','FormM','Reply','5',NULL,1,1,'sysadmin','2021-02-17 16:08:00.000','sysadmin','2021-02-17 16:08:00.000'),(38,1121,1121,'Compromise','FormM','Compromise','7',NULL,1,1,'sysadmin','2021-02-17 16:08:00.000','sysadmin','2021-02-17 16:08:00.000'),(39,1122,1122,'Ex-parte Evidence','FormM','Ex-parte Evidence','11',NULL,1,1,'sysadmin','2021-02-17 16:08:00.000','sysadmin','2021-02-17 16:08:00.000'),(40,2120,2120,'Reply','FormN','Reply','5',NULL,1,1,'sysadmin','2021-02-17 16:08:00.000','sysadmin','2021-02-17 16:08:00.000'),(41,2121,2121,'Compromise','FormN','Compromise','7',NULL,1,1,'sysadmin','2021-02-17 16:08:00.000','sysadmin','2021-02-17 16:08:00.000'),(42,2122,2122,'Ex-parte Evidence','FormN','Ex-parte Evidence','11',NULL,1,1,'sysadmin','2021-02-17 16:08:00.000','sysadmin','2021-02-17 16:08:00.000'),(43,1123,1123,'Further Proceedings','FormM','Further Proceedings','9',NULL,1,1,'sysadmin','2022-02-15 10:10:00.000','sysadmin','2022-02-15 10:10:00.000'),(44,2123,2123,'Further Proceedings','FormN','Further Proceedings','9',NULL,1,1,'sysadmin','2022-02-15 10:10:00.000','sysadmin','2022-02-15 10:10:00.000'),(45,1124,1124,'Sine-die','FormM','Sine-die Cases','16',NULL,1,1,'sysadmin','2025-04-24 11:10:00.000','sysadmin','2025-04-24 11:10:00.000'),(46,2124,2124,'Sine-die','FormN','Sine-die Cases','16',NULL,1,1,'sysadmin','2025-04-24 11:10:00.000','sysadmin','2025-04-24 11:10:00.000'),(47,1125,1125,'Warrants','FormM','Warrants of Recovery','13',NULL,1,1,'sysadmin','2025-07-25 11:10:00.000','sysadmin','2025-07-25 11:10:00.000'),(48,2125,2125,'Warrants','FormN','Warrants of Recovery','13',NULL,1,1,'sysadmin','2025-07-25 11:10:00.000','sysadmin','2025-07-25 11:10:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_complaint_prehearingfixedfor` ENABLE KEYS */;
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
