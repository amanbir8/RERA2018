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
-- Table structure for table `tbl_rera_ldr_promoter_othermemberdetails`
--

DROP TABLE IF EXISTS `tbl_rera_ldr_promoter_othermemberdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_ldr_promoter_othermemberdetails` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Promoter_OtherMemberDetails_ID` bigint(20) DEFAULT NULL,
  `Application_ID` bigint(20) DEFAULT NULL,
  `Designation` varchar(500) DEFAULT NULL,
  `Member_Names` varchar(500) DEFAULT NULL,
  `PAN_No` varchar(500) DEFAULT NULL,
  `Aadhar_No` bigint(20) DEFAULT NULL,
  `Address_Line1` varchar(500) NOT NULL,
  `Address_Line2` varchar(500) DEFAULT NULL,
  `State` varchar(200) NOT NULL,
  `District` varchar(200) NOT NULL,
  `Pin_Code` bigint(20) NOT NULL,
  `Mobile_no` bigint(20) NOT NULL,
  `PhoneNumber_STD` bigint(20) DEFAULT NULL,
  `Phone_No` bigint(20) DEFAULT NULL,
  `Email` varchar(100) NOT NULL,
  `Image_FileName` varchar(100) DEFAULT NULL,
  `Photo_Address` varchar(500) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) DEFAULT NULL,
  `Created_By` varchar(100) NOT NULL,
  `Created_On` datetime(3) NOT NULL,
  `Modify_By` varchar(100) DEFAULT NULL,
  `Modified_On` datetime(3) DEFAULT NULL,
  `Flag` int(11) DEFAULT NULL,
  `Extra1` varchar(200) DEFAULT NULL,
  `Extra2` varchar(200) DEFAULT NULL,
  `Extra3` varchar(200) DEFAULT NULL,
  `Extra4` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_ldr_promoter_othermemberdetails`
--

LOCK TABLES `tbl_rera_ldr_promoter_othermemberdetails` WRITE;
/*!40000 ALTER TABLE `tbl_rera_ldr_promoter_othermemberdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_ldr_promoter_othermemberdetails` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:36
