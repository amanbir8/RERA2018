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
-- Table structure for table `tbl_rera_complaint_formm_additionalmobilenumber`
--

DROP TABLE IF EXISTS `tbl_rera_complaint_formm_additionalmobilenumber`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_complaint_formm_additionalmobilenumber` (
  `AdditionalMobileNumberFormM_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `AdditionalMobileNumberFormM_ID` bigint(20) NOT NULL,
  `ComplaintFormM_ID` bigint(20) NOT NULL,
  `ComplaintFormM_Code` varchar(50) NOT NULL,
  `Profile_ID` bigint(20) NOT NULL,
  `User_ID` varchar(50) NOT NULL,
  `ComplaintType_MN` varchar(50) NOT NULL,
  `Complaint_DiaryNumber_Name` varchar(60) NOT NULL,
  `IsComplaintTransferFromTo` varchar(60) NOT NULL,
  `Complaint_TransferDiaryNumber_Name` varchar(60) NOT NULL,
  `Complainant_Name` varchar(90) NOT NULL,
  `OfficeResComplainant_AddressLine1` varchar(100) NOT NULL,
  `OfficeResComplainant_AddressLine2` varchar(100) NOT NULL,
  `OfficeResComplainant_AddressStateCode` int(11) NOT NULL,
  `OfficeResComplainant_AddressDistrictCode` int(11) NOT NULL,
  `OfficeResComplainant_AddressPIN` varchar(10) NOT NULL,
  `AuthorizedRepresentativeCounsel_Name` varchar(90) NOT NULL,
  `RelatesComplaint_ComplaintAgainstType` varchar(90) NOT NULL,
  `RelatesComplaint_ProjectAgent_RERA_RegNumber` varchar(90) NOT NULL,
  `RelatesComplaint_ProjectAgent_Name` varchar(450) NOT NULL,
  `Respondent_Name` varchar(90) NOT NULL,
  `AMN_ContactName` varchar(250) DEFAULT NULL,
  `AMN_Designation` varchar(250) DEFAULT NULL,
  `AMN_ReferenceName` varchar(250) DEFAULT NULL,
  `AMN_ReferenceDate` datetime(3) NOT NULL,
  `AMN_PhoneType` varchar(200) NOT NULL,
  `AMN_MobileNumber` bigint(20) NOT NULL,
  `RemarksIfAny` varchar(250) DEFAULT NULL,
  `Extra1` varchar(250) DEFAULT NULL,
  `Extra2` varchar(250) DEFAULT NULL,
  `Extra3` varchar(250) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `IsApproval` int(11) NOT NULL,
  `IsVerified` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`AdditionalMobileNumberFormM_IndexID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_complaint_formm_additionalmobilenumber`
--

LOCK TABLES `tbl_rera_complaint_formm_additionalmobilenumber` WRITE;
/*!40000 ALTER TABLE `tbl_rera_complaint_formm_additionalmobilenumber` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_complaint_formm_additionalmobilenumber` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:58
