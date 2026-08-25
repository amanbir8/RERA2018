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
-- Table structure for table `tbl_rera_project_payment_additionalfee`
--

DROP TABLE IF EXISTS `tbl_rera_project_payment_additionalfee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_project_payment_additionalfee` (
  `ProjectPaymentAdditionalFee_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ProjectPaymentAdditionalFee_ID` bigint(20) NOT NULL,
  `ProjectPaymentRelated_ProjectRegistration_ID` bigint(20) NOT NULL,
  `ProjectPayment_TitleCode` int(11) NOT NULL,
  `ProjectPayment_TitleName` varchar(90) NOT NULL,
  `RelatedRERAregNumber_Name` varchar(90) NOT NULL,
  `RelatedRERAregNumber_ValidUptoDate` datetime(3) NOT NULL,
  `RelatedAnnualYear` int(11) NOT NULL,
  `RelatedSessionYear_Name` varchar(90) NOT NULL,
  `Registration_Fee` decimal(10,2) NOT NULL,
  `Other_Fee` decimal(10,2) NOT NULL,
  `Payment_Mode` varchar(50) NOT NULL,
  `Date_of_Payment_RegistrationFee` datetime(3) NOT NULL,
  `Bank_Charges` decimal(10,2) NOT NULL,
  `Bank_Name` varchar(80) NOT NULL,
  `Branch_Name` varchar(80) NOT NULL,
  `DD_BankersCheque_Number` bigint(20) NOT NULL,
  `DD_BankersCheque_Amount` decimal(10,2) NOT NULL,
  `ImageDDorBankersCheque_FileName` varchar(100) NOT NULL,
  `ImageDDorBankersCheque_FilePath` varchar(100) NOT NULL,
  `Remarks_IfAny` varchar(100) DEFAULT NULL,
  `A_column` varchar(150) DEFAULT NULL,
  `B_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ProjectPaymentAdditionalFee_IndexID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_project_payment_additionalfee`
--

LOCK TABLES `tbl_rera_project_payment_additionalfee` WRITE;
/*!40000 ALTER TABLE `tbl_rera_project_payment_additionalfee` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_project_payment_additionalfee` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:47
