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
-- Table structure for table `tbl_rera_master_promoter_documents`
--

DROP TABLE IF EXISTS `tbl_rera_master_promoter_documents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_promoter_documents` (
  `PromoterDocMaster_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `PromoterDocMaster_InfoCode` int(11) NOT NULL,
  `PromoterDocMaster_InfoName` varchar(90) NOT NULL,
  `PromoterDoc_SetFileSize` varchar(50) NOT NULL,
  `PromoterDoc_SetFileFormat` varchar(50) NOT NULL,
  `PromoterDoc_SetFilePath` varchar(250) NOT NULL,
  `PromoterDoc_ValidCode` int(11) NOT NULL,
  `PromoterDoc_ValidSubCode` int(11) NOT NULL,
  `PromoterDoc_ValidTinySubCode` int(11) NOT NULL,
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
  PRIMARY KEY (`PromoterDocMaster_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_promoter_documents`
--

LOCK TABLES `tbl_rera_master_promoter_documents` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_promoter_documents` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_promoter_documents` VALUES (1,101,'PAN Card (Individual)','1048576','JPEG/JPG/PDF','readwritePromoter',1,1,0,1,'1','Promoter\'s PAN card copy','NULL','NULL',1,'systemdb','2018-11-17 13:08:00.000','systemdb','2018-11-17 13:08:00.000'),(2,102,'Audited P n L','6291456','JPEG/JPG/PDF','readwritePromoter',2,2,0,3,'1','Annual Audited Profit and Loss Statement for last 3 Financial Years or since Inception.  Please upload Audited Profit and Loss statement for each of the three Financial Years separately\r.','NULL','NULL',1,'systemdb','2018-11-17 13:08:00.000','systemdb','2018-11-17 13:08:00.000'),(3,103,'Balance Sheet','6291456','JPEG/JPG/PDF','readwritePromoter',2,2,0,3,'1','Annual Balance Sheet for last 3 Financial Years or since Inception. Please upload Balance Sheet for each of the three Financial Years separately.\r ','NULL','NULL',1,'systemdb','2018-11-17 13:08:00.000','systemdb','2018-11-17 13:08:00.000'),(4,104,'Income Tax Returns','3145728','JPEG/JPG/PDF','readwritePromoter',1,1,0,3,'1','Income Tax returns for the last 3 Financial Years. Please upload the returns for each of the three Financial Years separately.','NULL','NULL',1,'systemdb','2018-11-17 13:08:00.000','systemdb','2018-11-17 13:08:00.000'),(5,105,'Company Registration Certificate or Partership Deed','1048576','JPEG/JPG/PDF','readwritePromoter',2,1,0,1,'1','Company Registration Certificate or Partership Deed/ Memorundum of Association/ Article of Association of the promoter\'s organisation.','NULL','NULL',1,'systemdb','2018-11-17 13:08:00.000','systemdb','2018-11-17 13:08:00.000'),(11,106,'Cash Flow Statements','6291456','JPEG/JPG/PDF','readwritePromoter',2,2,0,3,'1','Annual Cash Flow Statement for last 3 Financial Years or since Inception. Please upload Cash Flow Statement for each of the three Financial Years separately.\r','NULL','NULL',1,'systemdb','2018-11-17 13:08:00.000','systemdb','2018-11-17 13:08:00.000'),(12,107,'Directors Report','15728640','JPEG/JPG/PDF','readwritePromoter',2,1,0,3,'1','Annual Directors report for last 3 Financial Years or since Inception.  Only the first page of the director\'s report and the pages showing the balance sheet, profit & loss statement and cash flow statemement in the report need to be uploaded. Please upload directors reports for each of the three Financial Years separately.','NULL','NULL',1,'systemdb','2018-11-17 13:08:00.000','systemdb','2018-11-17 13:08:00.000'),(14,108,'Auditors Report','15728640','JPEG/JPG/PDF','readwritePromoter',2,1,0,3,'1','Annual Auditor report for last 3 Financial Years or since Inception. Only the first page of the auditor report and the pages showing the balance sheet, profit & loss statement and cash flow statemement in the report need to be uploaded.Please upload auditor reports for each of the three Financial Years separately.','NULL','NULL',1,'systemdb','2018-11-17 13:08:00.000','systemdb','2018-11-17 13:08:00.000'),(16,109,'Annual Report','15728640','JPEG/JPG/PDF','readwritePromoter',2,3,0,3,'1','Annual Reports for last 3 Financial Years or since Inception. Only the first page of the annual report and the pages showing the balance sheet, profit & loss statement and cash flow statemement in the report need to be uploaded. Please upload annual reports for each of the three Financial Years separately.','NULL','NULL',1,'systemdb','2018-11-17 13:08:00.000','systemdb','2018-11-17 13:08:00.000'),(18,110,'PAN Card (Organization)','1048576','JPEG/JPG/PDF','readwritePromoter',2,1,0,1,'1','PAN card of the promoter\'s organisation','NULL','NULL',1,'systemdb','2018-11-17 13:08:00.000','systemdb','2018-11-17 13:08:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_promoter_documents` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:25
