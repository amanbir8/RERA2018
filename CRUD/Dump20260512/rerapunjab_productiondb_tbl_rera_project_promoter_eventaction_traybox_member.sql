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
-- Table structure for table `tbl_rera_project_promoter_eventaction_traybox_member`
--

DROP TABLE IF EXISTS `tbl_rera_project_promoter_eventaction_traybox_member`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_project_promoter_eventaction_traybox_member` (
  `ProjectMemberSubEventAction_ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `EventAction_Type` bigint(20) NOT NULL,
  `SubEventAction_Type` bigint(20) NOT NULL,
  `EventAction_Branch` varchar(90) NOT NULL,
  `EventAction_BranchGroup` varchar(90) NOT NULL,
  `EventCycle_SequenceID` int(11) NOT NULL,
  `EventCycle_SequenceFlag` varchar(50) NOT NULL,
  `SubEvent_IdentifiedBy` varchar(50) NOT NULL,
  `SubEvent_IdentifiedOn` datetime(3) NOT NULL,
  `Related_Promoter_ID` bigint(20) NOT NULL,
  `Related_Project_ID` bigint(20) NOT NULL,
  `Promoter_DiaryNumber` varchar(50) NOT NULL,
  `Project_DiaryNumber` varchar(50) NOT NULL,
  `SubEvent_Summary` varchar(200) NOT NULL,
  `SubEvent_Description` varchar(300) NOT NULL,
  `SubEvent_Category` varchar(150) NOT NULL,
  `SubEvent_Aggregate` varchar(200) NOT NULL,
  `SubEvent_Relationship` varchar(50) NOT NULL,
  `IsCP` int(11) NOT NULL,
  `IsMO` int(11) NOT NULL,
  `IsMT` int(11) NOT NULL,
  `IsAL` int(11) NOT NULL,
  `IsOR` int(11) NOT NULL,
  `IsAcceptedStatus` varchar(50) NOT NULL,
  `AssignedTo` varchar(50) NOT NULL,
  `Target_ResolutionDate` datetime(3) NOT NULL,
  `Actual_ResolutionDate` datetime(3) NOT NULL,
  `IsBefore_TargetResolution` int(11) NOT NULL,
  `Remarks_IfAny` varchar(500) DEFAULT NULL,
  `A_column` varchar(90) DEFAULT NULL,
  `B_column` varchar(90) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ProjectMemberSubEventAction_ID`),
  KEY `tbl_rera_project_promoter_eventaction_traybox_member` (`ProjectMemberSubEventAction_ID`,`EventAction_Type`,`SubEventAction_Type`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_project_promoter_eventaction_traybox_member`
--

LOCK TABLES `tbl_rera_project_promoter_eventaction_traybox_member` WRITE;
/*!40000 ALTER TABLE `tbl_rera_project_promoter_eventaction_traybox_member` DISABLE KEYS */;
INSERT INTO `tbl_rera_project_promoter_eventaction_traybox_member` VALUES (8,110051,0,'ACLP','MO',1,'Open','member.rera','2026-04-28 12:20:48.000',3581,12665,'NA','PRJ2026FZL0066','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,1,0,1,1,'NA',' ','2026-04-28 12:20:48.000','2026-04-28 12:20:48.000',0,NULL,NULL,NULL,2,0,'member.rera','2026-04-28 12:20:48.000','member.rera','2026-04-28 12:20:48.000'),(9,110051,0,'ACLP','MO',1,'Open','member.rera','2026-04-28 12:21:27.000',3586,12671,'NA','PRJ2026SGR0058','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,1,0,1,1,'NA',' ','2026-04-28 12:21:27.000','2026-04-28 12:21:27.000',0,NULL,NULL,NULL,2,0,'member.rera','2026-04-28 12:21:27.000','member.rera','2026-04-28 12:21:27.000'),(10,110051,0,'ACLP','CP',1,'Close','chairperson','2026-04-28 21:00:50.000',3581,12665,'NA','PRJ2026FZL0066','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',1,1,0,1,1,'NA',' ','2026-04-28 21:00:50.000','2026-04-28 21:00:50.000',0,NULL,NULL,NULL,1,0,'chairperson','2026-04-28 21:00:50.000','chairperson','2026-04-28 21:00:50.000'),(11,110051,0,'ACLP','CP',1,'Close','chairperson','2026-04-28 21:01:20.000',3586,12671,'NA','PRJ2026SGR0058','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',1,1,0,1,1,'NA',' ','2026-04-28 21:01:20.000','2026-04-28 21:01:20.000',0,NULL,NULL,NULL,1,0,'chairperson','2026-04-28 21:01:20.000','chairperson','2026-04-28 21:01:20.000');
/*!40000 ALTER TABLE `tbl_rera_project_promoter_eventaction_traybox_member` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:44
