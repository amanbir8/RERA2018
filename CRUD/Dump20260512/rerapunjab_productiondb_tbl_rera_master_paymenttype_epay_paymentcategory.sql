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
-- Table structure for table `tbl_rera_master_paymenttype_epay_paymentcategory`
--

DROP TABLE IF EXISTS `tbl_rera_master_paymenttype_epay_paymentcategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_paymenttype_epay_paymentcategory` (
  `PaymentCategory_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `PaymentCategory_Code` int(11) NOT NULL,
  `PaymentCategory_Name` varchar(100) NOT NULL,
  `PaymentHead` varchar(100) NOT NULL,
  `BankGateway` varchar(100) NOT NULL,
  `SequenceOrder` int(11) NOT NULL DEFAULT '0',
  `A_Column` varchar(500) DEFAULT NULL,
  `B_Column` varchar(100) NOT NULL,
  `IsActive` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`PaymentCategory_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_paymenttype_epay_paymentcategory`
--

LOCK TABLES `tbl_rera_master_paymenttype_epay_paymentcategory` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_paymenttype_epay_paymentcategory` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_paymenttype_epay_paymentcategory` VALUES (1,501,'Fee','Project','GatewayOne',1,'Description: Fees are statutory payments to the Authority for compliance or legal registration wrt regulation of a real estate project.','PV501',2,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(2,502,'Late Fee','Project','GatewayOne',2,'Description: Late Fee','PV502',2,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(3,503,'Penalty','Project','GatewayTwo',3,'Description: Charges paid to the Authority for Penalties for Non-Compliance, Other Violations etc','PV503',1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(4,504,'Services','Project','GatewayOne',4,'Description: Services charge paid to the Authority for Duplicate Copy of Certificate, change in Communication Address, change in Authorization Detail, change in Special Bank etc.','PV504',1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(5,505,'Others','Project','GatewayOne',5,'Description: Others','PV505',1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(6,601,'Fee','Agent','GatewayOne',1,'Description: Registration or compliance charge paid to the Authority for legal approval and regulation of a real estate agent.','NA501',1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(7,602,'Fine','Agent','GatewayOne',2,'Description: Fine','PV602',2,0,0,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(8,603,'Penalty','Agent','GatewayTwo',3,'Description: Description: Charges paid to the Authority for Penalties for Non-Compliance, Other Violations etc','NA503',2,0,0,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(9,604,'Others','Agent','GatewayOne',5,'Description: Others','NA505',1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(10,701,'Court Fee','eCourt','GatewayOne',1,'Description: Court Fee','PV701',1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(11,702,'Judicial Deposit','eCourt','GatewayOne',2,'Description: Judicial Deposit','PV702',1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(12,703,'Penalty','eCourt','GatewayTwo',3,'Description: Description: Charges paid to the Authority for Penalties for Non-Compliance, Other Violations etc','NA503',1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(13,704,'Others','eCourt','GatewayOne',5,'Description: Others','NA505',1,1,1,'sysadmin','2026-02-02 11:00:00.000','sysadmin','2026-02-02 11:00:00.000'),(14,605,'Services','Agent','GatewayOne',4,'Description: Description: Services charge paid to the Authority for Duplicate Copy of Certificate, change in Communication Address, change in Registered Address etc.','NA504',1,1,1,'sysadmin','2026-02-11 11:00:00.000','sysadmin','2026-02-11 11:00:00.000'),(15,705,'Services','eCourt','GatewayOne',4,'Description: Description: Services charge paid to the Authority for Duplicate Copy of Order, change in Vakalatnama, change in Registered Address etc.','NA504',1,1,1,'sysadmin','2026-02-11 11:00:00.000','sysadmin','2026-02-11 11:00:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_paymenttype_epay_paymentcategory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:59
