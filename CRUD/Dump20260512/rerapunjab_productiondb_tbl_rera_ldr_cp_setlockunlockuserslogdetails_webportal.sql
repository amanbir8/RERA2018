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
-- Table structure for table `tbl_rera_ldr_cp_setlockunlockuserslogdetails_webportal`
--

DROP TABLE IF EXISTS `tbl_rera_ldr_cp_setlockunlockuserslogdetails_webportal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_ldr_cp_setlockunlockuserslogdetails_webportal` (
  `WP_UsersLockUnLock_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `RelatedId` varchar(128) NOT NULL,
  `RelatedEmail` varchar(256) DEFAULT NULL,
  `RelatedEmailConfirmed` tinyint(1) NOT NULL,
  `RelatedPhoneNumber` longtext,
  `RelatedPhoneNumberConfirmed` tinyint(1) NOT NULL,
  `RelatedLockoutEndDateUtc` datetime DEFAULT NULL,
  `RelatedLockoutEnabled` tinyint(1) NOT NULL,
  `RelatedUserName` varchar(256) NOT NULL,
  `PublicUnpublicValue` varchar(50) NOT NULL,
  `UserID` varchar(100) NOT NULL,
  `Remarks_IfAny` varchar(500) DEFAULT NULL,
  `PVMsg_IfAny` varchar(250) DEFAULT NULL,
  `A_Column` varchar(100) DEFAULT NULL,
  `B_Column` varchar(100) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`WP_UsersLockUnLock_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_ldr_cp_setlockunlockuserslogdetails_webportal`
--

LOCK TABLES `tbl_rera_ldr_cp_setlockunlockuserslogdetails_webportal` WRITE;
/*!40000 ALTER TABLE `tbl_rera_ldr_cp_setlockunlockuserslogdetails_webportal` DISABLE KEYS */;
INSERT INTO `tbl_rera_ldr_cp_setlockunlockuserslogdetails_webportal` VALUES (1,'a40d2d83-c481-4688-9f7d-1b75b4f95f51','csvedparkash@gmail.com',0,NULL,0,'2018-10-30 23:06:15',0,'ashokkumar1','1','f193be5c-b13c-42ce-8d73-4a045acb493b','Email confirmation of the web-portal user details','Email confirm request','','',1,0,'admprogrammer.rera','2020-12-12 18:09:00.000','admprogrammer.rera','2020-12-12 18:09:00.000'),(2,'a40d2d83-c481-4688-9f7d-1b75b4f95f51','csvedparkash@gmail.com',1,NULL,0,'2018-10-30 23:06:15',0,'ashokkumar1','0','f193be5c-b13c-42ce-8d73-4a045acb493b','Email confirmation of the web-portal user details','Email disconfirm request','','',1,0,'admprogrammer.rera','2020-12-12 18:09:17.000','admprogrammer.rera','2020-12-12 18:09:17.000');
/*!40000 ALTER TABLE `tbl_rera_ldr_cp_setlockunlockuserslogdetails_webportal` ENABLE KEYS */;
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
