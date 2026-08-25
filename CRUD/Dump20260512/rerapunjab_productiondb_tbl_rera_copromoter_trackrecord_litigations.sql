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
-- Table structure for table `tbl_rera_copromoter_trackrecord_litigations`
--

DROP TABLE IF EXISTS `tbl_rera_copromoter_trackrecord_litigations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_copromoter_trackrecord_litigations` (
  `JointPromoter_Litigations_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `JointPromoter_Litigation_ID` bigint(20) NOT NULL,
  `Related_Promoter_ID` bigint(20) NOT NULL,
  `Related_PromoterType` int(11) NOT NULL,
  `Related_JointPromoter_ID` bigint(20) NOT NULL,
  `Related_JointPromoterType` int(11) NOT NULL,
  `LitigationsRelated_JointPromoterName` varchar(180) NOT NULL,
  `LitigationsRelated_ProjectName` varchar(180) NOT NULL,
  `Project_Name` varchar(200) DEFAULT NULL,
  `Project_Type` varchar(50) DEFAULT NULL,
  `Project_Status` varchar(50) DEFAULT NULL,
  `Project_AreaConstructed` decimal(18,4) DEFAULT NULL,
  `ProjectStartDate` datetime(3) DEFAULT NULL,
  `Case_Title` varchar(120) NOT NULL,
  `Case_Number` varchar(120) NOT NULL,
  `Authority_ForumName_CasePendingResolved` varchar(180) NOT NULL,
  `JointPromoter_LitigationsFlag` int(11) NOT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `Flag` int(11) DEFAULT NULL,
  `Created_By` varchar(100) NOT NULL,
  `Created_On` datetime(3) NOT NULL,
  `Modify_By` varchar(100) NOT NULL,
  `Modified_On` datetime(3) NOT NULL,
  `Extra1` varchar(120) DEFAULT NULL,
  `Extra2` varchar(120) DEFAULT NULL,
  `Extra3` varchar(120) DEFAULT NULL,
  `Extra4` varchar(120) DEFAULT NULL,
  PRIMARY KEY (`JointPromoter_Litigations_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_copromoter_trackrecord_litigations`
--

LOCK TABLES `tbl_rera_copromoter_trackrecord_litigations` WRITE;
/*!40000 ALTER TABLE `tbl_rera_copromoter_trackrecord_litigations` DISABLE KEYS */;
INSERT INTO `tbl_rera_copromoter_trackrecord_litigations` VALUES (11,11001,1148,2,1034,2,'Green Home Builders','100001','Curo High Street Commercial Complex','2','Complete',18175.9200,'0001-01-01 00:00:00.000','Curo India Pvt. Ltd vs. Raj Paul Walia','CA/61/2018','ADJ(Jalandhar)',1,2,1,1,1,0,'CreatedBy','2018-04-21 14:22:46.000','CreatedBy','2018-04-21 14:22:46.000',NULL,NULL,NULL,NULL),(12,11002,1148,2,1034,2,'Green Home Builders','100001','Curo High Street Commercial Complex','2','Complete',18175.9200,'0001-01-01 00:00:00.000','Curo India Pvt. Ltd. vs. Ashwani Verma','CA/2/2018','ADJ(Jalandhar)',1,2,1,1,1,0,'CreatedBy','2018-04-21 14:22:46.000','CreatedBy','2018-04-21 14:22:46.000',NULL,NULL,NULL,NULL),(13,11003,1148,2,1035,1,'Harinder Singh','100001','Curo High Street Commercial Complex','2','Complete',18175.9200,'0001-01-01 00:00:00.000','Dalip Mehta vs. Curo India Pvt. Ltd.','CA/913/2017','ADJ(Jalandhar)',1,2,1,1,1,0,'CreatedBy','2018-04-21 14:22:46.000','CreatedBy','2018-04-21 14:22:46.000',NULL,NULL,NULL,NULL),(14,11004,1148,2,1035,1,'Harinder Singh','100003','Curo One Phase-I','4','On-going',158164.0600,'0001-01-01 00:00:00.000','Rajinder Kumar Maria vs. Curo India Pvt. Ltd.','CA/914/2017','ADJ(Jalandhar)',1,2,1,1,1,0,'CreatedBy','2018-04-21 14:22:46.000','CreatedBy','2018-04-21 14:22:46.000',NULL,NULL,NULL,NULL),(15,11005,1148,2,1035,1,'Harinder Singh','100004','Dynamic Homes Phase-1','1','On-going',1553.1500,'0001-01-01 00:00:00.000','NA','NA','NA',0,2,1,1,1,0,'CreatedBy','2018-04-21 14:22:46.000','CreatedBy','2018-04-21 14:22:46.000',NULL,NULL,NULL,NULL),(16,11006,1148,2,1034,0,'Green Home Builders','100228','Test A','1','On-going',77.0000,'2025-02-18 15:17:52.844','AAA Test','Test 222 of 2025','Chandigarh',1,2,0,0,1,0,'herorealty','2025-02-18 15:17:56.000','herorealty','2025-02-18 15:17:56.000','','','',''),(21,11011,1148,2,1034,0,'Green Home Builders','0','Test F','1','On-going',3333.0000,'2025-02-18 17:15:39.747','','','',0,2,0,0,1,0,'herorealty','2025-02-18 17:15:43.000','herorealty','2025-02-18 17:15:43.000','','','',''),(24,11012,1148,2,1034,0,'Green Home Builders','0','Test IM','1','On-going',444.0000,'2025-02-18 18:23:58.557','Test 13','Test 33 of 2025','Test Test AA',1,2,0,0,1,0,'herorealty','2025-02-18 18:24:02.000','herorealty','2025-02-18 18:24:02.000','','','',''),(38,11013,1148,2,1041,0,'test DADA','100228','Hero Homes Mohali Phase-I','1','On-going',26069.0000,'2025-02-22 16:21:32.592','AAA Test A1','Test 222 of 2025','Test DATA',1,1,1,1,1,0,'herorealty','2025-02-22 16:21:31.000','herorealty','2025-02-22 16:21:31.000','','','','');
/*!40000 ALTER TABLE `tbl_rera_copromoter_trackrecord_litigations` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:02
