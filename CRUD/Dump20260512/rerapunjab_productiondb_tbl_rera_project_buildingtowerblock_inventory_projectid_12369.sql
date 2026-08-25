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
-- Table structure for table `tbl_rera_project_buildingtowerblock_inventory_projectid_12369`
--

DROP TABLE IF EXISTS `tbl_rera_project_buildingtowerblock_inventory_projectid_12369`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_project_buildingtowerblock_inventory_projectid_12369` (
  `ProjectInventory_IndexID` bigint(20) NOT NULL,
  `ProjectInventory_ID` bigint(20) NOT NULL,
  `ProjectInventoryRelated_ProjectRegistration_ID` bigint(20) NOT NULL,
  `BuildingTowerBlock_Name` varchar(50) NOT NULL,
  `ApartmentShopPlot_Type` varchar(100) NOT NULL,
  `ApartmentShopPlot_CarpetArea` decimal(12,3) NOT NULL,
  `ApartmentShopPlot_ExclusiveOpenTerraceArea` decimal(12,3) NOT NULL,
  `ApartmentShopPlot_ExclusiveBalconyVerandahArea` decimal(12,3) NOT NULL,
  `ApartmentShopPlot_AvailableforSaleNumber` int(11) NOT NULL,
  `ApartmentShopPlot_AlreadySoldNumber` int(11) NOT NULL,
  `Remarks_IfAny` varchar(100) DEFAULT NULL,
  `A_column` varchar(50) DEFAULT NULL,
  `B_column` varchar(50) DEFAULT NULL,
  `C_column` varchar(50) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_project_buildingtowerblock_inventory_projectid_12369`
--

LOCK TABLES `tbl_rera_project_buildingtowerblock_inventory_projectid_12369` WRITE;
/*!40000 ALTER TABLE `tbl_rera_project_buildingtowerblock_inventory_projectid_12369` DISABLE KEYS */;
INSERT INTO `tbl_rera_project_buildingtowerblock_inventory_projectid_12369` VALUES (65230,54635,12369,'Third Floor','Studio Apartment',1092.530,0.000,0.000,30,0,'','Registration Process','2025','',1,1,'CreatedBy','2025-08-12 16:02:21.000','ModifyBy','2025-08-12 16:02:21.000'),(65235,54649,12369,'Lower Ground Floor ','Kiosk',37.160,0.000,0.000,4,0,'','Registration Process','2025','',1,1,'CreatedBy','2025-08-12 16:09:30.000','ModifyBy','2025-08-12 16:09:30.000'),(65484,54641,12369,'First Floor','Shop',861.390,0.000,0.000,73,0,'','Registration Process','2025','',1,1,'CreatedBy','2025-08-14 13:31:58.000','ModifyBy','2025-08-14 13:31:58.000'),(65486,54642,12369,'First Floor','Showroom',4212.190,0.000,0.000,129,0,'','Registration Process','2025','',1,1,'CreatedBy','2025-08-14 13:32:14.000','ModifyBy','2025-08-14 13:32:14.000'),(65488,54643,12369,'First Floor','Kiosk',195.090,0.000,0.000,45,0,'','Registration Process','2025','',1,1,'CreatedBy','2025-08-14 13:32:27.000','ModifyBy','2025-08-14 13:32:27.000'),(65490,54636,12369,'Fourth Floors','Studio Apartment',1092.530,0.000,0.000,30,0,'','Registration Process','2025','',1,1,'CreatedBy','2025-08-14 13:32:42.000','ModifyBy','2025-08-14 13:32:42.000'),(65491,54644,12369,'Ground Floor','Shop',967.210,0.000,0.000,83,0,'','Registration Process','2025','',1,1,'CreatedBy','2025-08-14 13:32:58.000','ModifyBy','2025-08-14 13:32:58.000'),(65493,54645,12369,'Ground Floor','Showroom',5220.920,0.000,0.000,147,0,'','Registration Process','2025','',1,1,'CreatedBy','2025-08-14 13:33:12.000','ModifyBy','2025-08-14 13:33:12.000'),(65494,54646,12369,'Ground Floor','Kiosk',85.840,0.000,0.000,12,0,'','Registration Process','2025','',1,1,'CreatedBy','2025-08-14 13:33:25.000','ModifyBy','2025-08-14 13:33:25.000'),(65496,54647,12369,'Lower Ground Floor ','Shop',2700.200,0.000,0.000,203,0,'','Registration Process','2025','',1,1,'CreatedBy','2025-08-14 13:33:42.000','ModifyBy','2025-08-14 13:33:42.000'),(65498,54648,12369,'Lower Ground Floor ','Showroom',2630.250,0.000,0.000,70,0,'','Registration Process','2025','',1,1,'CreatedBy','2025-08-14 13:33:57.000','ModifyBy','2025-08-14 13:33:57.000'),(65500,54637,12369,'Second Floor','Shop',596.710,0.000,0.000,45,0,'','Registration Process','2025','',1,1,'CreatedBy','2025-08-14 13:34:25.000','ModifyBy','2025-08-14 13:34:25.000'),(65502,54638,12369,'Second Floor','Restaurant',802.950,0.000,0.000,15,0,'','Registration Process','2025','',1,1,'CreatedBy','2025-08-14 13:34:37.000','ModifyBy','2025-08-14 13:34:37.000'),(65504,54639,12369,'Second Floor','Food Stall',879.130,0.000,0.000,65,0,'','Registration Process','2025','',1,1,'CreatedBy','2025-08-14 13:34:47.000','ModifyBy','2025-08-14 13:34:47.000'),(65506,54640,12369,'Second Floor','Kiosk',291.060,0.000,0.000,32,0,'','Registration Process','2025','',1,1,'CreatedBy','2025-08-14 13:34:59.000','ModifyBy','2025-08-14 13:34:59.000');
/*!40000 ALTER TABLE `tbl_rera_project_buildingtowerblock_inventory_projectid_12369` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:48
