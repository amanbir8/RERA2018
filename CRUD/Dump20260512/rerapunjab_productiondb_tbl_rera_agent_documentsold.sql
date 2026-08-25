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
-- Table structure for table `tbl_rera_agent_documentsold`
--

DROP TABLE IF EXISTS `tbl_rera_agent_documentsold`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_agent_documentsold` (
  `AgentDocuments_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `AgentDocuments_ID` bigint(20) DEFAULT NULL,
  `Agent_ID` bigint(20) DEFAULT NULL,
  `AgentDoc_InfoCode` int(11) DEFAULT NULL,
  `AgentDoc_InfoName` varchar(90) DEFAULT NULL,
  `AgentDoc_Validity_Year` int(11) DEFAULT NULL,
  `AgentDoc_IssueDate` datetime(3) DEFAULT NULL,
  `AgentDoc_FileSize` varchar(50) DEFAULT NULL,
  `AgentDoc_FileFormat` varchar(50) DEFAULT NULL,
  `AgentDoc_FilePath` varchar(100) DEFAULT NULL,
  `AgentDoc_FileName` varchar(100) DEFAULT NULL,
  `AgentDoc_IsGroup` int(11) DEFAULT NULL,
  `Remarks_IfAny` varchar(100) DEFAULT NULL,
  `A_column` varchar(50) DEFAULT NULL,
  `B_column` varchar(50) DEFAULT NULL,
  `C_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `IsDraft` int(11) DEFAULT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `CreatedOn` datetime(3) DEFAULT NULL,
  `ModifyBy` varchar(50) DEFAULT NULL,
  `ModifyOn` datetime(3) DEFAULT NULL,
  PRIMARY KEY (`AgentDocuments_IndexID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_agent_documentsold`
--

LOCK TABLES `tbl_rera_agent_documentsold` WRITE;
/*!40000 ALTER TABLE `tbl_rera_agent_documentsold` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_agent_documentsold` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:22
