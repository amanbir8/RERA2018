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
-- Table structure for table `tbl_rera_acr_promoter_changerequest_historylogs`
--

DROP TABLE IF EXISTS `tbl_rera_acr_promoter_changerequest_historylogs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_acr_promoter_changerequest_historylogs` (
  `PromoterACR_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `PromoterACR_ID` bigint(20) NOT NULL,
  `Related_ProjectRegistration_ID` bigint(20) NOT NULL,
  `Related_PromoterApplication_ID` bigint(20) NOT NULL,
  `Related_ProjectDiaryNumber` varchar(80) NOT NULL,
  `Related_PromoterDiaryNumber` varchar(80) NOT NULL,
  `Related_Project_RERAnumber` varchar(100) NOT NULL,
  `ACR_ReferenceNumber` varchar(150) NOT NULL,
  `ACR_ApplicationDate` datetime(3) NOT NULL,
  `ACR_ApprovedDate` datetime(3) NOT NULL,
  `ACR_IdentifiedBy` varchar(150) NOT NULL,
  `ACR_Name` varchar(150) NOT NULL,
  `ACR_CategoryName` varchar(150) NOT NULL,
  `ACR_Code` varchar(150) NOT NULL,
  `ACR_RelatedTableName` varchar(200) NOT NULL,
  `ACR_PreviousRelatedCode` varchar(120) NOT NULL,
  `ACR_PresentRelatedCode` varchar(120) NOT NULL,
  `ACR_Status` varchar(150) NOT NULL,
  `Remarks_IfAny` varchar(300) DEFAULT NULL,
  `A_column` varchar(50) DEFAULT NULL,
  `B_column` varchar(50) DEFAULT NULL,
  `C_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`PromoterACR_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=109 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_acr_promoter_changerequest_historylogs`
--

LOCK TABLES `tbl_rera_acr_promoter_changerequest_historylogs` WRITE;
/*!40000 ALTER TABLE `tbl_rera_acr_promoter_changerequest_historylogs` DISABLE KEYS */;
INSERT INTO `tbl_rera_acr_promoter_changerequest_historylogs` VALUES (107,1001,10880,1740,'PRJ2019SAS1701','A','PBRERA-SAS80-PR0494','ByEmail','2020-08-24 00:00:00.000','2020-08-24 00:00:00.000','sysadmin','Change of Authorized Signatory of the promoter and Registered Address of the promoter','Authorized Signatory and Promoter Address Change Request','999','Rera_Tbl_Promoter','1647','2522','Updated','updated the authrorized person details in promoter profile as Name, Email ID and Mobile Number and Address of Promoter.','2',NULL,NULL,1,1,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000'),(108,1002,10880,1740,'PRJ2019SAS1701','A','PBRERA-SAS80-PR0494','ByEmail','2020-08-24 00:00:00.000','2020-08-24 00:00:00.000','sysadmin','Removal of Organization Member of the promoter','Organization Member Removal Request','999','Tbl_Rera_Promoter_OtherMemberDetails','1868','0','Updated','updated the flag of organization member of the promoter.','1',NULL,NULL,1,1,'sysadmin','2020-08-28 00:00:00.000','sysadmin','2020-08-28 00:00:00.000');
/*!40000 ALTER TABLE `tbl_rera_acr_promoter_changerequest_historylogs` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:53
