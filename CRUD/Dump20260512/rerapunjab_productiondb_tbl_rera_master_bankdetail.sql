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
-- Table structure for table `tbl_rera_master_bankdetail`
--

DROP TABLE IF EXISTS `tbl_rera_master_bankdetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_bankdetail` (
  `Bank_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `Bank_Code` int(11) NOT NULL,
  `Bank_Name` varchar(50) NOT NULL,
  `IsActive` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`Bank_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_bankdetail`
--

LOCK TABLES `tbl_rera_master_bankdetail` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_bankdetail` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_bankdetail` VALUES (4,1,'Allahabad Bank',1,'by','2024-11-17 13:08:00.000','by','2024-11-17 13:08:00.000'),(5,2,'Andhra Bank',1,'by','2025-11-17 13:08:00.000','by','2025-11-17 13:08:00.000'),(6,3,'Bank of Baroda',1,'by','2026-11-17 13:08:00.000','by','2026-11-17 13:08:00.000'),(7,4,'Bank of India',1,'by','2027-11-17 13:08:00.000','by','2027-11-17 13:08:00.000'),(8,5,'Bank of Maharashtra',1,'by','2028-11-17 13:08:00.000','by','2028-11-17 13:08:00.000'),(9,6,'Canara Bank',1,'by','2029-11-17 13:08:00.000','by','2029-11-17 13:08:00.000'),(10,7,'Central Bank of India',1,'by','2030-11-17 13:08:00.000','by','2030-11-17 13:08:00.000'),(11,8,'Corporation Bank',1,'by','2001-12-17 13:08:00.000','by','2001-12-17 13:08:00.000'),(12,9,'Dena Bank',1,'by','2002-12-17 13:08:00.000','by','2002-12-17 13:08:00.000'),(13,10,'Indian Bank',1,'by','2003-12-17 13:08:00.000','by','2003-12-17 13:08:00.000'),(14,11,'Indian Overseas Bank',1,'by','2004-12-17 13:08:00.000','by','2004-12-17 13:08:00.000'),(15,12,'IDBI Bank',1,'by','2005-12-17 13:08:00.000','by','2005-12-17 13:08:00.000'),(16,13,'Oriental Bank of Commerce',1,'by','2006-12-17 13:08:00.000','by','2006-12-17 13:08:00.000'),(17,14,'Punjab and Sind Bank',1,'by','2007-12-17 13:08:00.000','by','2007-12-17 13:08:00.000'),(18,15,'Punjab National Bank',1,'by','2008-12-17 13:08:00.000','by','2008-12-17 13:08:00.000'),(19,16,'State Bank of India',1,'by','2009-12-17 13:08:00.000','by','2009-12-17 13:08:00.000'),(20,17,'Syndicate Bank',1,'by','2010-12-17 13:08:00.000','by','2010-12-17 13:08:00.000'),(21,18,'UCO Bank',1,'by','2011-12-17 13:08:00.000','by','2011-12-17 13:08:00.000'),(22,19,'Union Bank of India',1,'by','2012-12-17 13:08:00.000','by','2012-12-17 13:08:00.000'),(23,20,'United Bank of India',1,'by','2013-12-17 13:08:00.000','by','2013-12-17 13:08:00.000'),(24,21,'Vijaya Bank',1,'by','2014-12-17 13:08:00.000','by','2014-12-17 13:08:00.000'),(26,22,'Axis Bank Limited',1,'by','2015-12-17 13:08:00.000','by','2015-12-17 13:08:00.000'),(28,23,'Federal Bank Limited',1,'by','2016-12-17 13:08:00.000','by','2016-12-17 13:08:00.000'),(29,24,'HDFC Bank Limited',1,'by','2017-12-17 13:08:00.000','by','2017-12-17 13:08:00.000'),(30,25,'ICICI Bank Limited',1,'by','2018-12-17 13:08:00.000','by','2018-12-17 13:08:00.000'),(31,26,'IndusInd Bank Limited',1,'by','2019-12-17 13:08:00.000','by','2019-12-17 13:08:00.000'),(32,27,'IDFC Bank Limited',1,'by','2020-12-17 13:08:00.000','by','2020-12-17 13:08:00.000'),(33,28,'Jammu & Kashmir Bank Limited',1,'by','2021-12-17 13:08:00.000','by','2021-12-17 13:08:00.000'),(34,29,'Karnataka Bank Limited',1,'by','2022-12-17 13:08:00.000','by','2022-12-17 13:08:00.000'),(35,30,'Karur Vysya Bank Limited',1,'by','2023-12-17 13:08:00.000','by','2023-12-17 13:08:00.000'),(36,31,'Kotak Mahindra Bank Limited',1,'by','2024-12-17 13:08:00.000','by','2024-12-17 13:08:00.000'),(37,32,'Lakshmi Vilas Bank Limited',1,'by','2025-12-17 13:08:00.000','by','2025-12-17 13:08:00.000'),(38,33,'RBL Bank Limited',1,'by','2026-12-17 13:08:00.000','by','2026-12-17 13:08:00.000'),(39,34,'YES Bank Limited',1,'by','2027-12-17 13:08:00.000','by','2027-12-17 13:08:00.000'),(40,99,'Others',1,'sysadmin','2018-11-25 15:33:53.000','sysadmin','2018-11-25 15:33:53.000'),(41,35,'DCB Bank',1,'itcellrera','2022-02-25 10:00:00.000','itcellrera','2022-02-25 10:00:00.000'),(42,36,'Capital Small Finance Bank',1,'sysadmin','2024-09-09 00:00:00.000','sysadmin','2024-09-09 00:00:00.000'),(43,37,'AU Small Finance Bank',1,'sysadmin','2026-04-13 00:00:00.000','sysadmin','2026-04-13 00:00:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_bankdetail` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:05
