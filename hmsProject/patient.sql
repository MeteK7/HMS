-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Mar 26, 2019 at 05:00 PM
-- Server version: 5.7.23
-- PHP Version: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `patient`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin_menuler`
--

DROP TABLE IF EXISTS `admin_menuler`;
CREATE TABLE IF NOT EXISTS `admin_menuler` (
  `registlogin1` varchar(30) COLLATE utf32_turkish_ci NOT NULL,
  `registlogin2` varchar(30) COLLATE utf32_turkish_ci NOT NULL,
  `regitsregist1` varchar(30) COLLATE utf32_turkish_ci NOT NULL,
  `regitsregist2` varchar(30) COLLATE utf32_turkish_ci NOT NULL,
  `regitsregist3` varchar(30) COLLATE utf32_turkish_ci NOT NULL,
  `regitsregist4` varchar(30) COLLATE utf32_turkish_ci NOT NULL,
  `regitsregist5` varchar(30) COLLATE utf32_turkish_ci NOT NULL,
  `yedek` varchar(30) COLLATE utf32_turkish_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf32 COLLATE=utf32_turkish_ci;

--
-- Dumping data for table `admin_menuler`
--

INSERT INTO `admin_menuler` (`registlogin1`, `registlogin2`, `regitsregist1`, `regitsregist2`, `regitsregist3`, `regitsregist4`, `regitsregist5`, `yedek`) VALUES
('UserName', 'Password', 'T.C ID', 'Name', 'Surname', 'Phone', 'Birth', '');

-- --------------------------------------------------------

--
-- Table structure for table `bolumler`
--

DROP TABLE IF EXISTS `bolumler`;
CREATE TABLE IF NOT EXISTS `bolumler` (
  `Id` int(5) NOT NULL AUTO_INCREMENT,
  `Bolum` varchar(20) COLLATE utf32_turkish_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=14 DEFAULT CHARSET=utf32 COLLATE=utf32_turkish_ci;

--
-- Dumping data for table `bolumler`
--

INSERT INTO `bolumler` (`Id`, `Bolum`) VALUES
(11, 'Internal medicine'),
(12, 'Psychiatry'),
(13, 'Ear Nose and Throat');

-- --------------------------------------------------------

--
-- Table structure for table `docpage`
--

DROP TABLE IF EXISTS `docpage`;
CREATE TABLE IF NOT EXISTS `docpage` (
  `Id` int(20) NOT NULL AUTO_INCREMENT,
  `firstName` varchar(30) COLLATE utf32_turkish_ci NOT NULL,
  `lastName` varchar(30) COLLATE utf32_turkish_ci NOT NULL,
  `tCNum` varchar(11) COLLATE utf32_turkish_ci NOT NULL,
  `phoneNum` varchar(15) COLLATE utf32_turkish_ci NOT NULL,
  `password` longtext COLLATE utf32_turkish_ci NOT NULL,
  `major` varchar(25) COLLATE utf32_turkish_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=24 DEFAULT CHARSET=utf32 COLLATE=utf32_turkish_ci;

--
-- Dumping data for table `docpage`
--

INSERT INTO `docpage` (`Id`, `firstName`, `lastName`, `tCNum`, `phoneNum`, `password`, `major`) VALUES
(10, 'Mete', 'KABA', '32377623452', '5419056587', '123456', 'Psychiatry'),
(23, 'Teynur', 'YILDIZ', '761389564', '5469356476', '6546848', 'Ear Nose and Throat'),
(22, 'Feyha', 'TALAY', '3464563', '457545', '547657', 'Psychiatry');

-- --------------------------------------------------------

--
-- Table structure for table `medicineinfo`
--

DROP TABLE IF EXISTS `medicineinfo`;
CREATE TABLE IF NOT EXISTS `medicineinfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `type` varchar(15) COLLATE utf32_turkish_ci NOT NULL,
  `name` varchar(20) COLLATE utf32_turkish_ci NOT NULL,
  `dosage` varchar(15) COLLATE utf32_turkish_ci NOT NULL,
  `barcode` varchar(15) COLLATE utf32_turkish_ci NOT NULL,
  `description` longtext COLLATE utf32_turkish_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=utf32 COLLATE=utf32_turkish_ci;

--
-- Dumping data for table `medicineinfo`
--

INSERT INTO `medicineinfo` (`id`, `type`, `name`, `dosage`, `barcode`, `description`) VALUES
(1, 'Antidepressant', 'Paxil', '20', '1635987521', 'Paxil (paroxetine) is an antidepressant belonging to a group of drugs called selective serotonin reuptake inhibitors (SSRIs). Paroxetine affects chemicals in the brain that may be unbalanced in people with depression, anxiety, or other disorders.'),
(5, 'Nervine', 'Rileptid', '1', '654987123', 'Rileptid is used to treat schizophrenia, bipolar disorder, or irritability associated with autistic disorder. Rileptid should not be used to treat behavioral problems in older adults who have dementia.'),
(6, 'Cold tablets', 'Coldaway', '15', '986745', 'Cold Away is a modern invention that combines herbs from several cold remedies, GAN MAO LING, ZONG GAN LING and YIN CHIAO together with several herbs, such as CHUAN XIN LIAN (andrographis) and HUANG QIN (scutellaria) not found in these 3 formulas.'),
(7, 'Painkiller', 'Panadol', '5', '79461352', 'Panadol is used in over 80 countries around the world: it offers fast and effective relief from pain and also reduces fever, leaving you free to enjoy life to the full again.'),
(8, 'Antidepressant', 'Paxera', '30', '7356832', ' Paroxetine is used to treat depression, panic attacks, obsessive-compulsive disorder (OCD), anxiety disorders, and post-traumatic stress disorder. '),
(9, 'Lotion', 'Lubriderm', '1', '35664', 'Daily Moisture Fragrance-Free Lotion is our family-friendly* solution to replenish and moisturize dry skin.'),
(10, 'Cold tablets', 'Minoset', '500', '36952246', 'Minoset (acetaminophen) is a pain reliever and a fever reducer. The exact mechanism of Minoset of is not known. Minoset is used to treat many conditions such as headache, muscle aches, arthritis, backache, toothaches, colds, and fevers. It relieves pain in mild arthritis but has no effect on the underlying inflammation and swelling of the joint.');

-- --------------------------------------------------------

--
-- Table structure for table `medicinetype`
--

DROP TABLE IF EXISTS `medicinetype`;
CREATE TABLE IF NOT EXISTS `medicinetype` (
  `type` varchar(15) COLLATE utf32_turkish_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf32 COLLATE=utf32_turkish_ci;

--
-- Dumping data for table `medicinetype`
--

INSERT INTO `medicinetype` (`type`) VALUES
('Antibiotic'),
('Painkiller'),
('Antidepressant'),
('Nervine'),
('Vitamins'),
('Lotion'),
('Cold tablets');

-- --------------------------------------------------------

--
-- Table structure for table `patientinfo`
--

DROP TABLE IF EXISTS `patientinfo`;
CREATE TABLE IF NOT EXISTS `patientinfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) COLLATE utf32_turkish_ci NOT NULL,
  `surname` varchar(20) COLLATE utf32_turkish_ci NOT NULL,
  `age` varchar(20) COLLATE utf32_turkish_ci NOT NULL,
  `gender` varchar(20) COLLATE utf32_turkish_ci NOT NULL,
  `tcnum` varchar(20) COLLATE utf32_turkish_ci NOT NULL,
  `phone` varchar(20) COLLATE utf32_turkish_ci NOT NULL,
  `clinic` varchar(20) COLLATE utf32_turkish_ci NOT NULL,
  `doctor` varchar(20) COLLATE utf32_turkish_ci NOT NULL,
  `medicine` longtext COLLATE utf32_turkish_ci,
  `diagnosis` longtext COLLATE utf32_turkish_ci,
  `comments` longtext COLLATE utf32_turkish_ci,
  `priority` int(1) NOT NULL,
  `secretary` varchar(20) COLLATE utf32_turkish_ci NOT NULL,
  `dateTime` varchar(20) COLLATE utf32_turkish_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=utf32 COLLATE=utf32_turkish_ci;

--
-- Dumping data for table `patientinfo`
--

INSERT INTO `patientinfo` (`id`, `name`, `surname`, `age`, `gender`, `tcnum`, `phone`, `clinic`, `doctor`, `medicine`, `diagnosis`, `comments`, `priority`, `secretary`, `dateTime`) VALUES
(1, 'mete', 'kaba', '1996', 'Male', '32377623452', '5419056587', 'Psychiatry', 'Mete KABA', 'Paxil   x3\nRileptid   x1\n', NULL, 'Gelecek kaygisi var.', 1, 'admin', '20.12.2018 16:46:05'),
(2, 'dghsr', 'dngfhsrfghhg', '1996', 'Male', '32377623454', '5419056588', 'Ear Nose and Throat', 'Teynur YILDIZ', 'Paxil   x1\nRileptid   x1\nColdaway   x1\n', NULL, NULL, 1, 'admin', NULL),
(3, 'misel', 'tur', '1998', 'Male', '87272465966', '5419056588', 'Psychiatry', 'Mete KABA', 'Paxil   x3\nRileptid   x1\nRileptid   x1\nPaxera   x1\nColdaway   x2\n', NULL, 'Gelecek kaygisi var.', 1, 'admin', '20.12.2018 16:46:30'),
(4, 'psikopat', 'psikopatoglu', '1900', 'Male', '57916475576', '5469253645', 'Psychiatry', 'Mete KABA', 'Paxera   x2\n', NULL, 'gidici', 0, 'admin', '20.12.2018 17:47:11'),
(7, 'mert', 'yusel', '1993', 'Male', '47720279446', '5392681749', 'Psychiatry', 'Mete KABA', 'Paxil   x1\nRileptid   x1\n', NULL, 'Ne gergin adam!!!', 1, 'admin', '8.01.2019 21:41:16'),
(8, 'robert', 'kozak', '2000', 'Male', '84873493084', '5332681478', 'Psychiatry', 'Mete KABA', 'Paxil   x1\nRileptid   x1\nPaxil   x1\n', NULL, 'Ne gergin adam!!!', 1, 'admin', '8.01.2019 21:42:00'),
(9, 'robert', 'kozak', '2000', 'Male', '84873493084', '5332681478', 'Psychiatry', 'Mete KABA', 'Paxil   x2\nRileptid   x1\n', NULL, 'No comment', 1, 'admin', '8.01.2019 21:43:04'),
(10, 'teynurss', 'teynurssss', '1945', 'Male', '36442150836', '5343005521', 'Psychiatry', 'Mete KABA', 'Rileptid   x1\n', NULL, 'Sakin ol Teynurssss!!!!', 0, 'admin', '9.01.2019 12:49:05'),
(11, 'ozan', 'atabak', '1958', 'Male', '11265944046', '5343005521', 'Psychiatry', 'Mete KABA', 'Paxil   x2\n', NULL, 'Hafif dikkat eksikligi Mevcut. Obsesif Kompulsif Bozukluk', 1, 'admin', '9.01.2019 12:53:31');

-- --------------------------------------------------------

--
-- Table structure for table `patientinfotemp`
--

DROP TABLE IF EXISTS `patientinfotemp`;
CREATE TABLE IF NOT EXISTS `patientinfotemp` (
  `id` int(4) NOT NULL AUTO_INCREMENT,
  `tcnum` bigint(11) NOT NULL,
  `name` varchar(20) COLLATE utf32_turkish_ci NOT NULL,
  `surname` varchar(20) COLLATE utf32_turkish_ci NOT NULL,
  `age` int(4) NOT NULL,
  `phone` bigint(10) NOT NULL,
  `priority` int(1) NOT NULL,
  `clinic` varchar(15) COLLATE utf32_turkish_ci NOT NULL,
  `doctor` varchar(30) COLLATE utf32_turkish_ci NOT NULL,
  `gender` varchar(10) COLLATE utf32_turkish_ci NOT NULL,
  `secretary` varchar(20) COLLATE utf32_turkish_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=40 DEFAULT CHARSET=utf32 COLLATE=utf32_turkish_ci;

--
-- Dumping data for table `patientinfotemp`
--

INSERT INTO `patientinfotemp` (`id`, `tcnum`, `name`, `surname`, `age`, `phone`, `priority`, `clinic`, `doctor`, `gender`, `secretary`) VALUES
(39, 36442150836, 'teynurss', 'teynurssss', 1945, 5343005521, 0, 'Psychiatry', 'Mete KABA', 'Male', 'admin'),
(38, 11265944046, 'ozan', 'atabak', 1958, 5343005521, 1, 'Psychiatry', 'Mete KABA', 'Male', 'admin'),
(36, 84873493084, 'robert', 'kozak', 2000, 5332681478, 1, 'Psychiatry', 'Mete KABA', 'Male', 'admin'),
(37, 47720279446, 'mert', 'yusel', 1993, 5392681749, 1, 'Psychiatry', 'Mete KABA', 'Male', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `secpage`
--

DROP TABLE IF EXISTS `secpage`;
CREATE TABLE IF NOT EXISTS `secpage` (
  `no` int(3) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) COLLATE utf32_turkish_ci NOT NULL,
  `surname` varchar(20) COLLATE utf32_turkish_ci NOT NULL,
  `tcnum` varchar(11) COLLATE utf32_turkish_ci NOT NULL,
  `phone` varchar(15) COLLATE utf32_turkish_ci NOT NULL,
  `password` varchar(20) COLLATE utf32_turkish_ci NOT NULL,
  `clinic` varchar(20) COLLATE utf32_turkish_ci NOT NULL,
  PRIMARY KEY (`no`)
) ENGINE=MyISAM AUTO_INCREMENT=32 DEFAULT CHARSET=utf32 COLLATE=utf32_turkish_ci;

--
-- Dumping data for table `secpage`
--

INSERT INTO `secpage` (`no`, `name`, `surname`, `tcnum`, `phone`, `password`, `clinic`) VALUES
(1, 'admin', 'Eke', '65464', '1618651', 'admin', 'Psychiatry'),
(31, 'Algi', 'Yaman', '69543218', '645982', '123789', 'Ear Nose and Throat');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
