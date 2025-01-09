

/***** Registros SueldosCategorias *****/

INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (110, 'MAESTRANZA "A"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (120, 'MAESTRANZA "B"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (130, 'MAESTRANZA "C"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (210, 'ADMINISTRATIVO "A"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (220, 'ADMINISTRATIVO "B"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (230, 'ADMINISTRATIVO "C"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (240, 'ADMINISTRATIVO "D"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (250, 'ADMINISTRATIVO "E"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (260, 'ADMINISTRATIVO "F"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (310, 'CAJERO "A"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (320, 'CAJERO "B"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (330, 'CAJERO "C"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (410, 'AUXILIAR "A"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (420, 'AUXILIAR "B"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (430, 'AUXILIAR "C"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (510, 'AUXILIAR ESPECIALIZADO "A"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (520, 'AUXILIAR ESPECIALIZADO "B"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (610, 'VENDEDOR "A"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (620, 'VENDEDOR "B"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (630, 'VENDEDOR "C"')
GO
INSERT INTO SueldosCategorias (idCategoria, NombreCategoria) VALUES (640, 'VENDEDOR "D"')
GO


/***** Registros SueldosEstadoCivil *****/

INSERT INTO SueldosEstadoCivil (idEstadoCivil, NombreEstadoCivil) VALUES (1, 'CASADO')
GO
INSERT INTO SueldosEstadoCivil (idEstadoCivil, NombreEstadoCivil) VALUES (2, 'SOLTERO')
GO
INSERT INTO SueldosEstadoCivil (idEstadoCivil, NombreEstadoCivil) VALUES (3, 'SEPARADO')
GO
INSERT INTO SueldosEstadoCivil (idEstadoCivil, NombreEstadoCivil) VALUES (4, 'DIVORCIADO')
GO
INSERT INTO SueldosEstadoCivil (idEstadoCivil, NombreEstadoCivil) VALUES (5, 'VIUDO')
GO
INSERT INTO SueldosEstadoCivil (idEstadoCivil, NombreEstadoCivil) VALUES (6, 'OTRO')
GO


/***** Registros SueldosLugaresActividad *****/

INSERT INTO SueldosLugaresActividad (IdLugarActividad, NombreLugarActividad) VALUES (1, 'EMPRESA')
GO


/***** Registros SueldosMotivosBaja *****/

INSERT INTO SueldosMotivosBaja (IdMotivoBaja, NombreMotivoBaja) VALUES (1, 'Renuncia')
GO
INSERT INTO SueldosMotivosBaja (IdMotivoBaja, NombreMotivoBaja) VALUES (2, 'Despido')
GO
INSERT INTO SueldosMotivosBaja (IdMotivoBaja, NombreMotivoBaja) VALUES (3, 'Fallecimiento')
GO
INSERT INTO SueldosMotivosBaja (IdMotivoBaja, NombreMotivoBaja) VALUES (4, 'Jubilacion')
GO


/***** Registros SueldosMotivosBaja *****/

INSERT INTO SueldosObraSocial (IdObraSocial, NombreObraSocial) VALUES (1, 'OSECAC')
GO
INSERT INTO SueldosObraSocial (IdObraSocial, NombreObraSocial) VALUES (2, 'OTRA' )
GO


/***** Registros SueldosQuePideConcepto *****/

INSERT INTO SueldosQuePideConcepto (idQuePide, NombreQuePide) VALUES (0, '*NO* ')
GO
INSERT INTO SueldosQuePideConcepto (idQuePide, NombreQuePide) VALUES (1, 'CANTIDAD')
GO
INSERT INTO SueldosQuePideConcepto (idQuePide, NombreQuePide) VALUES (2, 'IMPORTE')
GO
INSERT INTO SueldosQuePideConcepto (idQuePide, NombreQuePide) VALUES (3, 'PORCENTAJE')
GO


/***** Registros SueldosQuePideConcepto *****/

INSERT INTO SueldosTiposConceptos (idTipoConcepto, NombreTipoConcepto) VALUES (1 , 'HABERES')
GO
INSERT INTO SueldosTiposConceptos (idTipoConcepto, NombreTipoConcepto) VALUES (2 , 'RETENCIONES')
GO
INSERT INTO SueldosTiposConceptos (idTipoConcepto, NombreTipoConcepto) VALUES (3 , 'APORTES')
GO
INSERT INTO SueldosTiposConceptos (idTipoConcepto, NombreTipoConcepto) VALUES (4 , 'HAB.S/AGUINALDO')
GO
INSERT INTO SueldosTiposConceptos (idTipoConcepto, NombreTipoConcepto) VALUES (5 , 'DESCUENTO')
GO
INSERT INTO SueldosTiposConceptos (idTipoConcepto, NombreTipoConcepto) VALUES (6 , 'S.FAMILIAR')
GO
INSERT INTO SueldosTiposConceptos (idTipoConcepto, NombreTipoConcepto) VALUES (7 , 'INDEMNIZACION')
GO
INSERT INTO SueldosTiposConceptos (idTipoConcepto, NombreTipoConcepto) VALUES (8 , 'NO REMUNERATIVO')
GO
INSERT INTO SueldosTiposConceptos (idTipoConcepto, NombreTipoConcepto) VALUES (9 , 'RET.S/AGUINALDO')
GO
INSERT INTO SueldosTiposConceptos (idTipoConcepto, NombreTipoConcepto) VALUES (10 , 'APO.S/AGUINALDO')
GO


/***** Registros SueldosQuePideConcepto *****/

INSERT INTO SueldosTiposRecibos
           ([IdTipoRecibo],[NombreTipoRecibo], [PeriodoLiquidacion], [NumeroLiquidacion], [ImprimeRecibo])
     VALUES
           (1, 'Sueldo', 201109, 1, 'True')
GO

INSERT INTO SueldosTiposRecibos
           (IdTipoRecibo, NombreTipoRecibo, PeriodoLiquidacion, NumeroLiquidacion, ImprimeRecibo)
     VALUES
           (2, 'Liquidación Final', 201109, 1, 'False')
GO


/***** Registros SueldosConceptos *****/

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (1, 1, 'SUELDO BASICO', 0.00, 'P', 'N', 0, 'BASICO', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (7, 1, 'HORAS EXTRAS ( 50% )', 0.00, 'P', 'N', 1, 'BASICO / 200 * LIQVALOR * 1.5', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (8, 1, 'HORAS EXTRAS ( 100% )', 0.00, 'P', 'N', 1, 'BASICO / 200 * LIQVALOR * 2', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (719, 5, 'DESC. POR FALLAS DE CAJA', 0.00, 'P', 'N', 2, '267.93', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (10, 1, 'DIAS NORMALES', 0.00, 'U', 'N', 1, 'BASICO / 30 * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (11, 1, 'DIAS FEBRERO', 0.00, 'U', 'N', 1, 'BASICO / 30 * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (720, 5, 'DIAS DE DESCUENTO', 0.00, 'P', 'N', 0, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (13, 1, 'DIA EMPLEADO DE UTEDYC', 0.00, 'P', 'N', 1, 'BASICO / 30 * LIQVALOR', 'False', 'XX' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (14, 1, 'VACACIONES ANUALES', 0.00, 'U', 'N', 1, '982.75 / 25 * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (15, 1, 'VACACIONES PROPORCIONAL', 0.00, 'U', 'N', 1, '( BASICO ) / 25 * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (16, 1, 'LICENCIA MATRIMONIO', 0.00, 'P', 'N', 1, 'BASICO / 30 * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (17, 1, 'LIC.NAC. HIJO', 0.00, 'P', 'N', 1, 'BASICO / 30 * LIQVALOR', 'False', 'XXX XXXXXXX' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (18, 1, 'HS.ENFERMEDAD', 0.00, 'P', 'N', 0, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (19, 1, 'INC. TRIM.', 0.00, 'P', 'N', 0, 'BASICO * 15 / 100', 'False', 'X' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (20, 1, 'HS.FERIADOS', 0.00, 'P', 'N', 0, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (21, 1, 'SUELDO POR KM.REC', 0.00, 'U', 'N', 2, 'LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (22, 1, 'SAC PROPORC.', 118.50, 'P', 'N', 2, 'LIQVALOR', 'False', 'X X' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (23, 1, 'DIA DEL EMP.DE CO', 0.00, 'P', 'N', 0, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (5, 1, 'PUNTUALIDAD Y PRESENTISMO', 0.00, 'P', 'N', 0, 'BASICO * 10 / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (24, 1, 'AUMENTO SUELDO(%)', 2.00, 'P', 'N', 0, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (25, 1, 'COMIS.P/COBRO', 0.00, 'P', 'N', 2, 'LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (241, 4, 'AGUINALDO', 0.00, 'P', 'S', 0, 'LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (301, 5, 'ANTICIPO SUELDO Y/O VAC.', 0.00, 'U', 'N', 2, 'LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (310, 5, 'RETENCION JUDICIAL', 0.00, 'U', 'N', 2, 'LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (305, 5, 'DESC. PRESENTISMO', 28.00, 'U', 'N', 2, 'LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (315, 5, 'ANT. SAC', 0.00, 'U', 'N', 2, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (316, 7, 'SUSTIT.PREAVISO-INDEMNIZ.', 0.00, 'U', 'N', 2, 'LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (317, 7, 'INDEMIZAC. POR ANTIG.', 0.00, 'U', 'N', 2, 'LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (318, 7, 'MES INTEGRAC.', 0.00, 'U', 'N', 2, '( BASICO ) / 30 * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (319, 7, 'SAC PREAVISO', 0.00, 'U', 'N', 2, 'LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (320, 6, 'LIC.P/MATERNIDAD', 0.00, 'U', 'N', 2, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (321, 7, 'SAC S/PREAVISO', 0.00, 'U', 'N', 2, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (326, 7, 'VAC. PROP.', 0.00, 'U', 'N', 1, 'BASICO / 25 * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (327, 7, 'SAC VAC. PROP.', 0.00, 'U', 'N', 1, '( BASICO / 25 * LIQVALOR ) / 12', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (304, 6, 'RET. OCTUBRE DIF. SALARIO', 15.00, 'U', 'N', 1, 'CODVALOR * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (329, 8, 'ADICIONAL', 165.00, 'P', 'N', 2, 'CODVALOR', 'True', 'XXXXX XXXXXX' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (330, 8, 'AJUSTE NO REMUN. MES ANT.', 30.00, 'U', 'N', 2, 'CODVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (341, 7, 'PRESENT.VAC.PROP.', 8.33, 'U', 'N', 2, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (302, 6, 'SALARIO HIJO', 136.00, 'P', 'N', 1, 'CODVALOR * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (353, 6, 'ESC.PRIMARIA', 3.00, 'P', 'N', 1, 'CODVALOR * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (354, 6, 'ESC.MED.SUP', 4.50, 'P', 'N', 1, 'CODVALOR * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (355, 6, 'FAM.NUMEROSA', 3.00, 'P', 'N', 1, 'CODVALOR * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (356, 6, 'ESC.PRIMARIA-FN', 3.00, 'P', 'N', 1, 'CODVALOR * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (357, 6, 'ESC.MED.SUP-FN', 4.50, 'P', 'N', 1, 'CODVALOR * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (358, 6, 'HIJO DISCAPAC.', 120.00, 'P', 'N', 2, 'CODVALOR * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (359, 6, 'AYUDA ESCOLAR', 130.00, 'P', 'N', 1, 'CODVALOR * LIQVALOR', 'True', 'XXX' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (361, 6, 'PRENATAL', 136.00, 'U', 'N', 1, 'CODVALOR * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (362, 6, 'HIJO MENOR 4 A¥OS', 3.00, 'P', 'N', 1, 'CODVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (364, 6, 'LIC/MATERNIDAD', 696.45, 'P', 'N', 1, 'CODVALOR', 'False', 'XXX' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (365, 6, 'LIC. MATERNIDAD AJUSTE', 61.76, 'P', 'N', 1, 'CODVALOR', 'True', 'X      X' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (367, 6, 'NACIMIENTO', 64.20, 'P', 'N', 0, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (368, 6, 'DIF.PRENATAL', 0.00, 'P', 'N', 0, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (370, 6, 'RETROACTIVO JULIO 2006', 0.00, 'U', 'N', 2, 'CODVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (371, 6, 'DIF. PRENATAL', 0.00, 'P', 'N', 0, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (372, 6, 'DIF. HIJO', 0.00, 'P', 'N', 0, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (102, 2, 'LEY 19032', 3.00, 'P', 'N', 3, 'HABERES * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (103, 2, 'OSPEDYC', 3.00, 'P', 'N', 3, 'HABERES * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (104, 2, 'CUOTA SINDICAL UTEDYC', 2.50, 'P', 'N', 3, 'HABERES * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (515, 2, 'C.NAC.DE AHORR.ME', 10.00, 'P', 'N', 3, 'HABERES * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (521, 2, 'IM.FONDO SAL.PUB.', 0.50, 'P', 'N', 3, 'HABERES * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (522, 2, 'SIND. A.E.C.', 1.00, 'P', 'N', 3, 'HABERES * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (523, 2, 'RET.1/2 DIA O.S.', 3.00, 'P', 'N', 3, 'HABERES * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (524, 2, 'LEY 5110', 2.00, 'P', 'N', 3, 'HABERES * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (525, 2, 'FONDO COMP.MERC.', 2.00, 'P', 'N', 3, 'HABERES * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (526, 2, 'SIND. A.E.C.', 2.00, 'P', 'N', 3, 'HABERES * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (527, 2, 'A.E.C.CUOTA GR.', 3.00, 'P', 'N', 3, 'HABERES * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (528, 2, 'F.A.E.C.Y.S', 0.50, 'P', 'N', 3, 'HABERES * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (571, 2, 'AJ.RET.MES ANTER', 0.00, 'P', 'N', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (572, 2, 'IMP.A LOS REDITOS', 0.00, 'P', 'N', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (573, 2, 'SEGURO', 0.18, 'P', 'N', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (591, 2, 'SEGURO', 0.18, 'P', 'N', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (592, 2, 'FED.ARG.EMP.COM.', 3000.00, 'P', 'N', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (601, 9, 'JUBILACION AGUIN', 11.00, 'P', 'S', 3, 'HABEAGUIN * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (602, 9, 'LEY 19032 JUBIL', 3.00, 'P', 'S', 3, 'HABEAGUIN * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (603, 9, 'OSPEDYC - AGUI', 3.00, 'P', 'S', 3, 'HABEAGUIN * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (604, 9, 'OSECAC - AGUI', 3.00, 'P', 'S', 3, 'HABEAGUIN * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (607, 9, 'SIND.UTEDYC-AGUI', 2.50, 'P', 'S', 3, 'HABEAGUIN * LIQVALOR / 100', 'False', 'X     X' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (608, 9, 'A.E.C. AG', 2.00, 'P', 'S', 3, 'HABEAGUIN * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (611, 9, 'C.GRE.AEC-AGUI', 1.00, 'P', 'S', 2, 'CODVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (615, 9, 'C.NAC.AHORR.M.AG.', 10.00, 'P', 'S', 3, 'HABEAGUIN * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (621, 9, 'I.F.S.P.AG.', 0.50, 'P', 'S', 3, 'HABEAGUIN * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (622, 9, 'A.E.C. AG.', 1.00, 'P', 'S', 3, 'HABEAGUIN * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (623, 9, 'LEY 5110', 3.00, 'P', 'S', 3, 'HABEAGUIN * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (624, 9, 'RET.1/2 DIA O.S.', 3.00, 'P', 'S', 3, 'HABEAGUIN * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (625, 9, 'FONDO COMP.MERC.', 2.00, 'P', 'S', 3, 'HABEAGUIN * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (626, 9, 'A.E.C. AGU.', 2.00, 'P', 'S', 3, 'HABEAGUIN * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (627, 9, 'A.E.C. CUOT.G.SAC', 3.00, 'P', 'S', 3, 'HABEAGUIN * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (628, 9, 'F.A.E.C.Y.S.', 0.50, 'P', 'S', 3, 'HABEAGUIN * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (702, 3, 'L.22269- OSECAC', 6.00, 'P', 'N', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (703, 3, 'L.22269-OSECAC', 6.00, 'P', 'N', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (707, 3, 'IMP.F.SAL.PUB.', 0.50, 'P', 'N', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (708, 3, 'APORTE JUBILAT.', 7.50, 'P', 'N', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (714, 3, 'INST.N.JUB.Y.PEN.', 2.00, 'P', 'N', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (715, 3, 'ASIG. FAM.', 9.00, 'P', 'N', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (716, 3, 'AP.JUBILATORIO', 16.00, 'P', 'N', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (717, 3, 'AP. LEY 19032', 2.00, 'P', 'N', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (718, 3, 'JUBILACION A.E.C.', 3.50, 'P', 'N', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (802, 10, 'L.22269-OSECAC AG', 6.00, 'P', 'S', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (803, 10, 'L.22269-OSECAC AG', 6.00, 'P', 'S', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (807, 10, 'IMP.F.SAL.PUB.', 0.50, 'P', 'S', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (815, 10, 'F.O.N.A.V.I.', 5.00, 'P', 'S', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (816, 10, 'AP.JUBIL.AGUIN.', 12.50, 'P', 'S', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (850, 10, 'CASFEC', 9.00, 'P', 'S', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (851, 10, 'CASFEC', 9.00, 'P', 'S', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (898, 10, 'MINIMO', 1.00, 'P', 'S', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (899, 10, 'MINIMO', 1.00, 'P', 'S', 3, '', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (2, 8, 'RETROACTIVO JULIO 07', 0.00, 'P', 'N', 2, 'LIQVALOR', 'True', 'XXXXXXXXXXX' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (612, 2, 'A.E.C SERV.SOC.', 6.50, 'P', 'S', 2, 'CODVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (513, 2, 'AEC SERV. DE SEPELIO', 3.00, 'P', 'N', 2, 'LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (613, 2, 'AEC SERV. SEPELIO', 1.50, 'P', 'S', 2, 'LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (3, 1, 'ANTIGšEDAD', 0.00, 'P', 'N', 0, '1524 * 1 / 100 * ANTIGUEDAD', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (4, 1, 'MANEJO MAQUINA CONTABLE', 0.00, 'P', 'N', 0, 'BASICO * 10 / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (101, 2, 'JUBILACION', 7.00, 'P', 'N', 3, 'HABERES * LIQVALOR / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (6, 1, 'INCENTIVO TRIMESTRAL', 0.00, 'P', 'N', 0, 'BASICO * 15 / 100', 'False', 'X  X  X  X' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (303, 6, 'SALARIO HIJO', 180.00, 'P', 'N', 1, 'CODVALOR * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (360, 6, 'AYUDA ESCOLAR', 170.00, 'P', 'N', 1, 'CODVALOR * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (26, 1, 'MEDIO DIA', 0.00, 'U', 'N', 1, 'BASICO / 60 * LIQVALOR', 'False', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (9, 1, 'HORAS EXTRAS', 2.00, 'P', 'N', 1, 'BASICO / 200 * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (12, 1, 'DIAS ACCIDENTE', 0.00, 'P', 'N', 1, 'BASICO / 30 * LIQVALOR', 'False', 'XXXX' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (306, 6, 'RET. OCTUBRE SALARIO HIJO', 1.00, 'P', 'N', 1, 'CODVALOR * LIQVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (27, 1, 'INCENTIVO TRIMESTRAL', 0.00, 'P', 'N', 0, 'BASICO * 15 / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (28, 1, 'ADIC.REM.DEC.1347', 60.00, 'P', 'N', 2, 'CODVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (29, 1, 'ADIC.REMUN.2004/05', 120.00, 'P', 'N', 2, 'CODVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (30, 1, 'A CTA. FUTUROS AUMENTOS', 150.00, 'P', 'N', 2, 'CODVALOR', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (31, 1, 'FALLA DE CAJA', 0.00, 'P', 'N', 0, '2276 * 10 / 100', 'True', '' )
GO

INSERT INTO SueldosConceptos
      (idConcepto, idTipoConcepto, NombreConcepto, Valor, Tipo, Aguinaldo, idQuepide, Formula, LiquidacionAnual, LiquidacionMeses)
 VALUES
     (32, 1, 'FALA DE CAJA (RETROACT.)', 0.00, 'P', 'N', 0, '227.60 * 24', 'True', '' )
GO

