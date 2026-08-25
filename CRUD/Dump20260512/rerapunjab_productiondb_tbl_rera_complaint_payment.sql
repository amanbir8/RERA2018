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
-- Table structure for table `tbl_rera_complaint_payment`
--

DROP TABLE IF EXISTS `tbl_rera_complaint_payment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_complaint_payment` (
  `ComplaintPayment_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ComplaintPayment_ID` bigint(20) NOT NULL,
  `ComplaintPaymentRelated_ComplaintRegistration_ID` bigint(20) NOT NULL,
  `ComplaintPayment_TitleCode` int(11) NOT NULL,
  `ComplaintPayment_TitleName` varchar(90) NOT NULL,
  `Registration_Fee` decimal(10,2) NOT NULL,
  `Other_Fee` decimal(10,2) NOT NULL,
  `Payment_Mode` varchar(50) NOT NULL,
  `Date_of_Payment_RegistrationFee` datetime(3) NOT NULL,
  `Bank_Charges` decimal(10,2) NOT NULL,
  `Bank_Name` varchar(80) NOT NULL,
  `Branch_Name` varchar(80) NOT NULL,
  `DD_BankersCheque_Number` bigint(20) NOT NULL,
  `DD_BankersCheque_Amount` decimal(10,2) NOT NULL,
  `ImageDDorBankersCheque_FileName` varchar(250) NOT NULL,
  `ImageDDorBankersCheque_FilePath` varchar(250) NOT NULL,
  `Remarks_IfAny` varchar(100) DEFAULT NULL,
  `A_column` varchar(150) DEFAULT NULL,
  `B_column` varchar(100) DEFAULT NULL,
  `C_column` varchar(100) DEFAULT NULL,
  `D_column` varchar(100) DEFAULT NULL,
  `E_column` varchar(100) DEFAULT NULL,
  `F_column` varchar(100) DEFAULT NULL,
  `G_column` varchar(100) DEFAULT NULL,
  `H_column` varchar(100) DEFAULT NULL,
  `I_column` varchar(100) DEFAULT NULL,
  `J_column` varchar(100) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ComplaintPayment_IndexID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_complaint_payment`
--

LOCK TABLES `tbl_rera_complaint_payment` WRITE;
/*!40000 ALTER TABLE `tbl_rera_complaint_payment` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_complaint_payment` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:53
