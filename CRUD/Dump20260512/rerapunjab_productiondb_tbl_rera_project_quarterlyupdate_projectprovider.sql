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
-- Table structure for table `tbl_rera_project_quarterlyupdate_projectprovider`
--

DROP TABLE IF EXISTS `tbl_rera_project_quarterlyupdate_projectprovider`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_project_quarterlyupdate_projectprovider` (
  `QUP_ProjectProvider_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `QUP_ProjectProvider_ID` bigint(20) NOT NULL,
  `QUpdateProject_Year` int(11) NOT NULL,
  `QUpdateProject_QuarterName` varchar(100) NOT NULL,
  `UserID` varchar(50) NOT NULL,
  `PromoterID` bigint(20) NOT NULL,
  `ProjectID` bigint(20) NOT NULL,
  `RERA_RegistrationID` varchar(150) NOT NULL,
  `DiaryNumber_Project` varchar(150) DEFAULT NULL,
  `DiaryNumber_ExtensionProject` varchar(150) DEFAULT NULL,
  `ReferenceNumber` varchar(150) DEFAULT NULL,
  `ReferenceDate` datetime(3) NOT NULL,
  `Remarks_IfAny` varchar(250) DEFAULT NULL,
  `Locked_From_Date` datetime(3) NOT NULL,
  `Locked_To_Date` datetime(3) NOT NULL,
  `A_column` varchar(50) DEFAULT NULL,
  `B_column` varchar(50) DEFAULT NULL,
  `C_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsDraftSecMember` int(11) NOT NULL,
  `IsDraftMember` int(11) NOT NULL,
  `IsActiveProvider` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`QUP_ProjectProvider_IndexID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_project_quarterlyupdate_projectprovider`
--

LOCK TABLES `tbl_rera_project_quarterlyupdate_projectprovider` WRITE;
/*!40000 ALTER TABLE `tbl_rera_project_quarterlyupdate_projectprovider` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_project_quarterlyupdate_projectprovider` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:51
