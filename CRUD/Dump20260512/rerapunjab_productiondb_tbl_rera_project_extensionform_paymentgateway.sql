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
-- Table structure for table `tbl_rera_project_extensionform_paymentgateway`
--

DROP TABLE IF EXISTS `tbl_rera_project_extensionform_paymentgateway`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rera_project_extensionform_paymentgateway` (
  `PaymentRefNumberExtensionForm_IndexID` bigint(20) NOT NULL AUTO_INCREMENT,
  `PaymentRefNumberExtensionForm_ID` bigint(20) NOT NULL,
  `RelatedExtensionForm_ProjectID` bigint(20) NOT NULL,
  `RelatedExtensionForm_ProjectCode` varchar(50) NOT NULL,
  `RelatedPayment_ID` bigint(20) NOT NULL,
  `User_ID` varchar(50) NOT NULL,
  `ExtensionForm_Type` varchar(50) NOT NULL,
  `User_Name` varchar(100) NOT NULL,
  `ExtensionForm_BriefSummary` varchar(250) DEFAULT NULL,
  `IsPaymentSuccessComplete` int(11) NOT NULL,
  `PaymentSuccessDate` datetime(3) NOT NULL,
  `FailureSuccessSummary` varchar(150) DEFAULT NULL,
  `PG_Transaction_ID` varchar(50) NOT NULL,
  `PG_Date` datetime(3) DEFAULT NULL,
  `PG_PayU_ID` bigint(20) DEFAULT NULL,
  `PG_Amount` decimal(18,2) NOT NULL,
  `PG_Status` varchar(150) DEFAULT NULL,
  `PG_Product_Info` varchar(150) NOT NULL,
  `PG_Customer_Name` varchar(150) NOT NULL,
  `PG_Last_Name` varchar(100) DEFAULT NULL,
  `PG_Customer_Email` varchar(100) NOT NULL,
  `PG_Customer_Phone` varchar(50) NOT NULL,
  `PG_Customer_IP_Address` varchar(50) DEFAULT NULL,
  `PG_City` varchar(50) DEFAULT NULL,
  `PG_Merchant_Name` varchar(50) DEFAULT NULL,
  `PG_Bank_Name` varchar(50) DEFAULT NULL,
  `PG_Payment_Gateway` varchar(50) DEFAULT NULL,
  `PG_Bank_Reference_No` varchar(50) DEFAULT NULL,
  `PG_International_Domestic` varchar(50) DEFAULT NULL,
  `PG_Payment_Type` varchar(50) DEFAULT NULL,
  `PG_Error_Code` varchar(50) DEFAULT NULL,
  `PG_Error_Message` varchar(150) DEFAULT NULL,
  `PG_Name_on_Card` varchar(90) DEFAULT NULL,
  `PG_Card_Number` varchar(50) DEFAULT NULL,
  `PG_Address_Line1` varchar(100) DEFAULT NULL,
  `PG_Address_Line2` varchar(100) DEFAULT NULL,
  `PG_State` varchar(50) DEFAULT NULL,
  `PG_Country` varchar(50) DEFAULT NULL,
  `PG_ZipCode` varchar(50) DEFAULT NULL,
  `PG_Shipping_Firstname` varchar(90) DEFAULT NULL,
  `PG_Shipping_Lastname` varchar(90) DEFAULT NULL,
  `PG_Shipping_Address1` varchar(100) DEFAULT NULL,
  `PG_Shipping_Address2` varchar(100) DEFAULT NULL,
  `PG_Shipping_City` varchar(50) DEFAULT NULL,
  `PG_Shipping_State` varchar(50) DEFAULT NULL,
  `PG_Shipping_Country` varchar(50) DEFAULT NULL,
  `PG_Shipping_Zipcode` varchar(50) DEFAULT NULL,
  `PG_Shipping_Phone` varchar(50) DEFAULT NULL,
  `PG_Transaction_Fee` decimal(18,2) DEFAULT NULL,
  `PG_Discount` decimal(18,2) DEFAULT NULL,
  `PG_Additional_Charges` decimal(18,2) DEFAULT NULL,
  `PG_Amount_INR` decimal(18,2) NOT NULL,
  `PG_UDF_1` varchar(150) NOT NULL,
  `PG_UDF_2` varchar(150) NOT NULL,
  `PG_UDF_3` varchar(150) DEFAULT NULL,
  `PG_UDF_4` varchar(150) DEFAULT NULL,
  `PG_UDF_5` varchar(150) DEFAULT NULL,
  `PG_Device_Info` varchar(50) DEFAULT NULL,
  `PG_HashKey` varchar(350) DEFAULT NULL,
  `PG_ServiceProvider` varchar(50) DEFAULT NULL,
  `Remarks_IfAny` varchar(350) DEFAULT NULL,
  `A_column` varchar(100) DEFAULT NULL,
  `B_column` varchar(100) DEFAULT NULL,
  `C_column` varchar(100) DEFAULT NULL,
  `IsActive` int(11) NOT NULL,
  `IsDraft` int(11) NOT NULL,
  `IsLock` int(11) NOT NULL,
  `IsPublicView` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedOn` datetime(3) NOT NULL,
  `ModifyBy` varchar(50) NOT NULL,
  `ModifyOn` datetime(3) NOT NULL,
  PRIMARY KEY (`PaymentRefNumberExtensionForm_IndexID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rera_project_extensionform_paymentgateway`
--

LOCK TABLES `tbl_rera_project_extensionform_paymentgateway` WRITE;
/*!40000 ALTER TABLE `tbl_rera_project_extensionform_paymentgateway` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_rera_project_extensionform_paymentgateway` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-12 10:57:29
