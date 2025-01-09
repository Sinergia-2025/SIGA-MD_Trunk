select codigocliente, nombrecliente , SiMovilIdUsuario, SiMovilClave
     , CUIT, NroDocCliente
	 ,CASE WHEN ISNULL(Cuit,'') <> '' THEN Cuit ELSE
                          CASE WHEN ISNULL(NroDocCliente, 0) <> 0 THEN CONVERT(VARCHAR(MAX), NroDocCliente) ELSE
                          CONVERT(VARCHAR(MAX), CodigoCliente) END END as USUARIONUEVO

 FROM clientes
GO


UPDATE Clientes 
   SET SiMovilIdUsuario = CASE WHEN ISNULL(Cuit,'') <> '' THEN Cuit ELSE
                          CASE WHEN ISNULL(NroDocCliente, 0) <> 0 THEN CONVERT(VARCHAR(MAX), NroDocCliente) ELSE
                          CONVERT(VARCHAR(MAX), CodigoCliente) END END
     , SiMovilClave = CodigoCliente;
GO
