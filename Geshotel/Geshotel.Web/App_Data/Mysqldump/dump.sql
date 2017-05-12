-- MySQL dump 10.13  Distrib 5.7.16, for Win64 (x86_64)
--
-- Host: localhost    Database: geshoteldb
-- ------------------------------------------------------
-- Server version	5.7.16-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `ambito_oferta`
--

DROP TABLE IF EXISTS `ambito_oferta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ambito_oferta` (
  `ambito_oferta_id` smallint(6) NOT NULL,
  `nombre` varchar(15) NOT NULL,
  PRIMARY KEY (`ambito_oferta_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ambito_oferta`
--

LOCK TABLES `ambito_oferta` WRITE;
/*!40000 ALTER TABLE `ambito_oferta` DISABLE KEYS */;
INSERT INTO `ambito_oferta` VALUES (1,'Dia'),(2,'Cantidad');
/*!40000 ALTER TABLE `ambito_oferta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `anticipos`
--

DROP TABLE IF EXISTS `anticipos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `anticipos` (
  `anticipo_id` int(11) NOT NULL AUTO_INCREMENT,
  `hotel_id` smallint(6) NOT NULL,
  `fecha` date NOT NULL,
  `tipo_anticipo_id` smallint(6) NOT NULL,
  `reserva_id` int(11) DEFAULT NULL,
  `cliente_id` int(11) NOT NULL,
  `caja_id` smallint(6) NOT NULL,
  `importe` decimal(15,2) NOT NULL,
  `forma_pago_id` smallint(6) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`anticipo_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `anticipos`
--

LOCK TABLES `anticipos` WRITE;
/*!40000 ALTER TABLE `anticipos` DISABLE KEYS */;
/*!40000 ALTER TABLE `anticipos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `businessunits`
--

DROP TABLE IF EXISTS `businessunits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `businessunits` (
  `UnitId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `ParentUnitId` int(11) DEFAULT NULL,
  PRIMARY KEY (`UnitId`),
  KEY `FK_BusinessUnits_ParentUnit` (`ParentUnitId`),
  CONSTRAINT `FK_BusinessUnits_ParentUnit` FOREIGN KEY (`ParentUnitId`) REFERENCES `businessunits` (`UnitId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `businessunits`
--

LOCK TABLES `businessunits` WRITE;
/*!40000 ALTER TABLE `businessunits` DISABLE KEYS */;
/*!40000 ALTER TABLE `businessunits` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cajas`
--

DROP TABLE IF EXISTS `cajas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cajas` (
  `caja_id` int(11) NOT NULL AUTO_INCREMENT,
  `hotel_id` smallint(6) NOT NULL,
  `nombre_caja` varchar(30) NOT NULL,
  `desc_corta` varchar(6) NOT NULL,
  `cierre_dia` tinyint(1) NOT NULL,
  `cta_contable` varchar(16) DEFAULT NULL,
  `dpto_contable` varchar(5) DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` datetime NOT NULL,
  PRIMARY KEY (`caja_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cajas`
--

LOCK TABLES `cajas` WRITE;
/*!40000 ALTER TABLE `cajas` DISABLE KEYS */;
/*!40000 ALTER TABLE `cajas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `canales_reserva`
--

DROP TABLE IF EXISTS `canales_reserva`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `canales_reserva` (
  `canal_reserva_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `empresa_id` smallint(6) NOT NULL,
  `nombre_canal` varchar(40) NOT NULL,
  PRIMARY KEY (`canal_reserva_id`),
  KEY `FK_canales_reserva_empresa_id` (`empresa_id`),
  CONSTRAINT `FK_canales_reserva_empresa_id` FOREIGN KEY (`empresa_id`) REFERENCES `empresas` (`empresa_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `canales_reserva`
--

LOCK TABLES `canales_reserva` WRITE;
/*!40000 ALTER TABLE `canales_reserva` DISABLE KEYS */;
/*!40000 ALTER TABLE `canales_reserva` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categoria_hoteles`
--

DROP TABLE IF EXISTS `categoria_hoteles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `categoria_hoteles` (
  `categoria_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `categoria` varchar(20) NOT NULL,
  `abreviatura` varchar(6) NOT NULL,
  PRIMARY KEY (`categoria_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria_hoteles`
--

LOCK TABLES `categoria_hoteles` WRITE;
/*!40000 ALTER TABLE `categoria_hoteles` DISABLE KEYS */;
INSERT INTO `categoria_hoteles` VALUES (1,'1 ESTRELLA','*'),(2,'2 ESTRELLAS','**'),(3,'3 ESTRELLAS','***'),(4,'4 ESTRELLAS','****'),(5,'5 ESTRELLAS','*****'),(6,'SUPERIOR','5 * SU');
/*!40000 ALTER TABLE `categoria_hoteles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cierres`
--

DROP TABLE IF EXISTS `cierres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cierres` (
  `cierre_id` int(11) NOT NULL AUTO_INCREMENT,
  `hotel_id` smallint(6) NOT NULL,
  `fecha_cierre` date NOT NULL,
  `fecha_cierre_tpv` datetime DEFAULT NULL,
  `fecha_contabilizacion` datetime DEFAULT NULL,
  `fichero_cierre` varchar(512) DEFAULT NULL,
  `fichero_policia` varchar(512) DEFAULT NULL,
  `postcierre` tinyint(1) DEFAULT '0',
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`cierre_id`),
  UNIQUE KEY `IX_cierre_hotel_fecha` (`hotel_id`,`fecha_cierre`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cierres`
--

LOCK TABLES `cierres` WRITE;
/*!40000 ALTER TABLE `cierres` DISABLE KEYS */;
INSERT INTO `cierres` VALUES (1,1,'2017-03-31',NULL,NULL,NULL,NULL,0,1,'2017-04-10 17:32:50'),(2,2,'2017-04-09',NULL,NULL,NULL,NULL,0,1,'2017-04-10 17:32:50'),(3,3,'2017-04-01',NULL,NULL,NULL,NULL,0,1,'2017-04-10 17:32:50'),(4,4,'2017-04-02',NULL,NULL,NULL,NULL,0,1,'2017-04-10 17:32:50');
/*!40000 ALTER TABLE `cierres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
  `tipo_documento_id` varchar(1) DEFAULT NULL,
  `nif` varchar(20) DEFAULT NULL,
  `fecha_documento` date DEFAULT NULL,
  `sexo_id` varchar(1) DEFAULT NULL,
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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES (1,'Clientes Directos','DIR',NULL,NULL,1,NULL,NULL,'\0',1,'C','99999999',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'\0','\0','\0',NULL,NULL,NULL,NULL,1,'2017-04-10 17:32:25',NULL,NULL,NULL,NULL,NULL),(2,'Clientes Extra Contado','EXTRA',NULL,NULL,1,1,NULL,'',2,'C','99999999',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'\0','\0','\0',NULL,'\0',NULL,NULL,1,'2017-05-01 17:47:47',NULL,NULL,NULL,'\0',NULL),(3,'Clientes Directos empresa 1','DIR',NULL,NULL,1,NULL,NULL,'\0',1,'C','99999999',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'\0','\0','\0',NULL,NULL,NULL,NULL,1,'2017-04-10 17:32:37',NULL,NULL,NULL,NULL,NULL),(4,'Touroperador 1','TOUR1',NULL,NULL,1,7,NULL,'\0',2,'C','99999999',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'\0','\0','',NULL,'',NULL,NULL,1,'2017-05-01 17:49:15',NULL,NULL,NULL,'\0',NULL),(5,'Clientes Directos empresa 2','DIR',NULL,NULL,2,NULL,NULL,'\0',1,'C','99999999',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'\0','\0','\0',NULL,NULL,NULL,NULL,1,'2017-04-10 17:32:37',NULL,NULL,NULL,NULL,NULL),(6,'Clientes Extra Contado 2','EXTRA',NULL,NULL,2,3,NULL,'',2,'C','99999999',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'\0','\0','\0',NULL,NULL,NULL,NULL,1,'2017-04-10 17:32:37',NULL,NULL,NULL,NULL,NULL),(7,'Agencia 1','AGE1',NULL,NULL,1,NULL,NULL,'\0',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'\0','\0','\0',NULL,'\0',NULL,NULL,1,'2017-05-01 17:49:00',NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientes_hotel`
--

DROP TABLE IF EXISTS `clientes_hotel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clientes_hotel` (
  `clientes_hotel_id` int(11) NOT NULL AUTO_INCREMENT,
  `cliente_id` int(11) NOT NULL,
  `hotel_id` smallint(6) NOT NULL,
  `cta_contable` varchar(15) NOT NULL,
  `dpto_contable` varchar(5) NOT NULL,
  `cta_anticipos` varchar(15) NOT NULL,
  `dpto_anticipos` varchar(5) NOT NULL,
  `cta_depositos` varchar(15) NOT NULL,
  `cliente_bavel` varchar(20) NOT NULL,
  `tipo_bavel` tinyint(1) NOT NULL,
  `factura_anticipada` tinyint(1) NOT NULL,
  `precio_dingus` tinyint(1) NOT NULL,
  `impuestos_incluidos` tinyint(1) NOT NULL DEFAULT '1',
  `comision` decimal(5,2) NOT NULL,
  PRIMARY KEY (`clientes_hotel_id`),
  UNIQUE KEY `IX_clientes_hotel` (`cliente_id`,`hotel_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes_hotel`
--

LOCK TABLES `clientes_hotel` WRITE;
/*!40000 ALTER TABLE `clientes_hotel` DISABLE KEYS */;
/*!40000 ALTER TABLE `clientes_hotel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cobros`
--

DROP TABLE IF EXISTS `cobros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cobros` (
  `cobro_id` int(11) NOT NULL AUTO_INCREMENT,
  `tipo_cobro_id` smallint(6) NOT NULL,
  `fecha` date NOT NULL,
  `hotel_id` smallint(6) NOT NULL,
  `caja_id` smallint(6) NOT NULL,
  `forma_pago_id` smallint(6) NOT NULL,
  `cta_bancaria_id` smallint(6) DEFAULT NULL,
  `fecha_contabilizacion` datetime DEFAULT NULL,
  `observaciones` varchar(400) DEFAULT NULL,
  `estado_cobro_id` smallint(6) NOT NULL DEFAULT '0',
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`cobro_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cobros`
--

LOCK TABLES `cobros` WRITE;
/*!40000 ALTER TABLE `cobros` DISABLE KEYS */;
/*!40000 ALTER TABLE `cobros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comunidades_autonomas`
--

DROP TABLE IF EXISTS `comunidades_autonomas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `comunidades_autonomas` (
  `comunidad_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `nacion_id` smallint(6) DEFAULT NULL,
  `comunidad_autonoma` varchar(50) DEFAULT NULL,
  `comunidad_autonoma_ista` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`comunidad_id`),
  KEY `nacion_id` (`nacion_id`) USING BTREE,
  CONSTRAINT `comunidades_autonomas_ibfk_1` FOREIGN KEY (`nacion_id`) REFERENCES `naciones` (`nacion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comunidades_autonomas`
--

LOCK TABLES `comunidades_autonomas` WRITE;
/*!40000 ALTER TABLE `comunidades_autonomas` DISABLE KEYS */;
INSERT INTO `comunidades_autonomas` VALUES (1,1,'Andalucia',NULL),(2,1,'Aragon',NULL),(3,1,'Asturias',NULL),(4,1,'Baleares','ES530'),(5,1,'Canarias',NULL),(6,1,'Cantabria',NULL),(7,1,'Castilla y Leon',NULL),(8,1,'Castilla La Mancha',NULL),(9,1,'Cataluña',NULL),(10,1,'Valencia',NULL),(11,1,'Extremadura',NULL),(12,1,'Galicia',NULL),(13,1,'Madrid',NULL),(14,1,'Murcia',NULL),(15,1,'Navarra',NULL),(16,1,'Pais Vasco',NULL),(17,1,'La Rioja','ES230'),(18,1,'Ceuta y Melilla',NULL);
/*!40000 ALTER TABLE `comunidades_autonomas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `conceptos_acelerador_reservas`
--

DROP TABLE IF EXISTS `conceptos_acelerador_reservas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `conceptos_acelerador_reservas` (
  `concepto_acelerador_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `concepto` varchar(15) NOT NULL,
  PRIMARY KEY (`concepto_acelerador_id`)
) ENGINE=InnoDB AUTO_INCREMENT=100 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `conceptos_acelerador_reservas`
--

LOCK TABLES `conceptos_acelerador_reservas` WRITE;
/*!40000 ALTER TABLE `conceptos_acelerador_reservas` DISABLE KEYS */;
INSERT INTO `conceptos_acelerador_reservas` VALUES (1,'Tipo Habitacion'),(2,'Pension'),(99,'Pax');
/*!40000 ALTER TABLE `conceptos_acelerador_reservas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `condiciones_linea_contrato`
--

DROP TABLE IF EXISTS `condiciones_linea_contrato`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `condiciones_linea_contrato` (
  `condiciones_linea_contrato_id` int(11) NOT NULL AUTO_INCREMENT,
  `linea_contrato_id` int(11) NOT NULL,
  `unidad_calculo_id` smallint(6) NOT NULL,
  `tipo_condicion_id` smallint(6) NOT NULL,
  `cantidad` decimal(5,1) NOT NULL,
  PRIMARY KEY (`condiciones_linea_contrato_id`),
  UNIQUE KEY `IX_condiciones_linea_contrato` (`linea_contrato_id`,`unidad_calculo_id`,`tipo_condicion_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `condiciones_linea_contrato`
--

LOCK TABLES `condiciones_linea_contrato` WRITE;
/*!40000 ALTER TABLE `condiciones_linea_contrato` DISABLE KEYS */;
/*!40000 ALTER TABLE `condiciones_linea_contrato` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `condiciones_ofertas`
--

DROP TABLE IF EXISTS `condiciones_ofertas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `condiciones_ofertas` (
  `condiciones_ofertas_id` int(11) NOT NULL AUTO_INCREMENT,
  `oferta_id` int(11) NOT NULL,
  `unidad_calculo_id` smallint(6) NOT NULL,
  `tipo_condicion_id` smallint(6) NOT NULL,
  `cantidad` float(5,1) NOT NULL,
  PRIMARY KEY (`condiciones_ofertas_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `condiciones_ofertas`
--

LOCK TABLES `condiciones_ofertas` WRITE;
/*!40000 ALTER TABLE `condiciones_ofertas` DISABLE KEYS */;
/*!40000 ALTER TABLE `condiciones_ofertas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contacts`
--

DROP TABLE IF EXISTS `contacts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contacts` (
  `ContactId` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(30) DEFAULT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `IdentityNo` varchar(20) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`ContactId`),
  KEY `FK_Contacts_UserId` (`UserId`),
  CONSTRAINT `FK_Contacts_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contacts`
--

LOCK TABLES `contacts` WRITE;
/*!40000 ALTER TABLE `contacts` DISABLE KEYS */;
/*!40000 ALTER TABLE `contacts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contadores`
--

DROP TABLE IF EXISTS `contadores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contadores` (
  `contador_id` int(11) NOT NULL AUTO_INCREMENT,
  `empresa_id` smallint(6) NOT NULL,
  `serie_id` smallint(6) NOT NULL,
  `ano` smallint(6) NOT NULL,
  `contador` int(11) NOT NULL,
  PRIMARY KEY (`contador_id`),
  UNIQUE KEY `IX_contadores_empresa` (`empresa_id`,`serie_id`,`ano`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contadores`
--

LOCK TABLES `contadores` WRITE;
/*!40000 ALTER TABLE `contadores` DISABLE KEYS */;
/*!40000 ALTER TABLE `contadores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contratos`
--

DROP TABLE IF EXISTS `contratos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contratos`
--

LOCK TABLES `contratos` WRITE;
/*!40000 ALTER TABLE `contratos` DISABLE KEYS */;
INSERT INTO `contratos` VALUES (1,1,2,'2017-04-10','2017-01-01','2017-12-31',NULL,NULL,'2017-99',NULL,'',NULL,NULL,1,'2017-04-17 12:06:52'),(2,1,2,'2017-04-10','2018-01-01','2020-12-31',NULL,NULL,'2018-1',NULL,'',NULL,NULL,1,'2017-04-10 17:32:25'),(3,2,2,'2017-01-01','2017-01-01','2017-12-31',NULL,NULL,'1111111',NULL,'',NULL,NULL,4,'2017-04-15 20:29:32');
/*!40000 ALTER TABLE `contratos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contratos_edades`
--

DROP TABLE IF EXISTS `contratos_edades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contratos_edades`
--

LOCK TABLES `contratos_edades` WRITE;
/*!40000 ALTER TABLE `contratos_edades` DISABLE KEYS */;
/*!40000 ALTER TABLE `contratos_edades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cupos`
--

DROP TABLE IF EXISTS `cupos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cupos` (
  `cupo_id` int(11) NOT NULL AUTO_INCREMENT,
  `cliente_id` int(11) NOT NULL,
  `hotel_id` smallint(6) NOT NULL,
  `fecha_desde` date NOT NULL,
  `fecha_hasta` date NOT NULL,
  `tipo_habitacion_id` smallint(6) NOT NULL,
  `garantia` decimal(5,2) NOT NULL DEFAULT '0.00',
  `cupo` smallint(6) NOT NULL,
  `reserva_automatica` tinyint(1) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`cupo_id`),
  KEY `FK_cupos_cliente_id` (`cliente_id`),
  KEY `FK_cupos_hotel_id` (`hotel_id`),
  KEY `FK_cupos_tipo_habitacion_id` (`tipo_habitacion_id`),
  CONSTRAINT `FK_cupos_cliente_id` FOREIGN KEY (`cliente_id`) REFERENCES `clientes` (`cliente_id`),
  CONSTRAINT `FK_cupos_hotel_id` FOREIGN KEY (`hotel_id`) REFERENCES `hoteles` (`hotel_id`),
  CONSTRAINT `FK_cupos_tipo_habitacion_id` FOREIGN KEY (`tipo_habitacion_id`) REFERENCES `tipos_habitacion` (`tipo_habitacion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cupos`
--

LOCK TABLES `cupos` WRITE;
/*!40000 ALTER TABLE `cupos` DISABLE KEYS */;
INSERT INTO `cupos` VALUES (1,2,1,'2017-04-10','2017-12-31',21,0.00,10,0,1,'2017-04-10 17:32:25');
/*!40000 ALTER TABLE `cupos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empresas`
--

DROP TABLE IF EXISTS `empresas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empresas`
--

LOCK TABLES `empresas` WRITE;
/*!40000 ALTER TABLE `empresas` DISABLE KEYS */;
INSERT INTO `empresas` VALUES (1,'EMPRESA HOTELES 1','889','Su dirección','Menorca','43010',8,'+34.902.109.704','+34.928.229.290','B-35809789','D:\\geshotelfiles\\ficheros_contables'),(2,'EMPRESA PRUEBAS 1','888','Ctra. Del Centro 1','Las Palmas de GC','01001',1,'+34.928.11.11.22',NULL,'H-12345678',NULL);
/*!40000 ALTER TABLE `empresas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `equivalencia_reservas_servicios`
--

DROP TABLE IF EXISTS `equivalencia_reservas_servicios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `equivalencia_reservas_servicios` (
  `reserva_servicio_id` int(11) NOT NULL AUTO_INCREMENT,
  `servicio_opcion_id` int(11) NOT NULL,
  `servicio_id` int(11) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`reserva_servicio_id`),
  UNIQUE KEY `IX_equivalencia_reservas_servicios` (`servicio_opcion_id`,`servicio_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equivalencia_reservas_servicios`
--

LOCK TABLES `equivalencia_reservas_servicios` WRITE;
/*!40000 ALTER TABLE `equivalencia_reservas_servicios` DISABLE KEYS */;
INSERT INTO `equivalencia_reservas_servicios` VALUES (1,10,1,1,'2017-04-18 17:49:53'),(2,11,6,1,'2017-04-18 17:49:53'),(3,55,53,1,'2017-04-18 17:49:53'),(4,56,54,1,'2017-04-18 17:49:53'),(5,96,94,1,'2017-04-18 17:49:53'),(6,97,95,1,'2017-04-18 17:49:53');
/*!40000 ALTER TABLE `equivalencia_reservas_servicios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estados_facturas`
--

DROP TABLE IF EXISTS `estados_facturas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `estados_facturas` (
  `estado_factura_id` smallint(6) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `es_error` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`estado_factura_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estados_facturas`
--

LOCK TABLES `estados_facturas` WRITE;
/*!40000 ALTER TABLE `estados_facturas` DISABLE KEYS */;
INSERT INTO `estados_facturas` VALUES (0,'Creada',1),(1,'Actualizada',0),(2,'Contabilizada',0);
/*!40000 ALTER TABLE `estados_facturas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `events`
--

DROP TABLE IF EXISTS `events`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `events` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(25) NOT NULL,
  `eventstart` datetime NOT NULL,
  `eventend` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `events`
--

LOCK TABLES `events` WRITE;
/*!40000 ALTER TABLE `events` DISABLE KEYS */;
/*!40000 ALTER TABLE `events` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `exceptions`
--

DROP TABLE IF EXISTS `exceptions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `exceptions` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `GUID` varchar(40) NOT NULL,
  `ApplicationName` varchar(50) NOT NULL,
  `MachineName` varchar(50) NOT NULL,
  `CreationDate` datetime NOT NULL,
  `Type` varchar(100) NOT NULL,
  `IsProtected` tinyint(1) NOT NULL DEFAULT '1',
  `Host` varchar(100) DEFAULT NULL,
  `Url` varchar(500) DEFAULT NULL,
  `HTTPMethod` varchar(10) DEFAULT NULL,
  `IPAddress` varchar(40) DEFAULT NULL,
  `Source` varchar(100) DEFAULT NULL,
  `Message` varchar(1000) DEFAULT NULL,
  `Detail` longtext,
  `StatusCode` int(11) DEFAULT NULL,
  `SQL` longtext,
  `DeletionDate` datetime DEFAULT NULL,
  `FullJson` longtext,
  `ErrorHash` int(11) DEFAULT NULL,
  `DuplicateCount` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`Id`),
  KEY `IX_Exceptions_GUID_App_Del_Cre` (`GUID`,`ApplicationName`,`DeletionDate`,`CreationDate`),
  KEY `IX_Exceptions_Hash_App_Cre_Del` (`ErrorHash`,`ApplicationName`,`CreationDate`,`DeletionDate`),
  KEY `IX_Exceptions_App_Del_Cre` (`ApplicationName`,`DeletionDate`,`CreationDate`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exceptions`
--

LOCK TABLES `exceptions` WRITE;
/*!40000 ALTER TABLE `exceptions` DISABLE KEYS */;
/*!40000 ALTER TABLE `exceptions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `facturas`
--

DROP TABLE IF EXISTS `facturas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `facturas` (
  `factura_id` int(11) NOT NULL AUTO_INCREMENT,
  `numero_factura` int(11) NOT NULL,
  `serie_id` smallint(6) NOT NULL,
  `fecha_factura` date NOT NULL,
  `hotel_id` smallint(6) NOT NULL,
  `cliente_id` int(11) NOT NULL,
  `reserva_id` int(11) DEFAULT NULL,
  `forma_pago_id` smallint(6) DEFAULT NULL,
  `direccion_factura` varchar(70) DEFAULT NULL,
  `poblacion_factura` varchar(50) DEFAULT NULL,
  `zip` varchar(10) DEFAULT NULL,
  `provincia_id` smallint(6) DEFAULT NULL,
  `fecha_vencimiento` date DEFAULT NULL,
  `estado_factura_id` smallint(6) NOT NULL,
  `ref_fra1` varchar(75) DEFAULT NULL,
  `ref_fra2` varchar(75) DEFAULT NULL,
  `id_factura_rectificada` int(11) DEFAULT NULL,
  `motivo_rectificacion` varchar(75) DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  `cuota` decimal(15,2) DEFAULT NULL,
  `importe_total` decimal(15,2) DEFAULT NULL,
  `envio_bavel` smallint(6) DEFAULT NULL,
  `fecha_envio_bavel` datetime DEFAULT NULL,
  `motivo` varchar(255) DEFAULT NULL,
  `conforme` varchar(255) DEFAULT NULL,
  `usuario_confirmacion` int(11) DEFAULT NULL,
  PRIMARY KEY (`factura_id`),
  KEY `numero_factura` (`numero_factura`),
  KEY `hotel_id` (`hotel_id`),
  KEY `reserva_id` (`reserva_id`),
  KEY `cliente_id` (`cliente_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `facturas`
--

LOCK TABLES `facturas` WRITE;
/*!40000 ALTER TABLE `facturas` DISABLE KEYS */;
/*!40000 ALTER TABLE `facturas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ficheros_contratos`
--

DROP TABLE IF EXISTS `ficheros_contratos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ficheros_contratos` (
  `fichero_id` int(11) NOT NULL AUTO_INCREMENT,
  `contrato_id` int(11) NOT NULL,
  `titulo` varchar(100) NOT NULL,
  `url` varchar(255) NOT NULL,
  `user_id` int(11) NOT NULL,
  `fecha_modificacion` datetime NOT NULL,
  PRIMARY KEY (`fichero_id`),
  KEY `FK_ficheros_contratos_contrato_id` (`contrato_id`),
  CONSTRAINT `FK_ficheros_contratos_contrato_id` FOREIGN KEY (`contrato_id`) REFERENCES `contratos` (`contrato_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ficheros_contratos`
--

LOCK TABLES `ficheros_contratos` WRITE;
/*!40000 ALTER TABLE `ficheros_contratos` DISABLE KEYS */;
/*!40000 ALTER TABLE `ficheros_contratos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `formas_de_pago`
--

DROP TABLE IF EXISTS `formas_de_pago`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formas_de_pago`
--

LOCK TABLES `formas_de_pago` WRITE;
/*!40000 ALTER TABLE `formas_de_pago` DISABLE KEYS */;
INSERT INTO `formas_de_pago` VALUES (1,'Contado','\0','',NULL,NULL,NULL,NULL,'\0',''),(2,'Credito','','\0',NULL,NULL,NULL,NULL,'\0',''),(3,'Transferencia','\0','\0',NULL,NULL,NULL,NULL,'\0',''),(4,'Visa','\0','\0','','13,16','4','','\0',''),(5,'MasterCard','\0','\0','','16','51,52,53,54,55','','\0',''),(6,'4B','\0','\0','',NULL,NULL,NULL,'\0',''),(7,'Visa TPV Virtual','\0','\0','',NULL,NULL,NULL,'',''),(8,'AMEX','\0','\0',NULL,NULL,NULL,NULL,'\0',''),(9,'Cta Casa Propiedad','\0','\0',NULL,NULL,NULL,NULL,'\0','\0'),(10,'Cta Casa Direccion','\0','\0',NULL,NULL,NULL,NULL,'\0','\0'),(11,'Cta Casa Animacion','\0','\0',NULL,NULL,NULL,NULL,'\0','\0');
/*!40000 ALTER TABLE `formas_de_pago` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `formas_pago_empresa`
--

DROP TABLE IF EXISTS `formas_pago_empresa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `formas_pago_empresa` (
  `forma_pago_id` smallint(6) NOT NULL,
  `empresa_id` smallint(6) NOT NULL,
  `cta_contable` varchar(15) DEFAULT NULL,
  `dpto_contable` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`forma_pago_id`,`empresa_id`),
  KEY `FK_formas_pago_empresa_empresa_id` (`empresa_id`),
  CONSTRAINT `FK_formas_pago_empresa_empresa_id` FOREIGN KEY (`empresa_id`) REFERENCES `empresas` (`empresa_id`),
  CONSTRAINT `FK_formas_pago_empresa_foma_pago_id` FOREIGN KEY (`forma_pago_id`) REFERENCES `formas_de_pago` (`forma_pago_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formas_pago_empresa`
--

LOCK TABLES `formas_pago_empresa` WRITE;
/*!40000 ALTER TABLE `formas_pago_empresa` DISABLE KEYS */;
/*!40000 ALTER TABLE `formas_pago_empresa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `formas_pago_hotel`
--

DROP TABLE IF EXISTS `formas_pago_hotel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `formas_pago_hotel` (
  `forma_pago_id` smallint(6) NOT NULL,
  `hotel_id` smallint(6) NOT NULL,
  `cta_contable` varchar(15) DEFAULT NULL,
  `dpto_contable` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`forma_pago_id`,`hotel_id`),
  KEY `FK_formas_pago_hotel_hotel_id` (`hotel_id`),
  CONSTRAINT `FK_formas_pago_hotel_foma_pago_id` FOREIGN KEY (`forma_pago_id`) REFERENCES `formas_de_pago` (`forma_pago_id`),
  CONSTRAINT `FK_formas_pago_hotel_hotel_id` FOREIGN KEY (`hotel_id`) REFERENCES `hoteles` (`hotel_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formas_pago_hotel`
--

LOCK TABLES `formas_pago_hotel` WRITE;
/*!40000 ALTER TABLE `formas_pago_hotel` DISABLE KEYS */;
/*!40000 ALTER TABLE `formas_pago_hotel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `frecuencia_facturacion`
--

DROP TABLE IF EXISTS `frecuencia_facturacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `frecuencia_facturacion` (
  `frecuencia_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `descripcion_corta` varchar(3) NOT NULL,
  `descripcion` varchar(30) NOT NULL,
  PRIMARY KEY (`frecuencia_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `frecuencia_facturacion`
--

LOCK TABLES `frecuencia_facturacion` WRITE;
/*!40000 ALTER TABLE `frecuencia_facturacion` DISABLE KEYS */;
INSERT INTO `frecuencia_facturacion` VALUES (1,'1V','Una Vez'),(2,'DIA','Diario'),(3,'RSV','Reserva');
/*!40000 ALTER TABLE `frecuencia_facturacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `frecuencia_tipos_imputacion`
--

DROP TABLE IF EXISTS `frecuencia_tipos_imputacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `frecuencia_tipos_imputacion` (
  `frecuencia_id` smallint(6) NOT NULL,
  `tipo_imputacion_id` smallint(6) NOT NULL,
  PRIMARY KEY (`frecuencia_id`,`tipo_imputacion_id`),
  KEY `tipo_imputacion_id` (`tipo_imputacion_id`),
  CONSTRAINT `frecuencia_tipos_imputacion_ibfk_1` FOREIGN KEY (`tipo_imputacion_id`) REFERENCES `tipos_de_imputacion` (`tipo_imputacion_id`),
  CONSTRAINT `frecuencia_tipos_imputacion_ibfk_2` FOREIGN KEY (`frecuencia_id`) REFERENCES `frecuencia_facturacion` (`frecuencia_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `frecuencia_tipos_imputacion`
--

LOCK TABLES `frecuencia_tipos_imputacion` WRITE;
/*!40000 ALTER TABLE `frecuencia_tipos_imputacion` DISABLE KEYS */;
INSERT INTO `frecuencia_tipos_imputacion` VALUES (2,0),(1,1),(3,1),(1,2),(3,2),(3,3);
/*!40000 ALTER TABLE `frecuencia_tipos_imputacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grupos_de_cliente`
--

DROP TABLE IF EXISTS `grupos_de_cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grupos_de_cliente`
--

LOCK TABLES `grupos_de_cliente` WRITE;
/*!40000 ALTER TABLE `grupos_de_cliente` DISABLE KEYS */;
INSERT INTO `grupos_de_cliente` VALUES (1,'Agencias','\0','','\0','',800),(2,'Contratos','\0','','','\0',800),(4,'Empresas','\0','\0','','\0',600),(5,'Huespedes','','\0','\0','\0',600);
/*!40000 ALTER TABLE `grupos_de_cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grupos_de_servicios`
--

DROP TABLE IF EXISTS `grupos_de_servicios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grupos_de_servicios` (
  `grupo_servicio_id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre_grupo` varchar(255) NOT NULL,
  `cta_contable` varchar(16) NOT NULL,
  PRIMARY KEY (`grupo_servicio_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grupos_de_servicios`
--

LOCK TABLES `grupos_de_servicios` WRITE;
/*!40000 ALTER TABLE `grupos_de_servicios` DISABLE KEYS */;
INSERT INTO `grupos_de_servicios` VALUES (1,'Alojamiento','705'),(2,'Pension','7051'),(3,'Extras F&B','7052');
/*!40000 ALTER TABLE `grupos_de_servicios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grupos_habitacion`
--

DROP TABLE IF EXISTS `grupos_habitacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grupos_habitacion` (
  `grupo_habitacion_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `grupo_habitacion` varchar(15) NOT NULL,
  PRIMARY KEY (`grupo_habitacion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grupos_habitacion`
--

LOCK TABLES `grupos_habitacion` WRITE;
/*!40000 ALTER TABLE `grupos_habitacion` DISABLE KEYS */;
INSERT INTO `grupos_habitacion` VALUES (1,'1 Dormitorio'),(2,'2 Dormitorios'),(3,'Premier'),(4,'Kid Suite');
/*!40000 ALTER TABLE `grupos_habitacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grupos_oferta`
--

DROP TABLE IF EXISTS `grupos_oferta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grupos_oferta` (
  `grupo_oferta_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `grupo_oferta` varchar(20) NOT NULL,
  PRIMARY KEY (`grupo_oferta_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grupos_oferta`
--

LOCK TABLES `grupos_oferta` WRITE;
/*!40000 ALTER TABLE `grupos_oferta` DISABLE KEYS */;
INSERT INTO `grupos_oferta` VALUES (1,'Galas'),(2,'Early Booking'),(3,'NxM'),(4,'Descuento numero Pax'),(5,'Descuentos Niños');
/*!40000 ALTER TABLE `grupos_oferta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `habitaciones`
--

DROP TABLE IF EXISTS `habitaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `habitaciones` (
  `habitacion_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `hotel_id` smallint(6) NOT NULL,
  `numero_habitacion` varchar(8) NOT NULL,
  `tipo_habitacion_id` smallint(6) NOT NULL,
  `extension` smallint(6) DEFAULT NULL,
  `observaciones` varchar(255) DEFAULT NULL,
  `situacion_id` smallint(6) DEFAULT NULL,
  `fecha_inicio` date DEFAULT NULL,
  `estado_telefono` smallint(6) DEFAULT NULL,
  `estado_procesado` smallint(6) DEFAULT NULL,
  `habitacion_ista` varchar(20) DEFAULT NULL,
  `zona_limpieza_id` smallint(6) DEFAULT NULL,
  `lat` decimal(15,10) DEFAULT NULL,
  `lng` decimal(15,10) DEFAULT NULL,
  `primary_image` varchar(100) DEFAULT NULL,
  `galleryimages` longtext,
  `planta` smallint(6) DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT '2017-04-10 17:32:27',
  PRIMARY KEY (`habitacion_id`),
  KEY `IX_hotel_id` (`hotel_id`),
  KEY `IX_tipo_habitacion` (`tipo_habitacion_id`),
  KEY `IX_situacion` (`situacion_id`),
  KEY `IX_zona_limpieza` (`zona_limpieza_id`),
  CONSTRAINT `FK_habitaciones_hotel_id` FOREIGN KEY (`hotel_id`) REFERENCES `hoteles` (`hotel_id`),
  CONSTRAINT `FK_habitaciones_situacion` FOREIGN KEY (`situacion_id`) REFERENCES `habitaciones_situacion` (`situacion_id`),
  CONSTRAINT `FK_habitaciones_tipo_habitacion_id` FOREIGN KEY (`tipo_habitacion_id`) REFERENCES `tipos_habitacion` (`tipo_habitacion_id`),
  CONSTRAINT `FK_zonas_limpieza` FOREIGN KEY (`zona_limpieza_id`) REFERENCES `zonas_limpieza` (`zona_limpieza_id`)
) ENGINE=InnoDB AUTO_INCREMENT=111 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `habitaciones`
--

LOCK TABLES `habitaciones` WRITE;
/*!40000 ALTER TABLE `habitaciones` DISABLE KEYS */;
INSERT INTO `habitaciones` VALUES (1,1,'001',4,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(2,1,'002',4,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(3,1,'003',4,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(4,1,'004',4,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(5,1,'005',4,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(6,1,'006',4,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(7,1,'007',4,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(8,1,'008',4,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(9,1,'009',4,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(10,1,'010',4,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(11,1,'011',5,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(12,1,'012',5,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(13,1,'013',5,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(14,1,'014',5,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(15,1,'015',5,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(16,1,'016',5,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(17,1,'017',5,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(18,1,'018',5,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(19,1,'999',7,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(20,1,'888',20,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(21,2,'999',7,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(22,2,'888',20,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(23,2,'001',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(24,2,'002',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(25,2,'003',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(26,2,'004',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(27,2,'005',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(28,2,'006',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(29,2,'007',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(30,2,'008',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(31,2,'009',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(32,2,'010',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(33,2,'011',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(34,2,'012',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(35,2,'013',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(36,2,'014',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(37,2,'015',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(38,2,'016',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(39,2,'017',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(40,2,'018',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(41,2,'019',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(42,2,'020',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(43,2,'021',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(44,2,'022',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(45,2,'023',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(46,2,'024',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(47,2,'025',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(48,2,'026',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(49,2,'027',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(50,2,'028',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(51,2,'029',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(52,2,'030',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(53,2,'031',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(54,2,'032',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(55,2,'033',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(56,2,'034',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(57,2,'035',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(58,2,'036',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(59,2,'037',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(60,2,'038',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(61,2,'039',2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(62,2,'041',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(63,2,'042',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(64,2,'043',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(65,2,'044',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(66,2,'045',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(67,2,'046',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(68,2,'047',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(69,2,'048',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(70,2,'049',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(71,2,'050',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(72,2,'051',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(73,2,'052',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(74,2,'053',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(75,2,'054',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(76,2,'055',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(77,2,'056',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(78,2,'057',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(79,2,'058',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(80,2,'059',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(81,2,'060',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(82,2,'061',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(83,2,'062',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(84,2,'063',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(85,2,'064',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(86,2,'065',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(87,2,'066',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(88,2,'067',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(89,2,'068',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(90,2,'069',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(91,2,'070',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(92,2,'071',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(93,2,'072',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(94,2,'073',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(95,2,'074',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(96,2,'075',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(97,2,'076',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(98,2,'077',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(99,2,'078',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(100,2,'079',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(101,2,'080',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(102,2,'081',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(103,2,'082',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(104,2,'083',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(105,2,'084',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(106,2,'085',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(107,2,'086',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(108,2,'087',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(109,2,'088',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27'),(110,2,'089',1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-04-10 17:32:27');
/*!40000 ALTER TABLE `habitaciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `habitaciones_bloqueos`
--

DROP TABLE IF EXISTS `habitaciones_bloqueos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `habitaciones_bloqueos` (
  `habitacion_bloqueo_id` int(11) NOT NULL AUTO_INCREMENT,
  `habitacion_id` smallint(6) NOT NULL,
  `tipo_bloqueo_id` smallint(6) NOT NULL,
  `fecha_desde` date NOT NULL,
  `fecha_hasta` date NOT NULL,
  `Observaciones` varchar(1000) DEFAULT NULL,
  `reserva_id` int(11) DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` datetime NOT NULL,
  PRIMARY KEY (`habitacion_bloqueo_id`),
  KEY `IX_habitacion_id` (`habitacion_id`),
  KEY `IX_tipo_bloqueo` (`tipo_bloqueo_id`),
  CONSTRAINT `FK_habitacion_id` FOREIGN KEY (`habitacion_id`) REFERENCES `habitaciones` (`habitacion_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `habitaciones_bloqueos`
--

LOCK TABLES `habitaciones_bloqueos` WRITE;
/*!40000 ALTER TABLE `habitaciones_bloqueos` DISABLE KEYS */;
INSERT INTO `habitaciones_bloqueos` VALUES (1,34,1,'2017-03-31','2017-04-20',NULL,10,4,'2017-04-11 15:56:06'),(4,34,1,'2017-04-10','2017-05-01',NULL,14,2,'2017-04-25 12:00:26'),(6,37,1,'2017-05-01','2017-05-10',NULL,18,2,'2017-04-25 12:00:35'),(7,26,1,'2017-04-20','2017-05-01',NULL,10,2,'2017-04-25 12:05:32');
/*!40000 ALTER TABLE `habitaciones_bloqueos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `habitaciones_situacion`
--

DROP TABLE IF EXISTS `habitaciones_situacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `habitaciones_situacion` (
  `situacion_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `situacion` varchar(255) NOT NULL,
  PRIMARY KEY (`situacion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `habitaciones_situacion`
--

LOCK TABLES `habitaciones_situacion` WRITE;
/*!40000 ALTER TABLE `habitaciones_situacion` DISABLE KEYS */;
INSERT INTO `habitaciones_situacion` VALUES (1,'Libre'),(2,'Pendiente Salida'),(3,'Pendiente Entrada'),(4,'Ocupada'),(5,'Bloqueada');
/*!40000 ALTER TABLE `habitaciones_situacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hoteles`
--

DROP TABLE IF EXISTS `hoteles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hoteles`
--

LOCK TABLES `hoteles` WRITE;
/*!40000 ALTER TABLE `hoteles` DISABLE KEYS */;
INSERT INTO `hoteles` VALUES (1,'HOTEL 1',1,1,4,'PM','Urb. Castillo del Águila S/N','Playa Blanca, Yaiza. Lanzarote','35580',35,1,'(+34) 928 518 196','(+34) 928 519 099','4309999','000','5700000','5201004921','2009-12-06','c:/temp/policia/pm/',1914,'35987PLA02','webpm@hdhotels.com','webpm@hdhotels.com','correo','* Precios válidos para reservas individuales exclusivamente, no aplicables a grupos y/o eventos especiales.',NULL,NULL,NULL,'LAS PALMAS',1,'C:\\catanet_net_client\\db_hd_hoteles\\erp\\outbox\\','servicioshd','srvcshd','1','HD','http://hd.dingus-services.com/services/tazzy/convertedbookingservice.asmx',1,3,18,28.860337000000000,-13.815987000000000,500,500,99),(2,'Hotel Playa Bonita',1,2,3,'PCGC','C/ Holanda s/n','Playa del Inglés, San Bartolomé de Tirajana','35100',35,1,'(+34) 928 774 116','(+34) 928 761 152','4309998','000','5700005','5201004921','2009-11-01','c:/temp/policia/pcgc/',1013,'35552AAABU','webpcgc@hdhotels.com','webpcgc@hdhotels.com','correo','* Precios válidos para reservas individuales exclusivamente, no aplicables a grupos y/o eventos especiales.',NULL,NULL,NULL,'LAS PALMAS',1779,'C:\\catanet_net_client\\db_hd_hoteles\\erp\\outbox\\','servicioshd','srvcshd','2','PCGC','http://hd.dingus-services.com/services/tazzy/convertedbookingservice.asmx?wsdl',1,3,17,27.761752352202600,-15.581848025322000,600,200,99),(3,'HOTEL 3',1,2,3,'PCTF','Avda. Rafael Puig Llivina, 7 ',' Playa de las Américas, Arona. Tenerife','38660',39,1,'(+34) 922 790 874','(+34) 922 790 313 ','4309997','000','5700014','5201004921','2010-05-01','c:/temp/policia/pctf/',772,'38001AAA1F','webpctf@hdhotels.com','webctf@hdhotels.com','correo','* Oferta sujeta a un cupo limitado de habitaciones. El precio y las condiciones ofrecidas podrán ser diferentes en cada momento, incluso si solicita las mismas fechas. En caso de modificar reserva, compruebe siempre el nuevo precio aplicado antes de confirmar los cambios.',NULL,NULL,NULL,'TENERIFE',1,'C:\\catanet_net_client\\db_hd_hoteles\\erp\\outbox\\','servicioshd','srvcshd','3','PCTF','http://hd.dingus-services.com/services/tazzy/convertedbookingservice.asmx',1,3,18,28.060273000000000,-16.731324000000000,600,500,99),(4,'HOTEL 4',1,1,4,'BR','Avda Islas Canarias s/n','Costa Teguisa','35509',35,1,'(+34) 928 826 077','(+34) 928 346 043','4309996','000','5700000','5201004921','2010-07-01','c:/temp/policia/beach_resort/',1577,'35697AAH08','webbeachresort@hdhotels.com','webbeachresort@hdhotels.com','correo','* Oferta sujeta a un cupo limitado de habitaciones. El precio y las condiciones ofrecidas podrán ser diferentes en cada momento, incluso si solicita las mismas fechas. En caso de modificar reserva, compruebe siempre el nuevo precio aplicado antes de confirmar los cambios.',NULL,NULL,NULL,'LAS PALMAS',1779,'C:\\catanet_net_client\\db_hd_hoteles\\erp\\outbox\\','servicioshd','srvcshd','4','HDBR','http://hd.dingus-services.com/services/tazzy/convertedbookingservice.asmx',1,3,18,29.002515000000000,-13.482632000000000,550,550,99);
/*!40000 ALTER TABLE `hoteles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `huespedes`
--

DROP TABLE IF EXISTS `huespedes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `huespedes` (
  `huesped_id` int(11) NOT NULL AUTO_INCREMENT,
  `empresa_id` smallint(6) NOT NULL,
  `Nombre` varchar(30) NOT NULL,
  `Apellidos` varchar(50) NOT NULL,
  `tipo_documento_id` varchar(1) DEFAULT NULL,
  `nif` varchar(20) DEFAULT NULL,
  `fecha_documento` date DEFAULT NULL,
  `sexo_id` varchar(1) DEFAULT NULL,
  `direccion` varchar(70) DEFAULT NULL,
  `poblacion` varchar(70) DEFAULT NULL,
  `zip` varchar(10) DEFAULT NULL,
  `nacion_id` smallint(6) DEFAULT NULL,
  `provincia_id` smallint(6) DEFAULT NULL,
  `telefono` varchar(16) DEFAULT NULL,
  `email` varchar(70) DEFAULT NULL,
  `foto1` varchar(100) DEFAULT NULL,
  `foto2` varchar(100) DEFAULT NULL,
  `tarjeta_fidelizacion` varchar(20) DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  `fecha_nacimiento` date DEFAULT NULL,
  PRIMARY KEY (`huesped_id`),
  KEY `FK_huespedes_provincia` (`provincia_id`),
  KEY `IX_huespedes_empresa_id` (`empresa_id`),
  KEY `IX_huespedes_naciones` (`nacion_id`),
  KEY `FK_guest_users` (`user_id`),
  CONSTRAINT `FK_guest_users` FOREIGN KEY (`user_id`) REFERENCES `users` (`UserId`),
  CONSTRAINT `FK_huespedes_empresa_id` FOREIGN KEY (`empresa_id`) REFERENCES `empresas` (`empresa_id`),
  CONSTRAINT `FK_huespedes_nacion` FOREIGN KEY (`nacion_id`) REFERENCES `naciones` (`nacion_id`),
  CONSTRAINT `FK_huespedes_provincia` FOREIGN KEY (`provincia_id`) REFERENCES `provincias` (`provincia_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `huespedes`
--

LOCK TABLES `huespedes` WRITE;
/*!40000 ALTER TABLE `huespedes` DISABLE KEYS */;
INSERT INTO `huespedes` VALUES (1,1,'Javier','Nuñez Casanovass','D','12345678',NULL,'M',NULL,NULL,NULL,22,NULL,NULL,NULL,NULL,NULL,NULL,1,'2017-05-04 12:08:03','1963-05-25'),(2,1,'Pedro','Cruz Perez','P','42809943C','1963-05-05','M','direcc','poblax','12345',1,35,NULL,NULL,NULL,NULL,NULL,1,'2017-05-03 12:13:51','2007-05-05'),(10,1,'Pepi','Apellido','D','123456','2000-09-09','F','Su casa','su poblacion','12345',3,NULL,NULL,NULL,NULL,NULL,NULL,1,'2017-05-03 12:14:26','1980-09-09'),(11,1,'Maria','Nuñez Talavera','D','1234567',NULL,'F',NULL,NULL,NULL,27,NULL,NULL,NULL,NULL,NULL,NULL,1,'2017-05-04 12:08:15','2016-02-22');
/*!40000 ALTER TABLE `huespedes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `impuestos`
--

DROP TABLE IF EXISTS `impuestos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `impuestos` (
  `impuesto_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `empresa_id` smallint(6) NOT NULL,
  `impuesto` varchar(15) NOT NULL,
  `porcentaje` float NOT NULL,
  `activo_geshotel` bit(1) NOT NULL DEFAULT b'0',
  `cta_contable` varchar(16) NOT NULL,
  `dpto_contable` varchar(5) DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` date DEFAULT NULL,
  PRIMARY KEY (`impuesto_id`),
  KEY `empresa_id` (`empresa_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `impuestos`
--

LOCK TABLES `impuestos` WRITE;
/*!40000 ALTER TABLE `impuestos` DISABLE KEYS */;
INSERT INTO `impuestos` VALUES (1,1,'Exento',0,'\0','4777000','000',NULL,NULL),(2,1,'IGIC 7%',7,'\0','4777000','000',NULL,NULL),(3,2,'IGIC 7%',7,'\0','4777000','000',NULL,NULL);
/*!40000 ALTER TABLE `impuestos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `languages`
--

DROP TABLE IF EXISTS `languages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `languages` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `LanguageId` varchar(10) NOT NULL,
  `LanguageName` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `languages`
--

LOCK TABLES `languages` WRITE;
/*!40000 ALTER TABLE `languages` DISABLE KEYS */;
INSERT INTO `languages` VALUES (1,'es','Español'),(2,'en','English'),(3,'fr','Français'),(4,'de','Deutsch'),(5,'nl','Nederlands'),(6,'da','Dansk'),(7,'pt','Português'),(8,'sw','Swenska'),(9,'it','Italiano'),(10,'ru','Russian'),(11,'zh-CN','Chinese (Simplified)'),(12,'no','Norsk'),(13,'fi','Päät'),(14,'ro','Românesc'),(15,'lb','Lëtzebuerger'),(16,'el','Greek'),(17,'po','Polska'),(18,'ro','Românesc'),(19,'jp','Japanesse');
/*!40000 ALTER TABLE `languages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lineas_anticipo`
--

DROP TABLE IF EXISTS `lineas_anticipo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lineas_anticipo` (
  `linea_anticipo_id` int(11) NOT NULL AUTO_INCREMENT,
  `anticipo_id` int(11) NOT NULL,
  `factura_id` int(11) DEFAULT NULL,
  `importe` decimal(12,2) NOT NULL,
  `fecha_contabilizacion` datetime DEFAULT NULL,
  `estado` smallint(6) DEFAULT '0',
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`linea_anticipo_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lineas_anticipo`
--

LOCK TABLES `lineas_anticipo` WRITE;
/*!40000 ALTER TABLE `lineas_anticipo` DISABLE KEYS */;
/*!40000 ALTER TABLE `lineas_anticipo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lineas_cobro`
--

DROP TABLE IF EXISTS `lineas_cobro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lineas_cobro` (
  `linea_cobro_id` int(11) NOT NULL AUTO_INCREMENT,
  `cobro_id` int(11) NOT NULL,
  `factura_id` int(11) DEFAULT NULL,
  `importe` decimal(12,2) NOT NULL,
  PRIMARY KEY (`linea_cobro_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lineas_cobro`
--

LOCK TABLES `lineas_cobro` WRITE;
/*!40000 ALTER TABLE `lineas_cobro` DISABLE KEYS */;
/*!40000 ALTER TABLE `lineas_cobro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lineas_de_contrato`
--

DROP TABLE IF EXISTS `lineas_de_contrato`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
  `n` smallint(2) DEFAULT NULL,
  `m` decimal(10,2) DEFAULT NULL,
  `tipo_oferta_id` smallint(2) DEFAULT NULL,
  `ambito_oferta_id` smallint(2) DEFAULT NULL,
  `pag_factura` smallint(6) DEFAULT '1',
  `user_id` int(6) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`linea_contrato_id`),
  KEY `unidad_calculo_id` (`unidad_calculo_id`),
  KEY `servicio_id` (`servicio_id`),
  KEY `lineas_de_contrato_1` (`contrato_id`),
  KEY `contrato_id` (`contrato_id`,`servicio_id`),
  CONSTRAINT `FK_lineas_contrato_contrato` FOREIGN KEY (`contrato_id`) REFERENCES `contratos` (`contrato_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lineas_de_contrato`
--

LOCK TABLES `lineas_de_contrato` WRITE;
/*!40000 ALTER TABLE `lineas_de_contrato` DISABLE KEYS */;
INSERT INTO `lineas_de_contrato` VALUES (1,1,NULL,'2017-04-10','2017-12-31',1,6,2,4,50.440,'','','','','','','',NULL,NULL,NULL,NULL,1,4,'2017-04-17 11:56:22'),(2,1,NULL,'2017-04-10','2017-12-31',10,1,2,4,0.000,'','','','','','','',NULL,NULL,NULL,NULL,1,1,'2017-04-10 17:32:25'),(3,2,NULL,'2017-01-01','2017-12-31',10,1,2,4,0.000,'','','','','','','',NULL,NULL,NULL,NULL,1,1,'2017-04-17 12:07:16'),(4,2,NULL,'2017-01-01','2017-12-31',1,6,2,4,25.000,'','','','','','','',NULL,NULL,NULL,NULL,1,1,'2017-04-17 12:07:39'),(5,3,NULL,'2017-01-01','2017-12-31',1,6,2,4,0.000,'','','','','','','',NULL,NULL,NULL,NULL,1,1,'2017-04-11 09:53:29'),(6,3,NULL,'2017-01-01','2017-12-31',10,1,2,4,50.000,'','','','','','','',NULL,NULL,NULL,NULL,1,1,'2017-04-11 09:54:14'),(7,3,NULL,'2017-01-01','2017-12-31',3,6,2,4,20.000,'','','','','','','',NULL,NULL,NULL,NULL,1,1,'2017-04-11 09:55:07'),(8,3,NULL,'2017-01-01','2017-12-31',116,6,2,4,0.000,'','','','','','','',NULL,NULL,NULL,NULL,1,1,'2017-04-11 09:55:45'),(9,3,NULL,'2017-01-01','2017-12-31',4,6,2,4,30.000,'','','','','','','',NULL,NULL,NULL,NULL,1,1,'2017-04-11 09:56:32'),(10,3,NULL,'2017-01-01','2017-12-31',6,6,2,4,25.000,'','','','','','','',NULL,NULL,NULL,NULL,1,4,'2017-04-16 18:10:11'),(11,3,NULL,'2017-01-01','2017-12-31',11,1,2,4,0.000,'','','','','','','',NULL,NULL,NULL,NULL,1,4,'2017-04-16 17:57:58'),(12,3,NULL,'2017-01-01','2017-12-31',7,1,2,4,0.000,'','','','','','','',NULL,NULL,NULL,NULL,1,4,'2017-04-12 08:53:02'),(13,1,NULL,'2017-01-01','2017-12-31',2,6,2,4,10.000,'','','','','','','',NULL,NULL,NULL,NULL,1,1,'2017-04-25 19:57:06'),(14,1,NULL,'2017-01-01','2017-01-01',3,6,2,4,20.000,'','','','','','','',NULL,NULL,NULL,NULL,1,1,'2017-04-25 20:01:07'),(15,1,NULL,'2017-01-01','2017-12-31',4,6,2,4,30.000,'','','','','','','',NULL,NULL,NULL,NULL,1,1,'2017-04-25 20:01:36'),(16,3,NULL,'2017-01-01','2017-12-31',3,6,2,4,10.000,'','','','','','','',NULL,NULL,NULL,NULL,1,1,'2017-04-27 17:50:04'),(17,3,NULL,'2017-01-01','2017-12-31',42,1,2,4,3.000,'','','','','','','',NULL,NULL,NULL,NULL,1,1,'2017-05-01 17:29:56'),(18,3,NULL,'2017-01-01','2017-12-31',49,1,2,4,1.000,'','','','','','','',NULL,NULL,NULL,NULL,1,1,'2017-05-01 17:31:06');
/*!40000 ALTER TABLE `lineas_de_contrato` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lineas_factura`
--

DROP TABLE IF EXISTS `lineas_factura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lineas_factura` (
  `linea_factura_id` int(11) NOT NULL AUTO_INCREMENT,
  `hotel_id` smallint(6) NOT NULL,
  `fecha` date NOT NULL,
  `factura_id` int(11) DEFAULT NULL,
  `reserva_id` int(11) DEFAULT NULL,
  `contrato_id` int(11) DEFAULT NULL,
  `descripcion` varchar(50) NOT NULL,
  `cantidad` decimal(5,2) NOT NULL,
  `precio` decimal(15,3) NOT NULL,
  `impuesto_id` smallint(6) NOT NULL,
  `porc_impuesto` decimal(5,2) NOT NULL,
  `servicio_id` int(11) NOT NULL,
  `unidad_calculo_id` smallint(6) NOT NULL,
  `tipo_linea_factura` varchar(1) NOT NULL,
  `precio_produccion` decimal(15,3) DEFAULT NULL,
  `pag_factura` smallint(6) NOT NULL DEFAULT '1',
  `costo` decimal(10,2) DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  `sw_ajuste` tinyint(1) NOT NULL DEFAULT '0',
  `reserva_servicio_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`linea_factura_id`),
  KEY `hotel_id` (`hotel_id`),
  KEY `fecha` (`fecha`),
  KEY `factura_id` (`factura_id`),
  KEY `reserva_id` (`reserva_id`),
  KEY `servicio_id` (`servicio_id`),
  KEY `reserva_servicio_id` (`reserva_servicio_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lineas_factura`
--

LOCK TABLES `lineas_factura` WRITE;
/*!40000 ALTER TABLE `lineas_factura` DISABLE KEYS */;
/*!40000 ALTER TABLE `lineas_factura` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lineas_ticket`
--

DROP TABLE IF EXISTS `lineas_ticket`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lineas_ticket` (
  `linea_ticket_id` int(11) NOT NULL AUTO_INCREMENT,
  `tikect_id` int(11) NOT NULL,
  `servicio_id` smallint(6) NOT NULL,
  `unidad_calculo_id` smallint(6) NOT NULL,
  `cantidad` decimal(6,2) NOT NULL,
  `contrato_id` int(11) DEFAULT NULL,
  `descripcion` varchar(50) DEFAULT NULL,
  `precio` decimal(15,2) DEFAULT NULL,
  `impuesto_id` smallint(6) DEFAULT NULL,
  `porc_impuesto` decimal(5,2) DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`linea_ticket_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lineas_ticket`
--

LOCK TABLES `lineas_ticket` WRITE;
/*!40000 ALTER TABLE `lineas_ticket` DISABLE KEYS */;
/*!40000 ALTER TABLE `lineas_ticket` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `meetingagendarelevant`
--

DROP TABLE IF EXISTS `meetingagendarelevant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `meetingagendarelevant` (
  `AgendaRelevantId` int(11) NOT NULL AUTO_INCREMENT,
  `AgendaId` int(11) NOT NULL,
  `ContactId` int(11) NOT NULL,
  PRIMARY KEY (`AgendaRelevantId`),
  KEY `FK_AgendaRel_AgendaId` (`AgendaId`),
  KEY `FK_AgendaRel_ContactId` (`ContactId`),
  CONSTRAINT `FK_AgendaRel_AgendaId` FOREIGN KEY (`AgendaId`) REFERENCES `meetingagendas` (`AgendaId`),
  CONSTRAINT `FK_AgendaRel_ContactId` FOREIGN KEY (`ContactId`) REFERENCES `contacts` (`ContactId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `meetingagendarelevant`
--

LOCK TABLES `meetingagendarelevant` WRITE;
/*!40000 ALTER TABLE `meetingagendarelevant` DISABLE KEYS */;
/*!40000 ALTER TABLE `meetingagendarelevant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `meetingagendas`
--

DROP TABLE IF EXISTS `meetingagendas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `meetingagendas` (
  `AgendaId` int(11) NOT NULL AUTO_INCREMENT,
  `MeetingId` int(11) NOT NULL,
  `AgendaNumber` int(11) NOT NULL,
  `Title` varchar(2000) DEFAULT NULL,
  `Description` longtext,
  `AgendaTypeId` int(11) NOT NULL,
  `RequestedByContactId` int(11) DEFAULT NULL,
  `Images` longtext,
  `Attachments` longtext,
  PRIMARY KEY (`AgendaId`),
  KEY `FK_MeetAgendas_MeetingId` (`MeetingId`),
  KEY `FK_MeetAgendas_AgendaTypeId` (`AgendaTypeId`),
  KEY `FK_MeetAgendas_RequestedBy` (`RequestedByContactId`),
  CONSTRAINT `FK_MeetAgendas_AgendaTypeId` FOREIGN KEY (`AgendaTypeId`) REFERENCES `meetingagendatypes` (`AgendaTypeId`),
  CONSTRAINT `FK_MeetAgendas_MeetingId` FOREIGN KEY (`MeetingId`) REFERENCES `meetings` (`MeetingId`),
  CONSTRAINT `FK_MeetAgendas_RequestedBy` FOREIGN KEY (`RequestedByContactId`) REFERENCES `contacts` (`ContactId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `meetingagendas`
--

LOCK TABLES `meetingagendas` WRITE;
/*!40000 ALTER TABLE `meetingagendas` DISABLE KEYS */;
/*!40000 ALTER TABLE `meetingagendas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `meetingagendatypes`
--

DROP TABLE IF EXISTS `meetingagendatypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `meetingagendatypes` (
  `AgendaTypeId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  PRIMARY KEY (`AgendaTypeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `meetingagendatypes`
--

LOCK TABLES `meetingagendatypes` WRITE;
/*!40000 ALTER TABLE `meetingagendatypes` DISABLE KEYS */;
/*!40000 ALTER TABLE `meetingagendatypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `meetingattendees`
--

DROP TABLE IF EXISTS `meetingattendees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `meetingattendees` (
  `AttendeeId` int(11) NOT NULL AUTO_INCREMENT,
  `MeetingId` int(11) NOT NULL,
  `ContactId` int(11) NOT NULL,
  `AttendeeType` int(11) NOT NULL,
  `AttendanceStatus` int(11) NOT NULL,
  PRIMARY KEY (`AttendeeId`),
  KEY `FK_MeetAttendees_MeetingId` (`MeetingId`),
  KEY `FK_MeetAttendees_ContactId` (`ContactId`),
  CONSTRAINT `FK_MeetAttendees_ContactId` FOREIGN KEY (`ContactId`) REFERENCES `contacts` (`ContactId`),
  CONSTRAINT `FK_MeetAttendees_MeetingId` FOREIGN KEY (`MeetingId`) REFERENCES `meetings` (`MeetingId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `meetingattendees`
--

LOCK TABLES `meetingattendees` WRITE;
/*!40000 ALTER TABLE `meetingattendees` DISABLE KEYS */;
/*!40000 ALTER TABLE `meetingattendees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `meetingdecisionrelevant`
--

DROP TABLE IF EXISTS `meetingdecisionrelevant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `meetingdecisionrelevant` (
  `DecisionRelevantId` int(11) NOT NULL AUTO_INCREMENT,
  `DecisionId` int(11) NOT NULL,
  `ContactId` int(11) NOT NULL,
  PRIMARY KEY (`DecisionRelevantId`),
  KEY `FK_DecisionRel_DecisionId` (`DecisionId`),
  KEY `FK_DecisionRel_ContactId` (`ContactId`),
  CONSTRAINT `FK_DecisionRel_ContactId` FOREIGN KEY (`ContactId`) REFERENCES `contacts` (`ContactId`),
  CONSTRAINT `FK_DecisionRel_DecisionId` FOREIGN KEY (`DecisionId`) REFERENCES `meetingdecisions` (`DecisionId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `meetingdecisionrelevant`
--

LOCK TABLES `meetingdecisionrelevant` WRITE;
/*!40000 ALTER TABLE `meetingdecisionrelevant` DISABLE KEYS */;
/*!40000 ALTER TABLE `meetingdecisionrelevant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `meetingdecisions`
--

DROP TABLE IF EXISTS `meetingdecisions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `meetingdecisions` (
  `DecisionId` int(11) NOT NULL AUTO_INCREMENT,
  `MeetingId` int(11) NOT NULL,
  `AgendaId` int(11) NOT NULL,
  `Description` longtext,
  `DecisionNumber` int(11) NOT NULL,
  `ResponsibleContactId` int(11) DEFAULT NULL,
  `DueDate` datetime DEFAULT NULL,
  `ResolutionStatus` int(11) NOT NULL,
  `Images` longtext,
  `Attachments` longtext,
  PRIMARY KEY (`DecisionId`),
  KEY `FK_MeetDecisions_MeetingId` (`MeetingId`),
  KEY `FK_MeetDecisions_AgendaId` (`AgendaId`),
  KEY `FK_MeetDecisions_AgendaType` (`DecisionNumber`),
  KEY `FK_MeetDecisions_RequestedBy` (`ResponsibleContactId`),
  CONSTRAINT `FK_MeetDecisions_AgendaId` FOREIGN KEY (`AgendaId`) REFERENCES `meetingagendas` (`AgendaId`),
  CONSTRAINT `FK_MeetDecisions_AgendaType` FOREIGN KEY (`DecisionNumber`) REFERENCES `meetingagendatypes` (`AgendaTypeId`),
  CONSTRAINT `FK_MeetDecisions_MeetingId` FOREIGN KEY (`MeetingId`) REFERENCES `meetings` (`MeetingId`),
  CONSTRAINT `FK_MeetDecisions_RequestedBy` FOREIGN KEY (`ResponsibleContactId`) REFERENCES `contacts` (`ContactId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `meetingdecisions`
--

LOCK TABLES `meetingdecisions` WRITE;
/*!40000 ALTER TABLE `meetingdecisions` DISABLE KEYS */;
/*!40000 ALTER TABLE `meetingdecisions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `meetinglocations`
--

DROP TABLE IF EXISTS `meetinglocations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `meetinglocations` (
  `LocationId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `Address` varchar(300) DEFAULT NULL,
  `Latitude` double NOT NULL,
  `Longitude` double NOT NULL,
  PRIMARY KEY (`LocationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `meetinglocations`
--

LOCK TABLES `meetinglocations` WRITE;
/*!40000 ALTER TABLE `meetinglocations` DISABLE KEYS */;
/*!40000 ALTER TABLE `meetinglocations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `meetings`
--

DROP TABLE IF EXISTS `meetings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `meetings` (
  `MeetingId` int(11) NOT NULL AUTO_INCREMENT,
  `MeetingName` varchar(100) NOT NULL,
  `MeetingNumber` varchar(20) DEFAULT NULL,
  `MeetingGuid` varchar(40) NOT NULL,
  `MeetingTypeId` int(11) NOT NULL,
  `StartDate` datetime NOT NULL,
  `EndDate` datetime NOT NULL,
  `LocationId` int(11) DEFAULT NULL,
  `UnitId` int(11) DEFAULT NULL,
  `OrganizerContactId` int(11) DEFAULT NULL,
  `ReporterContactId` int(11) DEFAULT NULL,
  `InsertUserId` int(11) NOT NULL,
  `InsertDate` datetime NOT NULL,
  `UpdateUserId` int(11) DEFAULT NULL,
  `UpdateDate` datetime DEFAULT NULL,
  PRIMARY KEY (`MeetingId`),
  KEY `FK_Meetings_TypeId` (`MeetingTypeId`),
  KEY `FK_Meetings_LocationId` (`LocationId`),
  KEY `FK_Meetings_UnitId` (`UnitId`),
  KEY `FK_Meetings_Organizer` (`OrganizerContactId`),
  KEY `FK_Meetings_Reporter` (`ReporterContactId`),
  CONSTRAINT `FK_Meetings_LocationId` FOREIGN KEY (`LocationId`) REFERENCES `meetinglocations` (`LocationId`),
  CONSTRAINT `FK_Meetings_Organizer` FOREIGN KEY (`OrganizerContactId`) REFERENCES `contacts` (`ContactId`),
  CONSTRAINT `FK_Meetings_Reporter` FOREIGN KEY (`ReporterContactId`) REFERENCES `contacts` (`ContactId`),
  CONSTRAINT `FK_Meetings_TypeId` FOREIGN KEY (`MeetingTypeId`) REFERENCES `meetingtypes` (`MeetingTypeId`),
  CONSTRAINT `FK_Meetings_UnitId` FOREIGN KEY (`UnitId`) REFERENCES `businessunits` (`UnitId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `meetings`
--

LOCK TABLES `meetings` WRITE;
/*!40000 ALTER TABLE `meetings` DISABLE KEYS */;
/*!40000 ALTER TABLE `meetings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `meetingtypes`
--

DROP TABLE IF EXISTS `meetingtypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `meetingtypes` (
  `MeetingTypeId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  PRIMARY KEY (`MeetingTypeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `meetingtypes`
--

LOCK TABLES `meetingtypes` WRITE;
/*!40000 ALTER TABLE `meetingtypes` DISABLE KEYS */;
/*!40000 ALTER TABLE `meetingtypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mercados`
--

DROP TABLE IF EXISTS `mercados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mercados` (
  `mercado_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `mercado` varchar(25) NOT NULL,
  `hotel_id` smallint(6) NOT NULL,
  PRIMARY KEY (`mercado_id`,`hotel_id`),
  KEY `IX_mercados_hotel_id` (`hotel_id`),
  CONSTRAINT `FK_mercados_hoteles_hotel_id` FOREIGN KEY (`hotel_id`) REFERENCES `hoteles` (`hotel_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mercados`
--

LOCK TABLES `mercados` WRITE;
/*!40000 ALTER TABLE `mercados` DISABLE KEYS */;
/*!40000 ALTER TABLE `mercados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modo_descuento`
--

DROP TABLE IF EXISTS `modo_descuento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `modo_descuento` (
  `tipo` varchar(1) NOT NULL,
  `descripcion` varchar(15) NOT NULL,
  PRIMARY KEY (`tipo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modo_descuento`
--

LOCK TABLES `modo_descuento` WRITE;
/*!40000 ALTER TABLE `modo_descuento` DISABLE KEYS */;
INSERT INTO `modo_descuento` VALUES ('A','Automatico'),('M','Manual');
/*!40000 ALTER TABLE `modo_descuento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `monedas`
--

DROP TABLE IF EXISTS `monedas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `monedas` (
  `moneda_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(20) NOT NULL,
  `desc_corta` varchar(10) NOT NULL,
  `cambio` float DEFAULT NULL,
  PRIMARY KEY (`moneda_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `monedas`
--

LOCK TABLES `monedas` WRITE;
/*!40000 ALTER TABLE `monedas` DISABLE KEYS */;
INSERT INTO `monedas` VALUES (1,'EURO','€',1),(2,'US DOLAR','$',1.06),(3,'LIBRA ESTERLINA','£',0.88),(4,'CORONA SUECA','Kr',NULL),(5,'FRANCO SUIZO','CHK',NULL),(6,'CORONA CHECA','CZK',NULL),(7,'RUBLO','RU',NULL),(8,'YEN','YEN',NULL),(9,'YUAN','YU',NULL);
/*!40000 ALTER TABLE `monedas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movimientos_caja`
--

DROP TABLE IF EXISTS `movimientos_caja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `movimientos_caja` (
  `movimiento_id` int(11) NOT NULL AUTO_INCREMENT,
  `tipo_movimiento_id` smallint(6) NOT NULL,
  `fecha` datetime NOT NULL,
  `caja_id` smallint(6) NOT NULL,
  `descripcion` varchar(30) DEFAULT NULL,
  `importe` decimal(12,2) NOT NULL,
  `item_id` int(11) DEFAULT NULL,
  `forma_pago_id` smallint(6) DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`movimiento_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movimientos_caja`
--

LOCK TABLES `movimientos_caja` WRITE;
/*!40000 ALTER TABLE `movimientos_caja` DISABLE KEYS */;
/*!40000 ALTER TABLE `movimientos_caja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `naciones`
--

DROP TABLE IF EXISTS `naciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `naciones`
--

LOCK TABLES `naciones` WRITE;
/*!40000 ALTER TABLE `naciones` DISABLE KEYS */;
INSERT INTO `naciones` VALUES (1,'ESPAÑA','ESP',1,1,1,NULL,1,'España','ES'),(2,'HOLANDA','HOL',1,5,NULL,'NLD',0,'Nederland','EN'),(3,'ALEMANIA','ALE',1,4,2,'DEU',0,'Deutschland','DE'),(4,'REINO UNIDO','UK',3,2,NULL,'GBR',0,'UK','EN'),(5,'SUECIA','SWE',4,8,NULL,'SWE',0,'Sverige','EN'),(6,'NORUEGA','NOR',4,12,NULL,'NOR',0,'Norge','EN'),(7,'FINLANDIA','FIN',1,13,NULL,'FIN',0,'Suomi','EN'),(8,'FRANCIA','FRA',1,3,NULL,'FRA',0,'France','EN'),(9,'ITALIA','IT',1,9,NULL,'ITA',0,'Italia','EN'),(11,'CANADA','CAN',2,2,NULL,'CAN',0,'Canada','EN'),(12,'DINAMARCA','DEN',1,6,NULL,'DNK',0,'Danmark','EN'),(13,'BELGICA','BEL',1,5,4,'BEL',0,'België/Belgique','EN'),(14,'IRLANDA','IRL',1,2,NULL,'IRL',0,'Éire','EN'),(15,'RUMANIA','RUM',1,14,NULL,'ROU',0,'România','EN'),(16,'PORTUGAL','POR',1,7,NULL,'PRT',0,'Portugal','EN'),(17,'SUIZA','SUI',5,3,NULL,'CHE',0,'Schweiz','EN'),(18,'LUXEMBURGO','LUX',1,15,NULL,'LUX',0,'Luxemburg','EN'),(19,'GRECIA','GRE',1,16,NULL,'GRC',0,'Greece','EN'),(20,'RESTO DE EUROPA','RESTE',1,2,NULL,NULL,0,'Other','EN'),(21,'POLONIA','POL',1,1,NULL,'POL',0,'Polska','EN'),(22,'AUSTRIA','AUT',1,4,3,'AUT',0,'Österreich','EN'),(23,'REPUBLICA CHECA','CZEC',1,4,NULL,'CZE',0,'Cesko ','EN'),(25,'RUSIA','RUS',7,10,NULL,'RUS',0,'Russia','EN'),(27,'ESTADOS UNIDOS','USA',2,2,NULL,'USA',0,'United States','EN'),(28,'JAPON','JPN',8,19,NULL,'JPN',0,'Japan','EN'),(29,'CHINA','CHN',9,11,NULL,'CHN',0,'China','EN'),(30,'ISLANDIA','ISL',1,2,NULL,'ISL',0,'Ísland','EN');
/*!40000 ALTER TABLE `naciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ofertas`
--

DROP TABLE IF EXISTS `ofertas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
  `m` decimal(10,2) DEFAULT '0.00',
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
  KEY `ofertas_ibfk_12` (`ambito_oferta_id`),
  KEY `ofertas_ibfk_7` (`tipo_servicio_id`),
  KEY `ofertas_ibfk_9` (`unidad_calculo_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ofertas`
--

LOCK TABLES `ofertas` WRITE;
/*!40000 ALTER TABLE `ofertas` DISABLE KEYS */;
INSERT INTO `ofertas` VALUES (1,'Niños 50%',3,'2017-01-01','2017-12-31','E','','2017-01-01','2017-12-31',NULL,NULL,NULL,NULL,NULL,3,NULL,NULL,NULL,1,2,50.00,1,4,'2017-04-15 20:28:17','',4,1),(2,'Niños Free',3,'2017-01-01','2017-12-31','E','','2017-01-01','2017-12-31',NULL,NULL,NULL,NULL,NULL,4,NULL,NULL,NULL,1,2,100.00,1,1,'2017-04-11 10:02:17','',4,1),(3,'Bebes',3,'2017-01-01','2017-12-31','E','','2017-01-01','2017-12-31',NULL,NULL,NULL,NULL,NULL,5,NULL,NULL,NULL,1,2,100.00,1,4,'2017-04-15 20:27:46','',4,1),(4,'7x6 Caja de seguridad',3,'2017-01-01','2017-12-31','E','',NULL,NULL,NULL,NULL,NULL,4,42,1,NULL,NULL,NULL,7,1,6.00,1,1,'2017-05-01 17:32:47','',4,1);
/*!40000 ALTER TABLE `ofertas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ofertas_codigos`
--

DROP TABLE IF EXISTS `ofertas_codigos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ofertas_codigos` (
  `oferta_codigo_id` int(11) NOT NULL AUTO_INCREMENT,
  `oferta_id` int(11) NOT NULL,
  `codigo_oferta` varchar(20) NOT NULL,
  PRIMARY KEY (`oferta_codigo_id`),
  UNIQUE KEY `IX_ofertas_codigos` (`oferta_id`,`codigo_oferta`),
  KEY `IX_ofertas_codigos_oferta_id` (`oferta_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ofertas_codigos`
--

LOCK TABLES `ofertas_codigos` WRITE;
/*!40000 ALTER TABLE `ofertas_codigos` DISABLE KEYS */;
/*!40000 ALTER TABLE `ofertas_codigos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ofertas_rejillas`
--

DROP TABLE IF EXISTS `ofertas_rejillas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ofertas_rejillas`
--

LOCK TABLES `ofertas_rejillas` WRITE;
/*!40000 ALTER TABLE `ofertas_rejillas` DISABLE KEYS */;
/*!40000 ALTER TABLE `ofertas_rejillas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ofertas_servicios`
--

DROP TABLE IF EXISTS `ofertas_servicios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ofertas_servicios`
--

LOCK TABLES `ofertas_servicios` WRITE;
/*!40000 ALTER TABLE `ofertas_servicios` DISABLE KEYS */;
/*!40000 ALTER TABLE `ofertas_servicios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `preview_servicios`
--

DROP TABLE IF EXISTS `preview_servicios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `preview_servicios` (
  `preview_servicios_id` int(11) NOT NULL AUTO_INCREMENT,
  `reserva_id` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `servicio_id` int(11) NOT NULL,
  `importe` decimal(7,2) DEFAULT NULL,
  `descripcion` varchar(40) DEFAULT NULL,
  `error` int(11) NOT NULL DEFAULT '0',
  `desc_oferta` varchar(20) DEFAULT NULL,
  `desc_uc` varchar(20) DEFAULT NULL,
  `desc_uc_reserva` varchar(20) DEFAULT NULL,
  `cantidad` decimal(5,2) DEFAULT NULL,
  `precio_producciom` decimal(7,2) DEFAULT NULL,
  PRIMARY KEY (`preview_servicios_id`),
  UNIQUE KEY `IX_preview_servicios` (`reserva_id`,`fecha`,`servicio_id`),
  KEY `IX_reserva_id` (`reserva_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `preview_servicios`
--

LOCK TABLES `preview_servicios` WRITE;
/*!40000 ALTER TABLE `preview_servicios` DISABLE KEYS */;
/*!40000 ALTER TABLE `preview_servicios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `provincias`
--

DROP TABLE IF EXISTS `provincias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `provincias`
--

LOCK TABLES `provincias` WRITE;
/*!40000 ALTER TABLE `provincias` DISABLE KEYS */;
INSERT INTO `provincias` VALUES (1,'Álava ',16,1,'ES211',0),(2,'Albacete',8,1,'ES421',0),(3,'Alicante ',10,1,'ES521',0),(4,'Almería ',1,1,'ES611',0),(5,'Asturias ',3,1,'ES120',0),(6,'Ávila ',7,1,'ES411',0),(7,'Badajoz ',11,1,'ES431',0),(8,'Palma de Mallorca ',4,1,'ES532',0),(9,'Barcelona ',9,1,'ES511',0),(10,'Burgos ',7,1,'ES412',0),(11,'Cáceres ',11,1,'ES432',0),(12,'Cádiz ',1,1,'ES612',0),(13,'Cantabria ',6,1,'ES130',0),(14,'Castellón ',10,1,'ES522',0),(15,'Ciudad Real ',8,1,'ES422',0),(16,'Córdoba ',1,1,'ES613',0),(17,'La Coruña ',12,1,'ES111',0),(18,'Cuenca ',8,1,'ES423',0),(19,'Gerona ',9,1,'ES512',0),(20,'Granada ',1,1,'ES614',0),(21,'Guadalajara ',8,1,'ES424',0),(22,'Guipúzcoa ',16,1,'ES212',0),(23,'Huelva ',1,1,'ES615',0),(24,'Huesca ',2,1,'ES241',0),(25,'Jaén ',1,1,'ES616',0),(26,'León ',7,1,'ES413',0),(27,'Lérida ',9,1,'ES513',0),(28,'Lugo ',12,1,'ES112',0),(29,'Madrid ',13,1,'ES300',0),(30,'Málaga ',1,1,'ES617',0),(31,'Murcia ',14,1,'ES620',0),(32,'Navarra ',15,1,'ES220',0),(33,'Orense ',12,1,'ES113',0),(34,'Palencia ',7,1,'ES414',0),(35,'Las Palmas',5,1,'ES701',1),(36,'Pontevedra ',12,1,'ES114',0),(37,'Logroño',17,1,'ES230',0),(38,'Salamanca ',7,1,'ES415',0),(39,'Santa Cruz de Tenerife ',5,1,'ES702',0),(40,'Segovia ',7,1,'ES416',0),(41,'Sevilla ',1,1,'ES618',0),(42,'Soria ',7,1,'ES417',0),(43,'Tarragona ',9,1,'ES514',0),(44,'Teruel ',2,1,'ES242',0),(45,'Toledo ',8,1,'ES425',0),(46,'Valencia ',10,1,'ES523',0),(47,'Valladolid ',7,1,'ES418',0),(48,'Vizcaya ',16,1,'ES213',0),(49,'Zamora ',7,1,'ES419',0),(50,'Zaragoza ',2,1,'ES243',0),(51,'Ceuta',18,1,'ES630',0),(52,'Melilla',18,1,'ES640',0),(53,'N/A',NULL,20,NULL,0);
/*!40000 ALTER TABLE `provincias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `releases`
--

DROP TABLE IF EXISTS `releases`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `releases` (
  `release_id` int(11) NOT NULL AUTO_INCREMENT,
  `cliente_id` int(11) NOT NULL,
  `hotel_id` smallint(6) NOT NULL,
  `fecha_desde` date NOT NULL,
  `fecha_hasta` date NOT NULL,
  `observaciones` varchar(100) DEFAULT NULL,
  `dias` smallint(6) DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` date DEFAULT NULL,
  PRIMARY KEY (`release_id`),
  KEY `FK_releases_cliente_id` (`cliente_id`),
  KEY `FK_releases_hotel_id` (`hotel_id`),
  CONSTRAINT `FK_releases_cliente_id` FOREIGN KEY (`cliente_id`) REFERENCES `clientes` (`cliente_id`),
  CONSTRAINT `FK_releases_hotel_id` FOREIGN KEY (`hotel_id`) REFERENCES `hoteles` (`hotel_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `releases`
--

LOCK TABLES `releases` WRITE;
/*!40000 ALTER TABLE `releases` DISABLE KEYS */;
/*!40000 ALTER TABLE `releases` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reserva_estados`
--

DROP TABLE IF EXISTS `reserva_estados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reserva_estados` (
  `estado_reserva_id` smallint(6) NOT NULL,
  `estado` varchar(20) NOT NULL,
  `es_error_fechaini` smallint(6) NOT NULL,
  `es_error_fechafin` smallint(6) NOT NULL,
  PRIMARY KEY (`estado_reserva_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reserva_estados`
--

LOCK TABLES `reserva_estados` WRITE;
/*!40000 ALTER TABLE `reserva_estados` DISABLE KEYS */;
INSERT INTO `reserva_estados` VALUES (0,'Con Errores',1,1),(1,'Pendiente',1,1),(2,'Anulada',0,0),(3,'Check-in',0,1),(4,'Check-out',1,1),(5,'Facturado',0,0),(6,'No Show',0,0);
/*!40000 ALTER TABLE `reserva_estados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reservas`
--

DROP TABLE IF EXISTS `reservas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reservas` (
  `reserva_id` int(11) NOT NULL AUTO_INCREMENT,
  `fecha_creacion` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `hotel_id` smallint(6) NOT NULL,
  `estado_reserva_id` smallint(6) NOT NULL,
  `cliente_id` int(11) NOT NULL,
  `canal_reserva_id` smallint(6) DEFAULT NULL,
  `cliente_id_factura` int(11) DEFAULT NULL,
  `tipo_habitacion_id` smallint(6) NOT NULL,
  `vip` tinyint(1) NOT NULL DEFAULT '0',
  `pension_id` smallint(6) NOT NULL,
  `adultos` smallint(6) NOT NULL,
  `child_50` smallint(6) NOT NULL DEFAULT '0',
  `child_free` smallint(6) NOT NULL DEFAULT '0',
  `bebes` smallint(6) NOT NULL DEFAULT '0',
  `fecha_reserva` date NOT NULL,
  `nombre_reserva` varchar(100) NOT NULL,
  `fecha_prevista_llegada` datetime NOT NULL,
  `fecha_prevista_salida` datetime NOT NULL,
  `observaciones_llegada` varchar(1000) DEFAULT NULL,
  `observaciones_salida` varchar(1000) DEFAULT NULL,
  `observaciones_cliente` varchar(1000) DEFAULT NULL,
  `observaciones` varchar(1000) DEFAULT NULL,
  `fecha_llegada` date DEFAULT NULL,
  `fecha_salida` date DEFAULT NULL,
  `bono_referencia` varchar(40) NOT NULL,
  `bono_online` varchar(40) DEFAULT NULL,
  `bloquear_tarifa` tinyint(1) NOT NULL DEFAULT '0',
  `permite_devolucion` tinyint(1) NOT NULL DEFAULT '0',
  `tipo_tarjeta_id` smallint(6) DEFAULT NULL,
  `tarjeta_credito` varchar(255) DEFAULT NULL,
  `caducidad` varchar(10) DEFAULT NULL,
  `cod_seguridad` varchar(4) DEFAULT NULL,
  `contrato_ttoo` varchar(30) DEFAULT NULL,
  `codigo_oferta` varchar(30) DEFAULT NULL,
  `valor` decimal(10,2) DEFAULT NULL,
  `valor_validado` decimal(10,2) DEFAULT NULL,
  `fecha_validacion` datetime DEFAULT NULL,
  `usuario_validacion` int(11) DEFAULT NULL,
  `paroventas_check` tinyint(1) DEFAULT NULL,
  `cupos_check` tinyint(1) DEFAULT NULL,
  `release_check` tinyint(1) DEFAULT NULL,
  `reserva_dingus` longtext,
  `dingus_impuestos_incluidos` tinyint(1) DEFAULT NULL,
  `dingus_comision` smallint(6) DEFAULT NULL,
  `reserva_dingus_tipo` smallint(6) DEFAULT NULL,
  `fecha_anulacion` datetime DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`reserva_id`),
  KEY `FK_reservas_hotel_id` (`hotel_id`),
  KEY `FK_reservas_estado_reserva_id` (`estado_reserva_id`),
  KEY `FK_reservas_cliente_id` (`cliente_id`),
  KEY `FK_reservas_canal_reserva_id` (`canal_reserva_id`),
  KEY `FK_reservas_cliente_id_factura` (`cliente_id_factura`),
  KEY `FK_reservas_user_id` (`user_id`),
  CONSTRAINT `FK_reservas_canal_reserva_id` FOREIGN KEY (`canal_reserva_id`) REFERENCES `canales_reserva` (`canal_reserva_id`),
  CONSTRAINT `FK_reservas_cliente_id` FOREIGN KEY (`cliente_id`) REFERENCES `clientes` (`cliente_id`),
  CONSTRAINT `FK_reservas_cliente_id_factura` FOREIGN KEY (`cliente_id_factura`) REFERENCES `clientes` (`cliente_id`),
  CONSTRAINT `FK_reservas_estado_reserva_id` FOREIGN KEY (`estado_reserva_id`) REFERENCES `reserva_estados` (`estado_reserva_id`),
  CONSTRAINT `FK_reservas_hotel_id` FOREIGN KEY (`hotel_id`) REFERENCES `hoteles` (`hotel_id`),
  CONSTRAINT `FK_reservas_user_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservas`
--

LOCK TABLES `reservas` WRITE;
/*!40000 ALTER TABLE `reservas` DISABLE KEYS */;
INSERT INTO `reservas` VALUES (1,'2017-04-10 00:00:00',1,0,2,NULL,NULL,10,0,2,2,1,0,0,'2017-02-01','Prueba 1 Hotel 1','2017-04-25 14:00:00','2017-05-01 14:00:00',NULL,NULL,NULL,NULL,NULL,NULL,'123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,'2017-04-19 15:51:58'),(2,'2017-04-10 00:00:00',1,1,2,NULL,NULL,10,0,2,2,1,0,0,'2017-02-01','Prueba 2 Hotel 1','2017-04-26 16:00:00','2017-05-01 16:00:00',NULL,NULL,NULL,NULL,'2017-04-26','2017-05-01','123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,0.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,0,0,NULL,1,'2017-04-25 19:34:16'),(3,'2017-04-10 17:32:37',1,0,2,NULL,NULL,40,0,4,2,1,0,0,'2017-02-01',' Prueba 3 Hotel 1','2017-04-25 14:00:00','2017-05-01 14:00:00',NULL,NULL,NULL,NULL,NULL,NULL,'123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(4,'2017-04-10 17:32:37',1,0,2,NULL,NULL,40,0,4,2,1,0,0,'2017-02-01',' Prueba 4 Hotel 1','2017-04-25 14:00:00','2017-05-01 14:00:00',NULL,NULL,NULL,NULL,NULL,NULL,'123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(5,'2017-04-10 17:32:37',1,0,2,NULL,NULL,40,0,4,2,1,0,0,'2017-02-01',' Prueba 5 Hotel 1','2017-04-25 14:00:00','2017-05-01 14:00:00',NULL,NULL,NULL,NULL,NULL,NULL,'123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(6,'2017-04-10 17:32:37',1,0,2,NULL,NULL,40,0,4,2,1,0,0,'2017-02-01',' Prueba 6 Hotel 1','2017-04-25 14:00:00','2017-05-01 14:00:00',NULL,NULL,NULL,NULL,NULL,NULL,'123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(7,'2017-04-10 17:32:37',1,0,2,NULL,NULL,40,0,4,2,1,0,0,'2017-02-01',' Prueba 7 Hotel 1','2017-04-25 14:00:00','2017-05-01 14:00:00',NULL,NULL,NULL,NULL,NULL,NULL,'123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(8,'2017-04-10 17:32:37',1,0,2,NULL,NULL,40,0,4,2,1,0,0,'2017-02-01',' Prueba 8 Hotel 1','2017-04-25 14:00:00','2017-05-01 14:00:00',NULL,NULL,NULL,NULL,NULL,NULL,'123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(9,'2017-04-10 00:00:00',1,0,2,NULL,NULL,10,0,2,2,1,0,0,'2017-02-01','Prueba 9 Hotel 1','2017-04-25 14:00:00','2017-05-01 14:00:00',NULL,NULL,NULL,NULL,'2017-04-25','2017-05-01','123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,'2017-04-25 19:26:26'),(10,'2017-04-10 00:00:00',2,3,2,NULL,NULL,10,1,3,1,1,1,1,'2017-02-01','Prueba 10 Hotel 2','2017-03-31 18:00:00','2017-05-01 18:00:00',NULL,NULL,NULL,NULL,'2017-03-31','2017-05-01','123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,2945.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,0,0,'2017-04-11 15:49:39',1,'2017-05-10 09:09:38'),(11,'2017-04-10 00:00:00',2,1,2,NULL,NULL,11,0,3,2,1,1,1,'2017-02-01','Prueba 11 Hotel 2','2017-04-10 14:00:00','2017-05-01 14:00:00',NULL,NULL,NULL,NULL,'2017-04-10','2017-05-01','123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,0.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,0,0,NULL,2,'2017-04-17 14:00:28'),(12,'2017-04-10 00:00:00',2,1,2,NULL,NULL,11,0,3,2,1,1,1,'2017-02-01','Prueba 12 Hotel 2','2017-04-10 14:00:00','2017-05-01 14:00:00',NULL,NULL,NULL,NULL,'2017-04-10','2017-05-01','123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,2362.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,0,0,NULL,1,'2017-04-27 17:08:07'),(13,'2017-04-10 00:00:00',2,1,2,NULL,NULL,11,0,2,2,1,1,1,'2017-02-01','Prueba 13 Hotel 2','2017-04-10 14:00:00','2017-05-01 14:00:00',NULL,NULL,NULL,NULL,'2017-04-10','2017-05-01','123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,0.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,0,0,NULL,2,'2017-04-17 15:23:26'),(14,'2017-04-10 00:00:00',2,1,2,NULL,NULL,11,0,3,2,1,1,1,'2017-02-01','Prueba 14 Hotel 2','2017-04-10 16:00:00','2017-05-01 16:00:00',NULL,NULL,NULL,NULL,'2017-04-10','2017-05-01','123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,2888.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,0,0,NULL,1,'2017-04-30 18:32:22'),(15,'2017-04-10 00:00:00',2,1,2,NULL,NULL,10,0,3,2,1,1,0,'2017-02-01','Prueba 11 Hotel 2','2017-04-01 14:00:00','2017-04-10 14:00:00',NULL,NULL,NULL,NULL,'2017-04-01','2017-04-10','123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,0.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,0,0,NULL,1,'2017-04-27 12:33:30'),(16,'2017-04-10 00:00:00',2,1,2,NULL,NULL,10,0,3,2,1,1,1,'2017-02-01','Prueba 12 Hotel 2','2017-04-01 14:00:00','2017-04-10 14:00:00',NULL,NULL,NULL,NULL,'2017-04-01','2017-04-10','123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,0.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,0,0,NULL,1,'2017-04-25 19:25:08'),(17,'2017-04-10 00:00:00',2,1,2,NULL,NULL,10,0,3,2,1,1,1,'2017-02-01','Prueba 13 Hotel 2','2017-04-01 16:00:00','2017-04-10 16:00:00',NULL,NULL,NULL,NULL,'2017-04-01','2017-04-10','123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,1125.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,0,0,NULL,1,'2017-05-11 08:43:53'),(18,'2017-04-10 00:00:00',2,1,2,NULL,NULL,11,0,3,2,1,1,1,'2017-02-01','Prueba 14 Hotel 2','2017-05-01 16:00:00','2017-05-10 16:00:00',NULL,NULL,NULL,NULL,'2017-05-01','2017-05-10','123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,0.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,0,0,NULL,1,'2017-04-25 19:23:41'),(19,'2017-04-10 00:00:00',2,1,2,NULL,NULL,10,0,3,2,1,1,1,'2017-02-01','Otra prueba mas','2017-04-01 16:00:00','2017-04-10 16:00:00',NULL,NULL,NULL,NULL,'2017-04-01','2017-04-10','123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,1125.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,0,0,NULL,1,'2017-05-10 10:42:04'),(20,'2017-04-10 00:00:00',2,1,2,NULL,NULL,10,0,3,2,1,1,1,'2017-02-01','Prueba 16 Hotel 2','2017-04-01 16:00:00','2017-04-10 16:00:00',NULL,NULL,NULL,NULL,'2017-04-01','2017-04-10','123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,1125.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,0,0,NULL,1,'2017-05-10 10:37:43'),(21,'2017-04-10 00:00:00',2,1,2,NULL,NULL,10,0,116,2,1,1,1,'2017-02-01','Prueba 17 Hotel 2','2017-04-01 14:00:00','2017-04-10 14:00:00',NULL,NULL,NULL,NULL,'2017-04-01','2017-04-10','123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,0.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,0,0,NULL,1,'2017-04-25 19:22:49'),(22,'2017-04-10 00:00:00',2,1,2,NULL,NULL,10,0,116,2,1,1,1,'2017-02-01','Prueba 18 Hotel 2','2017-04-01 14:00:00','2017-04-10 14:00:00',NULL,NULL,NULL,NULL,'2017-04-01','2017-04-10','123456789',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,450.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,0,0,NULL,1,'2017-05-10 09:59:56'),(23,'2017-04-17 00:00:00',2,1,2,NULL,NULL,11,0,116,2,1,0,0,'2017-04-17','Javier Nuñez Casanovas','2017-05-05 18:30:00','2017-05-26 12:00:00',NULL,NULL,NULL,NULL,'2017-05-05','2017-05-26','1234567',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,1312.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,0,0,NULL,1,'2017-05-10 10:45:56'),(24,'2017-04-27 00:00:00',2,1,2,NULL,NULL,11,0,2,2,0,1,0,'2017-04-27','Alejandro Moriana','2017-04-29 03:00:00','2017-05-06 03:00:00',NULL,NULL,NULL,NULL,'2017-04-29','2017-05-06','1111111111',NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,350.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,0,0,NULL,1,'2017-05-01 17:50:21');
/*!40000 ALTER TABLE `reservas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reservas_contratos`
--

DROP TABLE IF EXISTS `reservas_contratos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reservas_contratos` (
  `reserva_contrato_id` int(11) NOT NULL AUTO_INCREMENT,
  `reserva_id` int(11) NOT NULL,
  `contrato_id` int(11) NOT NULL,
  `directo` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`reserva_contrato_id`),
  UNIQUE KEY `IX_reservas_contratos_reserva_id_contrato_id` (`reserva_id`,`contrato_id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservas_contratos`
--

LOCK TABLES `reservas_contratos` WRITE;
/*!40000 ALTER TABLE `reservas_contratos` DISABLE KEYS */;
INSERT INTO `reservas_contratos` VALUES (1,15,3,0),(2,16,3,0),(3,20,3,0),(4,17,3,0),(5,19,3,0),(6,18,3,0),(7,21,3,0),(8,2,1,0),(9,22,3,0),(10,14,3,0),(11,11,3,0),(12,10,3,0),(13,13,3,0),(14,12,3,0),(15,24,3,0),(16,23,3,0);
/*!40000 ALTER TABLE `reservas_contratos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reservas_descuentos`
--

DROP TABLE IF EXISTS `reservas_descuentos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reservas_descuentos` (
  `reserva_descuento_id` int(11) NOT NULL AUTO_INCREMENT,
  `reserva_id` int(11) NOT NULL,
  `servicio_id` int(11) NOT NULL,
  `tipo_descuento_id` smallint(6) NOT NULL,
  `tipo` varchar(1) NOT NULL,
  `descuento` decimal(7,2) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`reserva_descuento_id`),
  KEY `FK_reservas_descuentos_reserva_id` (`reserva_id`),
  KEY `FK_reservas_descuentos_servicio_id` (`servicio_id`),
  KEY `FK_reservas_descuentos_tipo_descuento_id` (`tipo_descuento_id`),
  KEY `FK_reservas_descuentos_tipo_modo_descuento_tipo` (`tipo`),
  CONSTRAINT `FK_reservas_descuentos_reserva_id` FOREIGN KEY (`reserva_id`) REFERENCES `reservas` (`reserva_id`),
  CONSTRAINT `FK_reservas_descuentos_servicio_id` FOREIGN KEY (`servicio_id`) REFERENCES `servicios` (`servicio_id`),
  CONSTRAINT `FK_reservas_descuentos_tipo_descuento_id` FOREIGN KEY (`tipo_descuento_id`) REFERENCES `tipos_descuento` (`tipo_descuento_id`),
  CONSTRAINT `FK_reservas_descuentos_tipo_modo_descuento_tipo` FOREIGN KEY (`tipo`) REFERENCES `modo_descuento` (`tipo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservas_descuentos`
--

LOCK TABLES `reservas_descuentos` WRITE;
/*!40000 ALTER TABLE `reservas_descuentos` DISABLE KEYS */;
/*!40000 ALTER TABLE `reservas_descuentos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reservas_huespedes`
--

DROP TABLE IF EXISTS `reservas_huespedes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reservas_huespedes` (
  `reservas_huespedes_id` int(11) NOT NULL AUTO_INCREMENT,
  `reserva_id` int(11) NOT NULL,
  `huesped_id` int(11) NOT NULL,
  `fecha_llegada` date DEFAULT NULL,
  `fecha_salida` date DEFAULT NULL,
  `habitacion_id` smallint(6) DEFAULT NULL,
  `tipo_huesped_id` smallint(6) DEFAULT NULL,
  `edad` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`reservas_huespedes_id`),
  KEY `FK_reservas_huespedes_reserva_id` (`reserva_id`),
  KEY `FK_reservas_huespedes_huesped_id` (`huesped_id`),
  KEY `FK_habitaciones` (`habitacion_id`),
  CONSTRAINT `FK_habitaciones` FOREIGN KEY (`habitacion_id`) REFERENCES `habitaciones` (`habitacion_id`),
  CONSTRAINT `FK_reservas_huespedes_huesped_id` FOREIGN KEY (`huesped_id`) REFERENCES `huespedes` (`huesped_id`),
  CONSTRAINT `FK_reservas_huespedes_reserva_id` FOREIGN KEY (`reserva_id`) REFERENCES `reservas` (`reserva_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservas_huespedes`
--

LOCK TABLES `reservas_huespedes` WRITE;
/*!40000 ALTER TABLE `reservas_huespedes` DISABLE KEYS */;
INSERT INTO `reservas_huespedes` VALUES (1,10,1,NULL,NULL,NULL,NULL,53),(2,10,2,NULL,NULL,NULL,NULL,9),(3,11,1,NULL,NULL,NULL,NULL,53),(4,15,1,NULL,NULL,NULL,NULL,53),(5,15,2,NULL,NULL,NULL,NULL,17),(8,10,10,NULL,NULL,NULL,NULL,36),(9,10,11,NULL,NULL,NULL,NULL,1);
/*!40000 ALTER TABLE `reservas_huespedes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reservas_ofertas`
--

DROP TABLE IF EXISTS `reservas_ofertas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reservas_ofertas` (
  `reserva_oferta_id` int(11) NOT NULL AUTO_INCREMENT,
  `reserva_id` int(11) NOT NULL,
  `oferta_id` int(11) NOT NULL,
  `tipo` varchar(1) DEFAULT NULL,
  `activa` tinyint(1) DEFAULT NULL,
  `oferta_usada` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`reserva_oferta_id`),
  UNIQUE KEY `IX_reservas_ofertas_reserva_id_oferta_id` (`reserva_id`,`oferta_id`),
  KEY `IX_reservas_ofertas_reserva_id` (`reserva_id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservas_ofertas`
--

LOCK TABLES `reservas_ofertas` WRITE;
/*!40000 ALTER TABLE `reservas_ofertas` DISABLE KEYS */;
INSERT INTO `reservas_ofertas` VALUES (1,15,1,'A',1,1),(2,15,2,'A',1,1),(3,16,1,'A',1,1),(4,16,2,'A',1,1),(5,16,3,'A',1,1),(6,20,1,'A',1,1),(7,20,2,'A',1,1),(8,20,3,'A',1,1),(9,17,1,'A',1,1),(10,17,2,'A',1,1),(11,17,3,'A',1,1),(12,19,1,'A',1,1),(13,19,2,'A',1,1),(14,19,3,'A',1,1),(15,18,1,'A',1,1),(16,18,2,'A',1,1),(17,18,3,'A',1,1),(18,21,1,'A',1,1),(19,21,2,'A',1,1),(20,21,3,'A',1,1),(21,22,1,'A',1,1),(22,22,2,'A',1,1),(23,22,3,'A',1,1),(24,14,1,'A',1,1),(25,14,2,'A',1,1),(26,14,3,'A',1,1),(27,11,1,'A',1,1),(28,11,2,'A',1,1),(29,11,3,'A',1,1),(30,10,1,'A',1,1),(31,10,2,'A',1,1),(32,10,3,'A',1,1),(33,13,1,'A',1,1),(34,13,2,'A',1,1),(35,13,3,'A',1,1),(36,12,1,'A',1,1),(37,12,2,'A',1,1),(38,12,3,'A',1,1),(39,23,1,'A',1,1),(41,24,2,'A',1,1);
/*!40000 ALTER TABLE `reservas_ofertas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reservas_servicios`
--

DROP TABLE IF EXISTS `reservas_servicios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reservas_servicios` (
  `servicio_reserva_id` int(11) NOT NULL AUTO_INCREMENT,
  `reserva_id` int(11) NOT NULL,
  `servicio_id` int(11) NOT NULL,
  `unidad_calculo_id` smallint(6) NOT NULL,
  `fecha_desde` date DEFAULT NULL,
  `fecha_hasta` date DEFAULT NULL,
  `cantidad` decimal(5,2) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  `flag_contrato` tinyint(1) DEFAULT NULL,
  `precio_servicio` double DEFAULT NULL,
  `servicio_extra` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`servicio_reserva_id`),
  KEY `FX_reservas_servicios_unidad_calculo_id` (`unidad_calculo_id`),
  KEY `FX_reservas_servicios_user_id` (`user_id`),
  KEY `IX_reservas_servicios_reserva_id` (`reserva_id`),
  KEY `IX_reservas_servicios_servicio_id` (`servicio_id`),
  KEY `IX_reservas_servicios_fecha_desde` (`fecha_desde`),
  KEY `IX_reservas_servicios_fecha_hasta` (`fecha_hasta`),
  CONSTRAINT `FX_reservas_servicios_reserva_id` FOREIGN KEY (`reserva_id`) REFERENCES `reservas` (`reserva_id`),
  CONSTRAINT `FX_reservas_servicios_servicio_id` FOREIGN KEY (`servicio_id`) REFERENCES `servicios` (`servicio_id`),
  CONSTRAINT `FX_reservas_servicios_unidad_calculo_id` FOREIGN KEY (`unidad_calculo_id`) REFERENCES `unidades_calculo` (`unidad_calculo_id`),
  CONSTRAINT `FX_reservas_servicios_user_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=434 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservas_servicios`
--

LOCK TABLES `reservas_servicios` WRITE;
/*!40000 ALTER TABLE `reservas_servicios` DISABLE KEYS */;
INSERT INTO `reservas_servicios` VALUES (112,11,11,1,NULL,NULL,1.00,2,'2017-04-17 13:31:42',1,NULL,0),(113,11,6,2,NULL,NULL,2.00,2,'2017-04-17 13:31:42',1,NULL,0),(114,11,6,3,NULL,NULL,1.00,2,'2017-04-17 13:31:42',1,NULL,0),(115,11,6,4,NULL,NULL,1.00,2,'2017-04-17 13:31:42',1,NULL,0),(116,11,6,5,NULL,NULL,1.00,2,'2017-04-17 13:31:42',1,NULL,0),(117,11,3,2,NULL,NULL,2.00,2,'2017-04-17 13:31:42',1,NULL,0),(118,11,3,3,NULL,NULL,1.00,2,'2017-04-17 13:31:42',1,NULL,0),(119,11,3,4,NULL,NULL,1.00,2,'2017-04-17 13:31:42',1,NULL,0),(120,11,7,1,NULL,NULL,1.00,2,'2017-04-17 13:31:42',1,NULL,0),(130,13,11,1,NULL,NULL,1.00,2,'2017-04-17 15:26:13',1,NULL,0),(131,13,6,2,NULL,NULL,2.00,2,'2017-04-17 15:38:37',1,NULL,0),(132,13,6,3,NULL,NULL,1.00,2,'2017-04-17 15:38:42',1,NULL,0),(133,13,6,4,NULL,NULL,1.00,2,'2017-04-17 15:38:45',1,NULL,0),(134,13,6,5,NULL,NULL,1.00,2,'2017-04-17 15:40:12',1,NULL,0),(135,13,2,2,NULL,NULL,2.00,2,'2017-04-17 15:40:12',1,NULL,0),(136,13,2,3,NULL,NULL,1.00,2,'2017-04-17 15:40:12',1,NULL,0),(137,13,2,4,NULL,NULL,1.00,2,'2017-04-17 15:40:12',1,NULL,0),(138,13,7,1,NULL,NULL,1.00,2,'2017-04-17 15:40:12',1,NULL,0),(139,13,11,1,NULL,NULL,1.00,2,'2017-04-17 15:40:12',1,NULL,0),(140,13,6,2,NULL,NULL,2.00,2,'2017-04-17 15:40:12',1,NULL,0),(141,13,6,3,NULL,NULL,1.00,2,'2017-04-17 15:40:12',1,NULL,0),(142,13,6,4,NULL,NULL,1.00,2,'2017-04-17 15:40:12',1,NULL,0),(143,13,6,5,NULL,NULL,1.00,2,'2017-04-17 15:40:12',1,NULL,0),(144,13,2,2,NULL,NULL,2.00,2,'2017-04-17 15:40:12',1,NULL,0),(145,13,2,3,NULL,NULL,1.00,2,'2017-04-17 15:40:12',1,NULL,0),(146,13,2,4,NULL,NULL,1.00,2,'2017-04-17 15:40:12',1,NULL,0),(147,13,7,1,NULL,NULL,1.00,2,'2017-04-17 15:40:12',1,NULL,0),(211,21,10,1,NULL,NULL,1.00,1,'2017-04-25 19:22:49',1,NULL,0),(212,21,1,2,NULL,NULL,2.00,1,'2017-04-25 19:22:49',1,NULL,0),(213,21,1,3,NULL,NULL,1.00,1,'2017-04-25 19:22:49',1,NULL,0),(214,21,1,4,NULL,NULL,1.00,1,'2017-04-25 19:22:49',1,NULL,0),(215,21,1,5,NULL,NULL,1.00,1,'2017-04-25 19:22:49',1,NULL,0),(216,21,116,2,NULL,NULL,2.00,1,'2017-04-25 19:22:49',1,NULL,0),(217,21,116,3,NULL,NULL,1.00,1,'2017-04-25 19:22:49',1,NULL,0),(218,21,116,4,NULL,NULL,1.00,1,'2017-04-25 19:22:49',1,NULL,0),(219,21,7,1,NULL,NULL,1.00,1,'2017-04-25 19:22:49',1,NULL,0),(229,18,11,1,NULL,NULL,1.00,1,'2017-04-25 19:23:41',1,NULL,0),(230,18,6,2,NULL,NULL,2.00,1,'2017-04-25 19:23:41',1,NULL,0),(231,18,6,3,NULL,NULL,1.00,1,'2017-04-25 19:23:41',1,NULL,0),(232,18,6,4,NULL,NULL,1.00,1,'2017-04-25 19:23:41',1,NULL,0),(233,18,6,5,NULL,NULL,1.00,1,'2017-04-25 19:23:41',1,NULL,0),(234,18,3,2,NULL,NULL,2.00,1,'2017-04-25 19:23:41',1,NULL,0),(235,18,3,3,NULL,NULL,1.00,1,'2017-04-25 19:23:41',1,NULL,0),(236,18,3,4,NULL,NULL,1.00,1,'2017-04-25 19:23:41',1,NULL,0),(237,18,7,1,NULL,NULL,1.00,1,'2017-04-25 19:23:41',1,NULL,0),(256,16,10,1,NULL,NULL,1.00,1,'2017-04-25 19:25:08',1,NULL,0),(257,16,1,2,NULL,NULL,2.00,1,'2017-04-25 19:25:08',1,NULL,0),(258,16,1,3,NULL,NULL,1.00,1,'2017-04-25 19:25:08',1,NULL,0),(259,16,1,4,NULL,NULL,1.00,1,'2017-04-25 19:25:08',1,NULL,0),(260,16,1,5,NULL,NULL,1.00,1,'2017-04-25 19:25:08',1,NULL,0),(261,16,3,2,NULL,NULL,2.00,1,'2017-04-25 19:25:08',1,NULL,0),(262,16,3,3,NULL,NULL,1.00,1,'2017-04-25 19:25:08',1,NULL,0),(263,16,3,4,NULL,NULL,1.00,1,'2017-04-25 19:25:08',1,NULL,0),(264,16,7,1,NULL,NULL,1.00,1,'2017-04-25 19:25:08',1,NULL,0),(265,2,10,1,NULL,NULL,1.00,1,'2017-04-25 19:34:19',1,NULL,0),(266,2,1,2,NULL,NULL,2.00,1,'2017-04-25 19:34:19',1,NULL,0),(267,2,1,3,NULL,NULL,1.00,1,'2017-04-25 19:34:19',1,NULL,0),(268,2,2,2,NULL,NULL,2.00,1,'2017-04-25 19:34:19',1,NULL,0),(269,2,2,3,NULL,NULL,1.00,1,'2017-04-25 19:34:19',1,NULL,0),(279,15,10,1,NULL,NULL,1.00,1,'2017-04-27 12:33:30',1,NULL,0),(280,15,1,2,NULL,NULL,2.00,1,'2017-04-27 12:33:30',1,NULL,0),(281,15,1,3,NULL,NULL,1.00,1,'2017-04-27 12:33:30',1,NULL,0),(282,15,1,4,NULL,NULL,1.00,1,'2017-04-27 12:33:30',1,NULL,0),(283,15,3,2,NULL,NULL,2.00,1,'2017-04-27 12:33:30',1,NULL,0),(284,15,3,3,NULL,NULL,1.00,1,'2017-04-27 12:33:30',1,NULL,0),(285,15,3,4,NULL,NULL,1.00,1,'2017-04-27 12:33:30',1,NULL,0),(295,12,11,1,NULL,NULL,1.00,1,'2017-04-27 17:08:24',1,NULL,0),(296,12,6,2,NULL,NULL,2.00,1,'2017-04-27 17:08:24',1,NULL,0),(297,12,6,3,NULL,NULL,1.00,1,'2017-04-27 17:08:24',1,NULL,0),(298,12,6,4,NULL,NULL,1.00,1,'2017-04-27 17:08:24',1,NULL,0),(299,12,6,5,NULL,NULL,1.00,1,'2017-04-27 17:08:24',1,NULL,0),(300,12,3,2,NULL,NULL,2.00,1,'2017-04-27 17:08:24',1,NULL,0),(301,12,3,3,NULL,NULL,1.00,1,'2017-04-27 17:08:24',1,NULL,0),(302,12,3,4,NULL,NULL,1.00,1,'2017-04-27 17:08:24',1,NULL,0),(303,12,7,1,NULL,NULL,1.00,1,'2017-04-27 17:08:24',1,NULL,0),(351,14,11,1,NULL,NULL,1.00,1,'2017-04-30 18:32:24',1,NULL,0),(352,14,6,2,NULL,NULL,2.00,1,'2017-04-30 18:32:24',1,NULL,0),(353,14,6,3,NULL,NULL,1.00,1,'2017-04-30 18:32:24',1,NULL,0),(354,14,6,4,NULL,NULL,1.00,1,'2017-04-30 18:32:24',1,NULL,0),(355,14,6,5,NULL,NULL,1.00,1,'2017-04-30 18:32:24',1,NULL,0),(356,14,3,2,NULL,NULL,2.00,1,'2017-04-30 18:32:24',1,NULL,0),(357,14,3,3,NULL,NULL,1.00,1,'2017-04-30 18:32:24',1,NULL,0),(358,14,3,4,NULL,NULL,1.00,1,'2017-04-30 18:32:24',1,NULL,0),(359,14,7,1,NULL,NULL,1.00,1,'2017-04-30 18:32:24',1,NULL,0),(368,24,11,1,NULL,NULL,1.00,1,'2017-05-01 17:50:23',1,NULL,0),(369,24,6,2,NULL,NULL,2.00,1,'2017-05-01 17:50:23',1,NULL,0),(370,24,6,4,NULL,NULL,1.00,1,'2017-05-01 17:50:23',1,NULL,0),(371,24,2,2,NULL,NULL,2.00,1,'2017-05-01 17:50:23',1,NULL,0),(372,24,2,4,NULL,NULL,1.00,1,'2017-05-01 17:50:23',1,NULL,0),(373,10,10,1,NULL,NULL,1.00,1,'2017-05-10 09:09:38',1,NULL,0),(374,10,1,2,NULL,NULL,1.00,1,'2017-05-10 09:09:38',1,NULL,0),(375,10,1,3,NULL,NULL,1.00,1,'2017-05-10 09:09:38',1,NULL,0),(376,10,1,4,NULL,NULL,1.00,1,'2017-05-10 09:09:38',1,NULL,0),(377,10,1,5,NULL,NULL,1.00,1,'2017-05-10 09:09:38',1,NULL,0),(378,10,3,2,NULL,NULL,1.00,1,'2017-05-10 09:09:38',1,NULL,0),(379,10,3,3,NULL,NULL,1.00,1,'2017-05-10 09:09:38',1,NULL,0),(380,10,3,4,NULL,NULL,1.00,1,'2017-05-10 09:09:38',1,NULL,0),(381,10,7,1,NULL,NULL,1.00,1,'2017-05-10 09:09:38',1,NULL,0),(382,22,10,1,NULL,NULL,1.00,1,'2017-05-10 09:59:57',1,NULL,0),(383,22,1,2,NULL,NULL,2.00,1,'2017-05-10 09:59:57',1,NULL,0),(384,22,1,3,NULL,NULL,1.00,1,'2017-05-10 09:59:57',1,NULL,0),(385,22,1,4,NULL,NULL,1.00,1,'2017-05-10 09:59:57',1,NULL,0),(386,22,1,5,NULL,NULL,1.00,1,'2017-05-10 09:59:57',1,NULL,0),(387,22,116,2,NULL,NULL,2.00,1,'2017-05-10 09:59:57',1,NULL,0),(388,22,116,3,NULL,NULL,1.00,1,'2017-05-10 09:59:57',1,NULL,0),(389,22,116,4,NULL,NULL,1.00,1,'2017-05-10 09:59:57',1,NULL,0),(390,22,7,1,NULL,NULL,1.00,1,'2017-05-10 09:59:57',1,NULL,0),(400,20,10,1,NULL,NULL,1.00,1,'2017-05-10 10:37:43',1,NULL,0),(401,20,1,2,NULL,NULL,2.00,1,'2017-05-10 10:37:43',1,NULL,0),(402,20,1,3,NULL,NULL,1.00,1,'2017-05-10 10:37:43',1,NULL,0),(403,20,1,4,NULL,NULL,1.00,1,'2017-05-10 10:37:43',1,NULL,0),(404,20,1,5,NULL,NULL,1.00,1,'2017-05-10 10:37:43',1,NULL,0),(405,20,3,2,NULL,NULL,2.00,1,'2017-05-10 10:37:43',1,NULL,0),(406,20,3,3,NULL,NULL,1.00,1,'2017-05-10 10:37:43',1,NULL,0),(407,20,3,4,NULL,NULL,1.00,1,'2017-05-10 10:37:43',1,NULL,0),(408,20,7,1,NULL,NULL,1.00,1,'2017-05-10 10:37:43',1,NULL,0),(409,19,10,1,NULL,NULL,1.00,1,'2017-05-10 10:42:04',1,NULL,0),(410,19,1,2,NULL,NULL,2.00,1,'2017-05-10 10:42:04',1,NULL,0),(411,19,1,3,NULL,NULL,1.00,1,'2017-05-10 10:42:04',1,NULL,0),(412,19,1,4,NULL,NULL,1.00,1,'2017-05-10 10:42:04',1,NULL,0),(413,19,1,5,NULL,NULL,1.00,1,'2017-05-10 10:42:04',1,NULL,0),(414,19,3,2,NULL,NULL,2.00,1,'2017-05-10 10:42:04',1,NULL,0),(415,19,3,3,NULL,NULL,1.00,1,'2017-05-10 10:42:04',1,NULL,0),(416,19,3,4,NULL,NULL,1.00,1,'2017-05-10 10:42:04',1,NULL,0),(417,19,7,1,NULL,NULL,1.00,1,'2017-05-10 10:42:04',1,NULL,0),(418,23,11,1,NULL,NULL,1.00,1,'2017-05-10 10:45:56',1,NULL,0),(419,23,6,2,NULL,NULL,2.00,1,'2017-05-10 10:45:56',1,NULL,0),(420,23,6,3,NULL,NULL,1.00,1,'2017-05-10 10:45:56',1,NULL,0),(421,23,116,2,NULL,NULL,2.00,1,'2017-05-10 10:45:56',1,NULL,0),(422,23,116,3,NULL,NULL,1.00,1,'2017-05-10 10:45:56',1,NULL,0),(424,10,42,1,NULL,NULL,1.00,1,'2017-05-10 15:40:32',2,NULL,1),(425,17,10,1,NULL,NULL,1.00,1,'2017-05-11 08:43:54',1,NULL,0),(426,17,1,2,NULL,NULL,2.00,1,'2017-05-11 08:43:54',1,NULL,0),(427,17,1,3,NULL,NULL,1.00,1,'2017-05-11 08:43:54',1,NULL,0),(428,17,1,4,NULL,NULL,1.00,1,'2017-05-11 08:43:54',1,NULL,0),(429,17,1,5,NULL,NULL,1.00,1,'2017-05-11 08:43:54',1,NULL,0),(430,17,3,2,NULL,NULL,2.00,1,'2017-05-11 08:43:54',1,NULL,0),(431,17,3,3,NULL,NULL,1.00,1,'2017-05-11 08:43:54',1,NULL,0),(432,17,3,4,NULL,NULL,1.00,1,'2017-05-11 08:43:54',1,NULL,0),(433,17,7,1,NULL,NULL,1.00,1,'2017-05-11 08:43:54',1,NULL,0);
/*!40000 ALTER TABLE `reservas_servicios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rolepermissions`
--

DROP TABLE IF EXISTS `rolepermissions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rolepermissions` (
  `RolePermissionId` bigint(20) NOT NULL AUTO_INCREMENT,
  `RoleId` int(11) NOT NULL,
  `PermissionKey` varchar(100) NOT NULL,
  PRIMARY KEY (`RolePermissionId`),
  UNIQUE KEY `UQ_RolePerm_RoleId_PermKey` (`RoleId`,`PermissionKey`),
  CONSTRAINT `FK_RolePermissions_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`RoleId`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rolepermissions`
--

LOCK TABLES `rolepermissions` WRITE;
/*!40000 ALTER TABLE `rolepermissions` DISABLE KEYS */;
INSERT INTO `rolepermissions` VALUES (1,1,'Recepcion:Hotel'),(2,1,'Todos:General'),(4,2,'Contratos:Empresa'),(5,2,'Contratos:General'),(6,2,'Recepcion:Hotel'),(3,2,'Todos:General');
/*!40000 ALTER TABLE `rolepermissions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roles` (
  `RoleId` int(11) NOT NULL AUTO_INCREMENT,
  `RoleName` varchar(100) NOT NULL,
  PRIMARY KEY (`RoleId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Recepcionista'),(2,'Jefe de Recepción'),(3,'Director de Hotel'),(4,'Administración y Central Reservas'),(5,'Admin');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `series`
--

DROP TABLE IF EXISTS `series`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
  `empresa_id` smallint(6) DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`serie_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `series`
--

LOCK TABLES `series` WRITE;
/*!40000 ALTER TABLE `series` DISABLE KEYS */;
INSERT INTO `series` VALUES (1,'Factura','FACT',1,1,1,0,NULL,NULL,2,NULL,NULL,NULL),(2,'Rectificativa','RECT',1,1,1,0,NULL,NULL,0,NULL,NULL,NULL),(3,'Ticket','TICK',1,1,1,0,NULL,NULL,0,NULL,NULL,NULL),(4,'Deposito','DEP',0,1,0,1,69,1,0,NULL,NULL,NULL),(5,'Anticipo','ANT',0,1,0,0,66,6,0,NULL,NULL,NULL),(6,'Descuento','DES',0,1,0,0,65,1,0,NULL,NULL,NULL),(7,'Descuento','DES',0,0,0,0,65,1,0,NULL,NULL,NULL),(8,'Gastos','GAST',0,1,0,0,NULL,NULL,0,NULL,NULL,NULL),(9,'Rectificativas 1','RECT',1,1,1,0,NULL,NULL,2,NULL,NULL,NULL);
/*!40000 ALTER TABLE `series` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `servicios`
--

DROP TABLE IF EXISTS `servicios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `servicios` (
  `servicio_id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre_servicio` varchar(50) NOT NULL,
  `abreviatura` varchar(6) NOT NULL,
  `tipo_servicio_id` smallint(6) NOT NULL,
  `sw_produccion` bit(1) NOT NULL DEFAULT b'1',
  `sw_descuento` bit(1) DEFAULT b'0',
  `sw_ajustes` bit(1) DEFAULT b'0',
  `sw_gastos` bit(1) DEFAULT b'0',
  `sw_pension` bit(1) NOT NULL DEFAULT b'0',
  `sw_rectificativa` bit(1) DEFAULT b'0',
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `servicios`
--

LOCK TABLES `servicios` WRITE;
/*!40000 ALTER TABLE `servicios` DISABLE KEYS */;
INSERT INTO `servicios` VALUES (1,'Alojamiento B1','A1',1,'','\0','\0','\0','\0','\0',2,99,NULL,NULL,NULL,1,'2008-12-10 00:00:00',1,NULL),(2,'Desayuno','HD',2,'','\0','\0','\0','','\0',2,2,NULL,NULL,NULL,1,'2009-02-02 00:00:00',NULL,1),(3,'Media Pension','MP',2,'','\0','\0','\0','','\0',2,2,NULL,NULL,NULL,2,'2011-03-11 00:00:00',NULL,2),(4,'Todo Incluido','TI',2,'','\0','\0','\0','','\0',2,2,NULL,NULL,NULL,1,'2011-08-17 00:00:00',NULL,4),(5,'Todo Incluido Bebidas','TIB',2,'','\0','\0','\0','','\0',2,2,NULL,NULL,NULL,7,NULL,NULL,4),(6,'Alojamiento B2','A2',1,'','\0','','\0','\0','\0',2,99,NULL,NULL,NULL,7,'2015-08-24 00:00:00',2,NULL),(7,'Cunas','CUN',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,NULL,NULL,NULL),(8,'Gala Navidad HD','GNHD',5,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,7,NULL,NULL,NULL),(9,'Gala Fin de Año','GF',5,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,7,'2015-01-14 00:00:00',NULL,NULL),(10,'Bungalow 1 Dormitorio','B1',1,'','\0','\0','\0','\0','\0',1,1,NULL,NULL,NULL,7,NULL,1,NULL),(11,'Bungalow 2 Dormitorios','B2',1,'','\0','\0','\0','\0','\0',1,1,NULL,NULL,NULL,7,NULL,2,NULL),(12,'Bar Piscina 1 Comidas','BP1C',4,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,NULL,NULL,NULL),(13,'Bar Piscina 1 Bebidas','BP1B',4,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,NULL,NULL,NULL),(14,'Bar Salon Bebidas','BSB',4,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,NULL,NULL,NULL),(15,'Bar Piscina 2 Comidas ','BP2C',4,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,NULL,NULL,NULL),(16,'Bar Piscina 2 Bebidas ','BP2B',4,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,NULL,NULL,NULL),(17,'Bar Restaurante Bebidas','BRB',4,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2013-07-29 00:00:00',NULL,NULL),(18,'Bar Restaurante Comidas','BRC',4,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2014-10-07 00:00:00',NULL,NULL),(19,'Gala Navidad','GN',5,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,7,NULL,NULL,NULL),(20,'Gala Fin de Año HD','GFHD',5,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,7,NULL,NULL,NULL),(23,'Habitacion Overbooking','HAOVB',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-01-21 00:00:00',NULL,NULL),(31,'Alquiler de Sombrilla','ALQSO',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-01-21 00:00:00',NULL,NULL),(33,'Cabinas Telefonicas','CABTF',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-01-21 00:00:00',NULL,NULL),(37,'Divisa','DIVIS',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-01-21 00:00:00',NULL,NULL),(38,'Exposiciones y Desfiles','EXPOS',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,37,'2015-05-12 00:00:00',NULL,NULL),(39,'Internet','INTER',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-01-21 00:00:00',NULL,NULL),(40,'Lavadoras','LAVAD',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-01-21 00:00:00',NULL,NULL),(42,'Caja de Seguridad','SAFE',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-01-21 00:00:00',NULL,NULL),(43,'Tabaco','TAB',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-01-21 00:00:00',NULL,NULL),(44,'Telefono','TELEF',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-01-21 00:00:00',NULL,NULL),(45,'Babychangingtable (Cambiador)','CAMBI',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-02-04 00:00:00',NULL,NULL),(47,'Babytrolly (Carrito)','CARRI',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-02-04 00:00:00',NULL,NULL),(48,'Rent a Car','RENT',3,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2013-08-07 00:00:00',NULL,NULL),(49,'Tenis','TENIS',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-02-04 00:00:00',NULL,NULL),(50,'Babychair (Trona)','TRONA',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-02-04 00:00:00',NULL,NULL),(51,'Wellness Center','WELLN',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-02-04 00:00:00',NULL,NULL),(52,'Wellcome Package','WPACK',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-02-04 00:00:00',NULL,NULL),(53,'Alojamiento Premier','AP',1,'','\0','\0','\0','\0','\0',2,99,NULL,NULL,NULL,1,'2009-03-04 00:00:00',3,NULL),(54,'Alojamiento Kid Suite','AKS',1,'','\0','\0','\0','\0','\0',2,99,NULL,NULL,NULL,1,'2009-03-04 00:00:00',4,NULL),(55,'Premier','PRE',1,'','\0','\0','\0','\0','\0',1,1,NULL,NULL,NULL,1,'2009-03-04 00:00:00',3,NULL),(56,'Kid Suite','KS',1,'','\0','\0','\0','\0','\0',1,1,NULL,NULL,NULL,1,'2009-03-04 00:00:00',4,NULL),(57,'Pension Completa','PC',2,'','\0','\0','\0','','\0',2,2,NULL,NULL,NULL,1,'2009-06-02 00:00:00',NULL,3),(60,'Varios','Var',3,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2013-03-11 00:00:00',NULL,NULL),(61,'Upgrade de B1 a B2','B1AB2',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,11,10,2,'2009-06-14 00:00:00',NULL,NULL),(62,'Descuento Publicidad Habitacion','DESH',1,'','','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2015-09-09 00:00:00',NULL,NULL),(63,'Descuento Pension','DESP',2,'','','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,2,'2009-04-14 00:00:00',NULL,NULL),(65,'Descuento Cobro','Desc',3,'\0','\0','\0','\0','\0','\0',1,NULL,0.00,NULL,NULL,2,'2009-05-18 13:47:27',NULL,NULL),(66,'Anticipo Factura','ANT',3,'\0','\0','\0','\0','\0','\0',1,NULL,0.00,NULL,NULL,2,'2009-05-18 13:49:24',NULL,NULL),(69,'Depositos','DEP',7,'\0','\0','\0','\0','\0','\0',1,NULL,0.00,NULL,NULL,2,'2009-10-27 00:00:00',NULL,NULL),(70,'Ajustes Produccion Pension','AJPEN',2,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,2,'2009-05-29 00:00:00',NULL,NULL),(71,'Ajustes Produccion Habitacion','AJUHA',1,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,2,'2009-05-29 00:00:00',NULL,NULL),(72,'Ajustes Produccion Galas','AJUGA',5,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,2,'2009-05-29 00:00:00',NULL,NULL),(73,'Ajustes Produccion Otros','AJUOT',3,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,2,'2009-05-29 00:00:00',NULL,NULL),(74,'Habitacion Permisos (Late check out)','PER',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2011-08-22 00:00:00',NULL,NULL),(75,'Upgrade B2 A KS','B2AKS',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,56,11,2,'2009-06-14 00:00:00',NULL,NULL),(76,'Animadores','ANIM',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,2,'2009-06-18 00:00:00',NULL,NULL),(77,'Upgrade MP a TI','MP2TI',2,'','\0','\0','\0','\0','\0',2,NULL,NULL,4,3,2,'2009-06-23 00:00:00',NULL,4),(78,'Persona Extra SA/día','CS',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,37,'2015-06-01 00:00:00',NULL,NULL),(79,'Varios Golosinas','GOLOS',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-07-03 00:00:00',NULL,NULL),(80,'Salón de Conferencias','CONFE',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2015-11-24 00:00:00',NULL,NULL),(83,'Sillon de Masajes','SILLO',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-07-03 00:00:00',NULL,NULL),(84,'Bisutería','BISUT',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-07-03 00:00:00',NULL,NULL),(85,'Roturas','ROTUR',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,9,'2009-09-29 00:00:00',NULL,NULL),(86,'Publicidad','PUBLI',6,'\0','\0','\0','','\0','\0',1,NULL,0.00,NULL,NULL,2,'2009-07-03 10:30:02',NULL,NULL),(87,'Luz para Tenis','Luz',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,2,'2009-07-08 00:00:00',NULL,NULL),(88,'Upgrade Desayuno a TI','De2TI',2,'','\0','\0','\0','\0','\0',2,NULL,NULL,4,2,2,'2009-07-09 00:00:00',NULL,4),(89,'Upgrade Desayuno a MP','DE2MP',2,'','\0','\0','\0','\0','\0',2,NULL,NULL,3,2,2,'2009-07-09 00:00:00',NULL,2),(90,'Suplemento Gala Navidad MP (contratos)','GNMP',5,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2011-12-22 00:00:00',NULL,NULL),(91,'Suplemento Gala Navidad TI (contratos)','GNTI',5,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2011-12-22 00:00:00',NULL,NULL),(92,'Suplemento Gala Fin de Año MP (contratos)','GFMP',5,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2011-12-22 00:00:00',NULL,NULL),(93,'Suplemento Gala Fin de Año TI (contratos)','GFTI',5,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2011-12-22 00:00:00',NULL,NULL),(94,'Suite 1 Dormitorio','SUITE1',1,'','\0','\0','\0','\0','\0',1,1,NULL,NULL,NULL,7,'2013-10-04 00:00:00',1,NULL),(95,'Suite 2 Dormitorios','SUITE2',1,'','\0','\0','\0','\0','\0',1,1,NULL,NULL,NULL,7,'2013-10-04 00:00:00',2,NULL),(96,'Alojamiento Suite 1','SU1',1,'','\0','\0','\0','\0','\0',2,99,NULL,NULL,NULL,7,'2013-10-04 00:00:00',1,NULL),(97,'Alojamiento Suite 2','SU2',1,'','\0','\0','\0','\0','\0',2,99,NULL,NULL,NULL,7,'2013-10-04 00:00:00',2,NULL),(98,'Upgrade A1 a A2','A1UA2',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,95,94,2,'2009-07-20 00:00:00',NULL,NULL),(99,'Upgrade A2 a KS','A2UKS',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,56,95,2,'2009-07-20 00:00:00',NULL,NULL),(100,'Calefaccion','Cal',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,2,'2009-07-21 00:00:00',NULL,NULL),(103,'Carga Partidas vivas','CCI',3,'\0','\0','\0','\0','\0','\0',1,NULL,0.00,NULL,NULL,2,'2009-07-31 00:00:00',NULL,NULL),(104,'Comisión bancaria','Comis',6,'\0','\0','\0','','\0','\0',1,NULL,0.00,NULL,NULL,7,'2009-08-28 16:48:22',NULL,NULL),(105,'Provisión Publicidad','ProvP',6,'\0','\0','\0','','\0','\0',1,NULL,0.00,NULL,NULL,7,'2009-08-28 16:48:46',NULL,NULL),(106,'Habitación Rectificativa','HABRE',1,'','\0','\0','\0','\0','',1,NULL,NULL,NULL,NULL,7,'2011-06-28 00:00:00',NULL,NULL),(107,'Desayuno rectificativa','DESRE',2,'','\0','\0','\0','\0','',2,NULL,NULL,NULL,NULL,7,'2011-06-28 00:00:00',NULL,NULL),(108,'Media Pensión Rectificativa','MPRE',2,'','\0','\0','\0','\0','',2,NULL,NULL,NULL,NULL,7,'2011-06-28 00:00:00',NULL,NULL),(109,'Todo Incluido Rectificativa','TIRE',2,'','\0','\0','\0','\0','',2,NULL,NULL,NULL,NULL,7,'2011-06-28 00:00:00',NULL,NULL),(110,'Supl. Doble Uso Ind.','SDUI',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,9,'2009-09-29 00:00:00',NULL,NULL),(111,'Coco´s birthday','COCO',4,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-10-21 00:00:00',NULL,NULL),(112,'Artículos Merchandising','MERCHA',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2012-06-18 00:00:00',NULL,NULL),(114,'Regularización cobro','REGUL',6,'\0','\0','\0','','\0','\0',1,NULL,0.00,NULL,NULL,7,'2009-11-30 11:09:21',NULL,NULL),(115,'Produccion Habitacion Garantia','GAR',1,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,2,'2009-12-04 00:00:00',NULL,NULL),(116,'Solo Alojamiento','SS',2,'\0','\0','\0','\0','','\0',2,2,0.00,NULL,NULL,1,'2009-12-25 19:48:23',NULL,NULL),(117,'Habitacion','HAB',1,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2009-12-30 00:00:00',NULL,NULL),(119,'Mando TV','TV',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,2,'2010-04-08 00:00:00',NULL,NULL),(120,'Snack','SNK',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,2,'2010-04-14 00:00:00',NULL,NULL),(121,'Pesa','PES',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,2,'2010-04-14 00:00:00',NULL,NULL),(122,'Upgrade Cenas ','CEN',2,'','\0','\0','\0','\0','\0',1,NULL,NULL,3,NULL,7,'2011-02-15 00:00:00',NULL,2),(123,'Cenas Niños','CEN',2,'','\0','\0','\0','\0','\0',1,NULL,NULL,3,NULL,2,'2010-04-14 00:00:00',NULL,2),(124,'Upgrade de A1 a PRE','UA1PR',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,55,94,1,'2010-07-14 00:00:00',NULL,NULL),(125,'Almuerzo','ALMUE',4,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2010-05-25 00:00:00',NULL,NULL),(126,'Merchandising','MERCH',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2010-07-26 00:00:00',NULL,NULL),(127,'SIAM PARK','SIAM',3,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,7,'2010-08-18 00:00:00',NULL,NULL),(128,'Misnusvalidos 1 Dorm','M1',1,'','\0','\0','\0','\0','\0',1,1,NULL,NULL,NULL,2,'2010-10-07 00:00:00',1,NULL),(129,'Minusvalidos 2 Dorm.','M2',1,'','\0','\0','\0','\0','\0',1,1,NULL,NULL,NULL,2,'2010-10-07 00:00:00',2,NULL),(130,'Alojamiento M1','AM1',1,'','\0','\0','\0','\0','\0',2,99,NULL,NULL,NULL,2,'2010-10-07 00:00:00',1,NULL),(131,'Alojamiento M2','AM2',1,'','\0','\0','\0','\0','\0',2,99,NULL,NULL,NULL,2,'2010-10-07 00:00:00',2,NULL),(132,'Máquinas recreativas','RECRE',3,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2014-10-16 00:00:00',NULL,NULL),(133,'Báscula maletas','BASCU',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2010-10-15 00:00:00',NULL,NULL),(134,'Máquinas expendedoras (VENDING)','EXPEN',3,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2014-01-24 00:00:00',NULL,NULL),(135,'Máquinas de café','CAFÉ',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2010-11-30 00:00:00',NULL,NULL),(136,'Upgrade SS a HD','SSHD',2,'','\0','\0','\0','\0','\0',2,2,NULL,2,NULL,7,'2010-12-22 00:00:00',NULL,1),(137,'Upgrade SS a MP','SSMP',2,'','\0','\0','\0','\0','\0',2,2,NULL,3,NULL,7,'2010-12-22 00:00:00',NULL,2),(138,'Upgrade SS a TI','SSTI',2,'','\0','\0','\0','\0','\0',2,2,NULL,4,NULL,7,'2010-12-22 00:00:00',NULL,4),(139,'Gala Navidad pasante 24.12','GNAP',5,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,7,'2014-12-24 00:00:00',NULL,NULL),(140,'Gala Fin de Año pasante','GFINP',5,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,7,'2014-12-24 00:00:00',NULL,NULL),(141,'Suplemento Gala Navidad SS (contratos)','GNSS',5,'','\0','\0','\0','\0','\0',2,2,NULL,NULL,NULL,7,'2011-12-22 00:00:00',NULL,NULL),(142,'Suplemento Gala Fin de Año SS (contratos)','GFISS',5,'','\0','\0','\0','\0','\0',2,2,NULL,NULL,NULL,7,'2011-12-22 00:00:00',NULL,NULL),(143,'Kid Suite +','KS+',1,'','\0','\0','\0','\0','\0',1,1,NULL,NULL,NULL,2,'2011-01-27 00:00:00',4,NULL),(144,'Alojamiento KS+','AKS+',1,'','\0','\0','\0','\0','\0',2,99,NULL,NULL,NULL,2,'2011-01-27 00:00:00',4,NULL),(145,'Productos Lavandería','LAVAN',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,37,'2011-02-04 00:00:00',NULL,NULL),(146,'Compensaciones OVB','COVB',3,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2011-03-02 00:00:00',NULL,NULL),(147,'Compensaciones','COMP',3,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2011-03-02 00:00:00',NULL,NULL),(148,'Pretty Woman','PREWO',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2011-04-18 00:00:00',NULL,NULL),(149,'Junior Suite Mar','JSM',1,'','\0','\0','\0','\0','\0',1,1,0.00,NULL,NULL,2,'2011-06-13 14:02:54',1,NULL),(150,'Alojamiento Junior Suite Mar','AJSM',1,'','\0','\0','\0','\0','\0',2,99,0.00,NULL,NULL,2,'2011-06-13 16:17:44',1,NULL),(151,'Suite Mar','SUITM',1,'','\0','\0','\0','\0','\0',1,1,0.00,NULL,NULL,2,'2011-06-13 16:18:51',2,NULL),(152,'Alojamiento Suite Mar','ASUIT',1,'','\0','\0','\0','\0','\0',2,99,0.00,NULL,NULL,2,'2011-06-13 16:19:43',2,NULL),(153,'Duplex Mar','DUPM',1,'','\0','\0','\0','\0','\0',1,1,0.00,NULL,NULL,2,'2011-06-13 16:20:38',4,NULL),(154,'Alojamiento Duplex Mar','ADUPM',1,'','\0','\0','\0','\0','\0',2,99,0.00,NULL,NULL,2,'2011-06-13 16:22:19',4,NULL),(156,'Junior Suite','JS',1,'','\0','\0','\0','\0','\0',1,1,0.00,NULL,NULL,2,'2011-06-14 16:47:28',1,NULL),(157,'Alojamiento Junior Suite','AJS',1,'','\0','\0','\0','\0','\0',2,99,0.00,NULL,NULL,7,'2013-01-24 00:00:00',1,NULL),(159,'Suite','SUIT',1,'','\0','\0','\0','\0','\0',1,1,0.00,NULL,NULL,2,'2011-06-14 16:49:38',2,NULL),(160,'Alojamiento Suite','ASUIT',1,'','\0','\0','\0','\0','\0',2,99,0.00,NULL,NULL,2,'2011-06-14 16:50:58',2,NULL),(161,'Duplex','DUP',1,'','\0','\0','\0','\0','\0',1,1,0.00,NULL,NULL,2,'2011-06-14 16:52:32',4,NULL),(162,'Alojamiento Duplex','ADUP',1,'','\0','\0','\0','\0','\0',2,99,0.00,NULL,NULL,2,'2011-06-14 16:53:21',4,NULL),(163,'HD Spa Wellness Center','SPA',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2011-06-15 00:00:00',NULL,NULL),(164,'Limpieza toallas','LTOAL',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,2,'2011-09-28 00:00:00',NULL,NULL),(165,'Snack Bar','SNACK',4,'','\0','\0','\0','\0','\0',1,2,NULL,NULL,NULL,7,'2012-02-10 00:00:00',NULL,NULL),(166,'Comisión Transfer','TRANS',3,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2011-07-06 00:00:00',NULL,NULL),(167,'Ingresos Reciclaje','IREC',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,2,'2011-07-26 00:00:00',NULL,NULL),(168,'Flores y tartas habitaciones','FLTA',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2011-08-31 00:00:00',NULL,NULL),(169,'Impresiones y fotocopias','IMFOT',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2011-08-31 00:00:00',NULL,NULL),(170,'Restaurante Italiano (Bebidas)','ITALI',4,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2012-06-18 00:00:00',NULL,NULL),(171,'Venta productos estética (spa HDBR)','VTAES',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2015-09-14 00:00:00',NULL,NULL),(172,'Alquiler DVDs','DVD',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2011-10-04 00:00:00',NULL,NULL),(173,'Upgrade de A1 a Kid Suite','A1KS',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2011-10-05 00:00:00',NULL,NULL),(174,'Alquiler electrodomésticos','ELECT',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2011-10-14 00:00:00',NULL,NULL),(175,'Cancelaciones reservas','CANCE',1,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2013-08-08 00:00:00',NULL,NULL),(176,'Upgrade Cena Japones','JAPO',2,'','\0','\0','\0','\0','\0',1,NULL,NULL,3,NULL,2,'2011-11-03 00:00:00',NULL,2),(177,'Descuento publicidad pensión','DtoPu',2,'','','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2015-09-09 00:00:00',NULL,NULL),(178,'Gala Navidad pasante 25.12','GNA25',5,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,7,'2011-12-20 00:00:00',NULL,NULL),(179,'Upgrade MP/TI-Gala 24/12','UG24',4,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,7,'2011-12-22 00:00:00',NULL,NULL),(180,'Upgrade MP/TI-Gala 25/12','UG25',4,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,7,'2011-12-22 00:00:00',NULL,NULL),(181,'Upgrade MP/TI-Gala 31/12','UG31',4,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,7,'2011-12-22 00:00:00',NULL,NULL),(182,'Aportación publicidad-guías','PBGUI',1,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2012-11-12 00:00:00',NULL,NULL),(183,'Suplemento Vista Mar','Vista',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2011-12-30 00:00:00',NULL,NULL),(184,'Seguro Bicicletas','BICI',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2012-01-11 00:00:00',NULL,NULL),(185,'Paquete material nautico','MATNA',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2012-02-29 00:00:00',NULL,NULL),(186,'Curso de Windsurf y Catamarán','WIDCA',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2012-02-29 00:00:00',NULL,NULL),(187,'Cena','CENA',4,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2014-05-12 00:00:00',NULL,NULL),(188,'Habitación interempresa','HABINT',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2012-03-30 00:00:00',NULL,NULL),(189,'Todo Incuido interempresa','TINTE',2,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2012-03-30 00:00:00',NULL,NULL),(190,'Alojamiento Interempresa','AINT',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2012-03-30 00:00:00',NULL,NULL),(191,'Habitación rectificativa interempresa','Rinte',1,'','\0','\0','\0','\0','',1,NULL,NULL,NULL,NULL,7,'2012-05-07 00:00:00',NULL,NULL),(192,'Todo Incluido Rectificativa Interempresa','TIRIN',2,'','\0','\0','\0','\0','',1,NULL,NULL,NULL,NULL,7,'2012-05-07 00:00:00',NULL,NULL),(193,'Restaurante Italiano (Comidas)','ITACO',4,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2012-06-18 00:00:00',NULL,NULL),(194,'Restaurante principal (Comidas)','RESTP',4,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2014-03-26 00:00:00',NULL,NULL),(195,'Restaurante principal (Bebidas)','RESTP',4,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2012-06-18 00:00:00',NULL,NULL),(196,'Upgrade Premier a B2','UPRB2',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,11,55,7,'2012-08-01 00:00:00',NULL,NULL),(197,'Aire Acondicionado','AIRE',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2012-09-20 00:00:00',NULL,NULL),(198,'VIP PACKAGE','PVIP',3,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,7,'2012-11-16 00:00:00',NULL,NULL),(199,'Peticiones obsequios para clientes(tartas, vino..)','OBSEQ',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2012-12-21 00:00:00',NULL,NULL),(200,'Suplemento Gala Navidad TI (contratos) 25.12','NTI25',5,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2012-12-24 00:00:00',NULL,NULL),(201,'Publicidad Marketing Dinámico','MARKE',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2013-02-19 00:00:00',NULL,NULL),(202,'Masajes','MASAJ',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2013-02-27 00:00:00',NULL,NULL),(203,'Suite Premier','A1PRE',1,'','\0','\0','\0','\0','\0',1,1,0.00,NULL,NULL,2,'2013-10-04 00:00:00',3,NULL),(204,'Suite Tecnologica','TECS2',1,'','\0','\0','\0','\0','\0',1,1,0.00,NULL,NULL,2,'2013-10-04 00:00:00',4,NULL),(205,'Alojamiento SUPRE','AA1PR',1,'','\0','\0','\0','\0','\0',2,99,0.00,NULL,NULL,2,'2013-10-04 00:00:00',3,NULL),(206,'Alojamiento TECS2','AA2PR',1,'','\0','\0','\0','\0','\0',2,99,0.00,NULL,NULL,2,'2013-10-04 00:00:00',4,NULL),(207,'Desayuno interempresa','DESIN',2,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2013-04-09 00:00:00',NULL,NULL),(208,'Venta cápsulas café','CAFÉ',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2013-06-13 00:00:00',NULL,NULL),(209,'Venta Pizzas','PIZZA',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2013-06-20 00:00:00',NULL,NULL),(210,'Alquiler Ipad','Ipad',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2013-06-26 00:00:00',NULL,NULL),(211,'Paquete Naútico','NAUTI',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2013-07-30 00:00:00',NULL,NULL),(212,'Alquiler MIFI','MIFI',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,2,'2013-09-12 00:00:00',NULL,NULL),(213,'Comida Animadores','Anima',2,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2013-10-22 00:00:00',NULL,NULL),(214,'Habitación permisos contrato (Late check-out)','LCOC',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2013-10-23 00:00:00',NULL,NULL),(215,'Producción garantía no ocupada','GNocu',1,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2014-01-27 00:00:00',NULL,NULL),(216,'Venta de aceite vegetal usado','ACEIT',1,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2014-02-28 00:00:00',NULL,NULL),(217,'Arrendamiento Terraza','ARREN',1,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2014-02-28 00:00:00',NULL,NULL),(218,'Refacturaciones consumos','CONSU',1,'','\0','','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2014-03-12 00:00:00',NULL,NULL),(219,'Fotografía','FOTO',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2014-05-09 00:00:00',NULL,NULL),(220,'Pintura','PINTU',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2014-05-09 00:00:00',NULL,NULL),(221,'Suplemento Sailor','SAILOR',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2014-05-19 00:00:00',NULL,NULL),(222,'Alquiler Cama Balinesa','BALI',3,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,7,'2014-05-19 00:00:00',NULL,NULL),(223,'Alquiler Bicicletas','BICIS',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2014-06-25 00:00:00',NULL,NULL),(224,'Descuento publicidad ','Publi',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2014-07-04 00:00:00',NULL,NULL),(225,'Day Use','DAYUS',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2014-08-01 00:00:00',NULL,NULL),(226,'Alquiler Babyphone','BPHON',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2014-09-05 00:00:00',NULL,NULL),(227,'Muñeco Be Chachi','CHACH',3,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,7,'2014-11-10 00:00:00',NULL,NULL),(228,'Puzzle Chachi (formula Creativa)','CHACH',3,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,37,'2014-09-15 00:00:00',NULL,NULL),(229,'Bolsa Chachi','CHACH',3,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,37,'2014-09-15 00:00:00',NULL,NULL),(230,'Libro El Secreto de los Chachis','CHACH',3,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,37,'2014-09-15 00:00:00',NULL,NULL),(231,'Libro de los dibujos Chachis','CHACH',3,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,37,'2014-09-15 00:00:00',NULL,NULL),(232,'Libro actividades Chachis','CHACH',3,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,37,'2014-09-15 00:00:00',NULL,NULL),(233,'Disco CD Chachi','CHACH',3,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,37,'2014-09-15 00:00:00',NULL,NULL),(234,'Super-pack Chachi','CHACH',3,'','\0','\0','\0','\0','\0',2,NULL,NULL,NULL,NULL,37,'2014-09-15 00:00:00',NULL,NULL),(235,'Cambio HAB misma Categoría','HAB=',1,'','\0','\0','\0','\0','\0',1,NULL,30.00,NULL,NULL,37,'2015-02-20 00:00:00',NULL,NULL),(236,'Camisetas Animación','CAMIS',3,'','\0','\0','\0','\0','\0',2,NULL,10.00,NULL,NULL,37,'2015-03-27 00:00:00',NULL,NULL),(237,'Descuento Habitación','DESH',1,'','','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,37,'2015-06-11 00:00:00',NULL,NULL),(238,'Sorteos de animación','SORTE',3,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2015-08-25 00:00:00',NULL,NULL),(239,'Comisión venta Sun Care','SUNCA',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2015-09-14 00:00:00',NULL,NULL),(240,'Alojamiento Villas','AVILL',1,'','\0','\0','\0','\0','\0',2,99,NULL,NULL,NULL,2,'2015-09-14 00:00:00',3,NULL),(241,'Villas','VILL',1,'','\0','\0','\0','\0','\0',1,1,NULL,NULL,NULL,2,'2015-09-14 00:00:00',3,NULL),(242,'Taza Chachi','TAZA',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2015-11-09 00:00:00',NULL,NULL),(243,'Descuento publicidad suplemento VIP','DTVIP',3,'','','\0','\0','\0','\0',1,2,NULL,NULL,NULL,7,'2015-11-25 00:00:00',NULL,NULL),(244,'Muñeco Be Chachi grande','CHACH',1,'','\0','\0','\0','\0','\0',1,NULL,NULL,NULL,NULL,7,'2015-11-26 00:00:00',NULL,NULL);
/*!40000 ALTER TABLE `servicios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `servicios_hotel`
--

DROP TABLE IF EXISTS `servicios_hotel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `servicios_hotel` (
  `servicio_hotel_id` int(11) NOT NULL AUTO_INCREMENT,
  `servicio_id` int(11) NOT NULL,
  `hotel_id` smallint(6) NOT NULL,
  `impuesto_id` smallint(6) NOT NULL,
  `costo` float DEFAULT NULL,
  `cta_contable` varchar(16) DEFAULT NULL,
  `dpto_contable` varchar(10) DEFAULT NULL,
  `permite_credito` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`servicio_hotel_id`,`hotel_id`),
  UNIQUE KEY `IX_servicio_hotel` (`servicio_id`,`hotel_id`),
  KEY `FK_servicios_hotel_impuesto_id_impuestos_impuesto_id` (`impuesto_id`),
  KEY `IX_servicio_id` (`servicio_id`),
  KEY `IX_hotel_id` (`hotel_id`),
  CONSTRAINT `FK_servicios_hotel_hotel_id_hoteles_hotel_id` FOREIGN KEY (`hotel_id`) REFERENCES `hoteles` (`hotel_id`),
  CONSTRAINT `FK_servicios_hotel_impuesto_id_impuestos_impuesto_id` FOREIGN KEY (`impuesto_id`) REFERENCES `impuestos` (`impuesto_id`),
  CONSTRAINT `FK_servicios_hotel_servicio_id_servicios_servicio_id` FOREIGN KEY (`servicio_id`) REFERENCES `servicios` (`servicio_id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `servicios_hotel`
--

LOCK TABLES `servicios_hotel` WRITE;
/*!40000 ALTER TABLE `servicios_hotel` DISABLE KEYS */;
INSERT INTO `servicios_hotel` VALUES (1,1,2,2,NULL,'7051000','100',0),(2,10,2,2,NULL,'7051000','100',0),(3,3,2,2,NULL,'7051000','100',0),(4,91,2,2,NULL,'7051000','100',0),(5,91,1,3,NULL,'7051000','100',0),(6,38,1,3,NULL,'7051000','100',0),(7,39,1,3,NULL,'7051000','100',0),(8,40,1,3,NULL,'7051000','100',0),(9,1,1,3,NULL,'7051000','100',0),(10,2,1,3,NULL,'7051000','100',0),(11,6,2,2,NULL,'7051000','100',0),(12,11,2,2,NULL,'7051000','100',0),(13,7,2,2,NULL,'123456','123',0),(14,116,2,2,NULL,'7051000','123',0),(15,10,1,2,NULL,'7051000','100',0),(16,2,2,2,NULL,'7051000','101',0),(17,4,2,2,NULL,'7052000','121',0),(18,3,1,2,NULL,'123456','100',0),(19,4,1,2,NULL,'7071000','100',0),(20,49,2,2,NULL,'7051000','100',0),(21,42,2,2,NULL,'7051000','100',0);
/*!40000 ALTER TABLE `servicios_hotel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sexos`
--

DROP TABLE IF EXISTS `sexos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sexos` (
  `sexo_id` varchar(1) NOT NULL,
  `sexo` varchar(20) NOT NULL,
  PRIMARY KEY (`sexo_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sexos`
--

LOCK TABLES `sexos` WRITE;
/*!40000 ALTER TABLE `sexos` DISABLE KEYS */;
INSERT INTO `sexos` VALUES ('F','Female / Mujer'),('M','Male / Hombre');
/*!40000 ALTER TABLE `sexos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `temporadas`
--

DROP TABLE IF EXISTS `temporadas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `temporadas` (
  `temporada_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `temporada` varchar(25) NOT NULL,
  `hotel_id` smallint(6) NOT NULL,
  `ano` smallint(6) DEFAULT NULL,
  `fecha_desde` date NOT NULL,
  `fecha_hasta` date NOT NULL,
  PRIMARY KEY (`temporada_id`),
  KEY `IX_tempradas_hotel_id` (`hotel_id`),
  CONSTRAINT `FK_temporadas_hoteles_hotel_id` FOREIGN KEY (`hotel_id`) REFERENCES `hoteles` (`hotel_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `temporadas`
--

LOCK TABLES `temporadas` WRITE;
/*!40000 ALTER TABLE `temporadas` DISABLE KEYS */;
/*!40000 ALTER TABLE `temporadas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tickets`
--

DROP TABLE IF EXISTS `tickets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tickets` (
  `ticket_id` int(11) NOT NULL AUTO_INCREMENT,
  `serie_id` smallint(6) NOT NULL,
  `cliente_id` int(11) NOT NULL,
  `hotel_id` smallint(6) NOT NULL,
  `fecha` date NOT NULL,
  `cliente_id_contrato` int(11) DEFAULT NULL,
  `reserva_id` int(11) DEFAULT NULL,
  `fecha_contabilizacion` datetime DEFAULT NULL,
  `caja_id` smallint(6) DEFAULT NULL,
  `forma_pago_id` smallint(6) DEFAULT NULL,
  `factura_id` int(11) DEFAULT NULL,
  `estado_ticket_id` smallint(6) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ticket_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tickets`
--

LOCK TABLES `tickets` WRITE;
/*!40000 ALTER TABLE `tickets` DISABLE KEYS */;
/*!40000 ALTER TABLE `tickets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipo_aplicacion_oferta`
--

DROP TABLE IF EXISTS `tipo_aplicacion_oferta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipo_aplicacion_oferta` (
  `tipo_aplicacion_oferta_id` varchar(1) NOT NULL,
  `aplicable_segun_fecha_de` varchar(15) NOT NULL,
  PRIMARY KEY (`tipo_aplicacion_oferta_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipo_aplicacion_oferta`
--

LOCK TABLES `tipo_aplicacion_oferta` WRITE;
/*!40000 ALTER TABLE `tipo_aplicacion_oferta` DISABLE KEYS */;
INSERT INTO `tipo_aplicacion_oferta` VALUES ('E','Estancia'),('L','LLegadas');
/*!40000 ALTER TABLE `tipo_aplicacion_oferta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_bloqueo`
--

DROP TABLE IF EXISTS `tipos_bloqueo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipos_bloqueo` (
  `tipo_bloqueo_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `descriptivo` varchar(20) NOT NULL,
  `editable` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`tipo_bloqueo_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_bloqueo`
--

LOCK TABLES `tipos_bloqueo` WRITE;
/*!40000 ALTER TABLE `tipos_bloqueo` DISABLE KEYS */;
INSERT INTO `tipos_bloqueo` VALUES (1,'Reserva',0),(2,'Rotura',1),(3,'Limpieza',0),(4,'Obras',0);
/*!40000 ALTER TABLE `tipos_bloqueo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_cobro`
--

DROP TABLE IF EXISTS `tipos_cobro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipos_cobro` (
  `tipo_cobro_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(20) NOT NULL,
  `signo` smallint(6) NOT NULL,
  `tipo_movimiento_id` smallint(6) NOT NULL,
  `cobro` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`tipo_cobro_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_cobro`
--

LOCK TABLES `tipos_cobro` WRITE;
/*!40000 ALTER TABLE `tipos_cobro` DISABLE KEYS */;
INSERT INTO `tipos_cobro` VALUES (1,'Cobro',1,1,1),(2,'Devolucion',-1,2,1),(3,'Depósito',1,8,0),(4,'Devol. Depósito',-1,9,0),(5,'Anticipo',1,5,1);
/*!40000 ALTER TABLE `tipos_cobro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_condicion`
--

DROP TABLE IF EXISTS `tipos_condicion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipos_condicion` (
  `tipo_condicion_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `condicion` varchar(2) NOT NULL,
  `literal` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`tipo_condicion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_condicion`
--

LOCK TABLES `tipos_condicion` WRITE;
/*!40000 ALTER TABLE `tipos_condicion` DISABLE KEYS */;
INSERT INTO `tipos_condicion` VALUES (1,'=','La unidad N es'),(2,'>','Para mas de N'),(3,'>=','Para N o mas'),(4,'<','Para menos de N'),(5,'<=','Para N o menos'),(6,'==','Al N es');
/*!40000 ALTER TABLE `tipos_condicion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_de_imputacion`
--

DROP TABLE IF EXISTS `tipos_de_imputacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipos_de_imputacion` (
  `tipo_imputacion_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `imputacion` varchar(20) NOT NULL,
  PRIMARY KEY (`tipo_imputacion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_de_imputacion`
--

LOCK TABLES `tipos_de_imputacion` WRITE;
/*!40000 ALTER TABLE `tipos_de_imputacion` DISABLE KEYS */;
INSERT INTO `tipos_de_imputacion` VALUES (1,'Llegada'),(2,'Salida'),(3,'Prorrateado'),(4,'Diario');
/*!40000 ALTER TABLE `tipos_de_imputacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_de_oferta`
--

DROP TABLE IF EXISTS `tipos_de_oferta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipos_de_oferta` (
  `tipo_oferta_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `Oferta` varchar(25) NOT NULL,
  `permitir_m_mayor_que_n` tinyint(4) NOT NULL DEFAULT '1',
  `rejilla` bit(1) NOT NULL DEFAULT b'0',
  `Observaciones` varchar(100) DEFAULT NULL,
  `orden_aplicacion` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`tipo_oferta_id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_de_oferta`
--

LOCK TABLES `tipos_de_oferta` WRITE;
/*!40000 ALTER TABLE `tipos_de_oferta` DISABLE KEYS */;
INSERT INTO `tipos_de_oferta` VALUES (1,'n X m',0,'\0','Oferta tipo 2x1 implica que cada “n” unidades cobramos “m” de forma repetitiva',1),(2,'La ud. n y +,  m% dto',1,'\0','Las primeras “n-1” udes a precio normal. Despues aplicar “m%” descuento',1),(3,'La ud. n y +, m% inc.',1,'\0','Las primeras “n” udes a precio normal. Despues aplicar “m%” recargo',1),(4,'La ud. n y +, a m €',1,'\0','Las primeras “n” udes a precio normal. Despues aplicar el precio “m”',0),(5,'Menos de n, m% inc.',1,'\0','Hacer un “m%” de incremento a todas las unidades si hay menos unidades que lo que indica “n”',1),(6,'Menos de n, m% dto.',1,'\0','Hacer un “m%” de descuento a todas las unidades Si hay menos unidades que lo que indica “n”',1),(7,'Mas de n, m% dto',1,'\0','Hacer un “m”% de descuento a todo Si hay más unidades que lo que indica “n”',1),(8,'Mas de n, m% inc.',1,'\0','Hacer un “m”% de incremento a todo Si hay más unidades que lo que indica “n”',1),(9,'Mas de n, a m €',1,'\0','Aplicar el precio “m” a todas las unidades Si hay más unidades que lo que indica “n”',0),(10,'n uds m a % dto.',1,'\0','Si hay n  unidades tienen un m% de descuento.',1),(11,'n uds a m% inc.',1,'\0','Si hay n unidades tienen un m% de incremento.',1),(12,'n uds a m €',1,'\0','Las n primeras unidades se facturan a m €, el resto al precio normal.',0),(13,'Rejilla unidades',1,'','Tabla de Unidades a precios o porcentajes que se aplican',1),(14,'mas de n ,a m € inc/dec',1,'\0','Hacer un m de desc/inc euros a todo Si hay más unidades que lo que indica “n”',1),(15,'mas de n ,a n*m € inc/dec',1,'\0','Hacer un n*m de desc/inc euros a todo Si hay más unidades que lo que indica “n”',1),(16,'menos de n ,a m € inc/dec',1,'\0','Hacer un m de desc/inc euros a todo Si hay menos unidades que lo que indica “n”',1),(17,'menos de n ,a n*m € inc/d',1,'\0','Hacer un n*m de desc/inc euros a todo Si hay menos unidades que lo que indica “n”',1),(18,'La ud. n y -,  m% dto',1,'\0','Las primeras “n\" unidades aplica un % descuento',1),(19,'La ud. n y -, a m €',1,'\0','Las primeras “n\" unidades aplica un precio',1);
/*!40000 ALTER TABLE `tipos_de_oferta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_de_tarjeta`
--

DROP TABLE IF EXISTS `tipos_de_tarjeta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipos_de_tarjeta` (
  `tipo_tarjeta_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `tipo_tarjeta` varchar(15) DEFAULT NULL,
  `tarjeta_length` varchar(20) DEFAULT NULL,
  `tarjeta_prefixes` varchar(40) DEFAULT NULL,
  `tarjeta_checkdigit` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`tipo_tarjeta_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_de_tarjeta`
--

LOCK TABLES `tipos_de_tarjeta` WRITE;
/*!40000 ALTER TABLE `tipos_de_tarjeta` DISABLE KEYS */;
INSERT INTO `tipos_de_tarjeta` VALUES (1,'VISA/Matercard','13,16','4,51,52,53,54,55',1),(2,'Maestro','12,13,14,15,16,18,19','5018,5020,5038,6304,6759,6761',1);
/*!40000 ALTER TABLE `tipos_de_tarjeta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_descuento`
--

DROP TABLE IF EXISTS `tipos_descuento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipos_descuento` (
  `tipo_descuento_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `tipo_descuento` varchar(16) NOT NULL,
  PRIMARY KEY (`tipo_descuento_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_descuento`
--

LOCK TABLES `tipos_descuento` WRITE;
/*!40000 ALTER TABLE `tipos_descuento` DISABLE KEYS */;
INSERT INTO `tipos_descuento` VALUES (1,'Porcentaje'),(2,'Cantidad');
/*!40000 ALTER TABLE `tipos_descuento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_documento`
--

DROP TABLE IF EXISTS `tipos_documento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipos_documento` (
  `tipo_documento_id` varchar(1) NOT NULL,
  `tipo_documento` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`tipo_documento_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_documento`
--

LOCK TABLES `tipos_documento` WRITE;
/*!40000 ALTER TABLE `tipos_documento` DISABLE KEYS */;
INSERT INTO `tipos_documento` VALUES ('C','CIF'),('D','DNI'),('N','NIF'),('P','Passport');
/*!40000 ALTER TABLE `tipos_documento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_habitacion`
--

DROP TABLE IF EXISTS `tipos_habitacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_habitacion`
--

LOCK TABLES `tipos_habitacion` WRITE;
/*!40000 ALTER TABLE `tipos_habitacion` DISABLE KEYS */;
INSERT INTO `tipos_habitacion` VALUES (1,'B1','Bungalow 1 dormitorio',1,3,0,0),(2,'B2','Bungalow 2 dormitorios',2,5,0,0),(3,'SUITE1','Suite 1 Dormitorio',1,4,0,0),(6,'PRE','Premier',3,3,0,0),(7,'KS','Kids Suites',4,5,0,0),(8,'SUITE2','Suite 2 dormitorios',2,6,0,0),(10,'DES','Desvios',NULL,999,1,0),(11,'M1','Minusvalidos 1 Dorm.',1,3,0,0),(12,'M2','Minusvalidos 2 Dorm',2,5,0,0),(13,'KS+','Kid Suites Promo',4,5,0,0),(14,'JSM','Junior Suite Vista Mar',3,3,0,0),(15,'SUITM','Suite Vista Mar',4,3,0,0),(16,'DUPM','Duplex Vista Mar',4,4,0,0),(17,'JS','Junior Suite',3,4,0,0),(18,'SUIT','Suite',4,3,0,0),(19,'DUP','Duplex',4,4,0,0),(20,'HABINT','Habitación interempresa',NULL,5,0,0),(21,'A1PRE','Suite Premier',3,3,0,0),(22,'TECS2','Suite Tecnologica',4,5,0,0),(23,'NO SH','No Show',NULL,900,1,1),(24,'VILL','Villas',3,6,0,0);
/*!40000 ALTER TABLE `tipos_habitacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_habitacion_hotel`
--

DROP TABLE IF EXISTS `tipos_habitacion_hotel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipos_habitacion_hotel` (
  `tipo_habitacion_hotel_id` int(11) NOT NULL AUTO_INCREMENT,
  `hotel_id` smallint(6) NOT NULL,
  `tipo_habitacion_id` smallint(6) NOT NULL,
  `servicio_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`tipo_habitacion_hotel_id`),
  UNIQUE KEY `IX_tipo_habitacion_hotel` (`tipo_habitacion_id`,`hotel_id`),
  KEY `FK_tipos_habitacion_hotel_hotel_id` (`hotel_id`),
  KEY `FK_tipos_habitacion_servicio_id` (`servicio_id`),
  CONSTRAINT `FK_tipos_habitacion_hotel_hotel_id` FOREIGN KEY (`hotel_id`) REFERENCES `hoteles` (`hotel_id`),
  CONSTRAINT `FK_tipos_habitacion_servicio_id` FOREIGN KEY (`servicio_id`) REFERENCES `servicios` (`servicio_id`),
  CONSTRAINT `FK_tipos_habitacion_tipo_habitacion_id` FOREIGN KEY (`tipo_habitacion_id`) REFERENCES `tipos_habitacion` (`tipo_habitacion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_habitacion_hotel`
--

LOCK TABLES `tipos_habitacion_hotel` WRITE;
/*!40000 ALTER TABLE `tipos_habitacion_hotel` DISABLE KEYS */;
INSERT INTO `tipos_habitacion_hotel` VALUES (1,2,2,11),(2,2,7,NULL),(3,2,20,NULL),(4,2,1,10),(5,1,20,NULL),(6,1,7,NULL),(7,1,4,40),(8,1,5,41),(9,1,3,72),(10,1,6,73);
/*!40000 ALTER TABLE `tipos_habitacion_hotel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_hotel`
--

DROP TABLE IF EXISTS `tipos_hotel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipos_hotel` (
  `tipo_hotel_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `tipo_hotel` varchar(30) DEFAULT NULL,
  `abreviatura` varchar(6) DEFAULT NULL,
  PRIMARY KEY (`tipo_hotel_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_hotel`
--

LOCK TABLES `tipos_hotel` WRITE;
/*!40000 ALTER TABLE `tipos_hotel` DISABLE KEYS */;
INSERT INTO `tipos_hotel` VALUES (1,'Hotel','H'),(2,'Hotel Bungalows','HA'),(3,'Apartamentos','A'),(4,'Hotel Rural','HR');
/*!40000 ALTER TABLE `tipos_hotel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_huesped`
--

DROP TABLE IF EXISTS `tipos_huesped`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipos_huesped` (
  `tipo_huesped_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(30) NOT NULL,
  `Desc_corta` varchar(2) NOT NULL,
  `uc_id` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`tipo_huesped_id`),
  KEY `uc_id` (`uc_id`),
  CONSTRAINT `tipos_huesped_ibfk_1` FOREIGN KEY (`uc_id`) REFERENCES `unidades_calculo` (`unidad_calculo_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_huesped`
--

LOCK TABLES `tipos_huesped` WRITE;
/*!40000 ALTER TABLE `tipos_huesped` DISABLE KEYS */;
INSERT INTO `tipos_huesped` VALUES (1,'Adultos','A',2),(2,'Niños 50% (N1)','N1',3),(3,'Niños Free (N2)','N2',4),(4,'Bebes ','B',5);
/*!40000 ALTER TABLE `tipos_huesped` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_movimiento_caja`
--

DROP TABLE IF EXISTS `tipos_movimiento_caja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipos_movimiento_caja` (
  `tipo_movimiento_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  `signo` smallint(6) NOT NULL,
  `produccion` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`tipo_movimiento_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_movimiento_caja`
--

LOCK TABLES `tipos_movimiento_caja` WRITE;
/*!40000 ALTER TABLE `tipos_movimiento_caja` DISABLE KEYS */;
INSERT INTO `tipos_movimiento_caja` VALUES (1,'Cobro',1,1),(2,'Devolución',-1,1),(3,'Dotación de Fondos',1,1),(4,'Retirada de Fondos',-1,1),(5,'Anticipo',1,1),(6,'Faltante de Caja',-1,1),(7,'Sobrante de Caja',1,1),(8,'Deposito',1,1),(9,'Devolucion Deposito',-1,1),(10,'Gastos',1,1),(11,'Devolucion Anticipo',1,1);
/*!40000 ALTER TABLE `tipos_movimiento_caja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_pension`
--

DROP TABLE IF EXISTS `tipos_pension`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipos_pension` (
  `tipo_pension_id` smallint(11) NOT NULL,
  `Tipo_pension` varchar(16) NOT NULL,
  PRIMARY KEY (`tipo_pension_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_pension`
--

LOCK TABLES `tipos_pension` WRITE;
/*!40000 ALTER TABLE `tipos_pension` DISABLE KEYS */;
INSERT INTO `tipos_pension` VALUES (0,'Solo Alojamiento'),(1,'Desayuno'),(2,'Media Pension'),(3,'Pension Completa'),(4,'Todo Incluido');
/*!40000 ALTER TABLE `tipos_pension` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_servicio`
--

DROP TABLE IF EXISTS `tipos_servicio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipos_servicio` (
  `tipo_servicio_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `nombre_tipo_servicio` varchar(30) NOT NULL,
  PRIMARY KEY (`tipo_servicio_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_servicio`
--

LOCK TABLES `tipos_servicio` WRITE;
/*!40000 ALTER TABLE `tipos_servicio` DISABLE KEYS */;
INSERT INTO `tipos_servicio` VALUES (1,'Habitación'),(2,'Pensión'),(3,'Otros'),(4,'Extras F&B'),(5,'Galas'),(6,'Gastos'),(7,'Depósitos');
/*!40000 ALTER TABLE `tipos_servicio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_unidad_calculo`
--

DROP TABLE IF EXISTS `tipos_unidad_calculo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipos_unidad_calculo` (
  `tipo_unidad_calculo_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `tipo_uc` varchar(15) NOT NULL,
  PRIMARY KEY (`tipo_unidad_calculo_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_unidad_calculo`
--

LOCK TABLES `tipos_unidad_calculo` WRITE;
/*!40000 ALTER TABLE `tipos_unidad_calculo` DISABLE KEYS */;
INSERT INTO `tipos_unidad_calculo` VALUES (1,'Servicio'),(2,'Huespedes');
/*!40000 ALTER TABLE `tipos_unidad_calculo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unidades_calculo`
--

DROP TABLE IF EXISTS `unidades_calculo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unidades_calculo` (
  `unidad_calculo_id` smallint(2) NOT NULL AUTO_INCREMENT COMMENT 'Abreviatura',
  `UC` varchar(4) NOT NULL,
  `descripcion_unidad_calculo` varchar(30) NOT NULL,
  `tipo_unidad_calculo_id` smallint(6) DEFAULT NULL,
  `pax` bit(1) DEFAULT NULL,
  `servicio_id` int(6) DEFAULT NULL,
  `user_id` int(6) DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  PRIMARY KEY (`unidad_calculo_id`),
  KEY `unidad_calculo_id` (`unidad_calculo_id`),
  KEY `servicio_id` (`servicio_id`),
  KEY `tipo_unidad_calculo_id` (`tipo_unidad_calculo_id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `unidades_calculo_ibfk_1` FOREIGN KEY (`servicio_id`) REFERENCES `servicios` (`servicio_id`),
  CONSTRAINT `unidades_calculo_ibfk_2` FOREIGN KEY (`tipo_unidad_calculo_id`) REFERENCES `tipos_unidad_calculo` (`tipo_unidad_calculo_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1 COMMENT='InnoDB free: 10240 kB';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unidades_calculo`
--

LOCK TABLES `unidades_calculo` WRITE;
/*!40000 ALTER TABLE `unidades_calculo` DISABLE KEYS */;
INSERT INTO `unidades_calculo` VALUES (1,'SRV','Servicio',1,'\0',NULL,2,NULL),(2,'A','Adultos',2,'',NULL,2,NULL),(3,'N1','Niños 50%',2,'',NULL,2,NULL),(4,'N2','Niños Free',2,'',NULL,2,NULL),(5,'B','Bebes',2,'\0',7,2,NULL),(6,'A+N','A+N1+N2+B',2,'\0',NULL,2,NULL);
/*!40000 ALTER TABLE `unidades_calculo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unidades_calculo_agrupados`
--

DROP TABLE IF EXISTS `unidades_calculo_agrupados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unidades_calculo_agrupados` (
  `unidad_calculo_padre_id` smallint(6) NOT NULL,
  `unidad_calculo_hijo_id` smallint(6) NOT NULL,
  PRIMARY KEY (`unidad_calculo_padre_id`,`unidad_calculo_hijo_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unidades_calculo_agrupados`
--

LOCK TABLES `unidades_calculo_agrupados` WRITE;
/*!40000 ALTER TABLE `unidades_calculo_agrupados` DISABLE KEYS */;
INSERT INTO `unidades_calculo_agrupados` VALUES (6,2),(6,3),(6,4),(6,5);
/*!40000 ALTER TABLE `unidades_calculo_agrupados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userpermissions`
--

DROP TABLE IF EXISTS `userpermissions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userpermissions` (
  `UserPermissionId` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `PermissionKey` varchar(100) NOT NULL,
  `Granted` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`UserPermissionId`),
  UNIQUE KEY `UQ_UserPerm_UserId_PermKey` (`UserId`,`PermissionKey`),
  CONSTRAINT `FK_UserPermissions_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userpermissions`
--

LOCK TABLES `userpermissions` WRITE;
/*!40000 ALTER TABLE `userpermissions` DISABLE KEYS */;
/*!40000 ALTER TABLE `userpermissions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userpreferences`
--

DROP TABLE IF EXISTS `userpreferences`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userpreferences` (
  `UserPreferenceId` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` bigint(20) NOT NULL,
  `PreferenceType` varchar(100) NOT NULL,
  `Name` varchar(200) NOT NULL,
  `Value` longtext,
  PRIMARY KEY (`UserPreferenceId`),
  UNIQUE KEY `IX_UserPref_UID_PrefType_Name` (`UserId`,`PreferenceType`,`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userpreferences`
--

LOCK TABLES `userpreferences` WRITE;
/*!40000 ALTER TABLE `userpreferences` DISABLE KEYS */;
/*!40000 ALTER TABLE `userpreferences` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userroles`
--

DROP TABLE IF EXISTS `userroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userroles` (
  `UserRoleId` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `RoleId` int(11) NOT NULL,
  PRIMARY KEY (`UserRoleId`),
  UNIQUE KEY `UQ_UserRoles_UserId_RoleId` (`UserId`,`RoleId`),
  KEY `IX_UserRoles_RoleId_UserId` (`RoleId`,`UserId`),
  CONSTRAINT `FK_UserRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`RoleId`),
  CONSTRAINT `FK_UserRoles_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userroles`
--

LOCK TABLES `userroles` WRITE;
/*!40000 ALTER TABLE `userroles` DISABLE KEYS */;
INSERT INTO `userroles` VALUES (1,2,1),(2,3,1),(3,3,2),(7,3,3),(6,3,4),(5,4,1),(4,4,2);
/*!40000 ALTER TABLE `userroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `UserId` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(100) NOT NULL,
  `DisplayName` varchar(100) NOT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Source` varchar(4) NOT NULL,
  `PasswordHash` varchar(86) NOT NULL,
  `PasswordSalt` varchar(10) NOT NULL,
  `LastDirectoryUpdate` datetime DEFAULT NULL,
  `UserImage` varchar(100) DEFAULT NULL,
  `InsertDate` datetime NOT NULL,
  `InsertUserId` int(11) NOT NULL,
  `UpdateDate` datetime DEFAULT NULL,
  `UpdateUserId` int(11) DEFAULT NULL,
  `IsActive` smallint(6) NOT NULL DEFAULT '1',
  `EmpresaId` smallint(6) DEFAULT NULL,
  `HotelId` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`UserId`),
  KEY `IX_users_EmpresaId` (`EmpresaId`),
  KEY `IX_users_HotelId` (`HotelId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'admin','admin','admin@geshotel.com','site','rfqpSPYs0ekFlPyvIRTXsdhE/qrTHFF+kKsAUla7pFkXL4BgLGlTe89GDX5DBysenMDj8AqbIZPybqvusyCjwQ','hJf_F',NULL,NULL,'2014-01-01 00:00:00',1,'2017-05-02 12:16:04',1,1,1,2),(2,'Booking2','Booking Hotel 2','admin@geshotel.com','site','aHiFfYAhHkNIzrkAUc29ovqX4tZR/Q67tUsD3tr+eKc+8oWmDY6e9EAY5zSS7zXYKAQEEXcqCLU7dMicKbh5Zg','m.DQR',NULL,NULL,'2017-04-10 17:32:37',1,NULL,NULL,1,1,2),(3,'jnunez','Javier Nuñez','admin@geshotel.com','site','fwYru7Z3kliO8Wr5pg3Bi4TkdWMiZtZR28QqyBonGhuaO+ViSS4PvTiWmoaj21Bjyr09+88lnk6VAU7Ig2Ozjg','(zAu-',NULL,NULL,'2017-04-10 17:32:37',1,NULL,NULL,1,1,1),(4,'Jefe2','Jefe Hotel2','jefe2@gmail.com','site','IQzVke2Y2EWGMsehcqVZiHmYsq+sMX96MaZZyDp0NWitBZgpBOA3LPKWVLblsuhj/7zPt7GOcNAln8npZ7SeNw','}DMv_',NULL,NULL,'2017-04-11 15:14:41',1,NULL,NULL,1,1,2);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `versioninfo`
--

DROP TABLE IF EXISTS `versioninfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `versioninfo` (
  `Version` bigint(20) NOT NULL,
  `AppliedOn` datetime DEFAULT NULL,
  `Description` varchar(1024) DEFAULT NULL,
  UNIQUE KEY `UC_Version` (`Version`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `versioninfo`
--

LOCK TABLES `versioninfo` WRITE;
/*!40000 ALTER TABLE `versioninfo` DISABLE KEYS */;
INSERT INTO `versioninfo` VALUES (20141103140000,'2017-04-10 17:32:07','DefaultDB_20141103_140000_Initial'),(20141111113000,'2017-04-10 17:32:08','DefaultDB_20141111_113000_Permissions'),(20160515072600,'2017-04-10 17:32:09','DefaultDB_20160515_072600_UserPreferences'),(20161029130000,'2017-04-10 17:32:09','DefaultDB_20161029_130000_ExceptionLog'),(20161126200000,'2017-04-10 17:32:10','DefaultDB_20161126_200000_Organization'),(20161126210000,'2017-04-10 17:32:16','DefaultDB_20161126_210000_Meeting'),(20170118182000,'2017-04-10 17:32:19','DefaultDB_20170118_182000_Usercompany'),(20170123163900,'2017-04-10 17:32:21','DefaultDB_20170123_163900_Inital'),(20170130120000,'2017-04-10 17:32:25','DefaultDB_20170130_120000_Contratos'),(20170203120000,'2017-04-10 17:32:25','DefaultDB_20170203_120000_TemporadasYMercados'),(20170203224500,'2017-04-10 17:32:26','DefaultDB_20170203_224500_ReservaAutomatica'),(20170208224500,'2017-04-10 17:32:27','DefaultDB_20170208_224500_Servicios_hotel'),(20170219224500,'2017-04-10 17:32:30','DefaultDB_20170219_224500_Habitaciones'),(20170220224500,'2017-04-10 17:32:37','DefaultDB_20170220_224500_Reservas'),(20170307224500,'2017-04-10 17:32:42','DefaultDB_20170307_224500_SampleData'),(20170326224500,'2017-04-10 17:32:45','DefaultDB_20170326_224500_Guests'),(20170404224500,'2017-04-10 17:32:50','DefaultDB_20170404_224500_Events_movimientos_caja'),(20170405224500,'2017-04-10 17:32:50','DefaultDB_20170405_224500_Cierres'),(20170410224500,'2017-04-18 17:49:58','DefaultDB_20170410_224500_Equivalencias_Reservas_Servicios'),(20170420224500,'2017-04-20 13:18:38','DefaultDB_20170420_224500_PreviewServicios');
/*!40000 ALTER TABLE `versioninfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `zonas_limpieza`
--

DROP TABLE IF EXISTS `zonas_limpieza`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `zonas_limpieza` (
  `zona_limpieza_id` smallint(6) NOT NULL AUTO_INCREMENT,
  `hotel_id` smallint(6) NOT NULL,
  `nombre_zona` varchar(20) NOT NULL,
  PRIMARY KEY (`zona_limpieza_id`),
  KEY `IX_zona_limpieza_hotel` (`hotel_id`),
  CONSTRAINT `FK_zonas_limpieza_hotel_id` FOREIGN KEY (`hotel_id`) REFERENCES `hoteles` (`hotel_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `zonas_limpieza`
--

LOCK TABLES `zonas_limpieza` WRITE;
/*!40000 ALTER TABLE `zonas_limpieza` DISABLE KEYS */;
/*!40000 ALTER TABLE `zonas_limpieza` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-05-11  8:47:26
