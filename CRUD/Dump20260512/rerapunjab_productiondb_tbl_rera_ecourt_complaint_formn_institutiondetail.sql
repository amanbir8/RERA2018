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
-- Table structure for table `tbl_rera_ecourt_complaint_formn_institutiondetail`
--

DROP TABLE IF EXISTS `tbl_rera_ecourt_complaint_formn_institutiondetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_ecourt_complaint_formn_institutiondetail` (
  `InstitutionFormN_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `InstitutionFormN_ID` bigint(20) NOT NULL,
  `InstitutionFormN_Code` varchar(50) NOT NULL,
  `Related_Profile_ID` bigint(20) NOT NULL,
  `Related_User_ID` varchar(50) NOT NULL,
  `Related_ComplaintFormN_ID` bigint(20) NOT NULL,
  `Related_ComplaintFormN_Code` varchar(50) NOT NULL,
  `Related_ComplaintDiaryNumber` varchar(90) NOT NULL,
  `ComplaintType_MN` varchar(50) NOT NULL,
  `Date_of_Filing` datetime(3) NOT NULL,
  `IsSameDiaryNumberWithInstitutionNumber` int(11) NOT NULL,
  `Institution_Ref_ID` bigint(20) NOT NULL,
  `Institution_Ref_Year` int(11) NOT NULL,
  `Institution_Ref_Number` varchar(90) NOT NULL,
  `Institution_Ref_Date` datetime(3) NOT NULL,
  `IsManualAssignBench` int(11) NOT NULL,
  `CaseAssignement_BenchID` bigint(20) NOT NULL,
  `CaseAssignement_BenchName` varchar(90) NOT NULL,
  `CaseAssignement_BenchDescription` varchar(250) NOT NULL,
  `CaseAssignement_BenchLocation` varchar(250) NOT NULL,
  `NatureOfComplaint_Statement` varchar(2500) NOT NULL,
  `NatureOfComplaint_Key1` varchar(50) NOT NULL,
  `NatureOfComplaint_Key2` varchar(50) NOT NULL,
  `NatureOfComplaint_Key3` varchar(50) NOT NULL,
  `ReliefSought_Statement` varchar(2500) NOT NULL,
  `Dak_Number` varchar(90) NOT NULL,
  `Dak_Date` datetime(3) NOT NULL,
  `IsComplaintHardcopySetYesNo` int(11) NOT NULL,
  `HardcopySetNumber` int(11) NOT NULL,
  `NumberOfComplainant` int(11) NOT NULL,
  `NumberOfRespondent` int(11) NOT NULL,
  `Remarks_IfAny` varchar(350) NOT NULL,
  `A_column` varchar(100) NOT NULL,
  `B_column` varchar(100) NOT NULL,
  `C_column` varchar(500) NOT NULL,
  `D_column` varchar(100) NOT NULL,
  `E_column` varchar(300) NOT NULL,
  `F_column` datetime(3) NOT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `IsLockRefNumber` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`InstitutionFormN_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_ecourt_complaint_formn_institutiondetail`
--

LOCK TABLES `tbl_rera_ecourt_complaint_formn_institutiondetail` WRITE;
/*!40000 ALTER TABLE `tbl_rera_ecourt_complaint_formn_institutiondetail` DISABLE KEYS */;
INSERT INTO `tbl_rera_ecourt_complaint_formn_institutiondetail` VALUES (8,1001,'AdCNo00662025',5122,'e391cba6-4ae6-467c-b641-47ee8822e935',3543,'3543','AdCNo00662025','FormN','0001-01-01 00:00:00.000',1,66,2025,'AdCNo00662025','2025-09-18 00:00:00.000',1,2216,'Sh. Rajinder Singh Rai, Adjudicating Officer','','','WAWRWQ','1','0','0','','','0001-01-01 00:00:00.000',0,0,0,0,'TEST 2424214','','','','','','0001-01-01 00:00:00.000',2,0,0,0,1,'LAuser','2025-09-18 10:16:11.000','LAuser','2025-09-18 10:16:11.000'),(9,1002,'AdCNo01252025TR-AUTH00302025',4393,'08233a08-1b06-41a1-9e07-a95c3b69b8fc',3618,'3618','AdCNo01252025TR-AUTH00302025','FormN','0001-01-01 00:00:00.000',1,125,2025,'AdCNo01252025TR-AUTH00302025','2025-10-16 00:00:00.000',1,2213,'Sh. Binod Kumar Singh, Member','','','For possession','0','0','1','','','0001-01-01 00:00:00.000',0,0,0,0,'','','','','','','0001-01-01 00:00:00.000',1,0,0,1,1,'DyDirectorLegal','2025-10-16 11:53:22.000','DyDirectorLegal','2025-10-16 11:53:22.000'),(10,1003,'AdCNo01422025TR-AUTH00312025',5402,'527f8e45-7231-4b38-b6d7-4a3988351659',3637,'3637','AdCNo01422025TR-AUTH00312025','FormN','0001-01-01 00:00:00.000',1,142,2025,'AdCNo01422025TR-AUTH00312025','2025-11-12 00:00:00.000',0,2215,'Sh. Arunvir Vashista, Member','','','For possession','0','0','1','','','0001-01-01 00:00:00.000',0,0,0,0,'','','','','','','0001-01-01 00:00:00.000',2,0,0,1,1,'DyDirectorLegal','2025-11-12 16:47:18.000','DyDirectorLegal','2025-11-12 16:47:18.000'),(11,1004,'AdCNo01432025TR-AUTH00322025',5402,'527f8e45-7231-4b38-b6d7-4a3988351659',3638,'3638','AdCNo01432025TR-AUTH00322025','FormN','0001-01-01 00:00:00.000',1,143,2025,'AdCNo01432025TR-AUTH00322025','2025-11-12 00:00:00.000',0,2214,'Sh. Rakesh Kumar Goyal, Chairperson','','','For possession','0','0','1','','','0001-01-01 00:00:00.000',0,0,0,0,'','','','','','','0001-01-01 00:00:00.000',2,0,0,1,1,'DyDirectorLegal','2025-11-12 16:47:54.000','DyDirectorLegal','2025-11-12 16:47:54.000'),(12,1003,'AdCNo01422025TR-AUTH00312025',5402,'527f8e45-7231-4b38-b6d7-4a3988351659',3637,'3637','AdCNo01422025TR-AUTH00312025','FormN','0001-01-01 00:00:00.000',1,142,2025,'AdCNo01422025TR-AUTH00312025','2025-11-12 00:00:00.000',0,2215,'Sh. Arunvir Vashista, Member','','','For possession','0','0','1','','7915','2025-11-14 00:00:00.000',1,3,1,1,'','','','','','','0001-01-01 00:00:00.000',1,0,0,1,1,'DyDirectorLegal','2025-11-12 16:47:18.000','excgen5','2025-11-21 17:07:10.000'),(13,1004,'AdCNo01432025TR-AUTH00322025',5402,'527f8e45-7231-4b38-b6d7-4a3988351659',3638,'3638','AdCNo01432025TR-AUTH00322025','FormN','0001-01-01 00:00:00.000',1,143,2025,'AdCNo01432025TR-AUTH00322025','2025-11-12 00:00:00.000',0,2214,'Sh. Rakesh Kumar Goyal, Chairperson','','','For possession','0','0','1','','7916','2025-11-14 00:00:00.000',1,3,1,1,'','','','','','','0001-01-01 00:00:00.000',1,0,0,1,1,'DyDirectorLegal','2025-11-12 16:47:54.000','excgen5','2025-11-21 17:09:21.000'),(14,1005,'AdCNo00222026TR-AUTH00022026',5573,'945c0736-cd09-45d7-b13a-5efdd7ad4dc0',3691,'3691','AdCNo00222026TR-AUTH00022026','FormN','0001-01-01 00:00:00.000',1,22,2026,'AdCNo00222026TR-AUTH00022026','2026-02-20 00:00:00.000',0,2213,'Sh. Binod Kumar Singh, Member','','','For possession','0','0','0','','','0001-01-01 00:00:00.000',0,0,0,0,'','','','','','','0001-01-01 00:00:00.000',2,0,0,1,1,'DyDirectorLegal','2026-02-20 15:12:28.000','DyDirectorLegal','2026-02-20 15:12:28.000'),(15,1006,'AdCNo00182026TR-AUTH00012026',5454,'c8c6abc1-1c9e-4986-84a5-80f21528b8cb',3678,'3678','AdCNo00182026TR-AUTH00012026','FormN','0001-01-01 00:00:00.000',1,18,2026,'AdCNo00182026TR-AUTH00012026','2026-02-25 00:00:00.000',0,2215,'Sh. Arunvir Vashista, Member','','','','0','0','1','','','0001-01-01 00:00:00.000',0,0,0,0,'','','','','','','0001-01-01 00:00:00.000',1,0,0,1,1,'DyDirectorLegal','2026-02-25 09:47:11.000','DyDirectorLegal','2026-02-25 09:47:11.000'),(16,1007,'AdCNo00212026TR-AUTH00032026',5275,'8974e873-1b58-4baa-a5d7-e615992a7745',3687,'3687','AdCNo00212026TR-AUTH00032026','FormN','0001-01-01 00:00:00.000',1,21,2026,'AdCNo00212026TR-AUTH00032026','2026-03-05 00:00:00.000',1,2214,'Sh. Rakesh Kumar Goyal, Chairperson','','','Interest on Refund amount','0','0','0','','','0001-01-01 00:00:00.000',0,0,0,0,'','','','','','','0001-01-01 00:00:00.000',1,0,0,1,1,'DyDirectorLegal','2026-03-05 10:12:43.000','DyDirectorLegal','2026-03-05 10:12:43.000'),(17,1005,'AdCNo00222026TR-AUTH00022026',5573,'945c0736-cd09-45d7-b13a-5efdd7ad4dc0',3691,'3691','AdCNo00222026TR-AUTH00022026','FormN','0001-01-01 00:00:00.000',1,22,2026,'AdCNo00222026TR-AUTH00022026','2026-02-20 00:00:00.000',0,2213,'Sh. Binod Kumar Singh, Member','','','For possession','0','0','0','','1418','2026-03-25 00:00:00.000',1,3,2,2,'','','','','','','0001-01-01 00:00:00.000',1,0,0,1,1,'DyDirectorLegal','2026-02-20 15:12:28.000','excgen5','2026-03-05 17:26:34.000');
/*!40000 ALTER TABLE `tbl_rera_ecourt_complaint_formn_institutiondetail` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:03
