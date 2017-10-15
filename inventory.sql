-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Oct 15, 2017 at 02:12 PM
-- Server version: 5.7.19
-- PHP Version: 5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `inventory`
--

-- --------------------------------------------------------

--
-- Table structure for table `attendance`
--

DROP TABLE IF EXISTS `attendance`;
CREATE TABLE IF NOT EXISTS `attendance` (
  `date` varchar(10) NOT NULL,
  `sId` int(2) NOT NULL,
  `inTime` char(5) DEFAULT NULL,
  `offTime` char(5) DEFAULT NULL,
  `otHrs` int(2) DEFAULT NULL,
  PRIMARY KEY (`sId`,`date`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `attendance`
--

INSERT INTO `attendance` (`date`, `sId`, `inTime`, `offTime`, `otHrs`) VALUES
('2017-09-27', 1, '21:20', '21:21', 0),
('2017-09-28', 1, '19:15', '19:40', 0),
('2017-10-15', 1, '13:32', NULL, NULL),
('2017-10-15', 3, '11:34', NULL, NULL),
('2017-10-04', 4, '18:46', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `bank`
--

DROP TABLE IF EXISTS `bank`;
CREATE TABLE IF NOT EXISTS `bank` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(200) NOT NULL,
  `Amount` double NOT NULL,
  `Date` varchar(100) NOT NULL,
  `Status` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bank`
--

INSERT INTO `bank` (`id`, `Description`, `Amount`, `Date`, `Status`) VALUES
(1, 'september bill', 10000, '9/22/2017 5:21:23 PM', 0),
(2, 'september bill', 10000, '9/22/2017 5:23:18 PM', 0),
(3, 'september bill', 10000, '9/22/2017 5:24:35 PM', 0),
(4, 'september bill', 10000, '9/22/2017 5:25:43 PM', 0),
(5, 'september bill', 10000, '9/22/2017 5:26:00 PM', 0),
(6, 'september bill', 10000, '9/22/2017 5:28:59 PM', 0),
(7, 'september bill', 10000, '9/22/2017 5:47:41 PM', 0),
(8, 'xxx', 10000, '9/22/2017 12:00:00 AM', 0),
(9, 'september bill', 10000, '9/22/2017 12:00:00 AM', 0),
(10, 'xxx', 10000, '9/22/2017 12:00:00 AM', 0),
(11, 'www', 15000, '9/22/2017 12:00:00 AM', 0),
(12, 'september bill', 10000, '9/22/2017 12:00:00 AM', 0),
(13, 'september bill', 10000, '9/22/2017 12:00:00 AM', 0),
(14, 'xvxfv', 100, '9/23/2017 12:00:00 AM', 0),
(15, 'dsdsfsdf', 1000, '9/23/2017 12:00:00 AM', 0),
(16, 'fgfgd', 1200, '9/23/2017 12:00:00 AM', 0),
(17, 'july bill', 10000, '9/23/2017 12:00:00 AM', 0),
(18, 'july bill', 30000, '9/23/2017 12:00:00 AM', 0),
(19, 'dfssdfsdf', 10000, '9/23/2017 12:00:00 AM', 0),
(20, 'september', 20000, '23/09/2017', 0),
(21, 'september', 20000, '23/09/2017', 0),
(22, 'new month', 12500, '27-09-2017', 0),
(23, 'PMT00000004', 40000, '2017-10-15 12:35:59', 1);

-- --------------------------------------------------------

--
-- Table structure for table `batch`
--

DROP TABLE IF EXISTS `batch`;
CREATE TABLE IF NOT EXISTS `batch` (
  `batchNo` int(11) NOT NULL AUTO_INCREMENT,
  `currentJob` varchar(30) CHARACTER SET utf8 NOT NULL,
  `noOfEmp` int(11) NOT NULL,
  `workingHrs` int(11) NOT NULL,
  `costPerUnit` int(11) NOT NULL,
  `units` int(11) NOT NULL,
  `total` int(11) NOT NULL,
  PRIMARY KEY (`batchNo`),
  UNIQUE KEY `batchNo` (`batchNo`)
) ENGINE=InnoDB AUTO_INCREMENT=1001 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `batch`
--

INSERT INTO `batch` (`batchNo`, `currentJob`, `noOfEmp`, `workingHrs`, `costPerUnit`, `units`, `total`) VALUES
(100, 'Design / Sketch', 10, 20, 40, 100, 4000),
(200, 'Design', 5, 10, 120, 40, 4800),
(300, 'Sketch', 5, 8, 80, 60, 4800),
(400, 'Pattern Design', 5, 10, 600, 100, 60000),
(500, 'Grading', 20, 5, 80, 75, 6000),
(600, 'Inspection', 10, 20, 100, 40, 4000),
(700, 'Pressing', 15, 6, 300, 800, 240000),
(800, 'Sewing', 15, 6, 1200, 300, 360000),
(900, 'Cutting', 15, 6, 300, 120, 36000),
(1000, 'Sample Making', 15, 10, 220, 200, 44000);

-- --------------------------------------------------------

--
-- Table structure for table `canceledpayment`
--

DROP TABLE IF EXISTS `canceledpayment`;
CREATE TABLE IF NOT EXISTS `canceledpayment` (
  `paymentid` varchar(100) NOT NULL,
  `cid` varchar(10) NOT NULL,
  `invoiceNo` varchar(100) NOT NULL,
  `date1` varchar(100) NOT NULL,
  `EnteredBy` varchar(100) NOT NULL,
  `type` varchar(100) NOT NULL,
  `payingAmt` double NOT NULL,
  `OutstandingAmt` double NOT NULL,
  `drawnDate` varchar(100) NOT NULL,
  `checkNo` varchar(20) NOT NULL,
  `refNo` varchar(10) NOT NULL,
  `depositeTo` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `cashinhand`
--

DROP TABLE IF EXISTS `cashinhand`;
CREATE TABLE IF NOT EXISTS `cashinhand` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(100) NOT NULL,
  `Amount` double NOT NULL,
  `Date` varchar(100) NOT NULL,
  `Status` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cashinhand`
--

INSERT INTO `cashinhand` (`id`, `Description`, `Amount`, `Date`, `Status`) VALUES
(1, 'nnn', 100, '9/22/2017 5:36:55 PM', 0),
(2, 'xxx', 10000, '9/22/2017 5:39:55 PM', 0),
(3, 'aaa', 500, '9/22/2017 5:48:00 PM', 0),
(4, 'september bill', 10000, '9/22/2017 12:00:00 AM', 0),
(5, 'aaa', 500, '9/22/2017 12:00:00 AM', 0),
(6, 'fgfgd', 1200, '9/23/2017 12:00:00 AM', 0);

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
CREATE TABLE IF NOT EXISTS `customer` (
  `cid` varchar(10) NOT NULL,
  `name` varchar(100) NOT NULL,
  `pno1` int(11) NOT NULL,
  `pno2` int(11) NOT NULL,
  `address1` varchar(200) NOT NULL,
  `address2` varchar(200) NOT NULL,
  `Email` varchar(200) NOT NULL,
  `EnteredBy` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`cid`, `name`, `pno1`, `pno2`, `address1`, `address2`, `Email`, `EnteredBy`) VALUES
('001', 'Arumugam', 775454588, 775454589, 'No 15', 'wellawatte,colombo-06', 'Arumugam@gmail.com', 'Gowshi'),
('002', 'Ragul', 773432344, 773454566, 'No 16,', 'Colombo-04', 'ragul@yahoo.com', 'Gowshi'),
('003', 'Kumar', 774532333, 115454888, 'No,14', 'Hangulana', 'Kumar@hotmail.com', 'Gowshi'),
('004', 'Ragu', 771311123, 118988890, 'No 15', 'Halthamulla', 'Ragu@gmail.com', 'Gowshi'),
('005', 'Ram', 774334343, 773434343, 'No 18', 'Rakwana', 'Ram@gmail.com', 'Gowshi'),
('006', 'Shaffan', 771548445, 771548446, 'nolimit', 'wellawatte', 'shaffan@gmail.com', 'GOWSHI');

-- --------------------------------------------------------

--
-- Table structure for table `deliverydetails`
--

DROP TABLE IF EXISTS `deliverydetails`;
CREATE TABLE IF NOT EXISTS `deliverydetails` (
  `DID` int(11) NOT NULL AUTO_INCREMENT,
  `CID` varchar(10) NOT NULL,
  `showRoomLocation` varchar(100) NOT NULL,
  `address` varchar(200) NOT NULL,
  `phoneNo` int(100) NOT NULL,
  PRIMARY KEY (`DID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `deliverydetails`
--

INSERT INTO `deliverydetails` (`DID`, `CID`, `showRoomLocation`, `address`, `phoneNo`) VALUES
(1, '001', 'wellawatte', 'No 15 ramakrishna road', 112222255),
(6, '002', 'Ratmalana', '46', 555555555),
(7, '002', 'moratuwa', '65', 11454587),
(8, '006', 'dehiwela', 'dehiwela', 115854558);

-- --------------------------------------------------------

--
-- Table structure for table `designation`
--

DROP TABLE IF EXISTS `designation`;
CREATE TABLE IF NOT EXISTS `designation` (
  `id` int(2) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `bSal` double DEFAULT NULL,
  `otRate` double DEFAULT NULL,
  `leaves` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

--
-- Dumping data for table `designation`
--

INSERT INTO `designation` (`id`, `name`, `bSal`, `otRate`, `leaves`) VALUES
(0, 'Administrator', NULL, NULL, NULL),
(1, 'CEO', 128000, 750, 42),
(2, 'Managing Director', 124000, 750, 36),
(3, 'Asst. Manager', 100000, 700, 30),
(4, 'Accountant', 96500, 650, 28),
(5, 'Asst. Accountant', 90000, 650, 28),
(6, 'Sueprvisor', 86500, 600, 28),
(7, 'Sales Representative', 18500, 250, 36),
(8, 'Driver', 34500, 450, 28),
(9, 'Office Clerk', 18500, 350, 24),
(10, 'Labourer', 13500, 550, 24);

-- --------------------------------------------------------

--
-- Table structure for table `from_suppliers`
--

DROP TABLE IF EXISTS `from_suppliers`;
CREATE TABLE IF NOT EXISTS `from_suppliers` (
  `TripID` int(10) NOT NULL AUTO_INCREMENT,
  `SupplierName` varchar(40) NOT NULL,
  `SupplierAddress` varchar(200) NOT NULL,
  `Date` varchar(10) DEFAULT NULL,
  `Time` varchar(5) DEFAULT NULL,
  `StockWeight` int(10) NOT NULL,
  `NoOfTurn` int(5) NOT NULL,
  `VehicleNumber` varchar(8) NOT NULL,
  `Staffid` int(3) NOT NULL,
  PRIMARY KEY (`TripID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `from_suppliers`
--

INSERT INTO `from_suppliers` (`TripID`, `SupplierName`, `SupplierAddress`, `Date`, `Time`, `StockWeight`, `NoOfTurn`, `VehicleNumber`, `Staffid`) VALUES
(5, 'nushra fawmy', 'ratnapura', '1/2/1963', NULL, 1300, 1, '122', 0),
(6, 'fareeda', 'dehiwala', '1/2/1963', NULL, 2300, 1, '1223', 0),
(7, 'acchu', 'colombo', '1/1/1963', NULL, 45, 1, '1', 0),
(8, 'nushra fawmy', 'ratnapura', '1963-01-01', '', 1300, 1, '122', 2);

-- --------------------------------------------------------

--
-- Table structure for table `invoice`
--

DROP TABLE IF EXISTS `invoice`;
CREATE TABLE IF NOT EXISTS `invoice` (
  `cid` varchar(10) NOT NULL,
  `invoiceNo` varchar(14) NOT NULL,
  `cashDisc` double NOT NULL,
  `qtyDisc` double NOT NULL,
  `specDisc` double NOT NULL,
  `totCost` double NOT NULL,
  `netCost` double NOT NULL,
  `seller` varchar(200) NOT NULL,
  `totQty` int(255) NOT NULL,
  `deliveryTo` varchar(100) NOT NULL,
  `deliverDate` varchar(100) NOT NULL,
  `remark` varchar(200) NOT NULL,
  `createdDate` varchar(100) NOT NULL,
  `createdBy` varchar(100) NOT NULL,
  `dueDate` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `invoice`
--

INSERT INTO `invoice` (`cid`, `invoiceNo`, `cashDisc`, `qtyDisc`, `specDisc`, `totCost`, `netCost`, `seller`, `totQty`, `deliveryTo`, `deliverDate`, `remark`, `createdDate`, `createdBy`, `dueDate`) VALUES
('002', 'INV00000001', 1140.35, 4882.5, 1140.35, 57017.5, 49854.3, 'Mohan', 58, 'Ratmalana', '2017-10-13 12:00:00 AM', 'festival', '19/09/2017', 'Gowshi', '18/12/2017'),
('004', 'INV00000002', 0, 560, 0, 9900, 9340, 'Navam', 17, 'moratuwa', '2017-10-13 12:00:00 AM', 'dfs', '19/09/2017', 'Gowshi', '18-12-2017'),
('004', 'INV00000003', 240, 0, 0, 12000, 11760, 'dfsf', 15, 'rakvana', '2017-10-13 12:00:00 AM', 'sd', '05-10-2017', '', '03-01-2018'),
('004', 'INV00000004', 0, 10920, 1848, 30800, 18032, 'hgj', 31, 'rakwana', '2017-10-12 12:00:00 AM', '', '06-10-2017', '', '04-01-2018'),
('004', 'INV00000005', 0, 9100, 1488, 24800, 14212, 'fghf', 31, 'moratuwa', '2017-10-09 12:00:00 AM', '', '07-10-2017', '', '05-01-2018'),
('004', 'INV00000006', 0, 40250, 1020, 102000, 60730, 'ghgfgf', 120, 'aluthgama', '2017-10-10 12:00:00 AM', 'dfg', '09-10-2017', '', '07-01-2018'),
('004', 'INV00000007', 620, 0, 310, 31000, 30070, 'hgfhg', 30, 'rakwana', '2017-10-27 12:00:00 AM', 'hvhj', '10-10-2017', '', '08-01-2018'),
('004', 'INV00000008', 450, 0, 0, 22500, 22050, 'fsdf', 10, 'rakwana', '2017-10-27 12:00:00 AM', '', '10-10-2017', '', '08-01-2018'),
('006', 'INV00000009', 960, 17500, 0, 48000, 29540, '1111', 60, 'fdsdf', '2017-10-22 00:00:00', '', '15-10-2017', 'GOWSHI', '13-01-2018'),
('006', 'INV0000010', 0, 0, 0, 35000, 35000, 'jkf', 20, 'dehiwela', '2017-10-19 00:00:00', '', '15-10-2017', 'GOWSHI', '13-01-2018');

-- --------------------------------------------------------

--
-- Table structure for table `item`
--

DROP TABLE IF EXISTS `item`;
CREATE TABLE IF NOT EXISTS `item` (
  `itemCode` int(10) NOT NULL,
  `Location` varchar(50) NOT NULL,
  `sellingPrice` int(11) NOT NULL,
  `MRP` int(11) NOT NULL,
  `Discription` varchar(200) NOT NULL,
  KEY `Location` (`Location`),
  KEY `itemCode` (`itemCode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `item`
--

INSERT INTO `item` (`itemCode`, `Location`, `sellingPrice`, `MRP`, `Discription`) VALUES
(111110, 'Colombo', 1900, 2500, 'denim blue L Male'),
(111111, 'Colombo', 2000, 2500, 'Denim Black Female'),
(111112, 'Kurunagala', 1500, 1750, 'Yellow Pants XL male'),
(111113, 'Kurunagala', 800, 1000, 'Pink T-shirt L Female'),
(111114, 'Kurunagala', 750, 1000, 'Blue T-shirt XL male'),
(111115, 'Moratuwa', 800, 1250, 'Red T-Shirt XL male'),
(111116, 'Colombo', 3500, 5000, 'Green Plain saree Female'),
(111117, 'Colombo', 3500, 5000, 'RedPlain saree Female'),
(111118, 'Colombo', 35000, 50000, 'Gold Designed saree Female'),
(111119, 'Moratuwa', 750, 900, 'V neck yellow L '),
(111120, 'Moratuwa', 750, 900, 'V neck yellow XL '),
(111121, 'Kurunagala', 2500, 1800, 'camo Denim XL Male'),
(111122, 'Colombo', 500, 750, 'Sarom');

-- --------------------------------------------------------

--
-- Table structure for table `jobs`
--

DROP TABLE IF EXISTS `jobs`;
CREATE TABLE IF NOT EXISTS `jobs` (
  `jobId` int(11) NOT NULL AUTO_INCREMENT,
  `jobName` varchar(50) CHARACTER SET utf8 NOT NULL,
  `description` varchar(50) CHARACTER SET utf8 NOT NULL,
  `duration` int(11) NOT NULL,
  `noOfEmp` int(11) NOT NULL,
  `startingDate` date NOT NULL,
  `status` varchar(20) CHARACTER SET utf8 NOT NULL DEFAULT '0',
  PRIMARY KEY (`jobId`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `jobs`
--

INSERT INTO `jobs` (`jobId`, `jobName`, `description`, `duration`, `noOfEmp`, `startingDate`, `status`) VALUES
(1, 'Design / Sketch', 'dummy ', 20, 4, '2017-08-09', 'Disable'),
(2, 'Pattern Design', '', 20, 5, '2017-08-16', 'Enable'),
(3, 'Sample Making', '', 20, 0, '2017-09-12', 'Disable'),
(4, 'Production Pattern', 'sasa', 40, 0, '2017-09-20', 'Disable'),
(5, 'Grading', '', 0, 0, '2017-09-13', 'Disable'),
(6, 'Spreading', '', 80, 12, '2017-09-14', 'Enable'),
(7, 'Cutting', '', 40, 10, '2017-09-05', 'Disable'),
(8, 'Sorting/Bundling', '', 20, 10, '2017-09-14', 'Disable'),
(9, 'Sewing/Assembling', '', 100, 50, '2017-09-08', 'Enable'),
(10, 'Packing', '', 40, 15, '2017-09-23', 'Enable'),
(11, 'Despatch', '', 10, 5, '2017-09-13', 'Disable'),
(12, 'Inspection', '', 45, 15, '2017-09-02', 'Enable'),
(13, 'Pressing/ Finishing', '', 50, 10, '2017-09-28', 'Enable'),
(14, 'Final Inspection', '', 30, 10, '2017-09-19', 'Enable');

-- --------------------------------------------------------

--
-- Table structure for table `leasing_details`
--

DROP TABLE IF EXISTS `leasing_details`;
CREATE TABLE IF NOT EXISTS `leasing_details` (
  `LeaserID` int(11) NOT NULL AUTO_INCREMENT,
  `VehicleNumber` varchar(8) NOT NULL,
  `LeaserName` varchar(100) NOT NULL,
  `LeaserAddress` varchar(200) NOT NULL,
  `PhoneNumber` int(10) NOT NULL,
  `StartDate` varchar(10) DEFAULT NULL,
  `EndDate` varchar(10) DEFAULT NULL,
  `Interestrate` double NOT NULL,
  `InitialPayement` double NOT NULL,
  `Balance` double NOT NULL,
  PRIMARY KEY (`LeaserID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `leasing_details`
--

INSERT INTO `leasing_details` (`LeaserID`, `VehicleNumber`, `LeaserName`, `LeaserAddress`, `PhoneNumber`, `StartDate`, `EndDate`, `Interestrate`, `InitialPayement`, `Balance`) VALUES
(2, '1', 'amna bank', 'colombo 10', 1234567890, '1963-01-22', '1963-01-29', 12, 12000, 36000),
(3, '3', 'LOLC Finance', 'Dehiwala', 771234567, '1999-06-01', '1999-12-31', 5, 35000, 41750);

-- --------------------------------------------------------

--
-- Table structure for table `location`
--

DROP TABLE IF EXISTS `location`;
CREATE TABLE IF NOT EXISTS `location` (
  `location` varchar(20) NOT NULL,
  PRIMARY KEY (`location`),
  UNIQUE KEY `location_2` (`location`),
  KEY `location` (`location`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `location`
--

INSERT INTO `location` (`location`) VALUES
('Colombo'),
('Kurunagala'),
('Moratuwa');

-- --------------------------------------------------------

--
-- Table structure for table `loyalty`
--

DROP TABLE IF EXISTS `loyalty`;
CREATE TABLE IF NOT EXISTS `loyalty` (
  `sId` int(2) NOT NULL,
  `month` char(5) NOT NULL,
  `type` int(1) NOT NULL,
  `amount` double DEFAULT NULL,
  PRIMARY KEY (`sId`,`month`,`type`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `manemp`
--

DROP TABLE IF EXISTS `manemp`;
CREATE TABLE IF NOT EXISTS `manemp` (
  `empId` int(11) NOT NULL AUTO_INCREMENT,
  `type` text CHARACTER SET utf8 NOT NULL,
  `noOfEmp` int(11) NOT NULL,
  PRIMARY KEY (`empId`),
  UNIQUE KEY `empId` (`empId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `manemp`
--

INSERT INTO `manemp` (`empId`, `type`, `noOfEmp`) VALUES
(1, 'Designer', 3),
(2, 'Spreader', 10),
(3, 'Cutter', 15),
(4, 'Sewer', 25),
(5, 'Packing', 20),
(6, 'Supervisor', 5),
(7, 'Analyser', 5),
(8, 'Pressor', 7),
(9, 'Pattern maker', 4),
(10, 'grader', 7);

-- --------------------------------------------------------

--
-- Table structure for table `manufactitem`
--

DROP TABLE IF EXISTS `manufactitem`;
CREATE TABLE IF NOT EXISTS `manufactitem` (
  `itemNo` int(11) NOT NULL DEFAULT '300000',
  `itemName` varchar(30) CHARACTER SET utf8 NOT NULL,
  `image` text CHARACTER SET utf8 NOT NULL,
  `totQty` int(11) NOT NULL,
  `deliverDate` date NOT NULL,
  `deliverStatus` varchar(20) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`itemNo`),
  UNIQUE KEY `itemName` (`itemName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `manufactitem`
--

INSERT INTO `manufactitem` (`itemNo`, `itemName`, `image`, `totQty`, `deliverDate`, `deliverStatus`) VALUES
(500, 'Denim', '', 800, '2017-09-13', 'Delivered'),
(30000, 'Denim blue L Female', '', 250, '2017-09-20', 'Delivered'),
(30100, 'Denim blue XL Female', '', 350, '2017-09-13', 'Delivered'),
(30102, 'blue', '', 350, '2017-09-29', 'Pending'),
(30200, 'T-Shirt Black XL male', '', 550, '2017-09-30', 'Pending'),
(30300, 'T-Shirt Pink S female', '', 560, '2017-10-10', 'Pending'),
(30387, 'Jeans', '', 400, '2017-09-05', 'Delivered'),
(60200, 'Blouse', '', 250, '2017-09-28', 'Pending'),
(300456, 'Shirt (Girl)', '', 300, '2017-09-04', 'Delivered'),
(301300, 'Shirt', '', 200, '2017-09-20', 'Delivered');

-- --------------------------------------------------------

--
-- Table structure for table `manufactraw`
--

DROP TABLE IF EXISTS `manufactraw`;
CREATE TABLE IF NOT EXISTS `manufactraw` (
  `rawMaterialID` int(11) NOT NULL,
  `rawMaterialName` varchar(30) CHARACTER SET utf8 NOT NULL,
  `availableNow` int(11) NOT NULL,
  `reorderLevel` int(11) NOT NULL,
  `orderAmount` int(11) NOT NULL,
  `toOrder` varchar(10) CHARACTER SET utf8 NOT NULL DEFAULT '0',
  PRIMARY KEY (`rawMaterialID`),
  UNIQUE KEY `rawMaterialID` (`rawMaterialID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `manufactraw`
--

INSERT INTO `manufactraw` (`rawMaterialID`, `rawMaterialName`, `availableNow`, `reorderLevel`, `orderAmount`, `toOrder`) VALUES
(1000, 'CLOTH', 100, 50, 200, 'YES'),
(2000, 'THREAD', 75, 25, 100, 'NO'),
(3000, 'YARN', 125, 100, 250, 'YES'),
(4000, 'COTTON', 200, 100, 500, 'YES'),
(5000, 'BUTTONS', 1000, 250, 250, 'NO'),
(6000, 'RIBBON', 100, 50, 300, 'NO'),
(7000, 'LACE', 400, 100, 400, 'YES'),
(8000, 'FABRIC', 200, 50, 300, 'NO'),
(9000, 'DENIM MATERIAL', 200, 500, 600, 'YES'),
(90000, 'BLOUSE MATERIAL', 200, 500, 600, 'YES');

-- --------------------------------------------------------

--
-- Table structure for table `monthlyexpenses`
--

DROP TABLE IF EXISTS `monthlyexpenses`;
CREATE TABLE IF NOT EXISTS `monthlyexpenses` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `expenditureName` varchar(100) NOT NULL,
  `amount` double NOT NULL,
  `description` varchar(100) NOT NULL,
  `date` varchar(20) NOT NULL,
  `accountType` varchar(100) NOT NULL,
  `chequeNo` int(11) NOT NULL,
  `drawnDate` varchar(20) NOT NULL,
  `status` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=136 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `monthlyexpenses`
--

INSERT INTO `monthlyexpenses` (`id`, `expenditureName`, `amount`, `description`, `date`, `accountType`, `chequeNo`, `drawnDate`, `status`) VALUES
(130, 'Electricity Bill', 10000, 'july bill', '11/10/2017', 'Cheque', 123, '11/10/2017', 0),
(132, 'Stationary', 10000, 'dfssdfsdf', '23/09/2017', 'Cheque', 1234, '11/10/2017', 0),
(133, 'Electricity Bill', 20000, 'september', '23/09/2017', 'Cheque', 1234, '11/10/2017', 0),
(134, 'Telephone Bill', 20000, 'september', '23/09/2017', 'Cheque', 1234, '11/10/2017', 0),
(135, 'Electricity Bill', 12500, 'new month', '27-09-2017', 'Cheque', 485968, '23-11-2017', 0);

-- --------------------------------------------------------

--
-- Table structure for table `oitems`
--

DROP TABLE IF EXISTS `oitems`;
CREATE TABLE IF NOT EXISTS `oitems` (
  `ItemCode` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `UnitPrice` int(11) NOT NULL,
  `ono` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `oitems`
--

INSERT INTO `oitems` (`ItemCode`, `Quantity`, `UnitPrice`, `ono`) VALUES
(111110, 100, 700, 6),
(111110, 100, 500, 7),
(111111, 100, 500, 7),
(111112, 100, 350, 7),
(111113, 100, 350, 7),
(111110, 100, 600, 8),
(111111, 100, 550, 8),
(111112, 100, 300, 8),
(111113, 100, 300, 8),
(111114, 100, 350, 9),
(111115, 100, 350, 9),
(111116, 20, 2500, 9),
(111117, 20, 2500, 9),
(111114, 100, 300, 10),
(111115, 100, 300, 10),
(111116, 20, 2200, 10),
(111117, 20, 2500, 10),
(111121, 500, 1400, 11);

-- --------------------------------------------------------

--
-- Table structure for table `orderdetails`
--

DROP TABLE IF EXISTS `orderdetails`;
CREATE TABLE IF NOT EXISTS `orderdetails` (
  `invoiceNo` varchar(14) NOT NULL,
  `ItemNo` varchar(10) NOT NULL,
  `qty` int(10) NOT NULL,
  `disc` double NOT NULL,
  `totcost` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `orderdetails`
--

INSERT INTO `orderdetails` (`invoiceNo`, `ItemNo`, `qty`, `disc`, `totcost`) VALUES
('INV00000001', '123741', 16, 280, 9320),
('INV00000001', '123456', 14, 3675, 3325),
('INV00000001', '987456', 13, 297.5, 7502.5),
('INV00000001', '784512', 15, 630, 36870),
('INV00000002', '123456', 3, 0, 1500),
('INV00000002', '123741', 14, 560, 8400),
('INV00000002', '987456', 45, 9817.5, 27000),
('INV00000002', '1234567892', 5, 0, 4000),
('INV00000003', '1234567892', 0, 0, 0),
('INV00000003', '1234567893', 10, 0, 8000),
('INV00000003', '1234567894', 5, 0, 4000),
('INV00000003', '1234567898', 0, 0, 0),
('INV00000004', '1234567896', 26, 10920, 20800),
('INV00000004', '1234567890', 5, 0, 10000),
('INV00000005', '1234567895', 26, 9100, 20800),
('INV00000005', '1234567893', 5, 0, 4000),
('INV00000006', '1234567893', 25, 8750, 20000),
('INV00000006', '1234567890', 5, 0, 10000),
('INV00000006', '1234567894', 90, 31500, 72000),
('INV00000007', '1234567897', 10, 0, 15000),
('INV00000007', '1234567893', 10, 0, 8000),
('INV00000007', '1234567896', 10, 0, 8000),
('INV00000008', '1234567890', 5, 0, 10000),
('INV00000008', '1234567891', 5, 0, 12500),
('INV00000009', '111113', 50, 17500, 40000),
('INV00000009', '111115', 10, 0, 8000),
('INV0000010', '111112', 10, 0, 15000),
('INV0000010', '111111', 10, 0, 20000);

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
CREATE TABLE IF NOT EXISTS `orders` (
  `sname` varchar(100) NOT NULL,
  `total` float NOT NULL,
  `pamount` float NOT NULL,
  `pmethod` varchar(10) NOT NULL,
  `balance` float NOT NULL,
  `ono` int(11) NOT NULL AUTO_INCREMENT,
  `date` varchar(100) NOT NULL,
  PRIMARY KEY (`ono`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`sname`, `total`, `pamount`, `pmethod`, `balance`, `ono`, `date`) VALUES
('Kavisha Shivangana', 70000, 65000, 'Cash', 5000, 6, '2017-10-02 19:23:48'),
('Kavisha Shivangana', 170000, 150000, 'Cash', 25000, 7, '2017-10-04 17:47:38'),
('Shehan Mark', 175000, 150000, 'Cash', 25000, 8, '2017-10-04 17:48:14'),
('Domink Dealwis', 170000, 180000, 'Cash', -10000, 9, '2017-10-04 17:49:48'),
('Anjelo Fernando', 154000, 180000, 'Cash', -26000, 10, '2017-10-04 17:50:21'),
('Shehan Mark', 700000, 650000, 'Card', 75000, 11, '2017-10-14 23:56:58');

-- --------------------------------------------------------

--
-- Table structure for table `payment`
--

DROP TABLE IF EXISTS `payment`;
CREATE TABLE IF NOT EXISTS `payment` (
  `paymentid` varchar(100) NOT NULL,
  `cid` varchar(10) NOT NULL,
  `invoiceNo` varchar(100) NOT NULL,
  `date1` varchar(100) NOT NULL,
  `EnteredBy` varchar(100) NOT NULL,
  `type` varchar(100) NOT NULL,
  `payingAmt` double NOT NULL,
  `OutstandingAmt` double NOT NULL,
  `drawnDate` varchar(100) NOT NULL,
  `checkNo` varchar(20) NOT NULL,
  `refNo` varchar(10) NOT NULL,
  `depositeTo` varchar(100) NOT NULL,
  PRIMARY KEY (`paymentid`,`invoiceNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `payment`
--

INSERT INTO `payment` (`paymentid`, `cid`, `invoiceNo`, `date1`, `EnteredBy`, `type`, `payingAmt`, `OutstandingAmt`, `drawnDate`, `checkNo`, `refNo`, `depositeTo`) VALUES
('PMT00000000', '000', '', '', '', '', 0, 0, '', '', '', ''),
('PMT00000002', '004', 'INV00000007', '2017-10-10 11:45:43 AM', 'Gowshi', 'Credit', 30070, -30070, '2017-10-10', '5555', '', 'Check'),
('PMT00000003', '004', 'INV00000004', '2017-10-10 2:12:57 PM', '', 'Cash', 0, 18032, '2017-10-10', '', '55555', 'Cash in hand'),
('PMT00000003', '004', 'INV00000005', '2017-10-10 2:12:57 PM', '', 'Cash', 0, 14208, '2017-10-10', '', '55555', 'Cash in hand'),
('PMT00000003', '004', 'INV00000006', '2017-10-10 2:12:57 PM', '', 'Cash', 0, 60728, '2017-10-10', '', '55555', 'Cash in hand'),
('PMT00000003', '004', 'INV00000008', '2017-10-10 2:12:57 PM', '', 'Cash', 22050, 0, '2017-10-10', '', '55555', 'Cash in hand'),
('PMT00000004', '006', 'INV00000009', '2017-10-15 12:35:59', 'GOWSHI', 'Credit', 20000, 25575, '2017-10-15', '', '', 'Bank'),
('PMT00000004', '006', 'INV0000010', '2017-10-15 12:35:59', 'GOWSHI', 'Credit', 20000, 15000, '2017-10-15', '', '', 'Bank');

-- --------------------------------------------------------

--
-- Table structure for table `reorderlevel`
--

DROP TABLE IF EXISTS `reorderlevel`;
CREATE TABLE IF NOT EXISTS `reorderlevel` (
  `itemCode` int(10) NOT NULL,
  `reOrderPoint` int(11) NOT NULL,
  KEY `itemCode` (`itemCode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `reorderlevel`
--

INSERT INTO `reorderlevel` (`itemCode`, `reOrderPoint`) VALUES
(111110, 10),
(111111, 10),
(111112, 10),
(111113, 20),
(111114, 10),
(111115, 15),
(111116, 10),
(111117, 10),
(111118, 10),
(111119, 0),
(111120, 0),
(111121, 0),
(111122, 0);

-- --------------------------------------------------------

--
-- Table structure for table `requests`
--

DROP TABLE IF EXISTS `requests`;
CREATE TABLE IF NOT EXISTS `requests` (
  `sId` int(2) NOT NULL,
  `onDate` varchar(12) NOT NULL,
  `type` varchar(10) NOT NULL,
  `forDays` int(2) DEFAULT NULL,
  `amount` double DEFAULT NULL,
  `reqDate` varchar(12) NOT NULL,
  `status` varchar(10) NOT NULL DEFAULT 'PENDING',
  `term` int(1) DEFAULT NULL,
  PRIMARY KEY (`sId`,`onDate`,`type`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `requests`
--

INSERT INTO `requests` (`sId`, `onDate`, `type`, `forDays`, `amount`, `reqDate`, `status`, `term`) VALUES
(1, '2017-10-24', 'Half Day', NULL, NULL, '2017-10-15', 'PENDING', 0),
(1, '2017-10-31', 'Day Off', 1, NULL, '2017-10-14', 'PENDING', 0),
(1, '2017-11-15', 'Loan', NULL, 6000, '2017-10-14', 'PENDING', 0),
(2, '2017-11-16', 'Loan', NULL, 10000, '2017-10-15', 'PENDING', 0),
(2, '2018-01-09', 'Day Off', 1, NULL, '2017-10-15', 'APPROVED', 0),
(3, '2017-11-24', 'Loan', NULL, 50000, '2017-10-15', 'PENDING', 0);

-- --------------------------------------------------------

--
-- Table structure for table `returndetails`
--

DROP TABLE IF EXISTS `returndetails`;
CREATE TABLE IF NOT EXISTS `returndetails` (
  `dno` varchar(14) DEFAULT NULL,
  `itemNo` int(10) DEFAULT NULL,
  `qty` int(4) DEFAULT NULL,
  `wsp` double DEFAULT NULL,
  `total` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `returndetails`
--

INSERT INTO `returndetails` (`dno`, `itemNo`, `qty`, `wsp`, `total`) VALUES
('1', 111112, 2, 1500, 3000),
('1', 111113, 2, 800, 1600),
('1', 111114, 2, 750, 1500);

-- --------------------------------------------------------

--
-- Table structure for table `returns`
--

DROP TABLE IF EXISTS `returns`;
CREATE TABLE IF NOT EXISTS `returns` (
  `dno` varchar(14) NOT NULL,
  `cid` varchar(10) DEFAULT NULL,
  `created` varchar(10) DEFAULT NULL,
  `remarks` varchar(100) DEFAULT NULL,
  `total` double DEFAULT NULL,
  PRIMARY KEY (`dno`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `returns`
--

INSERT INTO `returns` (`dno`, `cid`, `created`, `remarks`, `total`) VALUES
('001', '006', '2017-10-15', 'someo', 6100);

-- --------------------------------------------------------

--
-- Table structure for table `returnstock`
--

DROP TABLE IF EXISTS `returnstock`;
CREATE TABLE IF NOT EXISTS `returnstock` (
  `itemCode` varchar(14) NOT NULL,
  `description` varchar(100) DEFAULT NULL,
  `pp` double DEFAULT NULL,
  `wsp` double DEFAULT NULL,
  `sp` double DEFAULT NULL,
  `qty` int(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `returnstock`
--

INSERT INTO `returnstock` (`itemCode`, `description`, `pp`, `wsp`, `sp`, `qty`) VALUES
('111112', 'Yellow Pants XL male', NULL, 1500, NULL, 2),
('111113', 'Pink T-shirt L Female', NULL, 800, NULL, 2),
('111114', 'Blue T-shirt XL male', NULL, 750, NULL, 2);

-- --------------------------------------------------------

--
-- Table structure for table `salary`
--

DROP TABLE IF EXISTS `salary`;
CREATE TABLE IF NOT EXISTS `salary` (
  `sId` int(2) NOT NULL,
  `month` char(5) NOT NULL,
  `bSal` double DEFAULT NULL,
  `incentive` double DEFAULT NULL,
  `epf` double DEFAULT NULL,
  `etf` double DEFAULT NULL,
  `sAdv` double DEFAULT NULL,
  `loan` double DEFAULT NULL,
  `nopay` double DEFAULT NULL,
  `allowance` double DEFAULT NULL,
  `comm` double DEFAULT NULL,
  PRIMARY KEY (`sId`,`month`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `service_details`
--

DROP TABLE IF EXISTS `service_details`;
CREATE TABLE IF NOT EXISTS `service_details` (
  `ServiceID` int(4) NOT NULL AUTO_INCREMENT,
  `VehicleNumber` varchar(8) NOT NULL,
  `ServiceType` varchar(100) NOT NULL,
  `ServiceDate` varchar(10) DEFAULT NULL,
  `ServiceAmount` double NOT NULL,
  `NextSerDate` varchar(10) NOT NULL,
  PRIMARY KEY (`ServiceID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `service_details`
--

INSERT INTO `service_details` (`ServiceID`, `VehicleNumber`, `ServiceType`, `ServiceDate`, `ServiceAmount`, `NextSerDate`) VALUES
(10, '123', '2', '1/1/1963', 1000, ''),
(11, '124', '-1', '1/15/1963', 1200, ''),
(12, '113', '2', '1/1/1963', 1235, ''),
(13, '1244', '1', '1/1/1963', 1000, ''),
(14, '12', '2', '1/1/1963', 1230, ''),
(15, '123', '2', '1/1/1963', 1000, ''),
(16, '12', 'System.Int32', '1/3/1963', 2000, ''),
(17, '10', 'Int32', '1/1/1963', 2000, ''),
(18, '10', '2', '1/1/1963', 100, ''),
(19, '140', '0', '1963-01-01', 2000, ''),
(20, '256', '-1', '1/24/1963', 2300, '2/8/1963');

-- --------------------------------------------------------

--
-- Table structure for table `settings`
--

DROP TABLE IF EXISTS `settings`;
CREATE TABLE IF NOT EXISTS `settings` (
  `name` varchar(50) NOT NULL,
  `address` varchar(200) NOT NULL,
  `tele` varchar(13) NOT NULL,
  `fax` varchar(13) NOT NULL,
  `email` varchar(30) NOT NULL,
  `sTime` char(4) NOT NULL,
  `oTime` char(4) NOT NULL,
  `hTime` char(4) NOT NULL,
  `image` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `settings`
--

INSERT INTO `settings` (`name`, `address`, `tele`, `fax`, `email`, `sTime`, `oTime`, `hTime`, `image`) VALUES
('Ewing Associates (Pvt) Ltd', '658/78 2/1,\nDanister De Silva Mawatha,\nColombo 9', '0112672732', '0112672732', 'info@ewingassociates.lk', '0730', '1700', '1230', 'C:\\Users\\Shehan Mark Fdo\\Desktop\\InventoryMgt\\EwingInventory\\Resources\\EwingPP.png');

-- --------------------------------------------------------

--
-- Table structure for table `staff`
--

DROP TABLE IF EXISTS `staff`;
CREATE TABLE IF NOT EXISTS `staff` (
  `sId` int(3) NOT NULL AUTO_INCREMENT,
  `uName` varchar(10) DEFAULT NULL,
  `pass` varchar(10) DEFAULT NULL,
  `fName` varchar(30) DEFAULT NULL,
  `lname` varchar(30) DEFAULT NULL,
  `add1` varchar(50) DEFAULT NULL,
  `add2` varchar(50) DEFAULT NULL,
  `religion` int(2) NOT NULL,
  `mob` varchar(15) DEFAULT NULL,
  `email` varchar(30) DEFAULT NULL,
  `nic` varchar(12) DEFAULT NULL,
  `access` int(1) DEFAULT NULL,
  `joined` date DEFAULT NULL,
  `dob` date DEFAULT NULL,
  `desig` int(2) DEFAULT NULL,
  `image` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`sId`),
  KEY `desig` (`desig`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `staff`
--

INSERT INTO `staff` (`sId`, `uName`, `pass`, `fName`, `lname`, `add1`, `add2`, `religion`, `mob`, `email`, `nic`, `access`, `joined`, `dob`, `desig`, `image`) VALUES
(0, 'ADMIN', 'admin', NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL),
(1, 'SHAFAN', 'sha', 'SHAFAN', 'NAZIM', '34, De Waas Lane', '34, De Waas Lane', 3, '755619134', 'mohamed.shafan@my.sliit.lk', '199514303063', 1, '1995-05-22', '1995-05-22', 1, 'C:\\Users\\Shehan Mark Fdo\\Desktop\\InventoryMgt\\EwingInventory\\Resources\\icon_user1.png'),
(2, 'JAJE', 'jaje', 'JAJE', 'THANAN', 'adfs', 'adfs', 2, '799856565', 'thanan@gmail.com', '959384321', 2, '1995-12-05', '1995-12-05', 3, NULL),
(3, 'GOWSHI', 'gowshi', 'GOWSHALINI', 'RAJALINGAM', '87', 'Dehiwala', 3, '776589532', 'gow@shi.com', '199658596586', 1, '1996-12-05', '1996-12-05', 2, 'E:\\Setup\\OP2\\OP2_Backup\\Image_and_Video\\Pictures\\Wallpapers\\20151218063256.jpg'),
(4, 'MARK', 'mark', 'SHEHAN', 'FERNANDO', '78', 'Kollupitiya', 4, '7685965865', 'she@han.lk', '965833512', 2, '2017-07-01', '1996-09-06', 3, NULL),
(5, 'NUSHRA', 'nush', 'NUSHARA', 'FAWMY', '40', '40', 3, '888595959', 'some@this.com', '199685665959', 2, '1992-04-22', '1992-04-22', 3, NULL),
(6, 'FAIZAAN', 'zaan', 'FAIZAAN', 'YAKOOB', '78', 'Maradara', 3, '778596325', 'some@thing.com', '956885742V', 2, '2017-10-15', '1995-05-03', 5, NULL),
(7, 'SAMAN', 'saman', 'SAMAN', 'LAKSHITHA', '859', '', 1, '759685324', 'im@robot.com', '865974263V', 2, '2017-10-15', '1986-12-03', 8, NULL),
(8, 'ANURA', 'anura', 'ANURA', 'KUMARA', '121', 'dwf', 1, '118596325', 'anura@ewing.lk', '199712365284', 2, '2017-10-15', '1997-01-31', 8, NULL),
(9, 'NIZAR', 'nizar', 'NIZAR', 'AHAMED', 'wr', '', 3, '112358695', 'dwi@ef.vh', '198015236595', 2, '2017-10-15', '1980-01-15', 8, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `staffpay`
--

DROP TABLE IF EXISTS `staffpay`;
CREATE TABLE IF NOT EXISTS `staffpay` (
  `sId` int(2) NOT NULL,
  `month` char(5) NOT NULL,
  `type` int(1) NOT NULL,
  `amount` double DEFAULT NULL,
  `term` int(2) DEFAULT NULL,
  PRIMARY KEY (`sId`,`month`,`type`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `stock`
--

DROP TABLE IF EXISTS `stock`;
CREATE TABLE IF NOT EXISTS `stock` (
  `quantity` int(11) NOT NULL,
  `itemCodes` int(10) NOT NULL,
  PRIMARY KEY (`itemCodes`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `stock`
--

INSERT INTO `stock` (`quantity`, `itemCodes`) VALUES
(100, 111110),
(90, 111111),
(90, 111112),
(50, 111113),
(100, 111114),
(90, 111115),
(20, 111116),
(20, 111117),
(0, 111118),
(0, 111119),
(0, 111120),
(450, 111121),
(0, 111122);

-- --------------------------------------------------------

--
-- Table structure for table `stockadjustments`
--

DROP TABLE IF EXISTS `stockadjustments`;
CREATE TABLE IF NOT EXISTS `stockadjustments` (
  `Date` varchar(160) NOT NULL,
  `itemCode` int(10) NOT NULL,
  `NewQuantity` int(11) NOT NULL,
  `PreviousQuantity` int(11) NOT NULL,
  `quantityLost` int(11) NOT NULL,
  `reason` varchar(200) NOT NULL,
  `Location` varchar(100) NOT NULL,
  PRIMARY KEY (`Date`,`itemCode`),
  KEY `itemCode` (`itemCode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `stockadjustments`
--

INSERT INTO `stockadjustments` (`Date`, `itemCode`, `NewQuantity`, `PreviousQuantity`, `quantityLost`, `reason`, `Location`) VALUES
('2017-10-14 23:58:34', 111121, 450, 500, 50, 'Rat problem', 'Kurunagala');

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

DROP TABLE IF EXISTS `supplier`;
CREATE TABLE IF NOT EXISTS `supplier` (
  `Name` varchar(100) NOT NULL,
  `Nic` varchar(10) NOT NULL,
  `Phone` int(11) NOT NULL,
  `fax` int(10) NOT NULL,
  `email` varchar(50) NOT NULL,
  `sid` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`sid`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`Name`, `Nic`, `Phone`, `fax`, `email`, `sid`) VALUES
('Kavisha Shivangana', '123654789V', 774068832, 774068832, 'KGirl@gmail.com', 19),
('Shehan Mark', '96987451V', 757987146, 757987146, 'shehan@gmail.com', 20),
('Domink Dealwis', '987876567V', 774449876, 774449876, 'DomAl@gmail.com', 22),
('Jakson Black', '871234658V', 774898765, 774898765, 'Jblack@gmail.com', 23),
('Anjelo Fernando', '912345678V', 774786576, 774786576, 'AnjFdo@gmail.com', 24),
('Carol Jonson', '889876787V', 778987354, 778987354, 'Cjonsen@gmail.com', 25),
('Trevor Philips', '789876778V', 770707707, 770707707, 'Trevo@sliit.com', 26),
('Bilbo Bagins', '699867857V', 789879987, 789879987, 'Bilboo@gmail.com', 27),
('Tom cruise', '874587452V', 775465842, 775845625, 'Tom@gmail.com', 28),
('safan', '154875482V', 775487845, 775487845, 'sa@gmail.com', 29);

-- --------------------------------------------------------

--
-- Table structure for table `to_customers`
--

DROP TABLE IF EXISTS `to_customers`;
CREATE TABLE IF NOT EXISTS `to_customers` (
  `TripID` int(10) NOT NULL AUTO_INCREMENT,
  `CustomerName` varchar(40) NOT NULL,
  `CustomerAddress` varchar(200) NOT NULL,
  `Date` varchar(10) DEFAULT NULL,
  `Time` varchar(10) DEFAULT NULL,
  `Stockweight` int(10) NOT NULL,
  `NoOfTurn` int(5) NOT NULL,
  `VehicleNumber` varchar(8) NOT NULL,
  `Staffid` int(3) NOT NULL,
  PRIMARY KEY (`TripID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `to_customers`
--

INSERT INTO `to_customers` (`TripID`, `CustomerName`, `CustomerAddress`, `Date`, `Time`, `Stockweight`, `NoOfTurn`, `VehicleNumber`, `Staffid`) VALUES
(5, 'nus', 'col', '1/2/1963', NULL, 124, 2, '1231', 0),
(6, 'ilma', 'bambalapitiya', '1/21/1963', NULL, 1400, 1, '23', 0),
(7, 'shahani', 'jaela', '1/1/1963', '12:30', 1500, 1, '123', 0),
(8, 'noori', 'kurunegala', '1/1/1963', '12:30', 1500, 1, '120', 3);

-- --------------------------------------------------------

--
-- Table structure for table `vehicle`
--

DROP TABLE IF EXISTS `vehicle`;
CREATE TABLE IF NOT EXISTS `vehicle` (
  `VehicleName` varchar(15) NOT NULL,
  `VehicleNumber` varchar(8) NOT NULL,
  `ChassisNumber` varchar(40) NOT NULL,
  `EngineNumber` varchar(40) NOT NULL,
  `Capacity` int(5) NOT NULL,
  `OilLeters` int(5) NOT NULL,
  `Cost` int(10) NOT NULL,
  PRIMARY KEY (`VehicleNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vehicle`
--

INSERT INTO `vehicle` (`VehicleName`, `VehicleNumber`, `ChassisNumber`, `EngineNumber`, `Capacity`, `OilLeters`, `Cost`) VALUES
('eee', '121', '131313', '1213', 12, 1, 1),
('eee', '1233', '132', '131v', 12, 1, 1),
('nghg', '125', '12', '123x', 122, 1, 12),
('eee', '45', '85988', '66546', 12, 10, 1);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `attendance`
--
ALTER TABLE `attendance`
  ADD CONSTRAINT `attendance_ibfk_1` FOREIGN KEY (`sId`) REFERENCES `staff` (`sId`);

--
-- Constraints for table `loyalty`
--
ALTER TABLE `loyalty`
  ADD CONSTRAINT `loyalty_ibfk_1` FOREIGN KEY (`sId`) REFERENCES `staff` (`sId`);

--
-- Constraints for table `salary`
--
ALTER TABLE `salary`
  ADD CONSTRAINT `salary_ibfk_1` FOREIGN KEY (`sId`) REFERENCES `staff` (`sId`);

--
-- Constraints for table `staff`
--
ALTER TABLE `staff`
  ADD CONSTRAINT `staff_ibfk_1` FOREIGN KEY (`desig`) REFERENCES `designation` (`id`);

--
-- Constraints for table `staffpay`
--
ALTER TABLE `staffpay`
  ADD CONSTRAINT `staffpay_ibfk_1` FOREIGN KEY (`sId`) REFERENCES `staff` (`sId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
