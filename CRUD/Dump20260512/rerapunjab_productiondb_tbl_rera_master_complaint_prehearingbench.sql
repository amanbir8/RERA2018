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
-- Table structure for table `tbl_rera_master_complaint_prehearingbench`
--

DROP TABLE IF EXISTS `tbl_rera_master_complaint_prehearingbench`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_complaint_prehearingbench` (
  `PreHearingBench_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `PreHearingBench_ID` int(11) NOT NULL,
  `PreHearingBenchCode` int(11) NOT NULL,
  `PreHearingBenchName` varchar(150) NOT NULL,
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
  PRIMARY KEY (`PreHearingBench_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_complaint_prehearingbench`
--

LOCK TABLES `tbl_rera_master_complaint_prehearingbench` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_complaint_prehearingbench` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_complaint_prehearingbench` VALUES (1,1201,1201,'Sh. Jagdish Singh Khushdil, Member','FormM','Sh. Jagdish Singh Khushdil, Member','0','NPV',1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(2,1202,1202,'Sh. Jagdish Singh Khushdil, Adjudicating Officer','FormM','Sh. Jagdish Singh Khushdil, Adjudicating Officer','0','NPV',1,0,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(3,1203,1203,'Sh. Navreet Singh Kang, Chairperson','FormM','Sh. Navreet Singh Kang, Chairperson','1203','NPV',1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(4,1204,1204,'Sh. Sanjiv Gupta, Member','FormM','Sh. Sanjiv Gupta, Member','1204','NPV',1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(5,2201,2201,'Sh. Jagdish Singh Khushdil, Member','FormN','Sh. Jagdish Singh Khushdil, Member','0','NPV',1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(6,2202,2202,'Sh. Jagdish Singh Khushdil, Adjudicating Officer','FormN','Sh. Jagdish Singh Khushdil, Adjudicating Officer','0','NPV',1,0,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(7,2203,2203,'Sh. Navreet Singh Kang, Chairperson','FormN','Sh. Navreet Singh Kang, Chairperson','1203','NPV',1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(8,2204,2204,'Sh. Sanjiv Gupta, Member','FormN','Sh. Sanjiv Gupta, Member','1204','NPV',1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(9,2205,2205,'Authority, RERA Punjab','FormN','Authority, RERA Punjab','1206','NPV',1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(10,5501,5501,'Sh. Navreet Singh Kang, Chairperson','SecFiveNine','Sh. Navreet Singh Kang, Chairperson','1203','NPV',1,1,'sysadmin','2019-03-19 13:08:00.000','sysadmin','2019-03-19 13:08:00.000'),(11,5502,5502,'Sh. Jagdish Singh Khushdil, Member','SecFiveNine','Sh. Jagdish Singh Khushdil, Member','0','NPV',1,1,'sysadmin','2019-03-19 13:08:00.000','sysadmin','2019-03-19 13:08:00.000'),(12,5503,5503,'Sh. Sanjiv Gupta, Member','SecFiveNine','Sh. Sanjiv Gupta, Member','1204','NPV',1,1,'sysadmin','2019-03-19 13:08:00.000','sysadmin','2019-03-19 13:08:00.000'),(13,5504,5504,'Authority, RERA Punjab','SecFiveNine','Authority, RERA Punjab','1206','NPV',1,1,'sysadmin','2019-03-19 13:08:00.000','sysadmin','2019-03-19 13:08:00.000'),(14,1205,1205,'Sh. Balbir Singh, Adjudicating Officer','FormM','Sh. Balbir Singh, Adjudicating Officer','1205','NPV',1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(15,2206,2206,'Sh. Balbir Singh, Adjudicating Officer','FormN','Sh. Balbir Singh, Adjudicating Officer','1205','NPV',1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(16,1206,1206,'Authority, RERA Punjab','FormM','Authority, RERA Punjab','1206','YPV',1,1,'sysadmin','2020-11-04 00:00:00.000','sysadmin','2020-11-04 00:00:00.000'),(17,5505,5505,'Sh. Ajay Pal Singh, Member','SecFiveNine','Sh. Ajay Pal Singh, Member','1207','NPV',1,1,'sysadmin','2021-06-30 11:08:00.000','sysadmin','2021-06-30 11:08:00.000'),(18,1207,1207,'Sh. Ajay Pal Singh, Member','FormM','Sh. Ajay Pal Singh, Member','1207','NPV',1,1,'sysadmin','2021-11-30 17:13:00.000','sysadmin','2021-11-30 17:13:00.000'),(19,2207,2207,'Sh. Ajay Pal Singh, Member','FormN','Sh. Ajay Pal Singh, Member','1207','NPV',1,1,'sysadmin','2021-11-30 17:13:00.000','sysadmin','2021-11-30 17:13:00.000'),(20,1208,1208,'Chairperson','FormM','Chairperson','1208','YPV',1,1,'sysadmin','2022-09-27 11:11:00.000','sysadmin','2022-09-27 11:11:00.000'),(21,1209,1209,'Member','FormM','Member','1209','YPV',1,1,'sysadmin','2022-09-27 11:11:00.000','sysadmin','2022-09-27 11:11:00.000'),(22,1210,1210,'Adjudicating Officer','FormM','Adjudicating Officer','1210','YPV',1,1,'sysadmin','2022-09-27 11:11:00.000','sysadmin','2022-09-27 11:11:00.000'),(23,2208,2208,'Chairperson','FormN','Chairperson','1208','NPV',1,1,'sysadmin','2022-09-27 11:11:00.000','sysadmin','2022-09-27 11:11:00.000'),(24,2209,2209,'Member','FormN','Member','1209','NPV',1,1,'sysadmin','2022-09-27 11:11:00.000','sysadmin','2022-09-27 11:11:00.000'),(25,2210,2210,'Adjudicating Officer','FormN','Adjudicating Officer','1210','NPV',1,1,'sysadmin','2022-09-27 11:11:00.000','sysadmin','2022-09-27 11:11:00.000'),(26,5506,5506,'Chairperson','SecFiveNine','Chairperson','1208','NPV',1,1,'sysadmin','2022-09-27 11:11:00.000','sysadmin','2022-09-27 11:11:00.000'),(27,5507,5507,'Member','SecFiveNine','Member','1209','NPV',1,1,'sysadmin','2022-09-27 11:11:00.000','sysadmin','2022-09-27 11:11:00.000'),(28,5508,5508,'Adjudicating Officer','SecFiveNine','Adjudicating Officer','1210','NPV',1,1,'sysadmin','2022-09-27 11:11:00.000','sysadmin','2022-09-27 11:11:00.000'),(29,1211,1211,'Sh. Satya Gopal, Chairperson','FormM','Sh. Satya Gopal, Chairperson','1211','NPV',1,1,'sysadmin','2023-01-01 10:00:00.000','sysadmin','2023-01-01 10:00:00.000'),(30,1212,1212,'Sh. Rakesh Kumar Goyal, Member','FormM','Sh. Rakesh Kumar Goyal, Member','1212','NPV',1,1,'sysadmin','2023-01-01 10:00:00.000','sysadmin','2023-01-01 10:00:00.000'),(31,2211,2211,'Sh. Satya Gopal, Chairperson','FormN','Sh. Satya Gopal, Chairperson','1211','NPV',1,1,'sysadmin','2023-01-01 10:00:00.000','sysadmin','2023-01-01 10:00:00.000'),(32,2212,2212,'Sh. Rakesh Kumar Goyal, Member','FormN','Sh. Rakesh Kumar Goyal, Member','1212','NPV',1,1,'sysadmin','2023-01-01 10:00:00.000','sysadmin','2023-01-01 10:00:00.000'),(33,5509,5509,'Sh. Satya Gopal, Chairperson','SecFiveNine','Sh. Satya Gopal, Chairperson','1211','NPV',1,1,'sysadmin','2023-01-01 10:00:00.000','sysadmin','2023-01-01 10:00:00.000'),(34,5510,5510,'Sh. Rakesh Kumar Goyal, Member','SecFiveNine','Sh. Rakesh Kumar Goyal, Member','1212','NPV',1,1,'sysadmin','2023-01-01 10:00:00.000','sysadmin','2023-01-01 10:00:00.000'),(35,1213,1213,'Sh. Binod Kumar Singh, Member','FormM','Sh. Binod Kumar Singh, Member','1213','YPV',1,1,'sysadmin','2024-08-06 18:00:00.000','sysadmin','2024-08-06 18:00:00.000'),(36,2213,2213,'Sh. Binod Kumar Singh, Member','FormN','Sh. Binod Kumar Singh, Member','1213','NPV',1,1,'sysadmin','2024-08-06 18:00:00.000','sysadmin','2024-08-06 18:00:00.000'),(37,5511,5511,'Sh. Binod Kumar Singh, Member','SecFiveNine','Sh. Binod Kumar Singh, Member','1213','NPV',1,1,'sysadmin','2024-08-06 18:00:00.000','sysadmin','2024-08-06 18:00:00.000'),(38,1214,1214,'Sh. Rakesh Kumar Goyal, Chairperson','FormM','Sh. Rakesh Kumar Goyal, Chairperson','1214','YPV',1,1,'sysadmin','2024-10-29 10:00:00.000','sysadmin','2024-10-29 10:00:00.000'),(39,2214,2214,'Sh. Rakesh Kumar Goyal, Chairperson','FormN','Sh. Rakesh Kumar Goyal, Chairperson','1214','NPV',1,1,'sysadmin','2024-10-29 10:00:00.000','sysadmin','2024-10-29 10:00:00.000'),(40,5512,5512,'Sh. Rakesh Kumar Goyal, Chairperson','SecFiveNine','Sh. Rakesh Kumar Goyal, Chairperson','1214','NPV',1,1,'sysadmin','2024-10-29 10:00:00.000','sysadmin','2024-10-29 10:00:00.000'),(41,1215,1215,'Sh. Arunvir Vashista, Member','FormM','Sh. Arunvir Vashista, Member','1215','YPV',1,1,'sysadmin','2025-03-05 17:00:00.000','sysadmin','2025-03-05 17:00:00.000'),(42,2215,2215,'Sh. Arunvir Vashista, Member','FormN','Sh. Arunvir Vashista, Member','1215','NPV',1,1,'sysadmin','2025-03-05 17:00:00.000','sysadmin','2025-03-05 17:00:00.000'),(43,5513,5513,'Sh. Arunvir Vashista, Member','SecFiveNine','Sh. Arunvir Vashista, Member','1215','NPV',1,1,'sysadmin','2025-03-05 10:00:00.000','sysadmin','2025-03-05 10:00:00.000'),(44,1216,1216,'Sh. Rajinder Singh Rai, Adjudicating Officer','FormM','Sh. Rajinder Singh Rai, Adjudicating Officer','1216','YPV',1,1,'sysadmin','2025-05-22 10:21:00.000','sysadmin','2025-05-22 10:21:00.000'),(45,2216,2216,'Sh. Rajinder Singh Rai, Adjudicating Officer','FormN','Sh. Rajinder Singh Rai, Adjudicating Officer','1216','NPV',1,1,'sysadmin','2025-05-22 10:21:00.000','sysadmin','2025-05-22 10:21:00.000'),(46,5514,5514,'Sh. Rajinder Singh Rai, Adjudicating Officer','SecFiveNine','Sh. Rajinder Singh Rai, Adjudicating Officer','1216','NPV',1,1,'sysadmin','2025-05-22 10:21:00.000','sysadmin','2025-05-22 10:21:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_complaint_prehearingbench` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:13
