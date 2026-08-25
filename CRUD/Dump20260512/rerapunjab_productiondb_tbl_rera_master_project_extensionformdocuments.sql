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
-- Table structure for table `tbl_rera_master_project_extensionformdocuments`
--

DROP TABLE IF EXISTS `tbl_rera_master_project_extensionformdocuments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_project_extensionformdocuments` (
  `ProjectDocMaster_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `ProjectDocMaster_InfoCode` int(11) NOT NULL,
  `ProjectDocMaster_InfoName` varchar(90) NOT NULL,
  `ProjectDocMaster_RelatedSectionName` varchar(90) NOT NULL,
  `ProjectDoc_SetFileSize` varchar(50) NOT NULL,
  `ProjectDoc_SetFileFormat` varchar(50) NOT NULL,
  `ProjectDoc_SetFilePath` varchar(250) NOT NULL,
  `ProjectDoc_ValidCode` int(11) NOT NULL,
  `ProjectDoc_ValidSubCode` int(11) NOT NULL,
  `ProjectDoc_ValidTinySubCode` int(11) NOT NULL,
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
  PRIMARY KEY (`ProjectDocMaster_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_project_extensionformdocuments`
--

LOCK TABLES `tbl_rera_master_project_extensionformdocuments` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_project_extensionformdocuments` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_project_extensionformdocuments` VALUES (1,1101,'RERA Registration Certificate','Project Extension Documents','1048576','JPEG/JPG/PDF','readwriteExtFormDoc',0,0,4,1,'1','Authenticated copy of the project registration certificate by Punjab Real Estate Regulatory Authority',NULL,'4',1,'systemdb','2019-01-17 13:08:00.000','systemdb','2019-01-17 13:08:00.000'),(2,1102,'Authenticated Plan of the project development works','Project Extension Documents','2097152','JPEG/JPG/PDF','readwriteExtFormDoc',0,0,1,1,'1','Authenticated Plan of the project showning the stage of development works undertaken till date',NULL,'1',1,'systemdb','2019-01-17 13:08:00.000','systemdb','2019-01-17 13:08:00.000'),(3,1103,'Valid License as Promoter from competent Authority','Project Extension Documents','1048576','JPEG/JPG/PDF','readwriteExtFormDoc',0,0,9,1,'1','Authenticated copy of the [permission/approval/COT] from the competent authority which is valid is longer than the proposed term of extension',NULL,'9',2,'systemdb','2019-01-17 13:08:00.000','systemdb','2019-01-17 13:08:00.000'),(4,1104,'Valid License to develop colony/ project or Regularization Certificate','Project Extension Documents','2097152','JPEG/JPG/PDF','readwriteExtFormDoc',0,0,3,1,'1','Authenticated copy of the [permission/approval] from the competent authority which is valid for a period which is longer than the proposed term of extension of the registration sought from the authority or Regularisation certificate in respect of unauthorised colony',NULL,'3',1,'systemdb','2019-01-17 13:08:00.000','systemdb','2019-01-17 13:08:00.000'),(5,1105,'Regularization Certificate','Project Extension Documents','1048576','JPEG/JPG/PDF','readwriteExtFormDoc',0,0,4,1,'1','Authenticated copy of the [permission/approval/COT] from the competent authority which is valid is longer than the proposed term of extension',NULL,'4',2,'systemdb','2019-01-17 13:08:00.000','systemdb','2019-01-17 13:08:00.000'),(6,1106,'Form 1 - Architect Certificate','Project Extension Documents','1048576','JPEG/JPG/PDF','readwriteExtFormDoc',0,0,6,1,'1','Form 1 - Architect Certificate',NULL,'6',2,'systemdb','2019-01-17 13:08:00.000','systemdb','2019-01-17 13:08:00.000'),(7,1107,'Form 2 - Engineer Certificate','Project Extension Documents','1048576','JPEG/JPG/PDF','readwriteExtFormDoc',0,0,7,1,'1','Form 2 - Engineer Certificate',NULL,'7',2,'systemdb','2019-01-17 13:08:00.000','systemdb','2019-01-17 13:08:00.000'),(8,1108,'Form 3 - CA Certificate','Project Extension Documents','1048576','JPEG/JPG/PDF','readwriteExtFormDoc',0,0,8,1,'1','Form 3 - CA Certificate',NULL,'8',2,'systemdb','2019-01-17 13:08:00.000','systemdb','2019-01-17 13:08:00.000'),(9,1109,'State of development work and reason for not completing (explanatory note)','Project Extension Documents','1048576','JPEG/JPG/PDF','readwriteExtFormDoc',0,0,2,1,'1','Explanatory note reagrding the state of development works in the project and reason for not completing the development works in the project within the period declared in the declaration submitted in Form B at the time of registration of project [Rule 6 (2)]',NULL,'2',1,'systemdb','2019-01-17 13:08:00.000','systemdb','2019-01-17 13:08:00.000'),(10,1110,'Form B (Authenticated Copy)','Project Extension Documents','1048576','JPEG/JPG/PDF','readwriteExtFormDoc',0,0,5,1,'1','Authenticated Copy of Form B',NULL,'5',2,'systemdb','2019-01-17 13:08:00.000','systemdb','2019-01-17 13:08:00.000'),(11,1111,'Form 1 - Architect Certificate (alongwith Table A and Table B)','Project Extension Documents','1048576','JPEG/JPG/PDF','readwriteExtFormDoc',0,0,6,1,'1','Form 1 of Punjab RERA (General) Regulations, 2017, from Architect alongwith Table A and Table B',NULL,'6',1,'systemdb','2019-07-11 15:47:00.000','systemdb','2019-07-11 15:47:00.000'),(12,1112,'Proforma for Undertaking- cum-Indemnity Bond','Project Extension Documents','1048576','JPEG/JPG/PDF','readwriteExtFormDoc',0,0,10,1,'1','Proforma for Undertaking- cum-Indemnity Bond',NULL,'10',1,'systemdb','2022-12-12 10:10:00.000','systemdb','2022-12-12 10:10:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_project_extensionformdocuments` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:37
