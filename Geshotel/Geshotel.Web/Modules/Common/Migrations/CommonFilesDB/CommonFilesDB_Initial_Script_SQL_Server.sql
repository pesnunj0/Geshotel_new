/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50716
Source Host           : localhost:3306
Source Database       : commonfiles

Target Server Type    : Microsoft SQL Server
Converted By		  : http://www.sqlines.com/online


Date: 2017-01-20 16:00:42

Owner : Javier Nuñez
*/
-- ----------------------------
-- Table structure for tipos_de_imputacion
-- ----------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- DROP TABLE IF EXISTS [tipos_de_imputacion];
CREATE TABLE tipos_de_imputacion (
  [tipo_imputacion_id] smallint IDENTITY (1,1) NOT NULL,
  [imputacion] varchar(20) NOT NULL,
  PRIMARY KEY ([tipo_imputacion_id])
)  ;

-- ----------------------------
-- Records of tipos_de_imputacion
-- ----------------------------
INSERT INTO tipos_de_imputacion VALUES ( 'Llegada');
INSERT INTO tipos_de_imputacion VALUES ('Salida');
INSERT INTO tipos_de_imputacion VALUES ('Prorrateado');
INSERT INTO tipos_de_imputacion VALUES ('Diario');

-- ----------------------------
-- Table structure for monedas
-- ----------------------------
--DROP TABLE IF EXISTS [monedas];
CREATE TABLE monedas (
  [moneda_id] smallint IDENTITY (1,1) NOT NULL,
  [descripcion] varchar(20) NOT NULL,
  [desc_corta] varchar(10) NOT NULL,
  [cambio] float ,
  PRIMARY KEY ([moneda_id])
)  ;

-- ----------------------------
-- Records of monedas
-- ----------------------------
INSERT INTO monedas VALUES ('EURO', '€', '1');
INSERT INTO monedas VALUES ( 'US DOLAR', '$', '1.06');
INSERT INTO monedas VALUES ( 'LIBRA ESTERLINA', '£', '0.88');
INSERT INTO monedas VALUES ( 'CORONA SUECA', 'Kr', null);
INSERT INTO monedas VALUES ( 'FRANCO SUIZO', 'CHK', null);
INSERT INTO monedas VALUES ( 'CORONA CHECA', 'CZK', null);
INSERT INTO monedas VALUES ( 'RUBLO', 'RU', null);
INSERT INTO monedas VALUES ( 'YEN', 'YEN', null);
INSERT INTO monedas VALUES ( 'YUAN', 'YU', null);

-- ----------------------------
-- Table structure for naciones
-- ----------------------------
--DROP TABLE IF EXISTS [naciones];
CREATE TABLE naciones (
  [nacion_id] smallint IDENTITY (1,1) NOT NULL,
  [nacion] varchar(30) ,
  [desc_corta] varchar(6) ,
  [moneda_id] smallint NOT NULL,
  [idioma_id] int ,
  [numero_ine] smallint ,
  [pais_ista] varchar(3) ,
  [defecto] smallint ,
  [nombre_real] varchar(max),
  [idioma_mails] varchar(3) ,
  PRIMARY KEY ([nacion_id])
 ,

)  ;

CREATE INDEX [nacion] ON naciones ([nacion]);
CREATE INDEX [moneda_id] ON naciones ([moneda_id]);
CREATE INDEX [idioma_id] ON naciones ([idioma_id]);

-- ----------------------------
-- Records of naciones
-- ----------------------------
INSERT INTO naciones VALUES ('ESPAÑA', 'ESP', '1', '1', '1', null, '1', 'España', 'ES');
INSERT INTO naciones VALUES ('HOLANDA', 'HOL', '1', '5', null, 'NLD', '0', 'Nederland', 'EN');
INSERT INTO naciones VALUES ('ALEMANIA', 'ALE', '1', '4', '2', 'DEU', '0', 'Deutschland', 'DE');
INSERT INTO naciones VALUES ('REINO UNIDO', 'UK', '3', '2', null, 'GBR', '0', 'UK', 'EN');
INSERT INTO naciones VALUES ('SUECIA', 'SWE', '4', '8', null, 'SWE', '0', 'Sverige', 'EN');
INSERT INTO naciones VALUES ('NORUEGA', 'NOR', '4', '12', null, 'NOR', '0', 'Norge', 'EN');
INSERT INTO naciones VALUES ('FINLANDIA', 'FIN', '1', '13', null, 'FIN', '0', 'Suomi', 'EN');
INSERT INTO naciones VALUES ('FRANCIA', 'FRA', '1', '3', null, 'FRA', '0', 'France', 'EN');
INSERT INTO naciones VALUES ('ITALIA', 'IT', '1', '9', null, 'ITA', '0', 'Italia', 'EN');
INSERT INTO naciones VALUES ('CANADA', 'CAN', '2', '2', null, 'CAN', '0', 'Canada', 'EN');
INSERT INTO naciones VALUES ('DINAMARCA', 'DEN', '1', '6', null, 'DNK', '0', 'Danmark', 'EN');
INSERT INTO naciones VALUES ('BELGICA', 'BEL', '1', '5', '4', 'BEL', '0', 'België/Belgique', 'EN');
INSERT INTO naciones VALUES ('IRLANDA', 'IRL', '1', '2', null, 'IRL', '0', 'Éire', 'EN');
INSERT INTO naciones VALUES ('RUMANIA', 'RUM', '1', '14', null, 'ROU', '0', 'România', 'EN');
INSERT INTO naciones VALUES ('PORTUGAL', 'POR', '1', '7', null, 'PRT', '0', 'Portugal', 'EN');
INSERT INTO naciones VALUES ('SUIZA', 'SUI', '5', '3', null, 'CHE', '0', 'Schweiz', 'EN');
INSERT INTO naciones VALUES ('LUXEMBURGO', 'LUX', '1', '15', null, 'LUX', '0', 'Luxemburg', 'EN');
INSERT INTO naciones VALUES ('GRECIA', 'GRE', '1', '16', null, 'GRC', '0', 'Greece', 'EN');
INSERT INTO naciones VALUES ('RESTO DE EUROPA', 'RESTE', '1', '2', null, null, '0', 'Other', 'EN');
INSERT INTO naciones VALUES ('POLONIA', 'POL', '1', '1', null, 'POL', '0', 'Polska', 'EN');
INSERT INTO naciones VALUES ('AUSTRIA', 'AUT', '1', '4', '3', 'AUT', '0', 'Österreich', 'EN');
INSERT INTO naciones VALUES ('REPUBLICA CHECA', 'CZEC', '1', '4', null, 'CZE', '0', 'Cesko ', 'EN');
INSERT INTO naciones VALUES ('RUSIA', 'RUS', '7', '10', null, 'RUS', '0', 'Russia', 'EN');
INSERT INTO naciones VALUES ('ESTADOS UNIDOS', 'USA', '2', '2', null, 'USA', '0', 'United States', 'EN');
INSERT INTO naciones VALUES ('JAPON', 'JPN', '8', '19', null, 'JPN', '0', 'Japan', 'EN');
INSERT INTO naciones VALUES ('CHINA', 'CHN', '9', '11', null, 'CHN', '0', 'China', 'EN');
INSERT INTO naciones VALUES ('ISLANDIA', 'ISL', '1', '2', null, 'ISL', '0', 'Ísland', 'EN');

-- ---------------------------------------
-- Table structure for ambito_oferta
-- ---------------------------------------
--DROP TABLE IF EXISTS [ambito_oferta];
CREATE TABLE ambito_oferta (
  [ambito_oferta_id] smallint IDENTITY (1,1) NOT NULL,
  [nombre] varchar(15) NOT NULL,
  PRIMARY KEY ([ambito_oferta_id])
) ;

-- ----------------------------
-- Records of ambito_oferta
-- ----------------------------
INSERT INTO ambito_oferta VALUES ('Dia');
INSERT INTO ambito_oferta VALUES ('Cantidad');

-- ----------------------------
-- Table structure for categoria_hoteles
-- ----------------------------
--DROP TABLE IF EXISTS [categoria_hoteles];
CREATE TABLE categoria_hoteles (
  [categoria_id] smallint IDENTITY(1,1) NOT NULL,
  [categoria] varchar(20) NOT NULL,
  [abreviatura] varchar(6) NOT NULL,
  PRIMARY KEY ([categoria_id])
)  ;

-- ----------------------------
-- Table structure for tipos_unidad_calculo
-- ----------------------------
--DROP TABLE IF EXISTS [tipos_unidad_calculo];
CREATE TABLE tipos_unidad_calculo (
  [tipo_unidad_calculo_id] smallint IDENTITY (1,1) NOT NULL ,
  [tipo_uc] varchar(15) NOT NULL,
  PRIMARY KEY ([tipo_unidad_calculo_id])
)  ;

-- ----------------------------
-- Records of tipos_unidad_calculo
-- ----------------------------
INSERT INTO tipos_unidad_calculo VALUES ('Servicio');
INSERT INTO tipos_unidad_calculo VALUES ('Huespedes');

-- ----------------------------
-- Records of categoria_hoteles
-- ----------------------------
INSERT INTO categoria_hoteles VALUES ('1 ESTRELLA', '*');
INSERT INTO categoria_hoteles VALUES ('2 ESTRELLAS', '**');
INSERT INTO categoria_hoteles VALUES ('3 ESTRELLAS', '***');
INSERT INTO categoria_hoteles VALUES ('4 ESTRELLAS', '****');
INSERT INTO categoria_hoteles VALUES ('5 ESTRELLAS', '*****');
INSERT INTO categoria_hoteles VALUES ('SUPERIOR', '5 * SU');

-- ----------------------------
-- Table structure for grupos_habitacion
-- ----------------------------
--DROP TABLE IF EXISTS [grupos_habitacion];
CREATE TABLE grupos_habitacion (
  [grupo_habitacion_id] smallint IDENTITY (1,1) NOT NULL,
  [grupo_habitacion] varchar(15) NOT NULL,
  PRIMARY KEY ([grupo_habitacion_id])
) ;

-- ----------------------------
-- Records of grupos_habitacion
-- ----------------------------
INSERT INTO grupos_habitacion VALUES ('1 Dormitorio');
INSERT INTO grupos_habitacion VALUES ('2 Dormitorios');
INSERT INTO grupos_habitacion VALUES ('Premier');
INSERT INTO grupos_habitacion VALUES ('Kid Suite');

-- ----------------------------
-- Table structure for tipos_habitacion
-- ----------------------------
--DROP TABLE IF EXISTS [tipos_habitacion];
CREATE TABLE tipos_habitacion (
  [tipo_habitacion_id] smallint IDENTITY (1,1) NOT NULL ,
  [desc_corta] varchar(6) NOT NULL,
  [descripcion] varchar(50) NOT NULL,
  [grupo_habitacion_id] smallint ,
  [numero_personas] smallint NOT NULL,
  [desvios] smallint ,
  [no_show] smallint ,
  PRIMARY KEY ([tipo_habitacion_id])
)  ;

CREATE INDEX [grupo_habitacion_id] ON tipos_habitacion ([grupo_habitacion_id]);

-- ----------------------------
-- Records of tipos_habitacion
-- ----------------------------
INSERT INTO tipos_habitacion VALUES ( 'B1', 'Bungalow 1 dormitorio', '1', '3', '0', '0');
INSERT INTO tipos_habitacion VALUES ( 'B2', 'Bungalow 2 dormitorios', '2', '5', '0', '0');
INSERT INTO tipos_habitacion VALUES ( 'SUITE1', 'Suite 1 Dormitorio', '1', '4', '0', '0');
INSERT INTO tipos_habitacion VALUES ( 'PRE', 'Premier', '3', '3', '0', '0');
INSERT INTO tipos_habitacion VALUES ( 'KS', 'Kids Suites', '4', '5', '0', '0');
INSERT INTO tipos_habitacion VALUES ( 'SUITE2', 'Suite 2 dormitorios', '2', '6', '0', '0');
INSERT INTO tipos_habitacion VALUES ( 'DES', 'Desvios', null, '999', '1', '0');
INSERT INTO tipos_habitacion VALUES ( 'M1', 'Minusvalidos 1 Dorm.', '1', '3', '0', '0');
INSERT INTO tipos_habitacion VALUES ( 'M2', 'Minusvalidos 2 Dorm', '2', '5', '0', '0');
INSERT INTO tipos_habitacion VALUES ( 'KS+', 'Kid Suites Promo', '4', '5', '0', '0');
INSERT INTO tipos_habitacion VALUES ( 'JSM', 'Junior Suite Vista Mar', '3', '3', '0', '0');
INSERT INTO tipos_habitacion VALUES ( 'SUITM', 'Suite Vista Mar', '4', '3', '0', '0');
INSERT INTO tipos_habitacion VALUES ( 'DUPM', 'Duplex Vista Mar', '4', '4', '0', '0');
INSERT INTO tipos_habitacion VALUES ( 'JS', 'Junior Suite', '3', '4', '0', '0');
INSERT INTO tipos_habitacion VALUES ( 'SUIT', 'Suite', '4', '3', '0', '0');
INSERT INTO tipos_habitacion VALUES ( 'DUP', 'Duplex', '4', '4', '0', '0');
INSERT INTO tipos_habitacion VALUES ( 'HABINT', 'Habitación interempresa', null, '5', '0', '0');
INSERT INTO tipos_habitacion VALUES ( 'A1PRE', 'Suite Premier', '3', '3', '0', '0');
INSERT INTO tipos_habitacion VALUES ( 'TECS2', 'Suite Tecnologica', '4', '5', '0', '0');
INSERT INTO tipos_habitacion VALUES ( 'NO SH', 'No Show', null, '900', '1', '1');
INSERT INTO tipos_habitacion VALUES ( 'VILL', 'Villas', '3', '6', '0', '0');

-- ----------------------------
-- Table structure for tipos_hotel
-- ----------------------------
--DROP TABLE IF EXISTS [tipos_hotel];
CREATE TABLE tipos_hotel (
  [tipo_hotel_id] smallint IDENTITY (1,1) NOT NULL ,
  [tipo_hotel] varchar(30) ,
  [abreviatura] varchar(6) ,
  PRIMARY KEY ([tipo_hotel_id])
)  ;

-- ----------------------------
-- Records of tipos_hotel
-- ----------------------------
INSERT INTO tipos_hotel VALUES ('Hotel', 'H');
INSERT INTO tipos_hotel VALUES ('Hotel Bungalows', 'HA');
INSERT INTO tipos_hotel VALUES ('Apartamentos', 'A');
INSERT INTO tipos_hotel VALUES ('Hotel Rural', 'HR');

-- ----------------------------
-- Table structure for unidades_calculo
-- ----------------------------
--DROP TABLE IF EXISTS [unidades_calculo];
CREATE TABLE unidades_calculo (
  [unidad_calculo_id] smallint IDENTITY (1,1) NOT NULL ,
  [UC] varchar(4) NOT NULL,
  [descripcion_unidad_calculo] varchar(30) NOT NULL,
  [tipo_unidad_calculo_id] smallint ,
  [pax] bit ,
  [servicio_id] int ,
  [user_id] int ,
  [fecha_modificacion] datetime2(0) ,
  PRIMARY KEY ([unidad_calculo_id])
  )   ;

CREATE INDEX [unidad_calculo_id] ON unidades_calculo ([unidad_calculo_id]);
CREATE INDEX [servicio_id] ON unidades_calculo ([servicio_id]);
CREATE INDEX [tipo_unidad_calculo_id] ON unidades_calculo ([tipo_unidad_calculo_id]);
CREATE INDEX [user_id] ON unidades_calculo ([user_id]);

-- ----------------------------
-- Records of unidades_calculo
-- ----------------------------
INSERT INTO unidades_calculo VALUES ( 'SRV', 'Servicio', '1', Null, null, '2', null);
INSERT INTO unidades_calculo VALUES ( 'A', 'Adultos', '2', Null, null, '2', null);
INSERT INTO unidades_calculo VALUES ( 'N1', 'Niños 50%', '2', Null, null, '2', null);
INSERT INTO unidades_calculo VALUES ( 'N2', 'Niños Free', '2', Null, null, '2', null);
INSERT INTO unidades_calculo VALUES ( 'B', 'Bebes', '2', Null, '7', '2', null);
INSERT INTO unidades_calculo VALUES ( 'A+N', 'A+N1+N2+B', '2', Null, null, '2', null);

-- ----------------------------
-- Table structure for tipos_huesped
-- ----------------------------
--DROP TABLE IF EXISTS [tipos_huesped];
CREATE TABLE tipos_huesped (
  [tipo_huesped_id] smallint IDENTITY (1,1) NOT NULL ,
  [descripcion] varchar(30) NOT NULL,
  [Desc_corta] varchar(2) NOT NULL,
  [uc_id] smallint ,
  PRIMARY KEY ([tipo_huesped_id])
)  ;

CREATE INDEX [uc_id] ON tipos_huesped ([uc_id]);

-- ----------------------------
-- Records of tipos_huesped
-- ----------------------------
INSERT INTO tipos_huesped VALUES ( 'Adultos', 'A', '2');
INSERT INTO tipos_huesped VALUES ( 'Niños 50% (N1)', 'N1', '3');
INSERT INTO tipos_huesped VALUES ( 'Niños Free (N2)', 'N2', '4');
INSERT INTO tipos_huesped VALUES ( 'Bebes ', 'B', '5');

-- ----------------------------
-- Table structure for tipos_pension
-- ----------------------------
--DROP TABLE IF EXISTS [tipos_pension];
CREATE TABLE tipos_pension (
  [tipo_pension_id] smallint IDENTITY (1,1) NOT NULL,
  [Tipo_pension] varchar(20) NOT NULL,
  PRIMARY KEY ([tipo_pension_id])
) ;

-- ----------------------------
-- Records of tipos_pension
-- ----------------------------
INSERT INTO tipos_pension VALUES ('Solo Alojamiento');
INSERT INTO tipos_pension VALUES ('Desayuno');
INSERT INTO tipos_pension VALUES ('Media Pension');
INSERT INTO tipos_pension VALUES ('Pension Completa');
INSERT INTO tipos_pension VALUES ('Todo Incluido');

-- ----------------------------
-- Table structure for tipos_servicio
-- ----------------------------
--DROP TABLE IF EXISTS [tipos_servicio];
CREATE TABLE tipos_servicio (
  [tipo_servicio_id] smallint IDENTITY (1,1) NOT NULL ,
  [nombre_tipo_servicio] varchar(30) NOT NULL,
  PRIMARY KEY ([tipo_servicio_id])
)  ;

-- ----------------------------
-- Records of tipos_servicio
-- ----------------------------
INSERT INTO tipos_servicio VALUES ('Habitación');
INSERT INTO tipos_servicio VALUES ('Pensión');
INSERT INTO tipos_servicio VALUES ('Otros');
INSERT INTO tipos_servicio VALUES ('Extras F&B');
INSERT INTO tipos_servicio VALUES ('Galas');
INSERT INTO tipos_servicio VALUES ('Gastos');
INSERT INTO tipos_servicio VALUES ('Depósitos');


-- ----------------------------
-- Table structure for tipo_aplicacion_oferta
-- ----------------------------
--DROP TABLE IF EXISTS [tipo_aplicacion_oferta];
CREATE TABLE tipo_aplicacion_oferta (
  [tipo_aplicacion_oferta_id] varchar(1)  NOT NULL,
  [aplicable_segun_fecha_de] varchar(15) NOT NULL,
  PRIMARY KEY ([tipo_aplicacion_oferta_id])
) ;

-- ----------------------------
-- Records of tipo_aplicacion_oferta
-- ----------------------------
INSERT INTO tipo_aplicacion_oferta VALUES ('E', 'Estancia');
INSERT INTO tipo_aplicacion_oferta VALUES ('L', 'LLegadas');

-- ----------------------------
-- Table structure for comunidades_autonomas
-- ----------------------------
--DROP TABLE IF EXISTS [comunidades_autonomas];
CREATE TABLE comunidades_autonomas (
  [comunidad_id] smallint IDENTITY (1,1) NOT NULL,
  [nacion_id] smallint ,
  [comunidad_autonoma] varchar(50) ,
  [comunidad_autonoma_ista] varchar(5) ,
  PRIMARY KEY ([comunidad_id])
)  ;

CREATE INDEX [nacion_id] ON comunidades_autonomas ([nacion_id]);

-- ----------------------------
-- Records of comunidades_autonomas
-- ----------------------------
INSERT INTO comunidades_autonomas VALUES ('1', 'Andalucia', null);
INSERT INTO comunidades_autonomas VALUES ('1', 'Aragon', null);
INSERT INTO comunidades_autonomas VALUES ('1', 'Asturias', null);
INSERT INTO comunidades_autonomas VALUES ('1', 'Baleares', 'ES530');
INSERT INTO comunidades_autonomas VALUES ('1', 'Canarias', null);
INSERT INTO comunidades_autonomas VALUES ('1', 'Cantabria', null);
INSERT INTO comunidades_autonomas VALUES ('1', 'Castilla y Leon', null);
INSERT INTO comunidades_autonomas VALUES ('1', 'Castilla La Mancha', null);
INSERT INTO comunidades_autonomas VALUES ('1', 'Cataluña', null);
INSERT INTO comunidades_autonomas VALUES ('1', 'Valencia', null);
INSERT INTO comunidades_autonomas VALUES ('1', 'Extremadura', null);
INSERT INTO comunidades_autonomas VALUES ('1', 'Galicia', null);
INSERT INTO comunidades_autonomas VALUES ('1', 'Madrid', null);
INSERT INTO comunidades_autonomas VALUES ('1', 'Murcia', null);
INSERT INTO comunidades_autonomas VALUES ('1', 'Navarra', null);
INSERT INTO comunidades_autonomas VALUES ('1', 'Pais Vasco', null);
INSERT INTO comunidades_autonomas VALUES ('1', 'La Rioja', 'ES230');
INSERT INTO comunidades_autonomas VALUES ('1', 'Ceuta y Melilla', null);



-- ----------------------------
-- Table structure for provincias
-- ----------------------------
--DROP TABLE IF EXISTS [provincias];
CREATE TABLE provincias (
  [provincia_id] smallint IDENTITY (1,1) NOT NULL ,
  [provincia] varchar(30) NOT NULL,
  [comunidad_autonoma_id] smallint ,
  [nacion_id] smallint NOT NULL,
  [provincia_ista] varchar(6) ,
  [defecto_ista] smallint,
  PRIMARY KEY ([provincia_id])
)  ;

CREATE INDEX [nacion_id] ON provincias ([nacion_id]);
CREATE INDEX [comunidad_autonoma_id] ON provincias ([comunidad_autonoma_id]);

-- ----------------------------
-- Records of provincias
-- ----------------------------
INSERT INTO provincias VALUES ( 'Álava ', '16', '1', 'ES211', '0');
INSERT INTO provincias VALUES ( 'Albacete', '8', '1', 'ES421', '0');
INSERT INTO provincias VALUES ( 'Alicante ', '10', '1', 'ES521', '0');
INSERT INTO provincias VALUES ( 'Almería ', '1', '1', 'ES611', '0');
INSERT INTO provincias VALUES ( 'Asturias ', '3', '1', 'ES120', '0');
INSERT INTO provincias VALUES ( 'Ávila ', '7', '1', 'ES411', '0');
INSERT INTO provincias VALUES ( 'Badajoz ', '11', '1', 'ES431', '0');
INSERT INTO provincias VALUES ( 'Palma de Mallorca ', '4', '1', 'ES532', '0');
INSERT INTO provincias VALUES ( 'Barcelona ', '9', '1', 'ES511', '0');
INSERT INTO provincias VALUES ( 'Burgos ', '7', '1', 'ES412', '0');
INSERT INTO provincias VALUES ( 'Cáceres ', '11', '1', 'ES432', '0');
INSERT INTO provincias VALUES ( 'Cádiz ', '1', '1', 'ES612', '0');
INSERT INTO provincias VALUES ( 'Cantabria ', '6', '1', 'ES130', '0');
INSERT INTO provincias VALUES ( 'Castellón ', '10', '1', 'ES522', '0');
INSERT INTO provincias VALUES ( 'Ciudad Real ', '8', '1', 'ES422', '0');
INSERT INTO provincias VALUES ( 'Córdoba ', '1', '1', 'ES613', '0');
INSERT INTO provincias VALUES ( 'La Coruña ', '12', '1', 'ES111', '0');
INSERT INTO provincias VALUES ( 'Cuenca ', '8', '1', 'ES423', '0');
INSERT INTO provincias VALUES ( 'Gerona ', '9', '1', 'ES512', '0');
INSERT INTO provincias VALUES ( 'Granada ', '1', '1', 'ES614', '0');
INSERT INTO provincias VALUES ( 'Guadalajara ', '8', '1', 'ES424', '0');
INSERT INTO provincias VALUES ( 'Guipúzcoa ', '16', '1', 'ES212', '0');
INSERT INTO provincias VALUES ( 'Huelva ', '1', '1', 'ES615', '0');
INSERT INTO provincias VALUES ( 'Huesca ', '2', '1', 'ES241', '0');
INSERT INTO provincias VALUES ( 'Jaén ', '1', '1', 'ES616', '0');
INSERT INTO provincias VALUES ( 'León ', '7', '1', 'ES413', '0');
INSERT INTO provincias VALUES ( 'Lérida ', '9', '1', 'ES513', '0');
INSERT INTO provincias VALUES ( 'Lugo ', '12', '1', 'ES112', '0');
INSERT INTO provincias VALUES ( 'Madrid ', '13', '1', 'ES300', '0');
INSERT INTO provincias VALUES ( 'Málaga ', '1', '1', 'ES617', '0');
INSERT INTO provincias VALUES ( 'Murcia ', '14', '1', 'ES620', '0');
INSERT INTO provincias VALUES ( 'Navarra ', '15', '1', 'ES220', '0');
INSERT INTO provincias VALUES ( 'Orense ', '12', '1', 'ES113', '0');
INSERT INTO provincias VALUES ( 'Palencia ', '7', '1', 'ES414', '0');
INSERT INTO provincias VALUES ( 'Las Palmas', '5', '1', 'ES701', '1');
INSERT INTO provincias VALUES ( 'Pontevedra ', '12', '1', 'ES114', '0');
INSERT INTO provincias VALUES ( 'Logroño', '17', '1', 'ES230', '0');
INSERT INTO provincias VALUES ( 'Salamanca ', '7', '1', 'ES415', '0');
INSERT INTO provincias VALUES ( 'Santa Cruz de Tenerife ', '5', '1', 'ES702', '0');
INSERT INTO provincias VALUES ( 'Segovia ', '7', '1', 'ES416', '0');
INSERT INTO provincias VALUES ( 'Sevilla ', '1', '1', 'ES618', '0');
INSERT INTO provincias VALUES ( 'Soria ', '7', '1', 'ES417', '0');
INSERT INTO provincias VALUES ( 'Tarragona ', '9', '1', 'ES514', '0');
INSERT INTO provincias VALUES ( 'Teruel ', '2', '1', 'ES242', '0');
INSERT INTO provincias VALUES ( 'Toledo ', '8', '1', 'ES425', '0');
INSERT INTO provincias VALUES ( 'Valencia ', '10', '1', 'ES523', '0');
INSERT INTO provincias VALUES ( 'Valladolid ', '7', '1', 'ES418', '0');
INSERT INTO provincias VALUES ( 'Vizcaya ', '16', '1', 'ES213', '0');
INSERT INTO provincias VALUES ( 'Zamora ', '7', '1', 'ES419', '0');
INSERT INTO provincias VALUES ( 'Zaragoza ', '2', '1', 'ES243', '0');
INSERT INTO provincias VALUES ( 'Ceuta', '18', '1', 'ES630', '0');
INSERT INTO provincias VALUES ( 'Melilla', '18', '1', 'ES640', '0');
INSERT INTO provincias VALUES ( 'N/A', null, '20', null, '0');

-- ----------------------------
-- Table structure for conceptos_acelerador_reservas
-- ----------------------------
--DROP TABLE IF EXISTS [conceptos_acelerador_reservas];
CREATE TABLE conceptos_acelerador_reservas (
  [concepto_acelerador_id] smallint NOT NULL,
  [concepto] varchar(15) NOT NULL,
  PRIMARY KEY ([concepto_acelerador_id])
)  ;

-- ----------------------------
-- Records of conceptos_acelerador_reservas
-- ----------------------------
INSERT INTO conceptos_acelerador_reservas VALUES ('1', 'Tipo Habitacion');
INSERT INTO conceptos_acelerador_reservas VALUES ('2', 'Pension');
INSERT INTO conceptos_acelerador_reservas VALUES ('99', 'Pax');

-- ----------------------------
-- Table structure for empresas
-- ----------------------------
--DROP TABLE IF EXISTS [empresas];
CREATE TABLE empresas (
  [empresa_id] smallint IDENTITY (1,1) NOT NULL ,
  [empresa] varchar(40) NOT NULL,
  [empresa_contable] varchar(5) ,
  [direccion] varchar(50) ,
  [poblacion] varchar(50) ,
  [zip] varchar(5) ,
  [provincia_id] smallint ,
  [telefono] varchar(20) ,
  [fax] varchar(20) ,
  [cif] varchar(20) ,
  [ruta_ficheros] varchar(max),
  PRIMARY KEY ([empresa_id])
)  ;

CREATE INDEX [provincia_id] ON empresas ([provincia_id]);

-- ----------------------------
-- Records of empresas
-- ----------------------------
INSERT INTO empresas VALUES ('EMPRESA HOTELES 1', '889', 'Su dirección', 'Menorca', '43010', '8', '+34.902.109.704', '+34.928.229.290', 'B-35809789', 'D:\geshotelfiles\ficheros_contables');
INSERT INTO empresas VALUES ('EMPRESA PRUEBAS 1', '888', 'Ctra. Del Centro 1', 'Las Palmas de GC', '01001', '1', '+34.928.11.11.22', null, 'H-12345678', null);

-- ----------------------------
-- Table structure for estados_facturas
-- ----------------------------
--DROP TABLE IF EXISTS [estados_facturas];
CREATE TABLE estados_facturas (
  [estado_factura_id] smallint  NOT NULL,
  [descripcion] varchar(255) ,
  [es_error] smallint ,
  PRIMARY KEY ([estado_factura_id])
) ;

-- ----------------------------
-- Records of estados_facturas
-- ----------------------------
INSERT INTO estados_facturas VALUES ('0','Creada', '1');
INSERT INTO estados_facturas VALUES ('1','Actualizada', '0');
INSERT INTO estados_facturas VALUES ('2','Contabilizada', '0');

-- ----------------------------
-- Table structure for formas_de_pago
-- ----------------------------
-- DROP TABLE IF EXISTS [formas_de_pago];
CREATE TABLE formas_de_pago (
  [forma_pago_id] smallint IDENTITY (1,1) NOT NULL ,
  [forma_pago] varchar(20) NOT NULL,
  [credito] bit ,
  [sw_efectivo] bit ,
  [sw_tarjeta] bit ,
  [tarjeta_length] varchar(20) ,
  [tarjeta_prefixes] varchar(40) ,
  [tarjeta_checkdigit] bit ,
  [sw_dingus] bit ,
  [produccion_tpv] bit ,
  PRIMARY KEY ([forma_pago_id])
)  ;

-- ----------------------------
-- Records of formas_de_pago
-- ----------------------------
INSERT INTO formas_de_pago VALUES ('Contado', null, null, null, null, null, null, Null, Null);
INSERT INTO formas_de_pago VALUES ('Credito', null, null, null, null, null, null, Null, Null);
INSERT INTO formas_de_pago VALUES ('Transferencia', Null, Null, null, null, null, null, Null, Null);
INSERT INTO formas_de_pago VALUES ('Visa', Null, Null, Null, '13,16', '4', Null, Null, Null);
INSERT INTO formas_de_pago VALUES ('MasterCard', Null, Null, Null, '16', '51,52,53,54,55', Null, Null, Null);
INSERT INTO formas_de_pago VALUES ('4B', Null, Null, Null, null, null, null, Null, Null);
INSERT INTO formas_de_pago VALUES ('Visa TPV Virtual', Null, Null, Null, null, null, null, Null, Null);
INSERT INTO formas_de_pago VALUES ('AMEX', Null, Null, null, null, null, null, Null, Null);
INSERT INTO formas_de_pago VALUES ('Cta Casa Propiedad', Null, Null, null, null, null, null, Null, Null);
INSERT INTO formas_de_pago VALUES ('Cta Casa Direccion', Null, Null, null, null, null, null, Null, Null);
INSERT INTO formas_de_pago VALUES ('Cta Casa Animacion', Null, Null, null, null, null, null, Null, Null);

-- ----------------------------
-- Table structure for frecuencia_facturacion
-- ----------------------------
--DROP TABLE IF EXISTS [frecuencia_facturacion];
CREATE TABLE frecuencia_facturacion (
  [frecuencia_id] smallint IDENTITY (1,1) NOT NULL ,
  [descripcion_corta] varchar(3) NOT NULL,
  [descripcion] varchar(30) NOT NULL,
  PRIMARY KEY ([frecuencia_id])
)  ;

-- ----------------------------
-- Records of frecuencia_facturacion
-- ----------------------------
INSERT INTO frecuencia_facturacion VALUES ('1V', 'Una Vez');
INSERT INTO frecuencia_facturacion VALUES ('DIA', 'Diario');
INSERT INTO frecuencia_facturacion VALUES ('RSV', 'Reserva');

-- ----------------------------------------------------
-- Table structure for frecuencia_tipos_imputacion
-- ----------------------------------------------------
--DROP TABLE IF EXISTS [frecuencia_tipos_imputacion];
CREATE TABLE frecuencia_tipos_imputacion (
  [frecuencia_id] smallint  NOT NULL,
  [tipo_imputacion_id] smallint NOT NULL,
  PRIMARY KEY ([frecuencia_id],[tipo_imputacion_id])
) ;

CREATE INDEX [tipo_imputacion_id] ON frecuencia_tipos_imputacion ([tipo_imputacion_id]);

-- ----------------------------
-- Records of frecuencia_tipos_imputacion
-- ----------------------------
INSERT INTO frecuencia_tipos_imputacion VALUES ('2', '4');
INSERT INTO frecuencia_tipos_imputacion VALUES ('1', '1');
INSERT INTO frecuencia_tipos_imputacion VALUES ('3', '1');
INSERT INTO frecuencia_tipos_imputacion VALUES ('1', '2');
INSERT INTO frecuencia_tipos_imputacion VALUES ('3', '2');
INSERT INTO frecuencia_tipos_imputacion VALUES ('3', '3');

-- ----------------------------
-- Table structure for grupos_de_cliente
-- ----------------------------
--DROP TABLE IF EXISTS [grupos_de_cliente];
CREATE TABLE grupos_de_cliente (
  [grupo_cliente_id] smallint IDENTITY (1,1) NOT NULL ,
  [nombre_grupo] varchar(30) NOT NULL,
  [huesped] bit,
  [contratos] bit,
  [facturar] bit,
  [agencia] bit,
  [perfil] smallint,
  PRIMARY KEY ([grupo_cliente_id])
)  ;

CREATE INDEX [huesped] ON grupos_de_cliente ([huesped]);

-- ----------------------------
-- Records of grupos_de_cliente
-- ----------------------------
INSERT INTO grupos_de_cliente VALUES ('Agencias', Null, Null, Null, Null, '800');
INSERT INTO grupos_de_cliente VALUES ('Contratos', Null, Null, Null, Null, '800');
INSERT INTO grupos_de_cliente VALUES ('Empresas', Null, Null, Null, Null, '600');
INSERT INTO grupos_de_cliente VALUES ('Huespedes', Null, Null, Null, Null, '600');

-- ----------------------------
-- Table structure for grupos_de_servicios
-- ----------------------------
--DROP TABLE IF EXISTS [grupos_de_servicios];
CREATE TABLE grupos_de_servicios (
  [grupo_servicio_id] int IDENTITY (1,1) NOT NULL ,
  [nombre_grupo] varchar(255) NOT NULL,
  [cta_contable] varchar(16) NOT NULL,
  PRIMARY KEY ([grupo_servicio_id])
)  ;

-- ----------------------------
-- Records of grupos_de_servicios
-- ----------------------------
INSERT INTO grupos_de_servicios VALUES ('Alojamiento', '705');
INSERT INTO grupos_de_servicios VALUES ('Pension', '7051');
INSERT INTO grupos_de_servicios VALUES ('Extras F&B', '7052');


-- ----------------------------
-- Table structure for grupos_oferta
-- ----------------------------
--DROP TABLE IF EXISTS [grupos_oferta];
CREATE TABLE grupos_oferta (
  [grupo_oferta_id] smallint IDENTITY (1,1) NOT NULL,
  [grupo_oferta] varchar(20) NOT NULL,
  PRIMARY KEY ([grupo_oferta_id])
)  ;

-- ----------------------------
-- Records of grupos_oferta
-- ----------------------------
INSERT INTO grupos_oferta VALUES ('Galas');
INSERT INTO grupos_oferta VALUES ('Early Booking');
INSERT INTO grupos_oferta VALUES ('NxM');
INSERT INTO grupos_oferta VALUES ('Descuento numero Pax');
INSERT INTO grupos_oferta VALUES ('Descuentos Niños');

-- ----------------------------
-- Table structure for hoteles
-- ----------------------------
--DROP TABLE IF EXISTS [hoteles];
CREATE TABLE hoteles (
  [hotel_id] smallint IDENTITY (1,1) NOT NULL ,
  [hotel] varchar(50) NOT NULL,
  [empresa_id] smallint NOT NULL,
  [tipo_hotel_id] smallint NOT NULL,
  [categoria_id] smallint NOT NULL,
  [nombre_corto] varchar(6) ,
  [direccion] varchar(50) ,
  [poblacion] varchar(50) ,
  [zip] varchar(5) ,
  [provincia_id] smallint NOT NULL,
  [nacion_id] smallint NOT NULL,
  [telefono] varchar(20) ,
  [fax] varchar(20) ,
  [cta_manocorriente] varchar(16) ,
  [dpto_contable] varchar(5) ,
  [cta_contable_cajas] varchar(16) ,
  [cta_contable_banco] varchar(16) ,
  [fecha_inicio_programa] date ,
  [ruta_fichero_policia] varchar(512) ,
  [contador_fichero_policia] int ,
  [identificador_fichero_policia] varchar(10) ,
  [email_reservas] varchar(100) ,
  [email_ventas] varchar(100) ,
  [email_smtp] varchar(100) ,
  [texto_cancelacion] varchar(max),
  [usuario_ista] varchar(max),
  [password_ista] varchar(max),
  [url_ista] varchar(max),
  [municipio_ista] varchar(max),
  [numero_registro_ista] int ,
  [ruta_bavel] varchar(100) ,
  [dingus_usuario] varchar(20) ,
  [dingus_password] varchar(20) ,
  [dingus_hotel_code] varchar(10) ,
  [dingus_traductor] varchar(10) ,
  [dingus_url] varchar(255) ,
  [checkin_on_line] smallint check ([checkin_on_line] > 0) NOT NULL,
  [minimo_dias_checkin_online] smallint ,
  [zoom_mapa] smallint ,
  [lat] decimal(18,15) ,
  [lng] decimal(18,15) ,
  [ancho] smallint ,
  [alto] smallint ,
  [overbooking_limit] float ,
  PRIMARY KEY ([hotel_id])
)  ;

CREATE INDEX [fk_empresas] ON hoteles ([empresa_id]);
CREATE INDEX [fk_provincia] ON hoteles ([provincia_id]);
CREATE INDEX [fk_nacion_id] ON hoteles ([nacion_id]);
CREATE INDEX [tipo_hotel_id] ON hoteles ([tipo_hotel_id]);
CREATE INDEX [categoria_id] ON hoteles ([categoria_id]);

-- ----------------------------
-- Records of hoteles
-- ----------------------------
INSERT INTO hoteles VALUES ('HOTEL 1', '1', '1', '4', 'PM', 'Urb. Castillo del Águila S/N', 'Playa Blanca, Yaiza. Lanzarote', '35580', '35', '1', '(+34) 928 518 196', '(+34) 928 519 099', '4309999', '000', '5700000', '5201004921', '2009-12-06', 'c:/temp/policia/pm/', '1914', '35987PLA02', 'webpm@hdhotels.com', 'webpm@hdhotels.com', 'correo', '* Precios válidos para reservas individuales exclusivamente, no aplicables a grupos y/o eventos especiales.', null, null, null, 'LAS PALMAS', '1', 'C:\catanet_net_client\db_hd_hoteles\erp\outbox\', 'servicioshd', 'srvcshd', '1', 'HD', 'http://hd.dingus-services.com/services/tazzy/convertedbookingservice.asmx', '1', '3', '18', '28.860337000000000', '-13.815987000000000', '500', '500', '99');
INSERT INTO hoteles VALUES ('HOTEL 2', '1', '2', '3', 'PCGC', 'C/ Holanda s/n', ' Playa del Inglés, San Bartolomé de Tirajana', '35100', '35', '1', '(+34) 928 774 116 ', '(+34) 928 761 152', '4309998', '000', '5700005', '5201004921', '2009-11-01', 'c:/temp/policia/pcgc/', '1013', '35552AAABU', 'webpcgc@hdhotels.com', 'webpcgc@hdhotels.com', 'correo', '* Precios válidos para reservas individuales exclusivamente, no aplicables a grupos y/o eventos especiales.', null, null, null, 'LAS PALMAS', '1779', 'C:\catanet_net_client\db_hd_hoteles\erp\outbox\', 'servicioshd', 'srvcshd', '2', 'PCGC', 'http://hd.dingus-services.com/services/tazzy/convertedbookingservice.asmx?wsdl', '1', '3', '17', '27.761752352202550', '-15.581848025321960', '600', '200', '99');
INSERT INTO hoteles VALUES ('HOTEL 3', '1', '2', '3', 'PCTF', 'Avda. Rafael Puig Llivina, 7 ', ' Playa de las Américas, Arona. Tenerife', '38660', '39', '1', '(+34) 922 790 874', '(+34) 922 790 313 ', '4309997', '000', '5700014', '5201004921', '2010-05-01', 'c:/temp/policia/pctf/', '772', '38001AAA1F', 'webpctf@hdhotels.com', 'webctf@hdhotels.com', 'correo', '* Oferta sujeta a un cupo limitado de habitaciones. El precio y las condiciones ofrecidas podrán ser diferentes en cada momento, incluso si solicita las mismas fechas. En caso de modificar reserva, compruebe siempre el nuevo precio aplicado antes de confirmar los cambios.', null, null, null, 'TENERIFE', '1', 'C:\catanet_net_client\db_hd_hoteles\erp\outbox\', 'servicioshd', 'srvcshd', '3', 'PCTF', 'http://hd.dingus-services.com/services/tazzy/convertedbookingservice.asmx', '1', '3', '18', '28.060273000000000', '-16.731324000000000', '600', '500', '99');
INSERT INTO hoteles VALUES ('HOTEL 4', '1', '1', '4', 'BR', 'Avda Islas Canarias s/n', 'Costa Teguisa', '35509', '35', '1', '(+34) 928 826 077', '(+34) 928 346 043', '4309996', '000', '5700000', '5201004921', '2010-07-01', 'c:/temp/policia/beach_resort/', '1577', '35697AAH08', 'webbeachresort@hdhotels.com', 'webbeachresort@hdhotels.com', 'correo', '* Oferta sujeta a un cupo limitado de habitaciones. El precio y las condiciones ofrecidas podrán ser diferentes en cada momento, incluso si solicita las mismas fechas. En caso de modificar reserva, compruebe siempre el nuevo precio aplicado antes de confirmar los cambios.', null, null, null, 'LAS PALMAS', '1779', 'C:\catanet_net_client\db_hd_hoteles\erp\outbox\', 'servicioshd', 'srvcshd', '4', 'HDBR', 'http://hd.dingus-services.com/services/tazzy/convertedbookingservice.asmx', '1', '3', '18', '29.002515000000000', '-13.482632000000000', '550', '550', '99');

-- ----------------------------
-- Table structure for impuestos
-- ----------------------------
--DROP TABLE IF EXISTS [impuestos];
CREATE TABLE impuestos (
  [impuesto_id] smallint IDENTITY (1,1) NOT NULL,
  [empresa_id] smallint NOT NULL,
  [impuesto] varchar(30) NOT NULL,
  [porcentaje] float NOT NULL,
  [cta_contable] varchar(15) ,
  [activo_geshotel] smallint,
  [user_id] smallint ,
  [fecha_actualizacion] datetime2(0) ,
  PRIMARY KEY ([impuesto_id])
)  ;

-- ----------------------------
-- Records of impuestos
-- ----------------------------
INSERT INTO impuestos VALUES ( '1', 'Exento', '0', null, '0', '2', '2008-03-03 00:00:00');
INSERT INTO impuestos VALUES ( '1', 'Alimentos', '3', null, '0', '2', '2015-04-17 00:00:00');
INSERT INTO impuestos VALUES ( '1', 'General', '7', null, '0', '2', '2015-04-17 00:00:00');
INSERT INTO impuestos VALUES ( '1', 'Bebidas Alcohólicas', '13.5', null, '0', '2', '2015-04-17 00:00:00');
INSERT INTO impuestos VALUES ( '1', 'Tabaco Negro', '20', null, '0', '2', '2008-03-03 00:00:00');
INSERT INTO impuestos VALUES ( '1', 'Tabaco Rubio', '35', null, '0', '2', '2008-03-03 00:00:00');
INSERT INTO impuestos VALUES ( '2', 'Exento', '0', null, '0', '1', '2010-05-18 00:00:00');
INSERT INTO impuestos VALUES ( '2', '7%', '7', null, '0', '2', '2012-07-24 00:00:00');
INSERT INTO impuestos VALUES ( '4', 'EXENTO', '0', '1111111', '0', '2', '2011-12-05 00:00:00');
INSERT INTO impuestos VALUES ( '4', 'IGIC 7%', '7', '1111111', '1', '2', '2012-07-24 00:00:00');
INSERT INTO impuestos VALUES ( '4', 'IGIC 2%', '2', '1111111', '0', '2', '2011-12-05 00:00:00');
INSERT INTO impuestos VALUES ( '2', '3%', '3', null, '0', '2', '2012-07-26 00:00:00');


-- ----------------------------
-- Table structure for reserva_estados
-- ----------------------------
--DROP TABLE IF EXISTS [reserva_estados];
CREATE TABLE reserva_estados (
  [estado_reserva_id] smallint IDENTITY (1,1) NOT NULL,
  [estado] varchar(20) NOT NULL,
  [es_error_fechaini] smallint NOT NULL,
  [es_error_fechafin] smallint NOT NULL,
  PRIMARY KEY ([estado_reserva_id])
) ;

-- ----------------------------
-- Records of reserva_estados
-- ----------------------------
INSERT INTO reserva_estados VALUES ( 'Pen.Fin', '1', '1');
INSERT INTO reserva_estados VALUES ( 'Pen.Entrar', '1', '1');
INSERT INTO reserva_estados VALUES ( 'Anulada', '0', '0');
INSERT INTO reserva_estados VALUES ( 'Check-in', '0', '1');
INSERT INTO reserva_estados VALUES ( 'Check-out', '1', '1');
INSERT INTO reserva_estados VALUES ( 'Facturado', '0', '0');
INSERT INTO reserva_estados VALUES ( 'No Show', '0', '0');

-- ----------------------------
-- Table structure for series
-- ----------------------------
--DROP TABLE IF EXISTS [series];
CREATE TABLE series (
  [serie_id] smallint IDENTITY (1,1) NOT NULL,
  [descripcion] varchar(20) NOT NULL,
  [abreviatura] varchar(4) NOT NULL,
  [manocorriente] smallint ,
  [visible] smallint ,
  [factura] smallint ,
  [deposito] smallint ,
  [servicio_id] int ,
  [impuesto_id] int ,
  [voxel] smallint ,
  PRIMARY KEY ([serie_id])
) ;

-- ----------------------------
-- Records of series
-- ----------------------------
INSERT INTO series VALUES ( 'Factura', 'FACT', '1', '1', '1', '0', null, null, '2');
INSERT INTO series VALUES ( 'Rectificativa', 'RECT', '1', '1', '1', '0', null, null, '0');
INSERT INTO series VALUES ( 'Ticket', 'TICK', '1', '1', '1', '0', null, null, '0');
INSERT INTO series VALUES ( 'Deposito', 'DEP', '0', '1', '0', '1', '69', '1', '0');
INSERT INTO series VALUES ( 'Anticipo', 'ANT', '0', '1', '0', '0', '66', '6', '0');
INSERT INTO series VALUES ( 'Descuento', 'DES', '0', '1', '0', '0', '65', '1', '0');
INSERT INTO series VALUES ( 'Descuento', 'DES', '0', '0', '0', '0', '65', '1', '0');
INSERT INTO series VALUES ( 'Gastos', 'GAST', '0', '1', '0', '0', null, null, '0');
INSERT INTO series VALUES ( 'Rectificativas 1', 'RECT', '1', '1', '1', '0', null, null, '2');


-- ----------------------------
-- Table structure for sexos
-- ----------------------------
--DROP TABLE IF EXISTS [sexos];
CREATE TABLE sexos (
  [sexo_id] char(1) NOT NULL,
  [sexo] varchar(20) NOT NULL,
  PRIMARY KEY ([sexo_id])
) ;

-- ----------------------------
-- Records of sexos
-- ----------------------------
INSERT INTO sexos VALUES ('F', 'Female');
INSERT INTO sexos VALUES ('M', 'Male');

-- ----------------------------
-- Table structure for tipos_condicion
-- ----------------------------
-- DROP TABLE IF EXISTS [tipos_condicion];
CREATE TABLE tipos_condicion (
  [tipo_condicion_id] smallint IDENTITY (1,1) NOT NULL ,
  [condicion] varchar(2) NOT NULL,
  [literal] varchar(15) ,
  PRIMARY KEY ([tipo_condicion_id])
)  ;

-- ----------------------------
-- Records of tipos_condicion
-- ----------------------------
INSERT INTO tipos_condicion VALUES ( '=', 'La unidad N es');
INSERT INTO tipos_condicion VALUES ('>', 'Para mas de N');
INSERT INTO tipos_condicion VALUES ('>=', 'Para N o mas');
INSERT INTO tipos_condicion VALUES ('<', 'Para menos de N');
INSERT INTO tipos_condicion VALUES ('<=', 'Para N o menos');
INSERT INTO tipos_condicion VALUES ('==', 'Al N es');


-- ----------------------------
-- Table structure for tipos_de_oferta
-- ----------------------------
--DROP TABLE IF EXISTS [tipos_de_oferta];
CREATE TABLE tipos_de_oferta (
  [tipo_oferta_id] smallint IDENTITY (1,1) NOT NULL,
  [Oferta] varchar(25) NOT NULL,
  [permitir_m_mayor_que_n] smallint ,
  [rejilla] smallint,
  [Observaciones] varchar(100) ,
  [orden_aplicacion] smallint ,
  PRIMARY KEY ([tipo_oferta_id])
) ;

-- ----------------------------
-- Records of tipos_de_oferta
-- ----------------------------
INSERT INTO tipos_de_oferta VALUES ('n X m', '0', '0', 'Oferta tipo 2x1 implica que cada “n” unidades cobramos “m” de forma repetitiva', '1');
INSERT INTO tipos_de_oferta VALUES ('La ud. n y +,  m% dto', '1', '0', 'Las primeras “n-1” udes a precio normal. Despues aplicar “m%” descuento', '1');
INSERT INTO tipos_de_oferta VALUES ('La ud. n y +, m% inc.', '1', '0', 'Las primeras “n” udes a precio normal. Despues aplicar “m%” recargo', '1');
INSERT INTO tipos_de_oferta VALUES ('La ud. n y +, a m €', '1', '0', 'Las primeras “n” udes a precio normal. Despues aplicar el precio “m”', '0');
INSERT INTO tipos_de_oferta VALUES ('Menos de n, m% inc.', '1', '0', 'Hacer un “m%” de incremento a todas las unidades si hay menos unidades que lo que indica “n”', '1');
INSERT INTO tipos_de_oferta VALUES ('Menos de n, m% dto.', '1', '0', 'Hacer un “m%” de descuento a todas las unidades Si hay menos unidades que lo que indica “n”', '1');
INSERT INTO tipos_de_oferta VALUES ('Mas de n, m% dto', '1', '0', 'Hacer un “m”% de descuento a todo Si hay más unidades que lo que indica “n”', '1');
INSERT INTO tipos_de_oferta VALUES ('Mas de n, m% inc.', '1', '0', 'Hacer un “m”% de incremento a todo Si hay más unidades que lo que indica “n”', '1');
INSERT INTO tipos_de_oferta VALUES ('Mas de n, a m €', '1', '0', 'Aplicar el precio “m” a todas las unidades Si hay más unidades que lo que indica “n”', '0');
INSERT INTO tipos_de_oferta VALUES ('n uds m a % dto.', '1', '0', 'Si hay n  unidades tienen un m% de descuento.', '1');
INSERT INTO tipos_de_oferta VALUES ('n uds a m% inc.', '1', '0', 'Si hay n unidades tienen un m% de incremento.', '1');
INSERT INTO tipos_de_oferta VALUES ('n uds a m €', '1', '0', 'Las n primeras unidades se facturan a m €, el resto al precio normal.', '0');
INSERT INTO tipos_de_oferta VALUES ('Rejilla unidades', '1', '1', 'Tabla de Unidades a precios o porcentajes que se aplican', '1');
INSERT INTO tipos_de_oferta VALUES ('mas de n ,a m € inc/dec', '1', '0', 'Hacer un m de desc/inc euros a todo Si hay más unidades que lo que indica “n”', '1');
INSERT INTO tipos_de_oferta VALUES ('mas de n ,a n*m € inc/dec', '1', '0', 'Hacer un n*m de desc/inc euros a todo Si hay más unidades que lo que indica “n”', '1');
INSERT INTO tipos_de_oferta VALUES ('menos de n ,a m € inc/dec', '1', '0', 'Hacer un m de desc/inc euros a todo Si hay menos unidades que lo que indica “n”', '1');
INSERT INTO tipos_de_oferta VALUES ('menos de n ,a n*m € inc/d', '1', '0', 'Hacer un n*m de desc/inc euros a todo Si hay menos unidades que lo que indica “n”', '1');
INSERT INTO tipos_de_oferta VALUES ('La ud. n y -,  m% dto', '1', '0', 'Las primeras “n" unidades aplica un % descuento', '1');
INSERT INTO tipos_de_oferta VALUES ('La ud. n y -, a m €', '1', '0', 'Las primeras “n" unidades aplica un precio', '1');

-- ----------------------------
-- Table structure for tipos_de_tarjeta
-- ----------------------------
--DROP TABLE IF EXISTS [tipos_de_tarjeta];
CREATE TABLE tipos_de_tarjeta (
  [tipo_tarjeta_id] smallint IDENTITY (1,1) NOT NULL ,
  [tipo_tarjeta] varchar(15) ,
  [tarjeta_length] varchar(20) ,
  [tarjeta_prefixes] varchar(40) ,
  [tarjeta_checkdigit] smallint ,
  PRIMARY KEY ([tipo_tarjeta_id])
)  ;

-- ----------------------------
-- Records of tipos_de_tarjeta
-- ----------------------------
INSERT INTO tipos_de_tarjeta VALUES ( 'VISA/Matercard', '13,16', '4,51,52,53,54,55', '1');
INSERT INTO tipos_de_tarjeta VALUES ('Maestro', '12,13,14,15,16,18,19', '5018,5020,5038,6304,6759,6761', '1');

-- ----------------------------
-- Table structure for tipos_documento
-- ----------------------------
--DROP TABLE IF EXISTS [tipos_documento];
CREATE TABLE tipos_documento (
  [tipo_documento_id] char(1)  NOT NULL,
  [tipo_documento] varchar(15) ,
  PRIMARY KEY ([tipo_documento_id])
) ;

-- ----------------------------
-- Records of tipos_documento
-- ----------------------------
INSERT INTO tipos_documento VALUES ('C', 'CIF');
INSERT INTO tipos_documento VALUES ('D', 'DNI');
INSERT INTO tipos_documento VALUES ('N', 'NIF');
INSERT INTO tipos_documento VALUES ('P', 'Passport');


-- ----------------------------
-- Table structure for servicios
-- ----------------------------
--DROP TABLE IF EXISTS [servicios];
CREATE TABLE servicios (
  [servicio_id] int IDENTITY (1,1) NOT NULL,
  [nombre_servicio] varchar(50) NOT NULL,
  [abreviatura] varchar(6) NOT NULL,
  [tipo_servicio_id] smallint NOT NULL,
  [sw_produccion] bit ,
  [sw_descuento] bit ,
  [sw_ajustes] bit ,
  [sw_gastos] bit ,
  [sw_pension] bit ,
  [sw_rectificativa] bit ,
  [tipo_unidad_calculo_id] smallint ,
  [concepto_acelerador_reservas_id] smallint ,
  [costo] float ,
  [suma_servicio_id] int ,
  [resta_servicio_id] int ,
  [user_id] int ,
  [fecha_modificacion] datetime2(0) ,
  [tipo_hab] smallint ,
  [tipo_pension] smallint ,
  PRIMARY KEY ([servicio_id])
)  ;

CREATE INDEX [tipo_servicio_id] ON servicios ([tipo_servicio_id]);
CREATE INDEX [servicio_id] ON servicios ([concepto_acelerador_reservas_id]);
CREATE INDEX [tipo_unidad_calculo_id] ON servicios ([tipo_unidad_calculo_id]);
CREATE INDEX [tipo_hab] ON servicios ([tipo_hab]);

-- ----------------------------
-- Records of servicios
-- ----------------------------
INSERT INTO servicios VALUES ('Alojamiento B1', 'A1', '1', Null, Null, Null, Null, Null, Null, '2', '99', null, null, null, '1', '2008-12-10 00:00:00', '1', null);
INSERT INTO servicios VALUES ('Desayuno', 'HD', '2', Null, Null, Null, Null, Null, Null, '2', '2', null, null, null, '1', '2009-02-02 00:00:00', null, '1');
INSERT INTO servicios VALUES ('Media Pension', 'MP', '2', Null, Null, Null, Null, Null, Null, '2', '2', null, null, null, '2', '2011-03-11 00:00:00', null, '2');
INSERT INTO servicios VALUES ('Todo Incluido', 'TI', '2', Null, Null, Null, Null, Null, Null, '2', '2', null, null, null, '1', '2011-08-17 00:00:00', null, '4');
INSERT INTO servicios VALUES ('Todo Incluido Bebidas', 'TIB', '2', Null, Null, Null, Null, Null, Null, '2', '2', null, null, null, '7', null, null, '4');
INSERT INTO servicios VALUES ('Alojamiento B2', 'A2', '1', Null, Null, Null, Null, Null, Null, '2', '99', null, null, null, '7', '2015-08-24 00:00:00', '2', null);
INSERT INTO servicios VALUES ('Cunas', 'CUN', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', null, null, null);
INSERT INTO servicios VALUES ('Gala Navidad HD', 'GNHD', '5', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '7', null, null, null);
INSERT INTO servicios VALUES ('Gala Fin de Año', 'GF', '5', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '7', '2015-01-14 00:00:00', null, null);
INSERT INTO servicios VALUES ('Bungalow 1 Dormitorio', 'B1', '1', Null, Null, Null, Null, Null, Null, '1', '1', null, null, null, '7', null, '1', null);
INSERT INTO servicios VALUES ('Bungalow 2 Dormitorios', 'B2', '1', Null, Null, Null, Null, Null, Null, '1', '1', null, null, null, '7', null, '2', null);
INSERT INTO servicios VALUES ('Bar Piscina 1 Comidas', 'BP1C', '4', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', null, null, null);
INSERT INTO servicios VALUES ('Bar Piscina 1 Bebidas', 'BP1B', '4', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', null, null, null);
INSERT INTO servicios VALUES ('Bar Salon Bebidas', 'BSB', '4', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', null, null, null);
INSERT INTO servicios VALUES ('Bar Piscina 2 Comidas ', 'BP2C', '4', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', null, null, null);
INSERT INTO servicios VALUES ('Bar Piscina 2 Bebidas ', 'BP2B', '4', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', null, null, null);
INSERT INTO servicios VALUES ('Bar Restaurante Bebidas', 'BRB', '4', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2013-07-29 00:00:00', null, null);
INSERT INTO servicios VALUES ('Bar Restaurante Comidas', 'BRC', '4', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2014-10-07 00:00:00', null, null);
INSERT INTO servicios VALUES ('Gala Navidad', 'GN', '5', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '7', null, null, null);
INSERT INTO servicios VALUES ('Gala Fin de Año HD', 'GFHD', '5', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '7', null, null, null);
INSERT INTO servicios VALUES ('Habitacion Overbooking', 'HAOVB', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-01-21 00:00:00', null, null);
INSERT INTO servicios VALUES ('Alquiler de Sombrilla', 'ALQSO', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-01-21 00:00:00', null, null);
INSERT INTO servicios VALUES ('Cabinas Telefonicas', 'CABTF', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-01-21 00:00:00', null, null);
INSERT INTO servicios VALUES ('Divisa', 'DIVIS', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-01-21 00:00:00', null, null);
INSERT INTO servicios VALUES ('Exposiciones y Desfiles', 'EXPOS', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '37', '2015-05-12 00:00:00', null, null);
INSERT INTO servicios VALUES ('Internet', 'INTER', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-01-21 00:00:00', null, null);
INSERT INTO servicios VALUES ('Lavadoras', 'LAVAD', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-01-21 00:00:00', null, null);
INSERT INTO servicios VALUES ('Caja de Seguridad', 'SAFE', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-01-21 00:00:00', null, null);
INSERT INTO servicios VALUES ('Tabaco', 'TAB', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-01-21 00:00:00', null, null);
INSERT INTO servicios VALUES ('Telefono', 'TELEF', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-01-21 00:00:00', null, null);
INSERT INTO servicios VALUES ('Babychangingtable (Cambiador)', 'CAMBI', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-02-04 00:00:00', null, null);
INSERT INTO servicios VALUES ('Babytrolly (Carrito)', 'CARRI', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-02-04 00:00:00', null, null);
INSERT INTO servicios VALUES ('Rent a Car', 'RENT', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2013-08-07 00:00:00', null, null);
INSERT INTO servicios VALUES ('Tenis', 'TENIS', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-02-04 00:00:00', null, null);
INSERT INTO servicios VALUES ('Babychair (Trona)', 'TRONA', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-02-04 00:00:00', null, null);
INSERT INTO servicios VALUES ('Wellness Center', 'WELLN', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-02-04 00:00:00', null, null);
INSERT INTO servicios VALUES ('Wellcome Package', 'WPACK', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-02-04 00:00:00', null, null);
INSERT INTO servicios VALUES ('Alojamiento Premier', 'AP', '1', Null, Null, Null, Null, Null, Null, '2', '99', null, null, null, '1', '2009-03-04 00:00:00', '3', null);
INSERT INTO servicios VALUES ('Alojamiento Kid Suite', 'AKS', '1', Null, Null, Null, Null, Null, Null, '2', '99', null, null, null, '1', '2009-03-04 00:00:00', '4', null);
INSERT INTO servicios VALUES ('Premier', 'PRE', '1', Null, Null, Null, Null, Null, Null, '1', '1', null, null, null, '1', '2009-03-04 00:00:00', '3', null);
INSERT INTO servicios VALUES ('Kid Suite', 'KS', '1', Null, Null, Null, Null, Null, Null, '1', '1', null, null, null, '1', '2009-03-04 00:00:00', '4', null);
INSERT INTO servicios VALUES ('Pension Completa', 'PC', '2', Null, Null, Null, Null, Null, Null, '2', '2', null, null, null, '1', '2009-06-02 00:00:00', null, '3');
INSERT INTO servicios VALUES ('Varios', 'Var', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2013-03-11 00:00:00', null, null);
INSERT INTO servicios VALUES ('Upgrade de B1 a B2', 'B1AB2', '1', Null, Null, Null, Null, Null, Null, '1', null, null, '11', '10', '2', '2009-06-14 00:00:00', null, null);
INSERT INTO servicios VALUES ('Descuento Publicidad Habitacion', 'DESH', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2015-09-09 00:00:00', null, null);
INSERT INTO servicios VALUES ('Descuento Pension', 'DESP', '2', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '2', '2009-04-14 00:00:00', null, null);
INSERT INTO servicios VALUES ('Descuento Cobro', 'Desc', '3', Null, Null, Null, Null, Null, Null, '1', null, '0.00', null, null, '2', '2009-05-18 13:47:27', null, null);
INSERT INTO servicios VALUES ('Anticipo Factura', 'ANT', '3', Null, Null, Null, Null, Null, Null, '1', null, '0.00', null, null, '2', '2009-05-18 13:49:24', null, null);
INSERT INTO servicios VALUES ('Depositos', 'DEP', '7', Null, Null, Null, Null, Null, Null, '1', null, '0.00', null, null, '2', '2009-10-27 00:00:00', null, null);
INSERT INTO servicios VALUES ('Ajustes Produccion Pension', 'AJPEN', '2', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '2', '2009-05-29 00:00:00', null, null);
INSERT INTO servicios VALUES ('Ajustes Produccion Habitacion', 'AJUHA', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '2', '2009-05-29 00:00:00', null, null);
INSERT INTO servicios VALUES ('Ajustes Produccion Galas', 'AJUGA', '5', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '2', '2009-05-29 00:00:00', null, null);
INSERT INTO servicios VALUES ('Ajustes Produccion Otros', 'AJUOT', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '2', '2009-05-29 00:00:00', null, null);
INSERT INTO servicios VALUES ('Habitacion Permisos (Late check out)', 'PER', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2011-08-22 00:00:00', null, null);
INSERT INTO servicios VALUES ('Upgrade B2 A KS', 'B2AKS', '1', Null, Null, Null, Null, Null, Null, '1', null, null, '56', '11', '2', '2009-06-14 00:00:00', null, null);
INSERT INTO servicios VALUES ('Animadores', 'ANIM', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '2', '2009-06-18 00:00:00', null, null);
INSERT INTO servicios VALUES ('Upgrade MP a TI', 'MP2TI', '2', Null, Null, Null, Null, Null, Null, '2', null, null, '4', '3', '2', '2009-06-23 00:00:00', null, '4');
INSERT INTO servicios VALUES ('Persona Extra SA/día', 'CS', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '37', '2015-06-01 00:00:00', null, null);
INSERT INTO servicios VALUES ('Varios Golosinas', 'GOLOS', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-07-03 00:00:00', null, null);
INSERT INTO servicios VALUES ('Salón de Conferencias', 'CONFE', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2015-11-24 00:00:00', null, null);
INSERT INTO servicios VALUES ('Sillon de Masajes', 'SILLO', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-07-03 00:00:00', null, null);
INSERT INTO servicios VALUES ('Bisutería', 'BISUT', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-07-03 00:00:00', null, null);
INSERT INTO servicios VALUES ('Roturas', 'ROTUR', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '9', '2009-09-29 00:00:00', null, null);
INSERT INTO servicios VALUES ('Publicidad', 'PUBLI', '6', Null, Null, Null, Null, Null, Null, '1', null, '0.00', null, null, '2', '2009-07-03 10:30:02', null, null);
INSERT INTO servicios VALUES ('Luz para Tenis', 'Luz', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '2', '2009-07-08 00:00:00', null, null);
INSERT INTO servicios VALUES ('Upgrade Desayuno a TI', 'De2TI', '2', Null, Null, Null, Null, Null, Null, '2', null, null, '4', '2', '2', '2009-07-09 00:00:00', null, '4');
INSERT INTO servicios VALUES ('Upgrade Desayuno a MP', 'DE2MP', '2', Null, Null, Null, Null, Null, Null, '2', null, null, '3', '2', '2', '2009-07-09 00:00:00', null, '2');
INSERT INTO servicios VALUES ('Suplemento Gala Navidad MP (contratos)', 'GNMP', '5', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2011-12-22 00:00:00', null, null);
INSERT INTO servicios VALUES ('Suplemento Gala Navidad TI (contratos)', 'GNTI', '5', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2011-12-22 00:00:00', null, null);
INSERT INTO servicios VALUES ('Suplemento Gala Fin de Año MP (contratos)', 'GFMP', '5', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2011-12-22 00:00:00', null, null);
INSERT INTO servicios VALUES ('Suplemento Gala Fin de Año TI (contratos)', 'GFTI', '5', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2011-12-22 00:00:00', null, null);
INSERT INTO servicios VALUES ('Suite 1 Dormitorio', 'SUITE1', '1', Null, Null, Null, Null, Null, Null, '1', '1', null, null, null, '7', '2013-10-04 00:00:00', '1', null);
INSERT INTO servicios VALUES ('Suite 2 Dormitorios', 'SUITE2', '1', Null, Null, Null, Null, Null, Null, '1', '1', null, null, null, '7', '2013-10-04 00:00:00', '2', null);
INSERT INTO servicios VALUES ('Alojamiento Suite 1', 'SU1', '1', Null, Null, Null, Null, Null, Null, '2', '99', null, null, null, '7', '2013-10-04 00:00:00', '1', null);
INSERT INTO servicios VALUES ('Alojamiento Suite 2', 'SU2', '1', Null, Null, Null, Null, Null, Null, '2', '99', null, null, null, '7', '2013-10-04 00:00:00', '2', null);
INSERT INTO servicios VALUES ('Upgrade A1 a A2', 'A1UA2', '1', Null, Null, Null, Null, Null, Null, '1', null, null, '95', '94', '2', '2009-07-20 00:00:00', null, null);
INSERT INTO servicios VALUES ('Upgrade A2 a KS', 'A2UKS', '1', Null, Null, Null, Null, Null, Null, '1', null, null, '56', '95', '2', '2009-07-20 00:00:00', null, null);
INSERT INTO servicios VALUES ('Calefaccion', 'Cal', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '2', '2009-07-21 00:00:00', null, null);
INSERT INTO servicios VALUES ('Carga Partidas vivas', 'CCI', '3', Null, Null, Null, Null, Null, Null, '1', null, '0.00', null, null, '2', '2009-07-31 00:00:00', null, null);
INSERT INTO servicios VALUES ('Comisión bancaria', 'Comis', '6', Null, Null, Null, Null, Null, Null, '1', null, '0.00', null, null, '7', '2009-08-28 16:48:22', null, null);
INSERT INTO servicios VALUES ('Provisión Publicidad', 'ProvP', '6', Null, Null, Null, Null, Null, Null, '1', null, '0.00', null, null, '7', '2009-08-28 16:48:46', null, null);
INSERT INTO servicios VALUES ('Habitación Rectificativa', 'HABRE', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2011-06-28 00:00:00', null, null);
INSERT INTO servicios VALUES ('Desayuno rectificativa', 'DESRE', '2', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '7', '2011-06-28 00:00:00', null, null);
INSERT INTO servicios VALUES ('Media Pensión Rectificativa', 'MPRE', '2', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '7', '2011-06-28 00:00:00', null, null);
INSERT INTO servicios VALUES ('Todo Incluido Rectificativa', 'TIRE', '2', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '7', '2011-06-28 00:00:00', null, null);
INSERT INTO servicios VALUES ('Supl. Doble Uso Ind.', 'SDUI', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '9', '2009-09-29 00:00:00', null, null);
INSERT INTO servicios VALUES ('Coco´s birthday', 'COCO', '4', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-10-21 00:00:00', null, null);
INSERT INTO servicios VALUES ('Artículos Merchandising', 'MERCHA', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2012-06-18 00:00:00', null, null);
INSERT INTO servicios VALUES ('Regularización cobro', 'REGUL', '6', Null, Null, Null, Null, Null, Null, '1', null, '0.00', null, null, '7', '2009-11-30 11:09:21', null, null);
INSERT INTO servicios VALUES ('Produccion Habitacion Garantia', 'GAR', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '2', '2009-12-04 00:00:00', null, null);
INSERT INTO servicios VALUES ('Solo Alojamiento', 'SS', '2', Null, Null, Null, Null, Null, Null, '2', null, '0.00', null, null, '1', '2009-12-25 19:48:23', null, null);
INSERT INTO servicios VALUES ('Habitacion', 'HAB', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2009-12-30 00:00:00', null, null);
INSERT INTO servicios VALUES ('Mando TV', 'TV', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '2', '2010-04-08 00:00:00', null, null);
INSERT INTO servicios VALUES ('Snack', 'SNK', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '2', '2010-04-14 00:00:00', null, null);
INSERT INTO servicios VALUES ('Pesa', 'PES', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '2', '2010-04-14 00:00:00', null, null);
INSERT INTO servicios VALUES ('Upgrade Cenas ', 'CEN', '2', Null, Null, Null, Null, Null, Null, '1', null, null, '3', null, '7', '2011-02-15 00:00:00', null, '2');
INSERT INTO servicios VALUES ('Cenas Niños', 'CEN', '2', Null, Null, Null, Null, Null, Null, '1', null, null, '3', null, '2', '2010-04-14 00:00:00', null, '2');
INSERT INTO servicios VALUES ('Upgrade de A1 a PRE', 'UA1PR', '1', Null, Null, Null, Null, Null, Null, '1', null, null, '55', '94', '1', '2010-07-14 00:00:00', null, null);
INSERT INTO servicios VALUES ('Almuerzo', 'ALMUE', '4', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2010-05-25 00:00:00', null, null);
INSERT INTO servicios VALUES ('Merchandising', 'MERCH', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2010-07-26 00:00:00', null, null);
INSERT INTO servicios VALUES ('SIAM PARK', 'SIAM', '3', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '7', '2010-08-18 00:00:00', null, null);
INSERT INTO servicios VALUES ('Misnusvalidos 1 Dorm', 'M1', '1', Null, Null, Null, Null, Null, Null, '1', '1', null, null, null, '2', '2010-10-07 00:00:00', '1', null);
INSERT INTO servicios VALUES ('Minusvalidos 2 Dorm.', 'M2', '1', Null, Null, Null, Null, Null, Null, '1', '1', null, null, null, '2', '2010-10-07 00:00:00', '2', null);
INSERT INTO servicios VALUES ('Alojamiento M1', 'AM1', '1', Null, Null, Null, Null, Null, Null, '2', '99', null, null, null, '2', '2010-10-07 00:00:00', '1', null);
INSERT INTO servicios VALUES ('Alojamiento M2', 'AM2', '1', Null, Null, Null, Null, Null, Null, '2', '99', null, null, null, '2', '2010-10-07 00:00:00', '2', null);
INSERT INTO servicios VALUES ('Máquinas recreativas', 'RECRE', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2014-10-16 00:00:00', null, null);
INSERT INTO servicios VALUES ('Báscula maletas', 'BASCU', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2010-10-15 00:00:00', null, null);
INSERT INTO servicios VALUES ('Máquinas expendedoras (VENDING)', 'EXPEN', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2014-01-24 00:00:00', null, null);
INSERT INTO servicios VALUES ('Máquinas de café', 'CAFÉ', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2010-11-30 00:00:00', null, null);
INSERT INTO servicios VALUES ('Upgrade SS a HD', 'SSHD', '2', Null, Null, Null, Null, Null, Null, '2', '2', null, '2', null, '7', '2010-12-22 00:00:00', null, '1');
INSERT INTO servicios VALUES ('Upgrade SS a MP', 'SSMP', '2', Null, Null, Null, Null, Null, Null, '2', '2', null, '3', null, '7', '2010-12-22 00:00:00', null, '2');
INSERT INTO servicios VALUES ('Upgrade SS a TI', 'SSTI', '2', Null, Null, Null, Null, Null, Null, '2', '2', null, '4', null, '7', '2010-12-22 00:00:00', null, '4');
INSERT INTO servicios VALUES ('Gala Navidad pasante 24.12', 'GNAP', '5', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '7', '2014-12-24 00:00:00', null, null);
INSERT INTO servicios VALUES ('Gala Fin de Año pasante', 'GFINP', '5', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '7', '2014-12-24 00:00:00', null, null);
INSERT INTO servicios VALUES ('Suplemento Gala Navidad SS (contratos)', 'GNSS', '5', Null, Null, Null, Null, Null, Null, '2', '2', null, null, null, '7', '2011-12-22 00:00:00', null, null);
INSERT INTO servicios VALUES ('Suplemento Gala Fin de Año SS (contratos)', 'GFISS', '5', Null, Null, Null, Null, Null, Null, '2', '2', null, null, null, '7', '2011-12-22 00:00:00', null, null);
INSERT INTO servicios VALUES ('Kid Suite +', 'KS+', '1', Null, Null, Null, Null, Null, Null, '1', '1', null, null, null, '2', '2011-01-27 00:00:00', '4', null);
INSERT INTO servicios VALUES ('Alojamiento KS+', 'AKS+', '1', Null, Null, Null, Null, Null, Null, '2', '99', null, null, null, '2', '2011-01-27 00:00:00', '4', null);
INSERT INTO servicios VALUES ('Productos Lavandería', 'LAVAN', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '37', '2011-02-04 00:00:00', null, null);
INSERT INTO servicios VALUES ('Compensaciones OVB', 'COVB', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2011-03-02 00:00:00', null, null);
INSERT INTO servicios VALUES ('Compensaciones', 'COMP', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2011-03-02 00:00:00', null, null);
INSERT INTO servicios VALUES ('Pretty Woman', 'PREWO', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2011-04-18 00:00:00', null, null);
INSERT INTO servicios VALUES ('Junior Suite Mar', 'JSM', '1', Null, Null, Null, Null, Null, Null, '1', '1', '0.00', null, null, '2', '2011-06-13 14:02:54', '1', null);
INSERT INTO servicios VALUES ('Alojamiento Junior Suite Mar', 'AJSM', '1', Null, Null, Null, Null, Null, Null, '2', '99', '0.00', null, null, '2', '2011-06-13 16:17:44', '1', null);
INSERT INTO servicios VALUES ('Suite Mar', 'SUITM', '1', Null, Null, Null, Null, Null, Null, '1', '1', '0.00', null, null, '2', '2011-06-13 16:18:51', '2', null);
INSERT INTO servicios VALUES ('Alojamiento Suite Mar', 'ASUIT', '1', Null, Null, Null, Null, Null, Null, '2', '99', '0.00', null, null, '2', '2011-06-13 16:19:43', '2', null);
INSERT INTO servicios VALUES ('Duplex Mar', 'DUPM', '1', Null, Null, Null, Null, Null, Null, '1', '1', '0.00', null, null, '2', '2011-06-13 16:20:38', '4', null);
INSERT INTO servicios VALUES ('Alojamiento Duplex Mar', 'ADUPM', '1', Null, Null, Null, Null, Null, Null, '2', '99', '0.00', null, null, '2', '2011-06-13 16:22:19', '4', null);
INSERT INTO servicios VALUES ('Junior Suite', 'JS', '1', Null, Null, Null, Null, Null, Null, '1', '1', '0.00', null, null, '2', '2011-06-14 16:47:28', '1', null);
INSERT INTO servicios VALUES ('Alojamiento Junior Suite', 'AJS', '1', Null, Null, Null, Null, Null, Null, '2', '99', '0.00', null, null, '7', '2013-01-24 00:00:00', '1', null);
INSERT INTO servicios VALUES ('Suite', 'SUIT', '1', Null, Null, Null, Null, Null, Null, '1', '1', '0.00', null, null, '2', '2011-06-14 16:49:38', '2', null);
INSERT INTO servicios VALUES ('Alojamiento Suite', 'ASUIT', '1', Null, Null, Null, Null, Null, Null, '2', '99', '0.00', null, null, '2', '2011-06-14 16:50:58', '2', null);
INSERT INTO servicios VALUES ('Duplex', 'DUP', '1', Null, Null, Null, Null, Null, Null, '1', '1', '0.00', null, null, '2', '2011-06-14 16:52:32', '4', null);
INSERT INTO servicios VALUES ('Alojamiento Duplex', 'ADUP', '1', Null, Null, Null, Null, Null, Null, '2', '99', '0.00', null, null, '2', '2011-06-14 16:53:21', '4', null);
INSERT INTO servicios VALUES ('HD Spa Wellness Center', 'SPA', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2011-06-15 00:00:00', null, null);
INSERT INTO servicios VALUES ('Limpieza toallas', 'LTOAL', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '2', '2011-09-28 00:00:00', null, null);
INSERT INTO servicios VALUES ('Snack Bar', 'SNACK', '4', Null, Null, Null, Null, Null, Null, '1', '2', null, null, null, '7', '2012-02-10 00:00:00', null, null);
INSERT INTO servicios VALUES ('Comisión Transfer', 'TRANS', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2011-07-06 00:00:00', null, null);
INSERT INTO servicios VALUES ('Ingresos Reciclaje', 'IREC', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '2', '2011-07-26 00:00:00', null, null);
INSERT INTO servicios VALUES ('Flores y tartas habitaciones', 'FLTA', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2011-08-31 00:00:00', null, null);
INSERT INTO servicios VALUES ('Impresiones y fotocopias', 'IMFOT', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2011-08-31 00:00:00', null, null);
INSERT INTO servicios VALUES ('Restaurante Italiano (Bebidas)', 'ITALI', '4', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2012-06-18 00:00:00', null, null);
INSERT INTO servicios VALUES ('Venta productos estética (spa HDBR)', 'VTAES', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2015-09-14 00:00:00', null, null);
INSERT INTO servicios VALUES ('Alquiler DVDs', 'DVD', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2011-10-04 00:00:00', null, null);
INSERT INTO servicios VALUES ('Upgrade de A1 a Kid Suite', 'A1KS', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2011-10-05 00:00:00', null, null);
INSERT INTO servicios VALUES ('Alquiler electrodomésticos', 'ELECT', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2011-10-14 00:00:00', null, null);
INSERT INTO servicios VALUES ('Cancelaciones reservas', 'CANCE', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2013-08-08 00:00:00', null, null);
INSERT INTO servicios VALUES ('Upgrade Cena Japones', 'JAPO', '2', Null, Null, Null, Null, Null, Null, '1', null, null, '3', null, '2', '2011-11-03 00:00:00', null, '2');
INSERT INTO servicios VALUES ('Descuento publicidad pensión', 'DtoPu', '2', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2015-09-09 00:00:00', null, null);
INSERT INTO servicios VALUES ('Gala Navidad pasante 25.12', 'GNA25', '5', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '7', '2011-12-20 00:00:00', null, null);
INSERT INTO servicios VALUES ('Upgrade MP/TI-Gala 24/12', 'UG24', '4', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '7', '2011-12-22 00:00:00', null, null);
INSERT INTO servicios VALUES ('Upgrade MP/TI-Gala 25/12', 'UG25', '4', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '7', '2011-12-22 00:00:00', null, null);
INSERT INTO servicios VALUES ('Upgrade MP/TI-Gala 31/12', 'UG31', '4', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '7', '2011-12-22 00:00:00', null, null);
INSERT INTO servicios VALUES ('Aportación publicidad-guías', 'PBGUI', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2012-11-12 00:00:00', null, null);
INSERT INTO servicios VALUES ('Suplemento Vista Mar', 'Vista', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2011-12-30 00:00:00', null, null);
INSERT INTO servicios VALUES ('Seguro Bicicletas', 'BICI', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2012-01-11 00:00:00', null, null);
INSERT INTO servicios VALUES ('Paquete material nautico', 'MATNA', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2012-02-29 00:00:00', null, null);
INSERT INTO servicios VALUES ('Curso de Windsurf y Catamarán', 'WIDCA', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2012-02-29 00:00:00', null, null);
INSERT INTO servicios VALUES ('Cena', 'CENA', '4', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2014-05-12 00:00:00', null, null);
INSERT INTO servicios VALUES ('Habitación interempresa', 'HABINT', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2012-03-30 00:00:00', null, null);
INSERT INTO servicios VALUES ('Todo Incuido interempresa', 'TINTE', '2', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2012-03-30 00:00:00', null, null);
INSERT INTO servicios VALUES ('Alojamiento Interempresa', 'AINT', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2012-03-30 00:00:00', null, null);
INSERT INTO servicios VALUES ('Habitación rectificativa interempresa', 'Rinte', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2012-05-07 00:00:00', null, null);
INSERT INTO servicios VALUES ('Todo Incluido Rectificativa Interempresa', 'TIRIN', '2', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2012-05-07 00:00:00', null, null);
INSERT INTO servicios VALUES ('Restaurante Italiano (Comidas)', 'ITACO', '4', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2012-06-18 00:00:00', null, null);
INSERT INTO servicios VALUES ('Restaurante principal (Comidas)', 'RESTP', '4', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2014-03-26 00:00:00', null, null);
INSERT INTO servicios VALUES ('Restaurante principal (Bebidas)', 'RESTP', '4', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2012-06-18 00:00:00', null, null);
INSERT INTO servicios VALUES ('Upgrade Premier a B2', 'UPRB2', '1', Null, Null, Null, Null, Null, Null, '1', null, null, '11', '55', '7', '2012-08-01 00:00:00', null, null);
INSERT INTO servicios VALUES ('Aire Acondicionado', 'AIRE', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2012-09-20 00:00:00', null, null);
INSERT INTO servicios VALUES ('VIP PACKAGE', 'PVIP', '3', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '7', '2012-11-16 00:00:00', null, null);
INSERT INTO servicios VALUES ('Peticiones obsequios para clientes(tartas, vino..)', 'OBSEQ', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2012-12-21 00:00:00', null, null);
INSERT INTO servicios VALUES ('Suplemento Gala Navidad TI (contratos) 25.12', 'NTI25', '5', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2012-12-24 00:00:00', null, null);
INSERT INTO servicios VALUES ('Publicidad Marketing Dinámico', 'MARKE', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2013-02-19 00:00:00', null, null);
INSERT INTO servicios VALUES ('Masajes', 'MASAJ', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2013-02-27 00:00:00', null, null);
INSERT INTO servicios VALUES ('Suite Premier', 'A1PRE', '1', Null, Null, Null, Null, Null, Null, '1', '1', '0.00', null, null, '2', '2013-10-04 00:00:00', '3', null);
INSERT INTO servicios VALUES ('Suite Tecnologica', 'TECS2', '1', Null, Null, Null, Null, Null, Null, '1', '1', '0.00', null, null, '2', '2013-10-04 00:00:00', '4', null);
INSERT INTO servicios VALUES ('Alojamiento SUPRE', 'AA1PR', '1', Null, Null, Null, Null, Null, Null, '2', '99', '0.00', null, null, '2', '2013-10-04 00:00:00', '3', null);
INSERT INTO servicios VALUES ('Alojamiento TECS2', 'AA2PR', '1', Null, Null, Null, Null, Null, Null, '2', '99', '0.00', null, null, '2', '2013-10-04 00:00:00', '4', null);
INSERT INTO servicios VALUES ('Desayuno interempresa', 'DESIN', '2', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2013-04-09 00:00:00', null, null);
INSERT INTO servicios VALUES ('Venta cápsulas café', 'CAFÉ', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2013-06-13 00:00:00', null, null);
INSERT INTO servicios VALUES ('Venta Pizzas', 'PIZZA', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2013-06-20 00:00:00', null, null);
INSERT INTO servicios VALUES ('Alquiler Ipad', 'Ipad', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2013-06-26 00:00:00', null, null);
INSERT INTO servicios VALUES ('Paquete Naútico', 'NAUTI', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2013-07-30 00:00:00', null, null);
INSERT INTO servicios VALUES ('Alquiler MIFI', 'MIFI', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '2', '2013-09-12 00:00:00', null, null);
INSERT INTO servicios VALUES ('Comida Animadores', 'Anima', '2', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2013-10-22 00:00:00', null, null);
INSERT INTO servicios VALUES ('Habitación permisos contrato (Late check-out)', 'LCOC', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2013-10-23 00:00:00', null, null);
INSERT INTO servicios VALUES ('Producción garantía no ocupada', 'GNocu', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2014-01-27 00:00:00', null, null);
INSERT INTO servicios VALUES ('Venta de aceite vegetal usado', 'ACEIT', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2014-02-28 00:00:00', null, null);
INSERT INTO servicios VALUES ('Arrendamiento Terraza', 'ARREN', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2014-02-28 00:00:00', null, null);
INSERT INTO servicios VALUES ('Refacturaciones consumos', 'CONSU', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2014-03-12 00:00:00', null, null);
INSERT INTO servicios VALUES ('Fotografía', 'FOTO', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2014-05-09 00:00:00', null, null);
INSERT INTO servicios VALUES ('Pintura', 'PINTU', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2014-05-09 00:00:00', null, null);
INSERT INTO servicios VALUES ('Suplemento Sailor', 'SAILOR', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2014-05-19 00:00:00', null, null);
INSERT INTO servicios VALUES ('Alquiler Cama Balinesa', 'BALI', '3', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '7', '2014-05-19 00:00:00', null, null);
INSERT INTO servicios VALUES ('Alquiler Bicicletas', 'BICIS', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2014-06-25 00:00:00', null, null);
INSERT INTO servicios VALUES ('Descuento publicidad ', 'Publi', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2014-07-04 00:00:00', null, null);
INSERT INTO servicios VALUES ('Day Use', 'DAYUS', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2014-08-01 00:00:00', null, null);
INSERT INTO servicios VALUES ('Alquiler Babyphone', 'BPHON', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2014-09-05 00:00:00', null, null);
INSERT INTO servicios VALUES ('Muñeco Be Chachi', 'CHACH', '3', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '7', '2014-11-10 00:00:00', null, null);
INSERT INTO servicios VALUES ('Puzzle Chachi (formula Creativa)', 'CHACH', '3', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '37', '2014-09-15 00:00:00', null, null);
INSERT INTO servicios VALUES ('Bolsa Chachi', 'CHACH', '3', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '37', '2014-09-15 00:00:00', null, null);
INSERT INTO servicios VALUES ('Libro El Secreto de los Chachis', 'CHACH', '3', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '37', '2014-09-15 00:00:00', null, null);
INSERT INTO servicios VALUES ('Libro de los dibujos Chachis', 'CHACH', '3', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '37', '2014-09-15 00:00:00', null, null);
INSERT INTO servicios VALUES ('Libro actividades Chachis', 'CHACH', '3', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '37', '2014-09-15 00:00:00', null, null);
INSERT INTO servicios VALUES ('Disco CD Chachi', 'CHACH', '3', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '37', '2014-09-15 00:00:00', null, null);
INSERT INTO servicios VALUES ('Super-pack Chachi', 'CHACH', '3', Null, Null, Null, Null, Null, Null, '2', null, null, null, null, '37', '2014-09-15 00:00:00', null, null);
INSERT INTO servicios VALUES ('Cambio HAB misma Categoría', 'HAB=', '1', Null, Null, Null, Null, Null, Null, '1', null, '30.00', null, null, '37', '2015-02-20 00:00:00', null, null);
INSERT INTO servicios VALUES ('Camisetas Animación', 'CAMIS', '3', Null, Null, Null, Null, Null, Null, '2', null, '10.00', null, null, '37', '2015-03-27 00:00:00', null, null);
INSERT INTO servicios VALUES ('Descuento Habitación', 'DESH', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '37', '2015-06-11 00:00:00', null, null);
INSERT INTO servicios VALUES ('Sorteos de animación', 'SORTE', '3', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2015-08-25 00:00:00', null, null);
INSERT INTO servicios VALUES ('Comisión venta Sun Care', 'SUNCA', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2015-09-14 00:00:00', null, null);
INSERT INTO servicios VALUES ('Alojamiento Villas', 'AVILL', '1', Null, Null, Null, Null, Null, Null, '2', '99', null, null, null, '2', '2015-09-14 00:00:00', '3', null);
INSERT INTO servicios VALUES ('Villas', 'VILL', '1', Null, Null, Null, Null, Null, Null, '1', '1', null, null, null, '2', '2015-09-14 00:00:00', '3', null);
INSERT INTO servicios VALUES ('Taza Chachi', 'TAZA', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2015-11-09 00:00:00', null, null);
INSERT INTO servicios VALUES ('Descuento publicidad suplemento VIP', 'DTVIP', '3', Null, Null, Null, Null, Null, Null, '1', '2', null, null, null, '7', '2015-11-25 00:00:00', null, null);
INSERT INTO servicios VALUES ('Muñeco Be Chachi grande', 'CHACH', '1', Null, Null, Null, Null, Null, Null, '1', null, null, null, null, '7', '2015-11-26 00:00:00', null, null);

