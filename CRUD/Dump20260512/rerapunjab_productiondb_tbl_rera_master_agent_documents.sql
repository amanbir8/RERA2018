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
-- Table structure for table `tbl_rera_master_agent_documents`
--

DROP TABLE IF EXISTS `tbl_rera_master_agent_documents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_agent_documents` (
  `AgentDocMaster_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `AgentDocMaster_InfoCode` int(11) NOT NULL,
  `AgentDocMaster_InfoName` varchar(90) NOT NULL,
  `AgentDoc_SetFileSize` varchar(50) NOT NULL,
  `AgentDoc_SetFileFormat` varchar(50) NOT NULL,
  `AgentDoc_SetFilePath` varchar(250) NOT NULL,
  `AgentDoc_ValidCode` int(11) NOT NULL,
  `AgentDoc_ValidSubCode` int(11) NOT NULL,
  `AgentDoc_ValidTinySubCode` int(11) NOT NULL,
  `IsGroup` int(11) NOT NULL,
  `IsMandatory` varchar(2) NOT NULL,
  `A_column` varchar(500) DEFAULT NULL,
  `B_column` varchar(50) DEFAULT NULL,
  `C_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`AgentDocMaster_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_agent_documents`
--

LOCK TABLES `tbl_rera_master_agent_documents` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_agent_documents` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_agent_documents` VALUES (3,401,'Permanent Address Proof','2012048','JPEG/JPG/PDF','readwriteAgentDoc',1,0,1,1,'1','Permanent Address Proof (Self Attested Scan Copy)','readwriteRnAgentFMJ','0',1,'sysadmin','2018-06-22 13:08:00.000','sysadmin','2018-06-22 13:08:00.000'),(7,402,'Place of Bussiness Address Proof','2012048','JPEG/JPG/PDF','readwriteAgentDoc',3,0,1,1,'1','Address Proof of Place of Bussiness (Self Attested Scan Copy)','readwriteRnAgentFMJ','NULL',1,'sysadmin','2018-06-22 13:08:00.000','sysadmin','2018-06-22 13:08:00.000'),(8,403,'PAN Copy','768256','JPEG/JPG/PDF','readwriteAgentDoc',1,0,2,1,'1','Upload PAN copy (Self Attested Scan Copy)','readwriteRnAgentFMJ','NULL',1,'sysadmin','2018-06-22 13:08:00.000','sysadmin','2018-06-22 13:08:00.000'),(11,404,'Income Tax Return 1','2012048','JPEG/JPG/PDF','readwriteAgentDoc',3,0,4,1,'1','Income Tax Return filed (Self Attested Scan Copy)','readwriteRnAgentFMJ','NULL',1,'sysadmin','2018-06-22 13:08:00.000','sysadmin','2018-06-22 13:08:00.000'),(16,405,'Pan Copy (Organization)','768256','JPEG/JPG/PDF','readwriteAgentDoc',2,0,2,1,'1','Upload PAN copy of Organization (Self Attested Scan Copy)','readwriteRnAgentFMJ','NULL',1,'sysadmin','2018-06-22 13:08:00.000','sysadmin','2018-06-22 13:08:00.000'),(17,406,'Company Registration Certificate','4024096','JPEG/JPG/PDF','readwriteAgentDoc',2,0,0,1,'0','Upload Company Registration Certificate (Self Attested Scan Copy)','readwriteRnAgentFMJ','NULL',2,'sysadmin','2029-11-17 13:08:00.000','sysadmin','2029-11-17 13:08:00.000'),(18,407,'Registration including Bye-laws','4024096','JPEG/JPG/PDF','readwriteAgentDoc',2,0,0,1,'0','Particulars of registration as the case may be (Self Attested Scan Copy)','readwriteRnAgentFMJ','NULL',2,'sysadmin','2030-11-17 13:08:00.000','sysadmin','2030-11-17 13:08:00.000'),(21,408,'Memorandum of Association','1101024','JPEG/JPG/PDF','readwriteAgentDoc',2,0,0,1,'0','Particulars of registration as the case may be (Self Attested Scan Copy)','readwriteRnAgentFMJ','NULL',2,'sysadmin','2001-12-17 13:08:00.000','sysadmin','2001-12-17 13:08:00.000'),(23,409,'Articles of Association','1101024','JPEG/JPG/PDF','readwriteAgentDoc',2,0,0,1,'0','Particulars of registration as the case may be (Self Attested Scan Copy)','readwriteRnAgentFMJ','NULL',2,'sysadmin','2002-12-17 13:08:00.000','sysadmin','2002-12-17 13:08:00.000'),(24,410,'Company Registration Certificate or Registration By-Law or MOA or AOA','4024096','JPEG/JPG/PDF','readwriteAgentDoc',2,0,3,1,'1','Particulars of registration as the case may be (Company Registration Certificate or Registration By-Law or MOA or AOA) (Self Attested Scan Copy)','readwriteRnAgentFMJ',NULL,1,'sysadmin','2017-12-17 13:08:00.000','sysadmin','2017-12-17 13:08:00.000'),(25,411,'Income Tax Return 2','2012048','JPEG/JPG/PDF','readwriteAgentDoc',3,0,5,1,'1','Income Tax Return filed (Self Attested Scan Copy)','readwriteRnAgentFMJ',NULL,1,'sysadmin','2018-06-22 13:08:00.000','sysadmin','2018-06-22 13:08:00.000'),(26,412,'Income Tax Return 3','2012048','JPEG/JPG/PDF','readwriteAgentDoc',3,0,6,1,'1','Income Tax Return filed (Self Attested Scan Copy)','readwriteRnAgentFMJ',NULL,1,'sysadmin','2018-06-22 13:08:00.000','sysadmin','2018-06-22 13:08:00.000'),(27,413,'Proforma for Undertaking- cum-Indemnity Bond','1101024','JPEG/JPG/PDF','readwriteAgentDoc',3,0,7,1,'1','Proforma for Undertaking- cum-Indemnity Bond with regard to GST alongwith late fees interest.','readwriteRnAgentFMJ',NULL,2,'sysadmin','2022-10-21 11:11:00.000','sysadmin','2022-10-21 11:11:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_agent_documents` ENABLE KEYS */;
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
