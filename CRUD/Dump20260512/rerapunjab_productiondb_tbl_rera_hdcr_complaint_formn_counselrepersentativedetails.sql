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
-- Table structure for table `tbl_rera_hdcr_complaint_formn_counselrepersentativedetails`
--

DROP TABLE IF EXISTS `tbl_rera_hdcr_complaint_formn_counselrepersentativedetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_hdcr_complaint_formn_counselrepersentativedetails` (
  `ComplaintPUC_FormN_Counsel_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ComplaintPUC_FormN_Counsel_ID` bigint(20) NOT NULL,
  `Related_ComplaintFormN_ID` bigint(20) NOT NULL,
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
  `ComplaintFormN_IndexID` bigint(20) NOT NULL,
  `ComplaintFormN_ID` bigint(20) NOT NULL,
  `ComplaintFormN_Code` varchar(50) NOT NULL,
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
  PRIMARY KEY (`ComplaintPUC_FormN_Counsel_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_hdcr_complaint_formn_counselrepersentativedetails`
--

LOCK TABLES `tbl_rera_hdcr_complaint_formn_counselrepersentativedetails` WRITE;
/*!40000 ALTER TABLE `tbl_rera_hdcr_complaint_formn_counselrepersentativedetails` DISABLE KEYS */;
INSERT INTO `tbl_rera_hdcr_complaint_formn_counselrepersentativedetails` VALUES (1,1001,2179,1001,'NA','NA','0001-01-01 00:00:00.000','AdCNo00392021','2021-03-01 16:31:08.000',0,'NA','0001-01-01 00:00:00.000',1,1,1,'6757bc1a-0875-4187-b2ef-a25468d1ed74','50a40e86-0356-4e34-bff7-3cc3c382c48e',1905,2836,'2021-03-01 16:31:08.000','2021-06-01 00:00:00.000','2021-06-01 00:00:00.000','admprogrammer.rera',NULL,NULL,NULL,1,1,'2021-06-01 00:00:00.000','admprogrammer.rera',4616,2179,'2179',1905,'6757bc1a-0875-4187-b2ef-a25468d1ed74','FormTypeN',1,1,1,1,'2021-03-01 16:31:08.000','kanika  Gupta','shandilyaddutt@gmail.com',9646587009,0,0,'1054','sector 18-C',6,128,'160018','0','332','sector 6',13,15,'134114','Durga Dutt Sharma','shandilyaddutt@gmail.com',9872855920,0,1,4,0,0,'durgadutt','2021-02-27 16:53:52.000','durgadutt','2021-02-27 16:53:52.000'),(2,1002,2180,1002,'NA','NA','0001-01-01 00:00:00.000','AdCNo00402021','2021-03-01 16:33:39.000',0,'NA','0001-01-01 00:00:00.000',1,1,1,'6757bc1a-0875-4187-b2ef-a25468d1ed74','50a40e86-0356-4e34-bff7-3cc3c382c48e',1905,2836,'2021-03-01 16:33:39.000','2021-06-01 00:00:00.000','2021-06-01 00:00:00.000','admprogrammer.rera',NULL,NULL,NULL,1,1,'2021-06-01 00:00:00.000','admprogrammer.rera',4617,2180,'2180',1905,'6757bc1a-0875-4187-b2ef-a25468d1ed74','FormTypeN',1,1,1,1,'2021-03-01 16:33:39.000','Sanjeev Gupta','shandilyaddutt@gmail.com',9646587009,0,0,'1054','sector 18-C',6,128,'160018','0','332','sector 6',13,15,'134114','Durga Dutt Sharma','shandilyaddutt@gmail.com',9872855920,0,1,4,0,0,'durgadutt','2021-02-27 16:57:27.000','durgadutt','2021-02-27 16:57:27.000'),(3,1003,2181,1003,'NA','NA','0001-01-01 00:00:00.000','AdCNo00412021','2021-03-01 16:35:15.000',0,'NA','0001-01-01 00:00:00.000',1,1,1,'6757bc1a-0875-4187-b2ef-a25468d1ed74','50a40e86-0356-4e34-bff7-3cc3c382c48e',1905,2836,'2021-03-01 16:35:15.000','2021-06-01 00:00:00.000','2021-06-01 00:00:00.000','admprogrammer.rera',NULL,NULL,NULL,1,1,'2021-06-01 00:00:00.000','admprogrammer.rera',4618,2181,'2181',1905,'6757bc1a-0875-4187-b2ef-a25468d1ed74','FormTypeN',1,1,1,1,'2021-03-01 16:35:15.000','Sanjeev Gupta','shandilyaddutt@gmail.com',9646587009,0,0,'1054','sector 18-C',6,128,'160018','1','332','sector 6',13,15,'134114','Durga Dutt Sharma','shandilyaddutt@gmail.com',9872855920,0,1,1,1,0,'durgadutt','2021-02-27 17:07:29.000','durgadutt','2021-02-27 17:07:29.000');
/*!40000 ALTER TABLE `tbl_rera_hdcr_complaint_formn_counselrepersentativedetails` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:23
