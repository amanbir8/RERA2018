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
-- Table structure for table `tbl_rera_master_project_inventoryinfracommonlist`
--

DROP TABLE IF EXISTS `tbl_rera_master_project_inventoryinfracommonlist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_project_inventoryinfracommonlist` (
  `InventoryList_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `InventoryList_ID` int(11) NOT NULL,
  `InventoryListName` varchar(200) NOT NULL,
  `InventoryListDescription` varchar(500) DEFAULT NULL,
  `InventoryFlag` int(11) NOT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` varchar(90) DEFAULT NULL,
  `CreatedOn` datetime(3) DEFAULT NULL,
  `ModifyBy` varchar(90) DEFAULT NULL,
  `ModifyOn` datetime(3) DEFAULT NULL,
  PRIMARY KEY (`InventoryList_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_project_inventoryinfracommonlist`
--

LOCK TABLES `tbl_rera_master_project_inventoryinfracommonlist` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_project_inventoryinfracommonlist` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_project_inventoryinfracommonlist` VALUES (1,2001,'Park','Park',1,1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(2,2002,'Emergency Evacuation','Emergency Evacuation',1,1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(3,2003,'Street Lighting','Street Lighting',1,1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(4,2004,'Swimming pool','Swimming pool',1,1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(5,2005,'Club House','Club House',1,1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(6,2006,'Gym (Gymnasium)','Gym (Gymnasium)',1,1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(7,2007,'Fire Fighting','Fire Fighting',1,1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(8,2008,'Rain Water Harvesting','Rain Water Harvesting',1,1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(9,2009,'Play Area','Play Area',1,1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(10,2010,'Use for Renewable Energy','Use for Renewable Energy',1,1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(11,2011,'Drinking Water','Drinking Water',1,1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(12,2012,'Religious Places','Religious Places',1,1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(13,2013,'Sewerage and Drainage System','Sewerage and Drainage System',1,1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(14,2014,'Other','Other',1,1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000'),(15,2015,'Internal Roads','Internal Roads',1,1,'sysadmin','2020-02-05 13:00:00.000','sysadmin','2020-02-05 13:00:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_project_inventoryinfracommonlist` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:21
