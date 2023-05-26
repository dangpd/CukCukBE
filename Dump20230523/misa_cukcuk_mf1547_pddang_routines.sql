-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: misa_cukcuk_mf1547_pddang
-- ------------------------------------------------------
-- Server version	8.0.32
use `misa_cukcuk_mf1547_pddang`;
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
-- Dumping routines for database 'misa_cukcuk_mf1547_pddang'
--
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Conversionunit_Delete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Conversionunit_Delete`(IN p_ConversionUnitId char(36), IN p_MaterialId char(36))
BEGIN

  DELETE

    FROM conversionunit

  WHERE MaterialId = p_MaterialId

    AND ConversionUnitId = p_ConversionUnitId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Conversionunit_Insert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Conversionunit_Insert`(IN p_ConversionUnitId char(36), IN p_MaterialId char(36), IN p_Calculation smallint, IN p_ConversionRate double, IN p_CreatedBy varchar(255), IN p_CreatedDate datetime, IN p_ModifiedBy varchar(255), IN p_ModifiedDate datetime)
BEGIN

  INSERT INTO conversionunit (MaterialId, ConversionUnitID, ConversionRate, Calculation, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate)

  VALUES (p_MaterialId, p_ConversionUnitId, p_ConversionRate, p_Calculation, 'DangPD', NOW(), 'DangPD', NOW());

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Conversionunit_Update` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Conversionunit_Update`(IN p_ConversionUnitId CHAR(36), IN p_MaterialId CHAR(36), IN p_Calculation SMALLINT, IN p_ConversionRate DOUBLE, IN p_CreatedBy VARCHAR(255), IN p_CreatedDate DATETIME, IN p_ModifiedBy VARCHAR(255), IN p_ModifiedDate DATETIME)
BEGIN

  UPDATE conversionunit c

  SET ConversionRate = p_ConversionRate,

      Calculation = p_Calculation,

      CreatedBy = 'DangPD',

      CreatedDate = NOW(),

      ModifiedBy = 'DangPD',

      ModifiedDate = NOW()

  WHERE MaterialId = p_MaterialId

  AND ConversionUnitId = p_ConversionUnitId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_MaterialCategory_Delete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_MaterialCategory_Delete`(IN p_CategoryId char(36))
BEGIN

  DELETE

    FROM materialcategory

  WHERE CategoryId = p_CategoryId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_MaterialCategory_Filter` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_MaterialCategory_Filter`(IN $Offset int, IN $Limit int, IN $Where varchar(1000),IN $Sort varchar(100))
BEGIN

  IF IFNULL($Where, '') = '' THEN

    SET $Where = '1=1';

  END IF;



  IF IFNULL($Sort, '') = '' THEN

    SET $Sort = 'ModifiedDate DESC';

  END IF;



  IF $Limit = -1 THEN

    SET @filterQuery = CONCAT('SELECT * FROM materialcategory WHERE ', $Where, ' ORDER BY ', $Sort);

  ELSE

    SET @filterQuery = CONCAT('SELECT * FROM materialcategory WHERE ', $Where, ' ORDER BY ', $Sort, ' LIMIT ', $Offset, ' OFFSET ', ($Limit * $Offset - $Offset));

  END IF;



  PREPARE filterQuery FROM @filterQuery;

  EXECUTE filterQuery;

  DEALLOCATE PREPARE filterQuery;



  SET @filterQuery = CONCAT('SELECT count(CategoryId) AS TotalCount FROM materialcategory WHERE ', $Where);

  PREPARE filterQuery FROM @filterQuery;

  EXECUTE filterQuery;

  DEALLOCATE PREPARE filterQuery;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_MaterialCategory_GetAll` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_MaterialCategory_GetAll`()
BEGIN

  SELECT

    m.CategoryId,

    m.CategoryCode,

    m.CategoryName,

    m.Description,

    m.Status

  FROM materialcategory m;

  SELECT

    COUNT(m1.CategoryId) AS "tong"

  FROM materialcategory m1;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_MaterialCategory_GetById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_MaterialCategory_GetById`(IN p_CategoryId char(36))
BEGIN

  SELECT

    m.CategoryId,

    m.CategoryCode,

    m.CategoryName,

    m.Description,

    m.Status

  FROM materialcategory m

  WHERE m.CategoryId = p_CategoryId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_MaterialCategory_Insert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_MaterialCategory_Insert`(IN p_CategoryId char(36), IN p_CategoryCode varchar(20), IN p_CategoryName varchar(255), IN p_Description varchar(255), IN p_Status smallint, IN p_CreatedBy varchar(100), IN p_CreatedDate datetime, IN p_ModifiedBy varchar(100), IN p_ModifiedDate datetime)
BEGIN

  INSERT INTO materialcategory (CategoryId, CategoryCode, CategoryName, Description, Status, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate)

    VALUES (p_CategoryId, p_CategoryCode, p_CategoryName, p_Description, 1, 'DangPD', NOW(), 'DangPD', NOW());

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_MaterialCategory_Update` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_MaterialCategory_Update`(IN p_CategoryId char(36), IN p_CategoryCode varchar(20), IN p_CategoryName varchar(255), IN p_Description varchar(255), IN p_Status smallint, IN p_CreatedBy varchar(100), IN p_CreatedDate datetime, IN p_ModifiedBy varchar(100), IN p_ModifiedDate datetime)
BEGIN

  UPDATE materialcategory m

  SET CategoryCode = p_CategoryCode,

      CategoryName = p_CategoryName,

      Description = p_Description,

      Status = p_Status,

      CreatedBy = 'DangPD',

      CreatedDate = NOW(),

      ModifiedBy = 'DangPD',

      ModifiedDate = NOW()

  WHERE CategoryId = p_CategoryId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Material_Delete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Material_Delete`(IN p_MaterialId char(36))
BEGIN

  DELETE

    FROM material

  WHERE MaterialId = p_MaterialId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Material_Filter` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Material_Filter`(IN $Offset int, IN $Limit int, IN $Where varchar(1000), IN $Sort varchar(100))
BEGIN

  IF IFNULL($Where, '') = '' THEN

    SET $Where = '1=1';

  END IF;



  IF IFNULL($Sort, '') = '' THEN

    SET $Sort = 'm.ModifiedDate DESC';

  END IF;



  SET @filterQuery = CONCAT(' 

  SELECT

    m.MaterialId,

    m.MaterialCode,

    m.MaterialName,

    m.Feature,

    m1.CategoryId,

    m1.CategoryName,

    u.ConversionUnitId,

    u.ConversionUnitName,

    s.StockId,

    s.StockName,

    m.Description,

    m.Status

  FROM material m

    LEFT JOIN stock s

      ON m.StockId = s.StockId

    LEFT JOIN unit u

      ON m.ConversionUnitId = u.ConversionUnitId

    LEFT JOIN materialcategory m1

      ON m.CategoryId = m1.CategoryId

  WHERE ', $Where, ' ORDER BY ', $Sort, ' LIMIT ', $Offset, ' OFFSET ', ($Limit * $Offset - $Offset));



  PREPARE filterQuery FROM @filterQuery;

  EXECUTE filterQuery;

  DEALLOCATE PREPARE filterQuery;



  SET @pageSize = $Offset;

  SET @filterQuery = CONCAT(' 

  SELECT

    COUNT(m.MaterialId) as tong,

    CEILING((COUNT(m.MaterialId) / @pageSize)) as sotrang

  FROM material m

    LEFT JOIN stock s

      ON m.StockId = s.StockId

    LEFT JOIN unit u

      ON m.ConversionUnitId = u.ConversionUnitId

    LEFT JOIN materialcategory m1

      ON m.CategoryId = m1.CategoryId

  WHERE ', $Where);

  PREPARE filterQuery FROM @filterQuery;

  EXECUTE filterQuery;

  DEALLOCATE PREPARE filterQuery;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Material_GetAll` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Material_GetAll`()
BEGIN

  SELECT

    ROW_NUMBER() OVER (

    ORDER BY m.ModifiedDate DESC) AS RowIndex,

    m.MaterialId,

    m.MaterialCode,

    m.MaterialName,

    m.Feature,

    u.ConversionUnitId,

    u.ConversionUnitName,

    m1.CategoryId,

    m1.CategoryName,

    s.StockId,

    s.StockName,

    m.Description,

    m.Status

  FROM material m

    LEFT JOIN materialcategory m1

      ON m.CategoryId = m1.CategoryId

    LEFT JOIN unit u

      ON m.ConversionUnitId = u.ConversionUnitId

    LEFT JOIN stock s

      ON m.StockId = s.StockId;

  SELECT

    COUNT(m.MaterialId) AS "tong"

  FROM material m;

  SELECT

    m.MaterialId,

    m.MaterialCode,

    m.MaterialName,

    m.Feature,

    m1.CategoryId,

    m1.CategoryName,

    u.ConversionUnitId,

    u.ConversionUnitName,

    s.StockId,

    s.StockName,

    m.Description,

    m.Status

  FROM material m

    LEFT JOIN stock s

      ON m.StockId = s.StockId

    LEFT JOIN unit u

      ON m.ConversionUnitId = u.ConversionUnitId

    LEFT JOIN materialcategory m1

      ON m.CategoryId = m1.CategoryId

  WHERE m.Status = 1;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Material_GetById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Material_GetById`(IN p_MaterialId char(36))
BEGIN

  SELECT

    m.MaterialId,

    m.MaterialCode,

    m.MaterialName,

    m.Feature,

    m1.CategoryId,

    m1.CategoryName,

    u.ConversionUnitId,

    u.ConversionUnitName,

    s.StockId,

    s.StockName,

    m.ExpiryDate,

    m.InventoryNumber,

    m.Description,

    m.Status

  FROM material m

    LEFT JOIN materialcategory m1

      ON m.CategoryId = m1.CategoryId

    LEFT JOIN unit u

      ON m.ConversionUnitId = u.ConversionUnitId

    LEFT JOIN stock s

      ON m.StockId = s.StockId

  WHERE m.MaterialId = p_MaterialId;



  SELECT

    c.MaterialId,

    c.ConversionUnitId,

    c.ConversionRate,

    c.Calculation

  FROM conversionunit c

  WHERE c.MaterialId = p_MaterialId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Material_Insert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Material_Insert`(IN p_MaterialId CHAR(36), IN p_MaterialCode VARCHAR(20), IN p_MaterialName VARCHAR(255), IN p_Feature VARCHAR(255), IN p_CategoryId CHAR(36), IN p_CategoryName VARCHAR(255), IN p_ConversionUnitId CHAR(36), IN p_ConversionUnitName VARCHAR(255), IN p_StockId CHAR(36), IN p_StockName VARCHAR(255), IN p_ExpiryDate VARCHAR(255), IN p_InventoryNumber DOUBLE, IN p_Description VARCHAR(255), IN p_Status SMALLINT, IN p_CreatedBy VARCHAR(100), IN p_CreatedDate DATETIME, IN p_ModifiedBy VARCHAR(100), IN p_ModifiedDate DATETIME)
BEGIN

  INSERT INTO material (MaterialId, MaterialCode, MaterialName, Feature, CategoryId, CategoryName, ConversionUnitId, ConversionUnitName, StockId, StockName, ExpiryDate, InventoryNumber, Description, Status, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate)

  VALUES (p_MaterialId, p_MaterialCode, p_MaterialName, p_Feature, p_CategoryId, p_CategoryName, p_ConversionUnitId, p_ConversionUnitName, p_StockId, p_StockName, p_ExpiryDate, p_InventoryNumber, p_Description, 1, 'DangPD', NOW(), 'DangPD', NOW());

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Material_Update` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Material_Update`(IN p_MaterialId CHAR(36), IN p_MaterialCode VARCHAR(20), IN p_MaterialName VARCHAR(255), IN p_Feature VARCHAR(255), IN p_CategoryId CHAR(36), IN p_CategoryName VARCHAR(255), IN p_ConversionUnitId CHAR(36), IN p_ConversionUnitName VARCHAR(255), IN p_StockId CHAR(36), IN p_StockName VARCHAR(255), IN p_ExpiryDate VARCHAR(255), IN p_InventoryNumber DOUBLE, IN p_Description VARCHAR(255), IN p_Status SMALLINT, IN p_CreatedBy VARCHAR(100), IN p_CreatedDate DATETIME, IN p_ModifiedBy VARCHAR(100), IN p_ModifiedDate DATETIME)
BEGIN

  UPDATE material m

  SET MaterialCode = p_MaterialCode,

      MaterialName = p_MaterialName,

      Feature = p_Feature,

      CategoryID = p_CategoryId,

      CategoryName = p_CategoryName,

      ConversionUnitId = p_ConversionUnitId,

      ConversionUnitName = p_ConversionUnitName,

      StockID = p_StockId,

      StockName = p_StockName,

      ExpiryDate = p_ExpiryDate,

      InventoryNumber = p_InventoryNumber,

      Description = p_Description,

      Status = p_Status,

      CreatedBy = 'DangPD',

      CreatedDate = NOW(),

      ModifiedBy = 'DangPD',

      ModifiedDate = NOW()

  WHERE MaterialID = p_MaterialId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Stock_Delete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Stock_Delete`(IN p_StockId char(36))
BEGIN

  DELETE

    FROM stock

  WHERE StockId = p_StockId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Stock_Filter` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Stock_Filter`(IN $Offset int, IN $Limit int, IN $Where varchar(1000), IN $Sort varchar(100))
BEGIN

  IF IFNULL($Where, '') = '' THEN

    SET $Where = '1=1';

  END IF;



  IF IFNULL($Sort, '') = '' THEN

    SET $Sort = 'ModifiedDate DESC';

  END IF;



  IF $Limit = -1 THEN

    SET @filterQuery = CONCAT('SELECT * FROM stock WHERE ', $Where, ' ORDER BY ', $Sort);

  ELSE

    SET @filterQuery = CONCAT('SELECT * FROM stock WHERE ', $Where, ' ORDER BY ', $Sort, ' LIMIT ', $Offset, ' OFFSET ', ($Limit * $Offset - $Offset));

  END IF;



  PREPARE filterQuery FROM @filterQuery;

  EXECUTE filterQuery;

  DEALLOCATE PREPARE filterQuery;



  SET @filterQuery = CONCAT('SELECT count(StockId) AS TotalCount FROM stock WHERE ', $Where);

  PREPARE filterQuery FROM @filterQuery;

  EXECUTE filterQuery;

  DEALLOCATE PREPARE filterQuery;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Stock_GetAll` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Stock_GetAll`()
BEGIN

  SELECT

    s.StockId,

    s.StockCode,

    s.StockName,

    s.Address,

    s.Status

  FROM stock s;

  SELECT

    COUNT(s.StockId) AS "tong"

  FROM stock s;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Stock_GetById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Stock_GetById`(IN p_StockId char(36))
BEGIN

  SELECT

    s.StockId,

    s.StockCode,

    s.StockName,

    s.Address,

    s.Status

  FROM stock s

  WHERE s.StockId = p_StockId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Stock_Insert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Stock_Insert`(IN p_StockId CHAR(36),IN p_StockCode VARCHAR(20), IN p_StockName VARCHAR(255), IN p_Address VARCHAR(255), IN p_Status SMALLINT, IN p_CreatedBy VARCHAR(100), IN p_CreatedDate DATETIME, IN p_ModifiedBy VARCHAR(100), IN p_ModifiedDate datetime)
BEGIN

  INSERT INTO stock (StockId, StockCode, StockName, Address, Status, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate)

  VALUES (p_StockId, p_StockCode, p_StockName, p_Address, 1, 'DangPD', NOW(), 'DangPD', NOW());

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Stock_Update` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Stock_Update`(IN p_StockId char(36), IN p_StockCode varchar(20), IN p_StockName varchar(255), IN p_Address varchar(255), IN p_Status smallint, IN p_CreatedBy varchar(100), IN p_CreatedDate datetime, IN p_ModifiedBy varchar(100), IN p_ModifiedDate datetime)
BEGIN

  UPDATE stock s

  SET StockCode = p_StockCode,

      StockName = p_StockName,

      Address = p_Address,

      Status = p_Status,

      CreatedBy = 'DangPD',

      CreatedDate = NOW(),

      ModifiedBy = 'DangPD',

      ModifiedDate = NOW()

  WHERE StockId = p_StockId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Unit_Delete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Unit_Delete`(IN p_ConversionUnitId char(36))
BEGIN

  DELETE

    FROM unit

  WHERE ConversionUnitID = p_ConversionUnitId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Unit_Filter` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Unit_Filter`(IN $Offset int, IN $Limit int, IN $Where varchar(1000),IN $Sort varchar(100))
BEGIN

IF IFNULL($Where, '') = '' THEN

    SET $Where = '1=1';

  END IF;



  IF IFNULL($Sort, '') = '' THEN

    SET $Sort = 'ModifiedDate DESC';

  END IF;



  IF $Limit = -1 THEN

    SET @filterQuery = CONCAT('SELECT * FROM unit WHERE ', $Where, ' ORDER BY ', $Sort);

  ELSE

    SET @filterQuery = CONCAT('SELECT * FROM unit WHERE ', $Where, ' ORDER BY ', $Sort, ' LIMIT ', $Offset, ' OFFSET ', ($Limit * $Offset - $Offset));

  END IF;



  PREPARE filterQuery FROM @filterQuery;

  EXECUTE filterQuery;

  DEALLOCATE PREPARE filterQuery;



  SET @filterQuery = CONCAT('SELECT count(ConversionUnitId) AS TotalCount FROM unit WHERE ', $Where);

  PREPARE filterQuery FROM @filterQuery;

  EXECUTE filterQuery;

  DEALLOCATE PREPARE filterQuery;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Unit_GetAll` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Unit_GetAll`()
BEGIN

  SELECT

    *

  FROM unit u;

  SELECT

    COUNT(u.ConversionUnitId) AS tong

  FROM unit u;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Unit_GetById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Unit_GetById`(IN p_ConversionUnitId char(36))
BEGIN

  SELECT

    u.ConversionUnitId,

    u.ConversionUnitName,

    u.Description,

    u.Status

  FROM unit u

  WHERE u.ConversionUnitId = p_ConversionUnitId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Unit_Insert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Unit_Insert`(IN p_ConversionUnitId CHAR(36), IN p_ConversionUnitName VARCHAR(255), IN p_Description VARCHAR(255), IN p_Status SMALLINT, IN p_CreatedBy VARCHAR(100), IN p_CreatedDate DATETIME, IN p_ModifiedBy VARCHAR(100), IN p_ModifiedDate DATETIME)
    COMMENT 'Thêm 1 bản ghi đơn vị'
BEGIN

  INSERT INTO unit (ConversionUnitId, ConversionUnitName, Description, Status, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate)

  VALUES (p_ConversionUnitId, p_ConversionUnitName, p_Description, 1, 'DangPD', NOW(), 'DangPD', NOW());

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_Unit_Update` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_Unit_Update`(IN p_ConversionUnitId CHAR(36), IN p_ConversionUnitName VARCHAR(255), IN p_Description VARCHAR(255), IN p_Status SMALLINT, IN p_CreatedBy VARCHAR(100), IN p_CreatedDate DATETIME, IN p_ModifiedBy VARCHAR(100), IN p_ModifiedDate datetime)
BEGIN

  UPDATE unit u 

SET 

    ConversionUnitName = p_ConversionUnitName,

    Description = p_Description,

    Status = p_Status,

    CreatedBy = 'DangPD',

    CreatedDate = NOW(),

    ModifiedBy = 'DangPD',

    ModifiedDate = NOW()

WHERE ConversionUnitId = p_ConversionUnitId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `test` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb3 */ ;
/*!50003 SET character_set_results = utf8mb3 */ ;
/*!50003 SET collation_connection  = utf8mb3_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `test`()
BEGIN

  SELECT * FROM unit WHERE status = 1 ORDER BY ModifiedDate DESC;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-23  8:03:11
