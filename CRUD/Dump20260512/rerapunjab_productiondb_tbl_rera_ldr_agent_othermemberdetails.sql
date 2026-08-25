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
-- Table structure for table `tbl_rera_ldr_agent_othermemberdetails`
--

DROP TABLE IF EXISTS `tbl_rera_ldr_agent_othermemberdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_ldr_agent_othermemberdetails` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Agent_OtherMemberDetails_ID` bigint(20) NOT NULL,
  `Agent_ID` bigint(20) NOT NULL,
  `Designation` varchar(100) NOT NULL,
  `OtherMember_Name` varchar(100) NOT NULL,
  `OtherMember_PAN_Number` varchar(100) NOT NULL,
  `OtherMember_Aadhaar_Number` varchar(100) NOT NULL,
  `OfficeComm_AddressLine1` varchar(100) NOT NULL,
  `OfficeComm_AddressLine2` varchar(100) NOT NULL,
  `OfficeComm_AddressStateCode` int(11) NOT NULL,
  `OfficeComm_AddressDistrictCode` int(11) NOT NULL,
  `OfficeComm_AddressPIN` int(11) NOT NULL,
  `MobileNumber` bigint(20) NOT NULL,
  `PhoneNumber_STD` bigint(20) DEFAULT NULL,
  `PhoneNumber_Number` bigint(20) DEFAULT NULL,
  `EmailAddress` varchar(100) NOT NULL,
  `Image_FileName` varchar(100) NOT NULL,
  `Image_FilePath` varchar(100) NOT NULL,
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
-- Dumping data for table `tbl_rera_ldr_agent_othermemberdetails`
--

LOCK TABLES `tbl_rera_ldr_agent_othermemberdetails` WRITE;
/*!40000 ALTER TABLE `tbl_rera_ldr_agent_othermemberdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_ldr_agent_othermemberdetails` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:29
