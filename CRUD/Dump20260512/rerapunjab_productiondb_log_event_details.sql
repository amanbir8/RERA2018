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
-- Table structure for table `log_event_details`
--

DROP TABLE IF EXISTS `log_event_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `log_event_details` (
  `event_id` int(11) NOT NULL AUTO_INCREMENT,
  `logid` int(11) NOT NULL,
  `menu_name` varchar(255) NOT NULL,
  `action` varchar(255) NOT NULL,
  `remarks` longtext,
  `json` longtext,
  `date_added` datetime NOT NULL,
  PRIMARY KEY (`event_id`),
  KEY `logid` (`logid`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `log_event_details`
--

LOCK TABLES `log_event_details` WRITE;
/*!40000 ALTER TABLE `log_event_details` DISABLE KEYS */;
INSERT INTO `log_event_details` VALUES (1,8,'PaymentReports','Display_ePayProjectPaymentMIS','','','2026-03-26 12:37:08'),(2,9,'PaymentReports','Display_ePayProjectPaymentMIS','','','2026-03-26 14:52:25'),(3,11,'PaymentReports','Display_ePayProjectPaymentMIS','','','2026-03-26 14:59:08'),(4,12,'PaymentReports','Display_ePayProjectPaymentMIS','','','2026-03-26 15:02:12'),(8,14,'PaymentReports','Display_ePayProjectPaymentMIS','','','2026-03-26 15:11:28'),(9,14,'PaymentReports','Display_ePayProjectPaymentMIS','','','2026-03-26 15:11:40'),(10,15,'PaymentReports','Display_ePayProjectPaymentMIS','','','2026-03-26 15:30:07'),(11,17,'PaymentReports','Display_ePayProjectPaymentMIS','','','2026-03-26 15:42:09'),(12,19,'PaymentReports','Display_ePayProjectPaymentMIS','','','2026-03-26 15:52:04'),(13,19,'PaymentReports','Display_ePayProjectPaymentMIS','','','2026-03-26 15:52:11'),(14,19,'PaymentReports','Display_ePayProjectPaymentMIS','','','2026-03-26 15:52:17'),(15,20,'PaymentReports','Display_ePayProjectPaymentMIS','','','2026-03-26 16:00:08'),(16,25,'PaymentReports','Display_ePayProjectPaymentMIS','','','2026-03-26 16:23:13'),(17,25,'PaymentReports','Display_ePayProjectPaymentMIS','','','2026-03-26 16:23:50'),(18,25,'PaymentReports','Display_ePayProjectPaymentMIS','','','2026-03-26 16:24:00'),(19,25,'PaymentReports','Display_ePayProjectPaymentMIS','','','2026-03-26 16:24:11'),(20,4,'PaymentReports','Display_ePayProjectPaymentMIS','','','2026-04-07 10:51:57');
/*!40000 ALTER TABLE `log_event_details` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:23
