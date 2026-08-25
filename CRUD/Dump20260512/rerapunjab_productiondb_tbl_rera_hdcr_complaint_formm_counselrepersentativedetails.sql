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
-- Table structure for table `tbl_rera_hdcr_complaint_formm_counselrepersentativedetails`
--

DROP TABLE IF EXISTS `tbl_rera_hdcr_complaint_formm_counselrepersentativedetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_hdcr_complaint_formm_counselrepersentativedetails` (
  `ComplaintPUC_FormM_Counsel_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ComplaintPUC_FormM_Counsel_ID` bigint(20) NOT NULL,
  `Related_ComplaintFormM_ID` bigint(20) NOT NULL,
  `Related_ApplicationPUC_ID` bigint(20) NOT NULL,
  `PUC_DiaryNumber` varchar(100) NOT NULL,
  `PUC_ReferencePUC_Name` varchar(100) NOT NULL,
  `PUC_ReferencePUC_Date` datetime(3) NOT NULL,
  `ComplaintDiaryNumber` varchar(100) NOT NULL,
  `ComplaintFilingDate` datetime(3) NOT NULL,
  `IsTransferCase` int(11) NOT NULL,
  `TransferTypeOption` varchar(150) NOT NULL,
  `TransferDate` datetime(3) NOT NULL,
  `ACR_IsPublicView` int(11) NOT NULL,
  `ACR_IsApproved` int(11) NOT NULL,
  `ACR_IsMemberApproved` int(11) NOT NULL,
  `Related_Transfer_FromUser` varchar(90) NOT NULL,
  `Related_Transfer_ToUser` varchar(90) NOT NULL,
  `Related_Transfer_FromProfileID` bigint(20) NOT NULL,
  `Related_Transfer_ToProfileID` bigint(20) NOT NULL,
  `Account_FromDate` datetime(3) NOT NULL,
  `Account_ToDate` datetime(3) NOT NULL,
  `Approved_AccountDate` datetime(3) NOT NULL,
  `Approved_AccountBy` varchar(90) NOT NULL,
  `ACR_Remarks_IfAny` varchar(350) DEFAULT NULL,
  `ACR_A_column` varchar(50) DEFAULT NULL,
  `ACR_B_column` varchar(50) DEFAULT NULL,
  `ACR_IsActive` int(11) NOT NULL,
  `ACR_IsDraft` int(11) NOT NULL,
  `ACR_AccountDate` datetime(3) NOT NULL,
  `ACR_AccountBy` varchar(90) NOT NULL,
  `ComplaintFormM_IndexID` bigint(20) NOT NULL,
  `ComplaintFormM_ID` bigint(20) NOT NULL,
  `ComplaintFormM_Code` varchar(50) NOT NULL,
  `Profile_ID` bigint(20) NOT NULL,
  `User_ID` varchar(50) NOT NULL,
  `ComplaintType_MN` varchar(50) NOT NULL,
  `IsComplaintComplete` int(11) NOT NULL,
  `IsPaymentComplete` int(11) NOT NULL,
  `IsDocumentsComplete` int(11) NOT NULL,
  `IsVerificationComplete` int(11) NOT NULL,
  `ComplaintVerificationDate` datetime(3) NOT NULL,
  `Complainant_Name` varchar(90) NOT NULL,
  `Complainant_EmailAddress` varchar(90) NOT NULL,
  `Complainant_MobileNumber` bigint(20) NOT NULL,
  `Complainant_LandlineFaxNumber` bigint(20) NOT NULL,
  `Complainant_AadhaarNumber` bigint(20) NOT NULL,
  `OfficeResComplainant_AddressLine1` varchar(100) NOT NULL,
  `OfficeResComplainant_AddressLine2` varchar(100) NOT NULL,
  `OfficeResComplainant_AddressStateCode` int(11) NOT NULL,
  `OfficeResComplainant_AddressDistrictCode` int(11) NOT NULL,
  `OfficeResComplainant_AddressPIN` varchar(10) NOT NULL,
  `IsOfficeResComplainantAddress_SameAsServiceNoticeAddress` varchar(2) NOT NULL,
  `ServiceNoticesComplainant_AddressLine1` varchar(100) NOT NULL,
  `ServiceNoticesComplainant_AddressLine2` varchar(100) NOT NULL,
  `ServiceNoticesComplainant_AddressStateCode` int(11) NOT NULL,
  `ServiceNoticesComplainant_AddressDistrictCode` int(11) NOT NULL,
  `ServiceNoticesComplainant_AddressPIN` varchar(10) NOT NULL,
  `AuthorizedRepresentativeCounsel_Name` varchar(90) NOT NULL,
  `AuthorizedRepresentativeCounsel_EmailAddress` varchar(90) NOT NULL,
  `AuthorizedRepresentativeCounsel_MobileNumber` bigint(20) NOT NULL,
  `AuthorizedRepresentativeCounsel_LandlineFaxNumber` bigint(20) NOT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ComplaintPUC_FormM_Counsel_IndexID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_hdcr_complaint_formm_counselrepersentativedetails`
--

LOCK TABLES `tbl_rera_hdcr_complaint_formm_counselrepersentativedetails` WRITE;
/*!40000 ALTER TABLE `tbl_rera_hdcr_complaint_formm_counselrepersentativedetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_hdcr_complaint_formm_counselrepersentativedetails` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:48
