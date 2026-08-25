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
-- Table structure for table `tbl_rera_master_project_documents_trackfiltercounter`
--

DROP TABLE IF EXISTS `tbl_rera_master_project_documents_trackfiltercounter`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_project_documents_trackfiltercounter` (
  `ProjectDocCountMaster_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `ProjectDocCountMaster_InfoCode` int(11) NOT NULL,
  `ProjectDocCountMaster_InfoTitle` varchar(150) DEFAULT NULL,
  `DocFilter_ProjectStatus_OnGoing` varchar(50) NOT NULL,
  `DocFilter_AOS_AsFormat` varchar(50) NOT NULL,
  `DocFilter_Encumbrances` varchar(50) NOT NULL,
  `DocFilter_MegaProject` varchar(50) NOT NULL,
  `DocFilter_LandStatus_OwnByPromoter` varchar(50) NOT NULL,
  `DocFilter_A_Column` varchar(50) DEFAULT NULL,
  `DocFilter_B_Column` varchar(50) DEFAULT NULL,
  `DocFilter_C_Column` varchar(50) DEFAULT NULL,
  `ProjectDoc_ValidCounterNumber` int(11) NOT NULL,
  `ProjectDoc_ValidSubCounterNumber` int(11) NOT NULL,
  `IsGroup` int(11) NOT NULL,
  `A_column` varchar(500) DEFAULT NULL,
  `B_column` varchar(50) DEFAULT NULL,
  `C_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ProjectDocCountMaster_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=96 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_project_documents_trackfiltercounter`
--

LOCK TABLES `tbl_rera_master_project_documents_trackfiltercounter` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_project_documents_trackfiltercounter` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_project_documents_trackfiltercounter` VALUES (48,1901,'Project Document','N','N','N','N','N',NULL,NULL,NULL,17,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(49,1902,'Project Document','N','N','N','N','Y',NULL,NULL,NULL,16,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(50,1903,'Project Document','N','N','N','N','A',NULL,NULL,NULL,19,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(51,1904,'Project Document','N','N','N','Y','N',NULL,NULL,NULL,15,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(52,1905,'Project Document','N','N','N','Y','Y',NULL,NULL,NULL,14,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(53,1906,'Project Document','N','N','N','Y','A',NULL,NULL,NULL,17,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(54,1907,'Project Document','N','N','Y','N','N',NULL,NULL,NULL,17,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(55,1908,'Project Document','N','N','Y','N','Y',NULL,NULL,NULL,16,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(56,1909,'Project Document','N','N','Y','N','A',NULL,NULL,NULL,19,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(57,1910,'Project Document','N','N','Y','Y','N',NULL,NULL,NULL,15,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(58,1911,'Project Document','N','N','Y','Y','Y',NULL,NULL,NULL,14,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(59,1912,'Project Document','N','N','Y','Y','A',NULL,NULL,NULL,17,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(60,1913,'Project Document','N','Y','N','N','N',NULL,NULL,NULL,17,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(61,1914,'Project Document','N','Y','N','N','Y',NULL,NULL,NULL,16,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(62,1915,'Project Document','N','Y','N','N','A',NULL,NULL,NULL,19,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(63,1916,'Project Document','N','Y','N','Y','N',NULL,NULL,NULL,15,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(64,1917,'Project Document','N','Y','N','Y','Y',NULL,NULL,NULL,14,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(65,1918,'Project Document','N','Y','N','Y','A',NULL,NULL,NULL,17,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(66,1919,'Project Document','N','Y','Y','N','N',NULL,NULL,NULL,17,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(67,1920,'Project Document','N','Y','Y','N','Y',NULL,NULL,NULL,16,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(68,1921,'Project Document','N','Y','Y','N','A',NULL,NULL,NULL,19,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(69,1922,'Project Document','N','Y','Y','Y','N',NULL,NULL,NULL,15,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(70,1923,'Project Document','N','Y','Y','Y','Y',NULL,NULL,NULL,14,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(71,1924,'Project Document','N','Y','Y','Y','A',NULL,NULL,NULL,17,0,1,' ',NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(72,1925,'Project Document','Y','N','N','N','N',NULL,NULL,NULL,19,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(73,1926,'Project Document','Y','N','N','N','Y',NULL,NULL,NULL,18,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(74,1927,'Project Document','Y','N','N','N','A',NULL,NULL,NULL,21,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(75,1928,'Project Document','Y','N','N','Y','N',NULL,NULL,NULL,17,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(76,1929,'Project Document','Y','N','N','Y','Y',NULL,NULL,NULL,16,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(77,1930,'Project Document','Y','N','N','Y','A',NULL,NULL,NULL,19,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(78,1931,'Project Document','Y','N','Y','N','N',NULL,NULL,NULL,19,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(79,1932,'Project Document','Y','N','Y','N','Y',NULL,NULL,NULL,18,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(80,1933,'Project Document','Y','N','Y','N','A',NULL,NULL,NULL,21,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(81,1934,'Project Document','Y','N','Y','Y','N',NULL,NULL,NULL,17,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(82,1935,'Project Document','Y','N','Y','Y','Y',NULL,NULL,NULL,16,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(83,1936,'Project Document','Y','N','Y','Y','A',NULL,NULL,NULL,19,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(84,1937,'Project Document','Y','Y','N','N','N',NULL,NULL,NULL,19,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(85,1938,'Project Document','Y','Y','N','N','Y',NULL,NULL,NULL,18,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(86,1939,'Project Document','Y','Y','N','N','A',NULL,NULL,NULL,21,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(87,1940,'Project Document','Y','Y','N','Y','N',NULL,NULL,NULL,17,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(88,1941,'Project Document','Y','Y','N','Y','Y',NULL,NULL,NULL,16,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(89,1942,'Project Document','Y','Y','N','Y','A',NULL,NULL,NULL,19,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(90,1943,'Project Document','Y','Y','Y','N','N',NULL,NULL,NULL,19,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(91,1944,'Project Document','Y','Y','Y','N','Y',NULL,NULL,NULL,18,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(92,1945,'Project Document','Y','Y','Y','N','A',NULL,NULL,NULL,21,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(93,1946,'Project Document','Y','Y','Y','Y','N',NULL,NULL,NULL,17,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(94,1947,'Project Document','Y','Y','Y','Y','Y',NULL,NULL,NULL,16,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000'),(95,1948,'Project Document','Y','Y','Y','Y','A',NULL,NULL,NULL,19,0,1,NULL,NULL,NULL,1,'sysadmin','2018-05-31 13:08:00.000','sysadmin','2018-05-31 13:08:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_project_documents_trackfiltercounter` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:10
