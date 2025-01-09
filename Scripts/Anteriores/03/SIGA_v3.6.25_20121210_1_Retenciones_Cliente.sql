
-- Drop CHECK CONSTRAINT from the table
ALTER TABLE CuentasCorrientesRetenciones
	DROP CONSTRAINT FK_CuentasCorrientesRetenciones_Retenciones
GO

-- Drop CHECK CONSTRAINT from the table
ALTER TABLE Retenciones
	DROP CONSTRAINT PK_Retenciones
GO

-- Modify column to the table
ALTER TABLE Retenciones
	ALTER COLUMN TipoDocCliente varchar(5) NOT NULL 
GO

-- Modify column to the table
ALTER TABLE Retenciones
	ALTER COLUMN NroDocCliente varchar(12) NOT NULL 
GO


-- Add a new PRIMARY KEY CONSTRAINT to the table
ALTER TABLE Retenciones
  ADD CONSTRAINT PK_Retenciones PRIMARY KEY (
  [IdSucursal] ASC,
	[IdTipoImpuesto] ASC,
	[EmisorRetencion] ASC,
	[NumeroRetencion] ASC,
	TipoDocCliente ASC,
	NroDocCliente ASC
  )
GO

-- Drop CHECK CONSTRAINT from the table
ALTER TABLE CuentasCorrientesRetenciones
	DROP CONSTRAINT PK_CuentasCorrientesRetenciones
GO

-- Add column to the table
ALTER TABLE CuentasCorrientesRetenciones
	ADD TipoDocCliente varchar(5) NULL
GO

-- Add column to the table
ALTER TABLE CuentasCorrientesRetenciones
	ADD NroDocCliente varchar(12) NULL
GO

-------------------------
------------------------
-------------------------
    -- declaramos las variables
  declare @tipoDocCli as varchar(5)
  declare @nroDocCli as varchar(12)
   declare @idSucursal as int
    declare @idTipoComp as varchar(15)
     declare @letra as varchar(1)
      declare @centroEmisor as int
       declare @numeroCompro as bigint
    -- declaramos un cursor llamado "CURSORITO". 
        declare CURSORITO cursor for
  select IdSucursal, 
			IdTipoComprobante, 
			Letra,
			CentroEmisor,
			NumeroComprobante,
			 TipoDocCliente, 
			 NroDocCliente
			 from CuentasCorrientes
    open CURSORITO
        -- Avanzamos un registro y cargamos en las variables los valores encontrados en el primer registro
  fetch next from CURSORITO
  into @idSucursal, @idTipoComp, @letra, @centroEmisor, @numeroCompro, @tipoDocCli, @nroDocCli
      while @@fetch_status = 0
    begin
    update CuentasCorrientesRetenciones 
		set TipoDocCliente= @tipoDocCli,
			NroDocCliente=@nroDocCli 
			where idsucursal = @idSucursal
			and idtipocomprobante = @idTipoComp
			and letra = @letra
			and CentroEmisor = @centroEmisor
			and numerocomprobante = @numeroCompro
    -- Avanzamos otro registro
    fetch next from CURSORITO
    into @idSucursal, @idTipoComp, @letra, @centroEmisor, @numeroCompro, @tipoDocCli, @nroDocCli
    end
    -- cerramos el cursor
        close CURSORITO
  deallocate CURSORITO
  
  --------------------------------------
  ----------------------------------------

-- Modify column to the table
ALTER TABLE CuentasCorrientesRetenciones
	ALTER COLUMN TipoDocCliente varchar(5) NOT NULL 
GO

-- Modify column to the table
ALTER TABLE CuentasCorrientesRetenciones
	ALTER COLUMN NroDocCliente varchar(12) NOT NULL 
GO

ALTER TABLE CuentasCorrientesRetenciones
  ADD CONSTRAINT PK_CuentasCorrientesRetenciones PRIMARY KEY (
  [IdSucursal] ASC,
	IdTipoComprobante ASC,
	Letra ASC,
	CentroEmisor ASC,
	NumeroComprobante ASC,
	IdTipoImpuesto ASC,
	EmisorRetencion ASC,
	NumeroRetencion ASC,
	TipoDocCliente ASC,
	NroDocCliente ASC
  )
GO

-- Add a new CHECK CONSTRAINT to the table
ALTER TABLE [dbo].[CuentasCorrientesRetenciones]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesRetenciones_Retenciones] FOREIGN KEY([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion], TipoDocCliente,NroDocCliente)
REFERENCES [dbo].[Retenciones] ([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion],TipoDocCliente,NroDocCliente)
GO

ALTER TABLE [dbo].[CuentasCorrientesRetenciones] CHECK CONSTRAINT [FK_CuentasCorrientesRetenciones_Retenciones]
GO

