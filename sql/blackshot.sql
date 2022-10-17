-- phpMyAdmin SQL Dump
-- version 4.0.4.2
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Oct 17, 2022 at 02:05 PM
-- Server version: 5.6.13
-- PHP Version: 5.4.17

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `blackshot`
--
CREATE DATABASE IF NOT EXISTS `blackshot` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `blackshot`;

-- --------------------------------------------------------

--
-- Table structure for table `accounts`
--

CREATE TABLE IF NOT EXISTS `accounts` (
  `Id` int(10) unsigned NOT NULL,
  `Username` varchar(17) NOT NULL DEFAULT '',
  `Password` varchar(32) NOT NULL DEFAULT '',
  `Country` varchar(2) DEFAULT '',
  `LastIP` varchar(15) DEFAULT '',
  `Account Number` int(10) unsigned NOT NULL,
  `Cash` int(11) DEFAULT NULL,
  `Slots` tinyint(1) DEFAULT NULL,
  `PCEvent` tinyint(1) DEFAULT NULL COMMENT 'If player is in a LAN tournament(Garena''s implementation)',
  KEY `Id` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `bans`
--

CREATE TABLE IF NOT EXISTS `bans` (
  `Account Number` int(10) DEFAULT NULL,
  `Ban Reason` varchar(50) DEFAULT NULL,
  `Ban Duration` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `characterinfo`
--

CREATE TABLE IF NOT EXISTS `characterinfo` (
  `Account Number` int(10) DEFAULT NULL,
  `Slot` tinyint(1) DEFAULT NULL,
  `Nickname` varchar(17) DEFAULT NULL,
  `Level` smallint(3) DEFAULT NULL,
  `Hero` tinyint(4) DEFAULT NULL,
  `Experience` int(11) DEFAULT NULL,
  `Bounty Points` int(11) DEFAULT NULL,
  `Kills` int(11) DEFAULT NULL,
  `Deaths` int(11) DEFAULT NULL,
  `Wins` int(11) DEFAULT NULL,
  `Losses` int(11) DEFAULT NULL,
  `Clan Name` int(11) DEFAULT NULL,
  `Clan Mark` int(11) DEFAULT NULL,
  `Skin Color` smallint(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `characteritems`
--

CREATE TABLE IF NOT EXISTS `characteritems` (
  `Account Number` int(10) DEFAULT NULL,
  `Slot` int(1) DEFAULT NULL,
  `Item Code` int(11) DEFAULT NULL,
  `Type` tinyint(4) DEFAULT NULL,
  `Item Number` int(11) DEFAULT NULL,
  `Minutes Left` int(11) DEFAULT NULL,
  `Seconds Left` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
