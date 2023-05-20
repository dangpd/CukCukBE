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
-- Table structure for table `unit`
--

DROP TABLE IF EXISTS `unit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `unit` (
  `ConversionUnitId` char(36) NOT NULL DEFAULT '' COMMENT 'ID đơn vị chuyển đổi',
  `ConversionUnitName` varchar(255) NOT NULL DEFAULT '' COMMENT 'Tên đơn vị chuyển đổi',
  `Description` varchar(255) DEFAULT NULL COMMENT 'Mô tả',
  `Status` smallint DEFAULT NULL COMMENT 'Trạng thái(1-sử dụng,2-Ngưng sử dụng)',
  `CreatedBy` varchar(100) DEFAULT NULL COMMENT 'Người tạo',
  `CreatedDate` datetime DEFAULT NULL COMMENT 'Ngày tạo',
  `ModifiedBy` varchar(100) DEFAULT NULL COMMENT 'Người cập nhật gần nhất',
  `ModifiedDate` datetime DEFAULT NULL COMMENT 'Ngày cập nhật gần nhất',
  PRIMARY KEY (`ConversionUnitId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Đơn vị tính';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unit`
--

LOCK TABLES `unit` WRITE;
/*!40000 ALTER TABLE `unit` DISABLE KEYS */;
INSERT INTO `unit` VALUES ('0003bcd1-331b-49a6-8e71-23c84bbdedc6','string','string',1,'DangPD','2023-03-20 11:49:35','DangPD','2023-03-20 11:49:35'),('114b715b-430f-74cd-d5c6-21b180c0988f','Thùng','Hàng tái sử dụng',1,'Maria Abney','2007-09-30 02:48:01','Devora Acker','1998-05-05 09:08:10'),('1242d680-4f02-3bbb-9d66-a58ab8ff47ca','Bao','',2,'Berry Pedersen','1970-01-01 03:35:22','Trinidad Wright','2012-04-05 08:36:14'),('13a507d0-342d-6292-6de3-2ceaa9cf3765','Phần','hàng tái chế',2,'Gale Elliott','2017-09-15 06:49:04','Rocky Souza','2013-03-03 07:49:01'),('1949dae3-4d44-217e-9c66-a58ab8ff47ca','Suất','Hàng dễ vỡ',2,'Alonzo Calvin','2019-06-12 15:21:25','Joella Oconnell','2013-04-07 02:51:44'),('1f60e54f-196f-45f3-5498-ae38c5379e4b','Lon','',2,NULL,NULL,'Abe Sims','1970-01-01 01:01:22'),('234be17d-3820-7daa-5698-ae38c5379e4b','Gram','hàng tái chế',1,'Joette Valdez','2009-08-15 18:13:43','Odilia Archer','1983-08-08 08:09:27'),('23df2104-50d7-1d9c-eadb-93dede770727','Yến','hàng tái chế',1,'Alexis Mallory','1973-06-02 08:04:05','Evonne East','2008-04-12 15:11:17'),('26895d47-1420-68d0-9e66-a58ab8ff47ca','Tạ','hàng tái chế',2,'Bryant Blanchard','1991-02-14 22:56:55','Jed Abreu','1970-01-01 01:02:18'),('3564d2c8-2839-5bf7-851b-27d9d367aeb0','Miếng','',2,'Adah Ambrose','1995-02-03 10:29:36','David Plante','1970-01-01 01:11:09'),('3650c04e-62b1-6908-5598-ae38c5379e4b','Cốc','hàng tái chế',2,'Kareem Culver','2006-09-11 10:33:01','Jed Feliciano','1970-01-01 02:41:33'),('3fa85f64-5717-4562-b3fc-2c963f66afa2','string','string',1,'DangPD','2023-03-20 11:11:03','DangPD','2023-03-20 11:11:03'),('3fa85f64-5717-4562-b3fc-2c963f66afa6','string','string',1,'DangPD','2023-03-20 11:10:03','DangPD','2023-03-20 11:10:03'),('414a8f9e-7d53-42e9-bd04-3189e9bcec62','string','string',1,'DangPD','2023-03-20 10:57:36','DangPD','2023-03-20 10:57:36'),('47782bc9-1bf1-7c7b-6ee3-2ceaa9cf3765','Lọ','hàng tái chế',1,'Alane Patrick','2003-01-10 22:23:35',NULL,NULL),('4958949d-17c9-454d-841b-27d9d367aeb0','Chai','hàng tái chế',1,'Trudie Abney','1976-10-26 17:17:28','Ambrose Tavares','1999-10-22 18:41:02'),('6827e1c0-5b98-6d19-831b-27d9d367aeb0','Can','',1,'Houston Contreras','1974-02-28 13:31:41','Dina Dykes','1970-01-01 01:01:24'),('6e0dc48e-3eac-6143-9b66-a58ab8ff47ca','Gói','hàng tái chế',2,'Damien Gibbs','1991-01-07 02:48:56','Carina Summers','1992-12-31 14:53:10'),('7fa72f44-2825-2b26-d190-152dfadf6d0d','Bịch','hàng tái chế',2,'Thresa Park','1978-06-23 23:26:27','Brigid Jaramillo','1994-06-19 10:42:00'),('9386b0f6-2372-4fc3-9331-c2838e329808','string','string',1,'DangPD','2023-03-20 11:49:30','DangPD','2023-03-20 11:49:30');
/*!40000 ALTER TABLE `unit` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-20 12:01:17
