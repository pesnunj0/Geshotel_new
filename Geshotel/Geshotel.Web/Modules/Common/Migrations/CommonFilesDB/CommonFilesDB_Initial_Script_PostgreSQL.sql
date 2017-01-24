/*
Source Server         : Mysql
Source Server Version : 50716
Source Host           : localhost:3306
Source Database       : commonfiles

Target Server Type    : PostgreSQL
Converted By		  : http://www.sqlines.com/online

Date: 2017-01-20 16:00:42

Owner : Javier Nuñez
*/

-- ---------------------------------------
-- Table structure for ambito_oferta
-- ---------------------------------------
DROP TABLE IF EXISTS ambito_oferta;
CREATE TABLE ambito_oferta (
  ambito_oferta_id smallint NOT NULL,
  nombre varchar(15) NOT NULL,
  PRIMARY KEY (ambito_oferta_id)
) ;

-- ----------------------------
-- Records of ambito_oferta
-- ----------------------------
INSERT INTO ambito_oferta VALUES ('1', 'Dia');
INSERT INTO ambito_oferta VALUES ('2', 'Cantidad');

-- ----------------------------
-- Table structure for categoria_hoteles
-- ----------------------------
DROP TABLE IF EXISTS categoria_hoteles;
CREATE SEQUENCE categoria_hoteles_seq;

CREATE TABLE categoria_hoteles (
  categoria_id smallint NOT NULL DEFAULT NEXTVAL ('categoria_hoteles_seq'),
  categoria varchar(20) NOT NULL,
  abreviatura varchar(6) NOT NULL,
  PRIMARY KEY (categoria_id)
)  ;

ALTER SEQUENCE categoria_hoteles_seq RESTART WITH 7;

-- ----------------------------
-- Records of categoria_hoteles
-- ----------------------------
INSERT INTO categoria_hoteles VALUES ('1', '1 ESTRELLA', '*');
INSERT INTO categoria_hoteles VALUES ('2', '2 ESTRELLAS', '**');
INSERT INTO categoria_hoteles VALUES ('3', '3 ESTRELLAS', '***');
INSERT INTO categoria_hoteles VALUES ('4', '4 ESTRELLAS', '****');
INSERT INTO categoria_hoteles VALUES ('5', '5 ESTRELLAS', '*****');
INSERT INTO categoria_hoteles VALUES ('6', 'SUPERIOR', '5 * SU');

-- ----------------------------
-- Table structure for comunidades_autonomas
-- ----------------------------
DROP TABLE IF EXISTS comunidades_autonomas;
CREATE SEQUENCE comunidades_autonomas_seq;

CREATE TABLE comunidades_autonomas (
  comunidad_id smallint NOT NULL DEFAULT NEXTVAL ('comunidades_autonomas_seq'),
  nacion_id smallint DEFAULT NULL,
  comunidad_autonoma varchar(50) DEFAULT NULL,
  comunidad_autonoma_ista varchar(5) DEFAULT NULL,
  PRIMARY KEY (comunidad_id)
 ,
  CONSTRAINT comunidades_autonomas_ibfk_1 FOREIGN KEY (nacion_id) REFERENCES naciones (nacion_id)
)  ;

ALTER SEQUENCE comunidades_autonomas_seq RESTART WITH 19;

CREATE INDEX nacion_id ON comunidades_autonomas (nacion_id);

-- ----------------------------
-- Records of comunidades_autonomas
-- ----------------------------
INSERT INTO comunidades_autonomas VALUES ('1', '1', 'Andalucia', null);
INSERT INTO comunidades_autonomas VALUES ('2', '1', 'Aragon', null);
INSERT INTO comunidades_autonomas VALUES ('3', '1', 'Asturias', null);
INSERT INTO comunidades_autonomas VALUES ('4', '1', 'Baleares', 'ES530');
INSERT INTO comunidades_autonomas VALUES ('5', '1', 'Canarias', null);
INSERT INTO comunidades_autonomas VALUES ('6', '1', 'Cantabria', null);
INSERT INTO comunidades_autonomas VALUES ('7', '1', 'Castilla y Leon', null);
INSERT INTO comunidades_autonomas VALUES ('8', '1', 'Castilla La Mancha', null);
INSERT INTO comunidades_autonomas VALUES ('9', '1', 'Cataluña', null);
INSERT INTO comunidades_autonomas VALUES ('10', '1', 'Valencia', null);
INSERT INTO comunidades_autonomas VALUES ('11', '1', 'Extremadura', null);
INSERT INTO comunidades_autonomas VALUES ('12', '1', 'Galicia', null);
INSERT INTO comunidades_autonomas VALUES ('13', '1', 'Madrid', null);
INSERT INTO comunidades_autonomas VALUES ('14', '1', 'Murcia', null);
INSERT INTO comunidades_autonomas VALUES ('15', '1', 'Navarra', null);
INSERT INTO comunidades_autonomas VALUES ('16', '1', 'Pais Vasco', null);
INSERT INTO comunidades_autonomas VALUES ('17', '1', 'La Rioja', 'ES230');
INSERT INTO comunidades_autonomas VALUES ('18', '1', 'Ceuta y Melilla', null);

-- ----------------------------
-- Table structure for conceptos_acelerador_reservas
-- ----------------------------
DROP TABLE IF EXISTS conceptos_acelerador_reservas;
CREATE SEQUENCE conceptos_acelerador_reservas_seq;

CREATE TABLE conceptos_acelerador_reservas (
  concepto_acelerador_id smallint NOT NULL DEFAULT NEXTVAL ('conceptos_acelerador_reservas_seq'),
  concepto varchar(15) NOT NULL,
  PRIMARY KEY (concepto_acelerador_id)
)  ;

ALTER SEQUENCE conceptos_acelerador_reservas_seq RESTART WITH 100;

-- ----------------------------
-- Records of conceptos_acelerador_reservas
-- ----------------------------
INSERT INTO conceptos_acelerador_reservas VALUES ('1', 'Tipo Habitacion');
INSERT INTO conceptos_acelerador_reservas VALUES ('2', 'Pension');
INSERT INTO conceptos_acelerador_reservas VALUES ('99', 'Pax');

-- ----------------------------
-- Table structure for empresas
-- ----------------------------
DROP TABLE IF EXISTS empresas;
CREATE SEQUENCE empresas_seq;

CREATE TABLE empresas (
  empresa_id smallint NOT NULL DEFAULT NEXTVAL ('empresas_seq'),
  empresa varchar(40) NOT NULL,
  empresa_contable varchar(5) DEFAULT NULL,
  direccion varchar(50) DEFAULT NULL,
  poblacion varchar(50) DEFAULT NULL,
  zip varchar(5) DEFAULT NULL,
  provincia_id smallint DEFAULT NULL,
  telefono varchar(20) DEFAULT NULL,
  fax varchar(20) DEFAULT NULL,
  cif varchar(20) DEFAULT NULL,
  ruta_ficheros text,
  PRIMARY KEY (empresa_id)
 ,
  CONSTRAINT empresas_ibfk_1 FOREIGN KEY (provincia_id) REFERENCES provincias (provincia_id)
)  ;

ALTER SEQUENCE empresas_seq RESTART WITH 6;

CREATE INDEX provincia_id ON empresas (provincia_id);

-- ----------------------------
-- Records of empresas
-- ----------------------------
INSERT INTO empresas VALUES ('1', 'EMPRESA HOTELES 1', '889', 'Su dirección', 'Menorca', '43010', '8', '+34.902.109.704', '+34.928.229.290', 'B-35809789', 'D:\geshotelfiles\ficheros_contables');
INSERT INTO empresas VALUES ('2', 'EMPRESA PRUEBAS 1', '888', 'Ctra. Del Centro 1', 'Las Palmas de GC', '01001', '1', '+34.928.11.11.22', null, 'H-12345678', null);

-- ----------------------------
-- Table structure for estados_facturas
-- ----------------------------
DROP TABLE IF EXISTS estados_facturas;
CREATE TABLE estados_facturas (
  estado_factura_id smallint NOT NULL,
  descripcion varchar(255) DEFAULT NULL,
  es_error smallint DEFAULT NULL,
  PRIMARY KEY (estado_factura_id)
) ;

-- ----------------------------
-- Records of estados_facturas
-- ----------------------------
INSERT INTO estados_facturas VALUES ('0', 'Creada', '1');
INSERT INTO estados_facturas VALUES ('1', 'Actualizada', '0');
INSERT INTO estados_facturas VALUES ('2', 'Contabilizada', '0');

-- ----------------------------
-- Table structure for formas_de_pago
-- ----------------------------
DROP TABLE IF EXISTS formas_de_pago;
CREATE SEQUENCE formas_de_pago_seq;

CREATE TABLE formas_de_pago (
  forma_pago_id smallint NOT NULL DEFAULT NEXTVAL ('formas_de_pago_seq'),
  forma_pago varchar(20) NOT NULL,
  credito boolean(1) NOT NULL DEFAULT b'0',
  sw_efectivo boolean(1) DEFAULT NULL,
  sw_tarjeta boolean(1) DEFAULT NULL,
  tarjeta_length varchar(20) DEFAULT NULL,
  tarjeta_prefixes varchar(40) DEFAULT NULL,
  tarjeta_checkdigit boolean(1) DEFAULT NULL,
  sw_dingus boolean(1) DEFAULT b'0',
  produccion_tpv boolean(1) DEFAULT b'1',
  PRIMARY KEY (forma_pago_id)
)  ;

ALTER SEQUENCE formas_de_pago_seq RESTART WITH 12;

-- ----------------------------
-- Records of formas_de_pago
-- ----------------------------
INSERT INTO formas_de_pago VALUES ('1', 'Contado', '