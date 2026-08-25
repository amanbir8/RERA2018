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
-- Table structure for table `tbl_rera_master_project_inventorylist`
--

DROP TABLE IF EXISTS `tbl_rera_master_project_inventorylist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_project_inventorylist` (
  `InventoryList_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `InventoryList_ID` int(11) NOT NULL,
  `InventoryListName` varchar(200) NOT NULL,
  `InventoryListDescription` varchar(500) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` varchar(90) DEFAULT NULL,
  `CreatedOn` datetime(3) DEFAULT NULL,
  `ModifyBy` varchar(90) DEFAULT NULL,
  `ModifyOn` datetime(3) DEFAULT NULL,
  PRIMARY KEY (`InventoryList_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_project_inventorylist`
--

LOCK TABLES `tbl_rera_master_project_inventorylist` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_project_inventorylist` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_project_inventorylist` VALUES (1,1001,'Apartment','Apartment',1,'sysadmin','2020-02-04 10:51:39.000','sysadmin','2020-02-04 10:51:39.000'),(2,1002,'Commercial','Commercial',1,'sysadmin','2020-02-04 10:51:39.000','sysadmin','2020-02-04 10:51:39.000'),(3,1003,'Individual House','Individual House',1,'sysadmin','2020-02-04 10:51:39.000','sysadmin','2020-02-04 10:51:39.000'),(4,1004,'Residential Plots','Residential Plots',1,'sysadmin','2020-02-04 10:51:39.000','sysadmin','2020-02-04 10:51:39.000'),(5,1005,'Industrial Plots','Industrial Plots',1,'sysadmin','2020-02-04 10:51:39.000','sysadmin','2020-02-04 10:51:39.000'),(6,1006,'Shop','Shop',1,'sysadmin','2020-02-04 10:51:39.000','sysadmin','2020-02-04 10:51:39.000'),(7,1007,'Institutional','Institutional',1,'sysadmin','2020-02-04 10:51:39.000','sysadmin','2020-02-04 10:51:39.000'),(8,1008,'Hospitals','Hospitals',1,'sysadmin','2020-02-04 10:51:39.000','sysadmin','2020-02-04 10:51:39.000'),(9,1009,'Others','Others',1,'sysadmin','2020-02-04 10:51:39.000','sysadmin','2020-02-04 10:51:39.000'),(10,1010,'Group Housing','Group Housing',1,'sysadmin','2020-02-04 10:51:39.000','sysadmin','2020-02-04 10:51:39.000'),(11,1011,'Religious Places','Religious Places',1,'sysadmin','2020-02-04 10:51:39.000','sysadmin','2020-02-04 10:51:39.000'),(12,1012,'Schools','Schools',1,'sysadmin','2020-02-04 10:51:39.000','sysadmin','2020-02-04 10:51:39.000');
/*!40000 ALTER TABLE `tbl_rera_master_project_inventorylist` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:18
