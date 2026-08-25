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
-- Table structure for table `tbl_rera_project_stampapproval_details`
--

DROP TABLE IF EXISTS `tbl_rera_project_stampapproval_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_project_stampapproval_details` (
  `Stamp_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `Stamp_ID` bigint(20) NOT NULL,
  `Stamp_IdentifiedBy` varchar(50) NOT NULL,
  `Stamp_IdentifiedOn` datetime(3) NOT NULL,
  `Stamp_LockoutEndDate` datetime(3) DEFAULT NULL,
  `ApprovalStamp_Code` int(11) NOT NULL,
  `ApprovalStamp_Name` varchar(200) NOT NULL,
  `ApprovalStamp_Head` varchar(100) DEFAULT NULL,
  `ApprovalStamp_AuthorityCount` int(11) NOT NULL,
  `ApprovalStamp_ApprovalCount` int(11) NOT NULL,
  `Stamp_Category` varchar(150) NOT NULL,
  `Stamp_Aggregate` varchar(250) NOT NULL,
  `Stamp_Description` varchar(500) NOT NULL,
  `CP_UserId` varchar(200) NOT NULL,
  `CP_UserName` varchar(256) NOT NULL,
  `CP_StampProfile_ID` bigint(20) NOT NULL,
  `CP_LockoutEnabled` tinyint(1) NOT NULL,
  `CP_LockoutEndDate` datetime(3) DEFAULT NULL,
  `MF_UserId` varchar(200) NOT NULL,
  `MF_UserName` varchar(256) NOT NULL,
  `MF_StampProfile_ID` bigint(20) NOT NULL,
  `MF_LockoutEnabled` tinyint(1) NOT NULL,
  `MF_LockoutEndDate` datetime(3) DEFAULT NULL,
  `MS_UserId` varchar(200) NOT NULL,
  `MS_UserName` varchar(256) NOT NULL,
  `MS_StampProfile_ID` bigint(20) NOT NULL,
  `MS_LockoutEnabled` tinyint(1) NOT NULL,
  `MS_LockoutEndDate` datetime(3) DEFAULT NULL,
  `TieVote_UserId` varchar(200) NOT NULL,
  `TieVote_UserName` varchar(256) NOT NULL,
  `TieVote_StampProfile_ID` bigint(20) NOT NULL,
  `TieVote_LockoutEnabled` tinyint(1) NOT NULL,
  `TieVote_LockoutEndDate` datetime(3) DEFAULT NULL,
  `Remarks_IfAny` varchar(500) DEFAULT NULL,
  `A_column` varchar(150) DEFAULT NULL,
  `B_column` varchar(150) DEFAULT NULL,
  `C_column` varchar(150) DEFAULT NULL,
  `D_column` varchar(150) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `IsCondition` int(11) NOT NULL,
  `IsApproved` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`Stamp_IndexID`),
  KEY `index_tbl_rera_project_stampapproval_details` (`Stamp_ID`,`ApprovalStamp_Code`,`ApprovalStamp_ApprovalCount`)
) ENGINE=InnoDB AUTO_INCREMENT=109 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_project_stampapproval_details`
--

LOCK TABLES `tbl_rera_project_stampapproval_details` WRITE;
/*!40000 ALTER TABLE `tbl_rera_project_stampapproval_details` DISABLE KEYS */;
INSERT INTO `tbl_rera_project_stampapproval_details` VALUES (101,5001,'sysadmin','2017-08-01 00:00:00.000','2019-10-24 12:27:07.000',1,'Application Accepted for Project Approval','Project',3,2,'NA','','','59de6ff4-4575-4181-8620-470fc796d929','chairperson',1001,1,'0001-01-01 00:00:00.000','6a71dec8-8967-46b1-96c9-04d29609ed0e','membersg',1002,1,'0001-01-01 00:00:00.000','8d9c6328-e164-40c4-9547-45c7c90138a9','memberjsk',1003,1,'0001-01-01 00:00:00.000','0','0',0,0,'0001-01-01 00:00:00.000',NULL,NULL,NULL,NULL,NULL,1,1,1,1,0,2,'sysadmin','2024-12-27 11:21:13.000','sysadmin','2024-12-27 11:21:13.000'),(102,5002,'admprogrammer.rera','2019-11-01 00:00:00.000','2020-07-31 00:00:00.000',1,'Application Accepted for Project Approval','Project',2,1,'VirtualVote','','','59de6ff4-4575-4181-8620-470fc796d929','chairperson',1001,1,'0001-01-01 00:00:00.000','6a71dec8-8967-46b1-96c9-04d29609ed0e','membersg',1002,1,'0001-01-01 00:00:00.000','0','0',0,0,'0001-01-01 00:00:00.000','59de6ff4-4575-4181-8620-470fc796d929','chairperson',1001,1,'0001-01-01 00:00:00.000',NULL,NULL,NULL,NULL,NULL,1,1,1,1,0,2,'sysadmin','2024-12-27 11:21:13.000','sysadmin','2024-12-27 11:21:13.000'),(103,5003,'NA','2024-09-16 00:00:00.000','2024-09-16 00:00:00.000',1,'Application Accepted for Project Approval','Project',1,1,'NA','','','1','1',1,1,'0001-01-01 00:00:00.000','1','1',1,1,'0001-01-01 00:00:00.000','1','1',1,1,'0001-01-01 00:00:00.000','1','1',1,1,'0001-01-01 00:00:00.000',NULL,NULL,NULL,NULL,NULL,1,1,1,0,0,2,'sysadmin','2024-12-27 11:21:13.000','sysadmin','2024-12-27 11:21:13.000'),(104,5004,'NA','2024-09-16 00:00:00.000','2024-09-16 00:00:00.000',1,'Application Accepted for Project Approval','Project',2,1,'VirtualVote','','','1','1',1,1,'0001-01-01 00:00:00.000','1','1',1,1,'0001-01-01 00:00:00.000','1','1',1,1,'0001-01-01 00:00:00.000','1','1',1,1,'0001-01-01 00:00:00.000',NULL,NULL,NULL,NULL,NULL,1,1,1,0,0,2,'sysadmin','2024-12-27 11:21:13.000','sysadmin','2024-12-27 11:21:13.000'),(105,5005,'NA','2024-09-16 00:00:00.000','2024-09-16 00:00:00.000',1,'Application Accepted for Project Approval','Project',3,1,'NA','','','1','1',1,1,'0001-01-01 00:00:00.000','1','1',1,1,'0001-01-01 00:00:00.000','1','1',1,1,'0001-01-01 00:00:00.000','1','1',1,1,'0001-01-01 00:00:00.000',NULL,NULL,NULL,NULL,NULL,1,1,1,0,0,2,'sysadmin','2024-12-27 11:21:13.000','sysadmin','2024-12-27 11:21:13.000'),(106,5006,'admprogrammer.rera','2022-12-01 00:00:00.000','2024-02-07 00:00:00.000',1,'Application Accepted for Project Approval','Project',3,2,'NA','','','59de6ff4-4575-4181-8620-470fc796d929','chairperson',1005,1,'0001-01-01 00:00:00.000','97148e6d-64f5-490b-98cc-94767e9f36f7','memberaps.rera',1004,1,'0001-01-01 00:00:00.000','94e160b5-b568-4423-a202-b2deaffff793','member.rera',1009,1,'0001-01-01 00:00:00.000','0','0',0,0,'0001-01-01 00:00:00.000',NULL,NULL,NULL,NULL,NULL,1,1,1,1,0,2,'sysadmin','2024-12-27 11:21:13.000','sysadmin','2024-12-27 11:21:13.000'),(107,5007,'admprogrammer.rera','2024-04-01 00:00:00.000','2024-09-20 00:00:00.000',1,'Application Accepted for Project Approval','Project',1,1,'NA','','','59de6ff4-4575-4181-8620-470fc796d929','chairperson',1006,1,'0001-01-01 00:00:00.000','0','0',0,0,'0001-01-01 00:00:00.000','0','0',0,0,'0001-01-01 00:00:00.000','0','0',0,0,'0001-01-01 00:00:00.000',NULL,NULL,NULL,NULL,NULL,1,1,1,1,0,2,'sysadmin','2024-12-27 11:21:13.000','sysadmin','2024-12-27 11:21:13.000'),(108,5008,'admprogrammer.rera','2024-09-30 00:00:00.000','2025-12-31 00:00:00.000',1,'Application Accepted for Project Approval','Project',2,1,'VirtualVote','','','59de6ff4-4575-4181-8620-470fc796d929','chairperson',1007,1,'0001-01-01 00:00:00.000','2625c3c4-21e0-4fba-9400-7cf61bc62e8c','member1.rera',1008,1,'0001-01-01 00:00:00.000','0','0',0,0,'0001-01-01 00:00:00.000','59de6ff4-4575-4181-8620-470fc796d929','chairperson',1007,1,'0001-01-01 00:00:00.000',NULL,NULL,NULL,NULL,NULL,1,1,1,1,0,1,'sysadmin','2024-12-27 11:21:13.000','sysadmin','2024-12-27 11:21:13.000');
/*!40000 ALTER TABLE `tbl_rera_project_stampapproval_details` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:14
