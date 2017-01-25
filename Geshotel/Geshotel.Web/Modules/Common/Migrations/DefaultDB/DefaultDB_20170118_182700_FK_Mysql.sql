/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50716
Source Host           : localhost:3306
Source Database       : commonfiles

Target Server Type    : MYSQL
Target Server Version : 50716
File Encoding         : 65001

Foreign Keys Referenced to another Schema seems not working in FluentMigrator

Date: 2017-01-20 16:00:42

Owner : Javier Nuñez
*/
ALTER TABLE `users` ADD FOREIGN KEY (`HotelId`) REFERENCES `geshotel_commonfiles_v1`.`hoteles` (`hotel_id`);
ALTER TABLE `users` ADD FOREIGN KEY (`EmpresaId`) REFERENCES `geshotel_commonfiles_v1`.`empresas` (`empresa_id`);

