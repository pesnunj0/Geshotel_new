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
  `cliente_defecto` bit(1) NOT NULL DEFAULT b'0',
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
  `Cliente_factura` bit(1) NOT NULL DEFAULT b'0',
  `Cliente_huesped` bit(1) NOT NULL DEFAULT b'0',
  `permite_credito` bit(1) NOT NULL DEFAULT b'0',
  `limite_credito` float DEFAULT NULL,
  `factura_anticipada` bit(1) DEFAULT NULL,
  `vencimiento_facturas_id` smallint(6) DEFAULT NULL,
  `fecha_nacimiento` date DEFAULT NULL,
  `user_id` int(6) DEFAULT NULL,
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
  `temporada_id` smallint(6) DEFAULT NULL,
  `impuesto_incluido` bit(1) DEFAULT b'1',
  `mercado_id` smallint(6) DEFAULT NULL,
  `cliente_id_padre` int(11) DEFAULT NULL,
  `user_id` int(6) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`contrato_id`),
  KEY `hotel_id` (`hotel_id`),
  KEY `cliente_id` (`cliente_id`),
  CONSTRAINT `contratos_ibfk_1` FOREIGN KEY (`hotel_id`) REFERENCES `hoteles` (`hotel_id`),
  CONSTRAINT `contratos_ibfk_2` FOREIGN KEY (`cliente_id`) REFERENCES `clientes` (`cliente_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1;

-- -----------------------------------------
-- Table structure for lineas_de_contrato
-- -----------------------------------------
DROP TABLE IF EXISTS `lineas_de_contrato`;
CREATE TABLE `lineas_de_contrato` (
  `linea_contrato_id` int(11) NOT NULL AUTO_INCREMENT,
  `contrato_id` int(11) NOT NULL,
  `oferta` bit(1) DEFAULT NULL,
  `desde` date NOT NULL,
  `hasta` date NOT NULL,
  `servicio_id` int(11) NOT NULL,
  `unidad_calculo_id` smallint(2) NOT NULL,
  `frecuencia_id` smallint(6) DEFAULT '2',
  `tipo_imputacion_id` smallint(6) DEFAULT '0',
  `importe` float(15,3) NOT NULL,
  `lunes` bit(1) NOT NULL DEFAULT b'1',
  `martes` bit(1) NOT NULL DEFAULT b'1',
  `miercoles` bit(1) NOT NULL DEFAULT b'1',
  `jueves` bit(1) NOT NULL DEFAULT b'1',
  `viernes` bit(1) NOT NULL DEFAULT b'1',
  `sabado` bit(1) NOT NULL DEFAULT b'1',
  `domingo` bit(1) NOT NULL DEFAULT b'1',
  `pag_factura` smallint(6) DEFAULT '1',
  `user_id` int(6) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`linea_contrato_id`),
  KEY `tipo_oferta_id` (`tipo_oferta_id`),
  KEY `unidad_calculo_id` (`unidad_calculo_id`),
  KEY `servicio_id` (`servicio_id`),
  KEY `lineas_de_contrato_1` (`contrato_id`),
  KEY `contrato_id` (`contrato_id`,`servicio_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1;


-- ----------------------------
-- Table structure for contratos_edades
-- ----------------------------
DROP TABLE IF EXISTS `contratos_edades`;
CREATE TABLE `contratos_edades` (
  `contratos_edades_id` int(11) NOT NULL AUTO_INCREMENT,
  `hotel_id` smallint(6) NOT NULL,
  `cliente_id` int(11) NOT NULL,
  `fecha_desde` date NOT NULL,
  `fecha_hasta` date NOT NULL,
  `tipo_huesped_id` smallint(6) NOT NULL,
  `edad_minima` int(11) NOT NULL,
  `edad_maxima` int(11) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`contratos_edades_id`),
  KEY `tipo_huesped_id` (`tipo_huesped_id`)
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
  `aplicable_auto` bit(1) NOT NULL,
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
  `n` smallint(6) DEFAULT '0',
  `tipo_oferta_id` smallint(6) DEFAULT NULL,
  `m` decimal(10,2) DEFAULT '0.000',
  `ambito_oferta_id` smallint(6) DEFAULT NULL,
  `user_id` int(6) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  `impuesto_incluido` bit(1) DEFAULT b'1',
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
  KEY `ofertas_ibfk_9` (`unidad_calculo_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1;

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
  KEY `servico_id_existe` (`servico_id_existe`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1;

-- -----------------------------------------
-- Table structure for ofertas_rejillas
-- -----------------------------------------
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
  KEY `tipo_condicion_id` (`tipo_condicion_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1;
