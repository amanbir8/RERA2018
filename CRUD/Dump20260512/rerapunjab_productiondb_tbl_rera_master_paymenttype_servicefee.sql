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
-- Table structure for table `tbl_rera_master_paymenttype_servicefee`
--

DROP TABLE IF EXISTS `tbl_rera_master_paymenttype_servicefee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_paymenttype_servicefee` (
  `ServiceType_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `ServiceType_Code` int(11) NOT NULL,
  `ServiceType` varchar(50) NOT NULL,
  `PaymentType` varchar(50) NOT NULL,
  `PortalFlag` int(11) NOT NULL DEFAULT '0',
  `ServiceCategory` varchar(50) DEFAULT NULL,
  `ePayPaymentType` int(11) DEFAULT NULL,
  `ePayFlag` int(11) NOT NULL DEFAULT '0',
  `ServiceFeeAmount` varchar(50) DEFAULT NULL,
  `ServiceSeqOrder` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `IsValid` int(11) NOT NULL,
  `IsActive` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ServiceType_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_paymenttype_servicefee`
--

LOCK TABLES `tbl_rera_master_paymenttype_servicefee` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_paymenttype_servicefee` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_paymenttype_servicefee` VALUES (1,1001,'Authorization Detail','5',1,'Project',504,1,'1500.00',1,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(2,1002,'Change in Inventory','5',1,'Project',504,1,'1500.00',2,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(3,1003,'Communication Address','5',1,'Project',504,1,'1500.00',3,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(4,1004,'Partner Detail','5',1,'Project',504,1,'1500.00',4,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(5,1005,'Project Cost','5',1,'Project',504,1,'1500.00',5,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(6,1006,'RC Duplicate Copy','5',1,'Project',504,1,'1500.00',6,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(7,1007,'Special Bank','5',1,'Project',504,1,'1500.00',7,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(8,1008,'Other','5',1,'Project',504,1,'1500.00',90,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(9,1009,'Change in Constructions','5',1,'Project',504,0,'1500.00',0,0,0,2,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(10,1010,'Other','0',0,'ePay',501,1,'0.00',90,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(11,1011,'Other','0',0,'ePay',502,1,'0.00',90,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(12,1012,'Other','0',0,'ePay',503,1,'0.00',90,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(13,1013,'Other','0',0,'ePay',505,1,'0.00',90,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(14,1014,'Other','0',0,'ePay',601,1,'0.00',90,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(15,1015,'Other','0',0,'ePay',602,1,'0.00',90,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(16,1016,'Other','0',0,'ePay',603,1,'0.00',90,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(17,1017,'Other','0',0,'ePay',604,1,'0.00',90,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(18,1018,'Other','0',0,'ePay',701,1,'0.00',90,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(19,1019,'Other','0',0,'ePay',702,1,'0.00',90,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(20,1020,'Other','0',0,'ePay',703,1,'0.00',90,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(21,1021,'Other','0',0,'ePay',704,1,'0.00',90,1,1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(22,1022,'Other','0',0,'ePay',605,1,'0.00',90,1,1,1,1,'sysadmin','2026-02-11 11:00:00.000','sysadmin','2026-02-11 11:00:00.000'),(23,1023,'Other','0',0,'ePay',705,1,'0.00',90,1,1,1,1,'sysadmin','2026-02-17 11:00:00.000','sysadmin','2026-02-17 11:00:00.000'),(24,1024,'Section 59 (Non-Registration Promoter)','0',0,'ePay',703,1,'0.00',1,1,1,1,1,'sysadmin','2026-02-17 11:00:00.000','sysadmin','2026-02-17 11:00:00.000'),(25,1025,'Section 60 (Providing False Information Promoter)','0',0,'ePay',703,1,'0.00',2,1,1,1,1,'sysadmin','2026-02-17 11:00:00.000','sysadmin','2026-02-17 11:00:00.000'),(26,1026,'Section 61 (Other Violations Promoter)','0',0,'ePay',703,1,'0.00',3,1,1,1,1,'sysadmin','2026-02-17 11:00:00.000','sysadmin','2026-02-17 11:00:00.000'),(27,1027,'Section 62 (Non-Compliance Real Estate Agent)','0',0,'ePay',703,1,'0.00',4,1,1,1,1,'sysadmin','2026-02-17 11:00:00.000','sysadmin','2026-02-17 11:00:00.000'),(28,1028,'Section 63 (Failture to Comply with Orders)','0',0,'ePay',703,1,'0.00',5,1,1,1,1,'sysadmin','2026-02-17 11:00:00.000','sysadmin','2026-02-17 11:00:00.000'),(29,1029,'Section 59 (Non-Registration Promoter)','0',0,'ePay',503,1,'0.00',1,1,1,1,1,'sysadmin','2026-02-18 11:00:00.000','sysadmin','2026-02-18 11:00:00.000'),(30,1030,'Section 60 (Providing False Information Promoter)','0',0,'ePay',503,1,'0.00',2,1,1,1,1,'sysadmin','2026-02-18 11:00:00.000','sysadmin','2026-02-18 11:00:00.000'),(31,1031,'Section 61 (Other Violations Promoter)','0',0,'ePay',503,1,'0.00',3,1,1,1,1,'sysadmin','2026-02-18 11:00:00.000','sysadmin','2026-02-18 11:00:00.000'),(32,1032,'Section 62 (Non-Compliance Real Estate Agent)','0',0,'ePay',503,1,'0.00',4,1,1,1,1,'sysadmin','2026-02-18 11:00:00.000','sysadmin','2026-02-18 11:00:00.000'),(33,1033,'Section 63 (Failture to Comply with Orders)','0',0,'ePay',503,1,'0.00',5,1,1,1,1,'sysadmin','2026-02-18 11:00:00.000','sysadmin','2026-02-18 11:00:00.000'),(34,9999,'Not Known','0',0,'ePay',999,1,'0.00',99,1,1,1,1,'sysadmin','2026-02-18 11:00:00.000','sysadmin','2026-02-18 11:00:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_paymenttype_servicefee` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:17
