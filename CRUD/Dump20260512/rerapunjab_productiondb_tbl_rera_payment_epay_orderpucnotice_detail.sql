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
-- Table structure for table `tbl_rera_payment_epay_orderpucnotice_detail`
--

DROP TABLE IF EXISTS `tbl_rera_payment_epay_orderpucnotice_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_payment_epay_orderpucnotice_detail` (
  `Payment_RefIndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `Payment_RefID` bigint(20) NOT NULL,
  `Payment_RefNumber` varchar(90) NOT NULL,
  `Payment_GroupID` int(11) NOT NULL,
  `Payment_GroupName` varchar(120) NOT NULL,
  `ReferenceChoiceCode` varchar(90) NOT NULL,
  `ReferenceChoiceName` varchar(120) NOT NULL,
  `ReferenceChoiceValue` varchar(180) NOT NULL,
  `Project_ID` bigint(20) DEFAULT NULL,
  `Promoter_ID` bigint(20) DEFAULT NULL,
  `Project_Name` varchar(120) DEFAULT NULL,
  `Promoter_Name` varchar(120) DEFAULT NULL,
  `ProjectAddress_DistrictCode` int(11) DEFAULT NULL,
  `ProjectAddress_DistrictName` varchar(120) DEFAULT NULL,
  `Agent_ID` bigint(20) DEFAULT NULL,
  `RenewalAgent_ID` bigint(20) DEFAULT NULL,
  `Agent_Name` varchar(120) DEFAULT NULL,
  `Agent_TypeName` varchar(120) DEFAULT NULL,
  `AgentAddress_DistrictCode` int(11) DEFAULT NULL,
  `AgentAddress_DistrictName` varchar(120) DEFAULT NULL,
  `Complaint_ID` bigint(20) DEFAULT NULL,
  `Complaint_Type` varchar(90) DEFAULT NULL,
  `Complaint_Number` varchar(180) DEFAULT NULL,
  `Complainant_Name` varchar(120) DEFAULT NULL,
  `ComplaintAgainst_Code` varchar(90) DEFAULT NULL,
  `ComplaintAgainst_Name` varchar(120) DEFAULT NULL,
  `RERAnumberRegistration` varchar(180) NOT NULL,
  `Remarks_IfAny` varchar(250) DEFAULT NULL,
  `A_column` varchar(60) DEFAULT NULL,
  `B_column` varchar(60) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`Payment_RefIndexID`),
  KEY `index_tbl_rera_payment_epay_orderpucnotice` (`ReferenceChoiceValue`,`Payment_GroupID`,`RERAnumberRegistration`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_payment_epay_orderpucnotice_detail`
--

LOCK TABLES `tbl_rera_payment_epay_orderpucnotice_detail` WRITE;
/*!40000 ALTER TABLE `tbl_rera_payment_epay_orderpucnotice_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_payment_epay_orderpucnotice_detail` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:29
