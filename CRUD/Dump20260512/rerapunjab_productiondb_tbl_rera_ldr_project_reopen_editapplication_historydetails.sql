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
-- Table structure for table `tbl_rera_ldr_project_reopen_editapplication_historydetails`
--

DROP TABLE IF EXISTS `tbl_rera_ldr_project_reopen_editapplication_historydetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_ldr_project_reopen_editapplication_historydetails` (
  `ProjectEditApplicationLog_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ProjectEditApplicationLog_ID` bigint(20) NOT NULL,
  `Related_ProjectID` bigint(20) NOT NULL,
  `Related_PromoterID` bigint(20) NOT NULL,
  `Related_ReferenceID` bigint(20) DEFAULT NULL,
  `Registration_Number` varchar(60) NOT NULL,
  `Registration_IssueDate` datetime(3) NOT NULL,
  `Registration_ValidUptoDate` datetime(3) NOT NULL,
  `ProjectDiaryNumber` varchar(60) DEFAULT NULL,
  `IsReOpenRequest` int(11) NOT NULL,
  `ReOpenRefNumber` varchar(60) DEFAULT NULL,
  `ReOpenDate` datetime(3) NOT NULL,
  `ReOpenBy` varchar(60) DEFAULT NULL,
  `IsUnlockRequest` int(11) NOT NULL,
  `UnlockRefNumber` varchar(60) DEFAULT NULL,
  `UnlockDate` datetime(3) NOT NULL,
  `UnlockBy` varchar(60) DEFAULT NULL,
  `IsRePublicView` int(11) NOT NULL,
  `RePublicViewDate` datetime(3) NOT NULL,
  `RePublicViewBy` varchar(60) DEFAULT NULL,
  `SequenceOrder` int(11) DEFAULT NULL,
  `Remarks_IfAny` varchar(250) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `IsDraftEvaluation` int(11) NOT NULL,
  `IsDraftMember` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ProjectEditApplicationLog_IndexID`),
  KEY `index_tbl_rera_ldr_project_reopen_editapplication_historydetails` (`Related_ProjectID`,`Related_PromoterID`,`ProjectDiaryNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_ldr_project_reopen_editapplication_historydetails`
--

LOCK TABLES `tbl_rera_ldr_project_reopen_editapplication_historydetails` WRITE;
/*!40000 ALTER TABLE `tbl_rera_ldr_project_reopen_editapplication_historydetails` DISABLE KEYS */;
INSERT INTO `tbl_rera_ldr_project_reopen_editapplication_historydetails` VALUES (4,1,10923,1273,56,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2022-07-21 16:24:08.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,0,0,0,'admprogrammer.rera','2022-07-21 16:24:08.000','admprogrammer.rera','2022-07-21 16:24:08.000'),(5,2,10484,1353,56,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2022-09-24 11:46:12.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,1,0,0,'admprogrammer.rera','2022-09-24 11:41:48.000','admprogrammer.rera','2022-09-24 11:41:48.000'),(6,3,10484,1353,56,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2022-09-24 11:46:47.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,0,0,0,'admprogrammer.rera','2022-09-24 11:46:43.000','admprogrammer.rera','2022-09-24 11:46:43.000'),(7,4,10525,1061,56,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2023-09-22 10:14:13.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,1,0,0,'admprogrammer.rera','2023-09-22 10:14:13.000','admprogrammer.rera','2023-09-22 10:14:13.000'),(8,5,11725,2600,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:03:09.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,1,0,0,'admprogrammer.rera','2025-01-14 12:03:09.000','admprogrammer.rera','2025-01-14 12:03:09.000'),(9,6,10054,1004,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:31:18.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,1,0,0,'admprogrammer.rera','2025-01-14 12:31:18.000','admprogrammer.rera','2025-01-14 12:31:18.000'),(10,7,10300,1267,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:31:25.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,1,0,0,'admprogrammer.rera','2025-01-14 12:31:25.000','admprogrammer.rera','2025-01-14 12:31:25.000'),(11,8,10683,1562,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:31:28.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,1,0,0,'admprogrammer.rera','2025-01-14 12:31:28.000','admprogrammer.rera','2025-01-14 12:31:28.000'),(12,9,11104,1929,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:31:31.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,1,0,0,'admprogrammer.rera','2025-01-14 12:31:31.000','admprogrammer.rera','2025-01-14 12:31:31.000'),(13,10,10631,1521,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:31:34.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,1,0,0,'admprogrammer.rera','2025-01-14 12:31:34.000','admprogrammer.rera','2025-01-14 12:31:34.000'),(14,11,10776,1636,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:31:37.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,1,0,0,'admprogrammer.rera','2025-01-14 12:31:37.000','admprogrammer.rera','2025-01-14 12:31:37.000'),(15,12,10533,1432,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:31:40.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,1,0,0,'admprogrammer.rera','2025-01-14 12:31:40.000','admprogrammer.rera','2025-01-14 12:31:40.000'),(16,13,11159,1986,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:31:55.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,1,0,0,'admprogrammer.rera','2025-01-14 12:31:55.000','admprogrammer.rera','2025-01-14 12:31:55.000'),(17,14,11129,1943,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:31:57.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,1,0,0,'admprogrammer.rera','2025-01-14 12:31:57.000','admprogrammer.rera','2025-01-14 12:31:57.000'),(18,15,11605,2456,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:47:53.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,0,0,0,'admprogrammer.rera','2025-01-14 12:47:53.000','admprogrammer.rera','2025-01-14 12:47:53.000'),(19,16,11321,2166,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:48:01.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,0,0,0,'admprogrammer.rera','2025-01-14 12:48:01.000','admprogrammer.rera','2025-01-14 12:48:01.000'),(20,17,11424,2295,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:48:05.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,0,0,0,'admprogrammer.rera','2025-01-14 12:48:05.000','admprogrammer.rera','2025-01-14 12:48:05.000'),(21,18,11360,2232,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:48:08.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,0,0,0,'admprogrammer.rera','2025-01-14 12:48:08.000','admprogrammer.rera','2025-01-14 12:48:08.000'),(22,19,11248,1536,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:48:11.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,0,0,0,'admprogrammer.rera','2025-01-14 12:48:11.000','admprogrammer.rera','2025-01-14 12:48:11.000'),(23,20,11394,2251,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:48:14.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,0,0,0,'admprogrammer.rera','2025-01-14 12:48:14.000','admprogrammer.rera','2025-01-14 12:48:14.000'),(24,21,11287,2118,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:48:19.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,0,0,0,'admprogrammer.rera','2025-01-14 12:48:19.000','admprogrammer.rera','2025-01-14 12:48:19.000'),(25,22,11503,1004,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:48:25.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,0,0,0,'admprogrammer.rera','2025-01-14 12:48:25.000','admprogrammer.rera','2025-01-14 12:48:25.000'),(26,23,11435,2317,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:48:27.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,0,0,0,'admprogrammer.rera','2025-01-14 12:48:27.000','admprogrammer.rera','2025-01-14 12:48:27.000'),(27,24,11355,2222,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:48:30.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,0,0,0,'admprogrammer.rera','2025-01-14 12:48:30.000','admprogrammer.rera','2025-01-14 12:48:30.000'),(28,25,11382,2248,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:48:32.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,0,0,0,'admprogrammer.rera','2025-01-14 12:48:32.000','admprogrammer.rera','2025-01-14 12:48:32.000'),(29,26,11520,1256,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:48:35.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,0,0,0,'admprogrammer.rera','2025-01-14 12:48:35.000','admprogrammer.rera','2025-01-14 12:48:35.000'),(30,27,11439,2317,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:48:38.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,0,0,0,'admprogrammer.rera','2025-01-14 12:48:38.000','admprogrammer.rera','2025-01-14 12:48:38.000'),(31,28,12062,2667,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',1,'NA','2025-01-14 12:49:44.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,0,0,0,'admprogrammer.rera','2025-01-14 12:49:44.000','admprogrammer.rera','2025-01-14 12:49:44.000'),(32,29,12136,3037,57,'NA','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000','NA',1,'NA','0001-01-01 00:00:00.000','sysadmin',0,'NA','2025-01-14 12:57:48.000','admprogrammer.rera',0,'0001-01-01 00:00:00.000','NA',0,'Lock-UnLock web-portal project detail options',1,1,0,0,0,'admprogrammer.rera','2025-01-14 12:56:57.000','admprogrammer.rera','2025-01-14 12:56:57.000');
/*!40000 ALTER TABLE `tbl_rera_ldr_project_reopen_editapplication_historydetails` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:03
