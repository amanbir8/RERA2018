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
-- Table structure for table `tbl_rera_hdcr_project_authorisedpromoterpersondetails`
--

DROP TABLE IF EXISTS `tbl_rera_hdcr_project_authorisedpromoterpersondetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_hdcr_project_authorisedpromoterpersondetails` (
  `ProjectPUC_AuthorisedPromoterPerson_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ProjectPUC_AuthorisedPromoterPerson_ID` bigint(20) NOT NULL,
  `Related_Promoter_ID` bigint(20) NOT NULL,
  `Related_Project_ID` bigint(20) NOT NULL,
  `RelatedApplicationPUC_ID` bigint(20) NOT NULL,
  `PUC_DiaryNumber` varchar(100) NOT NULL,
  `PUC_ReferencePUC_Name` varchar(100) NOT NULL,
  `PUC_ReferencePUC_Date` datetime(3) NOT NULL,
  `PUC_RequestCategoryID` bigint(20) NOT NULL,
  `RERAnumberRegistration` varchar(100) NOT NULL,
  `ProjectDiaryNumber` varchar(100) NOT NULL,
  `ExtensionRegdDiaryNumber` varchar(100) NOT NULL,
  `IsConditionAnnexure` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `IsApproved` int(11) NOT NULL,
  `IsMemberApproved` int(11) NOT NULL,
  `Account_FormDate` datetime(3) NOT NULL,
  `Account_ToDate` datetime(3) NOT NULL,
  `Approved_AccountDate` datetime(3) NOT NULL,
  `Approved_AccountBy` varchar(50) NOT NULL,
  `ACR_AccountDate` datetime(3) NOT NULL,
  `ACR_AccountBy` varchar(50) NOT NULL,
  `PUC_Doc_ReferenceTitle` varchar(250) NOT NULL,
  `PUC_Doc_ReferenceNumber` varchar(250) DEFAULT NULL,
  `PUC_AuthorizedPerson_PAN_Number` varchar(90) NOT NULL,
  `PUC_AuthorizedPerson_Aadhaar_Number` varchar(90) DEFAULT NULL,
  `PUC_ReferenceDetailsIfAny` varchar(250) DEFAULT NULL,
  `promoter_Id` int(11) NOT NULL,
  `promoter_Application_id` bigint(20) NOT NULL,
  `promoter_First_Name` varchar(200) DEFAULT NULL,
  `promoter_Middle_Name` varchar(200) DEFAULT NULL,
  `promoter_Last_Name` varchar(200) DEFAULT NULL,
  `promoter_Org_Name` varchar(500) DEFAULT NULL,
  `promoter_Org_Type` varchar(100) DEFAULT NULL,
  `promoter_Org_Objects` varchar(500) DEFAULT NULL,
  `promoter_Fath_First_Name` varchar(200) DEFAULT NULL,
  `promoter_Fath_Middle_Name` varchar(200) DEFAULT NULL,
  `promoter_Fath_Last_Name` varchar(200) DEFAULT NULL,
  `promoter_Occupation` varchar(200) DEFAULT NULL,
  `promoter_Address_Line1` varchar(500) NOT NULL,
  `promoter_Address_Line2` varchar(500) DEFAULT NULL,
  `promoter_State` varchar(200) NOT NULL,
  `promoter_District` varchar(200) NOT NULL,
  `promoter_Pin_Code` bigint(20) NOT NULL,
  `promoter_Org_Address_Line1` varchar(500) DEFAULT NULL,
  `promoter_Org_Address_Line2` varchar(500) DEFAULT NULL,
  `promoter_Org_State` varchar(200) DEFAULT NULL,
  `promoter_Org_District` varchar(200) DEFAULT NULL,
  `promoter_Org_Pin_Code` bigint(20) DEFAULT NULL,
  `promoter_Mobile_no` bigint(20) NOT NULL,
  `promoter_Phone_No_STD` bigint(20) DEFAULT NULL,
  `promoter_Phone_No` bigint(20) DEFAULT NULL,
  `promoter_Email` varchar(100) NOT NULL,
  `promoter_WebLink_Promoter_website` varchar(200) DEFAULT NULL,
  `promoter_New_InCorp_Parnt_Entity_Name` varchar(200) DEFAULT NULL,
  `promoter_New_InCorp_TypeOf_Enterprise` varchar(100) DEFAULT NULL,
  `promoter_New_InCorp_Parent_Entity_Objects` varchar(200) DEFAULT NULL,
  `promoter_New_Incorp_Parent_Address_Line1` varchar(500) DEFAULT NULL,
  `promoter_New_Incorp_Parent_Address_Line2` varchar(500) DEFAULT NULL,
  `promoter_New_Incorp_Parent_Org_State` varchar(200) DEFAULT NULL,
  `promoter_New_Incorp_Parent_Org_District` varchar(200) DEFAULT NULL,
  `promoter_New_Incorp_Parent_Org_Pin_Code` bigint(20) DEFAULT NULL,
  `promoter_Past_Exp_Punjab` int(11) NOT NULL,
  `promoter_Past_Exp_Other_States` int(11) NOT NULL,
  `promoter_PAN_No` varchar(100) NOT NULL,
  `promoter_PAN_Doc_Address` varchar(500) DEFAULT NULL,
  `promoter_Photo_Address` varchar(500) DEFAULT NULL,
  `promoter_Image_FileName` varchar(200) DEFAULT NULL,
  `promoter_Org_Reg_Certificate` varchar(500) DEFAULT NULL,
  `promoter_New_InCorp_Parnt_Reg_Certificate` varchar(500) DEFAULT NULL,
  `promoter_Aadhaar` bigint(20) DEFAULT NULL,
  `promoter_Experience` varchar(100) DEFAULT NULL,
  `promoter_IsOtherOrganizationMembers` varchar(50) DEFAULT NULL,
  `promoter_Ind_Org_CompltdProj_FiveYrs` int(11) DEFAULT NULL,
  `promoter_Ind_Org_TotalArea_Constructed` decimal(18,2) DEFAULT NULL,
  `promoter_Ind_Org_OngoingProjects` int(11) DEFAULT NULL,
  `promoter_Ind_Org_AreaToBe_Constructed` decimal(18,2) DEFAULT NULL,
  `promoter_IsActive` int(11) NOT NULL,
  `promoter_IsDraft` int(11) DEFAULT NULL,
  `promoter_Created_By` varchar(100) NOT NULL,
  `promoter_Created_On` datetime(3) NOT NULL,
  `promoter_Modify_By` varchar(100) DEFAULT NULL,
  `promoter_Modified_On` datetime(3) DEFAULT NULL,
  `promoter_Flag` int(11) NOT NULL,
  `promoter_Last_FiveYr_Exp` varchar(100) DEFAULT NULL,
  `promoter_Ongoing_Exp` varchar(100) DEFAULT NULL,
  `promoter_Org_Parent_Entity` varchar(100) DEFAULT NULL,
  `promoter_IsLitigation_RelatedProject` varchar(50) DEFAULT NULL,
  `promoter_Extra1` varchar(200) DEFAULT NULL,
  `promoter_Extra2` varchar(200) DEFAULT NULL,
  `promoter_Extra3` varchar(200) DEFAULT NULL,
  `promoter_Extra4` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`ProjectPUC_AuthorisedPromoterPerson_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_hdcr_project_authorisedpromoterpersondetails`
--

LOCK TABLES `tbl_rera_hdcr_project_authorisedpromoterpersondetails` WRITE;
/*!40000 ALTER TABLE `tbl_rera_hdcr_project_authorisedpromoterpersondetails` DISABLE KEYS */;
INSERT INTO `tbl_rera_hdcr_project_authorisedpromoterpersondetails` VALUES (2,1001,1796,10951,1017,'PPUC00102021','1128','2021-03-26 00:00:00.000',604,'PBRERA-SAS81-PC0080','PRJ2019SAS1774','FormE2020SAS1104',0,1,1,1,'2019-07-17 12:02:39.000','2021-04-06 15:37:56.000','2021-04-06 15:37:56.000','f193be5c-b13c-42ce-8d73-4a045acb493b','2021-04-06 15:37:56.000','f193be5c-b13c-42ce-8d73-4a045acb493b','PAN Number','','AADCP3300N','','Pan card of Promoter',1873,1796,'GITESH ANEJA',NULL,NULL,'M/S P.P. BULDWELL PRIVATE LIMITED','1','PROPERTY DEVELOPERS',NULL,NULL,NULL,NULL,'PLOT NO. P-1, P.P. TRADE CENTRE','NETAJI SUBHASH PLACE, PRITAMPURA','10','628',110034,'PLOT NO. P-1, P.P. TRADE CENTRE','NETAJI SUBHASH PLACE, PRITAMPURA','10','628',110034,9690947939,0,0,'gitesh2aneja@gmail.com','',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,'AADCP3300N',NULL,NULL,'',NULL,NULL,NULL,'N','Y',0,0.00,0,0.00,1,1,'mohaliwalk','2019-07-17 12:02:39.000','mohaliwalk','2019-07-17 12:02:39.000',2,'NA','NA','N','NA','b8b8c97a-d1b0-4c35-a21f-3d7a9f30fb61',NULL,NULL,NULL),(3,1002,1270,10304,1018,'PPUC00112021','1085','2021-03-24 00:00:00.000',604,'PBRERA-SAS79-PR0292','PRJ2018SAS1233','',0,1,1,1,'2018-09-04 14:16:11.000','2021-04-09 16:15:36.000','2021-04-09 16:15:36.000','f193be5c-b13c-42ce-8d73-4a045acb493b','2021-04-09 16:15:36.000','f193be5c-b13c-42ce-8d73-4a045acb493b','PAN Number','','AAGCP9758H','','pan card',630,1270,'Harjinder Singh Rangi',NULL,NULL,'M/s Palm Heights Private Limited','1','Real Estate Developers',NULL,NULL,NULL,NULL,'Haibatpur Road, Opp Hansa Tubes','Derabassi','28','507',140507,'Haibatpur Road, Opp. hansa Tubes','Derabassi','28','507',140507,9815362101,0,0,'info@palmheights.in','',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,'AAGCP9758H',NULL,NULL,'',NULL,NULL,NULL,'N','Y',0,0.00,0,0.00,1,1,'palmheights','2018-09-04 14:16:11.000','palmheights','2018-09-04 14:16:11.000',2,'NA','NA','N','NA','618201e4-7200-419c-9c2f-23a06bd8a41c',NULL,NULL,NULL),(4,1003,1269,10303,1021,'PPUC00142021','1086','2021-03-24 00:00:00.000',604,'PBRERA-SAS80-PR0110','PRJ2018SAS1234','',0,0,1,1,'2018-09-04 12:35:26.000','2021-04-09 16:38:39.000','2021-04-09 16:38:39.000','f193be5c-b13c-42ce-8d73-4a045acb493b','2021-04-09 16:38:39.000','f193be5c-b13c-42ce-8d73-4a045acb493b','PAN Number','','AABCU8119J','','pan card of firm',629,1269,'Sarjan Singh Rangi',NULL,NULL,'M/s Ubber Buildtech Private Limited','1','Real Estate Developers',NULL,NULL,NULL,NULL,'H. no. 3244','Sector-27 D','6','128',160027,'H. NO. 3244','Sector-27 D','6','128',160027,9815362101,0,0,'csvedparkash@gmail.com','',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,'AABCU8119J',NULL,NULL,'',NULL,NULL,NULL,'N','Y',0,0.00,0,0.00,1,1,'palmmedows','2018-09-04 12:35:26.000','palmmedows','2018-09-04 12:35:26.000',2,'NA','NA','N','NA','71fa806d-aa67-43f3-ac49-6517f726c2b4',NULL,NULL,NULL),(5,1004,1050,10035,1031,'PPUC00242021','2650','2021-07-05 00:00:00.000',604,'PBRERA-SAS81-PC0086','PRJ2018SAS1106','',0,1,1,1,'2019-01-28 10:43:35.000','2021-07-19 16:01:28.000','2021-07-19 16:01:28.000','f193be5c-b13c-42ce-8d73-4a045acb493b','2021-07-19 16:01:28.000','f193be5c-b13c-42ce-8d73-4a045acb493b','Promoter Reference Letter','','AHBPC3878N','533616264174','Board resolution meeting document dated 17th June 2021',1330,1050,'PRADEEP KAPOOR',NULL,NULL,'TDI INFRATECH LIMITED','1','PROPERTY DEVELOPER AND BUILDER/CONTRACTOR',NULL,NULL,NULL,NULL,'SCO: 144-145, 200 FT INTERNATIONAL AIRPORT','SECTOR: 117, TDI CITY','28','507',140301,'10 SHAHEED BHAGAT SINGH MARG','GOLE MARKET','10','429',110001,9216639822,0,8558807770,'pradeep.kapoor@tdigroup.net','www.tdigroupmohali.net',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,10,15,'AABCT3582A',NULL,NULL,'img',NULL,NULL,NULL,'Y','Y',6,129812.28,9,86366.07,1,1,'TDIINFRATECHLIMITED','2019-01-28 10:43:35.000','TDIINFRATECHLIMITED','2019-01-28 10:43:35.000',2,'NA','NA','N','NA','9894b488-d09e-4739-b859-88b9b75c5fda',NULL,NULL,NULL),(6,1005,1332,10374,1062,'PPUC00112022','0145','2022-01-12 00:00:00.000',604,'PBRERA-SAS80-PR0074','PRJ2019SAS1661','FormE2021SAS0006',0,1,1,1,'2018-11-28 17:53:54.000','2022-02-24 17:12:06.000','2022-02-24 17:12:06.000','f193be5c-b13c-42ce-8d73-4a045acb493b','2022-02-24 17:12:06.000','f193be5c-b13c-42ce-8d73-4a045acb493b','PAN Number','','APGPS2394E','302182835206','Not applicable',1078,1332,'SUKHJINDER SINGH',NULL,NULL,'Innovative Housing & Infrastructure Pvt. Ltd. (Trade Name - PCL)','1','TO CARRY ON THE BUSINESS OF REAL ESTATE SALE, PURCHASE OF REAL ESTATE AND DEVELOPMENT OF LAND AND TO PROMOTE AND ACQUIRE IN INDIA OR ABROAD WHETHER ON OWN ACCOUNT OR IN ASSOCIATION WITH OTHERS OR THROUGH OTHERS OT FOR AND ON BEHALF OF OTHERS BY PURCHASE, LEASE, EXCHANGE, HIRE OF OTHERWISE ANY PROPERTIES',NULL,NULL,NULL,NULL,'SCO. 198, Sector - 7C, Chandigarh','Sector - 7C,','6','128',160019,'SCO. 198, Sector - 7C, Chandigarh','CHANDIGARH','6','128',160019,9876021417,0,0,'info@pclnewchandigarh.com','www.pclnewchandigarh.com',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,'AABCI4214N',NULL,NULL,'img',NULL,NULL,NULL,'N','Y',0,0.00,0,0.00,1,1,'innovative','2018-11-28 17:53:54.000','innovative','2018-11-28 17:53:54.000',2,'NA','NA','N','NA','1abda78e-4af3-46ed-ae94-a1fd12626a69',NULL,NULL,NULL),(7,1006,1563,10679,1086,'PPUC00352022','1155','2022-03-16 00:00:00.000',604,'PBRERA-SAS80-PR0109','PRJ2019SAS1551','',0,1,1,1,'2018-12-22 12:00:28.000','2022-04-06 15:01:37.000','2022-04-06 15:01:37.000','f193be5c-b13c-42ce-8d73-4a045acb493b','2022-04-06 15:01:37.000','f193be5c-b13c-42ce-8d73-4a045acb493b','PAN Number','','APAPS3381R','468200330127','Pan Card',1218,1563,'Pawan Kumar',NULL,NULL,'Sandalwood builders & promoters private limited','1','Builders and Promoters',NULL,NULL,NULL,NULL,'Quite office no.11, second floor ','Sector 35 A','6','128',160035,'Quite office no.11, second floor ','Sector 35 A','6','128',160035,9803030706,0,0,'pawank09@gmail.com','',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,6,0,'AAPCS9244L',NULL,NULL,'img',NULL,NULL,NULL,'N','Y',2,12578.49,2,12578.49,1,1,'sandalwoodprojects','2018-12-22 12:00:28.000','sandalwoodprojects','2018-12-22 12:00:28.000',2,'NA','NA','N','NA','921bd851-6cf7-4e5f-9d78-944093464f50',NULL,NULL,NULL),(8,1007,1072,10151,1105,'PPUC00542022','6424','2022-09-28 00:00:00.000',604,'PBRERA-SAS80-PR0033','PRJ2018SAS1237','FormE2021SAS0003',0,1,1,1,'2021-06-29 11:04:37.000','2022-10-20 12:42:17.000','2022-10-20 12:42:17.000','f193be5c-b13c-42ce-8d73-4a045acb493b','2022-10-20 12:42:17.000','f193be5c-b13c-42ce-8d73-4a045acb493b','Aadhaar Card','','AGGPB9256P','604715458538','Letter from promoter',2957,1072,'Bhupendra Singh',NULL,NULL,'Omaxe New Chandigarh Developers Private Ltd.','1',' Real Estate Actvities i.e. Constrcution, Development, Sale Purchase etc\r\n Civil Contractor, Colonizer, Builder',NULL,NULL,NULL,NULL,'Corporate Office: 7, Local Shopping Center, Kalkaji','','10','429',110019,'Omaxe City, 111th Milestone, Near Bad ke Balaji Bus Stand, Jaipur-Ajmer Expressway','','29','258',302026,9711800256,0,0,'bsingh_rera@omaxe.com','www.omaxe.com',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,12,12,'AABCO2751Q',NULL,NULL,'img',NULL,NULL,NULL,'Y','Y',10,718814.91,10,418135.71,1,1,'OCEDPL','2021-06-29 11:04:37.000','OCEDPL','2021-06-29 11:04:37.000',2,'NA','NA','Y','NA','05ca271e-e5f5-42b9-895d-35b700481ca6',NULL,NULL,NULL),(9,1008,1676,10845,1110,'PPUC00592022','7082','2022-11-14 00:00:00.000',604,'PBRERA-ASR01-PR0424','PRJ2019ASR1858','',0,1,1,1,'2019-03-08 12:27:47.000','2022-12-13 16:27:17.000','2022-12-13 16:27:17.000','f193be5c-b13c-42ce-8d73-4a045acb493b','2022-12-13 16:27:17.000','f193be5c-b13c-42ce-8d73-4a045acb493b','Aadhaar Card','487391185492','AGUPK4133C','487391185492','487391185492',1441,1676,'S.K. Arora',NULL,NULL,'Collage Group Infrastructure Pvt. Ltd.','1','Real Estate ',NULL,NULL,NULL,NULL,'56-58, Community Centre','East of Kailash','10','557',110065,'56-58, Community Centre,','East of Kailash','10','557',110065,9810853071,0,0,'info@collageindia.com','www.collageindia.com',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,'AADCC0322P',NULL,NULL,'img',NULL,NULL,NULL,'N','Y',0,0.00,0,0.00,1,1,'collage','2019-03-08 12:27:47.000','collage','2019-03-08 12:27:47.000',2,'NA','NA','N','NA','6da4cc53-cf0e-4d53-bf5e-70868c84a4a7',NULL,NULL,NULL),(10,1009,2282,11412,1112,'PPUC00612022','6787','2022-10-26 00:00:00.000',604,'PBRERA-SAS81-PR0757','PRJ2021SAS0130','',0,1,1,1,'2021-12-08 11:28:04.000','2022-12-15 13:29:20.000','2022-12-15 13:29:20.000','f193be5c-b13c-42ce-8d73-4a045acb493b','2022-12-15 13:29:20.000','f193be5c-b13c-42ce-8d73-4a045acb493b','Aadhaar Card','361805419784','ARNPJ7831N','361805419784','Adhaar no. ',3144,2282,'PUNEET BHANDARI ',NULL,NULL,'S.A. GLOBAL PRIVATE LIMITED','1','PROPERTY DEVELOPER AND BUILDER',NULL,NULL,NULL,NULL,'GROUP HOUSING SITE ','SECTOR-77','28','507',160055,'GROUP HOUSING SITE ','SECTOR-77 ','28','507',160055,9653100007,0,0,'legal@homelandgroup.org','',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,'AAXCS6741E',NULL,NULL,'',NULL,NULL,NULL,'N','Y',0,0.00,0,0.00,1,1,'S.A.Global','2021-12-08 11:28:04.000','S.A.Global','2021-12-08 11:28:04.000',2,'NA','NA','N','NA','126dd947-dfad-4fbc-a7d6-2f054d7132c9',NULL,NULL,NULL);
/*!40000 ALTER TABLE `tbl_rera_hdcr_project_authorisedpromoterpersondetails` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:06
