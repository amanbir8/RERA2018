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
-- Table structure for table `tbl_rera_complaint_formm_additioncomplainant_temp_bifurcation`
--

DROP TABLE IF EXISTS `tbl_rera_complaint_formm_additioncomplainant_temp_bifurcation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_complaint_formm_additioncomplainant_temp_bifurcation` (
  `ComplainantorApplicant_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ComplainantorApplicant_ID` bigint(20) NOT NULL,
  `ComplainantorApplicant_RelatedComplaint_ID` bigint(20) NOT NULL,
  `ComplainantorApplicant_RelatedComplaint_Code` varchar(50) NOT NULL,
  `Profile_ID` bigint(20) NOT NULL,
  `User_ID` varchar(50) NOT NULL,
  `ComplaintType_MN` varchar(50) NOT NULL,
  `ComplainantorApplicant_Name` varchar(90) NOT NULL,
  `ComplainantorApplicant_EmailAddress` varchar(90) NOT NULL,
  `MobileNumber` bigint(20) NOT NULL,
  `LandlineFaxNumber` bigint(20) NOT NULL,
  `AadhaarNumber` bigint(20) NOT NULL,
  `OfficeResComplainant_AddressLine1` varchar(100) NOT NULL,
  `OfficeResComplainant_AddressLine2` varchar(100) NOT NULL,
  `OfficeResComplainant_AddressStateCode` int(11) NOT NULL,
  `OfficeResComplainant_AddressDistrictCode` int(11) NOT NULL,
  `OfficeResComplainant_AddressPIN` varchar(10) NOT NULL,
  `IsOfficeResAddress_SameAsServiceNoticeAddress` varchar(2) NOT NULL,
  `ServiceNotices_AddressLine1` varchar(100) NOT NULL,
  `ServiceNotices_AddressLine2` varchar(100) NOT NULL,
  `ServiceNotices_AddressStateCode` int(11) NOT NULL,
  `ServiceNotices_AddressDistrictCode` int(11) NOT NULL,
  `ServiceNotices_AddressPIN` varchar(10) NOT NULL,
  `Remarks_IfAny` varchar(350) NOT NULL,
  `A_column` varchar(100) NOT NULL,
  `B_column` varchar(100) NOT NULL,
  `C_column` varchar(100) NOT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `IsTempTable` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ComplainantorApplicant_IndexID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_complaint_formm_additioncomplainant_temp_bifurcation`
--

LOCK TABLES `tbl_rera_complaint_formm_additioncomplainant_temp_bifurcation` WRITE;
/*!40000 ALTER TABLE `tbl_rera_complaint_formm_additioncomplainant_temp_bifurcation` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_complaint_formm_additioncomplainant_temp_bifurcation` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:36
