-- --------------------------------------------------------
-- Host:                         localhost
-- Server version:               12.0.2-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             12.11.0.7065
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for linkshortener
CREATE DATABASE IF NOT EXISTS `linkshortener` /*!40100 DEFAULT CHARACTER SET cp1251 COLLATE cp1251_general_ci */;
USE `linkshortener`;

-- Dumping structure for function linkshortener.sfGenerateNanoId
DELIMITER //
CREATE FUNCTION `sfGenerateNanoId`(`length` INT
) RETURNS char(21) CHARSET cp1251 COLLATE cp1251_general_ci
    NO SQL
BEGIN
  DECLARE characters VARCHAR(64) DEFAULT
  'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';

  DECLARE nanoid VARCHAR(21) DEFAULT '';

  DECLARE i INT DEFAULT 0;

  DECLARE char_index INT;

  WHILE i < length DO
    SET char_index = Floor(Rand() * Length(characters)) + 1;

    SET nanoid = CONCAT(nanoid, SUBSTRING(characters, char_index, 1));

    SET i = i + 1;
  END WHILE;

  RETURN nanoid;
END//
DELIMITER ;

-- Dumping structure for table linkshortener.shorturl
CREATE TABLE IF NOT EXISTS `shorturl` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `URL` varchar(32000) NOT NULL DEFAULT '',
  `tinyURL` varchar(32000) NOT NULL DEFAULT '',
  `Date` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `Counter` int(10) unsigned zerofill DEFAULT 0000000000,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=cp1251 COLLATE=cp1251_general_ci ROW_FORMAT=DYNAMIC;

-- Dumping data for table linkshortener.shorturl: ~4 rows (approximately)
REPLACE INTO `shorturl` (`Id`, `URL`, `tinyURL`, `Date`, `Counter`) VALUES
	(1, 'https://www.bee-gold.com/plugin/article/view/86/Chem-otlichaetsya-zelenoe-zoloto-ot-zheltogo-i-limonnogo', 'bee-gold.com/2BdSEcD5eow6XFQD', '2025-09-08 03:30:16', 0000000001),
	(2, 'https://alanmebel.by/kompanija/proizvodstvo-kuhonnyh-fasadov/fasady-iz-massiva/', 'alanmebel.by/3UAESQaVdSGkpivL', '2025-09-08 03:32:07', 0000000000),
	(3, 'https://career.habr.com/vacancies/net_developer', 'career.habr.com/BrdPyUOJF7fp0Ppn', '2025-09-08 03:33:05', 0000000003),
	(5, 'https://genome-euro.ucsc.edu/cgi-bin/hgPal?g=mm39.knownGene&c=chr5&l=104318578&r=104327993&i=ENSMUST00000112771.2&hgsid=401369889_MepGGcNpp7AAlpXLLFUAWspMrs6D&db=mm39&token=0.ppFVGVcq9P_ydyx2_bUldScFa3L1RxcAn770V30SgvfQh2Y1voOessJvy4REefbOXdR49yGWenYe_SEW151VDRwtK1r4_IffDmBFHNHnQ1G7I8nwB-VoLR4ZvcbdstquMt_tSSJZSs5ymg4Zr0OTAM4z4W_hkdSDE5WkmjHJa2wovwrrOtDdq0Ig-1lTusNGDtc8DyBxBkFSqL038r7FXSf9qFVb1wo8RAbXsOimmNr_reck1wFWieBHS9xqNbEEGOjcCdW6rkKdrsFCVpVNHevrMrT71ITw3cFHLjyTjE85y2DvNXO5ceACLsgHCVwa5dde2N7AkNlTW0oPI7pYLuVIaI_WSRgetm6IZPeMUTuS6F3J18ntqq-j1U4FQ2dwHYHM0TlanYa67lTESJkgikpwuEsmTqGRhksKfzEfwOeJl_zsLHpBEh_vN82Lq-xDJ8V97mHRnY_DG1faEIgM7NoZj1lXt4G0dSgKJVYA0rsRZ_fF0mKV_5GcZVIgrEaHSRhIISSipa5TacOs-tOTdlDxqWxAYAayEtkDc46Y4VIzQnUiR203_iBq-GKBN7ht8dQQm29M1kjvIT7e-Ebon9vqR32TwmqbSSmuSR384QFJ_FO3znlIVI8VY8VonsaKLeZauRhO2B8nBrWLvDcHBspdNRfijNUZgHJP2D-C4y-6vWH-s54IeY84apDaT5Y8H4H1f77CZ2K_K_0DCmJ48wE0GCZjZEHLvC7NkxTxXvx2meuahf47IiWZJAKPOFV3xChJ94vBQP6oQd2PfD71klRephDUoR0kahj4jkf-AjQjFWo2ErhSZgWPrvacU7qaAM0Slajlu4u50r1E_vroXFuETO_TnbnT_KNEHcfN4jJaBFwMJGt4cf__XP0kKrXRX-shJhaaZQYx_kF5S8M8YKcPq68FR3y25rChbcjCVX4.eo6tbO2kY2UkIK1zwBprQQ.eedcc93a66a5824d3d7281c8920d245236912b3fd54306331626be04f2e52f66', 'genome-euro.ucsc.edu/4El1dvaxvaz36BTd', '2025-09-08 03:36:52', 0000000001);

-- Dumping structure for procedure linkshortener.spInsertNewUrl
DELIMITER //
CREATE PROCEDURE `spInsertNewUrl`(
	IN `newUrl` VARCHAR(32000)
)
    MODIFIES SQL DATA
BEGIN
  DECLARE tempurl, domain VARCHAR(32000);

  IF newurl LIKE 'http://%' THEN
    SET tempurl = SUBSTRING(newurl, 8);
  ELSEIF newurl LIKE 'https://%' THEN
    SET tempurl = SUBSTRING(newurl, 9);
  ELSE
    SET tempurl = newurl;
  END IF;

  IF tempurl LIKE 'www.%' THEN
    SET tempurl = SUBSTRING(tempurl, 5);
  END IF;

  SET domain = Substring_index(Substring_index(tempurl, '/', 1), '?', 1);

  INSERT INTO shorturl
              (url,
               tinyurl)
  VALUES      (newurl,
               CONCAT(domain, '/', sfGeneratenanoid(16)));
END//
DELIMITER ;

-- Dumping structure for procedure linkshortener.spUpdateOnlyUrl
DELIMITER //
CREATE PROCEDURE `spUpdateOnlyUrl`(
	IN `updId` INT,
	IN `newUrl` VARCHAR(32000)
)
    MODIFIES SQL DATA
BEGIN
DECLARE tempTinyUrl, tempUrl, domain VARCHAR(32000);
IF newurl LIKE 'http://%' THEN
    SET tempurl = SUBSTRING(newurl, 8);
  ELSEIF newurl LIKE 'https://%' THEN
    SET tempurl = SUBSTRING(newurl, 9);
  ELSE
    SET tempurl = newurl;
  END IF;

  IF tempurl LIKE 'www.%' THEN
    SET tempurl = SUBSTRING(tempurl, 5);
  END IF;

  SET domain = Substring_index(Substring_index(tempurl, '/', 1), '?', 1);
SET tempTinyUrl = CONCAT(domain, '/', sfGeneratenanoid(16));
IF(SELECT Id = Id FROM shorturl WHERE Id = updId)
THEN UPDATE shorturl SET `URL` = newUrl, `TinyURL` = tempTinyUrl WHERE `Id` = updId;
END IF;
END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
