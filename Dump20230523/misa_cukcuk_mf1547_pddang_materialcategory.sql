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
-- Table structure for table `materialcategory`
--

DROP TABLE IF EXISTS `materialcategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `materialcategory` (
  `CategoryId` char(36) NOT NULL DEFAULT '' COMMENT 'Id nhóm nguyên vật liệu',
  `CategoryCode` varchar(20) NOT NULL DEFAULT '' COMMENT 'Mã nguyên vật liệu',
  `CategoryName` varchar(255) NOT NULL DEFAULT '' COMMENT 'Tên nguyên vật liệu',
  `Description` varchar(255) DEFAULT NULL COMMENT 'Mô tả',
  `Status` smallint DEFAULT NULL COMMENT 'Trạng thái(1-sử dụng,2-Ngưng sử dụng)',
  `CreatedBy` varchar(100) DEFAULT NULL COMMENT 'Người tạo',
  `CreatedDate` datetime DEFAULT NULL COMMENT 'Ngày tạo',
  `ModifiedBy` varchar(100) DEFAULT NULL COMMENT 'Người cập nhật gần nhất',
  `ModifiedDate` datetime DEFAULT NULL COMMENT 'Ngày cập nhật gần nhất',
  PRIMARY KEY (`CategoryId`),
  UNIQUE KEY `CategoryCode` (`CategoryCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Nhóm nguyên vật liệu';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materialcategory`
--

LOCK TABLES `materialcategory` WRITE;
/*!40000 ALTER TABLE `materialcategory` DISABLE KEYS */;
INSERT INTO `materialcategory` VALUES ('3f8e6896-4c7d-15f5-a018-75d8bd200d7c','N2','Nhóm 2','',1,'Norris Calderon','1970-01-01 04:16:14','Elwood Ligon','2007-04-02 18:57:39'),('45ac3d26-18f2-18a9-3031-644313fbb055','N3','Nhóm 1','',1,'Aileen Pitts','2021-10-20 11:26:47','Courtney Abernathy','1994-05-19 05:02:52'),('78aafe4a-67a7-2076-3bf3-eb0223d0a4f7','N1','Nhóm 3','',2,'Trey Christopher','2022-04-04 22:12:39','Natashia Blaylock','1995-09-10 10:59:22'),('7c4f14d8-66fb-14ae-198f-6354f958f4c0','N4','Nhóm 4','',2,'Alaine Hickey','1985-05-03 06:40:56','Rose Aiello','1992-07-30 18:03:07');
/*!40000 ALTER TABLE `materialcategory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-23  8:03:11
