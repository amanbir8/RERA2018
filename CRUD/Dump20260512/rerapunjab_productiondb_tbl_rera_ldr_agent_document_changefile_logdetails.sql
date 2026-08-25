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
-- Table structure for table `tbl_rera_ldr_agent_document_changefile_logdetails`
--

DROP TABLE IF EXISTS `tbl_rera_ldr_agent_document_changefile_logdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_ldr_agent_document_changefile_logdetails` (
  `Agentlog_changefile_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `Related_AgentDoc_IndexID` bigint(20) NOT NULL,
  `Related_AgentDoc_ID` bigint(20) NOT NULL,
  `Related_Agent_ID` bigint(20) NOT NULL,
  `Related_AgentRenewal_ID` bigint(20) NOT NULL,
  `Related_AgentDoc_InfoCode` bigint(20) NOT NULL,
  `Related_Agent_DiaryNumber` varchar(100) DEFAULT NULL,
  `Related_RERA_RegistrationNumber` varchar(100) DEFAULT NULL,
  `User_Role` varchar(100) NOT NULL,
  `UserID` varchar(100) NOT NULL,
  `Remarks_IfAny` varchar(500) DEFAULT NULL,
  `LockUnlockMsg_IfAny` varchar(250) DEFAULT NULL,
  `A_Column` varchar(100) DEFAULT NULL,
  `B_Column` varchar(100) DEFAULT NULL,
  `C_Column` varchar(100) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`Agentlog_changefile_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_ldr_agent_document_changefile_logdetails`
--

LOCK TABLES `tbl_rera_ldr_agent_document_changefile_logdetails` WRITE;
/*!40000 ALTER TABLE `tbl_rera_ldr_agent_document_changefile_logdetails` DISABLE KEYS */;
INSERT INTO `tbl_rera_ldr_agent_document_changefile_logdetails` VALUES (2,16876,15898,7388,0,411,'REA20210339','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Trashed request completed, ID(7388)','trashed','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2021-11-29 10:40:22.000','sysadmin','2021-11-29 10:40:22.000'),(3,16877,15899,7388,0,412,'REA20210339','','319a2b07-788f-4f90-9cda-3bca6ed81d3c','f193be5c-b13c-42ce-8d73-4a045acb493b','Trashed request completed, ID(7388)','trashed','','','',1,1,'f193be5c-b13c-42ce-8d73-4a045acb493b','2021-11-29 10:40:32.000','sysadmin','2021-11-29 10:40:32.000');
/*!40000 ALTER TABLE `tbl_rera_ldr_agent_document_changefile_logdetails` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:54
