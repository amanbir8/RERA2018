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
-- Table structure for table `tbl_rera_agent_revoke_regdiarynumber`
--

DROP TABLE IF EXISTS `tbl_rera_agent_revoke_regdiarynumber`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_agent_revoke_regdiarynumber` (
  `RevokeAgent_RegDiaryNumber_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `RevokeAgent_RegDiaryNumber_ID` bigint(20) NOT NULL,
  `RevokeAgent_RegDiaryNumber_Name` varchar(50) NOT NULL,
  `RevokeAgent_RegDiaryNumber_NameYear` int(11) NOT NULL,
  `UserID` varchar(50) NOT NULL,
  `Agent_ID` bigint(20) NOT NULL,
  `Agent_Type` int(11) NOT NULL,
  `AgentRegDiaryNumber_Name` varchar(60) NOT NULL,
  `LatestAgentRenewalRegDiaryNumber_Name` varchar(60) NOT NULL,
  `RERAnumberRegistration` varchar(100) NOT NULL,
  `RERAnumberIssueDate` datetime(3) NOT NULL,
  `RERAnumberRegUptoDate` datetime(3) NOT NULL,
  `IsRenewalRegistration` int(11) NOT NULL,
  `RenewalAgent_ID` bigint(20) NOT NULL,
  `RenewalAgent_Year` int(11) NOT NULL,
  `LatestRenewalRegistrationNumber` varchar(100) NOT NULL,
  `LatestRenewalRegistrationIssueDate` datetime(3) NOT NULL,
  `LatestRenewalRegistrationUptoDate` datetime(3) NOT NULL,
  `AgentName` varchar(250) NOT NULL,
  `OrganizationName` varchar(250) NOT NULL,
  `AuthorizedPersonName` varchar(250) NOT NULL,
  `AgentRegisteredDistrict` varchar(250) DEFAULT NULL,
  `AgentBussinessPlaceDistrict` varchar(250) DEFAULT NULL,
  `Revoke_InfoDetails` varchar(350) DEFAULT NULL,
  `Revoke_ReferenceName` varchar(250) DEFAULT NULL,
  `Revoke_ReferenceDate` datetime(3) NOT NULL,
  `Revoke_Category` varchar(400) NOT NULL,
  `Revoke_ReciptType` varchar(200) NOT NULL,
  `Revoke_Reasons` varchar(1250) DEFAULT NULL,
  `Remarks_IfAny` varchar(250) DEFAULT NULL,
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
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`RevokeAgent_RegDiaryNumber_IndexID`),
  KEY `index_tbl_rera_agent_revoke_regdiarynumber` (`Agent_ID`,`RenewalAgent_ID`,`RevokeAgent_RegDiaryNumber_Name`,`RERAnumberRegistration`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_agent_revoke_regdiarynumber`
--

LOCK TABLES `tbl_rera_agent_revoke_regdiarynumber` WRITE;
/*!40000 ALTER TABLE `tbl_rera_agent_revoke_regdiarynumber` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_agent_revoke_regdiarynumber` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:32
