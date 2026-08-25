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
-- Table structure for table `tbl_rera_ldr_project_document_changefile_logdetails`
--

DROP TABLE IF EXISTS `tbl_rera_ldr_project_document_changefile_logdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_ldr_project_document_changefile_logdetails` (
  `Projectlog_changefile_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `Related_ProjectDoc_IndexID` bigint(20) NOT NULL,
  `Related_ProjectDoc_ID` bigint(20) NOT NULL,
  `Related_Project_ID` bigint(20) NOT NULL,
  `Related_Promoter_ID` bigint(20) NOT NULL,
  `Related_ProjectDoc_InfoCode` bigint(20) NOT NULL,
  `Related_Project_DiaryNumber` varchar(100) DEFAULT NULL,
  `Related_RERA_RegistrationNumber` varchar(100) DEFAULT NULL,
  `User_Role` varchar(100) NOT NULL,
  `UserID` varchar(100) NOT NULL,
  `Remarks_IfAny` varchar(500) DEFAULT NULL,
  `LockUnlockMsg_IfAny` varchar(250) DEFAULT NULL,
  `A_Column` varchar(100) DEFAULT NULL,
  `B_Column` varchar(100) DEFAULT NULL,
  `C_Column` varchar(100) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`Projectlog_changefile_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_ldr_project_document_changefile_logdetails`
--

LOCK TABLES `tbl_rera_ldr_project_document_changefile_logdetails` WRITE;
/*!40000 ALTER TABLE `tbl_rera_ldr_project_document_changefile_logdetails` DISABLE KEYS */;
INSERT INTO `tbl_rera_ldr_project_document_changefile_logdetails` VALUES (7,35913,35653,10422,1352,1014,'PRJ2018SAS1261','','e583ee7f-aaa3-49bd-afc8-79c877afe591','6df8f5c6-38cc-4fe9-8df4-2fb5378575b6','Trashed request completed, ID(10422)','trashed','','','',1,1,'6df8f5c6-38cc-4fe9-8df4-2fb5378575b6','2022-02-17 11:27:07.000','sysadmin','2022-02-17 11:27:07.000'),(8,35180,34925,11401,2275,1010,'PRJ2021SAS0122','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Trashed request completed, ID(11401)','trashed','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2022-06-02 10:32:56.000','sysadmin','2022-06-02 10:32:56.000'),(9,40478,40218,11520,1256,1023,'PRJ2022SAS0133','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Trashed request completed, ID(11520)','trashed','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2022-07-27 11:44:34.000','sysadmin','2022-07-27 11:44:34.000'),(10,12126,11980,10479,1394,1008,'PRJ2018SAS1475','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Trashed request completed, ID(10479)','trashed','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2022-12-12 14:09:24.000','sysadmin','2022-12-12 14:09:24.000'),(11,43719,43459,11592,1057,1016,'PRJ2022LDH0176','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Trashed request completed, ID(11592)','trashed','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2023-01-25 12:32:50.000','sysadmin','2023-01-25 12:32:50.000'),(12,44485,44225,11634,2513,1018,'PRJ2023LDH0021','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Trashed request completed, ID(11634)','trashed','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2023-07-05 17:10:52.000','sysadmin','2023-07-05 17:10:52.000'),(13,44486,44226,11634,2513,1018,'PRJ2023LDH0021','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Trashed request completed, ID(11634)','trashed','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2023-07-05 17:11:06.000','sysadmin','2023-07-05 17:11:06.000'),(14,44487,44227,11634,2513,1018,'PRJ2023LDH0021','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Trashed request completed, ID(11634)','trashed','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2023-07-05 17:11:23.000','sysadmin','2023-07-05 17:11:23.000'),(15,44452,44192,11634,2513,1027,'PRJ2023LDH0021','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Trashed request completed, ID(11634)','trashed','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2023-07-05 17:11:50.000','sysadmin','2023-07-05 17:11:50.000'),(16,6952,6890,10338,1302,1014,'PRJ2018SAS1205','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Trashed request completed, ID(10338)','trashed','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2023-07-28 11:32:13.000','sysadmin','2023-07-28 11:32:13.000'),(17,54478,54218,11934,2819,1027,'PRJ2024LDH0070','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Trashed request completed, ID(11934)','trashed','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2024-07-19 16:03:43.000','sysadmin','2024-07-19 16:03:43.000'),(18,62502,62241,11994,2877,1023,'PRJ2024BTI0112','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Deleted request completed, ID(11994)','deleted','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2024-09-11 15:01:16.000','sysadmin','2024-09-11 15:01:16.000'),(19,56247,55986,11880,2769,1011,'PRJ2024SAS0025','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Trashed request completed, ID(11880)','trashed','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2024-09-18 16:45:38.000','sysadmin','2024-09-18 16:45:38.000'),(20,53120,52860,11880,2769,1015,'PRJ2024SAS0025','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Trashed request completed, ID(11880)','trashed','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2024-09-18 16:54:27.000','sysadmin','2024-09-18 16:54:27.000'),(21,48927,48667,11695,2021,1015,'PRJ2023BNL0054','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Trashed request completed, ID(11695)','trashed','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2024-10-24 15:58:37.000','sysadmin','2024-10-24 15:58:37.000'),(22,50027,49767,11719,2578,1027,'PRJ2023SAS0067','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Trashed request completed, ID(11719)','trashed','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2024-11-06 16:22:39.000','sysadmin','2024-11-06 16:22:39.000'),(23,80893,80630,12303,3203,1018,'PRJ2025SAS0125','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Deleted request completed, ID(12303)','deleted','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2025-12-03 11:41:45.000','sysadmin','2025-12-03 11:41:45.000'),(24,73040,72777,12303,3203,1018,'PRJ2025SAS0125','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Trashed request completed, ID(12303)','trashed','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2025-12-03 12:39:20.000','sysadmin','2025-12-03 12:39:20.000'),(25,59687,59426,12056,2951,1027,'PRJ2024LDH0181','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Trashed request completed, ID(12056)','trashed','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2026-02-06 16:59:25.000','sysadmin','2026-02-06 16:59:25.000');
/*!40000 ALTER TABLE `tbl_rera_ldr_project_document_changefile_logdetails` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:47
