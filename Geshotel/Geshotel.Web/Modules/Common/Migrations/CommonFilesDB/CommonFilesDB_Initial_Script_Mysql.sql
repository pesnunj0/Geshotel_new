/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50716
Source Host           : localhost:3306
Source Database       : commonfiles

Target Server Type    : MYSQL
Target Server Version : 50716
File Encoding         : 65001

Date: 2017-01-20 16:00:42

Owner : Javier Nuñez
*/

SET FOREIGN_KEY_CHECKS=0;

-- ---------------------------------------
-- Table structure for ambito_oferta
-- ---------------------------------------
DROP TABLE IF EXISTS `ambito_oferta`;
CREATE TABLE `ambito_oferta` (
  `ambito_oferta_id` smallint(6) NOT NULL,
  `nombre` varchar(15) NOT NULL,
  PRIMARY KEY (`ambito_oferta_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of ambito_oferta
-- ----------------------------
INSERT INTO `ambito_oferta` VALUES ('1', 'Dia');
INSERT INTO `ambito_oferta` VALUES ('2', 'Cantidad');

-- ----------------------------
-- Table structure for categoria_hoteles
-- ----------------------------
DROP TABLE IF EXISTS `categoria_hoteles`;
CREATE TABLE `categoria_hoteles` (
  `categoria_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `categoria` varchar(20) NOT NULL,
  `abreviatura` varchar(6) NOT NULL,
  PRIMARY KEY (`categoria_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of categoria_hoteles
-- ----------------------------
INSERT INTO `categoria_hoteles` VALUES ('1', '1 ESTRELLA', '*');
INSERT INTO `categoria_hoteles` VALUES ('2', '2 ESTRELLAS', '**');
INSERT INTO `categoria_hoteles` VALUES ('3', '3 ESTRELLAS', '***');
INSERT INTO `categoria_hoteles` VALUES ('4', '4 ESTRELLAS', '****');
INSERT INTO `categoria_hoteles` VALUES ('5', '5 ESTRELLAS', '*****');
INSERT INTO `categoria_hoteles` VALUES ('6', 'SUPERIOR', '5 * SU');

-- ----------------------------
-- Table structure for comunidades_autonomas
-- ----------------------------
DROP TABLE IF EXISTS `comunidades_autonomas`;
CREATE TABLE `comunidades_autonomas` (
  `comunidad_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `nacion_id` smallint(6) DEFAULT NULL,
  `comunidad_autonoma` varchar(50) DEFAULT NULL,
  `comunidad_autonoma_ista` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`comunidad_id`),
  KEY `nacion_id` (`nacion_id`) USING BTREE,
  CONSTRAINT `comunidades_autonomas_ibfk_1` FOREIGN KEY (`nacion_id`) REFERENCES `naciones` (`nacion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of comunidades_autonomas
-- ----------------------------
INSERT INTO `comunidades_autonomas` VALUES ('1', '1', 'Andalucia', null);
INSERT INTO `comunidades_autonomas` VALUES ('2', '1', 'Aragon', null);
INSERT INTO `comunidades_autonomas` VALUES ('3', '1', 'Asturias', null);
INSERT INTO `comunidades_autonomas` VALUES ('4', '1', 'Baleares', 'ES530');
INSERT INTO `comunidades_autonomas` VALUES ('5', '1', 'Canarias', null);
INSERT INTO `comunidades_autonomas` VALUES ('6', '1', 'Cantabria', null);
INSERT INTO `comunidades_autonomas` VALUES ('7', '1', 'Castilla y Leon', null);
INSERT INTO `comunidades_autonomas` VALUES ('8', '1', 'Castilla La Mancha', null);
INSERT INTO `comunidades_autonomas` VALUES ('9', '1', 'Cataluña', null);
INSERT INTO `comunidades_autonomas` VALUES ('10', '1', 'Valencia', null);
INSERT INTO `comunidades_autonomas` VALUES ('11', '1', 'Extremadura', null);
INSERT INTO `comunidades_autonomas` VALUES ('12', '1', 'Galicia', null);
INSERT INTO `comunidades_autonomas` VALUES ('13', '1', 'Madrid', null);
INSERT INTO `comunidades_autonomas` VALUES ('14', '1', 'Murcia', null);
INSERT INTO `comunidades_autonomas` VALUES ('15', '1', 'Navarra', null);
INSERT INTO `comunidades_autonomas` VALUES ('16', '1', 'Pais Vasco', null);
INSERT INTO `comunidades_autonomas` VALUES ('17', '1', 'La Rioja', 'ES230');
INSERT INTO `comunidades_autonomas` VALUES ('18', '1', 'Ceuta y Melilla', null);

-- ----------------------------
-- Table structure for conceptos_acelerador_reservas
-- ----------------------------
DROP TABLE IF EXISTS `conceptos_acelerador_reservas`;
CREATE TABLE `conceptos_acelerador_reservas` (
  `concepto_acelerador_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `concepto` varchar(15) NOT NULL,
  PRIMARY KEY (`concepto_acelerador_id`)
) ENGINE=InnoDB AUTO_INCREMENT=100 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of conceptos_acelerador_reservas
-- ----------------------------
INSERT INTO `conceptos_acelerador_reservas` VALUES ('1', 'Tipo Habitacion');
INSERT INTO `conceptos_acelerador_reservas` VALUES ('2', 'Pension');
INSERT INTO `conceptos_acelerador_reservas` VALUES ('99', 'Pax');

-- ----------------------------
-- Table structure for empresas
-- ----------------------------
DROP TABLE IF EXISTS `empresas`;
CREATE TABLE `empresas` (
  `empresa_id` smallint(2) NOT NULL AUTO_INCREMENT,
  `empresa` varchar(40) NOT NULL,
  `empresa_contable` varchar(5) DEFAULT NULL,
  `direccion` varchar(50) DEFAULT NULL,
  `poblacion` varchar(50) DEFAULT NULL,
  `zip` varchar(5) DEFAULT NULL,
  `provincia_id` smallint(2) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `fax` varchar(20) DEFAULT NULL,
  `cif` varchar(20) DEFAULT NULL,
  `ruta_ficheros` text,
  PRIMARY KEY (`empresa_id`),
  KEY `provincia_id` (`provincia_id`) USING BTREE,
  CONSTRAINT `empresas_ibfk_1` FOREIGN KEY (`provincia_id`) REFERENCES `provincias` (`provincia_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of empresas
-- ----------------------------
INSERT INTO `empresas` VALUES ('1', 'EMPRESA HOTELES 1', '889', 'Su dirección', 'Menorca', '43010', '8', '+34.902.109.704', '+34.928.229.290', 'B-35809789', 'D:\\geshotelfiles\\ficheros_contables');
INSERT INTO `empresas` VALUES ('2', 'EMPRESA PRUEBAS 1', '888', 'Ctra. Del Centro 1', 'Las Palmas de GC', '01001', '1', '+34.928.11.11.22', null, 'H-12345678', null);

-- ----------------------------
-- Table structure for estados_facturas
-- ----------------------------
DROP TABLE IF EXISTS `estados_facturas`;
CREATE TABLE `estados_facturas` (
  `estado_factura_id` smallint(6) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `es_error` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`estado_factura_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of estados_facturas
-- ----------------------------
INSERT INTO `estados_facturas` VALUES ('0', 'Creada', '1');
INSERT INTO `estados_facturas` VALUES ('1', 'Actualizada', '0');
INSERT INTO `estados_facturas` VALUES ('2', 'Contabilizada', '0');

-- ----------------------------
-- Table structure for formas_de_pago
-- ----------------------------
DROP TABLE IF EXISTS `formas_de_pago`;
CREATE TABLE `formas_de_pago` (
  `forma_pago_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `forma_pago` varchar(20) NOT NULL,
  `credito` bit(1) NOT NULL DEFAULT b'0',
  `sw_efectivo` bit(1) DEFAULT NULL,
  `sw_tarjeta` bit(1) DEFAULT NULL,
  `tarjeta_length` varchar(20) DEFAULT NULL,
  `tarjeta_prefixes` varchar(40) DEFAULT NULL,
  `tarjeta_checkdigit` bit(1) DEFAULT NULL,
  `sw_dingus` bit(1) DEFAULT b'0',
  `produccion_tpv` bit(1) DEFAULT b'1',
  PRIMARY KEY (`forma_pago_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of formas_de_pago
-- ----------------------------
INSERT INTO `formas_de_pago` VALUES ('1', 'Contado', '\0', '', null, null, null, null, '\0', '');
INSERT INTO `formas_de_pago` VALUES ('2', 'Credito', '', '\0', null, null, null, null, '\0', '');
INSERT INTO `formas_de_pago` VALUES ('3', 'Transferencia', '\0', '\0', null, null, null, null, '\0', '');
INSERT INTO `formas_de_pago` VALUES ('4', 'Visa', '\0', '\0', '', '13,16', '4', '', '\0', '');
INSERT INTO `formas_de_pago` VALUES ('5', 'MasterCard', '\0', '\0', '', '16', '51,52,53,54,55', '', '\0', '');
INSERT INTO `formas_de_pago` VALUES ('6', '4B', '\0', '\0', '', null, null, null, '\0', '');
INSERT INTO `formas_de_pago` VALUES ('7', 'Visa TPV Virtual', '\0', '\0', '', null, null, null, '', '');
INSERT INTO `formas_de_pago` VALUES ('8', 'AMEX', '\0', '\0', null, null, null, null, '\0', '');
INSERT INTO `formas_de_pago` VALUES ('9', 'Cta Casa Propiedad', '\0', '\0', null, null, null, null, '\0', '\0');
INSERT INTO `formas_de_pago` VALUES ('10', 'Cta Casa Direccion', '\0', '\0', null, null, null, null, '\0', '\0');
INSERT INTO `formas_de_pago` VALUES ('11', 'Cta Casa Animacion', '\0', '\0', null, null, null, null, '\0', '\0');

-- ----------------------------
-- Table structure for frecuencia_facturacion
-- ----------------------------
DROP TABLE IF EXISTS `frecuencia_facturacion`;
CREATE TABLE `frecuencia_facturacion` (
  `frecuencia_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `descripcion_corta` varchar(3) NOT NULL,
  `descripcion` varchar(30) NOT NULL,
  PRIMARY KEY (`frecuencia_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of frecuencia_facturacion
-- ----------------------------
INSERT INTO `frecuencia_facturacion` VALUES ('1', '1V', 'Una Vez');
INSERT INTO `frecuencia_facturacion` VALUES ('2', 'DIA', 'Diario');
INSERT INTO `frecuencia_facturacion` VALUES ('3', 'RSV', 'Reserva');

-- ----------------------------
-- Table structure for frecuencia_tipos_imputacion
-- ----------------------------
DROP TABLE IF EXISTS `frecuencia_tipos_imputacion`;
CREATE TABLE `frecuencia_tipos_imputacion` (
  `frecuencia_id` smallint(6) NOT NULL,
  `tipo_imputacion_id` smallint(6) NOT NULL,
  PRIMARY KEY (`frecuencia_id`,`tipo_imputacion_id`),
  KEY `tipo_imputacion_id` (`tipo_imputacion_id`),
  CONSTRAINT `frecuencia_tipos_imputacion_ibfk_1` FOREIGN KEY (`tipo_imputacion_id`) REFERENCES `tipos_de_imputacion` (`tipo_imputacion_id`),
  CONSTRAINT `frecuencia_tipos_imputacion_ibfk_2` FOREIGN KEY (`frecuencia_id`) REFERENCES `frecuencia_facturacion` (`frecuencia_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of frecuencia_tipos_imputacion
-- ----------------------------
INSERT INTO `frecuencia_tipos_imputacion` VALUES ('2', '0');
INSERT INTO `frecuencia_tipos_imputacion` VALUES ('1', '1');
INSERT INTO `frecuencia_tipos_imputacion` VALUES ('3', '1');
INSERT INTO `frecuencia_tipos_imputacion` VALUES ('1', '2');
INSERT INTO `frecuencia_tipos_imputacion` VALUES ('3', '2');
INSERT INTO `frecuencia_tipos_imputacion` VALUES ('3', '3');

-- ----------------------------
-- Table structure for grupos_de_cliente
-- ----------------------------
DROP TABLE IF EXISTS `grupos_de_cliente`;
CREATE TABLE `grupos_de_cliente` (
  `grupo_cliente_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `nombre_grupo` varchar(30) NOT NULL,
  `huesped` bit(1) NOT NULL DEFAULT b'0',
  `contratos` bit(1) NOT NULL DEFAULT b'0',
  `facturar` bit(1) NOT NULL DEFAULT b'1',
  `agencia` bit(1) NOT NULL DEFAULT b'0',
  `perfil` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`grupo_cliente_id`),
  KEY `huesped` (`huesped`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of grupos_de_cliente
-- ----------------------------
INSERT INTO `grupos_de_cliente` VALUES ('1', 'Agencias', '\0', '', '\0', '', '800');
INSERT INTO `grupos_de_cliente` VALUES ('2', 'Contratos', '\0', '', '', '\0', '800');
INSERT INTO `grupos_de_cliente` VALUES ('4', 'Empresas', '\0', '\0', '', '\0', '600');
INSERT INTO `grupos_de_cliente` VALUES ('5', 'Huespedes', '', '\0', '\0', '\0', '600');

-- ----------------------------
-- Table structure for grupos_de_servicios
-- ----------------------------
DROP TABLE IF EXISTS `grupos_de_servicios`;
CREATE TABLE `grupos_de_servicios` (
  `grupo_servicio_id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre_grupo` varchar(255) NOT NULL,
  `cta_contable` varchar(16) NOT NULL,
  PRIMARY KEY (`grupo_servicio_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of grupos_de_servicios
-- ----------------------------
INSERT INTO `grupos_de_servicios` VALUES ('1', 'Alojamiento', '705');
INSERT INTO `grupos_de_servicios` VALUES ('2', 'Pension', '7051');
INSERT INTO `grupos_de_servicios` VALUES ('3', 'Extras F&B', '7052');

-- ----------------------------
-- Table structure for grupos_habitacion
-- ----------------------------
DROP TABLE IF EXISTS `grupos_habitacion`;
CREATE TABLE `grupos_habitacion` (
  `grupo_habitacion_id` smallint(6) NOT NULL,
  `grupo_habitacion` varchar(15) NOT NULL,
  PRIMARY KEY (`grupo_habitacion_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of grupos_habitacion
-- ----------------------------
INSERT INTO `grupos_habitacion` VALUES ('1', '1 Dormitorio');
INSERT INTO `grupos_habitacion` VALUES ('2', '2 Dormitorios');
INSERT INTO `grupos_habitacion` VALUES ('3', 'Premier');
INSERT INTO `grupos_habitacion` VALUES ('4', 'Kid Suite');

-- ----------------------------
-- Table structure for grupos_oferta
-- ----------------------------
DROP TABLE IF EXISTS `grupos_oferta`;
CREATE TABLE `grupos_oferta` (
  `grupo_oferta_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `grupo_oferta` varchar(20) NOT NULL,
  PRIMARY KEY (`grupo_oferta_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of grupos_oferta
-- ----------------------------
INSERT INTO `grupos_oferta` VALUES ('1', 'Galas');
INSERT INTO `grupos_oferta` VALUES ('2', 'Early Booking');
INSERT INTO `grupos_oferta` VALUES ('3', 'NxM');
INSERT INTO `grupos_oferta` VALUES ('4', 'Descuento numero Pax');
INSERT INTO `grupos_oferta` VALUES ('5', 'Descuentos Niños');

-- ----------------------------
-- Table structure for hoteles
-- ----------------------------
DROP TABLE IF EXISTS `hoteles`;
CREATE TABLE `hoteles` (
  `hotel_id` smallint(2) NOT NULL AUTO_INCREMENT,
  `hotel` varchar(50) NOT NULL,
  `empresa_id` smallint(2) NOT NULL,
  `tipo_hotel_id` smallint(2) NOT NULL,
  `categoria_id` smallint(2) NOT NULL,
  `nombre_corto` varchar(6) DEFAULT NULL,
  `direccion` varchar(50) DEFAULT NULL,
  `poblacion` varchar(50) DEFAULT NULL,
  `zip` varchar(5) DEFAULT NULL,
  `provincia_id` smallint(2) NOT NULL,
  `nacion_id` smallint(2) NOT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `fax` varchar(20) DEFAULT NULL,
  `cta_manocorriente` varchar(16) DEFAULT NULL,
  `dpto_contable` varchar(5) DEFAULT NULL,
  `cta_contable_cajas` varchar(16) DEFAULT NULL,
  `cta_contable_banco` varchar(16) DEFAULT NULL,
  `fecha_inicio_programa` date DEFAULT NULL,
  `ruta_fichero_policia` varchar(512) DEFAULT NULL,
  `contador_fichero_policia` int(11) DEFAULT NULL,
  `identificador_fichero_policia` varchar(10) DEFAULT NULL,
  `email_reservas` varchar(100) DEFAULT NULL,
  `email_ventas` varchar(100) DEFAULT NULL,
  `email_smtp` varchar(100) DEFAULT NULL,
  `texto_cancelacion` text,
  `usuario_ista` text,
  `password_ista` text,
  `url_ista` text,
  `municipio_ista` text,
  `numero_registro_ista` int(11) DEFAULT NULL,
  `ruta_bavel` varchar(100) DEFAULT NULL,
  `dingus_usuario` varchar(20) DEFAULT NULL,
  `dingus_password` varchar(20) DEFAULT NULL,
  `dingus_hotel_code` varchar(10) DEFAULT NULL,
  `dingus_traductor` varchar(10) DEFAULT NULL,
  `dingus_url` varchar(255) DEFAULT NULL,
  `checkin_on_line` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `minimo_dias_checkin_online` smallint(6) DEFAULT '0',
  `zoom_mapa` smallint(6) DEFAULT NULL,
  `lat` decimal(18,15) DEFAULT NULL,
  `lng` double(18,15) DEFAULT NULL,
  `ancho` smallint(6) DEFAULT NULL,
  `alto` smallint(6) DEFAULT NULL,
  `overbooking_limit` float DEFAULT NULL,
  PRIMARY KEY (`hotel_id`),
  KEY `fk_empresas` (`empresa_id`),
  KEY `fk_provincia` (`provincia_id`),
  KEY `fk_nacion_id` (`nacion_id`),
  KEY `tipo_hotel_id` (`tipo_hotel_id`),
  KEY `categoria_id` (`categoria_id`),
  CONSTRAINT `hoteles_ibfk_1` FOREIGN KEY (`tipo_hotel_id`) REFERENCES `tipos_hotel` (`tipo_hotel_id`),
  CONSTRAINT `hoteles_ibfk_2` FOREIGN KEY (`categoria_id`) REFERENCES `categoria_hoteles` (`categoria_id`),
  CONSTRAINT `hoteles_ibfk_3` FOREIGN KEY (`empresa_id`) REFERENCES `portal`.`empresas` (`empresa_id`),
  CONSTRAINT `hoteles_ibfk_4` FOREIGN KEY (`provincia_id`) REFERENCES `portal`.`provincias` (`provincia_id`),
  CONSTRAINT `hoteles_ibfk_5` FOREIGN KEY (`nacion_id`) REFERENCES `portal`.`naciones` (`nacion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of hoteles
-- ----------------------------
INSERT INTO `hoteles` VALUES ('1', 'HOTEL 1', '1', '1', '4', 'PM', 'Urb. Castillo del Águila S/N', 'Playa Blanca, Yaiza. Lanzarote', '35580', '35', '1', '(+34) 928 518 196', '(+34) 928 519 099', '4309999', '000', '5700000', '5201004921', '2009-12-06', 'c:/temp/policia/pm/', '1914', '35987PLA02', 'webpm@hdhotels.com', 'webpm@hdhotels.com', 'correo', '* Precios válidos para reservas individuales exclusivamente, no aplicables a grupos y/o eventos especiales.', null, null, null, 'LAS PALMAS', '1', 'C:\\catanet_net_client\\db_hd_hoteles\\erp\\outbox\\', 'servicioshd', 'srvcshd', '1', 'HD', 'http://hd.dingus-services.com/services/tazzy/convertedbookingservice.asmx', '1', '3', '18', '28.860337000000000', '-13.815987000000000', '500', '500', '99');
INSERT INTO `hoteles` VALUES ('2', 'HOTEL 2', '1', '2', '3', 'PCGC', 'C/ Holanda s/n', ' Playa del Inglés, San Bartolomé de Tirajana', '35100', '35', '1', '(+34) 928 774 116 ', '(+34) 928 761 152', '4309998', '000', '5700005', '5201004921', '2009-11-01', 'c:/temp/policia/pcgc/', '1013', '35552AAABU', 'webpcgc@hdhotels.com', 'webpcgc@hdhotels.com', 'correo', '* Precios válidos para reservas individuales exclusivamente, no aplicables a grupos y/o eventos especiales.', null, null, null, 'LAS PALMAS', '1779', 'C:\\catanet_net_client\\db_hd_hoteles\\erp\\outbox\\', 'servicioshd', 'srvcshd', '2', 'PCGC', 'http://hd.dingus-services.com/services/tazzy/convertedbookingservice.asmx?wsdl', '1', '3', '17', '27.761752352202550', '-15.581848025321960', '600', '200', '99');
INSERT INTO `hoteles` VALUES ('3', 'HOTEL 3', '1', '2', '3', 'PCTF', 'Avda. Rafael Puig Llivina, 7 ', ' Playa de las Américas, Arona. Tenerife', '38660', '39', '1', '(+34) 922 790 874', '(+34) 922 790 313 ', '4309997', '000', '5700014', '5201004921', '2010-05-01', 'c:/temp/policia/pctf/', '772', '38001AAA1F', 'webpctf@hdhotels.com', 'webctf@hdhotels.com', 'correo', '* Oferta sujeta a un cupo limitado de habitaciones. El precio y las condiciones ofrecidas podrán ser diferentes en cada momento, incluso si solicita las mismas fechas. En caso de modificar reserva, compruebe siempre el nuevo precio aplicado antes de confirmar los cambios.', null, null, null, 'TENERIFE', '1', 'C:\\catanet_net_client\\db_hd_hoteles\\erp\\outbox\\', 'servicioshd', 'srvcshd', '3', 'PCTF', 'http://hd.dingus-services.com/services/tazzy/convertedbookingservice.asmx', '1', '3', '18', '28.060273000000000', '-16.731324000000000', '600', '500', '99');
INSERT INTO `hoteles` VALUES ('4', 'HOTEL 4', '1', '1', '4', 'BR', 'Avda Islas Canarias s/n', 'Costa Teguisa', '35509', '35', '1', '(+34) 928 826 077', '(+34) 928 346 043', '4309996', '000', '5700000', '5201004921', '2010-07-01', 'c:/temp/policia/beach_resort/', '1577', '35697AAH08', 'webbeachresort@hdhotels.com', 'webbeachresort@hdhotels.com', 'correo', '* Oferta sujeta a un cupo limitado de habitaciones. El precio y las condiciones ofrecidas podrán ser diferentes en cada momento, incluso si solicita las mismas fechas. En caso de modificar reserva, compruebe siempre el nuevo precio aplicado antes de confirmar los cambios.', null, null, null, 'LAS PALMAS', '1779', 'C:\\catanet_net_client\\db_hd_hoteles\\erp\\outbox\\', 'servicioshd', 'srvcshd', '4', 'HDBR', 'http://hd.dingus-services.com/services/tazzy/convertedbookingservice.asmx', '1', '3', '18', '29.002515000000000', '-13.482632000000000', '550', '550', '99');

-- ----------------------------
-- Table structure for impuestos
-- ----------------------------
DROP TABLE IF EXISTS `impuestos`;
CREATE TABLE `impuestos` (
  `impuesto_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `empresa_id` smallint(6) NOT NULL,
  `impuesto` varchar(30) NOT NULL,
  `porcentaje` float NOT NULL,
  `cta_contable` varchar(15) DEFAULT NULL,
  `activo_geshotel` tinyint(4) DEFAULT '0',
  `user_id` smallint(6) DEFAULT NULL,
  `fecha_actualizacion` datetime DEFAULT NULL,
  PRIMARY KEY (`impuesto_id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of impuestos
-- ----------------------------
INSERT INTO `impuestos` VALUES ('1', '1', 'Exento', '0', null, '0', '2', '2008-03-03 00:00:00');
INSERT INTO `impuestos` VALUES ('2', '1', 'Alimentos', '3', null, '0', '2', '2015-04-17 00:00:00');
INSERT INTO `impuestos` VALUES ('3', '1', 'General', '7', null, '0', '2', '2015-04-17 00:00:00');
INSERT INTO `impuestos` VALUES ('4', '1', 'Bebidas Alcohólicas', '13.5', null, '0', '2', '2015-04-17 00:00:00');
INSERT INTO `impuestos` VALUES ('5', '1', 'Tabaco Negro', '20', null, '0', '2', '2008-03-03 00:00:00');
INSERT INTO `impuestos` VALUES ('6', '1', 'Tabaco Rubio', '35', null, '0', '2', '2008-03-03 00:00:00');
INSERT INTO `impuestos` VALUES ('8', '2', 'Exento', '0', null, '0', '1', '2010-05-18 00:00:00');
INSERT INTO `impuestos` VALUES ('9', '2', '7%', '7', null, '0', '2', '2012-07-24 00:00:00');
INSERT INTO `impuestos` VALUES ('10', '4', 'EXENTO', '0', '1111111', '0', '2', '2011-12-05 00:00:00');
INSERT INTO `impuestos` VALUES ('11', '4', 'IGIC 7%', '7', '1111111', '1', '2', '2012-07-24 00:00:00');
INSERT INTO `impuestos` VALUES ('12', '4', 'IGIC 2%', '2', '1111111', '0', '2', '2011-12-05 00:00:00');
INSERT INTO `impuestos` VALUES ('13', '2', '3%', '3', null, '0', '2', '2012-07-26 00:00:00');

-- ----------------------------
-- Table structure for monedas
-- ----------------------------
DROP TABLE IF EXISTS `monedas`;
CREATE TABLE `monedas` (
  `moneda_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(20) NOT NULL,
  `desc_corta` varchar(10) NOT NULL,
  `cambio` float DEFAULT NULL,
  PRIMARY KEY (`moneda_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of monedas
-- ----------------------------
INSERT INTO `monedas` VALUES ('1', 'EURO', '€', '1');
INSERT INTO `monedas` VALUES ('2', 'US DOLAR', '$', '1.06');
INSERT INTO `monedas` VALUES ('3', 'LIBRA ESTERLINA', '£', '0.88');
INSERT INTO `monedas` VALUES ('4', 'CORONA SUECA', 'Kr', null);
INSERT INTO `monedas` VALUES ('5', 'FRANCO SUIZO', 'CHK', null);
INSERT INTO `monedas` VALUES ('6', 'CORONA CHECA', 'CZK', null);
INSERT INTO `monedas` VALUES ('7', 'RUBLO', 'RU', null);
INSERT INTO `monedas` VALUES ('8', 'YEN', 'YEN', null);
INSERT INTO `monedas` VALUES ('9', 'YUAN', 'YU', null);

-- ----------------------------
-- Table structure for naciones
-- ----------------------------
DROP TABLE IF EXISTS `naciones`;
CREATE TABLE `naciones` (
  `nacion_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `nacion` varchar(30) DEFAULT NULL,
  `desc_corta` varchar(6) DEFAULT NULL,
  `moneda_id` smallint(6) NOT NULL,
  `idioma_id` int(6) DEFAULT NULL,
  `numero_ine` smallint(6) DEFAULT NULL,
  `pais_ista` varchar(3) DEFAULT NULL,
  `defecto` tinyint(4) DEFAULT '0',
  `nombre_real` text CHARACTER SET utf8,
  `idioma_mails` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`nacion_id`),
  KEY `nacion` (`nacion`) USING BTREE,
  KEY `moneda_id` (`moneda_id`) USING BTREE,
  KEY `idioma_id` (`idioma_id`) USING BTREE,
  CONSTRAINT `naciones_ibfk_1` FOREIGN KEY (`moneda_id`) REFERENCES `monedas` (`moneda_id`),
  CONSTRAINT `naciones_ibfk_2` FOREIGN KEY (`idioma_id`) REFERENCES `default`.`languages` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of naciones
-- ----------------------------
INSERT INTO `naciones` VALUES ('1', 'ESPAÑA', 'ESP', '1', '1', '1', null, '1', 'España', 'ES');
INSERT INTO `naciones` VALUES ('2', 'HOLANDA', 'HOL', '1', '5', null, 'NLD', '0', 'Nederland', 'EN');
INSERT INTO `naciones` VALUES ('3', 'ALEMANIA', 'ALE', '1', '4', '2', 'DEU', '0', 'Deutschland', 'DE');
INSERT INTO `naciones` VALUES ('4', 'REINO UNIDO', 'UK', '3', '2', null, 'GBR', '0', 'UK', 'EN');
INSERT INTO `naciones` VALUES ('5', 'SUECIA', 'SWE', '4', '8', null, 'SWE', '0', 'Sverige', 'EN');
INSERT INTO `naciones` VALUES ('6', 'NORUEGA', 'NOR', '4', '12', null, 'NOR', '0', 'Norge', 'EN');
INSERT INTO `naciones` VALUES ('7', 'FINLANDIA', 'FIN', '1', '13', null, 'FIN', '0', 'Suomi', 'EN');
INSERT INTO `naciones` VALUES ('8', 'FRANCIA', 'FRA', '1', '3', null, 'FRA', '0', 'France', 'EN');
INSERT INTO `naciones` VALUES ('9', 'ITALIA', 'IT', '1', '9', null, 'ITA', '0', 'Italia', 'EN');
INSERT INTO `naciones` VALUES ('11', 'CANADA', 'CAN', '2', '2', null, 'CAN', '0', 'Canada', 'EN');
INSERT INTO `naciones` VALUES ('12', 'DINAMARCA', 'DEN', '1', '6', null, 'DNK', '0', 'Danmark', 'EN');
INSERT INTO `naciones` VALUES ('13', 'BELGICA', 'BEL', '1', '5', '4', 'BEL', '0', 'België/Belgique', 'EN');
INSERT INTO `naciones` VALUES ('14', 'IRLANDA', 'IRL', '1', '2', null, 'IRL', '0', 'Éire', 'EN');
INSERT INTO `naciones` VALUES ('15', 'RUMANIA', 'RUM', '1', '14', null, 'ROU', '0', 'România', 'EN');
INSERT INTO `naciones` VALUES ('16', 'PORTUGAL', 'POR', '1', '7', null, 'PRT', '0', 'Portugal', 'EN');
INSERT INTO `naciones` VALUES ('17', 'SUIZA', 'SUI', '5', '3', null, 'CHE', '0', 'Schweiz', 'EN');
INSERT INTO `naciones` VALUES ('18', 'LUXEMBURGO', 'LUX', '1', '15', null, 'LUX', '0', 'Luxemburg', 'EN');
INSERT INTO `naciones` VALUES ('19', 'GRECIA', 'GRE', '1', '16', null, 'GRC', '0', 'Greece', 'EN');
INSERT INTO `naciones` VALUES ('20', 'RESTO DE EUROPA', 'RESTE', '1', '2', null, null, '0', 'Other', 'EN');
INSERT INTO `naciones` VALUES ('21', 'POLONIA', 'POL', '1', '1', null, 'POL', '0', 'Polska', 'EN');
INSERT INTO `naciones` VALUES ('22', 'AUSTRIA', 'AUT', '1', '4', '3', 'AUT', '0', 'Österreich', 'EN');
INSERT INTO `naciones` VALUES ('23', 'REPUBLICA CHECA', 'CZEC', '1', '4', null, 'CZE', '0', 'Cesko ', 'EN');
INSERT INTO `naciones` VALUES ('25', 'RUSIA', 'RUS', '7', '10', null, 'RUS', '0', 'Russia', 'EN');
INSERT INTO `naciones` VALUES ('27', 'ESTADOS UNIDOS', 'USA', '2', '2', null, 'USA', '0', 'United States', 'EN');
INSERT INTO `naciones` VALUES ('28', 'JAPON', 'JPN', '8', '19', null, 'JPN', '0', 'Japan', 'EN');
INSERT INTO `naciones` VALUES ('29', 'CHINA', 'CHN', '9', '11', null, 'CHN', '0', 'China', 'EN');
INSERT INTO `naciones` VALUES ('30', 'ISLANDIA', 'ISL', '1', '2', null, 'ISL', '0', 'Ísland', 'EN');

-- ----------------------------
-- Table structure for provincias
-- ----------------------------
DROP TABLE IF EXISTS `provincias`;
CREATE TABLE `provincias` (
  `provincia_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `provincia` varchar(30) NOT NULL,
  `comunidad_autonoma_id` smallint(6) DEFAULT NULL,
  `nacion_id` smallint(6) NOT NULL,
  `provincia_ista` varchar(6) DEFAULT NULL,
  `defecto_ista` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`provincia_id`),
  KEY `nacion_id` (`nacion_id`) USING BTREE,
  KEY `comunidad_autonoma_id` (`comunidad_autonoma_id`) USING BTREE,
  CONSTRAINT `provincias_ibfk_1` FOREIGN KEY (`nacion_id`) REFERENCES `naciones` (`nacion_id`),
  CONSTRAINT `provincias_ibfk_2` FOREIGN KEY (`comunidad_autonoma_id`) REFERENCES `comunidades_autonomas` (`comunidad_id`)
) ENGINE=InnoDB AUTO_INCREMENT=54 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of provincias
-- ----------------------------
INSERT INTO `provincias` VALUES ('1', 'Álava ', '16', '1', 'ES211', '0');
INSERT INTO `provincias` VALUES ('2', 'Albacete', '8', '1', 'ES421', '0');
INSERT INTO `provincias` VALUES ('3', 'Alicante ', '10', '1', 'ES521', '0');
INSERT INTO `provincias` VALUES ('4', 'Almería ', '1', '1', 'ES611', '0');
INSERT INTO `provincias` VALUES ('5', 'Asturias ', '3', '1', 'ES120', '0');
INSERT INTO `provincias` VALUES ('6', 'Ávila ', '7', '1', 'ES411', '0');
INSERT INTO `provincias` VALUES ('7', 'Badajoz ', '11', '1', 'ES431', '0');
INSERT INTO `provincias` VALUES ('8', 'Palma de Mallorca ', '4', '1', 'ES532', '0');
INSERT INTO `provincias` VALUES ('9', 'Barcelona ', '9', '1', 'ES511', '0');
INSERT INTO `provincias` VALUES ('10', 'Burgos ', '7', '1', 'ES412', '0');
INSERT INTO `provincias` VALUES ('11', 'Cáceres ', '11', '1', 'ES432', '0');
INSERT INTO `provincias` VALUES ('12', 'Cádiz ', '1', '1', 'ES612', '0');
INSERT INTO `provincias` VALUES ('13', 'Cantabria ', '6', '1', 'ES130', '0');
INSERT INTO `provincias` VALUES ('14', 'Castellón ', '10', '1', 'ES522', '0');
INSERT INTO `provincias` VALUES ('15', 'Ciudad Real ', '8', '1', 'ES422', '0');
INSERT INTO `provincias` VALUES ('16', 'Córdoba ', '1', '1', 'ES613', '0');
INSERT INTO `provincias` VALUES ('17', 'La Coruña ', '12', '1', 'ES111', '0');
INSERT INTO `provincias` VALUES ('18', 'Cuenca ', '8', '1', 'ES423', '0');
INSERT INTO `provincias` VALUES ('19', 'Gerona ', '9', '1', 'ES512', '0');
INSERT INTO `provincias` VALUES ('20', 'Granada ', '1', '1', 'ES614', '0');
INSERT INTO `provincias` VALUES ('21', 'Guadalajara ', '8', '1', 'ES424', '0');
INSERT INTO `provincias` VALUES ('22', 'Guipúzcoa ', '16', '1', 'ES212', '0');
INSERT INTO `provincias` VALUES ('23', 'Huelva ', '1', '1', 'ES615', '0');
INSERT INTO `provincias` VALUES ('24', 'Huesca ', '2', '1', 'ES241', '0');
INSERT INTO `provincias` VALUES ('25', 'Jaén ', '1', '1', 'ES616', '0');
INSERT INTO `provincias` VALUES ('26', 'León ', '7', '1', 'ES413', '0');
INSERT INTO `provincias` VALUES ('27', 'Lérida ', '9', '1', 'ES513', '0');
INSERT INTO `provincias` VALUES ('28', 'Lugo ', '12', '1', 'ES112', '0');
INSERT INTO `provincias` VALUES ('29', 'Madrid ', '13', '1', 'ES300', '0');
INSERT INTO `provincias` VALUES ('30', 'Málaga ', '1', '1', 'ES617', '0');
INSERT INTO `provincias` VALUES ('31', 'Murcia ', '14', '1', 'ES620', '0');
INSERT INTO `provincias` VALUES ('32', 'Navarra ', '15', '1', 'ES220', '0');
INSERT INTO `provincias` VALUES ('33', 'Orense ', '12', '1', 'ES113', '0');
INSERT INTO `provincias` VALUES ('34', 'Palencia ', '7', '1', 'ES414', '0');
INSERT INTO `provincias` VALUES ('35', 'Las Palmas', '5', '1', 'ES701', '1');
INSERT INTO `provincias` VALUES ('36', 'Pontevedra ', '12', '1', 'ES114', '0');
INSERT INTO `provincias` VALUES ('37', 'Logroño', '17', '1', 'ES230', '0');
INSERT INTO `provincias` VALUES ('38', 'Salamanca ', '7', '1', 'ES415', '0');
INSERT INTO `provincias` VALUES ('39', 'Santa Cruz de Tenerife ', '5', '1', 'ES702', '0');
INSERT INTO `provincias` VALUES ('40', 'Segovia ', '7', '1', 'ES416', '0');
INSERT INTO `provincias` VALUES ('41', 'Sevilla ', '1', '1', 'ES618', '0');
INSERT INTO `provincias` VALUES ('42', 'Soria ', '7', '1', 'ES417', '0');
INSERT INTO `provincias` VALUES ('43', 'Tarragona ', '9', '1', 'ES514', '0');
INSERT INTO `provincias` VALUES ('44', 'Teruel ', '2', '1', 'ES242', '0');
INSERT INTO `provincias` VALUES ('45', 'Toledo ', '8', '1', 'ES425', '0');
INSERT INTO `provincias` VALUES ('46', 'Valencia ', '10', '1', 'ES523', '0');
INSERT INTO `provincias` VALUES ('47', 'Valladolid ', '7', '1', 'ES418', '0');
INSERT INTO `provincias` VALUES ('48', 'Vizcaya ', '16', '1', 'ES213', '0');
INSERT INTO `provincias` VALUES ('49', 'Zamora ', '7', '1', 'ES419', '0');
INSERT INTO `provincias` VALUES ('50', 'Zaragoza ', '2', '1', 'ES243', '0');
INSERT INTO `provincias` VALUES ('51', 'Ceuta', '18', '1', 'ES630', '0');
INSERT INTO `provincias` VALUES ('52', 'Melilla', '18', '1', 'ES640', '0');
INSERT INTO `provincias` VALUES ('53', 'N/A', null, '20', null, '0');

-- ----------------------------
-- Table structure for reserva_estados
-- ----------------------------
DROP TABLE IF EXISTS `reserva_estados`;
CREATE TABLE `reserva_estados` (
  `estado_reserva_id` smallint(6) NOT NULL,
  `estado` varchar(20) NOT NULL,
  `es_error_fechaini` smallint(6) NOT NULL,
  `es_error_fechafin` smallint(6) NOT NULL,
  PRIMARY KEY (`estado_reserva_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of reserva_estados
-- ----------------------------
INSERT INTO `reserva_estados` VALUES ('0', 'Pen.Fin', '1', '1');
INSERT INTO `reserva_estados` VALUES ('1', 'Pen.Entrar', '1', '1');
INSERT INTO `reserva_estados` VALUES ('2', 'Anulada', '0', '0');
INSERT INTO `reserva_estados` VALUES ('3', 'Check-in', '0', '1');
INSERT INTO `reserva_estados` VALUES ('4', 'Check-out', '1', '1');
INSERT INTO `reserva_estados` VALUES ('5', 'Facturado', '0', '0');
INSERT INTO `reserva_estados` VALUES ('6', 'No Show', '0', '0');

-- ----------------------------
-- Table structure for series
-- ----------------------------
DROP TABLE IF EXISTS `series`;
CREATE TABLE `series` (
  `serie_id` smallint(6) NOT NULL,
  `descripcion` varchar(20) NOT NULL,
  `abreviatura` varchar(4) NOT NULL,
  `manocorriente` tinyint(4) DEFAULT NULL,
  `visible` tinyint(4) DEFAULT NULL,
  `factura` tinyint(4) DEFAULT NULL,
  `deposito` tinyint(4) DEFAULT '0',
  `servicio_id` int(6) DEFAULT NULL,
  `impuesto_id` int(11) DEFAULT NULL,
  `voxel` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`serie_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of series
-- ----------------------------
INSERT INTO `series` VALUES ('1', 'Factura', 'FACT', '1', '1', '1', '0', null, null, '2');
INSERT INTO `series` VALUES ('2', 'Rectificativa', 'RECT', '1', '1', '1', '0', null, null, '0');
INSERT INTO `series` VALUES ('3', 'Ticket', 'TICK', '1', '1', '1', '0', null, null, '0');
INSERT INTO `series` VALUES ('4', 'Deposito', 'DEP', '0', '1', '0', '1', '69', '1', '0');
INSERT INTO `series` VALUES ('5', 'Anticipo', 'ANT', '0', '1', '0', '0', '66', '6', '0');
INSERT INTO `series` VALUES ('6', 'Descuento', 'DES', '0', '1', '0', '0', '65', '1', '0');
INSERT INTO `series` VALUES ('7', 'Descuento', 'DES', '0', '0', '0', '0', '65', '1', '0');
INSERT INTO `series` VALUES ('8', 'Gastos', 'GAST', '0', '1', '0', '0', null, null, '0');
INSERT INTO `series` VALUES ('9', 'Rectificativas 1', 'RECT', '1', '1', '1', '0', null, null, '2');

-- ----------------------------
-- Table structure for servicios
-- ----------------------------
DROP TABLE IF EXISTS `servicios`;
CREATE TABLE `servicios` (
  `servicio_id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre_servicio` varchar(50) NOT NULL,
  `abreviatura` varchar(6) NOT NULL,
  `tipo_servicio_id` smallint(6) NOT NULL,
  `sw_produccion` bit(4) NOT NULL DEFAULT b'1',
  `sw_descuento` bit(4) DEFAULT b'0',
  `sw_ajustes` bit(4) DEFAULT b'0',
  `sw_gastos` bit(4) DEFAULT b'0',
  `sw_pension` bit(4) NOT NULL DEFAULT b'0',
  `sw_rectificativa` bit(4) DEFAULT b'0',
  `tipo_unidad_calculo_id` smallint(6) DEFAULT NULL,
  `concepto_acelerador_reservas_id` smallint(6) DEFAULT NULL,
  `costo` float(6,2) DEFAULT '0.00',
  `suma_servicio_id` int(11) DEFAULT NULL,
  `resta_servicio_id` int(11) DEFAULT NULL,
  `user_id` int(6) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  `tipo_hab` smallint(6) DEFAULT NULL,
  `tipo_pension` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`servicio_id`),
  KEY `tipo_servicio_id` (`tipo_servicio_id`),
  KEY `servicio_id` (`concepto_acelerador_reservas_id`),
  KEY `tipo_unidad_calculo_id` (`tipo_unidad_calculo_id`),
  KEY `tipo_hab` (`tipo_hab`),
  CONSTRAINT `servicios_ibfk_1` FOREIGN KEY (`tipo_servicio_id`) REFERENCES `tipos_servicio` (`tipo_servicio_id`),
  CONSTRAINT `servicios_ibfk_2` FOREIGN KEY (`tipo_unidad_calculo_id`) REFERENCES `tipos_unidad_calculo` (`tipo_unidad_calculo_id`),
  CONSTRAINT `servicios_ibfk_3` FOREIGN KEY (`tipo_hab`) REFERENCES `grupos_habitacion` (`grupo_habitacion_id`),
  CONSTRAINT `servicios_ibfk_4` FOREIGN KEY (`concepto_acelerador_reservas_id`) REFERENCES `conceptos_acelerador_reservas` (`concepto_acelerador_id`)
) ENGINE=InnoDB AUTO_INCREMENT=245 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of servicios
-- ----------------------------
INSERT INTO `servicios` VALUES ('1', 'Alojamiento B1', 'A1', '1', '', '\0', '\0', '\0', '\0', '\0', '2', '99', null, null, null, '1', '2008-12-10 00:00:00', '1', null);
INSERT INTO `servicios` VALUES ('2', 'Desayuno', 'HD', '2', '', '\0', '\0', '\0', '', '\0', '2', '2', null, null, null, '1', '2009-02-02 00:00:00', null, '1');
INSERT INTO `servicios` VALUES ('3', 'Media Pension', 'MP', '2', '', '\0', '\0', '\0', '', '\0', '2', '2', null, null, null, '2', '2011-03-11 00:00:00', null, '2');
INSERT INTO `servicios` VALUES ('4', 'Todo Incluido', 'TI', '2', '', '\0', '\0', '\0', '', '\0', '2', '2', null, null, null, '1', '2011-08-17 00:00:00', null, '4');
INSERT INTO `servicios` VALUES ('5', 'Todo Incluido Bebidas', 'TIB', '2', '', '\0', '\0', '\0', '', '\0', '2', '2', null, null, null, '7', null, null, '4');
INSERT INTO `servicios` VALUES ('6', 'Alojamiento B2', 'A2', '1', '', '\0', '', '\0', '\0', '\0', '2', '99', null, null, null, '7', '2015-08-24 00:00:00', '2', null);
INSERT INTO `servicios` VALUES ('7', 'Cunas', 'CUN', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', null, null, null);
INSERT INTO `servicios` VALUES ('8', 'Gala Navidad HD', 'GNHD', '5', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '7', null, null, null);
INSERT INTO `servicios` VALUES ('9', 'Gala Fin de Año', 'GF', '5', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '7', '2015-01-14 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('10', 'Bungalow 1 Dormitorio', 'B1', '1', '', '\0', '\0', '\0', '\0', '\0', '1', '1', null, null, null, '7', null, '1', null);
INSERT INTO `servicios` VALUES ('11', 'Bungalow 2 Dormitorios', 'B2', '1', '', '\0', '\0', '\0', '\0', '\0', '1', '1', null, null, null, '7', null, '2', null);
INSERT INTO `servicios` VALUES ('12', 'Bar Piscina 1 Comidas', 'BP1C', '4', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', null, null, null);
INSERT INTO `servicios` VALUES ('13', 'Bar Piscina 1 Bebidas', 'BP1B', '4', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', null, null, null);
INSERT INTO `servicios` VALUES ('14', 'Bar Salon Bebidas', 'BSB', '4', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', null, null, null);
INSERT INTO `servicios` VALUES ('15', 'Bar Piscina 2 Comidas ', 'BP2C', '4', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', null, null, null);
INSERT INTO `servicios` VALUES ('16', 'Bar Piscina 2 Bebidas ', 'BP2B', '4', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', null, null, null);
INSERT INTO `servicios` VALUES ('17', 'Bar Restaurante Bebidas', 'BRB', '4', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '7', '2013-07-29 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('18', 'Bar Restaurante Comidas', 'BRC', '4', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '7', '2014-10-07 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('19', 'Gala Navidad', 'GN', '5', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '7', null, null, null);
INSERT INTO `servicios` VALUES ('20', 'Gala Fin de Año HD', 'GFHD', '5', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '7', null, null, null);
INSERT INTO `servicios` VALUES ('23', 'Habitacion Overbooking', 'HAOVB', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-01-21 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('31', 'Alquiler de Sombrilla', 'ALQSO', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-01-21 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('33', 'Cabinas Telefonicas', 'CABTF', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-01-21 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('37', 'Divisa', 'DIVIS', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-01-21 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('38', 'Exposiciones y Desfiles', 'EXPOS', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '37', '2015-05-12 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('39', 'Internet', 'INTER', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-01-21 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('40', 'Lavadoras', 'LAVAD', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-01-21 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('42', 'Caja de Seguridad', 'SAFE', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-01-21 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('43', 'Tabaco', 'TAB', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-01-21 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('44', 'Telefono', 'TELEF', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-01-21 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('45', 'Babychangingtable (Cambiador)', 'CAMBI', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-02-04 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('47', 'Babytrolly (Carrito)', 'CARRI', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-02-04 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('48', 'Rent a Car', 'RENT', '3', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '7', '2013-08-07 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('49', 'Tenis', 'TENIS', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-02-04 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('50', 'Babychair (Trona)', 'TRONA', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-02-04 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('51', 'Wellness Center', 'WELLN', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-02-04 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('52', 'Wellcome Package', 'WPACK', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-02-04 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('53', 'Alojamiento Premier', 'AP', '1', '', '\0', '\0', '\0', '\0', '\0', '2', '99', null, null, null, '1', '2009-03-04 00:00:00', '3', null);
INSERT INTO `servicios` VALUES ('54', 'Alojamiento Kid Suite', 'AKS', '1', '', '\0', '\0', '\0', '\0', '\0', '2', '99', null, null, null, '1', '2009-03-04 00:00:00', '4', null);
INSERT INTO `servicios` VALUES ('55', 'Premier', 'PRE', '1', '', '\0', '\0', '\0', '\0', '\0', '1', '1', null, null, null, '1', '2009-03-04 00:00:00', '3', null);
INSERT INTO `servicios` VALUES ('56', 'Kid Suite', 'KS', '1', '', '\0', '\0', '\0', '\0', '\0', '1', '1', null, null, null, '1', '2009-03-04 00:00:00', '4', null);
INSERT INTO `servicios` VALUES ('57', 'Pension Completa', 'PC', '2', '', '\0', '\0', '\0', '', '\0', '2', '2', null, null, null, '1', '2009-06-02 00:00:00', null, '3');
INSERT INTO `servicios` VALUES ('60', 'Varios', 'Var', '3', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '7', '2013-03-11 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('61', 'Upgrade de B1 a B2', 'B1AB2', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, '11', '10', '2', '2009-06-14 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('62', 'Descuento Publicidad Habitacion', 'DESH', '1', '', '', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2015-09-09 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('63', 'Descuento Pension', 'DESP', '2', '', '', '\0', '\0', '\0', '\0', '1', null, null, null, null, '2', '2009-04-14 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('65', 'Descuento Cobro', 'Desc', '3', '\0', '\0', '\0', '\0', '\0', '\0', '1', null, '0.00', null, null, '2', '2009-05-18 13:47:27', null, null);
INSERT INTO `servicios` VALUES ('66', 'Anticipo Factura', 'ANT', '3', '\0', '\0', '\0', '\0', '\0', '\0', '1', null, '0.00', null, null, '2', '2009-05-18 13:49:24', null, null);
INSERT INTO `servicios` VALUES ('69', 'Depositos', 'DEP', '7', '\0', '\0', '\0', '\0', '\0', '\0', '1', null, '0.00', null, null, '2', '2009-10-27 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('70', 'Ajustes Produccion Pension', 'AJPEN', '2', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '2', '2009-05-29 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('71', 'Ajustes Produccion Habitacion', 'AJUHA', '1', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '2', '2009-05-29 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('72', 'Ajustes Produccion Galas', 'AJUGA', '5', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '2', '2009-05-29 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('73', 'Ajustes Produccion Otros', 'AJUOT', '3', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '2', '2009-05-29 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('74', 'Habitacion Permisos (Late check out)', 'PER', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2011-08-22 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('75', 'Upgrade B2 A KS', 'B2AKS', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, '56', '11', '2', '2009-06-14 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('76', 'Animadores', 'ANIM', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '2', '2009-06-18 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('77', 'Upgrade MP a TI', 'MP2TI', '2', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, '4', '3', '2', '2009-06-23 00:00:00', null, '4');
INSERT INTO `servicios` VALUES ('78', 'Persona Extra SA/día', 'CS', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '37', '2015-06-01 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('79', 'Varios Golosinas', 'GOLOS', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-07-03 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('80', 'Salón de Conferencias', 'CONFE', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2015-11-24 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('83', 'Sillon de Masajes', 'SILLO', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-07-03 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('84', 'Bisutería', 'BISUT', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-07-03 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('85', 'Roturas', 'ROTUR', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '9', '2009-09-29 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('86', 'Publicidad', 'PUBLI', '6', '\0', '\0', '\0', '', '\0', '\0', '1', null, '0.00', null, null, '2', '2009-07-03 10:30:02', null, null);
INSERT INTO `servicios` VALUES ('87', 'Luz para Tenis', 'Luz', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '2', '2009-07-08 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('88', 'Upgrade Desayuno a TI', 'De2TI', '2', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, '4', '2', '2', '2009-07-09 00:00:00', null, '4');
INSERT INTO `servicios` VALUES ('89', 'Upgrade Desayuno a MP', 'DE2MP', '2', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, '3', '2', '2', '2009-07-09 00:00:00', null, '2');
INSERT INTO `servicios` VALUES ('90', 'Suplemento Gala Navidad MP (contratos)', 'GNMP', '5', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2011-12-22 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('91', 'Suplemento Gala Navidad TI (contratos)', 'GNTI', '5', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2011-12-22 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('92', 'Suplemento Gala Fin de Año MP (contratos)', 'GFMP', '5', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2011-12-22 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('93', 'Suplemento Gala Fin de Año TI (contratos)', 'GFTI', '5', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2011-12-22 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('94', 'Suite 1 Dormitorio', 'SUITE1', '1', '', '\0', '\0', '\0', '\0', '\0', '1', '1', null, null, null, '7', '2013-10-04 00:00:00', '1', null);
INSERT INTO `servicios` VALUES ('95', 'Suite 2 Dormitorios', 'SUITE2', '1', '', '\0', '\0', '\0', '\0', '\0', '1', '1', null, null, null, '7', '2013-10-04 00:00:00', '2', null);
INSERT INTO `servicios` VALUES ('96', 'Alojamiento Suite 1', 'SU1', '1', '', '\0', '\0', '\0', '\0', '\0', '2', '99', null, null, null, '7', '2013-10-04 00:00:00', '1', null);
INSERT INTO `servicios` VALUES ('97', 'Alojamiento Suite 2', 'SU2', '1', '', '\0', '\0', '\0', '\0', '\0', '2', '99', null, null, null, '7', '2013-10-04 00:00:00', '2', null);
INSERT INTO `servicios` VALUES ('98', 'Upgrade A1 a A2', 'A1UA2', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, '95', '94', '2', '2009-07-20 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('99', 'Upgrade A2 a KS', 'A2UKS', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, '56', '95', '2', '2009-07-20 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('100', 'Calefaccion', 'Cal', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '2', '2009-07-21 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('103', 'Carga Partidas vivas', 'CCI', '3', '\0', '\0', '\0', '\0', '\0', '\0', '1', null, '0.00', null, null, '2', '2009-07-31 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('104', 'Comisión bancaria', 'Comis', '6', '\0', '\0', '\0', '', '\0', '\0', '1', null, '0.00', null, null, '7', '2009-08-28 16:48:22', null, null);
INSERT INTO `servicios` VALUES ('105', 'Provisión Publicidad', 'ProvP', '6', '\0', '\0', '\0', '', '\0', '\0', '1', null, '0.00', null, null, '7', '2009-08-28 16:48:46', null, null);
INSERT INTO `servicios` VALUES ('106', 'Habitación Rectificativa', 'HABRE', '1', '', '\0', '\0', '\0', '\0', '', '1', null, null, null, null, '7', '2011-06-28 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('107', 'Desayuno rectificativa', 'DESRE', '2', '', '\0', '\0', '\0', '\0', '', '2', null, null, null, null, '7', '2011-06-28 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('108', 'Media Pensión Rectificativa', 'MPRE', '2', '', '\0', '\0', '\0', '\0', '', '2', null, null, null, null, '7', '2011-06-28 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('109', 'Todo Incluido Rectificativa', 'TIRE', '2', '', '\0', '\0', '\0', '\0', '', '2', null, null, null, null, '7', '2011-06-28 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('110', 'Supl. Doble Uso Ind.', 'SDUI', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '9', '2009-09-29 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('111', 'Coco´s birthday', 'COCO', '4', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-10-21 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('112', 'Artículos Merchandising', 'MERCHA', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2012-06-18 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('114', 'Regularización cobro', 'REGUL', '6', '\0', '\0', '\0', '', '\0', '\0', '1', null, '0.00', null, null, '7', '2009-11-30 11:09:21', null, null);
INSERT INTO `servicios` VALUES ('115', 'Produccion Habitacion Garantia', 'GAR', '1', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '2', '2009-12-04 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('116', 'Solo Alojamiento', 'SS', '2', '\0', '\0', '\0', '\0', '', '\0', '2', null, '0.00', null, null, '1', '2009-12-25 19:48:23', null, null);
INSERT INTO `servicios` VALUES ('117', 'Habitacion', 'HAB', '1', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '7', '2009-12-30 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('119', 'Mando TV', 'TV', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '2', '2010-04-08 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('120', 'Snack', 'SNK', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '2', '2010-04-14 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('121', 'Pesa', 'PES', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '2', '2010-04-14 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('122', 'Upgrade Cenas ', 'CEN', '2', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, '3', null, '7', '2011-02-15 00:00:00', null, '2');
INSERT INTO `servicios` VALUES ('123', 'Cenas Niños', 'CEN', '2', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, '3', null, '2', '2010-04-14 00:00:00', null, '2');
INSERT INTO `servicios` VALUES ('124', 'Upgrade de A1 a PRE', 'UA1PR', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, '55', '94', '1', '2010-07-14 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('125', 'Almuerzo', 'ALMUE', '4', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2010-05-25 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('126', 'Merchandising', 'MERCH', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2010-07-26 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('127', 'SIAM PARK', 'SIAM', '3', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '7', '2010-08-18 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('128', 'Misnusvalidos 1 Dorm', 'M1', '1', '', '\0', '\0', '\0', '\0', '\0', '1', '1', null, null, null, '2', '2010-10-07 00:00:00', '1', null);
INSERT INTO `servicios` VALUES ('129', 'Minusvalidos 2 Dorm.', 'M2', '1', '', '\0', '\0', '\0', '\0', '\0', '1', '1', null, null, null, '2', '2010-10-07 00:00:00', '2', null);
INSERT INTO `servicios` VALUES ('130', 'Alojamiento M1', 'AM1', '1', '', '\0', '\0', '\0', '\0', '\0', '2', '99', null, null, null, '2', '2010-10-07 00:00:00', '1', null);
INSERT INTO `servicios` VALUES ('131', 'Alojamiento M2', 'AM2', '1', '', '\0', '\0', '\0', '\0', '\0', '2', '99', null, null, null, '2', '2010-10-07 00:00:00', '2', null);
INSERT INTO `servicios` VALUES ('132', 'Máquinas recreativas', 'RECRE', '3', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '7', '2014-10-16 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('133', 'Báscula maletas', 'BASCU', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2010-10-15 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('134', 'Máquinas expendedoras (VENDING)', 'EXPEN', '3', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '7', '2014-01-24 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('135', 'Máquinas de café', 'CAFÉ', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2010-11-30 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('136', 'Upgrade SS a HD', 'SSHD', '2', '', '\0', '\0', '\0', '\0', '\0', '2', '2', null, '2', null, '7', '2010-12-22 00:00:00', null, '1');
INSERT INTO `servicios` VALUES ('137', 'Upgrade SS a MP', 'SSMP', '2', '', '\0', '\0', '\0', '\0', '\0', '2', '2', null, '3', null, '7', '2010-12-22 00:00:00', null, '2');
INSERT INTO `servicios` VALUES ('138', 'Upgrade SS a TI', 'SSTI', '2', '', '\0', '\0', '\0', '\0', '\0', '2', '2', null, '4', null, '7', '2010-12-22 00:00:00', null, '4');
INSERT INTO `servicios` VALUES ('139', 'Gala Navidad pasante 24.12', 'GNAP', '5', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '7', '2014-12-24 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('140', 'Gala Fin de Año pasante', 'GFINP', '5', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '7', '2014-12-24 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('141', 'Suplemento Gala Navidad SS (contratos)', 'GNSS', '5', '', '\0', '\0', '\0', '\0', '\0', '2', '2', null, null, null, '7', '2011-12-22 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('142', 'Suplemento Gala Fin de Año SS (contratos)', 'GFISS', '5', '', '\0', '\0', '\0', '\0', '\0', '2', '2', null, null, null, '7', '2011-12-22 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('143', 'Kid Suite +', 'KS+', '1', '', '\0', '\0', '\0', '\0', '\0', '1', '1', null, null, null, '2', '2011-01-27 00:00:00', '4', null);
INSERT INTO `servicios` VALUES ('144', 'Alojamiento KS+', 'AKS+', '1', '', '\0', '\0', '\0', '\0', '\0', '2', '99', null, null, null, '2', '2011-01-27 00:00:00', '4', null);
INSERT INTO `servicios` VALUES ('145', 'Productos Lavandería', 'LAVAN', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '37', '2011-02-04 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('146', 'Compensaciones OVB', 'COVB', '3', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '7', '2011-03-02 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('147', 'Compensaciones', 'COMP', '3', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '7', '2011-03-02 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('148', 'Pretty Woman', 'PREWO', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2011-04-18 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('149', 'Junior Suite Mar', 'JSM', '1', '', '\0', '\0', '\0', '\0', '\0', '1', '1', '0.00', null, null, '2', '2011-06-13 14:02:54', '1', null);
INSERT INTO `servicios` VALUES ('150', 'Alojamiento Junior Suite Mar', 'AJSM', '1', '', '\0', '\0', '\0', '\0', '\0', '2', '99', '0.00', null, null, '2', '2011-06-13 16:17:44', '1', null);
INSERT INTO `servicios` VALUES ('151', 'Suite Mar', 'SUITM', '1', '', '\0', '\0', '\0', '\0', '\0', '1', '1', '0.00', null, null, '2', '2011-06-13 16:18:51', '2', null);
INSERT INTO `servicios` VALUES ('152', 'Alojamiento Suite Mar', 'ASUIT', '1', '', '\0', '\0', '\0', '\0', '\0', '2', '99', '0.00', null, null, '2', '2011-06-13 16:19:43', '2', null);
INSERT INTO `servicios` VALUES ('153', 'Duplex Mar', 'DUPM', '1', '', '\0', '\0', '\0', '\0', '\0', '1', '1', '0.00', null, null, '2', '2011-06-13 16:20:38', '4', null);
INSERT INTO `servicios` VALUES ('154', 'Alojamiento Duplex Mar', 'ADUPM', '1', '', '\0', '\0', '\0', '\0', '\0', '2', '99', '0.00', null, null, '2', '2011-06-13 16:22:19', '4', null);
INSERT INTO `servicios` VALUES ('156', 'Junior Suite', 'JS', '1', '', '\0', '\0', '\0', '\0', '\0', '1', '1', '0.00', null, null, '2', '2011-06-14 16:47:28', '1', null);
INSERT INTO `servicios` VALUES ('157', 'Alojamiento Junior Suite', 'AJS', '1', '', '\0', '\0', '\0', '\0', '\0', '2', '99', '0.00', null, null, '7', '2013-01-24 00:00:00', '1', null);
INSERT INTO `servicios` VALUES ('159', 'Suite', 'SUIT', '1', '', '\0', '\0', '\0', '\0', '\0', '1', '1', '0.00', null, null, '2', '2011-06-14 16:49:38', '2', null);
INSERT INTO `servicios` VALUES ('160', 'Alojamiento Suite', 'ASUIT', '1', '', '\0', '\0', '\0', '\0', '\0', '2', '99', '0.00', null, null, '2', '2011-06-14 16:50:58', '2', null);
INSERT INTO `servicios` VALUES ('161', 'Duplex', 'DUP', '1', '', '\0', '\0', '\0', '\0', '\0', '1', '1', '0.00', null, null, '2', '2011-06-14 16:52:32', '4', null);
INSERT INTO `servicios` VALUES ('162', 'Alojamiento Duplex', 'ADUP', '1', '', '\0', '\0', '\0', '\0', '\0', '2', '99', '0.00', null, null, '2', '2011-06-14 16:53:21', '4', null);
INSERT INTO `servicios` VALUES ('163', 'HD Spa Wellness Center', 'SPA', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2011-06-15 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('164', 'Limpieza toallas', 'LTOAL', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '2', '2011-09-28 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('165', 'Snack Bar', 'SNACK', '4', '', '\0', '\0', '\0', '\0', '\0', '1', '2', null, null, null, '7', '2012-02-10 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('166', 'Comisión Transfer', 'TRANS', '3', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '7', '2011-07-06 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('167', 'Ingresos Reciclaje', 'IREC', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '2', '2011-07-26 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('168', 'Flores y tartas habitaciones', 'FLTA', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2011-08-31 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('169', 'Impresiones y fotocopias', 'IMFOT', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2011-08-31 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('170', 'Restaurante Italiano (Bebidas)', 'ITALI', '4', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2012-06-18 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('171', 'Venta productos estética (spa HDBR)', 'VTAES', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2015-09-14 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('172', 'Alquiler DVDs', 'DVD', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2011-10-04 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('173', 'Upgrade de A1 a Kid Suite', 'A1KS', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2011-10-05 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('174', 'Alquiler electrodomésticos', 'ELECT', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2011-10-14 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('175', 'Cancelaciones reservas', 'CANCE', '1', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '7', '2013-08-08 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('176', 'Upgrade Cena Japones', 'JAPO', '2', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, '3', null, '2', '2011-11-03 00:00:00', null, '2');
INSERT INTO `servicios` VALUES ('177', 'Descuento publicidad pensión', 'DtoPu', '2', '', '', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2015-09-09 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('178', 'Gala Navidad pasante 25.12', 'GNA25', '5', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '7', '2011-12-20 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('179', 'Upgrade MP/TI-Gala 24/12', 'UG24', '4', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '7', '2011-12-22 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('180', 'Upgrade MP/TI-Gala 25/12', 'UG25', '4', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '7', '2011-12-22 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('181', 'Upgrade MP/TI-Gala 31/12', 'UG31', '4', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '7', '2011-12-22 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('182', 'Aportación publicidad-guías', 'PBGUI', '1', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '7', '2012-11-12 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('183', 'Suplemento Vista Mar', 'Vista', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2011-12-30 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('184', 'Seguro Bicicletas', 'BICI', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2012-01-11 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('185', 'Paquete material nautico', 'MATNA', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2012-02-29 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('186', 'Curso de Windsurf y Catamarán', 'WIDCA', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2012-02-29 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('187', 'Cena', 'CENA', '4', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '7', '2014-05-12 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('188', 'Habitación interempresa', 'HABINT', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2012-03-30 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('189', 'Todo Incuido interempresa', 'TINTE', '2', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2012-03-30 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('190', 'Alojamiento Interempresa', 'AINT', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2012-03-30 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('191', 'Habitación rectificativa interempresa', 'Rinte', '1', '', '\0', '\0', '\0', '\0', '', '1', null, null, null, null, '7', '2012-05-07 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('192', 'Todo Incluido Rectificativa Interempresa', 'TIRIN', '2', '', '\0', '\0', '\0', '\0', '', '1', null, null, null, null, '7', '2012-05-07 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('193', 'Restaurante Italiano (Comidas)', 'ITACO', '4', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2012-06-18 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('194', 'Restaurante principal (Comidas)', 'RESTP', '4', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2014-03-26 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('195', 'Restaurante principal (Bebidas)', 'RESTP', '4', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2012-06-18 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('196', 'Upgrade Premier a B2', 'UPRB2', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, '11', '55', '7', '2012-08-01 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('197', 'Aire Acondicionado', 'AIRE', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2012-09-20 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('198', 'VIP PACKAGE', 'PVIP', '3', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '7', '2012-11-16 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('199', 'Peticiones obsequios para clientes(tartas, vino..)', 'OBSEQ', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2012-12-21 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('200', 'Suplemento Gala Navidad TI (contratos) 25.12', 'NTI25', '5', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2012-12-24 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('201', 'Publicidad Marketing Dinámico', 'MARKE', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2013-02-19 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('202', 'Masajes', 'MASAJ', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2013-02-27 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('203', 'Suite Premier', 'A1PRE', '1', '', '\0', '\0', '\0', '\0', '\0', '1', '1', '0.00', null, null, '2', '2013-10-04 00:00:00', '3', null);
INSERT INTO `servicios` VALUES ('204', 'Suite Tecnologica', 'TECS2', '1', '', '\0', '\0', '\0', '\0', '\0', '1', '1', '0.00', null, null, '2', '2013-10-04 00:00:00', '4', null);
INSERT INTO `servicios` VALUES ('205', 'Alojamiento SUPRE', 'AA1PR', '1', '', '\0', '\0', '\0', '\0', '\0', '2', '99', '0.00', null, null, '2', '2013-10-04 00:00:00', '3', null);
INSERT INTO `servicios` VALUES ('206', 'Alojamiento TECS2', 'AA2PR', '1', '', '\0', '\0', '\0', '\0', '\0', '2', '99', '0.00', null, null, '2', '2013-10-04 00:00:00', '4', null);
INSERT INTO `servicios` VALUES ('207', 'Desayuno interempresa', 'DESIN', '2', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2013-04-09 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('208', 'Venta cápsulas café', 'CAFÉ', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2013-06-13 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('209', 'Venta Pizzas', 'PIZZA', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2013-06-20 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('210', 'Alquiler Ipad', 'Ipad', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2013-06-26 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('211', 'Paquete Naútico', 'NAUTI', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2013-07-30 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('212', 'Alquiler MIFI', 'MIFI', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '2', '2013-09-12 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('213', 'Comida Animadores', 'Anima', '2', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '7', '2013-10-22 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('214', 'Habitación permisos contrato (Late check-out)', 'LCOC', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2013-10-23 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('215', 'Producción garantía no ocupada', 'GNocu', '1', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '7', '2014-01-27 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('216', 'Venta de aceite vegetal usado', 'ACEIT', '1', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '7', '2014-02-28 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('217', 'Arrendamiento Terraza', 'ARREN', '1', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '7', '2014-02-28 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('218', 'Refacturaciones consumos', 'CONSU', '1', '', '\0', '', '\0', '\0', '\0', '1', null, null, null, null, '7', '2014-03-12 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('219', 'Fotografía', 'FOTO', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2014-05-09 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('220', 'Pintura', 'PINTU', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2014-05-09 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('221', 'Suplemento Sailor', 'SAILOR', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2014-05-19 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('222', 'Alquiler Cama Balinesa', 'BALI', '3', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '7', '2014-05-19 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('223', 'Alquiler Bicicletas', 'BICIS', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2014-06-25 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('224', 'Descuento publicidad ', 'Publi', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2014-07-04 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('225', 'Day Use', 'DAYUS', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2014-08-01 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('226', 'Alquiler Babyphone', 'BPHON', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2014-09-05 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('227', 'Muñeco Be Chachi', 'CHACH', '3', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '7', '2014-11-10 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('228', 'Puzzle Chachi (formula Creativa)', 'CHACH', '3', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '37', '2014-09-15 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('229', 'Bolsa Chachi', 'CHACH', '3', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '37', '2014-09-15 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('230', 'Libro El Secreto de los Chachis', 'CHACH', '3', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '37', '2014-09-15 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('231', 'Libro de los dibujos Chachis', 'CHACH', '3', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '37', '2014-09-15 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('232', 'Libro actividades Chachis', 'CHACH', '3', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '37', '2014-09-15 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('233', 'Disco CD Chachi', 'CHACH', '3', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '37', '2014-09-15 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('234', 'Super-pack Chachi', 'CHACH', '3', '', '\0', '\0', '\0', '\0', '\0', '2', null, null, null, null, '37', '2014-09-15 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('235', 'Cambio HAB misma Categoría', 'HAB=', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, '30.00', null, null, '37', '2015-02-20 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('236', 'Camisetas Animación', 'CAMIS', '3', '', '\0', '\0', '\0', '\0', '\0', '2', null, '10.00', null, null, '37', '2015-03-27 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('237', 'Descuento Habitación', 'DESH', '1', '', '', '\0', '\0', '\0', '\0', '1', null, null, null, null, '37', '2015-06-11 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('238', 'Sorteos de animación', 'SORTE', '3', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2015-08-25 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('239', 'Comisión venta Sun Care', 'SUNCA', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2015-09-14 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('240', 'Alojamiento Villas', 'AVILL', '1', '', '\0', '\0', '\0', '\0', '\0', '2', '99', null, null, null, '2', '2015-09-14 00:00:00', '3', null);
INSERT INTO `servicios` VALUES ('241', 'Villas', 'VILL', '1', '', '\0', '\0', '\0', '\0', '\0', '1', '1', null, null, null, '2', '2015-09-14 00:00:00', '3', null);
INSERT INTO `servicios` VALUES ('242', 'Taza Chachi', 'TAZA', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2015-11-09 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('243', 'Descuento publicidad suplemento VIP', 'DTVIP', '3', '', '', '\0', '\0', '\0', '\0', '1', '2', null, null, null, '7', '2015-11-25 00:00:00', null, null);
INSERT INTO `servicios` VALUES ('244', 'Muñeco Be Chachi grande', 'CHACH', '1', '', '\0', '\0', '\0', '\0', '\0', '1', null, null, null, null, '7', '2015-11-26 00:00:00', null, null);

-- ----------------------------
-- Table structure for sexos
-- ----------------------------
DROP TABLE IF EXISTS `sexos`;
CREATE TABLE `sexos` (
  `sexo_id` char(1) NOT NULL,
  `sexo` varchar(20) NOT NULL,
  PRIMARY KEY (`sexo_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of sexos
-- ----------------------------
INSERT INTO `sexos` VALUES ('F', 'Female');
INSERT INTO `sexos` VALUES ('M', 'Male');

-- ----------------------------
-- Table structure for tipos_condicion
-- ----------------------------
DROP TABLE IF EXISTS `tipos_condicion`;
CREATE TABLE `tipos_condicion` (
  `tipo_condicion_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `condicion` varchar(2) NOT NULL,
  `literal` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`tipo_condicion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tipos_condicion
-- ----------------------------
INSERT INTO `tipos_condicion` VALUES ('1', '=', 'La unidad N es');
INSERT INTO `tipos_condicion` VALUES ('2', '>', 'Para mas de N');
INSERT INTO `tipos_condicion` VALUES ('3', '>=', 'Para N o mas');
INSERT INTO `tipos_condicion` VALUES ('4', '<', 'Para menos de N');
INSERT INTO `tipos_condicion` VALUES ('5', '<=', 'Para N o menos');
INSERT INTO `tipos_condicion` VALUES ('6', '==', 'Al N es');

-- ----------------------------
-- Table structure for tipos_de_imputacion
-- ----------------------------
DROP TABLE IF EXISTS `tipos_de_imputacion`;
CREATE TABLE `tipos_de_imputacion` (
  `tipo_imputacion_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `imputacion` varchar(20) NOT NULL,
  PRIMARY KEY (`tipo_imputacion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tipos_de_imputacion
-- ----------------------------
INSERT INTO `tipos_de_imputacion` VALUES ('1', 'Llegada');
INSERT INTO `tipos_de_imputacion` VALUES ('2', 'Salida');
INSERT INTO `tipos_de_imputacion` VALUES ('3', 'Prorrateado');
INSERT INTO `tipos_de_imputacion` VALUES ('4', 'Diario');

-- ----------------------------
-- Table structure for tipos_de_oferta
-- ----------------------------
DROP TABLE IF EXISTS `tipos_de_oferta`;
CREATE TABLE `tipos_de_oferta` (
  `tipo_oferta_id` smallint(6) NOT NULL,
  `Oferta` varchar(25) NOT NULL,
  `permitir_m_mayor_que_n` tinyint(4) NOT NULL DEFAULT '1',
  `rejilla` tinyint(4) NOT NULL DEFAULT '0',
  `Observaciones` varchar(100) DEFAULT NULL,
  `orden_aplicacion` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`tipo_oferta_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tipos_de_oferta
-- ----------------------------
INSERT INTO `tipos_de_oferta` VALUES ('1', 'n X m', '0', '0', 'Oferta tipo 2x1 implica que cada “n” unidades cobramos “m” de forma repetitiva', '1');
INSERT INTO `tipos_de_oferta` VALUES ('2', 'La ud. n y +,  m% dto', '1', '0', 'Las primeras “n-1” udes a precio normal. Despues aplicar “m%” descuento', '1');
INSERT INTO `tipos_de_oferta` VALUES ('3', 'La ud. n y +, m% inc.', '1', '0', 'Las primeras “n” udes a precio normal. Despues aplicar “m%” recargo', '1');
INSERT INTO `tipos_de_oferta` VALUES ('4', 'La ud. n y +, a m €', '1', '0', 'Las primeras “n” udes a precio normal. Despues aplicar el precio “m”', '0');
INSERT INTO `tipos_de_oferta` VALUES ('5', 'Menos de n, m% inc.', '1', '0', 'Hacer un “m%” de incremento a todas las unidades si hay menos unidades que lo que indica “n”', '1');
INSERT INTO `tipos_de_oferta` VALUES ('6', 'Menos de n, m% dto.', '1', '0', 'Hacer un “m%” de descuento a todas las unidades Si hay menos unidades que lo que indica “n”', '1');
INSERT INTO `tipos_de_oferta` VALUES ('7', 'Mas de n, m% dto', '1', '0', 'Hacer un “m”% de descuento a todo Si hay más unidades que lo que indica “n”', '1');
INSERT INTO `tipos_de_oferta` VALUES ('8', 'Mas de n, m% inc.', '1', '0', 'Hacer un “m”% de incremento a todo Si hay más unidades que lo que indica “n”', '1');
INSERT INTO `tipos_de_oferta` VALUES ('9', 'Mas de n, a m €', '1', '0', 'Aplicar el precio “m” a todas las unidades Si hay más unidades que lo que indica “n”', '0');
INSERT INTO `tipos_de_oferta` VALUES ('10', 'n uds m a % dto.', '1', '0', 'Si hay n  unidades tienen un m% de descuento.', '1');
INSERT INTO `tipos_de_oferta` VALUES ('11', 'n uds a m% inc.', '1', '0', 'Si hay n unidades tienen un m% de incremento.', '1');
INSERT INTO `tipos_de_oferta` VALUES ('12', 'n uds a m €', '1', '0', 'Las n primeras unidades se facturan a m €, el resto al precio normal.', '0');
INSERT INTO `tipos_de_oferta` VALUES ('13', 'Rejilla unidades', '1', '1', 'Tabla de Unidades a precios o porcentajes que se aplican', '1');
INSERT INTO `tipos_de_oferta` VALUES ('14', 'mas de n ,a m € inc/dec', '1', '0', 'Hacer un m de desc/inc euros a todo Si hay más unidades que lo que indica “n”', '1');
INSERT INTO `tipos_de_oferta` VALUES ('15', 'mas de n ,a n*m € inc/dec', '1', '0', 'Hacer un n*m de desc/inc euros a todo Si hay más unidades que lo que indica “n”', '1');
INSERT INTO `tipos_de_oferta` VALUES ('16', 'menos de n ,a m € inc/dec', '1', '0', 'Hacer un m de desc/inc euros a todo Si hay menos unidades que lo que indica “n”', '1');
INSERT INTO `tipos_de_oferta` VALUES ('17', 'menos de n ,a n*m € inc/d', '1', '0', 'Hacer un n*m de desc/inc euros a todo Si hay menos unidades que lo que indica “n”', '1');
INSERT INTO `tipos_de_oferta` VALUES ('18', 'La ud. n y -,  m% dto', '1', '0', 'Las primeras “n\" unidades aplica un % descuento', '1');
INSERT INTO `tipos_de_oferta` VALUES ('19', 'La ud. n y -, a m €', '1', '0', 'Las primeras “n\" unidades aplica un precio', '1');

-- ----------------------------
-- Table structure for tipos_de_tarjeta
-- ----------------------------
DROP TABLE IF EXISTS `tipos_de_tarjeta`;
CREATE TABLE `tipos_de_tarjeta` (
  `tipo_tarjeta_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `tipo_tarjeta` varchar(15) DEFAULT NULL,
  `tarjeta_length` varchar(20) DEFAULT NULL,
  `tarjeta_prefixes` varchar(40) DEFAULT NULL,
  `tarjeta_checkdigit` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`tipo_tarjeta_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tipos_de_tarjeta
-- ----------------------------
INSERT INTO `tipos_de_tarjeta` VALUES ('1', 'VISA/Matercard', '13,16', '4,51,52,53,54,55', '1');
INSERT INTO `tipos_de_tarjeta` VALUES ('2', 'Maestro', '12,13,14,15,16,18,19', '5018,5020,5038,6304,6759,6761', '1');

-- ----------------------------
-- Table structure for tipos_documento
-- ----------------------------
DROP TABLE IF EXISTS `tipos_documento`;
CREATE TABLE `tipos_documento` (
  `tipo_documento_id` char(1) NOT NULL,
  `tipo_documento` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`tipo_documento_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tipos_documento
-- ----------------------------
INSERT INTO `tipos_documento` VALUES ('C', 'CIF');
INSERT INTO `tipos_documento` VALUES ('D', 'DNI');
INSERT INTO `tipos_documento` VALUES ('N', 'NIF');
INSERT INTO `tipos_documento` VALUES ('P', 'Passport');

-- ----------------------------
-- Table structure for tipos_habitacion
-- ----------------------------
DROP TABLE IF EXISTS `tipos_habitacion`;
CREATE TABLE `tipos_habitacion` (
  `tipo_habitacion_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `desc_corta` varchar(6) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `grupo_habitacion_id` smallint(6) DEFAULT NULL,
  `numero_personas` smallint(6) NOT NULL,
  `desvios` tinyint(4) DEFAULT NULL,
  `no_show` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`tipo_habitacion_id`),
  KEY `grupo_habitacion_id` (`grupo_habitacion_id`),
  CONSTRAINT `tipos_habitacion_ibfk_1` FOREIGN KEY (`grupo_habitacion_id`) REFERENCES `grupos_habitacion` (`grupo_habitacion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tipos_habitacion
-- ----------------------------
INSERT INTO `tipos_habitacion` VALUES ('1', 'B1', 'Bungalow 1 dormitorio', '1', '3', '0', '0');
INSERT INTO `tipos_habitacion` VALUES ('2', 'B2', 'Bungalow 2 dormitorios', '2', '5', '0', '0');
INSERT INTO `tipos_habitacion` VALUES ('3', 'SUITE1', 'Suite 1 Dormitorio', '1', '4', '0', '0');
INSERT INTO `tipos_habitacion` VALUES ('6', 'PRE', 'Premier', '3', '3', '0', '0');
INSERT INTO `tipos_habitacion` VALUES ('7', 'KS', 'Kids Suites', '4', '5', '0', '0');
INSERT INTO `tipos_habitacion` VALUES ('8', 'SUITE2', 'Suite 2 dormitorios', '2', '6', '0', '0');
INSERT INTO `tipos_habitacion` VALUES ('10', 'DES', 'Desvios', null, '999', '1', '0');
INSERT INTO `tipos_habitacion` VALUES ('11', 'M1', 'Minusvalidos 1 Dorm.', '1', '3', '0', '0');
INSERT INTO `tipos_habitacion` VALUES ('12', 'M2', 'Minusvalidos 2 Dorm', '2', '5', '0', '0');
INSERT INTO `tipos_habitacion` VALUES ('13', 'KS+', 'Kid Suites Promo', '4', '5', '0', '0');
INSERT INTO `tipos_habitacion` VALUES ('14', 'JSM', 'Junior Suite Vista Mar', '3', '3', '0', '0');
INSERT INTO `tipos_habitacion` VALUES ('15', 'SUITM', 'Suite Vista Mar', '4', '3', '0', '0');
INSERT INTO `tipos_habitacion` VALUES ('16', 'DUPM', 'Duplex Vista Mar', '4', '4', '0', '0');
INSERT INTO `tipos_habitacion` VALUES ('17', 'JS', 'Junior Suite', '3', '4', '0', '0');
INSERT INTO `tipos_habitacion` VALUES ('18', 'SUIT', 'Suite', '4', '3', '0', '0');
INSERT INTO `tipos_habitacion` VALUES ('19', 'DUP', 'Duplex', '4', '4', '0', '0');
INSERT INTO `tipos_habitacion` VALUES ('20', 'HABINT', 'Habitación interempresa', null, '5', '0', '0');
INSERT INTO `tipos_habitacion` VALUES ('21', 'A1PRE', 'Suite Premier', '3', '3', '0', '0');
INSERT INTO `tipos_habitacion` VALUES ('22', 'TECS2', 'Suite Tecnologica', '4', '5', '0', '0');
INSERT INTO `tipos_habitacion` VALUES ('23', 'NO SH', 'No Show', null, '900', '1', '1');
INSERT INTO `tipos_habitacion` VALUES ('24', 'VILL', 'Villas', '3', '6', '0', '0');

-- ----------------------------
-- Table structure for tipos_hotel
-- ----------------------------
DROP TABLE IF EXISTS `tipos_hotel`;
CREATE TABLE `tipos_hotel` (
  `tipo_hotel_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `tipo_hotel` varchar(30) DEFAULT NULL,
  `abreviatura` varchar(6) DEFAULT NULL,
  PRIMARY KEY (`tipo_hotel_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tipos_hotel
-- ----------------------------
INSERT INTO `tipos_hotel` VALUES ('1', 'Hotel', 'H');
INSERT INTO `tipos_hotel` VALUES ('2', 'Hotel Bungalows', 'HA');
INSERT INTO `tipos_hotel` VALUES ('3', 'Apartamentos', 'A');
INSERT INTO `tipos_hotel` VALUES ('4', 'Hotel Rural', 'HR');

-- ----------------------------
-- Table structure for tipos_huesped
-- ----------------------------
DROP TABLE IF EXISTS `tipos_huesped`;
CREATE TABLE `tipos_huesped` (
  `tipo_huesped_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(30) NOT NULL,
  `Desc_corta` varchar(2) NOT NULL,
  `uc_id` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`tipo_huesped_id`),
  KEY `uc_id` (`uc_id`),
  CONSTRAINT `tipos_huesped_ibfk_1` FOREIGN KEY (`uc_id`) REFERENCES `unidades_calculo` (`unidad_calculo_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tipos_huesped
-- ----------------------------
INSERT INTO `tipos_huesped` VALUES ('1', 'Adultos', 'A', '2');
INSERT INTO `tipos_huesped` VALUES ('2', 'Niños 50% (N1)', 'N1', '3');
INSERT INTO `tipos_huesped` VALUES ('3', 'Niños Free (N2)', 'N2', '4');
INSERT INTO `tipos_huesped` VALUES ('4', 'Bebes ', 'B', '5');

-- ----------------------------
-- Table structure for tipos_pension
-- ----------------------------
DROP TABLE IF EXISTS `tipos_pension`;
CREATE TABLE `tipos_pension` (
  `tipo_pension_id` smallint(11) NOT NULL,
  `Tipo_pension` varchar(16) NOT NULL,
  PRIMARY KEY (`tipo_pension_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tipos_pension
-- ----------------------------
INSERT INTO `tipos_pension` VALUES ('0', 'Solo Alojamiento');
INSERT INTO `tipos_pension` VALUES ('1', 'Desayuno');
INSERT INTO `tipos_pension` VALUES ('2', 'Media Pension');
INSERT INTO `tipos_pension` VALUES ('3', 'Pension Completa');
INSERT INTO `tipos_pension` VALUES ('4', 'Todo Incluido');

-- ----------------------------
-- Table structure for tipos_servicio
-- ----------------------------
DROP TABLE IF EXISTS `tipos_servicio`;
CREATE TABLE `tipos_servicio` (
  `tipo_servicio_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `nombre_tipo_servicio` varchar(30) NOT NULL,
  PRIMARY KEY (`tipo_servicio_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tipos_servicio
-- ----------------------------
INSERT INTO `tipos_servicio` VALUES ('1', 'Habitación');
INSERT INTO `tipos_servicio` VALUES ('2', 'Pensión');
INSERT INTO `tipos_servicio` VALUES ('3', 'Otros');
INSERT INTO `tipos_servicio` VALUES ('4', 'Extras F&B');
INSERT INTO `tipos_servicio` VALUES ('5', 'Galas');
INSERT INTO `tipos_servicio` VALUES ('6', 'Gastos');
INSERT INTO `tipos_servicio` VALUES ('7', 'Depósitos');

-- ----------------------------
-- Table structure for tipos_unidad_calculo
-- ----------------------------
DROP TABLE IF EXISTS `tipos_unidad_calculo`;
CREATE TABLE `tipos_unidad_calculo` (
  `tipo_unidad_calculo_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `tipo_uc` varchar(15) NOT NULL,
  PRIMARY KEY (`tipo_unidad_calculo_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tipos_unidad_calculo
-- ----------------------------
INSERT INTO `tipos_unidad_calculo` VALUES ('1', 'Servicio');
INSERT INTO `tipos_unidad_calculo` VALUES ('2', 'Huespedes');

-- ----------------------------
-- Table structure for tipo_aplicacion_oferta
-- ----------------------------
DROP TABLE IF EXISTS `tipo_aplicacion_oferta`;
CREATE TABLE `tipo_aplicacion_oferta` (
  `tipo_aplicacion_oferta_id` varchar(1) NOT NULL,
  `aplicable_segun_fecha_de` varchar(15) NOT NULL,
  PRIMARY KEY (`tipo_aplicacion_oferta_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tipo_aplicacion_oferta
-- ----------------------------
INSERT INTO `tipo_aplicacion_oferta` VALUES ('E', 'Estancia');
INSERT INTO `tipo_aplicacion_oferta` VALUES ('L', 'LLegadas');

-- ----------------------------
-- Table structure for unidades_calculo
-- ----------------------------
DROP TABLE IF EXISTS `unidades_calculo`;
CREATE TABLE `unidades_calculo` (
  `unidad_calculo_id` smallint(2) NOT NULL AUTO_INCREMENT COMMENT 'Abreviatura',
  `UC` varchar(4) NOT NULL,
  `descripcion_unidad_calculo` varchar(30) NOT NULL,
  `tipo_unidad_calculo_id` smallint(6) DEFAULT NULL,
  `pax` bit(4) DEFAULT NULL,
  `servicio_id` int(6) DEFAULT NULL,
  `user_id` int(6) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`unidad_calculo_id`),
  KEY `unidad_calculo_id` (`unidad_calculo_id`),
  KEY `servicio_id` (`servicio_id`),
  KEY `tipo_unidad_calculo_id` (`tipo_unidad_calculo_id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `unidades_calculo_ibfk_1` FOREIGN KEY (`servicio_id`) REFERENCES `servicios` (`servicio_id`),
  CONSTRAINT `unidades_calculo_ibfk_2` FOREIGN KEY (`tipo_unidad_calculo_id`) REFERENCES `tipos_unidad_calculo` (`tipo_unidad_calculo_id`),
  CONSTRAINT `unidades_calculo_ibfk_3` FOREIGN KEY (`user_id`) REFERENCES `default`.`users` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1 COMMENT='InnoDB free: 10240 kB';

-- ----------------------------
-- Records of unidades_calculo
-- ----------------------------
INSERT INTO `unidades_calculo` VALUES ('1', 'SRV', 'Servicio', '1', '\0', null, '2', null);
INSERT INTO `unidades_calculo` VALUES ('2', 'A', 'Adultos', '2', '', null, '2', null);
INSERT INTO `unidades_calculo` VALUES ('3', 'N1', 'Niños 50%', '2', '', null, '2', null);
INSERT INTO `unidades_calculo` VALUES ('4', 'N2', 'Niños Free', '2', '', null, '2', null);
INSERT INTO `unidades_calculo` VALUES ('5', 'B', 'Bebes', '2', '\0', '7', '2', null);
INSERT INTO `unidades_calculo` VALUES ('6', 'A+N', 'A+N1+N2+B', '2', '\0', null, '2', null);
