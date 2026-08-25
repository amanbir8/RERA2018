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
-- Table structure for table `tbl_rera_ldr_project_puc_paperunderconsiderations`
--

DROP TABLE IF EXISTS `tbl_rera_ldr_project_puc_paperunderconsiderations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_ldr_project_puc_paperunderconsiderations` (
  `ProjectPUC_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ProjectPUC_ID` bigint(20) NOT NULL,
  `RelatedPromoter_ID` bigint(20) NOT NULL,
  `RelatedProject_ID` bigint(20) NOT NULL,
  `RelatedApplicationPUC_ID` bigint(20) NOT NULL,
  `User_ID` varchar(50) NOT NULL,
  `RERAnumberRegistration` varchar(200) NOT NULL,
  `RERAnumberIssueDate` datetime(3) NOT NULL,
  `RERAnumberRegUptoDate` datetime(3) NOT NULL,
  `IsExtensionRegistration` int(11) NOT NULL,
  `RERAnumberExtensionRegUptoDate` datetime(3) NOT NULL,
  `ProjectDiaryNumber` varchar(250) DEFAULT NULL,
  `ExtensionRegdDiaryNumber` varchar(250) DEFAULT NULL,
  `ProjectName` varchar(250) NOT NULL,
  `PromoterName` varchar(250) NOT NULL,
  `ProjectAddressDistrict` varchar(250) DEFAULT NULL,
  `DName` varchar(250) DEFAULT NULL,
  `ProjectType` varchar(250) NOT NULL,
  `PUC_ChangeForDetails` varchar(250) DEFAULT NULL,
  `PUC_ChangeSummary` varchar(500) NOT NULL,
  `PUC_ReferencePUC_Name` varchar(250) DEFAULT NULL,
  `PUC_ReferencePUC_Year` int(11) NOT NULL,
  `PUC_ReferencePUC_Date` datetime(3) NOT NULL,
  `PUC_RequestCategoryName` varchar(400) NOT NULL,
  `PUC_RequestCategoryID` bigint(20) NOT NULL,
  `PUC_ReferenceDocumentDetail` varchar(500) NOT NULL,
  `PUC_ReferenceDocumentNumber` varchar(100) NOT NULL,
  `PUC_DocReferenceName` varchar(250) DEFAULT NULL,
  `PUC_DocReferenceDate` datetime(3) NOT NULL,
  `PUC_DocumentStatus` varchar(200) NOT NULL,
  `PUC_ReceiptDatePlanned_DateExpected` datetime(3) NOT NULL,
  `PUC_ReciptType` varchar(200) NOT NULL,
  `RemarksIfAny` varchar(300) DEFAULT NULL,
  `Extra1` varchar(200) DEFAULT NULL,
  `Extra2` varchar(200) DEFAULT NULL,
  `Extra3` varchar(200) DEFAULT NULL,
  `Extra4` varchar(200) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `IsDraftHelpDesk` int(11) NOT NULL,
  `IsDraftEvaluation` int(11) NOT NULL,
  `IsDraftSecMember` int(11) NOT NULL,
  `IsDraftMember` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ProjectPUC_IndexID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_ldr_project_puc_paperunderconsiderations`
--

LOCK TABLES `tbl_rera_ldr_project_puc_paperunderconsiderations` WRITE;
/*!40000 ALTER TABLE `tbl_rera_ldr_project_puc_paperunderconsiderations` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_ldr_project_puc_paperunderconsiderations` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:35
