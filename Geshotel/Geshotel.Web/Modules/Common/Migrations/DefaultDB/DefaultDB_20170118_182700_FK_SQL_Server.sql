/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50716
Source Host           : localhost:3306
Source Database       : commonfiles

Target Server Type    : Microsoft SQL Server
Converted By		  : http://www.sqlines.com/online

Foreign Keys Referenced to another Schema seems not working in FluentMigrator

Date: 2017-01-20 16:00:42

Owner : Javier Nuñez
*/

ALTER TABLE [users] ADD FOREIGN KEY ([HotelId]) REFERENCES commonfiles.hoteles ([hotel_id]);
ALTER TABLE [users] ADD FOREIGN KEY ([EmpresaId]) REFERENCES commonfiles.empresas ([empresa_id]);
