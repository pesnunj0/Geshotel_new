# ---------------------------------------------------------------------- #
# Target DBMS:           MySQL 5                                         #
# Project name:          Geshotel                                        #
# Author:                Javier Nuñez                                    #
# Created on:            2017-01-23 20:00                                #
# Lo hice por script ya que Fluent el booleano lo crea tinyint           #
# y el tinyint para serenity es como un numero							 #
# ---------------------------------------------------------------------- #

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for clientes
-- ----------------------------
DROP TABLE IF EXISTS `clientes`;
CREATE TABLE `clientes` (
  `cliente_id` int(11) NOT NULL AUTO_INCREMENT,
  `razon` varchar(60) NOT NULL,
  `desc_corta` varchar(8) DEFAULT NULL,
  `nombre` varchar(30) DEFAULT NULL,
  `apellidos` varchar(50) DEFAULT NULL,
  `empresa_id` smallint(6) NOT NULL,
  `agencia_id` int(11) DEFAULT NULL,
  `mercado_id` smallint(6) DEFAULT NULL,
  `cliente_defecto` bit(4) NOT NULL DEFAULT b'0',
  `grupo_cliente_id` smallint(6) NOT NULL,
  `tipo_documento_id` char(1) DEFAULT NULL,
  `nif` varchar(20) DEFAULT NULL,
  `fecha_documento` date DEFAULT NULL,
  `sexo_id` char(1) DEFAULT NULL,
  `direccion` varchar(70) DEFAULT NULL,
  `poblacion` varchar(70) DEFAULT NULL,
  `zip` varchar(10) DEFAULT NULL,
  `nacion_id` smallint(6) DEFAULT NULL,
  `provincia_id` smallint(6) DEFAULT NULL,
  `cta_contable_anticipo` varchar(16) DEFAULT NULL,
  `cta_contable` varchar(16) DEFAULT NULL,
  `dpto_contable` varchar(5) DEFAULT NULL,
  `cta_depositos` varchar(15) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `fax` varchar(20) DEFAULT NULL,
  `contacto` varchar(70) DEFAULT NULL,
  `telefono_contacto` varchar(20) DEFAULT NULL,
  `fax_contacto` varchar(20) DEFAULT NULL,
  `email_contacto` varchar(100) DEFAULT NULL,
  `acepta_lopd` datetime DEFAULT NULL,
  `cif_fra` varchar(20) DEFAULT NULL,
  `direccion_fra` varchar(70) DEFAULT NULL,
  `poblacion_fra` varchar(70) DEFAULT NULL,
  `zip_fra` varchar(10) DEFAULT NULL,
  `nacion_id_factura` smallint(6) DEFAULT NULL,
  `provincia_id_factura` smallint(6) DEFAULT NULL,
  `Cliente_factura` bit(4) NOT NULL DEFAULT b'0',
  `Cliente_huesped` bit(4) NOT NULL,
  `permite_credito` bit(4) NOT NULL DEFAULT b'0',
  `limite_credito` float DEFAULT NULL,
  `factura_anticipada` bit(4) DEFAULT NULL,
  `vencimiento_facturas_id` smallint(6) DEFAULT NULL,
  `fecha_nacimiento` date DEFAULT NULL,
  `user_id` smallint(6) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  `cliente_bavel` varchar(20) DEFAULT NULL,
  `foto1` varchar(256) DEFAULT NULL,
  `foto2` varchar(256) DEFAULT NULL,
  `dingus_extras` bit(1) DEFAULT NULL,
  `id_clubhd` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`cliente_id`),
  KEY `grupo_cliente_id` (`grupo_cliente_id`),
  KEY `nacion_id` (`nacion_id`),
  KEY `provincia_id` (`provincia_id`),
  KEY `nacion_id_factura` (`nacion_id_factura`),
  KEY `provincia_id_factura` (`provincia_id_factura`),
  KEY `empresa_id` (`empresa_id`),
  KEY `cliente_defecto` (`cliente_defecto`),
  KEY `razon` (`razon`),
  KEY `nif` (`nif`),
  KEY `sexo_id` (`sexo_id`),
  KEY `tipo_documento_id` (`tipo_documento_id`),
  KEY `agencia_id` (`agencia_id`)
) ENGINE=InnoDB AUTO_INCREMENT=907568 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for lineas_de_contrato
-- ----------------------------
DROP TABLE IF EXISTS `lineas_de_contrato`;
CREATE TABLE `lineas_de_contrato` (
  `linea_contrato_id` int(11) NOT NULL AUTO_INCREMENT,
  `contrato_id` int(11) NOT NULL,
  `oferta` tinyint(1) DEFAULT NULL,
  `desde` date NOT NULL,
  `hasta` date NOT NULL,
  `servicio_id` int(11) NOT NULL,
  `unidad_calculo_id` smallint(2) NOT NULL,
  `frecuencia_id` smallint(6) DEFAULT '2',
  `tipo_imputacion_id` smallint(6) DEFAULT '0',
  `importe` float(15,3) NOT NULL,
  `n` smallint(6) DEFAULT NULL,
  `tipo_oferta_id` smallint(6) DEFAULT NULL,
  `m` float(12,2) DEFAULT NULL,
  `ambito_oferta_id` smallint(6) DEFAULT NULL,
  `lunes` tinyint(1) NOT NULL DEFAULT '1',
  `martes` bit(1) NOT NULL DEFAULT b'1',
  `miercoles` bit(1) NOT NULL DEFAULT b'1',
  `jueves` bit(1) NOT NULL DEFAULT b'1',
  `viernes` bit(1) NOT NULL DEFAULT b'1',
  `sabado` bit(1) NOT NULL DEFAULT b'1',
  `domingo` bit(1) NOT NULL DEFAULT b'1',
  `pag_factura` smallint(6) DEFAULT '1',
  `user_id` smallint(6) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`linea_contrato_id`),
  KEY `tipo_oferta_id` (`tipo_oferta_id`),
  KEY `unidad_calculo_id` (`unidad_calculo_id`),
  KEY `servicio_id` (`servicio_id`),
  KEY `lineas_de_contrato_1` (`contrato_id`),
  KEY `contrato_id` (`contrato_id`,`servicio_id`)
) ENGINE=InnoDB AUTO_INCREMENT=110148 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for contratos
-- ----------------------------
DROP TABLE IF EXISTS `contratos`;
CREATE TABLE `contratos` (
  `contrato_id` int(11) NOT NULL AUTO_INCREMENT,
  `hotel_id` smallint(6) NOT NULL,
  `cliente_id` int(11) NOT NULL,
  `fecha_contrato` date NOT NULL,
  `fecha_desde` date NOT NULL,
  `fecha_hasta` date NOT NULL,
  `contrato_id_original` int(11) DEFAULT NULL,
  `contrato_id_siguiente` int(11) DEFAULT NULL,
  `numero_contrato_cliente` varchar(40) DEFAULT NULL,
  `user_id` smallint(6) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  `temporada_id` smallint(6) DEFAULT NULL,
  `impuesto_incluido` tinyint(4) DEFAULT '1',
  `mercado_id` smallint(6) DEFAULT NULL,
  `cliente_id_padre` int(11) DEFAULT NULL,
  PRIMARY KEY (`contrato_id`),
  KEY `hotel_id` (`hotel_id`),
  KEY `cliente_id` (`cliente_id`),
  CONSTRAINT `contratos_ibfk_1` FOREIGN KEY (`hotel_id`) REFERENCES `Geshotel_commonfiles_v1`.`hoteles` (`hotel_id`),
  CONSTRAINT `contratos_ibfk_2` FOREIGN KEY (`cliente_id`) REFERENCES `clientes` (`cliente_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3405 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for contratos_edades
-- ----------------------------
DROP TABLE IF EXISTS `contratos_edades`;
CREATE TABLE `contratos_edades` (
  `contrato_id` int(11) NOT NULL,
  `tipo_huesped_id` smallint(6) NOT NULL,
  `edad_minima` int(11) NOT NULL,
  `edad_maxima` int(11) NOT NULL,
  `user_id` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`contrato_id`,`tipo_huesped_id`),
  KEY `tipo_huesped_id` (`tipo_huesped_id`),
  CONSTRAINT `contratos_edades_ibfk_1` FOREIGN KEY (`tipo_huesped_id`) REFERENCES `geshotel_commonfiles_v1`.`tipos_huesped` (`tipo_huesped_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for ofertas
-- ----------------------------
DROP TABLE IF EXISTS `ofertas`;
CREATE TABLE `ofertas` (
  `oferta_id` int(11) NOT NULL AUTO_INCREMENT,
  `texto` varchar(60) NOT NULL,
  `contrato_id` int(11) NOT NULL,
  `fecha_desde` date NOT NULL,
  `fecha_hasta` date NOT NULL,
  `tipo_aplicacion_oferta_id` varchar(1) NOT NULL,
  `aplicable_auto` bit(4) NOT NULL,
  `fecha_reserva_desde` date DEFAULT NULL,
  `fecha_reserva_hasta` date DEFAULT NULL,
  `estancia_minima_dias` smallint(6) DEFAULT NULL,
  `estancia_maxima_dias` smallint(6) DEFAULT NULL,
  `dias_de_antelacion` smallint(6) DEFAULT NULL,
  `tipo_servicio_id` smallint(6) DEFAULT NULL,
  `servicio_id` int(6) DEFAULT NULL,
  `unidad_calculo_id` smallint(6) DEFAULT NULL,
  `servicio_ligado_id` int(6) DEFAULT NULL,
  `cupo_oferta` smallint(6) DEFAULT NULL,
  `precio` decimal(15,3) DEFAULT NULL,
  `n` decimal(7,2) DEFAULT '0.00',
  `tipo_oferta_id` smallint(6) DEFAULT NULL,
  `m` decimal(15,3) DEFAULT '0.000',
  `ambito_oferta_id` smallint(6) DEFAULT NULL,
  `user_id` smallint(6) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  `impuesto_incluido` tinyint(4) DEFAULT '1',
  `tipo_imputacion_id` smallint(6) NOT NULL DEFAULT '0',
  `orden_aplicacion` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`oferta_id`),
  KEY `cliente_id` (`contrato_id`),
  KEY `tipo_aplicacion_oferta_id` (`tipo_aplicacion_oferta_id`),
  KEY `servicio_id` (`servicio_id`),
  KEY `ofertas_ibfk_10` (`servicio_ligado_id`),
  KEY `ofertas_ibfk_11` (`tipo_oferta_id`),
  KEY `ofertas_ibfk_12` (`ambito_oferta_id`),
  KEY `ofertas_ibfk_7` (`tipo_servicio_id`),
  KEY `ofertas_ibfk_9` (`unidad_calculo_id`),
  CONSTRAINT `ofertas_ibfk_10` FOREIGN KEY (`servicio_ligado_id`) REFERENCES `geshotel_commonfiles_v1`.`servicios` (`servicio_id`),
  CONSTRAINT `ofertas_ibfk_11` FOREIGN KEY (`tipo_oferta_id`) REFERENCES `geshotel_commonfiles_v1`.`tipos_de_oferta` (`tipo_oferta_id`),
  CONSTRAINT `ofertas_ibfk_12` FOREIGN KEY (`ambito_oferta_id`) REFERENCES `geshotel_commonfiles_v1`.`ambito_oferta` (`ambito_oferta_id`),
  CONSTRAINT `ofertas_ibfk_2` FOREIGN KEY (`tipo_aplicacion_oferta_id`) REFERENCES `geshotel_commonfiles_v1`.`tipo_aplicacion_oferta` (`tipo_aplicacion_oferta_id`),
  CONSTRAINT `ofertas_ibfk_3` FOREIGN KEY (`contrato_id`) REFERENCES `contratos` (`contrato_id`) ON DELETE CASCADE,
  CONSTRAINT `ofertas_ibfk_7` FOREIGN KEY (`tipo_servicio_id`) REFERENCES `geshotel_commonfiles_v1`.`tipos_servicio` (`tipo_servicio_id`),
  CONSTRAINT `ofertas_ibfk_8` FOREIGN KEY (`servicio_id`) REFERENCES `servicios` (`servicio_id`),
  CONSTRAINT `ofertas_ibfk_9` FOREIGN KEY (`unidad_calculo_id`) REFERENCES `geshotel_commonfiles_v1`.`unidades_calculo` (`unidad_calculo_id`)
) ENGINE=InnoDB AUTO_INCREMENT=47567 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for ofertas_servicios
-- ----------------------------
DROP TABLE IF EXISTS `ofertas_servicios`;
CREATE TABLE `ofertas_servicios` (
  `ofertas_servicio_id` int(11) NOT NULL AUTO_INCREMENT,
  `oferta_id` int(11) NOT NULL,
  `servicio_id` int(6) NOT NULL,
  `unidad_calculo_id` smallint(6) DEFAULT NULL,
  `cantidad` float(5,2) DEFAULT NULL,
  `precio` float(12,4) DEFAULT NULL,
  `servico_id_existe` int(6) DEFAULT NULL,
  PRIMARY KEY (`ofertas_servicio_id`),
  KEY `oferta_id` (`oferta_id`),
  KEY `unidad_calculo_id` (`unidad_calculo_id`),
  KEY `ofertas_servicios_ibfk_1` (`servicio_id`),
  KEY `servico_id_existe` (`servico_id_existe`),
  CONSTRAINT `ofertas_servicios_ibfk_1` FOREIGN KEY (`servicio_id`) REFERENCES `geshotel_commonfiles_v1`.`servicios` (`servicio_id`),
  CONSTRAINT `ofertas_servicios_ibfk_2` FOREIGN KEY (`unidad_calculo_id`) REFERENCES `geshotel_commonfiles_v1`.`unidades_calculo` (`unidad_calculo_id`),
  CONSTRAINT `ofertas_servicios_ibfk_3` FOREIGN KEY (`oferta_id`) REFERENCES `ofertas` (`oferta_id`),
  CONSTRAINT `ofertas_servicios_ibfk_4` FOREIGN KEY (`servico_id_existe`) REFERENCES `geshotel_commonfiles_v1`.`servicios` (`servicio_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3997 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for ofertas_rejillas
-- ----------------------------
DROP TABLE IF EXISTS `ofertas_rejillas`;
CREATE TABLE `ofertas_rejillas` (
  `rejilla_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `oferta_id` int(11) NOT NULL,
  `n` smallint(5) unsigned NOT NULL,
  `tipo_condicion_id` smallint(6) DEFAULT NULL,
  `tipo_aplicacion` smallint(5) unsigned DEFAULT NULL,
  `m` float NOT NULL,
  PRIMARY KEY (`rejilla_id`),
  KEY `oferta_id` (`oferta_id`),
  KEY `tipo_condicion_id` (`tipo_condicion_id`),
  CONSTRAINT `ofertas_rejillas_ibfk_1` FOREIGN KEY (`oferta_id`) REFERENCES `ofertas` (`oferta_id`) ON DELETE CASCADE,
  CONSTRAINT `ofertas_rejillas_ibfk_2` FOREIGN KEY (`tipo_condicion_id`) REFERENCES `geshotel_commonfiles_v1`.`tipos_condicion` (`tipo_condicion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=1642 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of clientes
-- ----------------------------
INSERT INTO `clientes` VALUES ('1', 'Tui Deutschland GmbH', 'TUI', null, null, '1', '23720', null, '\0', '2', 'C', 'DE242380569', null, null, 'Accounts payable TUI P.O. Box 160 130', 'Berlín', 'D-10337', '3', null, null, '4304018', null, '4304018', '4951115670', null, '495115671301', null, null, null, null, null, null, 'Accounts payable TUI P.O. Box 160 130', 'Berlín', 'D-10337', '3', null, '\0', '\0', '', '600000', '', '30', null, '7', '2014-05-07 00:00:00', 'DE812777076', null, null, null, null);
INSERT INTO `clientes` VALUES ('2', 'COQ LOLA', null, null, null, '1', null, null, '\0', '5', null, '', null, 'F', '', '', '', '18', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '8', '2015-09-25 10:11:26', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('3', 'TUI Nederland', 'TUIN', null, null, '1', '23721', null, '\0', '2', null, 'NL804637295B01', null, null, 'Volmerlaan, 3', 'Rijswijk', 'NL2288', '2', null, '4301005', '4304005', null, null, '31703266840', null, '31703266847', 'Claudine de Bilck', '928 73 02 93', '928 76 57 31', 'cdeblick@tui-contracting.e.telefonica.net', null, null, 'Volmerlaan, 3', 'Rijswijk', 'NL2288', '2', null, '\0', '\0', '', null, '', '30', null, '7', '2013-11-04 00:00:00', 'NL804637295B01', null, null, null, null);
INSERT INTO `clientes` VALUES ('5', 'DOO  TOBIAS BENJAMIN', 'REWE', null, null, '1', null, null, '\0', '5', 'P', '208494830', '2007-10-26', 'M', '16  UPPER LONGLANDS', 'DAWLISH', 'EX79DB', '4', null, null, null, null, null, '', '', '928 77 25 28', null, '928767763', '928772528', 'luzma.torres@mtsincoming.com', null, null, null, null, null, null, null, '', '\0', '\0', null, '\0', '30', '1986-02-23', '215', '2015-10-02 22:00:08', null, 'services/imagenRemota.aspx?url=\\\\10.3.0.30\\Gesviapi\\imagenes\\PASSPORT_2015102_21302.jpg', null, null, null);
INSERT INTO `clientes` VALUES ('6', 'Aurinkomatkat', 'AURINK', null, null, '1', '23722', null, '\0', '2', 'C', 'FI02009914', null, null, 'Pohjoinen Rautatiekatu, 25 PO Box 287', 'Pohjoinen Rautatiekatu, 25 PO Bo', null, '7', null, null, '4301008', null, null, '928720483', 'jmarrero@es.tui.com', '928765731', 'Jose Antonio Marrero', '928 72 04 83', '928 76 57 31', 'jmarrero@es.tui.com', null, null, 'Pohjoinen Rautatiekatu, 25 PO Box 287', 'Helsinki', 'FIN00101', '7', null, '\0', '\0', '', null, '', '30', null, '7', '2013-12-19 00:00:00', 'FI02009914', null, null, null, null);
INSERT INTO `clientes` VALUES ('8', 'Kuoni Scandinavia (Apollo-NG)', 'APONG', null, null, '1', '23723', null, '\0', '2', null, 'SE556306165301', null, null, 'Ynglingagatan', 'Stockholm', '11347', '5', null, null, '4304002', null, null, '928 72 00 05', null, '928 72 00 40', null, null, null, null, null, null, 'Ynglingagatan', 'Stockholm', '11347', '5', null, '\0', '\0', '', null, '', '30', null, '7', '2012-06-26 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('9', 'Global Hotels', 'GLOBAL', null, null, '1', '23748', null, '\0', '2', null, null, null, null, '14 Km Thessaloniki Michaniona P.O Box 60550', 'Thessaloniki', '57001', '19', null, null, null, null, null, null, null, null, null, null, null, 'medpayments@medhotels.com', null, null, 'Plaza Jandía, 1', 'San Fernando de Maspalomas', '35100', '1', '35', '', '\0', '', null, '', '30', null, '7', '2012-05-02 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('10', 'Kuoni Reisen AG', 'KUONI', null, null, '1', '23736', null, '\0', '2', null, 'CHE105823587', null, null, 'Neue Hard, 7', 'Zuerich', '8010', '17', null, null, '4304022', null, null, '41 44 277 44 44', null, '41 44 277 46 56', 'Christian (Viajes Canora)', '928 76 03 92', null, 'christian.schetsche@viajescanora.es', null, null, 'Neue Hard, 7', 'Zuerich', '8010', '17', null, '\0', '\0', '', null, '', '30', null, '7', '2013-10-24 00:00:00', 'CHE105823587', null, null, null, null);
INSERT INTO `clientes` VALUES ('11', 'Viajes Poseidón, S.L. (G) (Heimsferdir)', 'POSE-G', null, null, '1', '23737', null, '\0', '2', null, 'B35274604', null, null, 'Secundino Delgado, 5 Edif.Vista Combre I', 'San Fernando de Maspalomas', '35100', '1', '35', null, '4304015', null, null, '928 77 47 14 ', 'm.carmen@viajesposeidon.com', '928 77 05 24', 'reservas5.lpa@viajesposeidon.com', '928 77 74 17', '928 77 05 24', 'loliquintana.lpa@viajesposeidon.com', null, null, 'Secundino Delgado, 5 Edif.Vista C', 'San Fernando de Mas', '35100', '1', null, '', '\0', '', null, '', '30', null, '7', '2013-10-24 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('12', 'Viajes Poseidón, S.L. (NG) (Hemsferdir)', 'POSENG', null, null, '1', '23737', null, '\0', '2', null, 'B35274604', null, null, 'Secundino Delgado,5 Edif. Vista Cumbre I', 'San Fernando de Maspalomas', '35100', '1', '35', null, '4304015', null, null, '928 77 47 14', null, '928 77 05 24', null, null, null, null, null, null, 'Viajes Poseidón, S.L. (NG)', 'Secundino Delgado,5 Edif. Vista Cumbre I', '35100', '1', '35', '', '\0', '', null, '', '30', null, '7', '2013-10-24 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('13', 'Hotel Beds (Mdo.Nacional)', 'HB Nac', null, null, '1', '23738', null, '\0', '2', null, 'B38877676', null, null, 'Avda Marqués de Villanueva, C.C.La Cúpula, Local 77', 'Puerto de la Cruz', '38400', '1', '39', null, '4301010', null, null, '971 17 02 68', null, '971 466 455', 'Susana Torres', '971 17 02 68', '971 466 455', 's.torres@hotelbeds.com/ inclpa.booking2@hotelbeds.com', null, null, 'Avda Marqués de Villanueva, C.C.La Cúpula, Local 77', 'Puerto de la Cruz', '38400', '1', '39', '\0', '\0', '', null, '', '30', null, '7', '2013-10-24 00:00:00', 'B38877676', null, null, '', null);
INSERT INTO `clientes` VALUES ('14', 'Viajes El Corte Ingles SA', 'CORTH', null, null, '1', '23297', null, '\0', '2', 'P', 'A28229813', null, null, 'Avda. Cantabria, 51', 'Madrid', '28042', '1', '29', null, '4304017', null, null, '912038088', null, '913293560', null, '913298100/Ext 2036', null, 'attproveedor@viajeseci.es', null, null, 'Avda. Cantabria, 51', 'Madrid', '28042', '1', '29', '\0', '\0', '', null, '', '30', '1957-12-27', '7', '2012-05-02 00:00:00', 'A28229813', null, null, null, null);
INSERT INTO `clientes` VALUES ('15', 'V.El Corte Ingles, S.A./Toumundial I.Canarias y Baleares', 'CORTE', null, null, '1', '23297', null, '\0', '2', null, 'A28229813', null, null, 'Avda. Cantabria, 51', 'Madrid', '28042', '1', '29', null, '4304017', null, null, '912038088', null, '913293560', null, '913298100', null, 'attproveedor@viajeseci.es', null, null, 'Avda. Cantabria, 51', 'Madrid', '28042', '1', '35', '\0', '\0', '', null, '', '30', null, '7', '2012-05-02 00:00:00', 'A28229813', null, null, null, null);
INSERT INTO `clientes` VALUES ('16', 'Clientes Extras Contado', 'EXTRA', null, null, '1', '23770', null, '', '2', null, '99999999R ', null, null, null, null, null, '1', null, '4381997', '4301000', '000', '5610000', null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, '\0', '0', null, '7', '2013-10-28 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('17', 'ULTRAMAR', 'ULTRA', null, null, '1', '23747', null, '\0', '2', null, 'A08089187', null, null, 'Avda. Gran Vía Asima, 2', 'Palma de Mallorca', '07009', '1', '8', null, '4301025', null, null, '928720463', null, '928765731', 'MARIA BERSTROM', '928720463', '928765731', null, null, null, 'Avda. Gran Vía Asima, 2', 'Palma de Mallorca', '07009', '1', '8', '', '\0', '', null, '', '30', null, '7', '2012-05-02 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23', 'Kuoni Scandinavia (Apollo)', 'APOLL', null, null, '1', '23723', null, '\0', '2', null, 'SE556306165301', null, null, 'Ynglingagatan, 2', 'Stockholm', 'SE-113', '5', null, null, '4301002', null, null, '928 72 00 05', null, '928 72 00 40', null, null, null, null, null, null, 'Ynglingagatan, 2', 'Stockholm', 'SE-113', '5', null, '\0', '\0', '', null, '', '30', null, '7', '2012-05-02 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('6113', 'TUI-Z', 'TUI-Z', null, null, '1', '23720', null, '\0', '2', null, null, null, null, null, null, null, '3', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '', null, '', null, null, '7', '2012-05-02 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('6119', 'TUI-Z20', 'TUI-Z2', null, null, '1', '23720', null, '\0', '2', null, null, null, null, null, null, null, '3', null, null, '4302014', null, null, null, null, null, null, null, null, null, null, null, null, null, null, '3', null, '\0', '\0', '', null, '', null, null, '7', '2012-05-02 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('7690', 'Tui Deutschland F34', 'TUIF34', null, null, '1', '23720', null, '\0', '2', null, null, null, null, 'Kalr-Wiechert-Allee 23', 'Hannover', 'D-30625', '3', null, null, '4302014', null, null, '4951115670', null, '495115671301', null, null, null, null, null, null, 'Kalr-Wiechert-Allee 23', 'Hannover', 'D-30625', '3', null, '', '\0', '', '600000', '', '30', null, '7', '2012-05-02 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('14874', 'Tui Deutschland Gmbh ( ss )', 'TUI', null, null, '1', '23720', null, '\0', '2', 'C', 'DE242380569', null, null, 'Accounts payable TUI P.O. Box 160 130', 'Berlín', 'D-10337', '3', null, null, null, null, null, '4951115670', null, '495115671301', null, null, null, null, null, null, 'Accounts payable TUI P.O. Box 160 130', 'Berlín', 'D-10337', '3', null, '\0', '\0', '', null, '', null, null, '7', '2014-05-07 00:00:00', 'DE812777076', null, null, null, null);
INSERT INTO `clientes` VALUES ('15255', '1-2 FLY GMBH', '1-2 FL', null, null, '2', '23720', null, '\0', '2', 'D', 'DE163590527', null, null, 'Karl-Wiechert Allee, 66', 'Hannover', '30625', '3', null, null, '4301003', null, null, '004951154055734', 'ana.millan@1-2fly.de', '004951154055759', null, null, null, null, null, null, 'Karl-Wiechert Allee, 66', 'Hannover', '30625', '3', null, '\0', '\0', '', null, '', null, null, '7', '2012-05-02 00:00:00', null, null, null, '\0', null);
INSERT INTO `clientes` VALUES ('23720', 'Tui Deutschland GmbH', 'TUID', null, null, '1', null, null, '\0', '1', null, null, null, null, 'Kalr-Wiechert-Allee 23', 'Hannover', 'D-30625', '3', null, null, null, null, null, '4951115670', null, '495115671301', null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '', null, '\0', null, null, '7', '2009-10-14 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23721', 'Tui Nederland', 'TUIN', null, null, '1', null, null, '\0', '1', null, null, null, null, 'Volmerlaan, 3', 'Rijswijk', 'NL2288', '2', null, null, null, null, null, '31703266840', null, '31703266847', null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23722', 'Aurinkomatkat', 'AURINK', null, null, '1', null, null, '\0', '1', 'C', 'FI02009914', null, null, 'Pohjoinen Rautatiekatu, ', 'Pohjoinen Rautatiekatu, 25 PO B', null, '7', null, null, null, null, null, '928720483', 'jmarrero@es.tui.com', '928765731', null, null, null, null, null, null, 'Pohjoinen Rautatiekatu, 25 PO B', null, null, null, null, '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23723', 'Kuoni Scandinavia ', 'APOLLO', null, null, '1', null, null, '\0', '1', null, '556306165301', null, null, 'Ynglingagatan', 'Stockholm', '11347', '5', null, null, null, null, null, '928 72 00 05', null, '928 72 00 40', null, null, null, null, null, null, 'Ynglingagatan', 'Stockholm', '11347', '5', null, '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23724', 'SPECHT DORINA', null, null, null, '1', null, null, '\0', '5', 'P', '765652553', '2004-09-03', 'F', 'STADTWEG 19', 'DRESDEN', '01169', '3', null, null, null, null, null, '493514178040', 'rene.holz@web.de', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1975-04-20', '14', '2009-10-14 21:06:15', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23725', 'SPECHT AMANDA', null, null, null, '1', null, null, '\0', '5', 'P', 'E0037262', '2004-09-03', 'F', 'STADTWEG 19', 'DRESDEN', '01169', '3', null, null, null, null, null, '493514178040', 'rene.holz@web.de', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '2004-04-22', '14', '2009-10-14 21:06:15', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23726', 'SPECHT KIM-ANABEL', null, null, null, '1', null, null, '\0', '5', 'P', 'E5284643', '2009-10-13', 'F', 'STADTWEG 19', 'DRESDEN', '01169', '3', null, null, null, null, null, '493514178040', 'rene.holz@web.de', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '2008-06-11', '14', '2009-10-14 21:06:15', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23727', 'BECKER  THOMAS', null, null, null, '1', null, null, '\0', '5', 'D', '5407121259', '2007-12-05', 'M', 'austin wibbelt 12', 'HEIDEN', '46359', '3', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1966-04-19', '14', '2011-07-31 09:56:33', null, 'services/imagenRemota.aspx?url=\\\\10.2.0.43\\C$\\Archivos de programa\\GESVIAPI\\imagenes\\DNI_2011731_94041_REAR.jpg', 'services/imagenRemota.aspx?url=\\\\10.2.0.43\\C$\\Archivos de programa\\GESVIAPI\\imagenes\\DNI_2011731_94041_FRONT.jpg', null, null);
INSERT INTO `clientes` VALUES ('23728', 'KOHL BECKER BIRGIT', null, null, null, '1', null, null, '\0', '5', null, '212932729', '2005-09-12', 'F', null, null, null, '3', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1969-04-15', '16', '2009-10-14 21:06:42', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23729', 'BECKER JAKOB', null, null, null, '1', null, null, '\0', '5', 'P', 'E4511250', '2009-06-04', 'M', null, null, null, '3', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1998-04-04', '16', '2009-10-14 21:06:42', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23730', 'SCHONEVELD JACOB', null, null, null, '1', null, null, '\0', '5', null, 'ID1130840', '2005-01-17', 'M', 'MEIDOORNSTRAAT 33', 'KATWIJK', '2225 SJ', '2', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1940-03-02', '14', '2009-10-14 21:35:01', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23731', 'DE JONG MAARTJE', null, null, null, '1', null, null, '\0', '5', null, 'ID1130798', '2005-01-17', 'F', 'MEIDOORNSTRAAT 33', 'KATWIJK', '2225 SJ', '2', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1941-06-10', '14', '2009-10-14 21:35:01', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23732', 'POSTMA  GERRIT', null, null, null, '1', null, null, '\0', '5', 'P', 'NU7H9BLL5', '2007-04-03', 'M', 'STATIONSWEG 35', 'DRCHTEN (SMALLINGERLAND)', '9201GG', '2', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1969-06-18', '16', '2015-10-19 23:04:26', null, 'services/imagenRemota.aspx?url=\\\\10.2.0.30\\Gesviapi\\\\imagenes\\PASSPORT_20151019_23315.jpg', null, null, null);
INSERT INTO `clientes` VALUES ('23733', 'RODRIGUEZ GUTIERREZ LEONARDO', null, null, null, '1', null, null, '\0', '5', null, '42711700X', '2007-01-05', 'M', 'C. CARLOS I 24', 'VECINDARIO', '35110', '1', '35', null, null, null, null, '663 013 968', 'mehiceelorreo@hotmail.com', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1948-11-06', '15', '2010-09-21 14:48:03', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23734', 'ESPENSEN TOM', null, null, null, '1', null, null, '\0', '5', null, '', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '8', '2009-10-15 09:11:33', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23735', 'BERNARDI ALESSANDRO', null, null, null, '1', null, null, '\0', '5', 'P', 'AA0221837', '2006-11-09', 'M', 'VIA TOSCANA 128', 'RININI ', '47900', '9', null, null, null, null, null, '393898090867', 'alessandro.bernardi16@tin.it', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1973-10-14', '13', '2009-11-03 20:03:09', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23736', 'Kuoni Reisen AG', 'KUONI', null, null, '1', null, null, '\0', '1', null, null, null, null, 'Neue Hard, 7', 'Zuerich', '8010', '17', null, null, null, null, null, '41 44 277 44 44', 'sandra@looser@kuoni.ch', '41 44 277 46 56', null, null, null, null, null, null, 'Neue Hard, 7', 'Zuerich', '8010', '17', null, '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23737', 'Viajes Poseidón, S.L.', 'POSEID', null, null, '1', null, null, '\0', '1', null, 'B35274604', null, null, 'Secundino Delgado, 5 Edif.Vista Combre I', 'San Fernando de Masp', '35100', '1', '35', null, null, null, null, '928 77 47 14 ', 'm.carmen@viajesposeidon.com', '928 77 05 24', null, null, null, null, null, null, 'Secundino Delgado, 5 Edif.Vista Combre I', 'San Fernando de Masp', '35100', '1', '35', '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23738', 'Hotel Beds', 'HBEDS', null, null, '1', null, null, '\0', '1', 'C', 'B38877676', null, null, 'Avda Marqués de Villanueva, C.C.La Cúpula, Local 77', 'Puerto de la Cruz', '38400', '1', '39', null, null, null, null, '971 17 02 68', null, '971 466 455', null, null, null, null, null, null, 'Avda Marqués de Villanueva, C.C.La Cúpula, Local 77', 'Puerto de la Cruz', '38400', '1', '39', '\0', '\0', '', null, '\0', null, null, '7', '2011-02-07 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23742', 'ARNGRIMSSON GUDJON', null, null, null, '1', null, null, '\0', '5', 'P', 'A1203699', '2005-04-27', 'M', 'EFSTASUND 87', 'REYKJAVIK ISLANDIA', '104', '20', null, null, null, null, null, '+3546906712', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1955-09-13', '12', '2009-12-19 16:44:39', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23746', 'Rewe Touristik Gmgh', 'REWE', null, null, '1', null, null, '\0', '1', 'C', 'DE811177889', null, null, 'Humboldstrasse, 140-144', 'Köln', '51149', '3', null, null, null, null, null, '928 76 77 63', 'luzma.torres@mtsincoming.com', '928 77 25 28', null, null, null, null, null, null, 'Humboldstrasse, 140-144', 'Köln', '51149', '3', null, '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23747', 'Ultramar Express', 'ULTRAM', null, null, '1', null, null, '\0', '1', 'C', 'A08089187', null, null, 'Avda. Gran Vía Asima, 2', 'Palma de Mallorca', '07009', '1', '8', null, null, null, null, '928720463', null, '928765731', null, null, null, null, null, null, 'Avda. Gran Vía Asima, 2', 'Palma de Mallorca', '07009', '1', '8', '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23748', 'Global Hotels', 'GLOBAL', null, null, '1', null, null, '\0', '1', 'C', 'A35099423', null, null, 'Plaza Jandía, 1', 'San Fernando de Maspalomas', '35110', '1', '35', null, null, null, null, '928730403', 'bookinglpa@martelcanarias.com', '928769354', null, null, null, null, null, null, 'Plaza Jandía, 1', 'San Fernando de Maspalomas', '35110', '1', '35', '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23749', 'Sunway Holidays', 'SUNWAY', null, null, '1', null, null, '\0', '1', null, null, null, null, 'Marina House, Clarence Street', 'Dublin', 'Dun Laogha', '14', null, null, null, null, null, '353 1 2886828', 'Info@sunway.ie', '353 1 2885187', null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23750', 'Luxair, S.A.', 'LUXAIR', null, null, '1', null, null, '\0', '1', 'C', 'LU11868245', null, null, 'Aeroport', 'FINDEL', 'L-1110', '18', null, null, null, null, null, '928 76-77-63', 'luzma.torres@mtsincoming.com', '928-77-25-48', null, null, null, null, null, null, 'Aeroport', 'FINDEL', 'L-1110', '18', null, '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23751', 'Viajes Iberoservice, S.A.', 'IBEROS', null, null, '1', null, null, '\0', '1', 'C', 'GB239384142', null, null, 'MENORCA 8 bajos', 'PALMA DE MALLORCA', '07011', '1', null, null, null, null, null, '902996059', 'pagos.nur.lpa@iberoservice.com', '971070195', null, null, null, null, null, null, 'MENORCA 8 bajos', 'PALMA DE MALLORCA', '07011', '1', null, '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23752', 'Jumbo Canarias, S.A.', 'JUMBO', null, null, '1', null, null, '\0', '1', 'C', 'A38478491', null, null, 'Avda. Antonio Domíngu', 'Playa de las Américas', '38640', '1', '39', null, null, null, null, '928 767758/971211267', null, null, null, null, null, null, null, null, 'Avda. Antonio Domíngu', 'Playa de las Américas', '38640', '1', '39', '\0', '\0', '', null, '\0', null, null, '2', '2009-11-10 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23753', 'Viajes Tindaya, S.L.', 'TINDAY', null, null, '1', null, null, '\0', '1', 'C', 'B35865559', null, null, 'C.C SONELAND LOCAL 216/232', 'PLAYA DEL INGLES', '35100', '1', null, null, null, null, null, '928 148689', 'fsuarez@viajestindaya.com', '928 146995', null, null, null, null, null, null, 'C.C SONELAND LOCAL 216/232', 'PLAYA DEL INGLES', '35100', '1', '35', '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23754', 'Fischer', 'FISCHE', null, null, '1', null, null, '\0', '1', 'C', 'CZ26141647', null, null, 'MILESOVSKA 1136/5', 'REPUBLICA CHECA (P', '13000', '23', null, null, null, null, null, '928.77.41.35', 'kim@sunvalentin.es', '928.7741.57', null, null, null, null, null, null, 'MILESOVSKA 1136/5', 'REPUBLICA CHECA (P', '13000', '23', null, '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23755', 'Tui UK LTD', 'UK', null, null, '1', null, null, '\0', '1', 'C', 'GB233368762', null, null, 'wigmore house.wigmore place', 'wigmore lane', 'LUTON LU29', '4', null, null, null, null, null, '922.71.71.43', 'abi_paine@tui-uk.co.uk', '922.75.29.79', null, null, null, null, null, null, 'wigmore house.wigmore place', 'wigmore lane', 'LUTON LU29', '4', null, '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23756', 'Youtravel', 'YOUTRA', null, null, '1', null, null, '\0', '1', 'C', null, null, null, '5 TSAKALOF STREET ', 'KOLONAKI ', '106 73', '19', null, null, null, null, null, '30-2111200300', 'acccounting.el@youtravel.com', '30-2103625925', null, null, null, null, null, null, '5 TSAKALOF STREET ', 'KOLONAKI ', '106 73', '19', null, '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23757', 'Viajes Líder Canarias, S.A.', 'VLC', null, null, '1', null, null, '\0', '1', 'C', 'A38063798', null, null, 'C/ LA HOYA Nº 58', 'PTO DE LA CRUZ ', '38400', '1', '39', null, null, null, null, '922 74 62 00', null, '922 74 62 20', null, null, null, null, null, null, 'C/ LA HOYA Nº 58', 'PTO DE LA CRUZ ', '38400', '1', '39', '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23758', 'Altura Destination Service, S.A.', 'ALTURA', null, null, '1', null, null, '\0', '1', null, 'B57255036', null, null, 'c/ Las Sirenas, 17', 'Cala Viñas', '07181', '1', '8', null, null, null, null, '0034 971 132 813', 'res@alturaspain.com', '0034 971 130 906', null, null, null, null, null, null, 'c/ Las Sirenas, 17', 'Cala Viñas', '07181', '1', '8', '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23759', 'Viajes Rhodasol, S.A.', 'RHODA', null, null, '1', null, null, '\0', '1', null, 'A50075092', null, null, 'C/ GARBI 88-90', 'PINEDA DE MAR', '08397', '1', '9', null, null, null, null, '922 74 62 00', null, '922 74 62 20', null, null, null, null, null, null, 'C/ GARBI 88-90', 'PINEDA DE MAR', '08397', '1', '9', '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23760', 'Agentbeds, S.L.', 'AGENTB', null, null, '1', null, null, '\0', '1', null, 'B38919908', null, null, 'Crta. La Corujera, 84', 'Santa Ursula', '38390', '1', '39', null, null, null, null, '922 33 72 46', 'info@agentbeds.es', '922 33 72 51', null, null, null, null, null, null, 'Crta. La Corujera, 84', 'Santa Ursula', '38390', '1', '39', '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23761', 'Alojamientos Canarios', 'ALOCAN', null, null, '1', null, null, '\0', '1', 'C', 'A-35362383', null, null, '29 DE ABRIL 43 - 45 3º A', 'LAS PALMAS', '35007', '1', '35', null, null, null, null, '902 202 903', 'reservas@alocan.com', '902 883 364', null, null, null, null, null, null, '29 DE ABRIL 43 - 45 3º A', 'LAS PALMAS', '35007', '1', '35', '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23762', 'Oper.Turísticas Canarias Viaja, S.A.', 'OTC', null, null, '1', null, null, '\0', '1', null, 'A38876454', null, null, 'C.C.Bulevar Planta 2ª Local 56-57 Pasaje Puerto Escondido s/n', 'Santa Cruz de Tenerife', '38003', '1', '39', null, null, null, null, '922 24 81 61', 'info@otcv.es', null, null, null, null, null, null, null, 'C.C.Bulevar Planta 2ª Local 56-57 Pasaje Puerto Escondido s/n', 'Santa Cruz de Tenerife', '38003', '1', '39', '\0', '\0', '', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23763', 'Viajes Insular, S.A.', 'INSULA', null, null, '1', null, null, '\0', '1', 'C', 'A-35004670', null, null, 'ALEJANDRO HIDALGO 3', 'LAS PALMAS DE G.CANARIA', '35005', '1', '35', null, '4304038', null, null, '928 30 96 49', 'reservas@viajesinsular.es', '928 29 64 30', null, null, null, null, null, null, 'ALEJANDRO HIDALGO 3', 'LAS PALMAS DE G.CANARIA', '35005', '1', '35', '\0', '\0', '', null, '\0', null, null, '37', '2010-02-22 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23764', 'Jetair', 'JETAIR', null, null, '1', null, null, '\0', '1', 'C', '408.479.965', null, null, 'GISTELSESTENNWEG ', 'OOSTENDE', '8400', '13', null, null, null, null, null, '0032.59.56.56.50', null, '0032.59.56.56.51', null, null, null, null, null, null, 'GISTELSESTENNWEG ', 'OOSTENDE', '8400', '13', null, '\0', '\0', '\0', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23765', 'Clientes Free', 'CFREE', null, null, '1', null, null, '\0', '1', null, null, null, null, null, null, null, '1', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, '\0', null, null, '7', '2009-10-15 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23766', 'BLAAUBOER  JANET', null, null, null, '1', null, null, '\0', '5', 'P', 'NYR4L1H72', '2007-06-01', 'M', null, null, null, '2', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1955-09-04', '146', '2013-10-20 21:14:13', null, 'services/imagenRemota.aspx?url=\\\\10.4.0.31\\Gesviapi\\\\imagenes\\PASSPORT_20131020_211350.jpg', null, null, null);
INSERT INTO `clientes` VALUES ('23767', 'HAUGSBAK JOHN', null, null, null, '1', null, null, '\0', '5', null, '', null, 'M', null, null, null, '6', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '41', '2009-10-15 12:31:34', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23768', 'KAHLICH GERHARD', null, null, null, '1', null, null, '\0', '5', null, '6486256797', '2003-05-21', 'M', 'DANZIGER STR 3', 'BUCHEN (OKENWALD)', '74722', '3', null, null, null, null, null, '0049062818101', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1950-12-24', '8', '2011-10-13 09:13:29', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23769', 'LAGONI JEANNE', null, null, null, '1', null, null, '\0', '5', 'P', '202401116', '2007-04-12', 'F', 'PILEVENSET 15', 'MARSTALL', '5960', '6', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1966-02-27', '67', '2011-03-21 15:46:28', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23770', 'Clientes Directos', 'DTOS', null, null, '1', null, null, '\0', '1', null, null, null, null, null, null, null, '1', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, '\0', null, null, '2', '2009-11-10 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23771', 'Sol Access Service', 'SLL', null, null, '1', null, null, '\0', '1', null, 'B38960290', null, null, 'c/ J.Gonzalez Gonzalez 20', 'Valle San Lorenzo', '38626', '1', '39', null, null, null, null, '922.76.51.86', null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, '\0', null, null, '37', '2011-03-17 00:00:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23772', 'KORKIAKOSKI IIDA', null, null, null, '1', null, null, '\0', '5', 'D', '1703513', '2006-03-24', 'F', 'MYLLYMENETIE 50', 'KAUSTINEN', '69600', '7', null, null, null, null, null, '', '', null, null, null, null, null, '2010-11-02 18:56:32', null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1995-07-05', '13', '2010-11-02 18:56:32', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23773', 'MYLLYPALI MIIA', null, null, null, '1', null, null, '\0', '5', 'P', '16577276', '2005-02-07', 'F', 'MYLLYMENETIE 50', 'KAUSTINEN', '69600', '7', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1975-02-11', '8', '2009-12-16 12:11:49', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23774', 'MYLLYPALI ANNI', null, null, null, '1', null, null, '\0', '5', null, null, null, 'F', 'MYLLYMENETIE 50', 'KAUSTINEN', '69600', '7', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '2002-06-11', '8', '2009-12-16 12:11:49', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23775', 'MYLLYPALI EETU', null, null, null, '1', null, null, '\0', '5', null, null, null, 'F', 'MYLLYMENETIE 50', 'KAUSTINEN', '69600', '7', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '2004-08-23', '8', '2009-12-16 12:11:49', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23776', 'PUTKONEN JUKKA', null, null, null, '1', null, null, '\0', '5', null, '15587971', '2002-06-07', 'M', 'DPTTAJANPOLKU 7', 'SUANENJOKI', '77600', '7', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1951-03-14', '189', '2015-08-13 11:42:42', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23777', 'JARVINEN RAILI', null, null, null, '1', null, null, '\0', '5', null, 'PC77791241', '2007-09-11', 'F', 'DPTTAJANPOLKU 7', 'SUANENJOKI', '77600', '7', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1954-11-26', '14', '2012-12-08 18:37:29', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23778', 'VUORI KIMMO', null, null, null, '1', null, null, '\0', '5', 'P', 'pk23812883', '1957-06-19', 'M', 'rajanotkuntie 111', 'kirkkonummi', '02400', '7', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1956-11-11', '13', '2009-12-23 13:32:38', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23779', 'VUORI AKU KALLE', null, null, null, '1', null, null, '\0', '5', 'P', 'pz4197856', '2008-02-01', 'M', 'rajanotkuntie 111', 'kirkkonummi', '02400', '7', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1995-05-19', '13', '2009-12-23 13:32:38', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23780', 'LANKINEN MERJA', null, null, null, '1', null, null, '\0', '5', 'D', '201435788', '2002-09-27', 'F', 'NAPIN VLAJANTIE 16 AI', 'HELSINKI', '00650', '7', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1967-04-19', '8', '2009-12-25 12:38:08', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23781', 'LANKINEN PEKKA', null, null, null, '1', null, null, '\0', '5', 'D', '50334985', '2006-01-27', 'M', 'NAPIN VLAJANTIE 16 AI', 'HELSINKI', '00650', '7', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1968-06-04', '8', '2009-12-25 12:38:08', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23783', 'LANKINEN KAARLO (7)', null, null, null, '1', null, null, '\0', '5', 'D', null, null, 'M', 'NAPIN VLAJANTIE 16 AI', 'HELSINKI', '00650', '7', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '2002-02-22', '8', '2009-12-25 12:38:08', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23784', 'KORKOKAINEN', null, null, null, '1', null, null, '\0', '5', null, '', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '8', '2009-10-15 13:46:39', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23785', 'myllamik hannu', null, null, null, '1', null, null, '\0', '5', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '8', '2009-10-15 13:53:10', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23786', 'nyman buirger', null, null, null, '1', null, null, '\0', '5', null, '', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '8', '2009-10-15 13:56:10', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23787', 'ber uun britt', null, null, null, '1', null, null, '\0', '5', null, '', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '8', '2009-10-15 13:56:10', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23788', 'DAMAS ALF RAGNAR', null, null, null, '1', null, null, '\0', '5', 'P', '26077468', '2007-06-28', 'M', 'OLASVEVEIEN 64', 'LILLEHAMMER', '2618', '6', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '46', '2010-01-18 17:22:01', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23789', 'TYVDALEN  MARIT', null, null, null, '1', null, null, '\0', '5', 'P', '27002711', '2009-02-02', 'F', 'ASMARKVEIEN 1147', 'NAEROSET', '2364', '6', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1952-01-21', '14', '2014-10-19 09:23:53', null, 'services/imagenRemota.aspx?url=\\\\10.2.0.30\\Gesviapi\\\\imagenes\\PASSPORT_20141018_14510.jpg', null, null, null);
INSERT INTO `clientes` VALUES ('23790', 'PRAESTEN MARI', null, null, null, '1', null, null, '\0', '5', 'P', '20027584', '2002-04-29', 'F', 'SKOGBRYNET 63', 'ANDFISKA', '8618', '6', null, null, null, null, null, '92412914', 'maripr@online.no', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1973-02-03', '18', '2009-11-01 00:23:42', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23791', 'NIELSEN  STEEN', null, null, null, '1', null, null, '\0', '5', 'P', '202381481', '2007-04-16', 'M', 'LYOVEJ 4', 'SLAGELSE', '4200', '12', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1944-04-20', '16', '2015-01-24 18:26:35', null, 'services/imagenRemota.aspx?url=\\\\10.2.0.30\\Gesviapi\\\\imagenes\\PASSPORT_2015124_182550.jpg', null, null, null);
INSERT INTO `clientes` VALUES ('23792', 'RYNDER JENNY', null, null, null, '1', null, null, '\0', '5', 'P', '56660129', '2005-08-24', 'F', 'STRANDVAGEN 115', 'TYRESO', '13562', '5', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1972-01-26', '16', '2009-11-07 19:38:45', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23793', 'BJORLAND GRETE KARI', null, null, null, '1', null, null, '\0', '5', 'P', '25051762', '2005-11-09', 'F', 'MOTLANDSMARKA 116B', 'NAERBO', '4365', '6', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1960-04-13', '9', '2009-10-31 14:33:33', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23794', 'FAGERSAND TORHILD', null, null, null, '1', null, null, '\0', '5', 'P', '20469424', '2004-07-14', 'F', 'BERGTUN', 'SETSKOG', '1954', '6', null, null, null, null, null, '93011072', 'fagersand@tertitten.com', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1950-05-02', '16', '2010-11-06 20:28:49', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23795', 'STETTLER KURT', null, null, null, '1', null, null, '\0', '5', null, '004716435', '2001-02-21', 'M', 'ALFBENZRING 20', 'ETTINGEN', '4107', '17', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1960-07-16', '16', '2009-10-21 18:59:44', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23796', 'RYHNER URSULA', null, null, null, '1', null, null, '\0', '5', null, 'E0107329', '2003-06-20', 'F', 'ALFBENZRING 20', 'ETTINGEN', '4107', '17', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1961-10-03', '16', '2009-10-21 18:59:44', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23797', 'NORTHERN  VICTORIA CLAIRE', null, null, null, '1', null, null, '\0', '5', 'P', '400931267', '2003-07-09', 'F', '199 OLD ROAD WEST', 'GRAVESEND KENT', 'DA11OLV', '4', null, null, null, null, null, '01474328059', '', null, null, null, null, null, '2012-08-23 19:56:07', null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1981-11-22', '151', '2012-08-23 19:56:07', null, 'services/imagenRemota.aspx?url=\\\\10.3.0.31\\Gesviapi\\\\imagenes\\PASSPORT_2012823_195549.jpg', null, null, null);
INSERT INTO `clientes` VALUES ('23798', 'JENSEN  SVEN JARL', null, null, null, '1', null, null, '\0', '5', 'P', '28220755', '2011-01-19', 'M', '', '', '', '6', null, null, null, null, null, '', 'SVEJJ@ONLINE.NO', null, null, null, null, null, '2013-10-26 13:45:56', null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1937-01-29', '67', '2013-10-26 13:45:56', null, 'services/imagenRemota.aspx?url=\\\\10.1.0.30\\Gesviapi\\\\imagenes\\PASSPORT_20131026_134532.jpg', null, null, null);
INSERT INTO `clientes` VALUES ('23799', 'MYHR MARGRETHE', null, null, null, '1', null, null, '\0', '5', null, '', null, 'F', null, null, null, '5', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '41', '2009-10-16 08:40:36', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23800', 'SANDVIK KJELL EGIL', null, null, null, '1', null, null, '\0', '5', null, '', null, 'M', null, null, null, '5', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '41', '2009-10-16 08:44:51', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23801', 'HATLING HARALD LEO', null, null, null, '1', null, null, '\0', '5', null, '', null, 'M', null, null, null, '5', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '41', '2009-10-16 08:46:09', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23802', 'HESSEBERG REIDAR', null, null, null, '1', null, null, '\0', '5', null, '', null, 'M', null, null, null, '5', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '41', '2009-10-16 08:49:07', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23803', 'HESSEBERG HANS OLAV', null, null, null, '1', null, null, '\0', '5', null, '', null, 'M', null, null, null, '5', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '41', '2009-10-16 08:50:53', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23804', 'KAPKE SHALYNA', null, null, null, '1', null, null, '\0', '5', 'P', 'E5269863', '2009-10-02', 'F', 'BIRKENWEG 7', 'HEMMOOR', '21745', '3', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '2008-06-24', '12', '2009-10-21 23:06:55', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23805', 'CARLBERG  JAN ERIK', null, null, null, '1', null, null, '\0', '5', 'P', '34510247', '2003-09-18', 'M', 'BOX 100', 'KARESUANDO ', '98016', '5', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1939-07-25', '14', '2011-03-11 22:57:03', null, 'services/imagenRemota.aspx?url=\\\\10.2.0.43\\C$\\Archivos de programa\\GESVIAPI\\imagenes\\PASSPORT_2011311_225558.jpg', null, null, null);
INSERT INTO `clientes` VALUES ('23806', 'RUIZ FERNANDEZ JOSE ANGEL', null, null, null, '1', null, null, '\0', '5', 'D', '12766686F', '2008-02-06', 'M', 'C/. SAN MARTIN 3', 'RIBAS DE CAMPOS', '34411', '1', null, null, null, null, null, '670328937', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1973-03-29', '18', '2009-12-02 19:23:10', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23807', 'PATTYN BRAM', null, null, null, '1', null, null, '\0', '5', null, '5909548726', '2009-06-09', 'M', 'kapellenhoek 71', 'smetlede', '9340', '13', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1976-08-04', '15', '2009-11-16 11:44:07', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23808', 'VAN DE MAELE VALERIE', null, null, null, '1', null, null, '\0', '5', null, '5900945730', '2005-06-01', 'F', 'kapellenhoek 71', 'smetlede', '9340', '13', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1979-06-12', '15', '2009-11-16 11:44:07', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23809', 'PATTYN PEPIJN (2)', null, null, null, '1', null, null, '\0', '5', null, null, null, 'M', 'kapellenhoek 71', 'smetlede', '9340', '13', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '2007-04-25', '15', '2009-11-16 11:44:07', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23810', 'PATTYN MARTHA (0)', null, null, null, '1', null, null, '\0', '5', null, null, null, 'F', 'kapellenhoek 71', 'smetlede', '9340', '13', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '2009-02-24', '15', '2009-11-16 11:44:07', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23811', 'FUKKINK DANYEL', null, null, null, '1', null, null, '\0', '5', 'P', '101566384', '2008-06-19', 'M', 'SCHATBERGSTRAAT 124', 'LICHTENVOORDE', '7132AB', '2', null, null, null, null, null, '0654282140', 'DAANSANDY@HOTMAIL.COM', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1972-01-10', '9', '2010-02-16 13:44:44', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23812', 'RICO ULLOA JOSE ANTONIO', null, null, null, '1', null, null, '\0', '5', null, '12716885R', '2007-11-02', null, 'RONDA BUENA VISTA 41  ', 'TOLEDO', '45005', '1', '45', null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1957-07-08', '9', '2009-12-05 11:48:20', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23813', 'BASTO ROCCO ', null, null, null, '1', null, null, '\0', '5', null, null, null, null, 'GEISSEWERG 1', 'ZURICH', '8306', '17', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '8', '2009-11-13 13:56:38', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23814', 'RAVEN PETRUS', null, null, null, '1', null, null, '\0', '5', 'P', '117353103', '2007-06-04', 'M', 'SVATAMA 1', 'HILVERSUM', '1222H2', '2', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1957-07-16', '13', '2009-12-16 11:07:53', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23815', 'REINDERS', null, null, null, '1', null, null, '\0', '5', null, '', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '8', '2009-10-16 10:25:03', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23816', 'JACOBS I', null, null, null, '1', null, null, '\0', '5', null, 'NL0683883', '2006-06-02', 'F', 'POSTBUS 49', 'ASTEN', '5720AA', '2', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1974-12-22', '8', '2009-12-18 10:31:56', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23817', 'FISCHER HENRICK', null, null, null, '1', null, null, '\0', '5', null, '', null, 'M', null, null, null, '3', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '41', '2009-10-16 10:39:04', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23818', 'DE KONING JOHANNA', null, null, null, '1', null, null, '\0', '5', null, null, null, 'F', 'R KIPLINGERF 302', 'DORDRECHT', '3315AL', '2', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '16', '2009-12-02 22:53:09', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23819', 'OLIJERHOEK Marc (31)', null, null, null, '1', null, null, '\0', '5', null, 'nl4758660', '2006-07-27', 'M', 'greveligenmeer 137', 'pumerend', '1447am', '2', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1978-07-20', '13', '2009-12-09 16:45:32', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23820', 'BUITING HERMANNA', null, null, null, '1', null, null, '\0', '5', 'P', 'IL22LO69', '2004-10-09', 'F', 'GROTENHUISWEG 7', 'WILP', '7384CS', '2', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1960-11-22', '8', '2009-12-16 11:49:01', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23821', 'DEN OUDEN', null, null, null, '1', null, null, '\0', '5', null, '', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '8', '2009-10-16 10:45:32', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23822', 'RONCA JAN', null, null, null, '1', null, null, '\0', '5', 'P', 'NX2B33FK6', '2008-05-26', 'M', 'KEMPENLANDSTR 17', 'VUGHT', '5262GK', '2', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1967-10-25', '16', '2009-12-16 18:43:33', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23823', 'MUTSAARS JAN', null, null, null, '1', null, null, '\0', '5', 'P', 'NYB23PCL9', '2007-06-04', 'M', 'KEMPENLANDSTR 17', 'VUGHT', '5262GK', '2', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1973-04-14', '16', '2009-12-16 18:51:15', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23824', 'FLIERS  ERWIN', null, null, null, '1', null, null, '\0', '5', null, 'NN4F3FFR9', '2005-10-18', 'M', 'VERDILAAN 68', 'VLISSINGEN', '4384', '2', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1972-12-21', '8', '2015-05-12 13:38:52', null, 'services/imagenRemota.aspx?url=\\\\10.2.0.30\\Gesviapi\\\\imagenes\\PASSPORT_20141217_105927.jpg', null, null, null);
INSERT INTO `clientes` VALUES ('23825', 'ECKRINGA FRANCISCA', null, null, null, '1', null, null, '\0', '5', 'P', 'NJ0949099', '2005-04-25', 'F', 'KIKKERTSBLOM 5', 'BURGUM', '9251TM', '2', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1965-02-16', '14', '2009-12-26 23:29:03', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23826', 'VAN WEELDEN WILHELMINA', null, null, null, '1', null, null, '\0', '5', 'P', 'NN5DJ4K36', '2009-07-16', 'F', 'RIVIERDIJK 205', 'SLIEDRECHT', '3361AH', '2', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1975-05-19', '12', '2009-12-28 22:37:35', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23827', 'FATEHI HAMIDREZA', null, null, null, '1', null, null, '\0', '5', 'P', 'NK1919845', '2005-12-07', 'M', 'LIERSTRAAT 37', 'GRONINGEN', '9742PA', '2', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1958-03-23', '16', '2009-12-30 23:35:20', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23828', 'VAN VUGT', null, null, null, '1', null, null, '\0', '5', null, '', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '8', '2009-10-16 10:52:53', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23829', 'WIDEN INGELA', null, null, null, '1', null, null, '\0', '5', 'P', '52199427', '2006-01-09', 'F', '', '', '', '5', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1949-12-14', '16', '2009-11-07 19:38:45', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23830', 'ROREN ARNE KJELL', null, null, null, '1', null, null, '\0', '5', 'P', '25235315', '2006-04-18', 'F', 'STOREBAKKEN 5', 'FOSNAVAG', '6902', '6', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1971-04-20', '56', '2010-01-31 15:52:57', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23831', 'MOGENSEN STEEN', null, null, null, '1', null, null, '\0', '5', null, '', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '8', '2009-10-16 11:09:53', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23832', 'STIBERG MERETHE', null, null, null, '1', null, null, '\0', '5', 'P', '21111362', '2005-05-30', 'F', 'DRAMSVEIEN 129', 'TROMSO', '9010', '6', null, null, null, null, null, '98823846', 'mstiberg@hotmail.com', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1977-04-14', '18', '2009-11-15 02:14:03', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23833', 'LUJAN SUAREZ Mª DEL CARMEN', null, null, null, '1', null, null, '\0', '5', 'D', '43254723A', '2003-06-16', 'F', 'AYACATA 23', 'LAS PALMAS', '35009', '1', null, null, null, null, null, '650313762', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1951-08-08', '17', '2009-10-23 10:55:48', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23834', 'DYNGELAND OVE', null, null, null, '1', null, null, '\0', '5', null, '26001195', '2007-06-06', null, 'AMUNDALEITET 81', 'ULSET', '5115', '6', null, null, null, null, null, '', 'OVDYN@YAHOO.NO', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1948-02-06', '8', '2011-09-07 13:03:05', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23835', 'BERG SVERRE KNUT', null, null, null, '1', null, null, '\0', '5', 'P', '20677086', '2005-01-07', 'M', 'BRATLANDSV 136', 'HAUKELAND', '5268', '6', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1957-10-16', '16', '2009-11-07 16:55:00', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23836', 'KAJALA RAUNI', null, null, null, '1', null, null, '\0', '5', 'P', '17066735', '2006-03-08', 'F', null, null, null, '7', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1955-07-05', '18', '2010-11-11 11:57:11', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23837', 'GADSBY NEIL', null, null, null, '1', null, null, '\0', '5', null, '', null, 'M', null, null, null, '4', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, null, '41', '2009-10-16 12:10:13', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23838', 'KARAGOEL CHRISTINE', null, null, null, '1', null, null, '\0', '5', null, '601020940', '2005-11-03', 'F', 'HECKWIESENWEG 3', 'STUTTGART', '70499', '3', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1983-11-05', '16', '2009-10-21 18:48:45', null, null, null, null, null);
INSERT INTO `clientes` VALUES ('23839', 'DIRI ELISABETH', null, null, null, '1', null, null, '\0', '5', null, '612812973', '2007-11-26', 'F', 'HECKWIESENWEG 3', 'STUTTGART', '70499', '3', null, null, null, null, null, '', '', null, null, null, null, null, null, null, null, null, null, null, null, '\0', '\0', '\0', null, null, null, '1985-07-08', '16', '2009-10-21 18:48:45', null, null, null, null, null);
