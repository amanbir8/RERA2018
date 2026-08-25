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
-- Table structure for table `tbl_rera_master_complaint_interimorders_documents`
--

DROP TABLE IF EXISTS `tbl_rera_master_complaint_interimorders_documents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_complaint_interimorders_documents` (
  `ComplaintDocMaster_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `ComplaintDocMaster_InfoCode` int(11) NOT NULL,
  `ComplaintDocMaster_InfoName` varchar(90) NOT NULL,
  `ComplaintDocMaster_RelatedSectionName` varchar(90) NOT NULL,
  `ComplaintDoc_SetFileSize` varchar(50) NOT NULL,
  `ComplaintDoc_SetFileFormat` varchar(50) NOT NULL,
  `ComplaintDoc_SetFilePath` varchar(250) NOT NULL,
  `ComplaintDoc_ValidCode` int(11) NOT NULL,
  `ComplaintDoc_ValidSubCode` int(11) NOT NULL,
  `ComplaintDoc_ValidTinySubCode` int(11) NOT NULL,
  `IsGroup` int(11) NOT NULL,
  `IsMandatory` varchar(10) NOT NULL,
  `A_column` varchar(500) DEFAULT NULL,
  `B_column` varchar(50) DEFAULT NULL,
  `C_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ComplaintDocMaster_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_complaint_interimorders_documents`
--

LOCK TABLES `tbl_rera_master_complaint_interimorders_documents` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_complaint_interimorders_documents` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_complaint_interimorders_documents` VALUES (1,401,'FormM Interim Order','Interim Order Document','15485760','PDF','rwFormMInterimOrder',1,0,0,60,'1','Document Master',NULL,NULL,1,'systemdb','2019-12-01 10:10:00.000','systemdb','2019-12-01 10:10:00.000'),(2,402,'FormN Interim Order','Interim Order Document','15485760','PDF','rwFormNInterimOrder',1,0,0,60,'1','Document Master',NULL,NULL,1,'systemdb','2019-12-01 10:10:00.000','systemdb','2019-12-01 10:10:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_complaint_interimorders_documents` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:46
