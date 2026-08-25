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
-- Table structure for table `tbl_rera_ecourt_complaint_formn_caseallocation`
--

DROP TABLE IF EXISTS `tbl_rera_ecourt_complaint_formn_caseallocation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_ecourt_complaint_formn_caseallocation` (
  `CaseAllocation_formN_eCourtIndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `CaseAllocation_formN_eCourtID` bigint(20) NOT NULL,
  `SerialOrderNumber` int(11) NOT NULL,
  `Related_Profile_ID` bigint(20) NOT NULL,
  `Related_User_ID` varchar(50) NOT NULL,
  `Related_Complaint_ID` bigint(20) NOT NULL,
  `Related_ComplaintType_MN` varchar(50) NOT NULL,
  `Related_ComplaintDiaryNumber` varchar(90) NOT NULL,
  `eCourt_DiaryNumber` varchar(90) DEFAULT NULL,
  `eCourt_ReferenceName` varchar(250) DEFAULT NULL,
  `eCourt_ReferenceDate` datetime(3) DEFAULT NULL,
  `eCourt_UnderSectionName` varchar(90) DEFAULT NULL,
  `ComplainantName` varchar(250) NOT NULL,
  `RespondentName` varchar(250) NOT NULL,
  `eCourt_CaseType_Code` varchar(90) NOT NULL,
  `eCourt_CaseType_Name` varchar(90) NOT NULL,
  `eCourt_CaseType_Date` datetime(3) NOT NULL,
  `eCourt_CaseType_Description` varchar(250) DEFAULT NULL,
  `EntrustedTo_BenchCode` varchar(90) NOT NULL,
  `EntrustedTo_BenchName` varchar(200) NOT NULL,
  `EntrustedTo_BenchDescription` varchar(250) NOT NULL,
  `EntrustedTo_BenchLocation` varchar(250) NOT NULL,
  `Date_of_Filing` datetime(3) NOT NULL,
  `Date_of_Institution` datetime(3) NOT NULL,
  `Date_of_Hearing` datetime(3) NOT NULL,
  `Date_of_Decision` datetime(3) NOT NULL,
  `Date_of_Upload` datetime(3) NOT NULL,
  `IsTransferCase` int(11) NOT NULL,
  `TransferTypeOption` varchar(90) NOT NULL,
  `Related_CaseTransferN_IndexID` bigint(20) DEFAULT NULL,
  `Related_CaseTransferN_ID` bigint(20) DEFAULT NULL,
  `Related_PreHearingDate_IndexID` bigint(20) NOT NULL,
  `Related_PreHearingDate_ID` bigint(20) NOT NULL,
  `Related_OrderJudgementByAO_IndexID` bigint(20) DEFAULT NULL,
  `Related_OrderJudgementByAO_ID` bigint(20) DEFAULT NULL,
  `IsAppealCaseArisingUnderREAT` int(11) NOT NULL,
  `AppealCase_ArisingReferenceName` varchar(150) DEFAULT NULL,
  `AppealCase_ArisingReferenceDate` datetime(3) DEFAULT NULL,
  `AppealCase_UnderREAT_RemarksIfAny` varchar(250) DEFAULT NULL,
  `Remarks_IfAny` varchar(250) DEFAULT NULL,
  `A_column` varchar(90) DEFAULT NULL,
  `B_column` varchar(90) DEFAULT NULL,
  `C_column` varchar(90) DEFAULT NULL,
  `D_column` varchar(90) DEFAULT NULL,
  `E_column` varchar(90) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsLatestActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsDraftMember` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `IsFlag` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`CaseAllocation_formN_eCourtIndexID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_ecourt_complaint_formn_caseallocation`
--

LOCK TABLES `tbl_rera_ecourt_complaint_formn_caseallocation` WRITE;
/*!40000 ALTER TABLE `tbl_rera_ecourt_complaint_formn_caseallocation` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_ecourt_complaint_formn_caseallocation` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:16
