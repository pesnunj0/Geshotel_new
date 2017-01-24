﻿-- ----------------------------
-- Table structure for clientes
-- ----------------------------
DROP TABLE IF EXISTS [clientes];
CREATE TABLE clientes (
  [cliente_id] int NOT NULL IDENTITY,
  [razon] varchar(60) NOT NULL,
  [desc_corta] varchar(8) DEFAULT NULL,
  [nombre] varchar(30) DEFAULT NULL,
  [apellidos] varchar(50) DEFAULT NULL,
  [empresa_id] smallint NOT NULL,
  [agencia_id] int DEFAULT NULL,
  [mercado_id] smallint DEFAULT NULL,
  [cliente_defecto] binary(1) NOT NULL DEFAULT b'0',
  [grupo_cliente_id] smallint NOT NULL,
  [tipo_documento_id] char(1) DEFAULT NULL,
  [nif] varchar(20) DEFAULT NULL,
  [fecha_documento] date DEFAULT NULL,
  [sexo_id] char(1) DEFAULT NULL,
  [direccion] varchar(70) DEFAULT NULL,
  [poblacion] varchar(70) DEFAULT NULL,
  [zip] varchar(10) DEFAULT NULL,
  [nacion_id] smallint DEFAULT NULL,
  [provincia_id] smallint DEFAULT NULL,
  [cta_contable_anticipo] varchar(16) DEFAULT NULL,
  [cta_contable] varchar(16) DEFAULT NULL,
  [dpto_contable] varchar(5) DEFAULT NULL,
  [cta_depositos] varchar(15) DEFAULT NULL,
  [telefono] varchar(20) DEFAULT NULL,
  [email] varchar(100) DEFAULT NULL,
  [fax] varchar(20) DEFAULT NULL,
  [contacto] varchar(70) DEFAULT NULL,
  [telefono_contacto] varchar(20) DEFAULT NULL,
  [fax_contacto] varchar(20) DEFAULT NULL,
  [email_contacto] varchar(100) DEFAULT NULL,
  [acepta_lopd] datetime2(0) DEFAULT NULL,
  [cif_fra] varchar(20) DEFAULT NULL,
  [direccion_fra] varchar(70) DEFAULT NULL,
  [poblacion_fra] varchar(70) DEFAULT NULL,
  [zip_fra] varchar(10) DEFAULT NULL,
  [nacion_id_factura] smallint DEFAULT NULL,
  [provincia_id_factura] smallint DEFAULT NULL,
  [Cliente_factura] binary(1) NOT NULL DEFAULT b'0',
  [Cliente_huesped] binary(1) NOT NULL,
  [permite_credito] binary(1) NOT NULL DEFAULT b'0',
  [limite_credito] float DEFAULT NULL,
  [factura_anticipada] binary(1) DEFAULT NULL,
  [vencimiento_facturas_id] smallint DEFAULT NULL,
  [fecha_nacimiento] date DEFAULT NULL,
  [user_id] smallint DEFAULT NULL,
  [fecha_modificacion] datetime2(0) DEFAULT NULL,
  [cliente_bavel] varchar(20) DEFAULT NULL,
  [foto1] varchar(256) DEFAULT NULL,
  [foto2] varchar(256) DEFAULT NULL,
  [dingus_extras] binary(1) DEFAULT NULL,
  [id_clubhd] varchar(15) DEFAULT NULL,
  PRIMARY KEY ([cliente_id])
 ,
  CONSTRAINT [clientes_ibfk_10] FOREIGN KEY ([provincia_id_factura]) REFERENCES commonfiles.provincias ([provincia_id]),
  CONSTRAINT [clientes_ibfk_2] FOREIGN KEY ([grupo_cliente_id]) REFERENCES commonfiles.grupos_de_cliente ([grupo_cliente_id]),
  CONSTRAINT [clientes_ibfk_3] FOREIGN KEY ([empresa_id]) REFERENCES commonfiles.empresas ([empresa_id]),
  CONSTRAINT [clientes_ibfk_4] FOREIGN KEY ([sexo_id]) REFERENCES commonfiles.sexos ([sexo_id]),
  CONSTRAINT [clientes_ibfk_5] FOREIGN KEY ([tipo_documento_id]) REFERENCES commonfiles.tipos_documento ([tipo_documento_id]),
  CONSTRAINT [clientes_ibfk_6] FOREIGN KEY ([agencia_id]) REFERENCES clientes ([cliente_id]),
  CONSTRAINT [clientes_ibfk_7] FOREIGN KEY ([nacion_id]) REFERENCES commonfiles.naciones ([nacion_id]),
  CONSTRAINT [clientes_ibfk_8] FOREIGN KEY ([provincia_id]) REFERENCES commonfiles.provincias ([provincia_id]),
  CONSTRAINT [clientes_ibfk_9] FOREIGN KEY ([nacion_id_factura]) REFERENCES commonfiles.naciones ([nacion_id])
)  ;

CREATE INDEX [grupo_cliente_id] ON clientes ([grupo_cliente_id]);
CREATE INDEX [nacion_id] ON clientes ([nacion_id]);
CREATE INDEX [provincia_id] ON clientes ([provincia_id]);
CREATE INDEX [nacion_id_factura] ON clientes ([nacion_id_factura]);
CREATE INDEX [provincia_id_factura] ON clientes ([provincia_id_factura]);
CREATE INDEX [empresa_id] ON clientes ([empresa_id]);
CREATE INDEX [cliente_defecto] ON clientes ([cliente_defecto]);
CREATE INDEX [razon] ON clientes ([razon]);
CREATE INDEX [nif] ON clientes ([nif]);
CREATE INDEX [sexo_id] ON clientes ([sexo_id]);
CREATE INDEX [tipo_documento_id] ON clientes ([tipo_documento_id]);
CREATE INDEX [agencia_id] ON clientes ([agencia_id]);

-- -------------------------------------------
-- Table structure for lineas_de_contrato
-- -------------------------------------------
DROP TABLE IF EXISTS [lineas_de_contrato];
CREATE TABLE lineas_de_contrato (
  [linea_contrato_id] int NOT NULL IDENTITY,
  [contrato_id] int NOT NULL,
  [oferta] smallint DEFAULT NULL,
  [desde] date NOT NULL,
  [hasta] date NOT NULL,
  [servicio_id] int NOT NULL,
  [unidad_calculo_id] smallint NOT NULL,
  [frecuencia_id] smallint DEFAULT '2',
  [tipo_imputacion_id] smallint DEFAULT '0',
  [importe] float NOT NULL,
  [n] smallint DEFAULT NULL,
  [tipo_oferta_id] smallint DEFAULT NULL,
  [m] float DEFAULT NULL,
  [ambito_oferta_id] smallint DEFAULT NULL,
  [lunes] smallint NOT NULL DEFAULT '1',
  [martes] binary(1) NOT NULL DEFAULT b'1',
  [miercoles] binary(1) NOT NULL DEFAULT b'1',
  [jueves] binary(1) NOT NULL DEFAULT b'1',
  [viernes] binary(1) NOT NULL DEFAULT b'1',
  [sabado] binary(1) NOT NULL DEFAULT b'1',
  [domingo] binary(1) NOT NULL DEFAULT b'1',
  [pag_factura] smallint DEFAULT '1',
  [user_id] smallint DEFAULT NULL,
  [fecha_modificacion] datetime2(0) DEFAULT NULL,
  PRIMARY KEY ([linea_contrato_id])
 ,
  CONSTRAINT [lineas_de_contrato_ibfk_1] FOREIGN KEY ([contrato_id]) REFERENCES commonfiles.contratos ([contrato_id]) ON DELETE CASCADE,
  CONSTRAINT [lineas_de_contrato_ibfk_2] FOREIGN KEY ([servicio_id]) REFERENCES commonfiles.servicios ([servicio_id]),
  CONSTRAINT [lineas_de_contrato_ibfk_4] FOREIGN KEY ([tipo_oferta_id]) REFERENCES commonfiles.tipos_de_oferta ([tipo_oferta_id]),
  CONSTRAINT [lineas_de_contrato_ibfk_5] FOREIGN KEY ([unidad_calculo_id]) REFERENCES commonfiles.unidades_calculo ([unidad_calculo_id])
)  ;

CREATE INDEX [tipo_oferta_id] ON lineas_de_contrato ([tipo_oferta_id]);
CREATE INDEX [unidad_calculo_id] ON lineas_de_contrato ([unidad_calculo_id]);
CREATE INDEX [servicio_id] ON lineas_de_contrato ([servicio_id]);
CREATE INDEX [lineas_de_contrato_1] ON lineas_de_contrato ([contrato_id]);
CREATE INDEX [contrato_id] ON lineas_de_contrato ([contrato_id],[servicio_id]);

-- ----------------------------
-- Table structure for contratos
-- ----------------------------
DROP TABLE IF EXISTS [contratos];
CREATE TABLE contratos (
  [contrato_id] int NOT NULL IDENTITY,
  [hotel_id] smallint NOT NULL,
  [cliente_id] int NOT NULL,
  [fecha_contrato] date NOT NULL,
  [fecha_desde] date NOT NULL,
  [fecha_hasta] date NOT NULL,
  [contrato_id_original] int DEFAULT NULL,
  [contrato_id_siguiente] int DEFAULT NULL,
  [numero_contrato_cliente] varchar(40) DEFAULT NULL,
  [user_id] smallint DEFAULT NULL,
  [fecha_modificacion] datetime2(0) DEFAULT NULL,
  [temporada_id] smallint DEFAULT NULL,
  [impuesto_incluido] smallint DEFAULT '1',
  [mercado_id] smallint DEFAULT NULL,
  [cliente_id_padre] int DEFAULT NULL,
  PRIMARY KEY ([contrato_id])
 ,
  CONSTRAINT [contratos_ibfk_1] FOREIGN KEY ([hotel_id]) REFERENCES commonfiles.hoteles ([hotel_id]),
  CONSTRAINT [contratos_ibfk_2] FOREIGN KEY ([cliente_id]) REFERENCES clientes ([cliente_id])
)  ;

CREATE INDEX [hotel_id] ON contratos ([hotel_id]);
CREATE INDEX [cliente_id] ON contratos ([cliente_id]);

-- ----------------------------
-- Table structure for contratos_edades
-- ----------------------------
DROP TABLE IF EXISTS [contratos_edades];
CREATE TABLE contratos_edades (
  [contrato_id] int NOT NULL,
  [tipo_huesped_id] smallint NOT NULL,
  [edad_minima] int NOT NULL,
  [edad_maxima] int NOT NULL,
  [user_id] smallint DEFAULT NULL,
  PRIMARY KEY ([contrato_id],[tipo_huesped_id])
 ,
  CONSTRAINT [contratos_edades_ibfk_1] FOREIGN KEY ([tipo_huesped_id]) REFERENCES commonfiles.tipos_huesped ([tipo_huesped_id]) ON DELETE CASCADE
) ;

CREATE INDEX [tipo_huesped_id] ON contratos_edades ([tipo_huesped_id]);
-- ----------------------------
-- Table structure for ofertas
-- ----------------------------
DROP TABLE IF EXISTS [ofertas];
CREATE TABLE ofertas (
  [oferta_id] int NOT NULL IDENTITY,
  [texto] varchar(60) NOT NULL,
  [contrato_id] int NOT NULL,
  [fecha_desde] date NOT NULL,
  [fecha_hasta] date NOT NULL,
  [tipo_aplicacion_oferta_id] varchar(1) NOT NULL,
  [aplicable_auto] binary(1) NOT NULL,
  [fecha_reserva_desde] date DEFAULT NULL,
  [fecha_reserva_hasta] date DEFAULT NULL,
  [estancia_minima_dias] smallint DEFAULT NULL,
  [estancia_maxima_dias] smallint DEFAULT NULL,
  [dias_de_antelacion] smallint DEFAULT NULL,
  [tipo_servicio_id] smallint DEFAULT NULL,
  [servicio_id] int DEFAULT NULL,
  [unidad_calculo_id] smallint DEFAULT NULL,
  [servicio_ligado_id] int DEFAULT NULL,
  [cupo_oferta] smallint DEFAULT NULL,
  [precio] decimal(15,3) DEFAULT NULL,
  [n] decimal(7,2) DEFAULT '0.00',
  [tipo_oferta_id] smallint DEFAULT NULL,
  [m] decimal(15,3) DEFAULT '0.000',
  [ambito_oferta_id] smallint DEFAULT NULL,
  [user_id] smallint DEFAULT NULL,
  [fecha_modificacion] datetime2(0) DEFAULT NULL,
  [impuesto_incluido] smallint DEFAULT '1',
  [tipo_imputacion_id] smallint NOT NULL DEFAULT '0',
  [orden_aplicacion] smallint DEFAULT NULL,
  PRIMARY KEY ([oferta_id])
 ,
  CONSTRAINT [ofertas_ibfk_10] FOREIGN KEY ([servicio_ligado_id]) REFERENCES commonfiles.servicios ([servicio_id]),
  CONSTRAINT [ofertas_ibfk_11] FOREIGN KEY ([tipo_oferta_id]) REFERENCES commonfiles.tipos_de_oferta ([tipo_oferta_id]),
  CONSTRAINT [ofertas_ibfk_12] FOREIGN KEY ([ambito_oferta_id]) REFERENCES commonfiles.ambito_oferta ([ambito_oferta_id]),
  CONSTRAINT [ofertas_ibfk_2] FOREIGN KEY ([tipo_aplicacion_oferta_id]) REFERENCES commonfiles.tipo_aplicacion_oferta ([tipo_aplicacion_oferta_id]),
  CONSTRAINT [ofertas_ibfk_3] FOREIGN KEY ([contrato_id]) REFERENCES contratos ([contrato_id]) ON DELETE CASCADE,
  CONSTRAINT [ofertas_ibfk_7] FOREIGN KEY ([tipo_servicio_id]) REFERENCES commonfiles.tipos_servicio ([tipo_servicio_id]),
  CONSTRAINT [ofertas_ibfk_8] FOREIGN KEY ([servicio_id]) REFERENCES servicios ([servicio_id]),
  CONSTRAINT [ofertas_ibfk_9] FOREIGN KEY ([unidad_calculo_id]) REFERENCES commonfiles.unidades_calculo ([unidad_calculo_id])
)  ;

CREATE INDEX [cliente_id] ON ofertas ([contrato_id]);
CREATE INDEX [tipo_aplicacion_oferta_id] ON ofertas ([tipo_aplicacion_oferta_id]);
CREATE INDEX [servicio_id] ON ofertas ([servicio_id]);
CREATE INDEX [ofertas_ibfk_10] ON ofertas ([servicio_ligado_id]);
CREATE INDEX [ofertas_ibfk_11] ON ofertas ([tipo_oferta_id]);
CREATE INDEX [ofertas_ibfk_12] ON ofertas ([ambito_oferta_id]);
CREATE INDEX [ofertas_ibfk_7] ON ofertas ([tipo_servicio_id]);
CREATE INDEX [ofertas_ibfk_9] ON ofertas ([unidad_calculo_id]);

-- -----------------------------------------
-- Table structure for ofertas_servicios
-- -----------------------------------------
DROP TABLE IF EXISTS [ofertas_servicios];
CREATE TABLE ofertas_servicios (
  [ofertas_servicio_id] int NOT NULL IDENTITY,
  [oferta_id] int NOT NULL,
  [servicio_id] int NOT NULL,
  [unidad_calculo_id] smallint DEFAULT NULL,
  [cantidad] float DEFAULT NULL,
  [precio] float DEFAULT NULL,
  [servico_id_existe] int DEFAULT NULL,
  PRIMARY KEY ([ofertas_servicio_id])
 ,
  CONSTRAINT [ofertas_servicios_ibfk_1] FOREIGN KEY ([servicio_id]) REFERENCES commonfiles.servicios ([servicio_id]),
  CONSTRAINT [ofertas_servicios_ibfk_2] FOREIGN KEY ([unidad_calculo_id]) REFERENCES commonfiles.unidades_calculo ([unidad_calculo_id]),
  CONSTRAINT [ofertas_servicios_ibfk_3] FOREIGN KEY ([oferta_id]) REFERENCES ofertas ([oferta_id]),
  CONSTRAINT [ofertas_servicios_ibfk_4] FOREIGN KEY ([servico_id_existe]) REFERENCES commonfiles.servicios ([servicio_id])
)  ;

CREATE INDEX [oferta_id] ON ofertas_servicios ([oferta_id]);
CREATE INDEX [unidad_calculo_id] ON ofertas_servicios ([unidad_calculo_id]);
CREATE INDEX [ofertas_servicios_ibfk_1] ON ofertas_servicios ([servicio_id]);
CREATE INDEX [servico_id_existe] ON ofertas_servicios ([servico_id_existe]);

-- ----------------------------
-- Table structure for ofertas_rejillas
-- ----------------------------
DROP TABLE IF EXISTS [ofertas_rejillas];
CREATE TABLE ofertas_rejillas (
  [rejilla_id] int check ([rejilla_id] > 0) NOT NULL IDENTITY,
  [oferta_id] int NOT NULL,
  [n] smallint check ([n] > 0) NOT NULL,
  [tipo_condicion_id] smallint DEFAULT NULL,
  [tipo_aplicacion] smallint check ([tipo_aplicacion] > 0) DEFAULT NULL,
  [m] float NOT NULL,
  PRIMARY KEY ([rejilla_id])
 ,
  CONSTRAINT [ofertas_rejillas_ibfk_1] FOREIGN KEY ([oferta_id]) REFERENCES ofertas ([oferta_id]) ON DELETE CASCADE,
  CONSTRAINT [ofertas_rejillas_ibfk_2] FOREIGN KEY ([tipo_condicion_id]) REFERENCES commonfiles.tipos_condicion ([tipo_condicion_id])
)  ;

CREATE INDEX [oferta_id] ON ofertas_rejillas ([oferta_id]);
CREATE INDEX [tipo_condicion_id] ON ofertas_rejillas ([tipo_condicion_id]);

