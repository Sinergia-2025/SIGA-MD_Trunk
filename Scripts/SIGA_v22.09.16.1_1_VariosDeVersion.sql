
PRINT ''
PRINT '1. Tabla CalidadListasControlProductosItems: Chequea que exista FK'
IF exists
(
SELECT
    * 
    FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
    WHERE CONSTRAINT_NAME ='FK_CalidadListasControlProductosItems_CalidadListasControlConfig'
)
BEGIN

    PRINT ''
    PRINT '1.1. Tabla CalidadListasControlProductosItems: DROP  CONSTRAINT [FK_CalidadListasControlProductosItems_CalidadListasControlConfig]'
    ALTER TABLE CalidadListasControlProductosItems DROP  CONSTRAINT [FK_CalidadListasControlProductosItems_CalidadListasControlConfig]

    PRINT ''
    PRINT '1.2. Tabla CalidadListasControlConfigLinks: DROP  CONSTRAINT [FK_CalidadListasControlConfigLinks_CalidadListasControlConfig]'
    ALTER TABLE CalidadListasControlConfigLinks DROP CONSTRAINT FK_CalidadListasControlConfigLinks_CalidadListasControlConfig


    PRINT ''
    PRINT '1.3. Tabla CalidadListasControlConfigLinks: ADD  CONSTRAINT [FK_CalidadListasControlConfigLinks_CalidadListasControlConfig]'
    ALTER TABLE [dbo].[CalidadListasControlConfigLinks]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlConfigLinks_CalidadListasControl] FOREIGN KEY([IdListaControl])
    REFERENCES [dbo].[CalidadListasControl] ([IdListaControl])

    ALTER TABLE [dbo].[CalidadListasControlConfigLinks] CHECK CONSTRAINT [FK_CalidadListasControlConfigLinks_CalidadListasControl]

    PRINT ''
    PRINT '1.4. Tabla CalidadListasControlConfigLinks: ADD  CONSTRAINT [FK_CalidadListasControlConfigLinks_CalidadListasControlItems]'
    ALTER TABLE [dbo].[CalidadListasControlConfigLinks]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlConfigLinks_CalidadListasControlItems] FOREIGN KEY([Item])
    REFERENCES [dbo].[CalidadListasControlItems] ([IdListaControlItem])

    ALTER TABLE [dbo].[CalidadListasControlConfigLinks] CHECK CONSTRAINT [FK_CalidadListasControlConfigLinks_CalidadListasControlItems]

END

PRINT ''
PRINT '2. Tabla CalidadListasControl: Chequea que exista columna ControlaProduccion'

IF not exists
(
SELECT *
FROM INFORMATION_SCHEMA.COLUMNS
WHERE COLUMN_NAME = 'ControlaProduccion' AND TABLE_NAME = 'CalidadListasControl'
)
BEGIN
 --controlar que exista el campo
    PRINT ''
    PRINT '2.1. Tabla CalidadListasControl: Nuevas Columnas ControlaProduccion, ControlaCalidad, Controla5SProduccion, Controla5SCalidad y InicioAutomatico'
    ALTER TABLE CalidadListasControl ADD ControlaProduccion bit not null
    ALTER TABLE CalidadListasControl ADD ControlaCalidad bit not null
    ALTER TABLE CalidadListasControl ADD Controla5SProduccion bit not null
    ALTER TABLE CalidadListasControl ADD Controla5SCalidad bit not null
    ALTER TABLE CalidadListasControl ADD InicioAutomatico bit not null 
END

GO


PRINT ''
PRINT '3. Tabla BuscadoresCampos: Bancos actualiza Buscador'

UPDATE BuscadoresCampos SET IdBuscador = 40 where IdBuscador = 30 AND IdBuscadorNombreCampo = 'IdBanco'
UPDATE BuscadoresCampos SET IdBuscador = 40 where IdBuscador = 30 AND IdBuscadorNombreCampo = 'NombreBanco'
