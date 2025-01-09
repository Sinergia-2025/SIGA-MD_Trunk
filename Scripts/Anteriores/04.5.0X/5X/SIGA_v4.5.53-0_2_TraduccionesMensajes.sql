DECLARE @idAplicacion varchar(MAX)
SET @idAplicacion = (SELECT ValorParametro FROM Parametros WHERE IdParametro = 'IDAPLICACION')

DELETE FROM Traducciones WHERE Control IN 
    ('__NoSeleccionoPedido', '__AnulacionPedidoExitosa', '__FaltaNumeroPedido', '__CambioEstadoMasivo',
     '__ErrorCambioMasivoNoPermitido', '__ErrorEstadoNoPermiteCambio', '__ErrorDebeCambiarEstado',
     '__ConfirmarCambioEstado', '__NoSeleccionoPedidoModificar', '__ErrorFechaEntregaPedidoInvalida',
     '__ErrorFechaEntregaInvalida', '__PedidoNoSuministrado')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES ('AnularPresupuestos','','__NoSeleccionoPedido','es_AR',
            'ATENCION: NO Seleccionó Ningún Presupuesto para Anular!!')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES ('AnularPresupuestos','','__AnulacionPedidoExitosa','es_AR',
            '¡¡¡ Presupuesto/s Anulado/s Exitosamente !!!')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES (@idAplicacion,'','__FaltaNumeroPedido','es_AR',
            'ATENCION: NO Ingresó un Número de Presupuesto aunque activó ese Filtro.')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES ('PresupuestosAdmin','','__CambioEstadoMasivo','es_AR',
            '¿Desea cambiar masivamente el Estado actual de los Presupuestos Seleccionados al Estado: {0}?')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES ('PresupuestosAdmin','','__ErrorCambioMasivoNoPermitido','es_AR',
            'Presupuesto: {0}-->El Estado a cambiar debe ser distinto al Estado Actual del Presupuesto o cambiar Criticidad/Fecha de Entrega.')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES ('PresupuestosAdmin','','__ErrorEstadoNoPermiteCambio','es_AR',
            'Presupuesto: {0} --> El Estado Actual NO permite cambio.')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES ('PresupuestosAdmin','','__NoSeleccionoPedido','es_AR',
            'Debe seleccionar un Presupuesto para cambiar el Estado.')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES ('PresupuestosAdmin','','__ErrorDebeCambiarEstado','es_AR',
            'El Estado a cambiar debe ser distinto al Estado Actual del Presupuesto.')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES ('PresupuestosAdmin','','__ConfirmarCambioEstado','es_AR',
            '¿Desea cambiar el Estado actual del Presupuesto - {0} - al Estado: {1}?')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES ('PresupuestosAdmin','','__NoSeleccionoPedidoModificar','es_AR',
            'Por favor seleccione un Presupuesto.')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES (@idAplicacion,'PedidosClientesV2','__ConfirmarNuevoComprobante','es_AR',
            'ATENCION: ¿Desea Realizar un Presupuesto Nuevo?')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES (@idAplicacion,'PedidosClientesV2','__PedidoNoSuministrado','es_AR',
            'Debe pasar un Presupuesto a modificar.')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES (@idAplicacion,'PedidosClientesV2','__ErrorFechaEntregaInvalida','es_AR',
            'La Fecha de Entrega del producto (Código {0}) es menor a la Fecha del Presupuesto ({1:dd/MM/yyyy}).')
;
INSERT INTO Traducciones (IdFuncion,Pantalla,Control,IdIdioma,Texto)
    VALUES (@idAplicacion,'PedidosClientesV2','__ErrorFechaEntregaPedidoInvalida','es_AR',
            'La Fecha de Entrega es menor a la Fecha del Presupuesto ({0:dd/MM/yyyy}.')
;
