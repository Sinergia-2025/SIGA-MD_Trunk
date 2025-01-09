INSERT INTO [dbo].[ClientesParametros]
           ([IdCliente]
           ,[NombreServidor]
           ,[BaseDatos]
           ,[IdParametro]
           ,[ValorParametro])
SELECT IdCliente, '' NombreServidor, 'SIGA' BaseDatos, IdParametro, ValorParametro
  FROM Clientes
 CROSS JOIN Parametros

INSERT INTO [dbo].[ClientesDispositivos]
           ([IdCliente]
           ,[NombreServidor]
           ,[BaseDatos]
           ,[IdDispositivo]
           ,[NombreDispositivo]
           ,[FechaUltimoLogin]
           ,[UsuarioUltimoLogin]
           ,[IdTipoDispositivo]
           ,[SistemaOperativo]
           ,[ArquitecturaSO]
           ,[NumeroSerieDiscoRigido])
SELECT [IdCliente], '' [NombreServidor], 'SIGA' [BaseDatos]
     , [IdDispositivo], [NombreDispositivo], [FechaUltimoLogin], [UsuarioUltimoLogin]
     , [IdTipoDispositivo], [SistemaOperativo], [ArquitecturaSO], [NumeroSerieDiscoRigido]
  FROM Clientes
 CROSS JOIN Dispositivos
