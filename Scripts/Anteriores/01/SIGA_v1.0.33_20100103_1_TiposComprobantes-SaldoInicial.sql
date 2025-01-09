INSERT INTO dbo.TiposComprobantes
           ([IdTipoComprobante]
           ,[EsFiscal]
           ,[Descripcion]
           ,[Tipo]
           ,[CoeficienteStock]
           ,[GrabaLibro]
           ,[EsFacturable]
           ,[LetrasHabilitadas]
           ,[CantidadMaximaItems]
           ,[Imprime]
           ,[CoeficienteValores]
           ,[ModificaAlFacturar]
           ,[EsFacturador]
           ,[AfectaCaja]
           ,[CargaPrecioActual]
           ,[ActualizaCtaCte]
           ,[DescripcionAbrev]
           ,[PuedeSerBorrado]
           ,[CantidadCopias])
     VALUES
           ('SALDOINICIAL'
           ,'False'
           ,'Saldo Inicial'
           ,'CTACTE'
           ,0
           ,'False'
           ,'False'
           ,'X'
           ,999
           ,'False'
           ,1
           ,NULL
           ,'False'
           ,'False'
           ,'False'
           ,'False'
           ,'Saldo Inic'
           ,'False'
           ,1)
GO


