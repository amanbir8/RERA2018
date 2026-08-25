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
-- Table structure for table `tbl_rera_ldr_agent_profile`
--

DROP TABLE IF EXISTS `tbl_rera_ldr_agent_profile`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_ldr_agent_profile` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Agent_ID` bigint(20) NOT NULL,
  `Agent_Type` int(11) NOT NULL,
  `IsAlready_RERANumber` varchar(50) DEFAULT NULL,
  `Existing_RERANumber` varchar(100) DEFAULT NULL,
  `Agent_FirstName` varchar(100) DEFAULT NULL,
  `Agent_MiddleName` varchar(100) DEFAULT NULL,
  `Agent_LastName` varchar(100) DEFAULT NULL,
  `Father_FirstName` varchar(100) DEFAULT NULL,
  `Father_MiddleName` varchar(100) DEFAULT NULL,
  `Father_LastName` varchar(100) DEFAULT NULL,
  `Occupation` varchar(100) DEFAULT NULL,
  `Image_FileName` varchar(100) DEFAULT NULL,
  `Image_FilePath` varchar(100) DEFAULT NULL,
  `P_AddressLine1` varchar(100) DEFAULT NULL,
  `P_AddressLine2` varchar(100) DEFAULT NULL,
  `P_AddressStateCode` int(11) DEFAULT NULL,
  `P_AddressDistrictCode` int(11) DEFAULT NULL,
  `P_AddressPIN` varchar(100) DEFAULT NULL,
  `Organization_Name` varchar(100) DEFAULT NULL,
  `Organization_TypeCode` int(11) DEFAULT NULL,
  `Organization_MainObjects` varchar(100) DEFAULT NULL,
  `RegOffice_AddressLine1` varchar(100) DEFAULT NULL,
  `RegOffice_AddressLine2` varchar(100) DEFAULT NULL,
  `RegOffice_AddressStateCode` int(11) DEFAULT NULL,
  `RegOffice_AddressDistrictCode` int(11) DEFAULT NULL,
  `RegOffice_AddressPIN` int(11) DEFAULT NULL,
  `BusinessPlace_AddressLine1` varchar(100) NOT NULL,
  `BusinessPlace_AddressLine2` varchar(100) NOT NULL,
  `BusinessPlace_AddressStateCode` int(11) NOT NULL,
  `BusinessPlace_AddressDistrictCode` int(11) NOT NULL,
  `BusinessPlace_AddressPIN` int(11) NOT NULL,
  `IsSameBussinessAdd_CommAdd` varchar(100) NOT NULL,
  `BComm_AddressLine1` varchar(100) NOT NULL,
  `BComm_AddressLine2` varchar(100) NOT NULL,
  `BComm_AddressStateCode` int(11) NOT NULL,
  `BComm_AddressDistrictCode` int(11) NOT NULL,
  `BComm_AddressPIN` int(11) NOT NULL,
  `AuthorizedSignatory_FirstName` varchar(100) NOT NULL,
  `AuthorizedSignatory_MiddleName` varchar(100) NOT NULL,
  `AuthorizedSignatory_LastName` varchar(100) NOT NULL,
  `MobileNumber` bigint(20) NOT NULL,
  `PhoneNumber_STD` bigint(20) DEFAULT NULL,
  `PhoneNumber_Number` bigint(20) DEFAULT NULL,
  `EmailAddress` varchar(100) NOT NULL,
  `PAN_Number` varchar(100) NOT NULL,
  `Aadhaar_Number` bigint(20) NOT NULL,
  `IsOtherOrganizationMembers` varchar(100) NOT NULL,
  `IsOtherStateUT_RERAregistration` varchar(100) NOT NULL,
  `Remarks_IfAny` varchar(100) DEFAULT NULL,
  `A_column` varchar(50) DEFAULT NULL,
  `B_column` varchar(50) DEFAULT NULL,
  `C_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `CreatedBy` varchar(100) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(100) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_ldr_agent_profile`
--

LOCK TABLES `tbl_rera_ldr_agent_profile` WRITE;
/*!40000 ALTER TABLE `tbl_rera_ldr_agent_profile` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_ldr_agent_profile` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:57
