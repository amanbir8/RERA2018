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
-- Table structure for table `tbl_rera_authdesk_agent_eventaction_traybox_member`
--

DROP TABLE IF EXISTS `tbl_rera_authdesk_agent_eventaction_traybox_member`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_authdesk_agent_eventaction_traybox_member` (
  `AgentMemberSubEventAction_ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `EventAction_Type` bigint(20) NOT NULL,
  `SubEventAction_Type` bigint(20) NOT NULL,
  `EventAction_Branch` varchar(90) NOT NULL,
  `EventAction_BranchGroup` varchar(90) NOT NULL,
  `EventCycle_SequenceID` int(11) NOT NULL,
  `EventCycle_SequenceFlag` varchar(50) NOT NULL,
  `SubEvent_IdentifiedBy` varchar(50) NOT NULL,
  `SubEvent_IdentifiedOn` datetime(3) NOT NULL,
  `Related_User_ID` varchar(100) NOT NULL,
  `Related_Agent_ID` bigint(20) NOT NULL,
  `Promoter_DiaryNumber` varchar(50) NOT NULL,
  `Agent_DiaryNumber` varchar(50) NOT NULL,
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
  PRIMARY KEY (`AgentMemberSubEventAction_ID`),
  KEY `tbl_rera_authdesk_agent_eventaction_traybox_member` (`AgentMemberSubEventAction_ID`,`Related_Agent_ID`,`EventAction_Type`,`SubEventAction_Type`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_authdesk_agent_eventaction_traybox_member`
--

LOCK TABLES `tbl_rera_authdesk_agent_eventaction_traybox_member` WRITE;
/*!40000 ALTER TABLE `tbl_rera_authdesk_agent_eventaction_traybox_member` DISABLE KEYS */;
INSERT INTO `tbl_rera_authdesk_agent_eventaction_traybox_member` VALUES (5,220011,0,'ACLP','AL',1,'Open','secyrera','2026-05-08 11:37:16.000','0',10995,'NA','REA20260202','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,0,1,1,'NA',' ','2026-05-08 11:37:16.000','2026-05-08 11:37:16.000',0,NULL,NULL,NULL,1,0,'secyrera','2026-05-08 11:37:16.000','secyrera','2026-05-08 11:37:16.000'),(6,220011,0,'ACLP','AL',1,'Open','secyrera','2026-05-08 11:37:43.000','0',11073,'NA','REA20260175','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,0,1,1,'NA',' ','2026-05-08 11:37:43.000','2026-05-08 11:37:43.000',0,NULL,NULL,NULL,1,0,'secyrera','2026-05-08 11:37:43.000','secyrera','2026-05-08 11:37:43.000'),(7,220011,0,'ACLP','AL',1,'Open','secyrera','2026-05-08 11:39:45.000','0',10852,'NA','REA20260055','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,0,1,1,'NA',' ','2026-05-08 11:39:45.000','2026-05-08 11:39:45.000',0,NULL,NULL,NULL,1,0,'secyrera','2026-05-08 11:39:45.000','secyrera','2026-05-08 11:39:45.000'),(8,220011,0,'ACLP','AL',1,'Open','secyrera','2026-05-08 11:40:22.000','0',11104,'NA','REA20260190','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,0,1,1,'NA',' ','2026-05-08 11:40:22.000','2026-05-08 11:40:22.000',0,NULL,NULL,NULL,1,0,'secyrera','2026-05-08 11:40:22.000','secyrera','2026-05-08 11:40:22.000'),(9,220011,0,'ACLP','AL',1,'Open','secyrera','2026-05-08 11:41:32.000','0',11043,'NA','REA20260158','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,0,1,1,'NA',' ','2026-05-08 11:41:32.000','2026-05-08 11:41:32.000',0,NULL,NULL,NULL,1,0,'secyrera','2026-05-08 11:41:32.000','secyrera','2026-05-08 11:41:32.000'),(10,220011,0,'ACLP','AL',1,'Open','secyrera','2026-05-08 11:42:23.000','0',11093,'NA','REA20260200','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,0,1,1,'NA',' ','2026-05-08 11:42:23.000','2026-05-08 11:42:23.000',0,NULL,NULL,NULL,1,0,'secyrera','2026-05-08 11:42:23.000','secyrera','2026-05-08 11:42:23.000'),(11,220011,0,'ACLP','AL',1,'Open','secyrera','2026-05-08 11:42:36.000','0',11002,'NA','REA20260196','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,0,1,1,'NA',' ','2026-05-08 11:42:36.000','2026-05-08 11:42:36.000',0,NULL,NULL,NULL,1,0,'secyrera','2026-05-08 11:42:36.000','secyrera','2026-05-08 11:42:36.000'),(12,220011,0,'ACLP','AL',1,'Open','secyrera','2026-05-08 11:42:55.000','0',11071,'NA','REA20260171','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,0,1,1,'NA',' ','2026-05-08 11:42:55.000','2026-05-08 11:42:55.000',0,NULL,NULL,NULL,1,0,'secyrera','2026-05-08 11:42:55.000','secyrera','2026-05-08 11:42:55.000'),(13,220011,0,'ACLP','AL',1,'Open','secyrera','2026-05-08 11:43:33.000','0',10876,'NA','REA20260064','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,0,1,1,'NA',' ','2026-05-08 11:43:33.000','2026-05-08 11:43:33.000',0,NULL,NULL,NULL,1,0,'secyrera','2026-05-08 11:43:33.000','secyrera','2026-05-08 11:43:33.000'),(14,220011,0,'ACLP','AL',1,'Open','secyrera','2026-05-08 11:43:45.000','0',10987,'NA','REA20260201','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,0,1,1,'NA',' ','2026-05-08 11:43:45.000','2026-05-08 11:43:45.000',0,NULL,NULL,NULL,1,0,'secyrera','2026-05-08 11:43:45.000','secyrera','2026-05-08 11:43:45.000'),(15,220011,0,'ACLP','AL',1,'Open','secyrera','2026-05-08 11:43:54.000','0',10719,'NA','REA20260191','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,0,1,1,'NA',' ','2026-05-08 11:43:54.000','2026-05-08 11:43:54.000',0,NULL,NULL,NULL,1,0,'secyrera','2026-05-08 11:43:54.000','secyrera','2026-05-08 11:43:54.000'),(16,220011,0,'ACLP','AL',1,'Open','secyrera','2026-05-08 11:44:15.000','0',10992,'NA','REA20260121','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,0,1,1,'NA',' ','2026-05-08 11:44:15.000','2026-05-08 11:44:15.000',0,NULL,NULL,NULL,1,0,'secyrera','2026-05-08 11:44:15.000','secyrera','2026-05-08 11:44:15.000'),(17,220011,0,'ACLP','AL',1,'Open','secyrera','2026-05-08 11:44:27.000','0',11145,'NA','REA20260217','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,0,1,1,'NA',' ','2026-05-08 11:44:27.000','2026-05-08 11:44:27.000',0,NULL,NULL,NULL,1,0,'secyrera','2026-05-08 11:44:27.000','secyrera','2026-05-08 11:44:27.000'),(18,220011,0,'ACLP','AL',1,'Open','secyrera','2026-05-08 11:44:40.000','0',11078,'NA','REA20260174','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,0,1,1,'NA',' ','2026-05-08 11:44:40.000','2026-05-08 11:44:40.000',0,NULL,NULL,NULL,1,0,'secyrera','2026-05-08 11:44:40.000','secyrera','2026-05-08 11:44:40.000'),(19,220011,0,'ACLP','AL',1,'Open','secyrera','2026-05-08 11:45:00.000','0',10979,'NA','REA20260126','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,0,1,1,'NA',' ','2026-05-08 11:45:00.000','2026-05-08 11:45:00.000',0,NULL,NULL,NULL,1,0,'secyrera','2026-05-08 11:45:00.000','secyrera','2026-05-08 11:45:00.000'),(20,220011,0,'ACLP','AL',1,'Open','secyrera','2026-05-08 11:45:16.000','0',11139,'NA','REA20260210','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,0,1,1,'NA',' ','2026-05-08 11:45:16.000','2026-05-08 11:45:16.000',0,NULL,NULL,NULL,1,0,'secyrera','2026-05-08 11:45:16.000','secyrera','2026-05-08 11:45:16.000'),(21,220011,0,'ACLP','AL',1,'Open','secyrera','2026-05-08 11:45:29.000','0',11012,'NA','REA20260187','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,0,1,1,'NA',' ','2026-05-08 11:45:29.000','2026-05-08 11:45:29.000',0,NULL,NULL,NULL,2,0,'secyrera','2026-05-08 11:45:29.000','secyrera','2026-05-08 11:45:29.000'),(22,220011,0,'ACLP','AL',1,'Open','secyrera','2026-05-08 11:45:43.000','0',11113,'NA','REA20260194','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,0,1,1,'NA',' ','2026-05-08 11:45:43.000','2026-05-08 11:45:43.000',0,NULL,NULL,NULL,2,0,'secyrera','2026-05-08 11:45:43.000','secyrera','2026-05-08 11:45:43.000'),(23,220011,0,'ACLP','AL',1,'Open','secyrera','2026-05-08 11:46:33.000','0',11115,'NA','REA20260203','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,0,1,1,'NA',' ','2026-05-08 11:46:33.000','2026-05-08 11:46:33.000',0,NULL,NULL,NULL,2,0,'secyrera','2026-05-08 11:46:33.000','secyrera','2026-05-08 11:46:33.000'),(24,220051,0,'ACLP','MT',1,'Open','member1.rera','2026-05-08 16:21:27.000','0',11115,'NA','REA20260203','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,1,1,1,'NA',' ','2026-05-08 16:21:27.000','2026-05-08 16:21:27.000',0,NULL,NULL,NULL,1,0,'member1.rera','2026-05-08 16:21:27.000','member1.rera','2026-05-08 16:21:27.000'),(25,220051,0,'ACLP','MT',1,'Open','member1.rera','2026-05-08 16:21:38.000','0',11081,'NA','REA20260192','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,1,1,1,'NA',' ','2026-05-08 16:21:38.000','2026-05-08 16:21:38.000',0,NULL,NULL,NULL,1,0,'member1.rera','2026-05-08 16:21:38.000','member1.rera','2026-05-08 16:21:38.000'),(26,220051,0,'ACLP','MT',1,'Open','member1.rera','2026-05-08 16:21:50.000','0',11113,'NA','REA20260194','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,1,1,1,'NA',' ','2026-05-08 16:21:50.000','2026-05-08 16:21:50.000',0,NULL,NULL,NULL,1,0,'member1.rera','2026-05-08 16:21:50.000','member1.rera','2026-05-08 16:21:50.000'),(27,220051,0,'ACLP','MT',1,'Open','member1.rera','2026-05-08 16:22:00.000','0',11012,'NA','REA20260187','NA','NA','Authority Desk','ACLP','15ac7786-a35e-46a3-ae19-8befd003dcfd',0,0,1,1,1,'NA',' ','2026-05-08 16:22:00.000','2026-05-08 16:22:00.000',0,NULL,NULL,NULL,1,0,'member1.rera','2026-05-08 16:22:00.000','member1.rera','2026-05-08 16:22:00.000');
/*!40000 ALTER TABLE `tbl_rera_authdesk_agent_eventaction_traybox_member` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:27
