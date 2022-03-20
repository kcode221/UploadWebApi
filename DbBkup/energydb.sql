-- MySQL dump 10.13  Distrib 8.0.28, for Linux (x86_64)
--
-- Host: localhost    Database: energydb
-- ------------------------------------------------------
-- Server version	8.0.28-0ubuntu0.20.04.3

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `energydb`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `energydb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `energydb`;

--
-- Table structure for table `Accounts`
--

DROP TABLE IF EXISTS `Accounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Accounts` (
  `AccountId` int NOT NULL,
  `FirstName` varchar(100) NOT NULL,
  `LastName` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`AccountId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Accounts`
--

LOCK TABLES `Accounts` WRITE;
/*!40000 ALTER TABLE `Accounts` DISABLE KEYS */;
INSERT INTO `Accounts` VALUES (1234,'Freya','Test\r'),(1239,'Noddy','Test\r'),(1240,'Archie','Test\r'),(1241,'Lara','Test\r'),(1242,'Tim','Test\r'),(1243,'Graham','Test\r'),(1244,'Tony','Test\r'),(1245,'Neville','Test\r'),(1246,'Jo','Test\r'),(1247,'Jim','Test\r'),(1248,'Pam','Test\r'),(2233,'Barry','Test\r'),(2344,'Tommy','Test\r'),(2345,'Jerry','Test\r'),(2346,'Ollie','Test\r'),(2347,'Tara','Test\r'),(2348,'Tammy','Test\r'),(2349,'Simon','Test\r'),(2350,'Colin','Test\r'),(2351,'Gladys','Test\r'),(2352,'Greg','Test\r'),(2353,'Tony','Test\r'),(2355,'Arthur','Test\r'),(2356,'Craig','Test\r'),(4534,'JOSH','TEST\r'),(6776,'Laura','Test\r'),(8766,'Sally','Test\r');
/*!40000 ALTER TABLE `Accounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `MeterReadings`
--

DROP TABLE IF EXISTS `MeterReadings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `MeterReadings` (
  `AccountId` int DEFAULT NULL,
  `MeterReadingDateTime` datetime DEFAULT NULL,
  `MeterReadValue` int DEFAULT NULL,
  `MeterReadingId` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`MeterReadingId`),
  KEY `AccountId` (`AccountId`),
  CONSTRAINT `MeterReadings_ibfk_1` FOREIGN KEY (`AccountId`) REFERENCES `Accounts` (`AccountId`)
) ENGINE=InnoDB AUTO_INCREMENT=322 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MeterReadings`
--

LOCK TABLES `MeterReadings` WRITE;
/*!40000 ALTER TABLE `MeterReadings` DISABLE KEYS */;
INSERT INTO `MeterReadings` VALUES (2344,'2019-04-22 09:24:00',1002,296),(2233,'2019-04-22 12:25:00',323,297),(8766,'2019-04-22 12:25:00',3440,298),(2344,'2019-04-22 12:25:00',1002,299),(2345,'2019-04-22 12:25:00',45522,300),(2346,'2019-04-22 12:25:00',999999,301),(2347,'2019-04-22 12:25:00',54,302),(2348,'2019-04-22 12:25:00',123,303),(2350,'2019-04-22 12:25:00',5684,304),(2351,'2019-04-22 12:25:00',57579,305),(2352,'2019-04-22 12:25:00',455,306),(2353,'2019-04-22 12:25:00',1212,307),(2355,'2019-05-06 09:24:00',1,308),(2356,'2019-05-07 09:24:00',0,309),(6776,'2019-05-10 09:24:00',23566,310),(1234,'2019-05-12 09:24:00',9787,311),(1239,'2019-05-17 09:24:00',45345,312),(1240,'2019-05-18 09:24:00',978,313),(1241,'2019-04-11 09:24:00',436,314),(1242,'2019-05-20 09:24:00',124,315),(1243,'2019-05-21 09:24:00',77,316),(1244,'2019-05-25 09:24:00',3478,317),(1245,'2019-05-25 14:26:00',676,318),(1246,'2019-05-25 09:24:00',3455,319),(1247,'2019-05-25 09:24:00',3,320),(1248,'2019-05-26 09:24:00',3467,321);
/*!40000 ALTER TABLE `MeterReadings` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-03-20  7:39:30
