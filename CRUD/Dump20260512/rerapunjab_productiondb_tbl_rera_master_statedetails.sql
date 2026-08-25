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
-- Table structure for table `tbl_rera_master_statedetails`
--

DROP TABLE IF EXISTS `tbl_rera_master_statedetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_statedetails` (
  `State_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `State_Code` int(11) NOT NULL,
  `State_Name` varchar(50) NOT NULL,
  `IsActive` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`State_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=77 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_statedetails`
--

LOCK TABLES `tbl_rera_master_statedetails` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_statedetails` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_statedetails` VALUES (40,1,'Andaman & Nicobar Islands',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(41,2,'Andhra Pradesh',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(42,3,'Arunachal Pradesh',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(43,4,'Assam',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(44,5,'Bihar',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(45,6,'Chandigarh',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(46,7,'Chhattisgarh',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(47,8,'Dadra & Nagar Haveli',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(48,9,'Daman & Diu',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(49,10,'Delhi',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(50,11,'Goa',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(51,12,'Gujarat',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(52,13,'Haryana',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(53,14,'Himachal Pradesh',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(54,15,'Jammu & Kashmir',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(55,16,'Jharkhand',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(56,17,'Karnataka',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(57,18,'Kerala',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(58,19,'Lakshadweep',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(59,20,'Madhya Pradesh',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(60,21,'Maharashtra',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(61,22,'Manipur',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(62,23,'Meghalaya',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(63,24,'Mizoram',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(64,25,'Nagaland',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(65,26,'Odisha',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(66,27,'Puducherry',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(67,28,'Punjab',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(68,29,'Rajasthan',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(69,30,'Sikkim',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(70,31,'Tamil Nadu',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(71,32,'Tripura',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(72,33,'Uttar Pradesh',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(73,34,'Uttarakhand',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(74,35,'West Bengal',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(76,36,'Other',1,'sysadmin','2019-01-17 13:08:00.000','sysadmin','2019-01-17 13:08:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_statedetails` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:44
