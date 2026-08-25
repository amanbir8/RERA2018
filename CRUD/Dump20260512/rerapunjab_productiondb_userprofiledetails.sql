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
-- Table structure for table `userprofiledetails`
--

DROP TABLE IF EXISTS `userprofiledetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userprofiledetails` (
  `UserProfile_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserProfile_ID` bigint(20) NOT NULL,
  `Applicant_FirstName` varchar(100) NOT NULL,
  `Applicant_MiddleName` varchar(100) NOT NULL,
  `Applicant_LastName` varchar(100) NOT NULL,
  `Father_FirstName` varchar(100) DEFAULT NULL,
  `Father_MiddleName` varchar(100) DEFAULT NULL,
  `Father_LastName` varchar(100) DEFAULT NULL,
  `DateOfJoining` datetime(3) NOT NULL,
  `DateOfRetirement` datetime(3) NOT NULL,
  `Occupation` varchar(100) DEFAULT NULL,
  `Designation` varchar(100) DEFAULT NULL,
  `EmployeeType` varchar(100) DEFAULT NULL,
  `DepartmentCode` varchar(100) DEFAULT NULL,
  `DepartmentName` varchar(100) DEFAULT NULL,
  `JobSpecilization` varchar(400) DEFAULT NULL,
  `ScaleType` varchar(100) DEFAULT NULL,
  `Residencial_Official_AddressLine1` varchar(250) NOT NULL,
  `Residencial_Official_AddressLine2` varchar(250) NOT NULL,
  `Residencial_Official_AddressStateCode` int(11) NOT NULL,
  `Residencial_Official_AddressDistrictCode` int(11) NOT NULL,
  `Residencial_Official_AddressPIN` varchar(100) NOT NULL,
  `MobileNumber` bigint(20) NOT NULL,
  `PhoneNumber_STD` bigint(20) DEFAULT NULL,
  `PhoneNumber_Number` bigint(20) DEFAULT NULL,
  `EmailAddress` varchar(100) NOT NULL,
  `Remarks_IfAny` varchar(100) DEFAULT NULL,
  `IndexEMPID` varchar(90) NOT NULL,
  `IndexNumber` bigint(20) NOT NULL,
  `IndexYear` int(11) NOT NULL,
  `IsExistAuthorizedUser` int(11) NOT NULL,
  `UserEmployeeName` varchar(250) NOT NULL,
  `UserID` varchar(90) NOT NULL,
  `UserName` varchar(250) NOT NULL,
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
  PRIMARY KEY (`UserProfile_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userprofiledetails`
--

LOCK TABLES `userprofiledetails` WRITE;
/*!40000 ALTER TABLE `userprofiledetails` DISABLE KEYS */;
INSERT INTO `userprofiledetails` VALUES (1,1001,'Col. Varinder','Singh','(Retd.)','NA','NA','NA','2018-07-26 04:59:59.000','2018-07-26 04:59:59.000','AL','Secretary','Permanent','RERA Authority','RERA Authority','Secretary','Class A','NA','NA',0,0,'0',0,172,5139800,'NA',NULL,'PB1001RERA2020',1001,2020,2,'V Singh','1333aa16-4a5f-411f-b1fb-58966d962758','ABC2021',NULL,NULL,NULL,2,1,1,1,0,'sysadmin','2018-07-26 04:59:59.000','sysadmin','2018-07-26 04:59:59.000'),(2,1002,'Munish','','Sharma','NA','NA','NA','2021-06-01 04:59:59.000','2022-06-30 04:59:59.000','PR','IT Manager','Permanent','RERA Authority','RERA Authority','IT Manager and Admin Manager','Class A','NA','NA',0,0,'0',0,172,5139822,'NA',NULL,'PB222',222,2021,1,'Manish Sharma','6fb47c94-2320-4114-a999-cf852c1bb701','ManagerIT.rera',NULL,NULL,NULL,2,1,1,1,0,'sysadmin','2021-06-01 04:59:59.000','sysadmin','2021-06-01 04:59:59.000'),(3,1003,'Pardeep','','Kumar','Hans','','Raj','2021-05-21 00:00:00.000','2040-05-23 00:00:00.000','LG','Reader to AO','Permanent','Office of Adjudicating Officer','Office of Adjudicating Officer','PS to Members RERA','Class A','NA','NA',0,0,'0',9417868057,172,5139822,'readerao.rera@punjab.gov.in',NULL,'1000682',1003,2021,1,'Pardeep Kumar','2e8251d9-e943-4dc6-b922-e2da35e0cca6','readerao.rera',NULL,NULL,NULL,2,1,1,1,0,'sysadmin','2021-10-04 00:00:00.000','sysadmin','2021-10-04 00:00:00.000'),(4,1004,'Sawan','','Kumar','Vinod','','Kumar','2018-07-13 00:00:00.000','2040-07-13 00:00:00.000','LG','PA Member SG','Permanent','Office of Member SG','Office of Member SG','PS to Members RERA','Class A','NA','NA',0,0,'0',8699766338,172,5139822,'pamemsgrera@punjab.gov.in',NULL,'37149798',1004,2021,2,'Sawan Kumar','','',NULL,NULL,NULL,2,1,1,1,0,'sysadmin','2021-10-04 00:00:00.000','sysadmin','2021-10-04 00:00:00.000'),(5,1005,'Anju','','','Nand','Lal','Khurana','2017-12-07 00:00:00.000','2040-12-07 00:00:00.000','LG','PA Chairperson','Permanent','Office of Chairperson','Office of Chairperson','PS to Members RERA','Class A','NA','NA',0,0,'0',9877766508,172,5139822,'pachairrera@punjab.gov.in',NULL,'86431340',1005,2021,2,'Anju','','',NULL,NULL,NULL,2,1,1,1,0,'sysadmin','2021-10-04 00:00:00.000','sysadmin','2021-10-04 00:00:00.000'),(6,1006,'Rajinder','Singh','Batra','NA','NA','NA','2022-05-20 00:00:00.000','2040-05-20 00:00:00.000','PR','Manager Projects and Regulations','Permanent','RERA Authority','RERA Authority','Manager Projects and Regulations','Class A','NA','NA',0,0,'0',9877766508,172,5139822,'programmer.rera@punjab.gov.in',NULL,'11680543',1006,2022,1,'Rajinder Singh Batra','bd388345-c626-4c08-b8ed-2c4bbab4e0d5','mngrprojects.rera',NULL,NULL,NULL,2,1,1,1,0,'sysadmin','2022-05-23 11:15:00.000','sysadmin','2022-05-23 11:15:00.000'),(7,1007,'Rakesh','Kumar','Goyal','NA','','NA','2022-12-21 00:00:00.000','2027-12-20 00:00:00.000','AL','Member RERA','Permanent','RERA Authority','RERA Authority','Member RERA','Class A','NA','NA',0,0,'0',0,0,0,'member.rera@punjab.gov.in',NULL,'PB1001RERA2022',1007,2022,1,'Rakesh Kumar Goyal','94e160b5-b568-4423-a202-b2deaffff793','member.rera',NULL,NULL,NULL,2,1,1,1,0,'sysadmin','2023-01-01 10:00:00.000','sysadmin','2023-01-01 10:00:00.000'),(8,1008,'Hetu','','Sharma','NA','','NA','2022-12-21 00:00:00.000','2040-05-20 00:00:00.000','LG','PS Member RKG','Permanent','RERA Authority','RERA Authority','PS to Members RERA','Class A','NA','NA',0,0,'0',0,0,0,'psmember.rera@punjab.gov.in',NULL,'PB1002RERA2022',1008,2022,1,'Hetu Sharma','532a6506-e0e9-411a-99f3-f30fe8fd8f83','psmember.rera',NULL,NULL,NULL,2,1,1,1,0,'sysadmin','2023-01-01 10:00:00.000','sysadmin','2023-01-01 10:00:00.000'),(9,1009,'Saawan','','Kumar','NA','','NA','2022-12-21 00:00:00.000','2040-05-20 00:00:00.000','LG','PA Member RKG','Permanent','RERA Authority','RERA Authority','PA to Members RERA','Class A','NA','NA',0,0,'0',0,0,0,'pamember.rera@punjab.gov.in',NULL,'PB1003RERA2022',1009,2022,1,'Saawan Kumar','e6c964a6-70bb-4406-a8be-72e1934c2982','pamember.rera',NULL,NULL,NULL,2,1,1,1,0,'sysadmin','2023-01-01 10:00:00.000','sysadmin','2023-01-01 10:00:00.000'),(10,1010,'Amandeep','','Nijjer','NA','','NA','2023-07-11 00:00:00.000','2040-05-20 00:00:00.000','TP','TP Manager','Permanent','RERA Authority','RERA Authority','Manager Town Planning','Class A','NA','NA',0,0,'0',0,0,0,'mngrtp.rera@punjab.gov.in',NULL,'PB1001RERA2023',1010,2023,2,'Amandeep Nijjer','5927e2e1-5935-4cd0-bd14-1324e3cdbe45','ManagerTP.rera',NULL,NULL,NULL,2,1,1,1,0,'sysadmin','2023-07-11 18:10:00.000','sysadmin','2023-07-11 18:10:00.000'),(11,1011,'NA','','NA','NA','','NA','2023-07-11 00:00:00.000','2040-05-20 00:00:00.000','FA','DirectorFnA','Permanent','Director F and A','RERA Authority','Director F and A','Class A','NA','NA',0,0,'0',0,0,0,'mngrfnarera@punjab.gov.in',NULL,'PB1001RERA2025',1001,2025,1,'Rajan Munjal','79512617-accd-4c42-a526-79285ba6261f','DirectorFnA',NULL,NULL,NULL,1,1,1,1,0,'sysadmin','2025-04-13 14:15:00.000','sysadmin','2025-04-13 14:15:00.000'),(12,1012,'NA','','NA','NA','','NA','2023-07-11 00:00:00.000','2040-05-20 00:00:00.000','FA','DirectorFnA2','Permanent','Director F and A','RERA Authority','Director F and A','Class A','NA','NA',0,0,'0',0,0,0,'mngrfnarera@punjab.gov.in',NULL,'PB1002RERA2025',1002,2025,1,'Rajan Munjal','eb39347c-fcce-4372-bcc3-07b6fde3ade0','DirectorFnA2',NULL,NULL,NULL,1,1,1,1,0,'sysadmin','2025-04-13 14:15:00.000','sysadmin','2025-04-13 14:15:00.000'),(13,1013,'NA','','NA','NA','','NA','2023-07-11 00:00:00.000','2040-05-20 00:00:00.000','PR','DirectorIT','Permanent','Director IT','RERA Authority','Director IT','Class A','NA','NA',0,0,'0',0,0,0,'mgradmin.rera@punjab.gov.in',NULL,'PB1003RERA2025',1003,2025,1,'Manish Sharma','6fb47c94-2320-4114-a999-cf852c1bb701','DirectorIT',NULL,NULL,NULL,1,1,1,1,0,'sysadmin','2025-04-13 14:15:00.000','sysadmin','2025-04-13 14:15:00.000'),(14,1014,'NA','','NA','NA','','NA','2023-07-11 00:00:00.000','2040-05-20 00:00:00.000','LG','DirectorLegal','Permanent','Director Legal','RERA Authority','Director Legal','Class A','NA','NA',0,0,'0',0,0,0,'mngrlegal.rera@punjab.gov.in',NULL,'PB1004RERA2025',1004,2025,1,'Deepal Juneja','9df7eb97-bdc2-41d2-9c3d-fc23338a5749','DirectorLegal',NULL,NULL,NULL,1,1,1,1,0,'sysadmin','2025-04-13 14:15:00.000','sysadmin','2025-04-13 14:15:00.000'),(15,1015,'NA','','NA','NA','','NA','2023-07-11 00:00:00.000','2040-05-20 00:00:00.000','PR','DirectorPnR','Permanent','Director Project and Registrations','RERA Authority','Director Project and Registrations','Class A','NA','NA',0,0,'0',0,0,0,'mngrprojects.rera@punjab.gov.in',NULL,'PB1005RERA2025',1005,2025,1,'Rajinder Batra','bd388345-c626-4c08-b8ed-2c4bbab4e0d5','DirectorPnR',NULL,NULL,NULL,1,1,1,1,0,'sysadmin','2025-04-13 14:15:00.000','sysadmin','2025-04-13 14:15:00.000'),(16,1016,'NA','','NA','NA','','NA','2023-07-11 00:00:00.000','2040-05-20 00:00:00.000','TP','DirectorTP','Permanent','Director TP','RERA Authority','Director TP','Class A','NA','NA',0,0,'0',0,0,0,'mngrtp.rera@punjab.gov.in',NULL,'PB1006RERA2025',1006,2025,1,'Amandeep Nijjer','5927e2e1-5935-4cd0-bd14-1324e3cdbe45','DirectorTP',NULL,NULL,NULL,1,1,1,1,0,'sysadmin','2025-04-13 14:15:00.000','sysadmin','2025-04-13 14:15:00.000'),(17,1017,'NA','','NA','NA','','NA','2023-07-11 00:00:00.000','2040-05-20 00:00:00.000','PR','DyDirector1','Permanent','Dy Director Admin','RERA Authority','Dy Director Admin','Class A','NA','NA',0,0,'0',0,0,0,'amadmin1rera@punjab.gov.in',NULL,'PB1007RERA2025',1007,2025,1,'Neha Thakur','59ed568f-8562-490e-b382-deb3e7d4e3c9','DyDirector1',NULL,NULL,NULL,1,1,1,1,0,'sysadmin','2025-04-13 14:15:00.000','sysadmin','2025-04-13 14:15:00.000'),(18,1018,'NA','','NA','NA','','NA','2023-07-11 00:00:00.000','2040-05-20 00:00:00.000','FA','DyDirectorFnA','Permanent','Dy Director F and A','RERA Authority','Dy Director F and A','Class A','NA','NA',0,0,'0',0,0,0,'amfnarera@punjab.gov.in',NULL,'PB1008RERA2025',1008,2025,1,'Chavisor Sharma','b48f6b8e-a8ab-4c97-a4d5-75ad5f0710af','DyDirectorFnA',NULL,NULL,NULL,1,1,1,1,0,'sysadmin','2025-04-13 14:15:00.000','sysadmin','2025-04-13 14:15:00.000'),(19,1019,'NA','','NA','NA','','NA','2023-07-11 00:00:00.000','2040-05-20 00:00:00.000','LG','DyDirectorLegal','Permanent','Dy Director Legal','RERA Authority','Dy Director Legal','Class A','NA','NA',0,0,'0',0,0,0,'amlegal.rera@punjab.gov.in',NULL,'PB1009RERA2025',1009,2025,1,'Jaspal Khara','7b188a4d-f6e7-4214-a260-88c67472a785','DyDirectorLegal',NULL,NULL,NULL,1,1,1,1,0,'sysadmin','2025-04-13 14:15:00.000','sysadmin','2025-04-13 14:15:00.000'),(20,1020,'NA','','NA','NA','','NA','2023-07-11 00:00:00.000','2040-05-20 00:00:00.000','PR','DyDirectorPnR','Permanent','Dy Director P and R','RERA Authority','Dy Director P and R','Class A','NA','NA',0,0,'0',0,0,0,'amprojects.rera@punjab.gov.in',NULL,'PB1010RERA2025',1010,2025,1,'Jaipal Singh','5602ef8f-9636-4d42-ad1a-af395a5fdaeb','DyDirectorPnR',NULL,NULL,NULL,1,1,1,1,0,'sysadmin','2025-04-13 14:15:00.000','sysadmin','2025-04-13 14:15:00.000'),(21,1021,'NA','','NA','NA','','NA','2023-07-11 00:00:00.000','2040-05-20 00:00:00.000','AL','secyrera','Permanent','Secretary RERA','RERA Authority','Secretary RERA','Class A','NA','NA',0,0,'0',0,0,0,'secy.rera@punjab.gov.in',NULL,'PB1011RERA2025',1011,2025,1,'Manish Sharma','97eba4f1-7be4-4ba2-848d-8ad65a317455','secyrera',NULL,NULL,NULL,1,1,1,1,0,'sysadmin','2025-04-13 14:15:00.000','sysadmin','2025-04-13 14:15:00.000'),(22,1022,'NA','','NA','NA','','NA','2026-01-01 00:00:00.000','2040-05-20 00:00:00.000','CP','Chairperson RERA','Permanent','RERA Authority','RERA Authority','Chairperson RERA','Class A','NA','NA',0,0,'0',0,0,0,'chairrera@punjab.gov.in',NULL,'PB1012RERA2025',1012,2025,1,'Rakesh Kumar Goyal','59de6ff4-4575-4181-8620-470fc796d929','chairperson',NULL,NULL,NULL,1,1,1,1,0,'sysadmin','2026-01-01 11:00:00.000','sysadmin','2026-01-01 11:00:00.000'),(23,1023,'NA','','NA','NA','','NA','2026-01-01 00:00:00.000','2040-05-20 00:00:00.000','MO','Member I','Permanent','RERA Authority','RERA Authority','Member RERA','Class A','NA','NA',0,0,'0',0,0,0,'member.rera@punjab.gov.in',NULL,'PB1013RERA2025',1013,2025,1,'Arunvir Vashista','94e160b5-b568-4423-a202-b2deaffff793','member.rera',NULL,NULL,NULL,1,1,1,1,0,'sysadmin','2026-01-01 11:00:00.000','sysadmin','2026-01-01 11:00:00.000'),(24,1024,'NA','','NA','NA','','NA','2026-01-01 00:00:00.000','2040-05-20 00:00:00.000','MT','Member II','Permanent','RERA Authority','RERA Authority','Member RERA','Class A','NA','NA',0,0,'0',0,0,0,'member1.rera@punjab.gov.in',NULL,'PB1014RERA2025',1014,2025,1,'Binod Kumar Singh','2625c3c4-21e0-4fba-9400-7cf61bc62e8c','member1.rera',NULL,NULL,NULL,1,1,1,1,0,'sysadmin','2026-01-01 11:00:00.000','sysadmin','2026-01-01 11:00:00.000');
/*!40000 ALTER TABLE `userprofiledetails` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:37
