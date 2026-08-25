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
-- Table structure for table `tbl_rera_master_paymenttype`
--

DROP TABLE IF EXISTS `tbl_rera_master_paymenttype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_paymenttype` (
  `PaymentType_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `PaymentType_Code` int(11) NOT NULL,
  `PaymentType` varchar(50) NOT NULL,
  `IsActive` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`PaymentType_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_paymenttype`
--

LOCK TABLES `tbl_rera_master_paymenttype` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_paymenttype` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_paymenttype` VALUES (2,1,'Registration Fee',1,'sysadmin','2018-01-17 13:08:00.000','sysadmin','2018-01-17 13:08:00.000'),(4,2,'Registration Extension Fee',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(5,3,'Application for Change Fee',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(6,2,'Late Fee',1,'sysadmin','2019-11-06 11:00:00.000','sysadmin','2019-11-06 11:00:00.000'),(7,3,'Any Other Fee',1,'sysadmin','2019-11-06 11:00:00.000','sysadmin','2019-11-06 11:00:00.000'),(8,4,'Project Revision Fee',1,'sysadmin','2026-01-23 16:00:00.000','sysadmin','2026-01-23 16:00:00.000'),(9,5,'Service Fee',1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_paymenttype` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:49
