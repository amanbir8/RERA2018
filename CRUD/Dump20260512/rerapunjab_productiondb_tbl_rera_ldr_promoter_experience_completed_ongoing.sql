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
-- Table structure for table `tbl_rera_ldr_promoter_experience_completed_ongoing`
--

DROP TABLE IF EXISTS `tbl_rera_ldr_promoter_experience_completed_ongoing`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_ldr_promoter_experience_completed_ongoing` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Promoter_Experience_ID` bigint(20) DEFAULT NULL,
  `Application_id` varchar(200) NOT NULL,
  `Projectname` varchar(200) DEFAULT NULL,
  `ProjectType` varchar(50) DEFAULT NULL,
  `ProjectStatus` varchar(50) DEFAULT NULL,
  `AreaConUProject` decimal(18,2) DEFAULT NULL,
  `ProjectStartDate` datetime(3) DEFAULT NULL,
  `OCDateProject` datetime(3) DEFAULT NULL,
  `ACDProject` datetime(3) DEFAULT NULL,
  `RExtentofDelayProject` varchar(200) DEFAULT NULL,
  `TypeLandofProject` varchar(50) DEFAULT NULL,
  `LitgToProject` varchar(100) DEFAULT NULL,
  `CaseTitle` varchar(500) DEFAULT NULL,
  `CaseNumber` varchar(200) DEFAULT NULL,
  `NameofAuthorityForumwhereCasisPendingresolved` varchar(500) DEFAULT NULL,
  `IsPaymentDetailsPending_RelatedLand` varchar(50) DEFAULT NULL,
  `DetailPaymentPendingProject` varchar(200) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `Created_By` varchar(100) NOT NULL,
  `Created_On` datetime(3) NOT NULL,
  `Modify_By` varchar(100) DEFAULT NULL,
  `Modified_On` datetime(3) DEFAULT NULL,
  `Flag` int(11) NOT NULL,
  `Extra1` varchar(200) DEFAULT NULL,
  `Extra2` varchar(200) DEFAULT NULL,
  `Extra3` varchar(200) DEFAULT NULL,
  `Extra4` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_ldr_promoter_experience_completed_ongoing`
--

LOCK TABLES `tbl_rera_ldr_promoter_experience_completed_ongoing` WRITE;
/*!40000 ALTER TABLE `tbl_rera_ldr_promoter_experience_completed_ongoing` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_ldr_promoter_experience_completed_ongoing` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:27
