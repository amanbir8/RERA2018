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
-- Table structure for table `tbl_rera_payment_epay_eventaction`
--

DROP TABLE IF EXISTS `tbl_rera_payment_epay_eventaction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_payment_epay_eventaction` (
  `PaymentPayEventAction_ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `EventAction_Type` bigint(20) NOT NULL,
  `EventAction_IdentifiedBy` varchar(50) NOT NULL,
  `EventAction_IdentifiedOn` datetime(3) NOT NULL,
  `Related_PaymentRegistration_ID` bigint(20) NOT NULL,
  `Related_Payment_epayTxnID` bigint(20) NOT NULL,
  `Related_Payment_ChallanNumber_ID` bigint(20) NOT NULL,
  `Payment_TxnNumber` varchar(90) NOT NULL,
  `Payment_ChallanNumber` varchar(90) NOT NULL,
  `ReferenceNumber` varchar(120) NOT NULL,
  `RERA_RegistrationNumber` varchar(90) NOT NULL,
  `EventAction_Summary` varchar(200) NOT NULL,
  `EventAction_Description` varchar(300) NOT NULL,
  `EventAction_Category` varchar(150) NOT NULL,
  `EventAction_Aggregate` varchar(200) NOT NULL,
  `EventAction_Relationship` varchar(50) NOT NULL,
  `AssignedTo` varchar(50) NOT NULL,
  `Target_ResolutionDate` datetime(3) NOT NULL,
  `Target_ResolutionSummary` varchar(100) NOT NULL,
  `Actual_ResolutionDate` datetime(3) NOT NULL,
  `IsBefore_TargetResolution` int(11) NOT NULL,
  `ProgressStatus` varchar(50) NOT NULL,
  `Remarks_IfAny` varchar(2500) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`PaymentPayEventAction_ID`),
  KEY `index_tbl_rera_payment_epay_eventaction` (`EventAction_Type`,`Related_PaymentRegistration_ID`,`Related_Payment_ChallanNumber_ID`,`Payment_ChallanNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_payment_epay_eventaction`
--

LOCK TABLES `tbl_rera_payment_epay_eventaction` WRITE;
/*!40000 ALTER TABLE `tbl_rera_payment_epay_eventaction` DISABLE KEYS */;
INSERT INTO `tbl_rera_payment_epay_eventaction` VALUES (1,390001,'user','2026-02-03 11:00:00.000',10001,1,1,'TPRJ2026mrtzp0001','ChNo00001PRJ2026','PRJ2023PTL0117','PBRERA-PTL65-PR0960','ePay Application Submitted','ePay Application Submitted','Actor Anonymous','ePay Application Submitted','Role Anonymous','0','2026-02-02 11:00:00.000','NA','2026-02-02 11:00:00.000',1,'Success',NULL,1,0,'user','2026-02-02 11:00:00.000','user','2026-02-02 11:00:00.000'),(2,390001,'user','2026-02-03 11:00:00.000',10002,2,2,'TPRJ2026gtyim0002','ChNo00002CMP2026','GCNo03582025','PBRERA-SAS79-PR0489','ePay Application Submitted','ePay Application Submitted','Actor Anonymous','ePay Application Submitted','Role Anonymous','0','2026-02-02 11:00:00.000','NA','2026-02-02 11:00:00.000',1,'Success',NULL,1,0,'user','2026-02-02 11:00:00.000','user','2026-02-02 11:00:00.000');
/*!40000 ALTER TABLE `tbl_rera_payment_epay_eventaction` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:45
