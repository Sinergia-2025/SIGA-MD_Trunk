INSERT INTO AuditoriaClientes
           (FechaAuditoria
           ,OperacionAuditoria
           ,UsuarioAuditoria
           ,TipoDocumento
           ,NroDocumento
           ,NombreCliente
           ,Direccion
           ,IdLocalidad
           ,Telefono
           ,FechaNacimiento
           ,NroOperacion
           ,CorreoElectronico
           ,Celular
           ,NombreTrabajo
           ,DireccionTrabajo
           ,IdLocalidadTrabajo
           ,TelefonoTrabajo
           ,CorreoTrabajo
           ,FechaIngresoTrabajo
           ,FechaAlta
           ,SaldoPendiente
           ,TipoDocumentoGarante
           ,NroDocumentoGarante
           ,IdCategoria
           ,IdCategoriaFiscal
           ,Cuit
           ,TipoDocVendedor
           ,NroDocVendedor
           ,Observacion
           ,IdListaPrecios
           ,IdZonaGeografica
           ,Activo)
SELECT GETDATE() AS FechaAuditoria
      ,'A' AS OperacionAuditoria
      ,'Admin' AS UsuarioAuditoria
      ,TipoDocumento
      ,NroDocumento
      ,NombreCliente
      ,Direccion
      ,IdLocalidad
      ,Telefono
      ,FechaNacimiento
      ,NroOperacion
      ,CorreoElectronico
      ,Celular
      ,NombreTrabajo
      ,DireccionTrabajo
      ,IdLocalidadTrabajo
      ,TelefonoTrabajo
      ,CorreoTrabajo
      ,FechaIngresoTrabajo
      ,FechaAlta
      ,SaldoPendiente
      ,TipoDocumentoGarante
      ,NroDocumentoGarante
      ,IdCategoria
      ,IdCategoriaFiscal
      ,Cuit
      ,TipoDocVendedor
      ,NroDocVendedor
      ,Observacion
      ,IdListaPrecios
      ,IdZonaGeografica
      ,Activo
 FROM Clientes
GO

UPDATE AuditoriaClientes
 SET OperacionAuditoria='I'
  WHERE EXISTS (
   SELECT * FROM Clientes C
     WHERE C.Activo='False'
       AND C.TipoDocumento = AuditoriaClientes.TipoDocumento
       and C.NroDocumento = AuditoriaClientes.NroDocumento
               )
GO

            