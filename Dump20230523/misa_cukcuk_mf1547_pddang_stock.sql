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
-- Table structure for table `stock`
--

DROP TABLE IF EXISTS `stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stock` (
  `StockId` char(36) NOT NULL DEFAULT '' COMMENT 'Id kho',
  `StockCode` varchar(20) NOT NULL DEFAULT '' COMMENT 'Mã kho',
  `StockName` varchar(255) NOT NULL DEFAULT '' COMMENT 'Tên kho',
  `Address` varchar(255) DEFAULT NULL COMMENT 'Địa chỉ',
  `Status` smallint DEFAULT NULL COMMENT 'Trạng thái(1-sử dụng,2-Ngưng sử dụng)',
  `CreatedBy` varchar(100) DEFAULT NULL COMMENT 'Người tạo',
  `CreatedDate` datetime DEFAULT NULL COMMENT 'Ngày tạo',
  `ModifiedBy` varchar(100) DEFAULT NULL COMMENT 'Người cập nhật gần nhất',
  `ModifiedDate` datetime DEFAULT NULL COMMENT 'Ngày cập nhật gần nhất',
  PRIMARY KEY (`StockId`),
  UNIQUE KEY `StockCode` (`StockCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Kho';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock`
--

LOCK TABLES `stock` WRITE;
/*!40000 ALTER TABLE `stock` DISABLE KEYS */;
INSERT INTO `stock` VALUES ('11643064-22fb-7e14-1399-04b3a3d51ef2','KH-425','Kho Hải Hậu','Bắc Ninh',2,'Aubrey Boyce','1975-10-30 10:22:29','Annemarie Manson','1991-07-23 08:19:55'),('11fbda18-5d9f-396c-1299-04b3a3d51ef2','KH-247','Kho Hà Nội','Hà Nội',1,'Merle Reiter','1970-01-01 03:05:50','Brett Abney','1981-06-03 03:33:34'),('15b4ab0a-3b8f-6f6f-2a8f-4d82f3a13455','KH-689','Kho Hải Phòng','Quảng Ninh',1,'Leonila Malone','1982-12-25 08:37:00','Ward Provost','1970-01-01 04:41:26'),('1ec6fd47-2704-4e84-8f51-3dca16c79a48','KH-488','string','string',1,'DangPD','2023-03-19 20:55:27','DangPD','2023-03-19 20:55:27'),('33c6f0f4-3591-2c8e-1244-cfd00e0a9b3b','KH-478','Kho Bình Thuận','Bắc Giang',2,'Moises Adame','1970-01-01 03:14:55','Kelsey Alfaro','1970-01-01 02:02:27'),('4a0e751e-750e-45c3-de78-cf6d4dd5c4a3','KH-504','Kho Cà Mau','Hưng Yên',2,'Francis Shannon','2004-08-26 21:39:08','Carlita Ames','2004-06-08 02:05:50'),('4bfe55ba-57df-274c-1144-cfd00e0a9b3b','KH-314','Kho Lào Cai','Nam Định',2,'Dorian Conaway','1989-12-07 07:19:00','Abigail Mclemore','1970-01-01 02:02:25'),('5ada22d3-3248-6596-6e1a-bb545470e80c','KH-576','Kho TP.Hồ Chí Minh','Ninh Bình',1,'April Fife','2010-06-14 16:10:12','Colton Ackerman','2014-02-20 23:15:45'),('5e6695e2-5aad-3241-6c1a-bb545470e80c','KH-632','Kho Bắc Ninh','Cà Mau',2,'Yadira Villanueva','2017-07-11 05:56:50','Trent Dobbins','2015-11-08 19:11:16'),('60e226cb-63fb-4363-fc4d-8601bf3d85d8','KH-235','Kho Nam Định','Hà Nam',2,NULL,NULL,'Kim Charlton','1996-03-27 00:30:08'),('6207a9a7-3bf9-7288-8565-390639088226','KH-778','Kho Hà Nam','TP.Hồ Chí Minh',2,'Britta Ayres','1980-08-03 18:46:41','Araceli Kingsley','1970-01-01 02:03:43'),('697be7ba-1738-6adf-298f-4d82f3a13455','KH-891','Kho Bình Dương','Hải Hậu',1,'Vivienne Goodson','1984-08-16 05:32:38','Lonna Mccurdy','1989-04-28 20:14:14'),('6d81a322-63f0-7270-6d1a-bb545470e80c','KH-135','Kho Quảng Ninh','Lào Cai',2,'Bernard Creighton','1970-01-01 04:13:25',NULL,NULL),('6ed2e962-178c-712c-fd4d-8601bf3d85d8','KH-178','Kho Ninh Bình','Bình Thuận',1,'Ali Darling','2000-11-12 10:34:56','Adalberto Sousa','1970-01-01 02:02:22'),('76598eb0-20b1-664e-8665-390639088226','KH-713','Kho Bắc Giang','',2,'Wilfredo Southern','1980-11-30 07:01:40','Althea Heath','1983-09-27 22:39:26'),('7c29101e-03b1-46e5-809a-dfff0d85cddd','KH-348','string','string',1,'DangPD','2023-03-20 10:46:03','DangPD','2023-03-20 10:46:03'),('b5715c29-c2cb-4e83-9909-6351102ce26f','KH-493\r\n','string','string',1,'DangPD','2023-03-20 10:43:22','DangPD','2023-03-20 10:43:22'),('c37e42af-7035-4285-aee6-e6a38d1bd2cf','KH-234\r\n','string','string',1,'DangPD','2023-03-20 10:46:02','DangPD','2023-03-20 10:46:02'),('cd464ad7-e64b-4707-b945-b55dc5584392','KH-223','string','string',1,'DangPD','2023-03-19 20:55:31','DangPD','2023-03-19 20:55:31'),('d5b25017-820e-44b3-8e26-7ba4afad490e','KH-998\r\n','string','string',1,'DangPD','2023-03-19 20:55:34','DangPD','2023-03-19 20:55:34');
/*!40000 ALTER TABLE `stock` ENABLE KEYS */;
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
