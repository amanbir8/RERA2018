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
-- Table structure for table `tbl_rera_master_complaint_benchjudgemap`
--

DROP TABLE IF EXISTS `tbl_rera_master_complaint_benchjudgemap`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_complaint_benchjudgemap` (
  `Bench_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `PreHearingBench_ID` int(11) NOT NULL,
  `PreHearingBenchCode` int(11) NOT NULL,
  `PreHearingBenchName` varchar(150) NOT NULL,
  `PreHearingType` varchar(150) NOT NULL,
  `Court_MappingBenchID` int(11) NOT NULL,
  `Court_MappingFlag` varchar(100) NOT NULL,
  `PriorityLevel` int(11) NOT NULL,
  `PriorityColor` varchar(50) NOT NULL,
  `Bench_Position` varchar(100) NOT NULL,
  `Bench_Jurisdiction` varchar(150) NOT NULL,
  `Bench_Establishment` varchar(150) NOT NULL,
  `Bench_Type` enum('Single','Division','Full') NOT NULL,
  `Bench_Status` varchar(250) NOT NULL,
  `Effective_From` datetime(3) NOT NULL,
  `Effective_To` datetime(3) NOT NULL,
  `A_column` varchar(100) DEFAULT NULL,
  `B_column` varchar(100) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `IsExit` int(11) NOT NULL,
  `IsApproved` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`Bench_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_complaint_benchjudgemap`
--

LOCK TABLES `tbl_rera_master_complaint_benchjudgemap` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_complaint_benchjudgemap` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_complaint_benchjudgemap` VALUES (1,1201,1201,'Sh. Jagdish Singh Khushdil, Member','FormM',0,'NPV',0,'0','0','0','0','Single','Retired','2018-07-25 13:08:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(2,1202,1202,'Sh. Jagdish Singh Khushdil, Adjudicating Officer','FormM',0,'NPV',0,'0','0','0','0','Single','Retired','2018-07-25 13:08:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(3,1203,1203,'Sh. Navreet Singh Kang, Chairperson','FormM',1203,'NPV',0,'0','0','0','0','Single','Retired','2018-07-25 13:08:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(4,1204,1204,'Sh. Sanjiv Gupta, Member','FormM',1204,'NPV',0,'0','0','0','0','Single','Retired','2018-07-25 13:08:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(5,2201,2201,'Sh. Jagdish Singh Khushdil, Member','FormN',0,'NPV',0,'0','0','0','0','Single','Retired','2018-07-25 13:08:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(6,2202,2202,'Sh. Jagdish Singh Khushdil, Adjudicating Officer','FormN',0,'NPV',0,'0','0','0','0','Single','Retired','2018-07-25 13:08:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(7,2203,2203,'Sh. Navreet Singh Kang, Chairperson','FormN',1203,'NPV',0,'0','0','0','0','Single','Retired','2018-07-25 13:08:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(8,2204,2204,'Sh. Sanjiv Gupta, Member','FormN',1204,'NPV',0,'0','0','0','0','Single','Retired','2018-07-25 13:08:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(9,2205,2205,'Authority, RERA Punjab','FormN',1206,'NPV',0,'0','0','0','0','Full','sysadmin','2018-07-25 13:08:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,0,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(10,5501,5501,'Sh. Navreet Singh Kang, Chairperson','SecFiveNine',1203,'NPV',0,'0','0','0','0','Single','Retired','2019-03-19 13:08:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2019-03-19 13:08:00.000','sysadmin','2019-03-19 13:08:00.000'),(11,5502,5502,'Sh. Jagdish Singh Khushdil, Member','SecFiveNine',0,'NPV',0,'0','0','0','0','Single','Retired','2019-03-19 13:08:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2019-03-19 13:08:00.000','sysadmin','2019-03-19 13:08:00.000'),(12,5503,5503,'Sh. Sanjiv Gupta, Member','SecFiveNine',1204,'NPV',0,'0','0','0','0','Single','Retired','2019-03-19 13:08:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2019-03-19 13:08:00.000','sysadmin','2019-03-19 13:08:00.000'),(13,5504,5504,'Authority, RERA Punjab','SecFiveNine',1206,'NPV',0,'0','0','0','0','Full','sysadmin','2019-03-19 13:08:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,0,'sysadmin','2019-03-19 13:08:00.000','sysadmin','2019-03-19 13:08:00.000'),(14,1205,1205,'Sh. Balbir Singh, Adjudicating Officer','FormM',1205,'NPV',0,'0','0','0','0','Single','Retired','2018-07-25 13:08:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(15,2206,2206,'Sh. Balbir Singh, Adjudicating Officer','FormN',1205,'NPV',0,'0','0','0','0','Single','Retired','2018-07-25 13:08:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(16,1206,1206,'Authority, RERA Punjab','FormM',1206,'YPV',0,'0','0','0','0','Full','sysadmin','2020-11-04 00:00:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,1,'sysadmin','2020-11-04 00:00:00.000','sysadmin','2020-11-04 00:00:00.000'),(17,5505,5505,'Sh. Ajay Pal Singh, Member','SecFiveNine',1207,'NPV',0,'0','0','0','0','Single','Retired','2021-06-30 11:08:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2021-06-30 11:08:00.000','sysadmin','2021-06-30 11:08:00.000'),(18,1207,1207,'Sh. Ajay Pal Singh, Member','FormM',1207,'NPV',0,'0','0','0','0','Single','Retired','2021-11-30 17:13:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2021-11-30 17:13:00.000','sysadmin','2021-11-30 17:13:00.000'),(19,2207,2207,'Sh. Ajay Pal Singh, Member','FormN',1207,'NPV',0,'0','0','0','0','Single','Retired','2021-11-30 17:13:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2021-11-30 17:13:00.000','sysadmin','2021-11-30 17:13:00.000'),(20,1208,1208,'Chairperson','FormM',1208,'YPV',0,'0','0','0','0','Division','sysadmin','2022-09-27 11:11:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,1,'sysadmin','2022-09-27 11:11:00.000','sysadmin','2022-09-27 11:11:00.000'),(21,1209,1209,'Member','FormM',1209,'YPV',0,'0','0','0','0','Division','sysadmin','2022-09-27 11:11:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,1,'sysadmin','2022-09-27 11:11:00.000','sysadmin','2022-09-27 11:11:00.000'),(22,1210,1210,'Adjudicating Officer','FormM',1210,'YPV',0,'0','0','0','0','Division','sysadmin','2022-09-27 11:11:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,1,'sysadmin','2022-09-27 11:11:00.000','sysadmin','2022-09-27 11:11:00.000'),(23,2208,2208,'Chairperson','FormN',1208,'NPV',0,'0','0','0','0','Division','sysadmin','2022-09-27 11:11:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,0,'sysadmin','2022-09-27 11:11:00.000','sysadmin','2022-09-27 11:11:00.000'),(24,2209,2209,'Member','FormN',1209,'NPV',0,'0','0','0','0','Division','sysadmin','2022-09-27 11:11:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,0,'sysadmin','2022-09-27 11:11:00.000','sysadmin','2022-09-27 11:11:00.000'),(25,2210,2210,'Adjudicating Officer','FormN',1210,'NPV',0,'0','0','0','0','Division','sysadmin','2022-09-27 11:11:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,0,'sysadmin','2022-09-27 11:11:00.000','sysadmin','2022-09-27 11:11:00.000'),(26,5506,5506,'Chairperson','SecFiveNine',1208,'NPV',0,'0','0','0','0','Division','sysadmin','2022-09-27 11:11:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,0,'sysadmin','2022-09-27 11:11:00.000','sysadmin','2022-09-27 11:11:00.000'),(27,5507,5507,'Member','SecFiveNine',1209,'NPV',0,'0','0','0','0','Division','sysadmin','2022-09-27 11:11:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,0,'sysadmin','2022-09-27 11:11:00.000','sysadmin','2022-09-27 11:11:00.000'),(28,5508,5508,'Adjudicating Officer','SecFiveNine',1210,'NPV',0,'0','0','0','0','Division','sysadmin','2022-09-27 11:11:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,0,'sysadmin','2022-09-27 11:11:00.000','sysadmin','2022-09-27 11:11:00.000'),(29,1211,1211,'Sh. Satya Gopal, Chairperson','FormM',1211,'NPV',0,'0','0','0','0','Single','Leave','2023-01-01 10:00:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2023-01-01 10:00:00.000','sysadmin','2023-01-01 10:00:00.000'),(30,1212,1212,'Sh. Rakesh Kumar Goyal, Member','FormM',1212,'NPV',0,'0','0','0','0','Single','Promoted','2023-01-01 10:00:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2023-01-01 10:00:00.000','sysadmin','2023-01-01 10:00:00.000'),(31,2211,2211,'Sh. Satya Gopal, Chairperson','FormN',1211,'NPV',0,'0','0','0','0','Single','Leave','2023-01-01 10:00:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2023-01-01 10:00:00.000','sysadmin','2023-01-01 10:00:00.000'),(32,2212,2212,'Sh. Rakesh Kumar Goyal, Member','FormN',1212,'NPV',0,'0','0','0','0','Single','Promoted','2023-01-01 10:00:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2023-01-01 10:00:00.000','sysadmin','2023-01-01 10:00:00.000'),(33,5509,5509,'Sh. Satya Gopal, Chairperson','SecFiveNine',1211,'NPV',0,'0','0','0','0','Single','Leave','2023-01-01 10:00:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2023-01-01 10:00:00.000','sysadmin','2023-01-01 10:00:00.000'),(34,5510,5510,'Sh. Rakesh Kumar Goyal, Member','SecFiveNine',1212,'NPV',0,'0','0','0','0','Single','Promoted','2023-01-01 10:00:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,1,1,0,'sysadmin','2023-01-01 10:00:00.000','sysadmin','2023-01-01 10:00:00.000'),(35,1213,1213,'Sh. Binod Kumar Singh, Member','FormM',1213,'YPV',2,'#33cccc','0','0','0','Single','Active','2024-08-06 18:00:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,1,'sysadmin','2024-08-06 18:00:00.000','sysadmin','2024-08-06 18:00:00.000'),(36,2213,2213,'Sh. Binod Kumar Singh, Member','FormN',1213,'NPV',0,'0','0','0','0','Single','Active','2024-08-06 18:00:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,0,'sysadmin','2024-08-06 18:00:00.000','sysadmin','2024-08-06 18:00:00.000'),(37,5511,5511,'Sh. Binod Kumar Singh, Member','SecFiveNine',1213,'NPV',0,'0','0','0','0','Single','Active','2024-08-06 18:00:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,0,'sysadmin','2024-08-06 18:00:00.000','sysadmin','2024-08-06 18:00:00.000'),(38,1214,1214,'Sh. Rakesh Kumar Goyal, Chairperson','FormM',1214,'YPV',1,'#99ccff','0','0','0','Single','Active','2024-10-29 10:00:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,1,'sysadmin','2024-10-29 10:00:00.000','sysadmin','2024-10-29 10:00:00.000'),(39,2214,2214,'Sh. Rakesh Kumar Goyal, Chairperson','FormN',1214,'NPV',0,'0','0','0','0','Single','Active','2024-10-29 10:00:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,0,'sysadmin','2024-10-29 10:00:00.000','sysadmin','2024-10-29 10:00:00.000'),(40,5512,5512,'Sh. Rakesh Kumar Goyal, Chairperson','SecFiveNine',1214,'NPV',0,'0','0','0','0','Single','Active','2024-10-29 10:00:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,0,'sysadmin','2024-10-29 10:00:00.000','sysadmin','2024-10-29 10:00:00.000'),(41,1215,1215,'Sh. Arunvir Vashista, Member','FormM',1215,'YPV',3,'#cccc00','0','0','0','Single','Active','2025-03-05 17:00:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,1,'sysadmin','2025-03-05 17:00:00.000','sysadmin','2025-03-05 17:00:00.000'),(42,2215,2215,'Sh. Arunvir Vashista, Member','FormN',1215,'NPV',0,'0','0','0','0','Single','Active','2025-03-05 17:00:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,0,'sysadmin','2025-03-05 17:00:00.000','sysadmin','2025-03-05 17:00:00.000'),(43,5513,5513,'Sh. Arunvir Vashista, Member','SecFiveNine',1215,'NPV',0,'0','0','0','0','Single','Active','2025-03-05 17:00:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,0,'sysadmin','2025-03-05 10:00:00.000','sysadmin','2025-03-05 10:00:00.000'),(44,1216,1216,'Sh. Rajinder Singh Rai, Adjudicating Officer','FormM',1216,'YPV',0,'0','0','0','0','Single','Active','2025-05-22 10:21:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,1,'sysadmin','2025-05-22 10:21:00.000','sysadmin','2025-05-22 10:21:00.000'),(45,2216,2216,'Sh. Rajinder Singh Rai, Adjudicating Officer','FormN',1216,'NPV',1,'#ff9999','0','0','0','Single','Active','2025-05-22 10:21:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,0,'sysadmin','2025-05-22 10:21:00.000','sysadmin','2025-05-22 10:21:00.000'),(46,5514,5514,'Sh. Rajinder Singh Rai, Adjudicating Officer','SecFiveNine',1216,'NPV',0,'0','0','0','0','Single','Active','2025-05-22 10:21:00.000','0001-01-01 00:00:00.000',NULL,NULL,1,1,1,0,1,0,'sysadmin','2025-05-22 10:21:00.000','sysadmin','2025-05-22 10:21:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_complaint_benchjudgemap` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:31
