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
-- Table structure for table `tbl_rera_master_project_documents_bakup20220406`
--

DROP TABLE IF EXISTS `tbl_rera_master_project_documents_bakup20220406`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_project_documents_bakup20220406` (
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
  `A_column` varchar(4000) DEFAULT NULL,
  `B_column` varchar(50) DEFAULT NULL,
  `C_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ProjectDocMaster_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_project_documents_bakup20220406`
--

LOCK TABLES `tbl_rera_master_project_documents_bakup20220406` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_project_documents_bakup20220406` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_project_documents_bakup20220406` VALUES (6,1001,'Authenticated Copy of Form B','Project Documents','1048576','JPEG/JPG/PDF','readwriteProjectDoc',1,1,0,1,'1','Authenticated Copy of Form B of the Punjab RERA Rules. The prescribed format may be downloaded from the Forms and Templates section under the Downloads tab of the web portal.','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(9,1002,'Pro forma of Allotment Letter to be provided to allottees','Project Documents','1048576','JPEG/JPG/PDF','readwriteProjectDoc',1,1,0,1,'1','Proforma of Allotment Letter to be provided to the allottee at the time of allotment of a particular unit of the project.','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(10,1003,'Project Schedule or Work Plan','Project Documents','768256','JPEG/JPG/PDF','readwriteProjectDoc',1,1,0,5,'1','The plan of developemt works to be executed in the project and the details of the proposed facilities to be provided thereof and the timelines to achieve the same.','NULL','NULL',2,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(11,1004,'Project Land Photograph','Project Documents','1024096','JPEG/JPG/PDF','readwriteProjectDoc',1,1,0,5,'1','Photograph of Project Land and Construction Site.','NULL','NULL',2,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(13,1005,'Self-Declaration Certification - Potential Zone','Project Documents','512048','JPEG/JPG/PDF','readwriteProjectDoc',1,1,0,1,'1','Self-Declaration from the promoter certifying the Potential Zone under which the project falls.','NULL','NULL',2,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(15,1006,'Pro forma of Conveyance Deed to be signed with allottees','Project Documents','1048576','JPEG/JPG/PDF','readwriteProjectDoc',1,1,0,1,'1','Pro Forma of Conveyance or Sale Deed to be signed with the allottees at the time of registry.','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(16,1007,'Pro forma of Application Form','Project Documents','768256','JPEG/JPG/PDF','readwriteProjectDoc',1,1,0,1,'1','Pro Forma of Application Form','NULL','NULL',2,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(19,1008,'Pro forma Agreement of Sale to be signed with allottees','Project Documents','5242880','JPEG/JPG/PDF','readwriteProjectDoc',1,3,0,1,'1','Proforma of Agreement of Sale to be signed with the allottees as per the RERA Act, 2016 Annexure A. The prescribed format may be downloaded from the Forms and  Templates section under the Downloads tab of the web portal.\n','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(20,1009,'Draft Agreement of Sale highlighting the changes','Project Documents','5242880','JPEG/JPG/PDF','readwriteProjectDoc',1,2,0,1,'1','Draft Agreement of Sale highlighting the proposed changes in bold and underline where Agreement of Sale is not as per the Annexure A of RERA, Act.','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(21,1010,'Approved Layout Plan','Project Land Documents','5242880','JPEG/JPG/PDF','readwriteProjectDoc',2,1,0,5,'1','Layout Plan of the project land, approved by the competent authority clearly marking the Land Area proposed to be developed and for which RERA Registration is sought.','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(22,1011,'Land Title Search Report','Project Land Documents','5242880','JPEG/JPG/PDF','readwriteProjectDoc',2,1,0,1,'1','Land title search report of the project land from an advocate having experience of at least ten years.','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(24,1012,'Approved Project Site OR Location Map','Project Land Documents','5242880','JPEG/JPG/PDF','readwriteProjectDoc',2,1,0,1,'1','Approved Site plan or site map or location map of the project showing the location of the project land.','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(25,1013,'Sanctioned Building Plan','Project Land Documents','5242880','JPEG/JPG/PDF','readwriteProjectDoc',2,1,0,1,'1','Sanctioned builiding plan incase of building/ tower/ gorup housing/ villas development. In case of plotted development, upload the layout plan.','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(26,1014,'Details of Encumbrances over the land','Project Land Documents','5242880','JPEG/JPG/PDF','readwriteProjectDoc',2,3,0,1,'1','Upload Details of Land Encumbrances - Details of charge created on the land or building in any manner by the promoter or any other authority as on the date of application of Project Registration.','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(28,1015,'Non Encumbrance Certificate','Project Land Documents','5242880','JPEG/JPG/PDF','readwriteProjectDoc',2,2,0,1,'1','Non Encumbrance certificate from the revenue authority not below rank of Tehsildar.','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(29,1016,'Commencement Certificate (Mega Project Category)','Project Approval Details','3145728','JPEG/JPG/PDF','readwriteProjectDoc',3,1,0,1,'1','Commencement Certificate i.e. Agreement between Promoter and the concerned development authority (Mega Project Category).','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(30,1017,'Copy of Registration as Promoter','Project Approval Details','1048576','JPEG/JPG/PDF','readwriteProjectDoc',3,2,0,1,'1','Copy of Registration as Promoter issued by the competent authority.','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(31,1018,'CLU Certificate','Project Approval Details','5242880','JPEG/JPG/PDF','readwriteProjectDoc',3,2,0,5,'1','CLU Certificate for the project land proposed to be developed.','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(32,1019,'License to develop colony or society from Competent Authority','Project Approval Details','1048576','JPEG/JPG/PDF','readwriteProjectDoc',3,2,0,1,'1','Valid license or Application for the renewal of License to develop colony or society from the Competent Authority\n','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(33,1020,'Legal Title Deed(s) - In case Land is owned by Promoter','Project Land Documents','31457280','JPEG/JPG/PDF','readwriteProjectDoc',4,2,0,10,'1','Authenticated copy of the legal title deed through which land is acquired, reflecting the title of the promoter to the land on which development of project is proposed. Upload Document from Sale Deed / Gift Deed / Exchange Deed / Inheritance / Court Decree / Other.','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(36,1021,'Latest Jamabandi Document','Project Land Documents','31457280','JPEG/JPG/PDF','readwriteProjectDoc',4,2,0,5,'1','Latest jamabandi of the project land.','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(37,1022,'Consent details of actual owner of Land','Project Land Documents','5242880','JPEG/JPG/PDF','readwriteProjectDoc',4,3,0,10,'1','Upload - Consent Details of Land Owner in case land is not owned by promoter','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(40,1023,'Collaboration or Joint Development Agreement','Project Land Documents','5242880','JPEG/JPG/PDF','readwriteProjectDoc',4,3,0,10,'1','Copy of collaboration agreement, development agreement, joint development agreement or any other agreement entered between promoter and actual land owner(s) in case land is not owned by promoter.','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(42,1024,'Land Title Deed(s) - In case land is not owned by Promoter','Project Land Documents','31457280','JPEG/JPG/PDF','readwriteProjectDoc',4,3,0,10,'1','Legal title deed of the original owner(s) of the part of the project land not owned by promoter.','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(44,1025,'Architects Certificate (Form 1)','Project Documents','1048576','PDF','readwriteProjectDoc',5,2,0,1,'1','Architect\'s Certificate as per the Form 1 of the RERA Punjab General Regulations. The prescribed format may be downloaded from the Forms & Templates section under the Downloads tab of the web portal.','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(45,1026,'Engineers Certificate (Form 2)','Project Documents','1048576','PDF','readwriteProjectDoc',5,2,0,1,'1','Engineer\'s Certificate as per the Form 2 of the RERA Punjab General Regulations. The prescribed format may be downloaded from the Forms and Templates section under the Downloads tab of the web portal.','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(46,1027,'CA Certificate (Form 3)','Project Documents','1048576','PDF','readwriteProjectDoc',5,1,0,1,'1','CA Certificate as per the Form 3 of the RERA Punjab General Regulations. The prescribed format may be downloaded from the Forms and Templates section under the Downloads tab of the web portal.\n','NULL','NULL',1,'systemdb','2024-11-17 13:08:00.000','systemdb','2024-11-17 13:08:00.000'),(47,1028,'Project Land Khasra Report or Plan','Project Land Documents','1048576','PDF','readwriteProjectDoc',5,1,0,5,'1','Khasra details of the project land consisting of a) Khasra Number b) Area of land proposed to be developed under the khasra no. c) Name of the village under the khasra no.  d) ownership status-Not Owned By Promoter/Owned By Promoter.',NULL,NULL,1,'sysadmin','2018-11-17 13:08:00.000','sysadmin','2018-11-17 13:08:00.000'),(48,1029,'Declaration for AFS, CD and Allottment Letter','Project Approvals','1048576','PDF','readwriteProjectDoc',5,1,0,1,'1','Declaration stating that the clauses mentioned in Conveyance Deed and Allottment Letter are in conformity with the Agreement of Sale. ',NULL,NULL,1,'sysadmin','2018-11-17 13:08:00.000','sysadmin','2018-11-17 13:08:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_project_documents_bakup20220406` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:27
