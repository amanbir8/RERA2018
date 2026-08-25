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
-- Table structure for table `tbl_rera_ldr_project_registration`
--

DROP TABLE IF EXISTS `tbl_rera_ldr_project_registration`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_ldr_project_registration` (
  `ProjectRegistration_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ProjectRegistration_ID` bigint(20) NOT NULL,
  `Project_Name` varchar(90) NOT NULL,
  `Project_Amenities` varchar(500) NOT NULL,
  `IsAlready_RERANumber` varchar(2) NOT NULL,
  `Existing_RERANumber` varchar(50) DEFAULT NULL,
  `ProposedProjectDetail_Structure` varchar(255) NOT NULL,
  `ProposedProjectDetail_Flooring` varchar(255) NOT NULL,
  `ProposedProjectDetail_WallFinishing` varchar(255) NOT NULL,
  `ProposedProjectDetail_SanitaryFittings` varchar(255) NOT NULL,
  `ProposedProjectDetail_ElectricalFittings` varchar(255) NOT NULL,
  `ProposedProjectDetail_Kitchen` varchar(255) NOT NULL,
  `IsProposedProjectDetail_OthersIfAny` varchar(2) NOT NULL,
  `ProposedProjectDetail_OthersIfAnyName` varchar(50) NOT NULL,
  `ProposedProjectDetail_OthersIfAny` varchar(255) NOT NULL,
  `Project_Status` varchar(50) NOT NULL,
  `ProjectStart_Date` datetime(3) NOT NULL,
  `ProjectCompletion_ProposedDate` datetime(3) NOT NULL,
  `ProjectCompletion_OriginalDate` datetime(3) NOT NULL,
  `ProjectRegistrationProvided_Duration` varchar(90) NOT NULL,
  `ProjectDelayReason_IfAny` varchar(255) DEFAULT NULL,
  `Project_AddressLine1` varchar(90) NOT NULL,
  `Project_AddressLine2` varchar(90) NOT NULL,
  `Project_AddressStateCode` int(11) NOT NULL,
  `Project_AddressDistrictCode` int(11) NOT NULL,
  `Project_AddressSubDivisionCode` int(11) NOT NULL,
  `Project_AddressPIN` varchar(10) NOT NULL,
  `Project_PotentialZoneCode` int(11) NOT NULL,
  `ProjectWebsite_WebLink` varchar(90) NOT NULL,
  `AuthorizedPerson_FirstName` varchar(50) NOT NULL,
  `AuthorizedPerson_MiddleName` varchar(50) NOT NULL,
  `AuthorizedPerson_LastName` varchar(50) NOT NULL,
  `AuthorizedPerson_AddressLine1` varchar(90) NOT NULL,
  `AuthorizedPerson_AddressLine2` varchar(90) NOT NULL,
  `AuthorizedPerson_AddressStateCode` int(11) NOT NULL,
  `AuthorizedPerson_AddressDistrictCode` int(11) NOT NULL,
  `AuthorizedPerson_AddressPIN` varchar(10) NOT NULL,
  `AuthorizedPerson_EmailAddress` varchar(100) NOT NULL,
  `AuthorizedPerson_MobileNumber` bigint(20) NOT NULL,
  `IsProForma_AOS_RERAformat_AnnexureA` varchar(2) NOT NULL,
  `IsProForma_AOS_RERAformat_No_IsApproved` varchar(2) NOT NULL,
  `IsProject_MegaProjectCategory` varchar(2) NOT NULL,
  `IsLitigation_RelatedProject` varchar(2) NOT NULL,
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
  `Promoter_ID` bigint(20) DEFAULT NULL,
  `Used_ID` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ProjectRegistration_IndexID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_ldr_project_registration`
--

LOCK TABLES `tbl_rera_ldr_project_registration` WRITE;
/*!40000 ALTER TABLE `tbl_rera_ldr_project_registration` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_ldr_project_registration` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:07
