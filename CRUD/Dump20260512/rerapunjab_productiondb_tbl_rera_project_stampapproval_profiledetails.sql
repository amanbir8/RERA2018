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
-- Table structure for table `tbl_rera_project_stampapproval_profiledetails`
--

DROP TABLE IF EXISTS `tbl_rera_project_stampapproval_profiledetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_project_stampapproval_profiledetails` (
  `StampProfile_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `StampProfile_ID` bigint(20) NOT NULL,
  `Related_UserID` varchar(90) NOT NULL,
  `Related_UserName` varchar(250) NOT NULL,
  `Related_UserProfile_ID` bigint(20) NOT NULL,
  `Related_IndexEMPID` varchar(90) NOT NULL,
  `Stamp_EmployeeName` varchar(100) NOT NULL,
  `Stamp_DateOfJoining` datetime(3) NOT NULL,
  `Stamp_DateOfRetirement` datetime(3) NOT NULL,
  `User_DesignationCode` varchar(100) DEFAULT NULL,
  `User_DesignationName` varchar(100) DEFAULT NULL,
  `User_EmployeeType` varchar(100) DEFAULT NULL,
  `User_DepartmentCode` varchar(100) DEFAULT NULL,
  `User_DepartmentName` varchar(100) DEFAULT NULL,
  `User_JobSpecilization` varchar(400) DEFAULT NULL,
  `User_Email` varchar(256) DEFAULT NULL,
  `User_MobileNumber` longtext,
  `User_PhoneNumber` longtext,
  `Remarks_IfAny` varchar(100) DEFAULT NULL,
  `A_column` varchar(50) DEFAULT NULL,
  `B_column` varchar(50) DEFAULT NULL,
  `C_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `IsApproved` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `CreatedBy` varchar(100) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(100) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`StampProfile_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_project_stampapproval_profiledetails`
--

LOCK TABLES `tbl_rera_project_stampapproval_profiledetails` WRITE;
/*!40000 ALTER TABLE `tbl_rera_project_stampapproval_profiledetails` DISABLE KEYS */;
INSERT INTO `tbl_rera_project_stampapproval_profiledetails` VALUES (1,1001,'59de6ff4-4575-4181-8620-470fc796d929','chairperson',0,'NA','Sh. Navreet Singh Kang, Chairperson','2024-12-27 09:51:38.000','2024-12-27 09:51:38.000','Chairperson','Chairperson','Regular','RERA','RERA','Authority','chairrera@punjab.gov.in','9877766508','0',NULL,NULL,NULL,NULL,1,1,1,0,0,'sysadmin','2024-12-27 09:51:38.000','sysadmin','2024-12-27 09:51:38.000'),(2,1002,'6a71dec8-8967-46b1-96c9-04d29609ed0e','membersg',0,'NA','Sh. Sanjiv Gupta, Member','2024-12-27 09:51:38.000','2024-12-27 09:51:38.000','Member','Member','Regular','RERA','RERA','Authority','membersgrera@punjab.gov.in','9877766508','0',NULL,NULL,NULL,NULL,1,1,1,0,0,'sysadmin','2024-12-27 09:51:38.000','sysadmin','2024-12-27 09:51:38.000'),(3,1003,'8d9c6328-e164-40c4-9547-45c7c90138a9','memberjsk',0,'NA','Sh. Jagdish Singh Khushdil, Member','2024-12-27 09:51:38.000','2024-12-27 09:51:38.000','Member','Member','Regular','RERA','RERA','Authority','memberjskrera@punjab.gov.in','9877766508','0',NULL,NULL,NULL,NULL,1,1,1,0,0,'sysadmin','2024-12-27 09:51:38.000','sysadmin','2024-12-27 09:51:38.000'),(4,1004,'97148e6d-64f5-490b-98cc-94767e9f36f7','memberaps.rera',0,'NA','Sh. Ajay Pal Singh, Member','2024-12-27 09:51:38.000','2024-12-27 09:51:38.000','Member','Member','Regular','RERA','RERA','Authority','memberaps.rera@punjab.gov.in','9969233019','0',NULL,NULL,NULL,NULL,1,1,1,0,0,'sysadmin','2024-12-27 09:51:38.000','sysadmin','2024-12-27 09:51:38.000'),(5,1005,'59de6ff4-4575-4181-8620-470fc796d929','chairperson',0,'NA','Sh. Satya Gopal, Chairperson','2024-12-27 09:51:38.000','2024-12-27 09:51:38.000','Chairperson','Chairperson','Regular','RERA','RERA','Authority','chairrera@punjab.gov.in','9877766508','0',NULL,NULL,NULL,NULL,1,1,1,0,0,'sysadmin','2024-12-27 09:51:38.000','sysadmin','2024-12-27 09:51:38.000'),(6,1006,'59de6ff4-4575-4181-8620-470fc796d929','chairperson',0,'NA','Sh. Malwinder Singh Jaggi, Chairperson','2024-12-27 09:51:38.000','2024-12-27 09:51:38.000','Authority','Authority','Regular','RERA','RERA','Authority','programmer.rera@punjab.gov.in','9877766508','0',NULL,NULL,NULL,NULL,1,1,1,0,0,'sysadmin','2024-12-27 09:51:38.000','sysadmin','2024-12-27 09:51:38.000'),(7,1007,'59de6ff4-4575-4181-8620-470fc796d929','chairperson',0,'NA','Sh. Rakesh Kumar Goyal, Chairperson','2024-12-27 09:51:38.000','2024-12-27 09:51:38.000','Chairperson','Chairperson','Regular','RERA','RERA','Authority','chairrera@punjab.gov.in','9877766508','0',NULL,NULL,NULL,NULL,1,1,1,1,1,'sysadmin','2024-12-27 09:51:38.000','sysadmin','2024-12-27 09:51:38.000'),(8,1008,'2625c3c4-21e0-4fba-9400-7cf61bc62e8c','member1.rera',0,'NA','Sh. Binod Kumar Singh, Member','2024-12-27 09:51:38.000','2024-12-27 09:51:38.000','Member','Member','Regular','RERA','RERA','Authority','member1.rera@punjab.gov.in','9877766508','0',NULL,NULL,NULL,NULL,1,1,1,1,1,'sysadmin','2024-12-27 09:51:38.000','sysadmin','2024-12-27 09:51:38.000'),(9,1009,'94e160b5-b568-4423-a202-b2deaffff793','member.rera',0,'NA','Sh. Rakesh Kumar Goyal, Member','2024-12-27 09:51:38.000','2024-12-27 09:51:38.000','Member','Member','Regular','RERA','RERA','Authority','member.rera@punjab.gov.in','9877766508','0',NULL,NULL,NULL,NULL,1,1,1,0,0,'sysadmin','2024-12-27 09:51:38.000','sysadmin','2024-12-27 09:51:38.000');
/*!40000 ALTER TABLE `tbl_rera_project_stampapproval_profiledetails` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:35
