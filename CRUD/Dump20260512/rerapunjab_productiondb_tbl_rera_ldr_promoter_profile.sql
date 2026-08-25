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
-- Table structure for table `tbl_rera_ldr_promoter_profile`
--

DROP TABLE IF EXISTS `tbl_rera_ldr_promoter_profile`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_ldr_promoter_profile` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Application_id` bigint(20) NOT NULL,
  `First_Name` varchar(200) DEFAULT NULL,
  `Middle_Name` varchar(200) DEFAULT NULL,
  `Last_Name` varchar(200) DEFAULT NULL,
  `Org_Name` varchar(500) DEFAULT NULL,
  `Org_Type` varchar(100) DEFAULT NULL,
  `Org_Objects` varchar(500) DEFAULT NULL,
  `Fath_First_Name` varchar(200) DEFAULT NULL,
  `Fath_Middle_Name` varchar(200) DEFAULT NULL,
  `Fath_Last_Name` varchar(200) DEFAULT NULL,
  `Occupation` varchar(200) DEFAULT NULL,
  `Address_Line1` varchar(500) NOT NULL,
  `Address_Line2` varchar(500) DEFAULT NULL,
  `State` varchar(200) NOT NULL,
  `District` varchar(200) NOT NULL,
  `Pin_Code` bigint(20) NOT NULL,
  `Org_Address_Line1` varchar(500) DEFAULT NULL,
  `Org_Address_Line2` varchar(500) DEFAULT NULL,
  `Org_State` varchar(200) DEFAULT NULL,
  `Org_District` varchar(200) DEFAULT NULL,
  `Org_Pin_Code` bigint(20) DEFAULT NULL,
  `Mobile_no` bigint(20) NOT NULL,
  `Phone_No_STD` bigint(20) DEFAULT NULL,
  `Phone_No` bigint(20) DEFAULT NULL,
  `Email` varchar(100) NOT NULL,
  `WebLink_Promoter_website` varchar(200) DEFAULT NULL,
  `New_InCorp_Parnt_Entity_Name` varchar(200) DEFAULT NULL,
  `New_InCorp_TypeOf_Enterprise` varchar(100) DEFAULT NULL,
  `New_InCorp_Parent_Entity_Objects` varchar(200) DEFAULT NULL,
  `New_Incorp_Parent_Address_Line1` varchar(500) DEFAULT NULL,
  `New_Incorp_Parent_Address_Line2` varchar(500) DEFAULT NULL,
  `New_Incorp_Parent_Org_State` varchar(200) DEFAULT NULL,
  `New_Incorp_Parent_Org_District` varchar(200) DEFAULT NULL,
  `New_Incorp_Parent_Org_Pin_Code` bigint(20) DEFAULT NULL,
  `Past_Exp_Punjab` int(11) NOT NULL,
  `Past_Exp_Other_States` int(11) NOT NULL,
  `PAN_No` varchar(100) NOT NULL,
  `PAN_Doc_Address` varchar(500) DEFAULT NULL,
  `Photo_Address` varchar(500) DEFAULT NULL,
  `Image_FileName` varchar(200) DEFAULT NULL,
  `Org_Reg_Certificate` varchar(500) DEFAULT NULL,
  `New_InCorp_Parnt_Reg_Certificate` varchar(500) DEFAULT NULL,
  `Aadhaar` bigint(20) DEFAULT NULL,
  `Experience` varchar(100) DEFAULT NULL,
  `IsOtherOrganizationMembers` varchar(50) DEFAULT NULL,
  `Ind_Org_CompltdProj_FiveYrs` int(11) DEFAULT NULL,
  `Ind_Org_TotalArea_Constructed` decimal(18,2) DEFAULT NULL,
  `Ind_Org_OngoingProjects` int(11) DEFAULT NULL,
  `Ind_Org_AreaToBe_Constructed` decimal(18,2) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) DEFAULT NULL,
  `Created_By` varchar(100) NOT NULL,
  `Created_On` datetime(3) NOT NULL,
  `Modify_By` varchar(100) DEFAULT NULL,
  `Modified_On` datetime(3) DEFAULT NULL,
  `Flag` int(11) NOT NULL,
  `Last_FiveYr_Exp` varchar(100) DEFAULT NULL,
  `Ongoing_Exp` varchar(100) DEFAULT NULL,
  `Org_Parent_Entity` varchar(100) DEFAULT NULL,
  `IsLitigation_RelatedProject` varchar(50) DEFAULT NULL,
  `Extra1` varchar(200) DEFAULT NULL,
  `Extra2` varchar(200) DEFAULT NULL,
  `Extra3` varchar(200) DEFAULT NULL,
  `Extra4` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_ldr_promoter_profile`
--

LOCK TABLES `tbl_rera_ldr_promoter_profile` WRITE;
/*!40000 ALTER TABLE `tbl_rera_ldr_promoter_profile` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_ldr_promoter_profile` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:39
