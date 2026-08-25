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
-- Table structure for table `tbl_rera_webapplication_agentuploadlist`
--

DROP TABLE IF EXISTS `tbl_rera_webapplication_agentuploadlist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_webapplication_agentuploadlist` (
  `UploadFilePDF_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `UploadFilePDF_ID` bigint(20) NOT NULL,
  `FileReferenceType` varchar(100) NOT NULL,
  `FileReferenceName` varchar(250) NOT NULL,
  `Date_of_UploadorIssue` datetime(3) NOT NULL,
  `UploadFilePDF_BaseUrl` varchar(100) DEFAULT NULL,
  `UploadFilePDF_FilePath` varchar(250) DEFAULT NULL,
  `UploadFilePDF_FileName` varchar(250) DEFAULT NULL,
  `UploadFilePDF_FileType` varchar(250) DEFAULT NULL,
  `A_column` varchar(50) DEFAULT NULL,
  `B_column` varchar(50) DEFAULT NULL,
  `C_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsDraftMember` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`UploadFilePDF_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_webapplication_agentuploadlist`
--

LOCK TABLES `tbl_rera_webapplication_agentuploadlist` WRITE;
/*!40000 ALTER TABLE `tbl_rera_webapplication_agentuploadlist` DISABLE KEYS */;
INSERT INTO `tbl_rera_webapplication_agentuploadlist` VALUES (1,1001,'List of Registered Real-Estate Agents','','2018-04-27 00:00:00.000','~/','rwPDF/RegisteredAgent\\2019\\','20190107RegAgent769e5776-12a7-4ef6-bcbe-00394f4d0c5b.pdf','.pdf','','','',1,0,1,'PROGuser','2019-01-05 14:01:34.000','PROGuser','2019-01-05 14:01:34.000');
/*!40000 ALTER TABLE `tbl_rera_webapplication_agentuploadlist` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:26
