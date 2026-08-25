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
-- Table structure for table `tbl_rera_master_project_registrationareazone`
--

DROP TABLE IF EXISTS `tbl_rera_master_project_registrationareazone`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_project_registrationareazone` (
  `Zone_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `Zone_ID` int(11) NOT NULL,
  `Zone_TitleCode` int(11) NOT NULL,
  `Zone_TitleName` varchar(450) NOT NULL,
  `Zone_StateID` int(11) NOT NULL,
  `Mode` varchar(50) NOT NULL,
  `ActRegulationReference` varchar(250) NOT NULL,
  `ResidentialPlotted_ChargesPerSquareYard` decimal(18,2) NOT NULL,
  `GroupHousing_ChargesPerSquareYard` decimal(18,2) NOT NULL,
  `Commercial_ChargesPerSquareYard` decimal(18,2) NOT NULL,
  `Industrial_ChargesPerSquareYard` decimal(18,2) NOT NULL,
  `CommonArea_ChargesPerSquareYard` decimal(18,2) NOT NULL,
  `ClubSchoolBuliding_ChargesPerSquareYard` decimal(18,2) NOT NULL,
  `EWS_ChargesPerSquareYard` decimal(18,2) NOT NULL,
  `A_ChargesPerSquareYard` decimal(18,2) NOT NULL,
  `B_ChargesPerSquareYard` decimal(18,2) NOT NULL,
  `Fee_ValidCode` int(11) NOT NULL,
  `RemarksIfAny` varchar(250) NOT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`Zone_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_project_registrationareazone`
--

LOCK TABLES `tbl_rera_master_project_registrationareazone` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_project_registrationareazone` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_project_registrationareazone` VALUES (1,1001,1,'Zone 1 - Master Plan Area of S.A.S.Nagar, Mullanpur and Zirakpur  / Ludhiana within and outside M.C Limits upto 15 Kms.',28,'Zone 1','Regulation 2017',3.00,5.00,10.00,2.00,0.00,10.00,5.00,0.00,0.00,2,'NA',2,0,1,'sysadmin','2018-01-17 00:00:00.000','sysadmin','2020-10-17 14:58:37.000'),(2,1002,2,'Zone 2 - Jalandhar within and outside M.C Limits upto 10 Kms./Master Plan Area of Kharar, DeraBassi and Banur.',28,'Zone 2','Regulation 2017',2.00,4.00,8.00,1.50,0.00,8.00,4.00,0.00,0.00,2,'NA',2,0,1,'sysadmin','2018-01-17 00:00:00.000','sysadmin','2020-10-17 14:58:37.000'),(3,1003,3,'Zone 3 - Amritsar, Patiala, Khanna, Rajpura, MandiGobindgarh, Sirhind and Phagwara within and outside M.C Limits upto 7 Kms and NH-1 upto 2Kms on both sides, outside any potential zone.',28,'Zone 3','Regulation 2017',2.00,4.00,6.00,1.50,0.00,6.00,4.00,0.00,0.00,2,'NA',2,0,1,'sysadmin','2018-01-17 00:00:00.000','sysadmin','2020-10-17 14:58:37.000'),(4,1004,4,'Zone 4 - Bathinda, Moga, Batala, Pathankot, Barnala, Malerkotla, Morinda, Hoshiarpur, within and outside M.C Limits upto 5 Kms.',28,'Zone 4','Regulation 2017',2.00,3.00,4.00,1.00,0.00,4.00,3.00,0.00,0.00,2,'NA',2,0,1,'sysadmin','2018-01-17 00:00:00.000','sysadmin','2020-10-17 14:58:37.000'),(5,1005,5,'Zone 5 - Sangrur, Sunam, Nabha, Faridkot, Kotkapura, Ferozepur, Malout, Abohar, Sri Mukatsar Sahib, Kapurthala, NawanShahar, Ropar, Tarn Taran, Gurdaspur, Samana, Jagraon, Mansa, Lalru, Kurali within and outside M.C Limits upto 3 Kms and All other NH (except NH 1)/SH/Scheduled Roads upto 1 Kms both sides, outside any potential zone.',28,'Zone 5','Regulation 2017',1.00,2.00,3.00,1.00,0.00,3.00,2.00,0.00,0.00,2,'NA',2,0,1,'sysadmin','2018-01-17 00:00:00.000','sysadmin','2020-10-17 14:58:37.000'),(6,1006,6,'Zone 6 - Rest of Punjab.',28,'Zone 6','Regulation 2017',1.00,2.00,3.00,1.00,0.00,3.00,2.00,0.00,0.00,2,'NA',2,0,1,'sysadmin','2018-01-17 00:00:00.000','sysadmin','2020-10-17 14:58:37.000'),(7,1007,1,'Zone 1 - Master Plan Area of S.A.S. Nagar, New Chandigarh and Zirakpur.',28,'Zone 1','Regulation 2020 (First Amendment)',3.00,5.00,10.00,2.00,0.00,10.00,5.00,0.00,0.00,2,'NA',2,0,1,'sysadmin','2020-10-17 14:58:37.000','sysadmin','2020-10-17 14:58:37.000'),(8,1008,2,'Zone 2 - Master Plan Area of Kharar, Dera Bassi and Banur.',28,'Zone 2','Regulation 2020 (First Amendment)',2.00,4.00,8.00,1.50,0.00,8.00,4.00,0.00,0.00,2,'NA',2,0,1,'sysadmin','2020-10-17 14:58:37.000','sysadmin','2020-10-17 14:58:37.000'),(9,1009,3,'Zone 3 - Ludhiana (within and outside municipal limits upto 15 Kms.)',28,'Zone 3','Regulation 2020 (First Amendment)',3.00,5.00,10.00,2.00,0.00,10.00,5.00,0.00,0.00,2,'NA',2,0,1,'sysadmin','2020-10-17 14:58:37.000','sysadmin','2020-10-17 14:58:37.000'),(10,1010,4,'Zone 4 - Jalandhar (within and outside municipal limits upto 10 Kms.)',28,'Zone 4','Regulation 2020 (First Amendment)',2.00,4.00,8.00,1.50,0.00,8.00,4.00,0.00,0.00,2,'NA',2,0,1,'sysadmin','2020-10-17 14:58:37.000','sysadmin','2020-10-17 14:58:37.000'),(11,1011,5,'Zone 5 - Amritsar, Patiala, Khanna, Rajpura, Mandi Gobindgarh, Sirhind and Phagwara within and outside municipal limits upto 7 Kms and NH-1 upto 2 Kms on both sides, outside the potential zone.',28,'Zone 5','Regulation 2020 (First Amendment)',2.00,4.00,6.00,1.50,0.00,6.00,4.00,0.00,0.00,2,'NA',2,0,1,'sysadmin','2020-10-17 14:58:37.000','sysadmin','2020-10-17 14:58:37.000'),(12,1012,6,'Zone 6 - Bathinda, Moga, Batala, Pathankot, Barnala, Malerkotla, Morinda, Hoshiarpur, within and outside municipal limits upto 5 Kms.',28,'Zone 6','Regulation 2020 (First Amendment)',2.00,3.00,4.00,1.00,0.00,4.00,3.00,0.00,0.00,2,'NA',2,0,1,'sysadmin','2020-10-17 14:58:37.000','sysadmin','2020-10-17 14:58:37.000'),(13,1013,7,'Zone 7 - Sangrur, Sunam Udham Singh Wala, Nabha, Faridkot, Kotkapura, Ferozepur, Malout, Abohar, Sri Muktsar Sahib, Kapurthala, Nawanshahr, Rupnagar, Taran Taran, Gurdaspur, Samana, Jagraon, Mansa, Lalru, Kurali within and outside municipal limits upto 3 Kms and all other NH (except NH 1)/SH/Scheduled Roads upto 1 Kms both sides, outside the potential zone.',28,'Zone 7','Regulation 2020 (First Amendment)',1.00,2.00,3.00,1.00,0.00,3.00,2.00,0.00,0.00,2,'NA',2,0,1,'sysadmin','2020-10-17 14:58:37.000','sysadmin','2020-10-17 14:58:37.000'),(14,1014,8,'Zone 8 - Rest of Punjab.',28,'Zone 8','Regulation 2020 (First Amendment)',1.00,2.00,3.00,1.00,0.00,3.00,2.00,0.00,0.00,2,'NA',2,0,1,'sysadmin','2020-10-17 14:58:37.000','sysadmin','2020-10-17 14:58:37.000'),(15,1015,1,'Zone 1 - Master Plan Area of S.A.S. Nagar, New Chandigarh and Zirakpur.',28,'Zone 1','Regulation, Rules 2017 (Amendment dt 29.06.2022)',6.00,10.00,20.00,4.00,0.00,20.00,10.00,0.00,0.00,1,'NA',1,0,1,'sysadmin','2022-07-21 10:10:00.000','sysadmin','2022-07-21 10:10:00.000'),(16,1016,2,'Zone 2 - Master Plan Area of Kharar, Dera Bassi and Banur.',28,'Zone 2','Regulation, Rules 2017 (Amendment dt 29.06.2022)',4.00,8.00,16.00,3.00,0.00,16.00,8.00,0.00,0.00,1,'NA',1,0,1,'sysadmin','2022-07-21 10:10:00.000','sysadmin','2022-07-21 10:10:00.000'),(17,1017,3,'Zone 3 - Ludhiana (within and outside municipal limits upto 10 Kms.)',28,'Zone 3','Regulation, Rules 2017 (Amendment dt 29.06.2022)',6.00,10.00,20.00,4.00,0.00,20.00,10.00,0.00,0.00,1,'NA',1,0,1,'sysadmin','2022-07-21 10:10:00.000','sysadmin','2022-07-21 10:10:00.000'),(18,1018,4,'Zone 4 - Jalandhar (within and outside municipal limits upto 10 Kms.)',28,'Zone 4','Regulation, Rules 2017 (Amendment dt 29.06.2022)',4.00,8.00,16.00,3.00,0.00,16.00,8.00,0.00,0.00,1,'NA',1,0,1,'sysadmin','2022-07-21 10:10:00.000','sysadmin','2022-07-21 10:10:00.000'),(19,1019,5,'Zone 5 - Amritsar, Patiala, Khanna, Rajpura, Mandi Gobindgarh, Sirhind and Phagwara within and outside municipal limits upto 7 Kms and NH-1 upto 2 Kms on both sides, outside the potential zone.',28,'Zone 5','Regulation, Rules 2017 (Amendment dt 29.06.2022)',4.00,8.00,12.00,3.00,0.00,12.00,8.00,0.00,0.00,1,'NA',1,0,1,'sysadmin','2022-07-21 10:10:00.000','sysadmin','2022-07-21 10:10:00.000'),(20,1020,6,'Zone 6 - Bathinda, Moga, Batala, Pathankot, Barnala, Malerkotla, Morinda, Hoshiarpur, within and outside municipal limits upto 5 Kms.',28,'Zone 6','Regulation, Rules 2017 (Amendment dt 29.06.2022)',4.00,6.00,8.00,2.00,0.00,8.00,6.00,0.00,0.00,1,'NA',1,0,1,'sysadmin','2022-07-21 10:10:00.000','sysadmin','2022-07-21 10:10:00.000'),(21,1021,7,'Zone 7 - Sangrur, Sunam Udham Singh Wala, Nabha, Faridkot, Kotkapura, Ferozepur, Malout, Abohar, Sri Muktsar Sahib, Kapurthala, Nawanshahr, Rupnagar, Taran Taran, Gurdaspur, Samana, Jagraon, Mansa, Lalru, Kurali within and outside municipal limits upto 3 Kms and all other NH (except NH 1)/SH/Scheduled Roads upto 1 Kms both sides, outside the potential zone.',28,'Zone 7','Regulation, Rules 2017 (Amendment dt 29.06.2022)',2.00,4.00,6.00,2.00,0.00,6.00,4.00,0.00,0.00,1,'NA',1,0,1,'sysadmin','2022-07-21 10:10:00.000','sysadmin','2022-07-21 10:10:00.000'),(22,1022,8,'Zone 8 - Rest of Punjab.',28,'Zone 8','Regulation, Rules 2017 (Amendment dt 29.06.2022)',2.00,4.00,6.00,2.00,0.00,6.00,4.00,0.00,0.00,1,'NA',1,0,1,'sysadmin','2022-07-21 10:10:00.000','sysadmin','2022-07-21 10:10:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_project_registrationareazone` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:30
