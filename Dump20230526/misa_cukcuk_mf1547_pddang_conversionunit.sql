-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: misa_cukcuk_mf1547_pddang
-- ------------------------------------------------------
-- Server version	8.0.32

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
-- Table structure for table `conversionunit`
--

DROP TABLE IF EXISTS `conversionunit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `conversionunit` (
  `ConversionUnitId` char(36) NOT NULL DEFAULT '',
  `MaterialId` char(36) NOT NULL DEFAULT '',
  `UnitId` char(36) NOT NULL DEFAULT '',
  `ConversionRate` double DEFAULT NULL COMMENT 'Tỷ lệ chuyển đổi',
  `Calculation` smallint DEFAULT NULL COMMENT 'Phép tính (1- nhân,2-chia)',
  `CreatedBy` varchar(100) DEFAULT NULL COMMENT 'Người tạo',
  `CreatedDate` datetime DEFAULT NULL COMMENT 'Ngày tạo',
  `ModifiedBy` varchar(100) DEFAULT NULL COMMENT 'Người cập nhật gần nhất',
  `ModifiedDate` datetime DEFAULT NULL COMMENT 'Ngày cập nhật gần nhất',
  PRIMARY KEY (`ConversionUnitId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Đơn vị chuyển đổi';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `conversionunit`
--

LOCK TABLES `conversionunit` WRITE;
/*!40000 ALTER TABLE `conversionunit` DISABLE KEYS */;
INSERT INTO `conversionunit` VALUES ('3fa85f64-5717-4562-b3fc-2c963f66af46','c55c5a2c-266e-48c0-94cf-417984d4d45b','114b715b-430f-74cd-d5c6-21b180c0988f',1,1,'DangPD','2023-05-25 13:24:21','DangPD','2023-05-25 13:24:21');
/*!40000 ALTER TABLE `conversionunit` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-26 18:12:11
