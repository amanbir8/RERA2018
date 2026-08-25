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
-- Table structure for table `tbl_rera_master_paymenttypebycode`
--

DROP TABLE IF EXISTS `tbl_rera_master_paymenttypebycode`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_paymenttypebycode` (
  `PaymentType_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `PaymentType_Code` int(11) NOT NULL,
  `PaymentType` varchar(150) NOT NULL,
  `PaymentTypeFlag` int(11) NOT NULL,
  `PaymentTypeGroup` int(11) NOT NULL,
  `PaymentTypeGroupName` varchar(150) NOT NULL,
  `IsActive` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`PaymentType_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_paymenttypebycode`
--

LOCK TABLES `tbl_rera_master_paymenttypebycode` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_paymenttypebycode` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_paymenttypebycode` VALUES (1,101,'Project Extension Fee',1,11,'Project Extension',1,'sysadmin','2019-04-01 13:08:00.000','sysadmin','2019-04-01 13:08:00.000'),(2,102,'Late Fee',1,11,'Project Extension',1,'sysadmin','2025-08-26 16:08:00.000','sysadmin','2025-08-26 16:08:00.000'),(3,103,'Any Other Fee',1,11,'Project Extension',1,'sysadmin','2025-08-26 16:08:00.000','sysadmin','2025-08-26 16:08:00.000'),(4,104,'Project Extension (u/s 7/8) Fee',1,11,'Project Extension',1,'sysadmin','2026-01-23 16:00:00.000','sysadmin','2026-01-23 16:00:00.000'),(5,105,'Service Fee',1,11,'Project Extension',1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_paymenttypebycode` ENABLE KEYS */;
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
