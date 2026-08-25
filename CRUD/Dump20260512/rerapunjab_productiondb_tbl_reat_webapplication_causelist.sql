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
-- Table structure for table `tbl_reat_webapplication_causelist`
--

DROP TABLE IF EXISTS `tbl_reat_webapplication_causelist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_reat_webapplication_causelist` (
  `CauseList_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `CauseList_ID` bigint(20) DEFAULT NULL,
  `SerialOrderNumber` int(11) DEFAULT NULL,
  `ComplaintApplicationNumberKey1` varchar(100) DEFAULT NULL,
  `ComplaintApplicationNumberKey2` varchar(100) DEFAULT NULL,
  `ComplaintApplicationNumberKey3` varchar(100) DEFAULT NULL,
  `ComplaintApplicationNumberKey4` varchar(100) DEFAULT NULL,
  `ComplaintApplicationNumber` varchar(100) DEFAULT NULL,
  `Date_of_HearingWithDayTime` datetime(3) DEFAULT NULL,
  `Date_of_HearingDate` datetime(3) DEFAULT NULL,
  `Date_of_HearingDay` varchar(50) DEFAULT NULL,
  `Date_of_HearingTime` varchar(50) DEFAULT NULL,
  `Business_on_Date` datetime(3) DEFAULT NULL,
  `ComplainantName` varchar(250) DEFAULT NULL,
  `RespondentName` varchar(250) DEFAULT NULL,
  `FixedForCode` varchar(250) DEFAULT NULL,
  `FixedForName` varchar(250) DEFAULT NULL,
  `Court_UnderSectionName` varchar(50) DEFAULT NULL,
  `Court_UnderSectionCode` varchar(50) DEFAULT NULL,
  `CauseList_BaseUrl` varchar(250) DEFAULT NULL,
  `CauseList_FilePath` varchar(250) DEFAULT NULL,
  `CauseList_FileName` varchar(250) DEFAULT NULL,
  `CauseList_FileType` varchar(50) DEFAULT NULL,
  `Related_CauseList_FileSize` varchar(50) DEFAULT NULL,
  `Bench_Name` varchar(150) DEFAULT NULL,
  `Bench_Code` varchar(100) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `IsDraft` int(11) DEFAULT NULL,
  `IsDraftMember` int(11) DEFAULT NULL,
  `IsDocumentValid` int(11) DEFAULT NULL,
  `IsPublicView` int(11) DEFAULT NULL,
  `CounterCycleNumber` bigint(20) DEFAULT NULL,
  `isSineDie` int(11) DEFAULT NULL,
  `isTransferOrder` int(11) DEFAULT NULL,
  `isBifurcateOrder` int(11) DEFAULT NULL,
  `isReOpen` int(11) DEFAULT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `CreatedOn` datetime(3) DEFAULT NULL,
  `ModifyBy` varchar(50) DEFAULT NULL,
  `ModifyOn` datetime(3) DEFAULT NULL,
  `RemarksIfAny` varchar(50) DEFAULT NULL,
  `EventAction_Type` varchar(50) DEFAULT NULL,
  `EventAction_TypeName` varchar(150) DEFAULT NULL,
  `EventAction_IdentifiedOn` datetime(3) DEFAULT NULL,
  `EventAction_Aggregate` varchar(250) DEFAULT NULL,
  `EventRemarks_IfAny` varchar(250) DEFAULT NULL,
  `EventAction_Summary` varchar(250) DEFAULT NULL,
  `PreHearingBench_ID` int(11) DEFAULT NULL,
  `AppealNumber` varchar(100) DEFAULT NULL,
  `ReferenceNumber` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`CauseList_IndexID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_reat_webapplication_causelist`
--

LOCK TABLES `tbl_reat_webapplication_causelist` WRITE;
/*!40000 ALTER TABLE `tbl_reat_webapplication_causelist` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_reat_webapplication_causelist` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:15
