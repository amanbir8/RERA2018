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
-- Table structure for table `tbl_rera_hdcr_project_projectlandsdetails`
--

DROP TABLE IF EXISTS `tbl_rera_hdcr_project_projectlandsdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_hdcr_project_projectlandsdetails` (
  `ProjectPUC_ProjectLand_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ProjectPUC_ProjectLand_ID` bigint(20) NOT NULL,
  `Related_Promoter_ID` bigint(20) NOT NULL,
  `Related_Project_ID` bigint(20) NOT NULL,
  `RelatedApplicationPUC_ID` bigint(20) NOT NULL,
  `PUC_DiaryNumber` varchar(100) NOT NULL,
  `PUC_ReferencePUC_Name` varchar(100) NOT NULL,
  `PUC_ReferencePUC_Date` datetime(3) NOT NULL,
  `PUC_RequestCategoryID` bigint(20) NOT NULL,
  `RERAnumberRegistration` varchar(100) NOT NULL,
  `ProjectDiaryNumber` varchar(100) NOT NULL,
  `ExtensionRegdDiaryNumber` varchar(100) NOT NULL,
  `IsConditionAnnexure` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `IsApproved` int(11) NOT NULL,
  `IsMemberApproved` int(11) NOT NULL,
  `Account_FormDate` datetime(3) NOT NULL,
  `Account_ToDate` datetime(3) NOT NULL,
  `Approved_AccountDate` datetime(3) NOT NULL,
  `Approved_AccountBy` varchar(50) NOT NULL,
  `ACR_AccountDate` datetime(3) NOT NULL,
  `ACR_AccountBy` varchar(50) NOT NULL,
  `PUC_Doc_ReferenceTitle` varchar(250) NOT NULL,
  `PUC_Doc_ReferenceNumber` varchar(250) DEFAULT NULL,
  `PUC_AuthorizedPerson_PAN_Number` varchar(90) NOT NULL,
  `PUC_AuthorizedPerson_Aadhaar_Number` varchar(90) DEFAULT NULL,
  `PUC_ReferenceDetailsIfAny` varchar(250) DEFAULT NULL,
  `ProjectLand_IndexID` bigint(20) NOT NULL,
  `ProjectLand_ID` bigint(20) NOT NULL,
  `ProjectLandRelated_ProjectRegistration_ID` bigint(20) NOT NULL,
  `ProposedLand_TobeDeveloped_Area_Total` decimal(8,3) NOT NULL,
  `ProposedLand_Area_ResidentialGroupHousing` decimal(8,3) NOT NULL,
  `ProposedLand_Area_ResidentialPlotted` decimal(8,3) NOT NULL,
  `ProposedLand_Area_Commercial` decimal(8,3) NOT NULL,
  `ProposedLand_Area_Industrial` decimal(8,3) NOT NULL,
  `ProposedLand_Area_A_column` decimal(8,3) NOT NULL,
  `ProposedLand_Area_B_column` decimal(8,3) NOT NULL,
  `ProposedLand_Area_C_column` decimal(8,3) NOT NULL,
  `ProposedLand_Area_D_column` decimal(8,3) NOT NULL,
  `Name_of_Villages` varchar(500) NOT NULL,
  `ProposedLand_TobeDeveloped_TotalOpenArea` decimal(8,3) NOT NULL,
  `ProposedLand_TobeDeveloped_TotalCoveredArea` decimal(8,3) NOT NULL,
  `ProposedProjectLand_StartPoint_Longitude` decimal(7,4) NOT NULL,
  `ProposedProjectLand_StartPoint_Latitude` decimal(7,4) NOT NULL,
  `ProposedProjectLand_EndPoint_Longitude` decimal(7,4) NOT NULL,
  `ProposedProjectLand_EndPoint_Latitude` decimal(7,4) NOT NULL,
  `IsProjectLand_Status_OwnedByPromoter` varchar(2) NOT NULL,
  `IsProjectLand_Status_NotOwnedByPromoter` varchar(2) NOT NULL,
  `IsLandEncumbrances_IfAny` varchar(2) NOT NULL,
  `Remarks_IfAny` varchar(100) DEFAULT NULL,
  `A_column` varchar(50) DEFAULT NULL,
  `B_column` varchar(50) DEFAULT NULL,
  `C_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ProjectPUC_ProjectLand_IndexID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_hdcr_project_projectlandsdetails`
--

LOCK TABLES `tbl_rera_hdcr_project_projectlandsdetails` WRITE;
/*!40000 ALTER TABLE `tbl_rera_hdcr_project_projectlandsdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_hdcr_project_projectlandsdetails` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:21
