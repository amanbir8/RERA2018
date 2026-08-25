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
-- Table structure for table `tbl_rera_master_agent_subchecklist`
--

DROP TABLE IF EXISTS `tbl_rera_master_agent_subchecklist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_master_agent_subchecklist` (
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
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_master_agent_subchecklist`
--

LOCK TABLES `tbl_rera_master_agent_subchecklist` WRITE;
/*!40000 ALTER TABLE `tbl_rera_master_agent_subchecklist` DISABLE KEYS */;
INSERT INTO `tbl_rera_master_agent_subchecklist` VALUES (1,601,'Duly filed Form \'G  as defined in the Rules','Duly filed Form \'G  as defined in the Rules',513,2,'sysadmin','2024-11-17 13:08:00.000','sysadmin','2024-11-27 13:08:00.000'),(2,602,'The details of promoter incase of an individual real estate agent','The details of promoter incase of an individual real estate agent',511,2,'sysadmin','2025-11-17 13:08:00.000','sysadmin','2025-11-27 13:08:00.000'),(3,603,'The details of Chairman, partners, directors etc. in case of other entities','The details of Chairman, partners, directors etc. in case of other entities',511,1,'sysadmin','2026-11-17 13:08:00.000','sysadmin','2026-11-17 13:08:00.000'),(4,604,'Name, Registered address & Type of enterprise','Name, registered address, type of enterprise(Proprietership, scoiety, partnership, company etc.)',511,2,'sysadmin','2027-11-17 13:08:00.000','sysadmin','2027-11-27 13:08:00.000'),(5,605,'Registration details including bye-law, memorandum of association, articles of association etc.','Registration details including bye-law, memorandum of association, articles of association etc.',511,2,'sysadmin','2028-11-17 13:08:00.000','sysadmin','2028-11-27 13:08:00.000'),(7,606,'Authentcated copy of address proof of the place of business.(Premises Self Owned, Title deed)','Authentcated copy of address proof of the place of business. If the premises is self  owned, title deed to this effect shall be furnished',513,1,'sysadmin','2029-11-17 13:08:00.000','sysadmin','2029-11-17 13:08:00.000'),(8,607,'Authentcated copy of address proof of the place of business. (Premises Rented, Rent deed)','Authentcated copy of address proof of the place of business. If the premises is rented, rent deed for the same shall be furnished.',513,1,'sysadmin','2030-11-17 13:08:00.000','sysadmin','2030-11-17 13:08:00.000'),(9,608,'Authenticated copy of the PAN card','Authenticated copy of the PAN card',513,1,'sysadmin','2001-12-17 13:08:00.000','sysadmin','2001-12-17 13:08:00.000'),(10,609,'Income Tax returns for the last three financial years preceding the application','Income Tax returns for the last three financial years preceding the application',513,1,'sysadmin','2002-12-17 13:08:00.000','sysadmin','2002-12-17 13:08:00.000'),(11,610,'The enterprise has been in existence for less than 3 years, the income tax returns for all the years in existence','In case the enterprise has been in existence for less than 3 years, the income tax returns for all the years in existence',513,2,'sysadmin','2003-12-17 13:08:00.000','sysadmin','2003-12-27 13:08:00.000'),(12,611,'The applicant was exempted from filing returns under the provisions of the Income Tax Act, 1961 for any of the three year (Declaration)','In case the applicant was exempted from filing returns under the provisions of the Income Tax Act, 1961 for any of the three year preceding the application, a declaration to such effects',513,2,'sysadmin','2004-12-17 13:08:00.000','sysadmin','2004-12-27 13:08:00.000'),(13,612,'Demand Draft for a sum as per Schedule - I drawn on any Scheduled Bank','Demand Draft for a sum as per Schedule - I drawn on any Scheduled Bank',512,2,'sysadmin','2005-12-17 13:08:00.000','sysadmin','2005-12-27 13:08:00.000'),(14,613,'Copy of the Online Payment Recipt to be annexed with file','Copy of the Online Payment Recipt to be annexed with file or Online Payment for a sum as per Schedule - I drawn on any Scheduled Bank',512,1,'sysadmin','2006-12-17 13:08:00.000','sysadmin','2006-12-17 13:08:00.000'),(15,614,'Articles of Association/ Company Registration Certificate/ Memorandum of Association/ Registration Including Bye-Laws','Articles of Association/ Company Registration Certificate/ Memorandum of Association/ Registration Including Bye-Laws',513,1,'sysadmin','2018-04-01 14:14:14.000','sysadmin','2018-04-01 14:14:14.000'),(16,615,'RERA Registration Details with Other State/UT Details','RERA Registration Details with Other State/UT Details',514,1,'sysadmin','2018-04-01 14:14:14.000','sysadmin','2018-04-01 14:14:14.000'),(17,616,'Authorized Signatory Details','Authorized Signatory Details',511,1,'sysadmin','2018-04-01 14:14:14.000','sysadmin','2018-04-01 14:14:14.000'),(18,617,'Address for Place of Business','Address for Place of Business',511,2,'sysadmin','2018-04-01 14:14:14.000','sysadmin','2018-04-27 14:14:14.000'),(19,618,'Registered Address of Organization\n','Registered Address of Organization\n',511,2,'sysadmin','2018-04-01 14:14:14.000','sysadmin','2018-04-27 14:14:14.000'),(20,619,'Address for Official Communication\n','Address for Official Communication\n',511,2,'sysadmin','2018-04-01 14:14:14.000','sysadmin','2018-04-27 14:14:14.000'),(21,620,'Agent (Individual Profile) Details','Agent (Individual Profile) Details',511,1,'sysadmin','2018-04-01 14:14:14.000','sysadmin','2018-04-01 14:14:14.000'),(22,621,'Agent (Other than Individual Profile) Details','Agent (Other than Individual Profile) Details',511,1,'sysadmin','2018-04-01 14:14:14.000','sysadmin','2018-04-01 14:14:14.000'),(23,622,'Authentcated copy of Permanent address proof','Authentcated copy of Permanent address proof',513,1,'sysadmin','2018-07-05 14:14:14.000','sysadmin','2018-07-05 14:14:14.000'),(24,623,'Proforma for Undertaking- cum-Indemnity Bond','Proforma for Undertaking- cum-Indemnity Bond.',513,1,'sysadmin','2022-10-21 11:11:00.000','sysadmin','2022-10-21 11:11:00.000');
/*!40000 ALTER TABLE `tbl_rera_master_agent_subchecklist` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:49
