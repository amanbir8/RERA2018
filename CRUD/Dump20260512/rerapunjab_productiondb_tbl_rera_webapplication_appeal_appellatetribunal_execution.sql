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
-- Table structure for table `tbl_rera_webapplication_appeal_appellatetribunal_execution`
--

DROP TABLE IF EXISTS `tbl_rera_webapplication_appeal_appellatetribunal_execution`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_webapplication_appeal_appellatetribunal_execution` (
  `AppellateTribunalOrderExecution_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `AppellateTribunalOrderExecution_ID` bigint(20) NOT NULL,
  `Related_ComplaintID` bigint(20) NOT NULL,
  `Related_DiaryNumber` varchar(50) NOT NULL,
  `Related_ComplaintType_MN` varchar(50) NOT NULL,
  `Related_Appeal_RefNumber` varchar(50) NOT NULL,
  `Related_Appeal_OrderDate` datetime(3) NOT NULL,
  `SerialOrderNumber` int(11) DEFAULT NULL,
  `ComplaintNumber` varchar(100) NOT NULL,
  `ComplainantName` varchar(250) NOT NULL,
  `RespondentName` varchar(250) NOT NULL,
  `Date_of_Decision` datetime(3) NOT NULL,
  `Execution_RefNumber` varchar(100) NOT NULL,
  `Execution_FilingDate` datetime(3) NOT NULL,
  `Execution_InstitutionDate` datetime(3) NOT NULL,
  `Related_PreHearingDate_IndexID` bigint(20) NOT NULL,
  `Related_PreHearingDate_ID` bigint(20) NOT NULL,
  `Related_PreHearingDate` datetime(3) NOT NULL,
  `Related_PreHearingTime` varchar(50) NOT NULL,
  `User_ID` varchar(50) NOT NULL,
  `HearingBenchCode` varchar(100) NOT NULL,
  `HearingBenchName` varchar(250) NOT NULL,
  `HearingBenchType` varchar(150) NOT NULL,
  `ExecutionOrderDoc_InfoCode` int(11) DEFAULT NULL,
  `ExecutionOrderDoc_InfoName` varchar(90) NOT NULL,
  `ExecutionOrderDoc_ReferenceNumber` varchar(90) NOT NULL,
  `ExecutionOrderDoc_IssueDate` datetime(3) NOT NULL,
  `ExecutionOrderDoc_FileSize` varchar(50) NOT NULL,
  `ExecutionOrderDoc_FileFormat` varchar(50) NOT NULL,
  `ExecutionOrderDoc_FilePath` varchar(250) NOT NULL,
  `ExecutionOrderDoc_FileName` varchar(250) NOT NULL,
  `ExecutionOrderDoc_IsGroup` int(11) NOT NULL,
  `Upload_SerialNumber` varchar(50) NOT NULL,
  `Upload_PageStartNumber` int(11) DEFAULT NULL,
  `Upload_PageEndNumber` int(11) DEFAULT NULL,
  `Remarks_IfAny` varchar(250) DEFAULT NULL,
  `A_column` varchar(50) DEFAULT NULL,
  `B_column` varchar(50) DEFAULT NULL,
  `C_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `IsDraftMember` int(11) NOT NULL,
  `IsFlag` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`AppellateTribunalOrderExecution_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=1015 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_webapplication_appeal_appellatetribunal_execution`
--

LOCK TABLES `tbl_rera_webapplication_appeal_appellatetribunal_execution` WRITE;
/*!40000 ALTER TABLE `tbl_rera_webapplication_appeal_appellatetribunal_execution` DISABLE KEYS */;
INSERT INTO `tbl_rera_webapplication_appeal_appellatetribunal_execution` VALUES (1001,1001,0,'NA','FormTypeMN','Appeal No. 116 of 2021','0001-01-01 00:00:00.000',1,'NA','Dhiraj Gurvinder Singh','M/s ATS Infrabuild Pvt. Ltd. and Another','2022-10-10 00:00:00.000','Execution Application No. 04 of 2022','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000',0,0,'0001-01-01 00:00:00.000','00:00 AM','fa53d766-d3ae-4b3d-9c62-022d4391f561','0','NA','REAT',1001,'Final Order','NA','2022-10-10 00:00:00.000','1','.pdf','rwdataOrdersExecutionByPbREAT/2024/','20221010ExecutionApp04of2022AppealNo116of2021.pdf',10,'1',1,15,NULL,NULL,NULL,NULL,1,1,0,0,0,1,'SheetByREAT','2022-10-10 00:00:00.000','SheetByREAT','2022-10-10 00:00:00.000'),(1002,1002,0,'NA','FormTypeMN','Appeal No. 257 of 2020','0001-01-01 00:00:00.000',2,'NA','Akhilesh Khanna','Chief Administrator, GMADA','2022-11-21 00:00:00.000','Execution Application 09 of 2022','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000',0,0,'0001-01-01 00:00:00.000','00:00 AM','fa53d766-d3ae-4b3d-9c62-022d4391f561','0','NA','REAT',1001,'Final Order','NA','2022-11-21 00:00:00.000','1','.pdf','rwdataOrdersExecutionByPbREAT/2024/','20221121ExeApp9of2022AppealNo257of2020.pdf',10,'1',1,15,NULL,NULL,NULL,NULL,1,1,0,0,0,1,'SheetByREAT','2022-10-10 00:00:00.000','SheetByREAT','2022-10-10 00:00:00.000'),(1003,1003,0,'NA','FormTypeMN','Appeal No. 09 of 2022','0001-01-01 00:00:00.000',3,'NA','Dinesh Arora and Another','Parsvnath Developers Ltd. and Another','2023-01-23 00:00:00.000','Execution Application No. 06 of 2022','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000',0,0,'0001-01-01 00:00:00.000','00:00 AM','fa53d766-d3ae-4b3d-9c62-022d4391f561','0','NA','REAT',1001,'Final Order','NA','2023-01-23 00:00:00.000','1','.pdf','rwdataOrdersExecutionByPbREAT/2024/','20230123ExcApp06to08of2022AppealNo09to25of2022.pdf',10,'1',1,15,NULL,NULL,NULL,NULL,1,1,0,0,0,1,'SheetByREAT','2022-10-10 00:00:00.000','SheetByREAT','2022-10-10 00:00:00.000'),(1004,1004,0,'NA','FormTypeMN','Appeal No. 25 of 2022','0001-01-01 00:00:00.000',4,'NA','Dhruva Bhramchary and Another','Parsvnath Developers Ltd. and Another','2023-01-23 00:00:00.000','Execution Application No. 07 of 2022','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000',0,0,'0001-01-01 00:00:00.000','00:00 AM','fa53d766-d3ae-4b3d-9c62-022d4391f561','0','NA','REAT',1001,'Final Order','NA','2023-01-23 00:00:00.000','1','.pdf','rwdataOrdersExecutionByPbREAT/2024/','20230123ExcApp06to08of2022AppealNo09to25of2022.pdf',10,'1',1,15,NULL,NULL,NULL,NULL,1,1,0,0,0,1,'SheetByREAT','2022-10-10 00:00:00.000','SheetByREAT','2022-10-10 00:00:00.000'),(1005,1005,0,'NA','FormTypeMN','Appeal No. 22 of 2022','0001-01-01 00:00:00.000',5,'NA','Anuradha Dua','Parsvnath Developers Ltd. and Another','2023-01-23 00:00:00.000','Execution Application No. 08 of 2022','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000',0,0,'0001-01-01 00:00:00.000','00:00 AM','fa53d766-d3ae-4b3d-9c62-022d4391f561','0','NA','REAT',1001,'Final Order','NA','2023-01-23 00:00:00.000','1','.pdf','rwdataOrdersExecutionByPbREAT/2024/','20230123ExcApp06to08of2022AppealNo09to25of2022.pdf',10,'1',1,15,NULL,NULL,NULL,NULL,1,1,0,0,0,1,'SheetByREAT','2022-10-10 00:00:00.000','SheetByREAT','2022-10-10 00:00:00.000'),(1006,1006,0,'NA','FormTypeMN','Appeal No. 44 of 2022','0001-01-01 00:00:00.000',6,'NA','Kiran Pal Gupta and Another','Sushma Buildtech Ltd. and Others','2023-02-16 00:00:00.000','Execution Application 15 of 2022','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000',0,0,'0001-01-01 00:00:00.000','00:00 AM','fa53d766-d3ae-4b3d-9c62-022d4391f561','0','NA','REAT',1001,'Final Order','NA','2023-02-16 00:00:00.000','1','.pdf','rwdataOrdersExecutionByPbREAT/2024/','20230216ExAppNo15to16of2022nAppealNo44to45of2022.pdf',10,'1',1,15,NULL,NULL,NULL,NULL,1,1,0,0,0,1,'SheetByREAT','2022-10-10 00:00:00.000','SheetByREAT','2022-10-10 00:00:00.000'),(1007,1007,0,'NA','FormTypeMN','Appeal No. 45 of 2022','0001-01-01 00:00:00.000',7,'NA','Manas Chabbra and Another','Sushma Buildtech Ltd. and Others','2023-02-16 00:00:00.000','Execution Application No. 16 of 2022','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000',0,0,'0001-01-01 00:00:00.000','00:00 AM','fa53d766-d3ae-4b3d-9c62-022d4391f561','0','NA','REAT',1001,'Final Order','NA','2023-02-16 00:00:00.000','1','.pdf','rwdataOrdersExecutionByPbREAT/2024/','20230216ExAppNo15to16of2022nAppealNo44to45of2022.pdf',10,'1',1,15,NULL,NULL,NULL,NULL,1,1,0,0,0,1,'SheetByREAT','2022-10-10 00:00:00.000','SheetByREAT','2022-10-10 00:00:00.000'),(1008,1008,0,'NA','FormTypeMN','Appeal No. 120 of 2022','0001-01-01 00:00:00.000',8,'NA','Dr. Ira Dhawan and Another','M/s Manohar Infrastructure & Constructions Pvt. Ltd.','2023-03-27 00:00:00.000','Execution Application No. 11 of 2022','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000',0,0,'0001-01-01 00:00:00.000','00:00 AM','fa53d766-d3ae-4b3d-9c62-022d4391f561','0','NA','REAT',1001,'Final Order','NA','2023-03-27 00:00:00.000','1','.pdf','rwdataOrdersExecutionByPbREAT/2024/','20230327ExcApplicationNo11of2022INAppealNo120of2022.pdf',10,'1',1,15,NULL,NULL,NULL,NULL,1,1,0,0,0,1,'SheetByREAT','2022-10-10 00:00:00.000','SheetByREAT','2022-10-10 00:00:00.000'),(1009,1009,0,'NA','FormTypeMN','Appeal No. 230 of 2020','0001-01-01 00:00:00.000',9,'NA','Inderjeet Mohan Kaur','The Chief Administrator GMADA, PUDA','2023-05-29 00:00:00.000','Execution Application No. 01 of 2022','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000',0,0,'0001-01-01 00:00:00.000','00:00 AM','fa53d766-d3ae-4b3d-9c62-022d4391f561','0','NA','REAT',1001,'Final Order','NA','2023-05-29 00:00:00.000','1','.pdf','rwdataOrdersExecutionByPbREAT/2024/','20230529execution01of2022appealno230of2020.pdf',10,'1',1,15,NULL,NULL,NULL,NULL,1,1,0,0,0,1,'SheetByREAT','2022-10-10 00:00:00.000','SheetByREAT','2022-10-10 00:00:00.000'),(1010,1010,0,'NA','FormTypeMN','Appeal No. 231 of 2020','0001-01-01 00:00:00.000',10,'NA','Inderjeet Mohan Kaur and Another','The Chief Administrator GMADA, PUDA','2023-05-29 00:00:00.000','Execution Application No. 02 of 2022','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000',0,0,'0001-01-01 00:00:00.000','00:00 AM','fa53d766-d3ae-4b3d-9c62-022d4391f561','0','NA','REAT',1001,'Final Order','NA','2023-05-29 00:00:00.000','1','.pdf','rwdataOrdersExecutionByPbREAT/2024/','20230529execution02of2022appealno231of2020.pdf',10,'1',1,15,NULL,NULL,NULL,NULL,1,1,0,0,0,1,'SheetByREAT','2022-10-10 00:00:00.000','SheetByREAT','2022-10-10 00:00:00.000'),(1011,1011,0,'NA','FormTypeMN','Appeal No. 116 of 2021','0001-01-01 00:00:00.000',11,'NA','Dhiraj Gurvinder Singh','M/s ATS Infrabuild Pvt. Ltd & Anr.','2023-08-14 00:00:00.000','Execution Application No. 12','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000',0,0,'0001-01-01 00:00:00.000','00:00 AM','fa53d766-d3ae-4b3d-9c62-022d4391f561','0','NA','REAT',1001,'Final Order','NA','2023-08-14 00:00:00.000','1','.pdf','rwdataOrdersExecutionByPbREAT/2024/','20230814execution12appealno116of2021.pdf',10,'1',1,15,NULL,NULL,NULL,NULL,1,1,0,0,0,1,'SheetByREAT','2022-10-10 00:00:00.000','SheetByREAT','2022-10-10 00:00:00.000'),(1012,1012,0,'NA','FormTypeMN','Appeal No. 111 of 2022','0001-01-01 00:00:00.000',12,'NA','Dr. Raj Kumar & ARS.','M/s ATS Infrabuild Pvt. Ltd','2023-09-21 00:00:00.000','Execution No. 05 of 2023','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000',0,0,'0001-01-01 00:00:00.000','00:00 AM','fa53d766-d3ae-4b3d-9c62-022d4391f561','0','NA','REAT',1001,'Final Order','NA','2023-09-21 00:00:00.000','1','.pdf','rwdataOrdersExecutionByPbREAT/2024/','20230921execution05of2023appealno111of2022.pdf',10,'1',1,15,NULL,NULL,NULL,NULL,1,1,0,0,0,1,'SheetByREAT','2022-10-10 00:00:00.000','SheetByREAT','2022-10-10 00:00:00.000'),(1013,1013,0,'NA','FormTypeMN','Appeal No. 207 of 2022','0001-01-01 00:00:00.000',13,'NA','M/s TDI Infratech Limited','Real Estate Regulatory Authority, Punjab','2024-04-30 00:00:00.000','Execution Application No. 03 of 2023','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000',0,0,'0001-01-01 00:00:00.000','00:00 AM','fa53d766-d3ae-4b3d-9c62-022d4391f561','0','NA','REAT',1001,'Final Order','NA','2024-04-30 00:00:00.000','1','.pdf','rwdataOrdersExecutionByPbREAT/2024/','20240430execution03of2023appealno207of2022.pdf',10,'1',1,15,NULL,NULL,NULL,NULL,1,1,0,0,0,1,'SheetByREAT','2022-10-10 00:00:00.000','SheetByREAT','2022-10-10 00:00:00.000'),(1014,1014,0,'NA','FormTypeMN','Appeal No. 152 of 2022','0001-01-01 00:00:00.000',14,'NA','Subhash Chandra Basu','Punjab Empires Pvt. Ltd. and Others','2026-01-22 00:00:00.000','Execution Application No. 11 of 2023','0001-01-01 00:00:00.000','0001-01-01 00:00:00.000',0,0,'0001-01-01 00:00:00.000','00:00 AM','fa53d766-d3ae-4b3d-9c62-022d4391f561','0','NA','REAT',1001,'Final Order','NA','2026-01-29 00:00:00.000','1','.pdf','rwdataOrdersExecutionByPbREAT/2026/','20260129execution11of2023appealno152of2022.pdf',10,'1',1,15,NULL,NULL,NULL,NULL,1,1,0,0,0,1,'SheetByONLINE','2026-01-29 00:00:00.000','SheetByONLINE','2026-01-29 00:00:00.000');
/*!40000 ALTER TABLE `tbl_rera_webapplication_appeal_appellatetribunal_execution` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:49
