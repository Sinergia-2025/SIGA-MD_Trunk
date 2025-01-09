Partial Class Publicos

   Public Sub PreparaGrillaActividades(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Actividades"
         .ColumnasOcultas = New String() {"IdProvincia"}
         .ColumnasTitulos = New String() {"", "Provincia", "Codigo", "Actividad", "Porcentaje"}
         .ColumnasFormato = New String() {"", "", "", "", ""}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft}
         .ColumnasAncho = New Integer() {0, 100, 80, 250, 80}
         .AyudaAncho = 600
      End With
   End Sub

   Public Sub PreparaGrillaBancos(buscador As Controles.Buscador)
      With buscador
         .ColumnasTitulos = New String() {"Banco", "Nombre Banco"}
         .ColumnasOcultas = New String() {}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
         .ColumnasAncho = New Integer() {70, 300}
         .AyudaAncho = 400
         .Titulo = "Bancos"
      End With
   End Sub

   Public Sub PreparaGrillaCajasUsuarios(buscador As Controles.Buscador, muestraSucursal As Boolean)
      With buscador
         .Titulo = "Cajas"
         If muestraSucursal Then
            .ColumnasOcultas = New String() {"", "", "", "", "IdPlanCuenta", "TopeAviso", "TopeBloqueo", "IdCuentaContable"}
            .ColumnasTitulos = New String() {"Suc.", "Caja", "Nombre Caja", "Nombre PC", "", "", "", "IdUsuario"}
            .ColumnasAncho = New Integer() {50, 80, 150, 150, 0, 0, 0, 80}
         Else
            .ColumnasOcultas = New String() {"IdSucursal", "", "", "", "IdPlanCuenta", "TopeAviso", "TopeBloqueo", "IdCuentaContable"}
            .ColumnasTitulos = New String() {"", "Caja", "Nombre Caja", "Nombre PC", "", "", "", "IdUsuario"}
            .ColumnasAncho = New Integer() {0, 80, 150, 150, 0, 0, 0, 80}
         End If
         '.ColumnasFormato = New String() {"", ""}
         '.ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
         .AyudaAncho = 500
      End With
   End Sub

   Public Sub PreparaGrillaCalles(buscador As Controles.Buscador)
      With buscador
         .ColumnasTitulos = New String() {"IdCalle", "Nombre Calle"}
         .ColumnasOcultas = New String() {}
         .ColumnasAncho = New Integer() {80, 300}
         .Titulo = "Calles"
         .AyudaAncho = 600
      End With
   End Sub

   Public Sub PreparaGrillaChoferes(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Choferes"
         .ColumnasTitulos = New String() {"Codigo", "Nombre Chofer", "Direccion", "Telefono"}
         .ColumnasAncho = New Integer() {80, 200, 150, 100}
         .AyudaAncho = 600
      End With
   End Sub

   Public Sub PreparaGrillaClientes(buscador As Controles.Buscador)
      With buscador
         'CAMPOS: IdCliente, CodigoCliente, NombreCliente, NombreDeFantasia, Direccion, IdLocalidad, NombreLocalidad, NombreProvincia, IdCategoriaFiscal, NombreCategoriaFiscal, LetraFiscal, CUIT, TipoDocCliente, NroDocCliente, Telefono, Celular, IdZonaGeografica, NombreZonaGeografica, FechaNacimiento, NroOperacion, CorreoElectronico, NombreTrabajo, DireccionTrabajo, TelefonoTrabajo, CorreoTrabajo, IdLocalidadTrabajo, NombreLocalidadTrabajo, FechaIngresoTrabajo, FechaAlta, SaldoPendiente, TipoDocumentoGarante, NroDocumentoGarante, NombreGarante, IdCategoria, NombreCategoria, Observacion, IdListaPrecios, NombreListaPrecios, TipoDocVendedor, NroDocVendedor, NombreVendedor, LimiteDeCredito , IdSucursalAsociada, NombreSucursalAsociada, DescuentoRecargoPorc, Activo, IdTipoComprobante, IdFormasPago, DescripcionFormasPago
         '              X               X            X               X              X           x            X             X    X                        X               X            X        X           X                      X                X                X              X                X                 X                X                 X              X                     X                   X                X             X                  X                     X               X                 x            X             X             X               X                   X                X              X                 X                 X                  X                           X                   X           X                  X            X
         .ColumnasTitulos = New String() {"", "Codigo", "Nombre", "Nombre de Fantasia", "Dirección", "", "Localidad", "Provincia", "", "Categoria Fiscal", "", "CUIT", "T.Doc", "Nro.Documento"}
         .ColumnasOcultas = New String() {"IdCliente", "IdLocalidad", "IdCategoriaFiscal", "LetraFiscal", "IdZonaGeografica", "FechaNacimiento", "NroOperacion", "CorreoElectronico", "NombreTrabajo", "DireccionTrabajo", "TelefonoTrabajo", "CorreoTrabajo", "IdLocalidadTrabajo", "NombreLocalidadTrabajo", "FechaIngresoTrabajo", "FechaAlta", "SaldoPendiente", "IdClienteGarante", "CodigoGarante", "NombreGarante", "IdCategoria", "NombreCategoria", "Observacion", "IdListaPrecios", "NombreListaPrecios", "TipoDocVendedor", "NroDocVendedor", "NombreVendedor", "LimiteDeCredito", "IdSucursalAsociada", "NombreSucursalAsociada", "Activo", "IdTipoComprobante", "IdFormasPago", "DescripcionFormasPago"}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft}
         .ColumnasAncho = New Integer() {0, 50, 200, 150, 150, 0, 100, 80, 0, 100, 0, 80, 40, 80}
         .AyudaAncho = 900
         .Titulo = "Clientes"
      End With
   End Sub

   Public Sub PreparaGrillaConceptos(buscador As Controles.Buscador)

      With buscador
         .Titulo = "Conceptos"
         .ColumnasOcultas = New String() {"IdRubroConcepto"}
         .ColumnasTitulos = New String() {"Concepto", "Descripción", "", "Rubro"}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft}
         .ColumnasAncho = New Integer() {70, 250, 0, 300}
      End With

   End Sub

   Public Sub PreparaGrillaContactos(buscador As Controles.Buscador)
      With buscador
         'CAMPOS: C.IdCliente  ,C.IdTipoContacto ,TC.NombreTipoContacto,C.IdContacto,C.NombreContacto,C.Telefono  
         ' ,C.Celular,C.Observacion ,C.CorreoElectronico ,C.Direccion,C.IdLocalidad,L.NombreLocalidad 
         ',P.NombreProvincia ,C.Activo ,C.IdUsuario,EnUso
         .ColumnasTitulos = New String() {"", "", "Tipo Contacto", "", "Nombre", "Telefono", "Celular", "Observacion", "CorreoElectronico", "Dirección", "", "Localidad", "Provincia", "", "Usuario"}
         .ColumnasOcultas = New String() {"IdCliente", "IdTipoContacto", "IdContacto", "IdLocalidad", "Activo", "EnUso"}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft}
         .ColumnasAncho = New Integer() {0, 0, 100, 0, 150, 100, 100, 100, 200, 150, 100, 100, 80, 80, 80}
         .AyudaAncho = 900
         .Titulo = "Contactos"
      End With
   End Sub

   Public Sub PreparaGrillaCuentasBancarias(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Cuentas Bancarias"
         .ColumnasOcultas = New String() {"IdCuentaBancaria", "Saldo", "SaldoConfirmado"}
         '.ColumnasTitulos = New String() {"", "Nombre", "Código", "Clase", "Moneda", "Chequera", "Nro.Bco.", "Nombre Banco", "Suc.Bco.", "C.P.", "Nombre Localidad"}
         '.ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
         '.ColumnasAncho = New Integer() {0, 200, 150, 100, 70, 70, 70, 110, 60, 50, 110}
         .ColumnasTitulos = New String() {"", "Nombre", "Código", "Clase", "Moneda", "Nombre Banco", "Chequera", "Nro.Bco.", "Suc.Bco.", "C.P.", "Nombre Localidad"}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
         .ColumnasAncho = New Integer() {0, 180, 130, 100, 70, 130, 70, 110, 60, 50, 110}
         .AyudaAncho = 600
      End With
   End Sub

   <Obsolete("", True)>
   Public Sub PreparaGrillaCuentasDeBancos(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Cuentas de Bancos"
         .ColumnasTitulos = New String() {"Código", "Nombre", "Tipo", "Posdatado", "Pide Cheque"}
         '.ColumnasOcultas = New String() {"IdGrupoCuenta"}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter}
         .ColumnasAncho = New Integer() {70, 273, 70, 80, 80}
         .AyudaAncho = 600
      End With
   End Sub

   <Obsolete("", True)>
   Public Sub PreparaGrillaCuentasBancos(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Cuentas de Banco"
         .ColumnasOcultas = New String() {"EsPosdatado", "PideCheque", "IdCuentaContable", "IdGrupoCuenta", "IdCentroCosto", "NombreCuentaContable"}
         .ColumnasTitulos = New String() {"Código", "Cuenta", "Tipo"}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight}
         .ColumnasAncho = New Integer() {50, 180, 130}
         .AyudaAncho = 600
      End With
   End Sub

   Public Sub PreparaGrillaCuentasDeCajas(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Cuentas de Cajas"
         .ColumnasTitulos = New String() {"Código", "Nombre", "Tipo", "Posdatado", "Requiere Cheque"}
         .ColumnasOcultas = New String() {"IdGrupoCuenta"}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter}
         .ColumnasAncho = New Integer() {50, 250, 35, 70, 100}
         .AyudaAncho = 600
      End With
   End Sub

   Public Sub PreparaGrillaEstadosCheques(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Estados"
         '    .ColumnasOcultas = New String() {"ComisionPorVenta"}
         .ColumnasTitulos = New String() {"Estado", "Descripción"}
         .ColumnasFormato = New String() {"", ""}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight}
         .ColumnasAncho = New Integer() {100, 100}
         .AyudaAncho = 600
      End With
   End Sub

   Public Sub PreparaGrillaFormasDePago(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Formas de Pago"
         .ColumnasTitulos = New String() {"IdFormasPago", "DescripcionFormasPago"}
         .ColumnasOcultas = New String() {"Dias", "EsTarjeta", "OrdenVentas", "OrdenCompras",
                                          "OrdenFichas", "CantidadCuotas", "DiasPrimerCuota",
                                          "FechaBaseProximaCuota", "ExcluyeSabados", "ExcluyeDomingos",
                                          "ExcluyeFeriados", "Porcentaje", "RequierePesos", "RequiereDolares",
                                          "RequiereTickets", "RequiereTransferencia", "RequiereCheques", "RequiereTarjetaDebito",
                                          "RequiereTarjetaCredito", "RequiereTarjetaCredito1Pago"}
         .ColumnasAncho = New Integer() {50, 250}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
         .AyudaAncho = 320
      End With
   End Sub

   Public Sub PreparaGrillaListaPrecios(buscador As Controles.Buscador)
      With buscador
         .Titulo = "ListasDePrecios"
         .ColumnasOcultas = New String() {"FechaVigencia"}
         .ColumnasTitulos = New String() {"IdListaPrecios", "NombreListaPrecios"}
         .ColumnasFormato = New String() {"", ""}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
         .ColumnasAncho = New Integer() {70, 350}
         .AyudaAncho = 600
      End With
   End Sub

   Public Sub PreparaGrillaLocalidades(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Localidades"
         .ColumnasTitulos = New String() {"C.P.", "Nombre", "", "Provincia"}
         .ColumnasOcultas = New String() {"IdProvincia"}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft}
         .ColumnasAncho = New Integer() {50, 200, 0, 200}
         .AyudaAncho = 600
      End With
   End Sub

   Public Sub PreparaGrillaLotes(buscador As Controles.Buscador)
      With buscador
         'CAMPOS: IdLote, IdSucursal, IdProducto, NombreProducto, FechaIngreso, FechaVencimiento, CantidadInicial, CantidadActual,Habilitado
         '  X         X          X          X
         .ColumnasTitulos = New String() {"Lote", "", "Producto", "Nombre Producto", "", "Vencimiento", "Cant. Inicial", "Cant. Actual", "", "Precio Costo"}
         .ColumnasOcultas = New String() {"IdSucursal", "Habilitado", "FechaIngreso"}
         .ColumnasFormato = New String() {"", "", "", "", "dd/MM/yyyy", "dd/MM/yyyy", "##,##0.00", "##,##0.00", "", "##,##0.00"}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight}
         .ColumnasAncho = New Integer() {140, 0, 100, 180, 0, 70, 70, 70, 0, 70}
         .AyudaAncho = 650
         .Titulo = "Lotes"
      End With
   End Sub

   Public Sub PreparaGrillaLotesDespacho(buscador As Controles.Buscador)
      With buscador
         'CAMPOS: IdLote, IdSucursal, IdProducto, NombreProducto, FechaIngreso, FechaVencimiento, CantidadInicial, CantidadActual,Habilitado
         '  X         X          X          X
         .ColumnasTitulos = New String() {"Oficialización", "Despacho", "Aduana"}
         .ColumnasOcultas = New String() {}
         .ColumnasFormato = New String() {"dd/MM/yyyy", "", ""}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.BottomLeft, DataGridViewContentAlignment.BottomLeft}
         .ColumnasAncho = New Integer() {70, 180, 180}
         .AyudaAncho = 500
         .Titulo = "Despachos"
      End With
   End Sub

   Public Sub PreparaGrillaMarcas(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Marcas"
         .ColumnasOcultas = New String() {"ComisionPorVenta"}
         .ColumnasTitulos = New String() {"Marca", "Descripción"}
         .ColumnasFormato = New String() {"", ""}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
         .ColumnasAncho = New Integer() {70, 350}
         .AyudaAncho = 600
      End With
   End Sub

   Public Sub PreparaGrillaEmpleados(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Empleados"
         .ColumnasOcultas = New String() {}
         .ColumnasTitulos = New String() {"Codigo", "Nombre Empleado"}
         .ColumnasFormato = New String() {"", ""}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
         .ColumnasAncho = New Integer() {70, 350}
         .AyudaAncho = 600
      End With
   End Sub

   Public Sub PreparaGrillaModelos(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Modelos"
         .ColumnasOcultas = New String() {""}
         .ColumnasTitulos = New String() {"Modelo", "Descripción", "Marca", "Nombre Marca"}
         .ColumnasFormato = New String() {"", "", "", ""}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
         .ColumnasAncho = New Integer() {70, 220, 70, 270}
         .AyudaAncho = 600
      End With
   End Sub

   Public Sub PreparaGrillaMovilRutas(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Rutas"
         .ColumnasOcultas = New String() {Entidades.MovilRuta.Columnas.Activa.ToString(),
                                          Entidades.MovilRuta.Columnas.IdDispositivoPorDefecto.ToString(),
                                          Entidades.MovilRuta.Columnas.IdVendedor.ToString(),
                                          Entidades.MovilRuta.Columnas.IdTransportista.ToString(),
                                          "NombreVendedor", "NombreTransportista"}
         .ColumnasTitulos = New String() {"Código", "Ruta", "", "", "", "", "", "", ""}
         .ColumnasFormato = New String() {"", "", "", "", "", "", "", "", ""}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
         .ColumnasAncho = New Integer() {80, 250, 0, 0, 0, 0, 0, 0, 0}
         .AyudaAncho = 350
      End With
   End Sub

   Public Sub PreparaGrillaObservaciones(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Observaciones"
         .ColumnasTitulos = New String() {"", "Observacion", ""}
         .ColumnasOcultas = New String() {"IdObservacion", "Tipo"}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft}
         .ColumnasAncho = New Integer() {0, 620, 0}
         .AyudaAncho = 650
      End With
   End Sub

   Public Sub PreparaGrillaProveedores(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Proveedores"
         .ColumnasTitulos = New String() {"", "Codigo", "Codigo Letras", "Nombre", "Dirección", "", "Localidad", "", "", "Categ.Fiscal", "", "Categoria"}
         .ColumnasOcultas = New String() {"IdProveedor", "IdLocalidadProveedor", "IdCategoriaFiscal", "LetraFiscal", "IdCategoria", "IdRubroCompra"}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight}
         .ColumnasAncho = New Integer() {0, 50, 70, 150, 0, 100, 0, 0, 120, 0, 120}
         .AyudaAncho = 800
      End With
   End Sub

   Public Sub PreparaGrillaRubros(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Rubros"
         .ColumnasOcultas = New String() {}
         .ColumnasTitulos = New String() {"Rubro", "Descripción"}
         .ColumnasFormato = New String() {"", ""}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
         .ColumnasAncho = New Integer() {70, 350}
         .AyudaAncho = 600
      End With
   End Sub

   Public Sub PreparaGrillaRubrosConceptos(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Rubros Conceptos"
         .ColumnasOcultas = New String() {}
         .ColumnasTitulos = New String() {"Rubro", "Descripción"}
         .ColumnasFormato = New String() {"", ""}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
         .ColumnasAncho = New Integer() {70, 350}
      End With
   End Sub

   Public Sub PreparaGrillaSubRubros(buscador As Controles.Buscador)
      With buscador
         .Titulo = "SubRubros"
         .ColumnasOcultas = New String() {"IdRubro"}
         .ColumnasTitulos = New String() {"", "Rubro", "Codigo", "SubRubro", "Desc./Recargo"}
         .ColumnasFormato = New String() {"", "", "", "", "##0.00"}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight}
         .ColumnasAncho = New Integer() {0, 250, 50, 250, 90}
         .AyudaAncho = 700
      End With
   End Sub

   Public Sub PreparaGrillaSubRubrosSS(buscador As Controles.Buscador)
      With buscador
         .Titulo = "SubRubros"
         .ColumnasOcultas = New String() {"IdRubro", "", "", "", "Desc./Recargo"}
         .ColumnasTitulos = New String() {"", "Rubro", "Codigo", "SubRubro", ""}
         .ColumnasFormato = New String() {"", "", "", "", "##0.00"}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight}
         .ColumnasAncho = New Integer() {0, 200, 80, 350, 0}
         .AyudaAncho = 700
      End With
   End Sub

   Public Sub PreparaGrillaSubSubRubros(buscador As Controles.Buscador)
      With buscador
         .Titulo = "SubSubRubros"
         .ColumnasOcultas = New String() {"IdRubro", "", "IdSubRubro", "", "", ""}
         .ColumnasTitulos = New String() {"", "Rubro", "", "SubRubro", "Codigo", "SubSubRubro"}
         .ColumnasFormato = New String() {"", "", "", "", "", ""}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
         .ColumnasAncho = New Integer() {0, 200, 0, 200, 80, 350}
         .AyudaAncho = 900
      End With
   End Sub

   Public Sub PreparaGrillaSucursales(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Sucursales"
         .ColumnasTitulos = New String() {"IdSucursal", "Nombre"}
         .ColumnasOcultas = New String() {"Direccion", "IdLocalidad", "Telefono", "Correo",
                                          "FechaInicioActiv", "EstoyAca", "SoyLaCentral",
                                          "Id", "IdSucursalAsociada", "ColorSucursal",
                                          "LogoSucursal", "DireccionComercial", "IdLocalidadComercial",
                                          "NombreLocalidad", "NombreSucursalAsociada",
                                          "NombreLocalidadComercial"}
         .ColumnasAncho = New Integer() {50, 250}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
         .AyudaAncho = 320
      End With
   End Sub

   Public Sub PreparaGrillaSueldosTiposConceptos(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Tipos de Conceptos"
         .ColumnasOcultas = New String() {"idTipoConcepto"}
         .ColumnasTitulos = New String() {"Codigo", "Nombre"}
         .ColumnasFormato = New String() {"", ""}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
         .ColumnasAncho = New Integer() {70, 350}
         .AyudaAncho = 600
      End With
   End Sub

   Public Sub PreparaGrillaTiposCliente(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Tipos de Cliente"
         .ColumnasTitulos = New String() {"Código", "Tipo de Cliente"}
         .ColumnasOcultas = New String() {}
         .ColumnasAncho = New Integer() {150, 350}   ' son 3 columnas visibles
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() _
                                    {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
      End With
   End Sub

   Public Sub PreparaGrillaTiposComprobantes(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Tipos de Comprobantes"
         .ColumnasTitulos = New String() {"Tipo Comp.", "Descripcion"}
         .ColumnasOcultas = New String() {"EsFiscal", "Tipo", "CoeficienteStock", "GrabaLibro",
                                          "LetrasHabilitadas", "EsFacturable", "CantidadMaximaItems",
                                          "Imprime", "CoeficienteValores", "ModificaAlFacturar",
                                          "EsFacturador", "AfectaCaja", "CargaPrecioActual", "ActualizaCtaCte",
                                          "DescripcionAbrev", "PuedeSerBorrado", "CantidadCopias",
                                          "ComprobantesAsociados", "EsComercial", "EsRemitoTransportista",
                                          "CantidadMaximaItemsObserv", "IdTipoComprobanteSecundario",
                                          "ImporteTope", "IdTipoComprobanteEpson", "UsaFacturacionRapida",
                                          "ImporteMinimo", "EsElectronico"}   ', "DatosEnvioObligatorio"}
         .ColumnasAncho = New Integer() {150, 0, 350}
      End With
   End Sub

   Public Sub PreparaGrillaTransportistas(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Transportistas"
         .ColumnasOcultas = New String() {"IdTransportista", "idLocalidadTransportista", "IdCategoriaFiscalTransportista", "CuitTransportista"}
         .ColumnasTitulos = New String() {"Codigo", "Nombre", "Dirección", "", "Localidad", "CUIT", "Teléfono", "Observacion", "Categ.Fiscal"}
         .ColumnasAncho = New Integer() {60, 200, 150, 100, 100, 100, 120, 120, 200}
         .AyudaAncho = 600
      End With
   End Sub

   Public Sub PreparaGrillaZonasGeograficas(buscador As Controles.Buscador)
      With buscador
         .Titulo = "Zonas Geográficas"
         .ColumnasTitulos = New String() {"Código", "Zona"}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() _
                                    {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
         .ColumnasAncho = New Integer() {50, 300}
      End With
   End Sub




#Region "Metodos que ya no se usan"

   'Public Sub PreparaGrillaObservacionesCargosClientes(buscador As Controles.Buscador)
   '   With buscador
   '      .Titulo = "Observaciones"
   '      .ColumnasTitulos = New String() {"", "", "Cargo", "Nro. Observación", "Observación"}
   '      .ColumnasOcultas = New String() {"IdSucursal", "IdCliente"}
   '      .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleLeft}
   '      .ColumnasAncho = New Integer() {0, 0, 80, 20, 620, 0}
   '      .AyudaAncho = 650
   '   End With
   'End Sub
   'Public Sub PreparaGrillaCuentasContable(buscador As Controles.Buscador)
   '   With buscador
   '      .Titulo = "Cuentas Contables"
   '      .ColumnasTitulos = New String() {"Código", "Cuenta"}
   '      .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() _
   '                                 {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
   '      .ColumnasAncho = New Integer() {100, 300}
   '   End With
   'End Sub
   'Public Sub PreparaGrillaCajasNombre(buscador As Controles.Buscador)
   '   With buscador
   '      .Titulo = "Cajas"
   '      .ColumnasOcultas = New String() {"IdSucursal", "Nombre"}
   '      .ColumnasTitulos = New String() {"Caja", "Descripción"}
   '      .ColumnasFormato = New String() {"", ""}
   '      .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
   '      .ColumnasAncho = New Integer() {70, 350}
   '      .AyudaAncho = 500
   '   End With
   'End Sub
#End Region

End Class