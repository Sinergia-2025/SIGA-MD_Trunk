PRINT ''
PRINT '2. Inicializar Numerador para SIRPLUS'

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('30714374938'))
BEGIN
INSERT INTO Numeradores
          (IdNumerador,Numero,Descripcion)
VALUES('SIRPLUS', 0, '')
END
GO

IF dbo.ExisteCampo('Intereses', 'VencimientoExcluyeSabado') = 0
BEGIN
    ALTER TABLE dbo.Intereses ADD VencimientoExcluyeSabado bit NULL
    ALTER TABLE dbo.Intereses ADD VencimientoExcluyeDomingo bit NULL
    ALTER TABLE dbo.Intereses ADD VencimientoExcluyeFeriados bit NULL
END
GO

UPDATE Intereses
   SET VencimientoExcluyeSabado   = 'False'
     , VencimientoExcluyeDomingo  = 'False'
     , VencimientoExcluyeFeriados = 'False'
 WHERE VencimientoExcluyeSabado IS NULL;

ALTER TABLE dbo.Intereses ALTER COLUMN VencimientoExcluyeSabado   bit NOT NULL
ALTER TABLE dbo.Intereses ALTER COLUMN VencimientoExcluyeDomingo  bit NOT NULL
ALTER TABLE dbo.Intereses ALTER COLUMN VencimientoExcluyeFeriados bit NOT NULL
GO

/*
ALTER TABLE Clientes DROP COLUMN SaldoLimiteDeCredito
ALTER TABLE AuditoriaClientes DROP COLUMN SaldoLimiteDeCredito
ALTER TABLE Prospectos DROP COLUMN SaldoLimiteDeCredito
ALTER TABLE AuditoriaProspectos DROP COLUMN SaldoLimiteDeCredito
*/

IF dbo.ExisteCampo('Clientes', 'SaldoLimiteDeCredito') = 0
BEGIN
    ALTER TABLE Clientes ADD SaldoLimiteDeCredito decimal(16, 2) NULL
    ALTER TABLE AuditoriaClientes ADD SaldoLimiteDeCredito decimal(16, 2) NULL
    ALTER TABLE Prospectos ADD SaldoLimiteDeCredito decimal(16, 2) NULL
    ALTER TABLE AuditoriaProspectos ADD SaldoLimiteDeCredito decimal(16, 2) NULL
END
GO
UPDATE Clientes
   SET SaldoLimiteDeCredito = LimiteDeCredito
 WHERE SaldoLimiteDeCredito IS NULL;
UPDATE Prospectos
   SET SaldoLimiteDeCredito = LimiteDeCredito
 WHERE SaldoLimiteDeCredito IS NULL;

ALTER TABLE Clientes ALTER COLUMN SaldoLimiteDeCredito decimal(16, 2) NOT NULL
ALTER TABLE Prospectos ALTER COLUMN SaldoLimiteDeCredito decimal(16, 2) NOT NULL
GO

ALTER TABLE Clientes ALTER COLUMN LimiteDeCredito decimal(16, 2) NOT NULL
ALTER TABLE AuditoriaClientes ALTER COLUMN LimiteDeCredito decimal(16, 2) NULL
ALTER TABLE Prospectos ALTER COLUMN LimiteDeCredito decimal(16, 2) NOT NULL
ALTER TABLE AuditoriaProspectos ALTER COLUMN LimiteDeCredito decimal(16, 2) NULL

IF dbo.ExisteTabla('LiquidacionesClientes') = 1
BEGIN
    IF dbo.ExisteCampo('LiquidacionesClientes', 'SaldoLimiteDeCredito') = 0
    BEGIN
        ALTER TABLE LiquidacionesClientes ADD SaldoLimiteDeCredito decimal(16, 2) NULL
    END
    ALTER TABLE LiquidacionesClientes ALTER COLUMN LimiteDeCredito decimal(16, 2) NULL
END
GO

IF dbo.ExisteFuncion('CuentasCorrientes') = 1 AND dbo.ExisteFuncion('SituacionCrediticiaCalcMasivo') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('SituacionCrediticiaCalcMasivo', 'Cálculo Saldo Límite de Crédito', 'Cálculo Saldo Límite de Crédito', 'True', 'False', 'True', 'True'
        ,'CuentasCorrientes', 66, 'Eniac.Win', 'EstadoSituacionCrediticiaCalculoMasivo', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'SituacionCrediticiaCalcMasivo' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
go