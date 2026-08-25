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
-- Table structure for table `tbl_rera_master_project_formextension_subchecklist`
--

DROP TABLE IF EXISTS `tbl_rera_master_project_formextension_subchecklist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_project_formextension_subchecklist` (
  `SubCheckList_IndexID` int(11) NOT NULL AUTO_INCREMENT,
  `SubCheckList_ID` int(11) NOT NULL,
  `SubCheckListName` varchar(200) NOT NULL,
  `SubCheckListDescription` varchar(500) DEFAULT NULL,
  `CheckList_ID` int(11) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` varchar(200) DEFAULT NULL,
  `CreatedOn` datetime(3) DEFAULT NULL,
  `ModifyBy` varchar(200) DEFAULT NULL,
  `ModifyOn` datetime(3) DEFAULT NULL,
  PRIMARY KEY (`SubCheckList_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_project_formextension_subchecklist`
--

LOCK TABLES `tbl_rera_master_project_formextension_subchecklist` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_project_formextension_subchecklist` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_project_formextension_subchecklist` VALUES (1,9101,'Copy of Approved Layout plan (Revised Layout, if any)','Authenticated Plan of the project showning the stage of development works undertaken till date (a) Copy of Approved Layout plan (Revised Layout, if any)',5101,1,'sysadmin','2019-11-17 13:08:00.000','sysadmin','2019-11-17 13:08:00.000'),(2,9102,'State of development work and reason for not completing (explanatory note)','Explanatory note reagrding the state of development works in the project and reason for not completing the development works in the project within the period declared in the declaration submitted in Form B at the time of registration of project [Rule 6 (2)]',5101,1,'sysadmin','2019-11-17 13:08:00.000','sysadmin','2019-11-17 13:08:00.000'),(3,9103,'RERA Registration Certificate','Authenticated copy of the project registration certificate by Punjab Real Estate Regulatory Authority',5101,1,'sysadmin','2019-11-17 13:08:00.000','sysadmin','2019-11-17 13:08:00.000'),(4,9104,'Valid License to develop colony/ project or Regularization Certificate','Authenticated copy of the [permission/approval] from the competent authority which is valid for a period which is longer than the proposed term of extension of the registration sought from the authority or Regularisation certificate in respect of unauthorised colony',5101,1,'sysadmin','2019-11-17 13:08:00.000','sysadmin','2019-11-17 13:08:00.000'),(5,9105,'Demand Draft for the sum calculated as per 50% of original registration fees (excluding late fee/ any penalty)','Demand Draft for the sum calculated as per 50% of original registration fees (excluding late fee/ any penalty)',5105,1,'sysadmin','2019-11-17 13:08:00.000','sysadmin','2019-11-17 13:08:00.000'),(6,9106,'Application for Extension of Registration of Project (reasons and information etc.)','Application for Extension of Registration of Project as (i) Reason for Extension, (ii) Project Information etc.',5106,1,'sysadmin','2019-11-17 13:08:00.000','sysadmin','2019-11-17 13:08:00.000'),(7,9107,'Form 1 of Punjab RERA (General) Regulations, 2017, from Architect alongwith Table A and Table B (Progress/status of development works)','Form 1 of Punjab RERA (General) Regulations, 2017, from Architect alongwith Table A and Table B (to see the progress/status of development works)',5101,1,'sysadmin','2019-08-07 11:15:00.000','sysadmin','2019-08-07 11:15:00.000'),(8,9108,'Proforma for Undertaking- cum-Indemnity Bond','Proforma for Undertaking- cum-Indemnity Bond.',5101,1,'sysadmin','2022-12-12 11:15:00.000','sysadmin','2022-12-12 11:15:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_project_formextension_subchecklist` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:56
