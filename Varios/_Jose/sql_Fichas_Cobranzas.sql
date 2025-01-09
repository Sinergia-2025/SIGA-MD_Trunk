SELECT idsucursal, 
       idtipocomprobante2, 
       letra2, 
       centroemisor2, 
       numerocomprobante2, 
       semana, 
       Año, 
       codigocliente, 
       nombrecliente, 
	   NombreVendedor,
	   Sum(ImporteCuota) AS ImporteCobrado,
	   fecha, 
       cuota
FROM   (SELECT                  CCP.idsucursal, 
                                 CONVERT(VARCHAR(11),  CCP.fecha, 120) AS Fecha, 
                                 CCP.idtipocomprobante2, 
                                 CCP.letra2, 
                                 CCP.centroemisor2, 
                                 CCP.numerocomprobante2, 
                                 Datepart(week,  CCP.fecha) AS semana, 
                                 Datename(yyyy,  CCP.fecha) AS Año, 
                                 CCP.importecuota * -1 AS ImporteCuota, 
                                 --CCP.importecuota * - ( 1 * V.subtotal / V.importetotal ) AS ImporteNeto, 
                                 C.codigocliente, 
                                 C.nombrecliente, 
                                 CCP.cuotanumero2 AS Cuota, 
                                 E1.nombreempleado AS NombreVendedor 
        FROM   cuentascorrientespagos AS CCP 
               --LEFT OUTER JOIN ventas AS V 
               --             ON CCP.idsucursal = V.idsucursal 
               --                AND CCP.idtipocomprobante2 = V.idtipocomprobante 
               --                AND CCP.letra2 = V.letra 
               --                AND CCP.centroemisor2 = V.centroemisor 
               --                AND CCP.numerocomprobante2 = V.numerocomprobante 
               INNER JOIN cuentascorrientes AS CC 
                       ON CCP.idsucursal = CC.idsucursal 
                          AND CCP.idtipocomprobante = CC.idtipocomprobante 
                          AND CCP.letra = CC.letra 
                          AND CCP.centroemisor = CC.centroemisor 
                          AND CCP.numerocomprobante = CC.numerocomprobante 
               INNER JOIN empleados AS E1 
                       ON CC.tipodocvendedor = E1.tipodocempleado AND CC.nrodocvendedor = E1.nrodocempleado 
               INNER JOIN clientes AS C 
                       ON CC.idcliente = C.idcliente 
               --INNER JOIN empleados AS E2 
               --        ON C.tipodocvendedor = E2.tipodocempleado AND C.nrodocvendedor = E2.nrodocempleado 
               --INNER JOIN categoriasfiscales AS CF 
               --        ON C.idcategoriafiscal = CF.idcategoriafiscal 
               INNER JOIN tiposcomprobantes AS TC 
                       ON CCP.idtipocomprobante = TC.idtipocomprobante 
               INNER JOIN tiposcomprobantes AS TC2 
                       ON CCP.idtipocomprobante2 = TC2.idtipocomprobante 
               --INNER JOIN ventasformaspago AS VFP 
               --        ON CCP.idformaspago = VFP.idformaspago 
        WHERE  ( TC.esrecibo = 'True' ) 
               AND ( CCP.idsucursal IN ( 1, 1 ) ) 
               --AND ( CCP.idtipocomprobante = 'RECIBOPROV' ) 
               --AND ( CCP.letra = 'X' ) 
               --AND ( CCP.centroemisor = 1 ) 
               AND ( CONVERT(VARCHAR(11),  CCP.fecha, 120) >= '2018-08-01' ) 
               AND ( CONVERT(VARCHAR(11), CCP.fecha, 120) <= '2018-11-06' ) 
               OR ( CCP.idsucursal IN ( 1, 1 ) ) 
               AND ( TC.esanticipo = 'True' )
				   ) AS tbl 
GROUP  BY idsucursal, 
          idtipocomprobante2, 
          letra2, 
          centroemisor2, 
          numerocomprobante2, 
          semana, 
          año, 
          codigocliente, 
          nombrecliente, 
          cuota, 
          nombrevendedor,
		  Fecha
