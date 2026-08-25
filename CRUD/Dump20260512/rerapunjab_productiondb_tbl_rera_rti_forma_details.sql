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
-- Table structure for table `tbl_rera_rti_forma_details`
--

DROP TABLE IF EXISTS `tbl_rera_rti_forma_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_rti_forma_details` (
  `ApplicationFormA_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ApplicationFormA_ID` bigint(20) NOT NULL,
  `ApplicationFormA_Code` varchar(50) NOT NULL,
  `ReferenceFormA_Year` bigint(20) NOT NULL,
  `ReferenceFormA_Code` varchar(50) NOT NULL,
  `User_ID` varchar(50) NOT NULL,
  `RTI_Type` varchar(50) NOT NULL,
  `RTI_FormLanguage` varchar(50) NOT NULL,
  `RTI_OfficeDepartmentName` varchar(150) NOT NULL,
  `IsPersonalInfoComplete` int(11) NOT NULL,
  `IsRTIdetailComplete` int(11) NOT NULL,
  `IsPaymentModeComplete` int(11) NOT NULL,
  `IsSendingModeComplete` int(11) NOT NULL,
  `IsDocumentsComplete` int(11) NOT NULL,
  `IsVerificationComplete` int(11) NOT NULL,
  `ApplicationVerificationDate` datetime(3) NOT NULL,
  `Complainant_Name` varchar(150) NOT NULL,
  `Complainant_FatherSpouseName` varchar(150) NOT NULL,
  `Complainant_EmailAddress` varchar(150) NOT NULL,
  `Complainant_MobileNumber` bigint(20) NOT NULL,
  `Complainant_LandlineFaxNumber` bigint(20) NOT NULL,
  `PermanentComplainant_AddressLine1` varchar(100) NOT NULL,
  `PermanentComplainant_AddressLine2` varchar(100) NOT NULL,
  `PermanentComplainant_AddressStateCode` int(11) NOT NULL,
  `PermanentComplainant_AddressDistrictCode` int(11) NOT NULL,
  `PermanentComplainant_AddressPIN` varchar(10) NOT NULL,
  `IsPermanentAddress_SameAsServiceNoticeAddress` varchar(10) NOT NULL,
  `ServiceNoticesComplainant_AddressLine1` varchar(100) NOT NULL,
  `ServiceNoticesComplainant_AddressLine2` varchar(100) NOT NULL,
  `ServiceNoticesComplainant_AddressStateCode` int(11) NOT NULL,
  `ServiceNoticesComplainant_AddressDistrictCode` int(11) NOT NULL,
  `ServiceNoticesComplainant_AddressPIN` varchar(10) NOT NULL,
  `AuthorizedRepresentativeCounsel_Name` varchar(90) NOT NULL,
  `AuthorizedRepresentativeCounsel_EmailAddress` varchar(90) NOT NULL,
  `AuthorizedRepresentativeCounsel_MobileNumber` bigint(20) NOT NULL,
  `AuthorizedRepresentativeCounsel_LandlineFaxNumber` bigint(20) NOT NULL,
  `RTI_Subject` varchar(1500) NOT NULL,
  `RTI_RelatedInformationPeriod` varchar(1500) NOT NULL,
  `RTI_RequiredInformationDetails` varchar(6000) NOT NULL,
  `RTI_RequiredInformationModeTitle` varchar(100) NOT NULL,
  `RTI_RequiredInformationSubModeTitleCode` varchar(10) NOT NULL,
  `RTI_RequiredInformationSubModeTitleName` varchar(100) NOT NULL,
  `VoluntaryDisclosure_YN` varchar(10) NOT NULL,
  `VoluntaryDisclosure_RelatedInformationDetails` varchar(350) NOT NULL,
  `IsAgreeDeclaration_RequiredPaymentFee` varchar(10) NOT NULL,
  `INR_PaymentMode` varchar(60) NOT NULL,
  `INR_RegistrationFee` decimal(10,2) NOT NULL,
  `INR_OtherFee` decimal(10,2) NOT NULL,
  `INR_FeeAmount` decimal(10,2) NOT NULL,
  `BelowPovertyLineCategory_YN` varchar(10) NOT NULL,
  `BelowPovertyLineCategory_RelatedInformationDetails` varchar(350) NOT NULL,
  `FormA_SubmittedModeTitle` varchar(100) NOT NULL,
  `FormA_SubmittedSubModeTitleCode` varchar(10) NOT NULL,
  `FormA_SubmittedSubModeTitleName` varchar(100) NOT NULL,
  `FormA_PostalTrackingNumber` varchar(100) DEFAULT NULL,
  `FormA_DateOfPosting` datetime(3) DEFAULT NULL,
  `ComplaintDocI_InfoName` varchar(90) NOT NULL,
  `ComplaintDocI_IssueDate` datetime(3) NOT NULL,
  `ComplaintDocI_FileSize` varchar(50) NOT NULL,
  `ComplaintDocI_FileFormat` varchar(50) NOT NULL,
  `ComplaintDocI_FilePath` varchar(250) NOT NULL,
  `ComplaintDocI_FileName` varchar(250) NOT NULL,
  `ComplaintDocI_NumberOfPages` int(11) NOT NULL,
  `ComplaintDocII_InfoName` varchar(90) NOT NULL,
  `ComplaintDocII_IssueDate` datetime(3) NOT NULL,
  `ComplaintDocII_FileSize` varchar(50) NOT NULL,
  `ComplaintDocII_FileFormat` varchar(50) NOT NULL,
  `ComplaintDocII_FilePath` varchar(250) NOT NULL,
  `ComplaintDocII_FileName` varchar(250) NOT NULL,
  `ComplaintDocII_NumberOfPages` int(11) NOT NULL,
  `IsAgreeDeclaration_RTImaunals` varchar(10) NOT NULL,
  `Remarks_IfAny` varchar(350) NOT NULL,
  `A_column` varchar(50) NOT NULL,
  `B_column` varchar(50) NOT NULL,
  `C_column` varchar(50) NOT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`ApplicationFormA_IndexID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_rti_forma_details`
--

LOCK TABLES `tbl_rera_rti_forma_details` WRITE;
/*!40000 ALTER TABLE `tbl_rera_rti_forma_details` DISABLE KEYS */;
INSERT INTO `tbl_rera_rti_forma_details` VALUES (1,1001,'RERA00012020',2020,'RTI00012020','A','A','PB','RERA Punjab',1,1,2,1,2,2,'2020-02-17 23:12:26.000','ABCD AB','ABCD CD','abc@abc.com',9999998888,1111111111,'test address','test address',0,0,'111111','1','test address','test address',0,0,'111111','ABC test data','a@a.com',1111111111,1111111111,'ABC','last two years','ABC test data','By Post','Speed Post','0','N','test data','N','Other',0.00,0.00,0.00,'N','test data','Online RTI','NA','0','0','2020-02-17 23:12:26.000','0','2020-02-17 23:12:26.000','0','0','0','0',0,'0','2020-02-17 23:12:26.000','0','0','0','0',0,'2','ABC','0','0','0',1,0,0,0,'ABC','2020-02-17 23:12:26.000','ABC','2020-02-17 23:12:26.000'),(2,1002,'ID10022020',2020,'0','','FormA','','',1,1,2,1,2,2,'0001-01-01 00:00:00.000','sds','sdfdsf','abc@abc.com',1111111111,1111111111,'test address','test address',0,0,'333333','0','test address','test address',0,0,'555555','ABC test data','Test@Test.com',4545454545,4545454545,'ABC','last two years','ABC test data','By Post','Speed Post','','N','test data','N','Other',0.00,0.00,0.00,'N','test data','Online RTI','NA','','','0001-01-01 00:00:00.000','','0001-01-01 00:00:00.000','','','','',0,'','0001-01-01 00:00:00.000','','','','',0,'N','','','','',1,0,0,0,'RTIuser','2020-02-18 18:33:17.000','RTIuser','2020-02-18 18:33:17.000'),(3,1003,'ID10032020',2020,'0','','FormA','','',1,1,2,1,2,2,'0001-01-01 00:00:00.000','dfgfdg','dfgfdg','abc@abc.com',3333333333,1111111111,'test address','test address',0,0,'343434','0','test address','test address',0,0,'454545','ABC test data','Test@Test.com',4545454545,4545454545,'ABC','last two years','ABC test data','By Post','Speed Post','','N','test data','N','Other',0.00,0.00,0.00,'N','test data','Online RTI','NA','','','0001-01-01 00:00:00.000','','0001-01-01 00:00:00.000','','','','',0,'','0001-01-01 00:00:00.000','','','','',0,'N','','','','',1,0,0,0,'RTIuser','2020-02-18 18:34:43.000','RTIuser','2020-02-18 18:34:43.000'),(4,1004,'ID10042020',2020,'0','','FormA','','',1,1,2,1,2,2,'0001-01-01 00:00:00.000','asdfafa','afasfs','abc@abc.com',3434343434,3434343434,'test address','test address',0,0,'343434','0','test address','test address',0,0,'454545','ABC test data','Test@Test.com',4545454545,4545454545,'ABC','last two years','ABC test data','By Post','Speed Post','','N','test data','N','Other',0.00,0.00,0.00,'N','test data','Online RTI','NA','','','0001-01-01 00:00:00.000','','0001-01-01 00:00:00.000','','','','',0,'','0001-01-01 00:00:00.000','','','','',0,'N','','','','',1,0,0,0,'RTIuser','2020-02-18 18:37:39.000','RTIuser','2020-02-18 18:37:39.000'),(5,1005,'ID10052020',2020,'0','','FormA','','',1,1,2,1,2,2,'0001-01-01 00:00:00.000','asdfafa','afasfs','abc@abc.com',3434343434,3434343434,'test address','test address',0,0,'343434','0','test address','test address',0,0,'454545','ABC test data','Test@Test.com',4545454545,4545454545,'ABC','last two years','ABC test data','By Post','Speed Post','','N','test data','N','Other',0.00,0.00,0.00,'N','test data','Online RTI','NA','','','0001-01-01 00:00:00.000','','0001-01-01 00:00:00.000','','','','',0,'','0001-01-01 00:00:00.000','','','','',0,'N','','','','',1,0,0,0,'RTIuser','2020-02-18 18:38:07.000','RTIuser','2020-02-18 18:38:07.000'),(6,1006,'ID10062020',2020,'0','','FormA','','',1,1,2,1,2,2,'0001-01-01 00:00:00.000','ASAS','asa','abc@abc.com',1111111111,1111111111,'test address','test address',0,0,'343434','0','test address','test address',0,0,'454545','ABC test data','Test@Test.com',3333333333,4444444444,'ABC','last two years','ABC test data','By Post','Speed Post','','N','test data','N','Other',0.00,0.00,0.00,'N','test data','Online RTI','NA','','','0001-01-01 00:00:00.000','','0001-01-01 00:00:00.000','','','','',0,'','0001-01-01 00:00:00.000','','','','',0,'N','','','','',1,0,0,0,'RTIuser','2020-02-18 18:50:21.000','RTIuser','2020-02-18 18:50:21.000'),(7,1007,'ID10072020',2020,'0','','FormA','','',1,1,2,1,2,2,'0001-01-01 00:00:00.000','fghgfh','fghgfh','abc@abc.com',1111111111,1111111111,'test address','test address',0,0,'444444','0','test address','test address',0,0,'555555','ABC test data','Test@Test.com',4444444444,4444444444,'ABC','last two years','ABC test data','By Post','Speed Post','','N','test data','N','Other',0.00,0.00,0.00,'N','test data','Online RTI','NA','','','0001-01-01 00:00:00.000','','0001-01-01 00:00:00.000','','','','',0,'','0001-01-01 00:00:00.000','','','','',0,'N','','','','',1,0,0,0,'RTIuser','2020-02-18 19:04:48.000','RTIuser','2020-02-18 19:04:48.000'),(8,1008,'ID10082020',2020,'0','','FormA','','',1,1,2,1,2,2,'0001-01-01 00:00:00.000','Harpreet Singh','Singh','abc@abc.com',1111111111,1111111111,'test address','test address',0,0,'333333','0','test address','test address',0,0,'444444','ABC test data','Test@Test.com',1111111111,1111111111,'ABC','last two years','ABC test data','By Post','Speed Post','','Y','test data','N','Other',0.00,0.00,0.00,'Y','test data','Online RTI','NA','','','0001-01-01 00:00:00.000','','0001-01-01 00:00:00.000','','','','',0,'','0001-01-01 00:00:00.000','','','','',0,'N','','','','',1,0,0,0,'RTIuser','2020-02-18 19:08:52.000','RTIuser','2020-02-18 19:08:52.000');
/*!40000 ALTER TABLE `tbl_rera_rti_forma_details` ENABLE KEYS */;
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
