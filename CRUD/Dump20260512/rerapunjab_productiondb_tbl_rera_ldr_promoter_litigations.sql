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
-- Table structure for table `tbl_rera_ldr_promoter_litigations`
--

DROP TABLE IF EXISTS `tbl_rera_ldr_promoter_litigations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_ldr_promoter_litigations` (
  `Promoter_Litigations_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `Promoter_Litigation_ID` bigint(20) NOT NULL,
  `Promoter_ID` bigint(20) NOT NULL,
  `LitigationsRelated_ProjectName` varchar(100) NOT NULL,
  `Case_Title` varchar(100) NOT NULL,
  `Case_Number` varchar(100) NOT NULL,
  `Authority_ForumName_CasePendingResolved` varchar(100) NOT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `Flag` int(11) DEFAULT NULL,
  `Created_By` varchar(100) NOT NULL,
  `Created_On` datetime(3) NOT NULL,
  `Modify_By` varchar(100) NOT NULL,
  `Modified_On` datetime(3) NOT NULL,
  `Extra1` varchar(200) DEFAULT NULL,
  `Extra2` varchar(200) DEFAULT NULL,
  `Extra3` varchar(200) DEFAULT NULL,
  `Extra4` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Promoter_Litigations_IndexID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_ldr_promoter_litigations`
--

LOCK TABLES `tbl_rera_ldr_promoter_litigations` WRITE;
/*!40000 ALTER TABLE `tbl_rera_ldr_promoter_litigations` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_ldr_promoter_litigations` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:44
