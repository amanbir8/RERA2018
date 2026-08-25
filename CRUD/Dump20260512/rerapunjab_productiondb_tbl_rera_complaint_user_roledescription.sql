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
-- Table structure for table `tbl_rera_complaint_user_roledescription`
--

DROP TABLE IF EXISTS `tbl_rera_complaint_user_roledescription`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_complaint_user_roledescription` (
  `ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `User_ID` varchar(60) NOT NULL,
  `Role_ID` varchar(60) NOT NULL,
  `IsMemberSG` varchar(60) DEFAULT NULL,
  `IsMemberJSK` varchar(60) DEFAULT NULL,
  `IsMemberChairperson` varchar(60) DEFAULT NULL,
  `IsMemberReraSectt` varchar(60) DEFAULT NULL,
  `A_column` varchar(60) DEFAULT NULL,
  `B_column` varchar(60) DEFAULT NULL,
  `C_column` varchar(60) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `CreatedBy` varchar(100) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(100) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_complaint_user_roledescription`
--

LOCK TABLES `tbl_rera_complaint_user_roledescription` WRITE;
/*!40000 ALTER TABLE `tbl_rera_complaint_user_roledescription` DISABLE KEYS */;
INSERT INTO `tbl_rera_complaint_user_roledescription` VALUES (1,'4f7ebbc2-407b-44de-ba40-0f813742e467','97eba4f1-7be4-4ba2-848d-8ad65a317455','0','0','1','0','pschairperson','0','0',1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(2,'6af0b3dc-4139-4048-91db-3de967a7484b','97eba4f1-7be4-4ba2-848d-8ad65a317455','1','0','0','0','psmembersg','0','0',1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(3,'ba8c0852-26b2-41ba-b95a-742c041a1afc','97eba4f1-7be4-4ba2-848d-8ad65a317455','0','1','0','0','psmemberjsk','0','0',1,1,'sysadmin','2018-07-25 13:08:00.000','sysadmin','2018-07-25 13:08:00.000'),(4,'5d3b4f29-7217-476b-83f2-0db85d2b90ad','97eba4f1-7be4-4ba2-848d-8ad65a317455','0','1','0','0','pamemberaps','0','0',1,1,'sysadmin','2021-12-01 10:10:00.000','sysadmin','2021-12-01 10:10:00.000'),(5,'f80f0d57-3bcc-4b2e-9452-4fffacbba5c6','97eba4f1-7be4-4ba2-848d-8ad65a317455','0','1','0','0','psmemberaps','0','0',1,1,'sysadmin','2021-12-01 10:10:00.000','sysadmin','2021-12-01 10:10:00.000'),(6,'fa53d766-d3ae-4b3d-9c62-022d4391f561','97eba4f1-7be4-4ba2-848d-8ad65a317455','0','0','0','1','executiveassistantao','0','0',1,1,'sysadmin','2021-12-01 10:10:00.000','sysadmin','2021-12-01 10:10:00.000'),(7,'2e8251d9-e943-4dc6-b922-e2da35e0cca6','97eba4f1-7be4-4ba2-848d-8ad65a317455','0','0','0','1','readerao.rera','0','0',1,1,'sysadmin','2021-12-01 10:10:00.000','sysadmin','2021-12-01 10:10:00.000');
/*!40000 ALTER TABLE `tbl_rera_complaint_user_roledescription` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:50
