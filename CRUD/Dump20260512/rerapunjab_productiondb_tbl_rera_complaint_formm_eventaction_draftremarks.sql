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
-- Table structure for table `tbl_rera_complaint_formm_eventaction_draftremarks`
--

DROP TABLE IF EXISTS `tbl_rera_complaint_formm_eventaction_draftremarks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_complaint_formm_eventaction_draftremarks` (
  `ComplaintFormM_EventActionDraft_ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `EventAction_Type` bigint(20) NOT NULL,
  `EventAction_IdentifiedBy` varchar(50) NOT NULL,
  `EventAction_IdentifiedOn` datetime(3) NOT NULL,
  `Related_ComplaintorApplication_ID` bigint(20) NOT NULL,
  `Related_RegDiaryNumber` varchar(50) NOT NULL,
  `IdentifiedBy_UserId` varchar(250) NOT NULL,
  `IdentifiedBy_RoleId` varchar(250) NOT NULL,
  `IdentifiedBy_FormType` varchar(50) NOT NULL,
  `EventAction_Summary` varchar(250) NOT NULL,
  `EventAction_Description` varchar(250) NOT NULL,
  `EventAction_Category` varchar(250) NOT NULL,
  `EventAction_Aggregate` varchar(250) NOT NULL,
  `EventAction_Relationship` varchar(250) NOT NULL,
  `AssignedTo` varchar(100) NOT NULL,
  `Target_ResolutionDate` datetime(3) NOT NULL,
  `Target_ResolutionSummary` varchar(250) NOT NULL,
  `Actual_ResolutionDate` datetime(3) NOT NULL,
  `ProgressStatus` varchar(250) NOT NULL,
  `Remarks_IfAny` varchar(2000) NOT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ComplaintFormM_EventActionDraft_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_complaint_formm_eventaction_draftremarks`
--

LOCK TABLES `tbl_rera_complaint_formm_eventaction_draftremarks` WRITE;
/*!40000 ALTER TABLE `tbl_rera_complaint_formm_eventaction_draftremarks` DISABLE KEYS */;
INSERT INTO `tbl_rera_complaint_formm_eventaction_draftremarks` VALUES (13,330058,'legaladvrera','2019-08-01 11:42:06.000',1134,'GCNo13332019','4e6f2ab8-89e0-46b6-9389-a41e8c6329c3','7330c9a0-4296-4ddf-a421-0d0c491adf2d','FormTypeM','','','','','SaveAsDraft','','2019-08-01 11:47:34.211','','2019-08-01 11:47:34.211','','test 2000',1,1,'legaladvrera','2019-08-01 11:42:06.000','legaladvrera','2019-08-01 11:42:06.000'),(14,330058,'legaladvrera','2019-08-01 11:43:13.000',1134,'GCNo13332019','4e6f2ab8-89e0-46b6-9389-a41e8c6329c3','7330c9a0-4296-4ddf-a421-0d0c491adf2d','FormTypeM','','','','','SaveAsDraft','','2019-08-01 11:48:41.193','','2019-08-01 11:48:41.193','','test 2019',1,1,'legaladvrera','2019-08-01 11:43:13.000','legaladvrera','2019-08-01 11:43:13.000'),(15,330051,'legaladvrera','2019-08-01 14:49:14.000',1466,'GCNo13172019','4e6f2ab8-89e0-46b6-9389-a41e8c6329c3','7330c9a0-4296-4ddf-a421-0d0c491adf2d','FormTypeM','','','','','SaveAsDraft','','2019-08-01 14:54:40.022','','2019-08-01 14:54:40.022','','Complaint was returned to complainant with observations for removal of defects in the complaint and to resubmit the same within 15 days or to explain. Complainant neither submitted any explanation nor re-submitted the complaint by removing the defects. No hard copy submitted by complainant. After expiry of 15 days period the complaint was re-called but due to mixing up with under process complaints could not be detected for entrustment to the bench. Now colour coding has been got incorporated through CDAC to identify such complaints and to avoid delays, hence present complaint as per Rotation is forwarded to this Bench ',2,1,'legaladvrera','2019-08-01 14:49:14.000','legaladvrera','2019-08-01 14:54:03.000'),(16,330007,'legaladvrera','2019-08-21 15:56:45.000',1512,'GCNo13532019','4e6f2ab8-89e0-46b6-9389-a41e8c6329c3','7330c9a0-4296-4ddf-a421-0d0c491adf2d','FormTypeM','','','','','SaveAsDraft','','2019-08-21 16:02:22.858','','2019-08-21 16:02:22.859','','You have filed complaint against Promoter of a Registered Project but the name of respondent as appeared in details of Respondent are  different. You are required to implead Promoter who is recorded as registered against the Registration number of the Project. You may add any other number of respondents as additional respondent which are necessary. Further, you have uploaded document mentioning it as Allottment Letter in List of enclosures but wrongly uploaded blank form M which is also required to be  rectified. Remove deficiences and re-submit complaint within 15 days. Also submit hard copies of the uploaded complaint and documents immediately on re-submission of online complaint.',2,1,'legaladvrera','2019-08-21 15:56:45.000','legaladvrera','2019-08-21 15:57:57.000'),(17,330062,'legaladvrera','2019-08-28 10:38:50.000',1534,'GCNo13562019','4e6f2ab8-89e0-46b6-9389-a41e8c6329c3','7330c9a0-4296-4ddf-a421-0d0c491adf2d','FormTypeM','','','','','SaveAsDraft','','2019-08-28 10:44:14.286','','2019-08-28 10:44:14.286','','Submit requisite sets of  hard copies of the complaint',2,1,'legaladvrera','2019-08-28 10:38:50.000','legaladvrera','2019-08-28 10:53:30.000'),(18,330007,'legaladvrera','2019-09-05 10:10:37.000',1517,'GCNo13492019','4e6f2ab8-89e0-46b6-9389-a41e8c6329c3','7330c9a0-4296-4ddf-a421-0d0c491adf2d','FormTypeM','','','','','SaveAsDraft','','2019-09-05 10:16:04.608','','2019-09-05 10:16:04.608','','You have filed complaint under section 18(3) of the Act alleging violations and contravention under section 4, 11 and 17 and has sought relief of compensation. As per Judgment 27.02.2019 passed by Hon\'ble Real Estate Appellate Tribunal, Punjab  the complaint under section 18(3) lies with the Jurisdiction of Adjudicating Officer under form N and with Authority as relief of compensation can only be adjudicated by the Adjudicating Officer. You are required to explain the position within 3 days to proceed further or you may opt to file a fresh complaint before Adjudicating Officer. ',2,1,'legaladvrera','2019-09-05 10:10:37.000','legaladvrera','2019-09-05 10:14:45.000'),(19,330007,'legaladvrera','2019-09-09 14:14:02.000',1562,'GCNo13772019','4e6f2ab8-89e0-46b6-9389-a41e8c6329c3','7330c9a0-4296-4ddf-a421-0d0c491adf2d','FormTypeM','','','','','SaveAsDraft','','2019-09-09 14:20:07.955','','2019-09-09 14:20:07.955','','You have alleged increase in area as per spot and difference in transfer of area through sale deed  which seems to be violation of allotment or agreement , further you have alleged structural defects and irregular power supply causing damage to your house holds  The pleadings are vague and not supported by documents. Prima facie your complaint alleges violation of Section 14 and 18 which fall under the jurisdiction of Adjudicating officer. You are required to explain the legal position in para 5 of the complaint  as your complaint must be in consonance with the provisions of the Act & Rules. You have filed complaint against Promoter but the respondent impleaded is not the same as recorded against Registration of the Project. You are required to verify the same from official web site of the Authoroity and required to rectify the same. You may add any necessary party as additional respondent. The complaint is forwarded to you for removal of defects and to explain the observations otherwise immediately. You are free to contact legal wing of the Authority for any further clairification. ',2,1,'legaladvrera','2019-09-09 14:14:02.000','legaladvrera','2019-09-16 16:13:53.000'),(20,330007,'legaladvrera','2019-09-09 15:23:46.000',1544,'GCNo13632019','4e6f2ab8-89e0-46b6-9389-a41e8c6329c3','7330c9a0-4296-4ddf-a421-0d0c491adf2d','FormTypeM','','','','','SaveAsDraft','','2019-09-09 15:29:51.783','','2019-09-09 15:29:51.783','','I have been directed to forward the complaint as it is transpired that as per  records, the unit in question is not part of  project Registration mentioned in the complaint rather it falls under  \r\nanother project with registration no PBRERA-SAS80-PR0032. You have also mentioned Project name Omaxe Cassia in legal notice uploaded. which falls under PBRERA-SAS80-PR0032. This needs to be verified and modified . You are required to upload allotment letter and agreement to sell , if same are in your possession. Rectify defect and resubmit complaint within three days. ',2,1,'legaladvrera','2019-09-09 15:23:46.000','legaladvrera','2019-09-09 15:24:53.000'),(21,330007,'legaladvrera','2019-09-17 17:20:40.000',1576,'GCNo13872019','4e6f2ab8-89e0-46b6-9389-a41e8c6329c3','7330c9a0-4296-4ddf-a421-0d0c491adf2d','FormTypeM','','','','','SaveAsDraft','','2019-09-17 17:26:15.165','','2019-09-17 17:26:15.165','','You have filed complaint against Promoter of a Registered Project but has not impleaded the Promoter recorded against Registration number of the Project. You must plead specifically that you want to stay in the project or witdraw from the same. So far your pleadings show that Vera Developers stepped into shoes of Bajwa Developers owned liability to adjust the amount paid to Bajwa Developers to which they refused now. ',2,1,'legaladvrera','2019-09-17 17:20:40.000','legaladvrera','2019-09-17 17:43:07.000'),(22,330051,'legaladvrera','2019-09-21 07:33:25.000',1542,'GCNo13612019','4e6f2ab8-89e0-46b6-9389-a41e8c6329c3','7330c9a0-4296-4ddf-a421-0d0c491adf2d','FormTypeM','','','','','SaveAsDraft','','2019-09-21 07:39:55.271','','2019-09-21 07:39:55.271','','Fee and format checked, earlier complaint filed complaint Number GC 10142018 which was dismissed by this bench. ',2,1,'legaladvrera','2019-09-21 07:33:25.000','legaladvrera','2019-09-21 08:01:13.000'),(23,330051,'legaladvrera','2019-09-21 07:34:44.000',1542,'GCNo13612019','4e6f2ab8-89e0-46b6-9389-a41e8c6329c3','7330c9a0-4296-4ddf-a421-0d0c491adf2d','FormTypeM','','','','','SaveAsDraft','','2019-09-21 07:41:14.629','','2019-09-21 07:41:14.629','','Fee and format checked, earlier complaint filed complaint Number GC 10142018 which was dismissed by this bench directing complainant  to pay 3 pending due instalments without interest and then take up my grievences with Puda and in case of non grievance of the same file a fresh complaint with RERA',2,1,'legaladvrera','2019-09-21 07:34:44.000','legaladvrera','2019-09-21 08:01:13.000');
/*!40000 ALTER TABLE `tbl_rera_complaint_formm_eventaction_draftremarks` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:58:16
