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
-- Table structure for table `tbl_rera_ldr_project_quarterlyupdate_setpublicviewlogdetails`
--

DROP TABLE IF EXISTS `tbl_rera_ldr_project_quarterlyupdate_setpublicviewlogdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_ldr_project_quarterlyupdate_setpublicviewlogdetails` (
  `ProjectPublicUnPublic_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `Related_ProjectID` bigint(20) NOT NULL,
  `Related_ProjectRefIndexID` bigint(20) NOT NULL,
  `Related_ProjectRefID` bigint(20) NOT NULL,
  `PublicUnpublicValue` varchar(50) NOT NULL,
  `UserID` varchar(100) NOT NULL,
  `Remarks_IfAny` varchar(500) DEFAULT NULL,
  `PVMsg_IfAny` varchar(250) DEFAULT NULL,
  `A_Column` varchar(100) DEFAULT NULL,
  `B_Column` varchar(100) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ProjectPublicUnPublic_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_ldr_project_quarterlyupdate_setpublicviewlogdetails`
--

LOCK TABLES `tbl_rera_ldr_project_quarterlyupdate_setpublicviewlogdetails` WRITE;
/*!40000 ALTER TABLE `tbl_rera_ldr_project_quarterlyupdate_setpublicviewlogdetails` DISABLE KEYS */;
INSERT INTO `tbl_rera_ldr_project_quarterlyupdate_setpublicviewlogdetails` VALUES (23,10490,40,123,'NPV','16efb501-8222-4f29-af53-b5e0b04983a9','Project status of contruction with photographs details','UnPublicView request','','',1,0,'mngradminrera','2020-07-13 10:16:53.000','mngradminrera','2020-07-13 10:16:53.000'),(24,10490,40,123,'YPV','16efb501-8222-4f29-af53-b5e0b04983a9','Project status of contruction with photographs details','PublicView request','','',1,0,'mngradminrera','2020-07-13 10:17:02.000','mngradminrera','2020-07-13 10:17:02.000'),(25,10928,1378,2229,'2','94e160b5-b568-4423-a202-b2deaffff793','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'member.rera','2023-08-24 13:21:53.000','member.rera','2023-08-24 13:21:53.000'),(26,10928,1378,2229,'1','94e160b5-b568-4423-a202-b2deaffff793','Project Audited Annual Report On Statement of Accounts details','PublicView request','','',1,0,'member.rera','2023-08-24 13:22:08.000','member.rera','2023-08-24 13:22:08.000'),(27,10373,1992,2784,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2023-09-01 13:11:07.000','programmer.rera','2023-09-01 13:11:07.000'),(28,10373,1993,2785,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2023-09-01 13:11:12.000','programmer.rera','2023-09-01 13:11:12.000'),(29,10373,1994,2786,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2023-09-01 13:11:15.000','programmer.rera','2023-09-01 13:11:15.000'),(30,10103,4002,4637,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2024-07-17 16:44:51.000','programmer.rera','2024-07-17 16:44:51.000'),(31,10103,4001,4636,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2024-07-17 16:44:54.000','programmer.rera','2024-07-17 16:44:54.000'),(32,10103,3842,4498,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2024-07-17 16:44:59.000','programmer.rera','2024-07-17 16:44:59.000'),(33,10103,3841,4497,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2024-07-17 16:45:02.000','programmer.rera','2024-07-17 16:45:02.000'),(34,10103,2507,3250,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2024-07-17 16:45:05.000','programmer.rera','2024-07-17 16:45:05.000'),(35,10103,1385,2236,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2024-07-17 16:45:07.000','programmer.rera','2024-07-17 16:45:07.000'),(36,10103,1384,2235,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2024-07-17 16:45:10.000','programmer.rera','2024-07-17 16:45:10.000'),(37,10103,1383,2234,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2024-07-17 16:45:12.000','programmer.rera','2024-07-17 16:45:12.000'),(38,10376,4348,4944,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2024-10-16 17:08:03.000','programmer.rera','2024-10-16 17:08:03.000'),(39,10376,4349,4945,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2024-10-16 17:08:31.000','programmer.rera','2024-10-16 17:08:31.000'),(40,11635,4801,5362,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2024-12-02 12:42:21.000','programmer.rera','2024-12-02 12:42:21.000'),(41,10705,4205,4822,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2024-12-26 14:22:29.000','programmer.rera','2024-12-26 14:22:29.000'),(42,10705,1164,2031,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2024-12-26 14:23:21.000','programmer.rera','2024-12-26 14:23:21.000'),(43,10705,4206,4823,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2024-12-26 14:23:43.000','programmer.rera','2024-12-26 14:23:43.000'),(44,10705,1165,2032,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2024-12-26 14:24:17.000','programmer.rera','2024-12-26 14:24:17.000'),(45,10705,4207,4824,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2024-12-26 14:24:34.000','programmer.rera','2024-12-26 14:24:34.000'),(46,10705,4208,4825,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2024-12-26 14:24:50.000','programmer.rera','2024-12-26 14:24:50.000'),(47,10705,1986,2779,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2024-12-26 14:24:53.000','programmer.rera','2024-12-26 14:24:53.000'),(48,10705,3892,4543,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2024-12-26 14:25:19.000','programmer.rera','2024-12-26 14:25:19.000'),(49,11419,3893,4544,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2025-01-09 15:28:13.000','programmer.rera','2025-01-09 15:28:13.000'),(50,11419,4200,4821,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2025-01-09 15:29:31.000','programmer.rera','2025-01-09 15:29:31.000'),(51,11419,3894,4545,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2025-01-09 15:40:14.000','programmer.rera','2025-01-09 15:40:14.000'),(52,10734,5929,6369,'2','a10588c2-b4bf-49c1-bb51-91b354794d63','Project Audited Annual Report On Statement of Accounts details','UnPublicView request','','',1,0,'programmer.rera','2026-01-12 18:01:35.000','programmer.rera','2026-01-12 18:01:35.000');
/*!40000 ALTER TABLE `tbl_rera_ldr_project_quarterlyupdate_setpublicviewlogdetails` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:55
