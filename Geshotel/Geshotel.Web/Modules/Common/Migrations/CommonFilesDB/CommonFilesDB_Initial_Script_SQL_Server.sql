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
INSERT INTO monedas VALUES ('US DOLAR', '$', '1.06');
INSERT INTO monedas VALUES ('LIBRA ESTERLINA', '£', '0.88');
INSERT INTO monedas VALUES ('CORONA SUECA', 'Kr', null);
INSERT INTO monedas VALUES ('FRANCO SUIZO', 'CHK', null);
INSERT INTO monedas VALUES ('CORONA CHECA', 'CZK', null);
INSERT INTO monedas VALUES ('RUBLO', 'RU', null);
INSERT INTO monedas VALUES ('YEN', 'YEN', null);
INSERT INTO monedas VALUES ('YUAN', 'YU', null);

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
  [activo_geshotel] bit,
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
  [estado_reserva_id] smallint NOT NULL,
  [estado] varchar(20) NOT NULL,
  [es_error_fechaini] smallint NOT NULL,
  [es_error_fechafin] smallint NOT NULL,
  PRIMARY KEY ([estado_reserva_id])
) ;

-- ----------------------------
-- Records of reserva_estados
-- ----------------------------
INSERT INTO reserva_estados VALUES ('0', 'Con Errores', '1', '1');
INSERT INTO reserva_estados VALUES ('1', 'Pendiente', '1', '1');
INSERT INTO reserva_estados VALUES ('2', 'Anulada', '0', '0');
INSERT INTO reserva_estados VALUES ('3', 'Check-in', '0', '1');
INSERT INTO reserva_estados VALUES ('4', 'Check-out', '1', '1');
INSERT INTO reserva_estados VALUES ('5', 'Facturado', '0', '0');
INSERT INTO reserva_estados VALUES ('6', 'No Show', '0', '0');

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
SET IDENTITY_INSERT [dbo].[servicios] ON
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'1', N'Alojamiento B1', N'A1', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'99', null, null, null, N'1', N'2008-12-10 00:00:00', N'1', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'2', N'Desayuno', N'HD', N'2', N'1', N'0', N'0', N'0', N'1', N'0', N'2', N'2', null, null, null, N'1', N'2009-02-02 00:00:00', null, N'1')
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'3', N'Media Pension', N'MP', N'2', N'1', N'0', N'0', N'0', N'1', N'0', N'2', N'2', null, null, null, N'2', N'2011-03-11 00:00:00', null, N'2')
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'4', N'Todo Incluido', N'TI', N'2', N'1', N'0', N'0', N'0', N'1', N'0', N'2', N'2', null, null, null, N'1', N'2011-08-17 00:00:00', null, N'4')
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'5', N'Todo Incluido Bebidas', N'TIB', N'2', N'1', N'0', N'0', N'0', N'1', N'0', N'2', N'2', null, null, null, N'7', null, null, N'4')
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'6', N'Alojamiento B2', N'A2', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'99', null, null, null, N'7', N'2015-08-24 00:00:00', N'2', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'7', N'Cunas', N'CUN', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', null, null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'8', N'Gala Navidad HD', N'GNHD', N'5', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'7', null, null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'9', N'Gala Fin de Año', N'GF', N'5', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'7', N'2015-01-14 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'10', N'Bungalow 1 Dormitorio', N'B1', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', N'1', null, null, null, N'7', null, N'1', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'11', N'Bungalow 2 Dormitorios', N'B2', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', N'1', null, null, null, N'7', null, N'2', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'12', N'Bar Piscina 1 Comidas', N'BP1C', N'4', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', null, null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'13', N'Bar Piscina 1 Bebidas', N'BP1B', N'4', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', null, null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'14', N'Bar Salon Bebidas', N'BSB', N'4', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', null, null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'15', N'Bar Piscina 2 Comidas ', N'BP2C', N'4', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', null, null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'16', N'Bar Piscina 2 Bebidas ', N'BP2B', N'4', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', null, null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'17', N'Bar Restaurante Bebidas', N'BRB', N'4', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2013-07-29 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'18', N'Bar Restaurante Comidas', N'BRC', N'4', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2014-10-07 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'19', N'Gala Navidad', N'GN', N'5', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'7', null, null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'20', N'Gala Fin de Año HD', N'GFHD', N'5', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'7', null, null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'21', N'Habitacion Overbooking', N'HAOVB', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-01-21 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'22', N'Alquiler de Sombrilla', N'ALQSO', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-01-21 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'23', N'Cabinas Telefonicas', N'CABTF', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-01-21 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'24', N'Divisa', N'DIVIS', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-01-21 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'25', N'Exposiciones y Desfiles', N'EXPOS', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'37', N'2015-05-12 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'26', N'Internet', N'INTER', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-01-21 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'27', N'Lavadoras', N'LAVAD', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-01-21 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'28', N'Caja de Seguridad', N'SAFE', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-01-21 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'29', N'Tabaco', N'TAB', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-01-21 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'30', N'Telefono', N'TELEF', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-01-21 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'31', N'Babychangingtable (Cambiador)', N'CAMBI', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-02-04 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'32', N'Babytrolly (Carrito)', N'CARRI', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-02-04 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'33', N'Rent a Car', N'RENT', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2013-08-07 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'34', N'Tenis', N'TENIS', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-02-04 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'35', N'Babychair (Trona)', N'TRONA', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-02-04 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'36', N'Wellness Center', N'WELLN', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-02-04 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'37', N'Wellcome Package', N'WPACK', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-02-04 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'38', N'Alojamiento Premier', N'AP', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'99', null, null, null, N'1', N'2009-03-04 00:00:00', N'3', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'39', N'Alojamiento Kid Suite', N'AKS', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'99', null, null, null, N'1', N'2009-03-04 00:00:00', N'4', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'40', N'Premier', N'PRE', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', N'1', null, null, null, N'1', N'2009-03-04 00:00:00', N'3', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'41', N'Kid Suite', N'KS', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', N'1', null, null, null, N'1', N'2009-03-04 00:00:00', N'4', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'42', N'Pension Completa', N'PC', N'2', N'1', N'0', N'0', N'0', N'1', N'0', N'2', N'2', null, null, null, N'1', N'2009-06-02 00:00:00', null, N'3')
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'43', N'Varios', N'Var', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2013-03-11 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'44', N'Upgrade de B1 a B2', N'B1AB2', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, N'11', N'10', N'2', N'2009-06-14 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'45', N'Descuento Publicidad Habitacion', N'DESH', N'1', N'1', N'1', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2015-09-09 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'46', N'Descuento Pension', N'DESP', N'2', N'1', N'1', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'2', N'2009-04-14 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'47', N'Descuento Cobro', N'Desc', N'3', N'0', N'1', N'0', N'0', N'0', N'0', N'1', null, N'0', null, null, N'2', N'2009-05-18 13:47:27', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'48', N'Anticipo Factura', N'ANT', N'3', N'0', N'0', N'0', N'0', N'0', N'0', N'1', null, N'0', null, null, N'2', N'2009-05-18 13:49:24', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'49', N'Depositos', N'DEP', N'7', N'0', N'0', N'0', N'0', N'0', N'0', N'1', null, N'0', null, null, N'2', N'2009-10-27 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'50', N'Ajustes Produccion Pension', N'AJPEN', N'2', N'1', N'0', N'1', N'0', N'0', N'0', N'1', null, null, null, null, N'2', N'2009-05-29 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'51', N'Ajustes Produccion Habitacion', N'AJUHA', N'1', N'1', N'0', N'1', N'0', N'0', N'0', N'1', null, null, null, null, N'2', N'2009-05-29 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'52', N'Ajustes Produccion Galas', N'AJUGA', N'5', N'1', N'0', N'1', N'0', N'0', N'0', N'1', null, null, null, null, N'2', N'2009-05-29 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'53', N'Ajustes Produccion Otros', N'AJUOT', N'3', N'1', N'0', N'1', N'0', N'0', N'0', N'1', null, null, null, null, N'2', N'2009-05-29 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'54', N'Habitacion Permisos (Late check out)', N'PER', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2011-08-22 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'55', N'Upgrade B2 A KS', N'B2AKS', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, N'56', N'11', N'2', N'2009-06-14 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'56', N'Animadores', N'ANIM', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'2', N'2009-06-18 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'57', N'Upgrade MP a TI', N'MP2TI', N'2', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, N'4', N'3', N'2', N'2009-06-23 00:00:00', null, N'4')
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'58', N'Persona Extra SA/día', N'CS', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'37', N'2015-06-01 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'59', N'Varios Golosinas', N'GOLOS', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-07-03 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'60', N'Salón de Conferencias', N'CONFE', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2015-11-24 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'61', N'Sillon de Masajes', N'SILLO', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-07-03 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'62', N'Bisutería', N'BISUT', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-07-03 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'63', N'Roturas', N'ROTUR', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'9', N'2009-09-29 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'64', N'Publicidad', N'PUBLI', N'6', N'0', N'0', N'0', N'1', N'0', N'0', N'1', null, N'0', null, null, N'2', N'2009-07-03 10:30:02', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'65', N'Luz para Tenis', N'Luz', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'2', N'2009-07-08 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'66', N'Upgrade Desayuno a TI', N'De2TI', N'2', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, N'4', N'2', N'2', N'2009-07-09 00:00:00', null, N'4')
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'67', N'Upgrade Desayuno a MP', N'DE2MP', N'2', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, N'3', N'2', N'2', N'2009-07-09 00:00:00', null, N'2')
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'68', N'Suplemento Gala Navidad MP (contratos)', N'GNMP', N'5', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2011-12-22 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'69', N'Suplemento Gala Navidad TI (contratos)', N'GNTI', N'5', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2011-12-22 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'70', N'Suplemento Gala Fin de Año MP (contratos)', N'GFMP', N'5', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2011-12-22 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'71', N'Suplemento Gala Fin de Año TI (contratos)', N'GFTI', N'5', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2011-12-22 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'72', N'Suite 1 Dormitorio', N'SUITE1', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', N'1', null, null, null, N'7', N'2013-10-04 00:00:00', N'1', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'73', N'Suite 2 Dormitorios', N'SUITE2', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', N'1', null, null, null, N'7', N'2013-10-04 00:00:00', N'2', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'74', N'Alojamiento Suite 1', N'SU1', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'99', null, null, null, N'7', N'2013-10-04 00:00:00', N'1', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'75', N'Alojamiento Suite 2', N'SU2', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'99', null, null, null, N'7', N'2013-10-04 00:00:00', N'2', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'76', N'Upgrade A1 a A2', N'A1UA2', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, N'95', N'94', N'2', N'2009-07-20 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'77', N'Upgrade A2 a KS', N'A2UKS', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, N'56', N'95', N'2', N'2009-07-20 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'78', N'Calefaccion', N'Cal', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'2', N'2009-07-21 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'79', N'Carga Partidas vivas', N'CCI', N'3', N'0', N'0', N'0', N'0', N'0', N'0', N'1', null, N'0', null, null, N'2', N'2009-07-31 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'80', N'Comisión bancaria', N'Comis', N'6', N'0', N'0', N'0', N'1', N'0', N'0', N'1', null, N'0', null, null, N'7', N'2009-08-28 16:48:22', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'81', N'Provisión Publicidad', N'ProvP', N'6', N'0', N'0', N'0', N'0', N'0', N'0', N'1', null, N'0', null, null, N'7', N'2009-08-28 16:48:46', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'82', N'Habitación Rectificativa', N'HABRE', N'1', N'1', N'0', N'0', N'0', N'0', N'1', N'1', null, null, null, null, N'7', N'2011-06-28 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'83', N'Desayuno rectificativa', N'DESRE', N'2', N'1', N'0', N'0', N'0', N'0', N'1', N'2', null, null, null, null, N'7', N'2011-06-28 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'84', N'Media Pensión Rectificativa', N'MPRE', N'2', N'1', N'0', N'0', N'0', N'0', N'1', N'2', null, null, null, null, N'7', N'2011-06-28 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'85', N'Todo Incluido Rectificativa', N'TIRE', N'2', N'1', N'0', N'0', N'0', N'0', N'1', N'2', null, null, null, null, N'7', N'2011-06-28 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'86', N'Supl. Doble Uso Ind.', N'SDUI', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'9', N'2009-09-29 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'87', N'Coco´s birthday', N'COCO', N'4', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-10-21 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'88', N'Artículos Merchandising', N'MERCHA', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2012-06-18 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'89', N'Regularización cobro', N'REGUL', N'6', N'0', N'0', N'0', N'1', N'0', N'0', N'1', null, N'0', null, null, N'7', N'2009-11-30 11:09:21', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'90', N'Produccion Habitacion Garantia', N'GAR', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'2', N'2009-12-04 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'91', N'Solo Alojamiento', N'SS', N'2', N'0', N'0', N'0', N'0', N'1', N'0', N'2', null, N'0', null, null, N'1', N'2009-12-25 19:48:23', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'92', N'Habitacion', N'HAB', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2009-12-30 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'93', N'Mando TV', N'TV', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'2', N'2010-04-08 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'94', N'Snack', N'SNK', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'2', N'2010-04-14 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'95', N'Pesa', N'PES', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'2', N'2010-04-14 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'96', N'Upgrade Cenas ', N'CEN', N'2', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, N'3', null, N'7', N'2011-02-15 00:00:00', null, N'2')
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'97', N'Cenas Niños', N'CEN', N'2', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, N'3', null, N'2', N'2010-04-14 00:00:00', null, N'2')
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'98', N'Upgrade de A1 a PRE', N'UA1PR', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, N'55', N'94', N'1', N'2010-07-14 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'99', N'Almuerzo', N'ALMUE', N'4', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2010-05-25 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'100', N'Merchandising', N'MERCH', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2010-07-26 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'101', N'SIAM PARK', N'SIAM', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'7', N'2010-08-18 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'102', N'Misnusvalidos 1 Dorm', N'M1', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', N'1', null, null, null, N'2', N'2010-10-07 00:00:00', N'1', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'103', N'Minusvalidos 2 Dorm.', N'M2', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', N'1', null, null, null, N'2', N'2010-10-07 00:00:00', N'2', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'104', N'Alojamiento M1', N'AM1', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'99', null, null, null, N'2', N'2010-10-07 00:00:00', N'1', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'105', N'Alojamiento M2', N'AM2', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'99', null, null, null, N'2', N'2010-10-07 00:00:00', N'2', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'106', N'Máquinas recreativas', N'RECRE', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2014-10-16 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'107', N'Báscula maletas', N'BASCU', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2010-10-15 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'108', N'Máquinas expendedoras (VENDING)', N'EXPEN', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2014-01-24 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'109', N'Máquinas de café', N'CAFÉ', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2010-11-30 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'110', N'Upgrade SS a HD', N'SSHD', N'2', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'2', null, N'2', null, N'7', N'2010-12-22 00:00:00', null, N'1')
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'111', N'Upgrade SS a MP', N'SSMP', N'2', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'2', null, N'3', null, N'7', N'2010-12-22 00:00:00', null, N'2')
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'112', N'Upgrade SS a TI', N'SSTI', N'2', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'2', null, N'4', null, N'7', N'2010-12-22 00:00:00', null, N'4')
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'113', N'Gala Navidad pasante 24.12', N'GNAP', N'5', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'7', N'2014-12-24 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'114', N'Gala Fin de Año pasante', N'GFINP', N'5', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'7', N'2014-12-24 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'115', N'Suplemento Gala Navidad SS (contratos)', N'GNSS', N'5', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'2', null, null, null, N'7', N'2011-12-22 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'116', N'Suplemento Gala Fin de Año SS (contratos)', N'GFISS', N'5', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'2', null, null, null, N'7', N'2011-12-22 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'117', N'Kid Suite +', N'KS+', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', N'1', null, null, null, N'2', N'2011-01-27 00:00:00', N'4', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'118', N'Alojamiento KS+', N'AKS+', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'99', null, null, null, N'2', N'2011-01-27 00:00:00', N'4', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'119', N'Productos Lavandería', N'LAVAN', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'37', N'2011-02-04 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'120', N'Compensaciones OVB', N'COVB', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2011-03-02 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'121', N'Compensaciones', N'COMP', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2011-03-02 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'122', N'Pretty Woman', N'PREWO', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2011-04-18 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'123', N'Junior Suite Mar', N'JSM', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', N'1', N'0', null, null, N'2', N'2011-06-13 14:02:54', N'1', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'124', N'Alojamiento Junior Suite Mar', N'AJSM', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'99', N'0', null, null, N'2', N'2011-06-13 16:17:44', N'1', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'125', N'Suite Mar', N'SUITM', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', N'1', N'0', null, null, N'2', N'2011-06-13 16:18:51', N'2', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'126', N'Alojamiento Suite Mar', N'ASUIT', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'99', N'0', null, null, N'2', N'2011-06-13 16:19:43', N'2', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'127', N'Duplex Mar', N'DUPM', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', N'1', N'0', null, null, N'2', N'2011-06-13 16:20:38', N'4', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'128', N'Alojamiento Duplex Mar', N'ADUPM', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'99', N'0', null, null, N'2', N'2011-06-13 16:22:19', N'4', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'129', N'Junior Suite', N'JS', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', N'1', N'0', null, null, N'2', N'2011-06-14 16:47:28', N'1', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'130', N'Alojamiento Junior Suite', N'AJS', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'99', N'0', null, null, N'7', N'2013-01-24 00:00:00', N'1', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'131', N'Suite', N'SUIT', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', N'1', N'0', null, null, N'2', N'2011-06-14 16:49:38', N'2', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'132', N'Alojamiento Suite', N'ASUIT', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'99', N'0', null, null, N'2', N'2011-06-14 16:50:58', N'2', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'133', N'Duplex', N'DUP', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', N'1', N'0', null, null, N'2', N'2011-06-14 16:52:32', N'4', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'134', N'Alojamiento Duplex', N'ADUP', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'99', N'0', null, null, N'2', N'2011-06-14 16:53:21', N'4', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'135', N'HD Spa Wellness Center', N'SPA', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2011-06-15 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'136', N'Limpieza toallas', N'LTOAL', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'2', N'2011-09-28 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'137', N'Snack Bar', N'SNACK', N'4', N'1', N'0', N'0', N'0', N'0', N'0', N'1', N'2', null, null, null, N'7', N'2012-02-10 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'138', N'Comisión Transfer', N'TRANS', N'3', N'1', N'0', N'0', N'1', N'0', N'0', N'1', null, null, null, null, N'7', N'2011-07-06 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'139', N'Ingresos Reciclaje', N'IREC', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'2', N'2011-07-26 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'140', N'Flores y tartas habitaciones', N'FLTA', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2011-08-31 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'141', N'Impresiones y fotocopias', N'IMFOT', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2011-08-31 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'142', N'Restaurante Italiano (Bebidas)', N'ITALI', N'4', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2012-06-18 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'143', N'Venta productos estética (spa HDBR)', N'VTAES', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2015-09-14 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'144', N'Alquiler DVDs', N'DVD', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2011-10-04 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'145', N'Upgrade de A1 a Kid Suite', N'A1KS', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2011-10-05 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'146', N'Alquiler electrodomésticos', N'ELECT', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2011-10-14 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'147', N'Cancelaciones reservas', N'CANCE', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2013-08-08 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'148', N'Upgrade Cena Japones', N'JAPO', N'2', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, N'3', null, N'2', N'2011-11-03 00:00:00', null, N'2')
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'149', N'Descuento publicidad pensión', N'DtoPu', N'2', N'1', N'1', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2015-09-09 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'150', N'Gala Navidad pasante 25.12', N'GNA25', N'5', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'7', N'2011-12-20 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'151', N'Upgrade MP/TI-Gala 24/12', N'UG24', N'4', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'7', N'2011-12-22 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'152', N'Upgrade MP/TI-Gala 25/12', N'UG25', N'4', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'7', N'2011-12-22 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'153', N'Upgrade MP/TI-Gala 31/12', N'UG31', N'4', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'7', N'2011-12-22 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'154', N'Aportación publicidad-guías', N'PBGUI', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2012-11-12 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'155', N'Suplemento Vista Mar', N'Vista', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2011-12-30 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'156', N'Seguro Bicicletas', N'BICI', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2012-01-11 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'157', N'Paquete material nautico', N'MATNA', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2012-02-29 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'158', N'Curso de Windsurf y Catamarán', N'WIDCA', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2012-02-29 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'159', N'Cena', N'CENA', N'4', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2014-05-12 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'160', N'Habitación interempresa', N'HABINT', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2012-03-30 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'161', N'Todo Incuido interempresa', N'TINTE', N'2', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2012-03-30 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'162', N'Alojamiento Interempresa', N'AINT', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2012-03-30 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'163', N'Habitación rectificativa interempresa', N'Rinte', N'1', N'1', N'0', N'0', N'0', N'0', N'1', N'1', null, null, null, null, N'7', N'2012-05-07 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'164', N'Todo Incluido Rectificativa Interempresa', N'TIRIN', N'2', N'1', N'0', N'0', N'0', N'0', N'1', N'1', null, null, null, null, N'7', N'2012-05-07 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'165', N'Restaurante Italiano (Comidas)', N'ITACO', N'4', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2012-06-18 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'166', N'Restaurante principal (Comidas)', N'RESTP', N'4', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2014-03-26 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'167', N'Restaurante principal (Bebidas)', N'RESTP', N'4', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2012-06-18 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'168', N'Upgrade Premier a B2', N'UPRB2', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, N'11', N'55', N'7', N'2012-08-01 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'169', N'Aire Acondicionado', N'AIRE', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2012-09-20 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'170', N'VIP PACKAGE', N'PVIP', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'7', N'2012-11-16 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'171', N'Peticiones obsequios para clientes(tartas, vino..)', N'OBSEQ', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2012-12-21 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'172', N'Suplemento Gala Navidad TI (contratos) 25.12', N'NTI25', N'5', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2012-12-24 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'173', N'Publicidad Marketing Dinámico', N'MARKE', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2013-02-19 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'174', N'Masajes', N'MASAJ', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2013-02-27 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'175', N'Suite Premier', N'A1PRE', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', N'1', N'0', null, null, N'2', N'2013-10-04 00:00:00', N'3', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'176', N'Suite Tecnologica', N'TECS2', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', N'1', N'0', null, null, N'2', N'2013-10-04 00:00:00', N'4', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'177', N'Alojamiento SUPRE', N'AA1PR', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'99', N'0', null, null, N'2', N'2013-10-04 00:00:00', N'3', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'178', N'Alojamiento TECS2', N'AA2PR', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'99', N'0', null, null, N'2', N'2013-10-04 00:00:00', N'4', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'179', N'Desayuno interempresa', N'DESIN', N'2', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2013-04-09 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'180', N'Venta cápsulas café', N'CAFÉ', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2013-06-13 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'181', N'Venta Pizzas', N'PIZZA', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2013-06-20 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'182', N'Alquiler Ipad', N'Ipad', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2013-06-26 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'183', N'Paquete Naútico', N'NAUTI', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2013-07-30 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'184', N'Alquiler MIFI', N'MIFI', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'2', N'2013-09-12 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'185', N'Comida Animadores', N'Anima', N'2', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2013-10-22 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'186', N'Habitación permisos contrato (Late check-out)', N'LCOC', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2013-10-23 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'187', N'Producción garantía no ocupada', N'GNocu', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2014-01-27 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'188', N'Venta de aceite vegetal usado', N'ACEIT', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2014-02-28 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'189', N'Arrendamiento Terraza', N'ARREN', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2014-02-28 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'190', N'Refacturaciones consumos', N'CONSU', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2014-03-12 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'191', N'Fotografía', N'FOTO', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2014-05-09 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'192', N'Pintura', N'PINTU', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2014-05-09 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'193', N'Suplemento Sailor', N'SAILOR', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2014-05-19 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'194', N'Alquiler Cama Balinesa', N'BALI', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'7', N'2014-05-19 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'195', N'Alquiler Bicicletas', N'BICIS', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2014-06-25 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'196', N'Descuento publicidad ', N'Publi', N'1', N'1', N'1', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2014-07-04 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'197', N'Day Use', N'DAYUS', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2014-08-01 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'198', N'Alquiler Babyphone', N'BPHON', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2014-09-05 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'199', N'Muñeco Be Chachi', N'CHACH', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'7', N'2014-11-10 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'200', N'Puzzle Chachi (formula Creativa)', N'CHACH', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'37', N'2014-09-15 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'201', N'Bolsa Chachi', N'CHACH', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'37', N'2014-09-15 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'202', N'Libro El Secreto de los Chachis', N'CHACH', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'37', N'2014-09-15 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'203', N'Libro de los dibujos Chachis', N'CHACH', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'37', N'2014-09-15 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'204', N'Libro actividades Chachis', N'CHACH', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'37', N'2014-09-15 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'205', N'Disco CD Chachi', N'CHACH', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'37', N'2014-09-15 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'206', N'Super-pack Chachi', N'CHACH', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, null, null, null, N'37', N'2014-09-15 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'207', N'Cambio HAB misma Categoría', N'HAB=', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, N'30', null, null, N'37', N'2015-02-20 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'208', N'Camisetas Animación', N'CAMIS', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'2', null, N'10', null, null, N'37', N'2015-03-27 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'209', N'Descuento Habitación', N'DESH', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'37', N'2015-06-11 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'210', N'Sorteos de animación', N'SORTE', N'3', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2015-08-25 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'211', N'Comisión venta Sun Care', N'SUNCA', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2015-09-14 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'212', N'Alojamiento Villas', N'AVILL', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'2', N'99', null, null, null, N'2', N'2015-09-14 00:00:00', N'3', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'213', N'Villas', N'VILL', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', N'1', null, null, null, N'2', N'2015-09-14 00:00:00', N'3', null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'214', N'Taza Chachi', N'TAZA', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2015-11-09 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'215', N'Descuento publicidad suplemento VIP', N'DTVIP', N'3', N'1', N'1', N'0', N'0', N'0', N'0', N'1', N'2', null, null, null, N'7', N'2015-11-25 00:00:00', null, null)
GO
GO
INSERT INTO [dbo].[servicios] ([servicio_id], [nombre_servicio], [abreviatura], [tipo_servicio_id], [sw_produccion], [sw_descuento], [sw_ajustes], [sw_gastos], [sw_pension], [sw_rectificativa], [tipo_unidad_calculo_id], [concepto_acelerador_reservas_id], [costo], [suma_servicio_id], [resta_servicio_id], [user_id], [fecha_modificacion], [tipo_hab], [tipo_pension]) VALUES (N'216', N'Muñeco Be Chachi grande', N'CHACH', N'1', N'1', N'0', N'0', N'0', N'0', N'0', N'1', null, null, null, null, N'7', N'2015-11-26 00:00:00', null, null)
GO
GO
SET IDENTITY_INSERT [dbo].[servicios] OFF
GO