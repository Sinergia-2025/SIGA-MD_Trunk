
INSERT INTO AuditoriaProductos
           (FechaAuditoria
           ,OperacionAuditoria
           ,UsuarioAuditoria
           ,IdProducto
           ,NombreProducto
           ,Tamano
           ,IdUnidadDeMedida
           ,IdMarca
           ,IdRubro
           ,MesesGarantia
           ,Activo
           ,AfectaStock
           ,IdModelo
           ,IdSubRubro
           ,Foto
           ,Lote
           ,NroSerie
           ,IdTipoImpuesto
           ,Alicuota
           ,CodigoDeBarras
           ,EsServicio
           ,Observacion
           ,PublicarEnWeb
           ,EsDeCompras
           ,EsDeVentas
           ,DescontarStockComponentes
           ,IdMoneda
           ,EsCompuesto
           ,CodigoDeBarrasConPrecio
           ,EsAlquilable
           ,EquipoMarca
           ,EquipoModelo
           ,NumeroSerie
           ,CaractSII
           ,Anio
           ,PermiteModificarDescripcion
           ,Alicuota2
           ,PagaIngresosBrutos
           ,Embalaje
           ,Kilos
           ,IdFormula
           ,IdProductoMercosur
           ,IdProductoSecretaria
           ,PublicarListaDePreciosClientes
           ,FacturacionCantidadNegativa
           ,SolicitaEnvase
           ,AlertaDeCaja
           ,NombreCorto)
SELECT GETDATE() AS FechaAuditoria
      ,'A' AS OperacionAuditoria
      ,'Admin' AS UsuarioAuditoria
      ,IdProducto
      ,NombreProducto
      ,Tamano
      ,IdUnidadDeMedida
      ,IdMarca
      ,IdRubro
      ,MesesGarantia
      ,Activo
      ,AfectaStock
      ,IdModelo
      ,IdSubRubro
      ,Foto
      ,Lote
      ,NroSerie
      ,IdTipoImpuesto
      ,Alicuota
      ,CodigoDeBarras
      ,EsServicio
      ,Observacion
      ,PublicarEnWeb
      ,EsDeCompras
      ,EsDeVentas
      ,DescontarStockComponentes
      ,IdMoneda
      ,EsCompuesto
      ,CodigoDeBarrasConPrecio
      ,EsAlquilable
      ,EquipoMarca
      ,EquipoModelo
      ,NumeroSerie
      ,CaractSII
      ,Anio
      ,PermiteModificarDescripcion
      ,Alicuota2
      ,PagaIngresosBrutos
      ,Embalaje
      ,Kilos
      ,IdFormula
      ,IdProductoMercosur
      ,IdProductoSecretaria
      ,PublicarListaDePreciosClientes
      ,FacturacionCantidadNegativa
      ,SolicitaEnvase
      ,AlertaDeCaja
      ,NombreCorto
 FROM Productos
GO

UPDATE AuditoriaProductos
 SET OperacionAuditoria = 'I'
  WHERE EXISTS (
   SELECT * FROM Productos C
     WHERE C.Activo = 'False'
       AND C.IdProducto = AuditoriaProductos.IdProducto
               )
GO
