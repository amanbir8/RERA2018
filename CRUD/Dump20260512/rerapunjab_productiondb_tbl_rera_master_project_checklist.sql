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
-- Table structure for table `tbl_rera_master_project_checklist`
--

DROP TABLE IF EXISTS `tbl_rera_master_project_checklist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_project_checklist` (
  `CheckList_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `CheckList_Code` int(11) NOT NULL,
  `CheckList_Name` varchar(200) NOT NULL,
  `CheckList_Head` varchar(100) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`CheckList_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_project_checklist`
--

LOCK TABLES `tbl_rera_master_project_checklist` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_project_checklist` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_project_checklist` VALUES (2,101,'Promoter Details - Individual','Promoter Profile',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(4,137,'Promoter Details - Other than Individual','Promoter Profile',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(5,102,'Financial Details','Promoter Profile',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(6,103,'Track Record of Promoter','Promoter Profile',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(7,104,'Projects launched in the last 5 years (if any)','Promoter Profile',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(8,105,'Form A as defined in the Rules','Project Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(9,106,'Form B as defined in the Rules','Project Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(10,107,'Project Name & Address','Project Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(11,108,'Communication Details of Authorized Person','Project Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(12,109,'Project Amenities','Project Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(13,110,'Project Specifications','Project Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(14,111,'Project Facts','Project Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(15,112,'Registration Fee','Project Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(16,113,'Plan for development works in the project','Project Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(17,114,'Litigation Details','Project Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(18,115,'Documents to be signed with allottees','Project Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(19,116,'Location Details','Project Land Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(20,117,'Legal Title Deed of the promoter for the land','Project Land Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(21,118,'Consent details of owner incase builder is not owner of land','Project Land Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(22,119,'Encumbrance details of the land','Project Land Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(23,120,'Land Title Search Report','Project Land Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(24,121,'Approved Project Plans (Copy of the documents sanctioned by competent authority)','Project Land Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(25,122,'Approvals and commencment certificate for the project (Mega Project)','Project Approval Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(26,123,'Approvals and commencment certificate for the project (Other Projects)','Project Approval Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(27,124,'Details of other Approvals, Permissions, Clearances, Modifications, Amendments, Revisions or Legal Documents','Project Approval Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(28,125,'Certifications regarding the project','Project Approval Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(29,126,'Special bank account number as per subclause D of clause(l) of subsection 2 of section 4 of the Act','Special Bank Account Details',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(30,127,'Construction Details','Project Updates (Quarterly basis)',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(31,128,'Apartment/Plot inventory details','Project Updates (Quarterly basis)',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(32,129,'Parking Details','Project Updates (Quarterly basis)',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(33,130,'Internal Infrastrcuture status','Project Updates (Quarterly basis)',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(34,131,'Proposed Facilities','Project Updates (Quarterly basis)',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(35,132,'Common Project Infrastructure (External development works)','Project Updates (Quarterly basis)',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(36,133,'Project Documents','Project Updates (Quarterly basis)',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(37,134,'Form 5 of General Regulations','Project Updates (Quarterly basis)',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(38,135,'Details of real estate agents (if any)','Project Updates (Quarterly basis)',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(39,136,'Details of Contractors, architects, structural engineer (if any)','Project Updates (Quarterly basis)',2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-17 13:08:00.000'),(40,151,'Promoter Profile','Promoter Details',1,'sysadmin','2018-04-12 13:08:00.000','sysadmin','2018-04-12 13:08:00.000'),(41,152,'Promoter Track Record','Promoter Details',1,'sysadmin','2018-04-12 13:08:00.000','sysadmin','2018-04-12 13:08:00.000'),(42,153,'Promoter Documents','Promoter Details',1,'sysadmin','2018-04-12 13:08:00.000','sysadmin','2018-04-12 13:08:00.000'),(43,154,'Project Details','Project Details and Description',1,'sysadmin','2018-04-12 13:08:00.000','sysadmin','2018-04-12 13:08:00.000'),(44,155,'Project Land Details','Project Details and Description',1,'sysadmin','2018-04-12 13:08:00.000','sysadmin','2018-04-12 13:08:00.000'),(45,156,'Project Litigations','Project Details and Description',1,'sysadmin','2018-04-12 13:08:00.000','sysadmin','2018-04-12 13:08:00.000'),(46,157,'Project Approval\n','Project Details and Description',1,'sysadmin','2018-04-12 13:08:00.000','sysadmin','2018-04-12 13:08:00.000'),(47,158,'Project Documents','Project Details and Description',1,'sysadmin','2018-04-12 13:08:00.000','sysadmin','2018-04-12 13:08:00.000'),(48,159,'Special Bank Account Details','Project Details and Description',1,'sysadmin','2018-04-12 13:08:00.000','sysadmin','2018-04-12 13:08:00.000'),(49,160,'Project Updates','Project (Quarterly Update) Details and Description ',1,'sysadmin','2018-04-12 13:08:00.000','sysadmin','2018-04-12 13:08:00.000'),(50,161,'Project Professionals\n','Project (Quarterly Update) Details and Description',1,'sysadmin','2018-04-12 13:08:00.000','sysadmin','2018-04-12 13:08:00.000'),(51,162,'Project Photographs','Project (Quarterly Update) Details and Description',1,'sysadmin','2018-04-12 13:08:00.000','sysadmin','2018-04-12 13:08:00.000'),(52,163,'Project Registration Fee Details','Project Details and Description',1,'sysadmin','2018-04-12 13:08:00.000','sysadmin','2018-04-12 13:08:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_project_checklist` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:25
