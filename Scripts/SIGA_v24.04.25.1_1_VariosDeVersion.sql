PRINT ''
PRINT '1. Parametros para Talkiu - RDS'

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('30714757128'))
BEGIN
INSERT [dbo].[Parametros] ([IdParametro], [ValorParametro], [CategoriaParametro], [DescripcionParametro], [IdEmpresa], [UbicacionParametro]) VALUES (N'PEDIDOTALKIUGET', N'https://staging-talkiu.web-experto.com.ar/api/v3/proposals/R{0}', N'', N'URL GET', 1, N'Parametros => Pedidos -> Web : ucConfPedidosWeb')
INSERT [dbo].[Parametros] ([IdParametro], [ValorParametro], [CategoriaParametro], [DescripcionParametro], [IdEmpresa], [UbicacionParametro]) VALUES (N'PEDIDOTALKIUTOKEN', N'eyJhbGciOiJIUzI1NiJ9.eyJ1c2VyX2lkIjoiNjVkNjBhYTY1ZWVkMGUwMDAxYTczZDNiIiwiZXhwIjo4MDIwNTYyNzQ4fQ.pMywEXRU-U1zyPoBJVMdQRFZpxAdNa8YvpsyA5u6EuQ', N'', N'TOKEN', 1, N'Parametros => Pedidos -> Web : ucConfPedidosWeb')
END
GO
