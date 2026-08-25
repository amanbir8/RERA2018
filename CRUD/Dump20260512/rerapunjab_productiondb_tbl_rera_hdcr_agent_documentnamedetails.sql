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
-- Table structure for table `tbl_rera_hdcr_agent_documentnamedetails`
--

DROP TABLE IF EXISTS `tbl_rera_hdcr_agent_documentnamedetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_hdcr_agent_documentnamedetails` (
  `AgentPUC_DocumentName_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `AgentPUC_DocumentName_ID` bigint(20) NOT NULL,
  `Related_Agent_ID` bigint(20) NOT NULL,
  `Related_AgentRenewal_ID` bigint(20) NOT NULL,
  `RelatedApplicationPUC_ID` bigint(20) NOT NULL,
  `PUC_DiaryNumber` varchar(100) NOT NULL,
  `PUC_ReferencePUC_Name` varchar(100) NOT NULL,
  `PUC_ReferencePUC_Date` datetime(3) NOT NULL,
  `PUC_RequestCategoryID` bigint(20) NOT NULL,
  `RERAnumberRegistration` varchar(100) NOT NULL,
  `AgentDiaryNumber` varchar(100) NOT NULL,
  `AgentDoc_InfoCode_ChangeTo` varchar(100) NOT NULL,
  `AgentDoc_InfoName_ChangeTo` varchar(250) NOT NULL,
  `Account_FormDate` datetime(3) NOT NULL,
  `Account_ToDate` datetime(3) NOT NULL,
  `Approved_AccountDate` datetime(3) NOT NULL,
  `Approved_AccountBy` varchar(50) NOT NULL,
  `ACR_AccountDate` datetime(3) NOT NULL,
  `ACR_AccountBy` varchar(50) NOT NULL,
  `rea_AgentDoc_IndexID` bigint(20) NOT NULL,
  `rea_AgentDoc_ID` bigint(20) NOT NULL,
  `rea_Agent_ID` bigint(20) NOT NULL,
  `rea_AgentDoc_InfoCode` int(11) NOT NULL,
  `rea_AgentDoc_InfoName` varchar(90) NOT NULL,
  `rea_AgentDoc_ReferenceNumber` varchar(90) DEFAULT NULL,
  `rea_AgentDoc_IssueDate` datetime(3) NOT NULL,
  `rea_AgentDoc_FileSize` varchar(50) NOT NULL,
  `rea_AgentDoc_FileFormat` varchar(50) NOT NULL,
  `rea_AgentDoc_FilePath` varchar(250) NOT NULL,
  `rea_AgentDoc_FileName` varchar(250) NOT NULL,
  `rea_AgentDoc_IsGroup` int(11) NOT NULL,
  `rea_Remarks_IfAny` varchar(300) DEFAULT NULL,
  `rea_A_column` varchar(500) DEFAULT NULL,
  `rea_B_column` varchar(50) DEFAULT NULL,
  `rea_C_column` varchar(50) DEFAULT NULL,
  `rea_IsActive` int(11) NOT NULL,
  `rea_IsDraft` int(11) NOT NULL,
  `rea_CreatedBy` varchar(50) NOT NULL,
  `rea_CreatedOn` datetime(3) NOT NULL,
  `rea_ModifyBy` varchar(50) NOT NULL,
  `rea_ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`AgentPUC_DocumentName_IndexID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_hdcr_agent_documentnamedetails`
--

LOCK TABLES `tbl_rera_hdcr_agent_documentnamedetails` WRITE;
/*!40000 ALTER TABLE `tbl_rera_hdcr_agent_documentnamedetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_hdcr_agent_documentnamedetails` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:17
