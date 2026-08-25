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
-- Table structure for table `tbl_reat_webapplication_circularpublicnotices`
--

DROP TABLE IF EXISTS `tbl_reat_webapplication_circularpublicnotices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_reat_webapplication_circularpublicnotices` (
  `CircularPublicNotice_Reat_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `CircularPublicNotice_Reat_ID` bigint(20) NOT NULL,
  `CircularPublicNotice_LanguageFlag` varchar(50) NOT NULL,
  `Circular_Number` varchar(50) DEFAULT NULL,
  `Circular_IssueDate` datetime(3) NOT NULL,
  `Circular_Category` varchar(100) NOT NULL,
  `Circular_Title` varchar(300) NOT NULL,
  `CulturePunjabi_Circular_Category` varchar(100) DEFAULT NULL,
  `CulturePunjabi_Circular_Title` varchar(300) DEFAULT NULL,
  `Circular_BaseUrl` varchar(100) DEFAULT NULL,
  `Circular_FilePath` varchar(250) DEFAULT NULL,
  `Circular_FileName` varchar(250) DEFAULT NULL,
  `Circular_FileType` varchar(250) DEFAULT NULL,
  `A_column` varchar(50) DEFAULT NULL,
  `B_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`CircularPublicNotice_Reat_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_reat_webapplication_circularpublicnotices`
--

LOCK TABLES `tbl_reat_webapplication_circularpublicnotices` WRITE;
/*!40000 ALTER TABLE `tbl_reat_webapplication_circularpublicnotices` DISABLE KEYS */;
INSERT INTO `tbl_reat_webapplication_circularpublicnotices` VALUES (1,101,'PB','REAT/2021 - 01','2021-02-17 00:00:00.000','Public Notice','Public Notice regarding the fresh filled appeals before Real Estate Appellate Tribunal Punjab','ਜਨਤਕ ਨੋਟਿਸ','ਜਨਤਕ ਨੋਟਿਸ - ਰੀਅਲ ਅਸਟੇਟ ਅਪੀਲ ਟ੍ਰਿਬਿਊਨਲ ਪੰਜਾਬ ਦੇ ਸਾਹਮਣੇ ਤਾਜ਼ਾ ਭਰੀਆਂ ਅਪੀਲਾਂ ਸੰਬੰਧੀ','~/','pdf/circulars-reatpb\\','20210217PbATpublicNoticePhysicalHearing2021.pdf','.pdf','','',1,1,'ReatAdmin','2025-08-07 09:55:07.000','ReatAdmin','2025-08-07 09:55:07.000'),(2,102,'PB','Notice','2021-04-16 00:00:00.000','Public Notice','Public Notice regarding the appeals before Real Estate Appellate Tribunal Punjab','ਜਨਤਕ ਨੋਟਿਸ','ਰੀਅਲ ਅਸਟੇਟ ਅਪੀਲ ਟ੍ਰਿਬਿਊਨਲ ਪੰਜਾਬ ਦੇ ਸਾਹਮਣੇ ਅਪੀਲਾਂ ਸੰਬੰਧੀ ਜਨਤਕ ਨੋਟਿਸ','~/','pdf/circulars-reatpb\\','20210416PbATpublicNoticeForHearing2021ud.pdf','.pdf','','',1,1,'ReatAdmin','2025-08-07 09:55:07.000','ReatAdmin','2025-08-07 09:55:07.000'),(3,103,'PB','REAT/2021 - 01','2021-09-23 00:00:00.000','Public Notice','Public Notice regarding order regarding freshly filed appeals dated 23.09.2021','ਜਨਤਕ ਨੋਟਿਸ','ਜਨਤਕ ਨੋਟਿਸ ਤਾਜ਼ਾ ਦਾਇਰ ਕੀਤੀਆਂ ਅਪੀਲਾਂ 23.09.2021 ਸੰਬੰਧੀ ਆਦੇਸ਼','~/','pdf/circulars-reatpb\\','20210923Order_regarding_freshly_filed_appeals.pdf','.pdf','','',1,1,'ReatAdmin','2025-08-07 09:55:07.000','ReatAdmin','2025-08-07 09:55:07.000'),(4,104,'PB','REAT/2021-Notice','2021-10-12 00:00:00.000','Public Notice','Public Notice regarding Email Address in case of any Grievance','ਜਨਤਕ ਨੋਟਿਸ','ਕਿਸੇ ਵੀ ਸ਼ਿਕਾਇਤ ਦੇ ਮਾਮਲੇ ਵਿੱਚ ਈਮੇਲ ਪਤੇ ਸੰਬੰਧੀ ਜਨਤਕ ਨੋਟਿਸ','~/','pdf/circulars-reatpb\\','20211012notice_emailaddress_grievance2021_02.pdf','.pdf','','',1,1,'ReatAdmin','2025-08-07 09:55:07.000','ReatAdmin','2025-08-07 09:55:07.000'),(5,105,'PB','Notice/Order','2022-01-03 00:00:00.000','Order','Hearings of the Tribunal (REAT, Punjab) through virtual mode','ਆਰਡਰ','ਟ੍ਰਿਬਿਊਨਲ (ਰੀਟ, ਪੰਜਾਬ) ਦੀਆਂ ਸੁਣਵਾਈਆਂ ਵਰਚੁਅਲ ਮੋਡ ਰਾਹੀਂ','~/','pdf/circulars-reatpb\\','20220105PublicNoticeHearingTribunalVirtual.pdf','.pdf','','',1,1,'ReatAdmin','2025-08-07 09:55:07.000','ReatAdmin','2025-08-07 09:55:07.000'),(6,106,'PB','Notice','2022-01-14 00:00:00.000','Public Notice','Public Notice - Real Estate Appellate Tribunal, Punjab','ਜਨਤਕ ਨੋਟਿਸ','ਜਨਤਕ ਨੋਟਿਸ - ਰੀਅਲ ਅਸਟੇਟ ਅਪੀਲ ਟ੍ਰਿਬਿਊਨਲ, ਪੰਜਾਬ','~/','pdf/circulars-reatpb\\','20220114PublicNoticeREATPunjab.pdf','.pdf','','',1,1,'ReatAdmin','2025-08-07 09:55:07.000','ReatAdmin','2025-08-07 09:55:07.000'),(7,107,'PB','Notice','2022-06-01 00:00:00.000','Public Notice','Public Notice regarding the filing of appeals or applications before Real Estate Appellate Tribunal Punjab','ਜਨਤਕ ਨੋਟਿਸ','ਰੀਅਲ ਐਸਟੇਟ ਅਪੀਲੀ ਅਦਾਲਤ ਪੰਜਾਬ ਅੱਗੇ ਅਪੀਲਾਂ ਜਾਂ ਅਰਜ਼ੀਆਂ ਦਾਇਰ ਕਰਨ ਸੰਬੰਧੀ ਜਨਤਕ ਸੂਚਨਾ','~/','pdf/circulars-reatpb\\','20220602PublicNoticeFilingAppealsApplications.pdf','.pdf','','',1,1,'ReatAdmin','2025-08-07 09:55:07.000','ReatAdmin','2025-08-07 09:55:07.000'),(8,108,'PB','Notice','2023-09-18 00:00:00.000','Public Notice','Public Notice regarding the appeals before Real Estate Appellate Tribunal Punjab','ਜਨਤਕ ਨੋਟਿਸ','ਰੀਅਲ ਅਸਟੇਟ ਅਪੀਲੀ ਟ੍ਰਿਬਿਊਨਲ ਪੰਜਾਬ ਦੇ ਸਾਹਮਣੇ ਅਪੀਲਾਂ ਸੰਬੰਧੀ ਜਨਤਕ ਨੋਟਿਸ','~/','pdf/circulars-reatpb\\','20230918PbATpublicNoticeForHearing2023ud.pdf','.pdf','','',1,1,'ReatAdmin','2025-08-07 09:55:07.000','ReatAdmin','2025-08-07 09:55:07.000'),(9,109,'PB','Notice','2023-11-07 00:00:00.000','Public Notice','Revised Check-list regarding fresh Appeals before Real Estate Appellate Tribunal Punjab for compliance by counsel for appellants/appellant w.e.f. 09.11.2023','ਜਨਤਕ ਨੋਟਿਸ','ਅਪੀਲਕਰਤਾਵਾਂ/ਅਪੀਲਕਰਤਾ ਦੇ ਵਕੀਲ ਦੁਆਰਾ ਪਾਲਣਾ ਲਈ ਰੀਅਲ ਅਸਟੇਟ ਅਪੀਲੀ ਟ੍ਰਿਬਿਊਨਲ ਪੰਜਾਬ ਦੇ ਸਾਹਮਣੇ ਤਾਜ਼ਾ ਅਪੀਲਾਂ ਸੰਬੰਧੀ ਸੋਧੀ ਹੋਈ ਚੈੱਕ-ਲਿਸਟ 09.11.2023 ਤੋਂ','~/','pdf/circulars-reatpb\\','20231107PbATpublicNoticeForChecklistforAppeals2023.pdf','.pdf','','',1,1,'ReatAdmin','2025-08-07 09:55:07.000','ReatAdmin','2025-08-07 09:55:07.000'),(10,110,'PB','Notice','2024-04-01 00:00:00.000','Public Notice','Public Notice - Real Estate Appellate Tribunal Punjab','ਜਨਤਕ ਨੋਟਿਸ','ਜਨਤਕ ਨੋਟਿਸ - ਰੀਅਲ ਅਸਟੇਟ ਅਪੀਲ ਟ੍ਰਿਬਿਊਨਲ ਪੰਜਾਬ','~/','pdf/circulars-reatpb\\','20240401PublicNoticePBREATNOTCE.pdf','.pdf','','',1,1,'ReatAdmin','2025-08-07 09:55:07.000','ReatAdmin','2025-08-07 09:55:07.000');
/*!40000 ALTER TABLE `tbl_reat_webapplication_circularpublicnotices` ENABLE KEYS */;
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
