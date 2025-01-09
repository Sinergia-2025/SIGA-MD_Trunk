Partial Class Publicos

   Public Sub PreparaGrillaAduana(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Aduanas)
   End Sub

   Public Sub PreparaGrillaAgenteTransporte(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.AduanasAgentesTransporte)
   End Sub

   Public Sub PreparaGrillaCategorias(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.CategoriasCliente)
   End Sub
   Public Sub PreparaGrillaDespachante(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.AduanasDespachantes)
   End Sub

   Public Sub PreparaGrillaDestinacion(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.AduanasDestinaciones)
   End Sub

   Public Sub PreparaGrillaAplicacion2(buscador As Eniac.Controles.Buscador2)
      With buscador
         .ConfigBuscador = New Controles.ConfigBuscador() _
                                With {.Titulo = "Aplicaciones",
                                      .AnchoAyuda = 460}

         Dim col As Eniac.Controles.ColumnaBuscador
         '--
         col = New Controles.ColumnaBuscador()
         col.Orden = 1
         col.Nombre = Entidades.Aplicacion.Columnas.IdAplicacion.ToString()
         col.Titulo = "Código"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 120
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador()
         col.Orden = 2
         col.Nombre = Entidades.Aplicacion.Columnas.NombreAplicacion.ToString()
         col.Titulo = "Nombre"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 280
         .ColumnasVisibles.Add(col)
      End With

   End Sub

   Public Sub PreparaGrillaAplicacionFuncion2(buscador As Controles.Buscador2)
      With buscador
         .ConfigBuscador = New Controles.ConfigBuscador() With
                                    {
                                       .Titulo = "Funciones de Aplicaciones",
                                       .AnchoAyuda = 800
                                    }

         Dim col As Controles.ColumnaBuscador
         '--
         col = New Controles.ColumnaBuscador()
         col.Orden = 1
         col.Nombre = Entidades.AplicacionFuncion.Columnas.IdFuncion.ToString()
         col.Titulo = "Código"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador()
         col.Orden = 2
         col.Nombre = Entidades.AplicacionFuncion.Columnas.NombreFuncion.ToString()
         col.Titulo = "Nombre"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 280
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador()
         col.Orden = 3
         col.Nombre = Entidades.AplicacionFuncion.Columnas.IdFuncionPadre.ToString()
         col.Titulo = "Código Padre"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador()
         col.Orden = 2
         col.Nombre = Entidades.AplicacionFuncion.Columnas.NombreFuncion.ToString() + "Padre"
         col.Titulo = "Nombre Padre"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 280
         .ColumnasVisibles.Add(col)
      End With

   End Sub
   Public Sub PreparaGrillaBancos(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Bancos)
   End Sub

   Public Sub PreparaGrillaCajasUsuarios(buscador As Controles.Buscador2, muestraSucursal As Boolean)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Cajas)
   End Sub
   Public Sub PreparaGrillaCuentasContables(buscador As Eniac.Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.CuentasContables)
   End Sub

   Public Sub PreparaGrillaCentroCosto(buscador As Eniac.Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.ContabilidadCentrosCostos)
   End Sub

   Public Sub PreparaGrillaClientes2(buscador As Controles.Buscador2)

      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Clientes)

   End Sub

   Public Sub PreparaGrillaTipoAtributoProducto2(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.TiposAtributosProductos)
   End Sub
   Public Sub PreparaGrillaGrupoTipoAtributoProducto2(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.GruposTiposAtributosProductos)
   End Sub
   Public Sub PreparaGrillaAtributoProducto2(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.AtributosProductos)
   End Sub

   Public Sub PreparaGrillaComprobantesVentaPendientes(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.ComprobantesVentaPendientes)
   End Sub

   Public Sub PreparaGrillaComprobantesReenvio(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.ComprobantesReenvio)
   End Sub

   Public Sub PreparaGrillaCRMCiclosPlanificacion(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.CRMCiclosPlanificacion)
   End Sub
   Public Sub PreparaGrillaCRMNovedades(buscador As Controles.Buscador2, tipoNovedad As String)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.CRMNovedades)
   End Sub

   Public Sub PreparaGrillaCuentasDeCajas2(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.CuentasCajas)
   End Sub

   Public Sub PreparaGrillaCuentasDeBancos2(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.CuentasBancos)
   End Sub

   Public Sub PreparaGrillaCuentasBancarias2(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.CuentasBancarias)
   End Sub
   Public Sub PreparaGrillaCamas(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Camas)
   End Sub

   Public Sub PreparaGrillaDeposito2(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, "Depositos")
   End Sub

   Public Sub PreparaGrillaEmbarcaciones(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Embarcaciones)
   End Sub

   Public Sub PreparaGrillaEmpleados(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Empleados)
   End Sub
   Public Sub PreparaGrillaEmpresas(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Empresas)
   End Sub

   Public Sub PreparaGrillaEstadosCheques(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.EstadosCheques)
   End Sub
   Public Sub PreparaGrillaEstadosOrdenCalidad(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.EstadosOrdenesCalidad)
   End Sub

   Public Sub PreparaGrillaExcepciones(buscador As Controles.Buscador2)
      With buscador
         .ConfigBuscador = New Controles.ConfigBuscador() _
                          With {.Titulo = "Desvíos",
                                .AnchoAyuda = 800}

         Dim col As Eniac.Controles.ColumnaBuscador
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 1
         col.Nombre = "IdExcepcion"
         col.Titulo = "Codigo"
         col.Ancho = 70
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 2
         col.Nombre = "Dpto"
         col.Titulo = "Departamento"
         col.Ancho = 100
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 3
         col.Nombre = "IdUsuario"
         col.Titulo = "Solicitante"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 100
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 4
         col.Nombre = "FechaExcepcion"
         col.Titulo = "Fecha"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 100
         .ColumnasVisibles.Add(col)
         '-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 5
         col.Nombre = "NombreListaControlTipo"
         col.Titulo = "Sección"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 100
         .ColumnasVisibles.Add(col)
         '-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 6
         col.Nombre = "NombreExcepcionTipo"
         col.Titulo = "Tipo"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 100
         .ColumnasVisibles.Add(col)
         '-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 7
         col.Nombre = "Item"
         col.Titulo = "Item"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 300
         .ColumnasVisibles.Add(col)
         '-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 8
         col.Nombre = "Motivo"
         col.Titulo = "Motivo"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 300
         .ColumnasVisibles.Add(col)
         '-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 9
         col.Nombre = "AccionesCorrectivas"
         col.Titulo = "Acciones Correctivas"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
         '-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 10
         col.Nombre = "IdUsuario1"
         col.Titulo = "Autorizante 1"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
         '-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 11
         col.Nombre = "FechaUsuario1"
         col.Titulo = "Fecha"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
         '-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 12
         col.Nombre = "IdUsuario2"
         col.Titulo = "Autorizante 2"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
         '-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 13
         col.Nombre = "FechaUsuario2"
         col.Titulo = "Fecha"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
         '-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 14
         col.Nombre = "IdUsuario3"
         col.Titulo = "Autorizante 3"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
         '-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 15
         col.Nombre = "FechaUsuario3"
         col.Titulo = "Fecha"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
      End With
   End Sub

   Public Sub PreparaGrillaFormasDePago(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.FormasDePago)
   End Sub
   Public Sub PreparaGrillaFunciones2(buscador As Controles.Buscador2)

      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Funciones)

   End Sub

   Public Sub PreparaGrillaListaPrecios(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.ListasDePrecios)
   End Sub
   Public Sub PreparaGrillaLocalidades(buscador As Controles.Buscador2)

      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Localidades)

   End Sub

   Public Sub PreparaGrillaModelosProductos(buscador As Controles.Buscador2)
      With buscador
         .ConfigBuscador = New Controles.ConfigBuscador() _
                          With {.Titulo = "Modelos de Productos",
                                .AnchoAyuda = 800}

         Dim col As Eniac.Controles.ColumnaBuscador
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 1
         col.Nombre = "CodigoProductoModelo"
         col.Titulo = "Codigo"
         col.Ancho = 100
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 2
         col.Nombre = "NombreProductoModelo"
         col.Titulo = "Descripcion"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 300
         .ColumnasVisibles.Add(col)
         '-- 
         'col = New Controles.ColumnaBuscador
         'col.Orden = 3
         'col.Nombre = "stp_Partida"
         'col.Titulo = "Nro de Chasis"
         'col.Alineacion = DataGridViewContentAlignment.MiddleRight
         'col.Ancho = 150
         '.ColumnasVisibles.Add(col)

      End With
   End Sub

   Public Sub PreparaGrillaLotes(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Lotes)
   End Sub
   Public Sub PreparaGrillaNrosSerie(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.NrosSerie)
   End Sub

   Public Sub PreparaGrillaLotesDespacho(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.LotesDespachos)
   End Sub

   Public Sub PreparaGrillaObservaciones(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Observaciones)
   End Sub

   Public Sub PreparaGrillaOrdenDeCompra(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.OrdenesCompra)
   End Sub

   Public Sub PreparaGrillaParametros2(buscador As Controles.Buscador2)
      With buscador
         .ConfigBuscador = New Controles.ConfigBuscador() _
                          With {.Titulo = "Parametros",
                                .AnchoAyuda = 900}

         Dim col As Eniac.Controles.ColumnaBuscador
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 1
         col.Nombre = "IdParametro"
         col.Titulo = "Código"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 250
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 2
         col.Nombre = "ValorParametro"
         col.Titulo = "Valor"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 150
         .ColumnasVisibles.Add(col)
         '-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 3
         col.Nombre = "DescripcionParametro"
         col.Titulo = "Descripción"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 390
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 4
         col.Nombre = "CategoriaParametro"
         col.Titulo = "Categoría"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 150
         .ColumnasVisibles.Add(col)
      End With

   End Sub

   Public Sub PreparaGrillaPlantillas(buscador As Controles.Buscador2)

      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Plantillas)

   End Sub

   Public Sub PreparaGrillaProductos2(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Productos)
   End Sub

   Public Sub PreparaGrillaProductosProveedor2(buscador As Controles.Buscador2)
      With buscador
         .ConfigBuscador = New Controles.ConfigBuscador() _
                          With {.Titulo = "Productos",
                                .AnchoAyuda = 900}

         Dim col As Eniac.Controles.ColumnaBuscador
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 1
         col.Nombre = "IdProducto"
         col.Titulo = "Producto"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 100
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 2
         col.Nombre = "NombreProducto"
         col.Titulo = "Descripción"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 285
         .ColumnasVisibles.Add(col)
         '-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 3
         col.Nombre = "CodigoProductoProveedor"
         col.Titulo = "Codigo Proveedor"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 100
         .ColumnasVisibles.Add(col)

         col = New Controles.ColumnaBuscador
         col.Orden = 4
         col.Nombre = "Alicuota"
         col.Titulo = "IVA"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Formato = "##0.00"
         col.Ancho = 50
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 5
         col.Nombre = "NombreMoneda"
         col.Titulo = "M."
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 40
         .ColumnasVisibles.Add(col)
         '--

         col = New Controles.ColumnaBuscador
         col.Orden = 6
         col.Nombre = "PrecioVentaSinIVA"
         col.Titulo = "P.Venta Sin IVA"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Formato = "#,##0.00"
         col.Ancho = 70
         .ColumnasVisibles.Add(col)

         col = New Controles.ColumnaBuscador
         col.Orden = 7
         col.Nombre = "PrecioVentaConIVA"
         col.Titulo = "P.Venta Con IVA"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Formato = "#,##0.00"
         col.Ancho = 70
         .ColumnasVisibles.Add(col)

         col = New Controles.ColumnaBuscador
         col.Orden = 8
         col.Nombre = "Stock"
         col.Titulo = "Stock"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Formato = "#,##0.00"
         col.Ancho = 70
         .ColumnasVisibles.Add(col)

         col = New Controles.ColumnaBuscador
         col.Orden = 9
         col.Nombre = "CodigoDeBarras"
         col.Titulo = "Codigo De Barras"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 100
         .ColumnasVisibles.Add(col)

         col = New Controles.ColumnaBuscador
         col.Orden = 10
         col.Nombre = "AfectaStock"
         col.Titulo = "Afecta Stock"
         col.Alineacion = DataGridViewContentAlignment.MiddleCenter
         col.Ancho = 50
         .ColumnasVisibles.Add(col)

         col = New Controles.ColumnaBuscador
         col.Orden = 11
         col.Nombre = "EsServicio"
         col.Titulo = "Es Servicio"
         col.Alineacion = DataGridViewContentAlignment.MiddleCenter
         col.Ancho = 50
         .ColumnasVisibles.Add(col)

         col = New Controles.ColumnaBuscador
         col.Orden = 12
         col.Nombre = "PublicarEnWeb"
         col.Titulo = "En Web"
         col.Alineacion = DataGridViewContentAlignment.MiddleCenter
         col.Ancho = 50
         .ColumnasVisibles.Add(col)

         col = New Controles.ColumnaBuscador
         col.Orden = 13
         col.Nombre = "Observacion"
         col.Titulo = "Observacion"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 300
         .ColumnasVisibles.Add(col)
      End With

   End Sub

   Public Sub PreparaGrillaCatgoriasEmpleados2(buscador As Controles.Buscador2)

      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.CategoriasEmpleados)

   End Sub
   '-- MRP BUSCADORES.- ---------------------------------------------
   Public Sub PreparaGrillaMRPTareas(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.MRPTareas)
   End Sub
   Public Sub PreparaGrillaMRPNormas(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.MRPNormasFabricacion)
   End Sub
   Public Sub PreparaGrillaMRPSecciones(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.MRPSecciones)
   End Sub
   Public Sub PreparaGrillaMRPCentrosProductores(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.MRPCentroProductores)
   End Sub
   Public Sub PreparaGrillaMRPProcesosProductivos(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.MRPProcesosProductivos)
   End Sub
   '-----------------------------------------------------------------
   Public Sub PreparaGrillaCategoriasFiscales2(buscador As Controles.Buscador2)
      With buscador
         .ConfigBuscador = New Controles.ConfigBuscador() _
                          With {.Titulo = "Categorias Fiscales",
                                .AnchoAyuda = 900}

         Dim col As Eniac.Controles.ColumnaBuscador
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 1
         col.Nombre = "IdCategoriaFiscal"
         col.Titulo = "Categoria"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 100
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 2
         col.Nombre = "NombreCategoriaFiscal"
         col.Titulo = "Descripción"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 285
         .ColumnasVisibles.Add(col)
         '-- 

      End With

   End Sub

   Public Sub PreparaGrillaProspectos2(buscador As Controles.Buscador2)

      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Prospectos)

   End Sub

   Public Sub PreparaGrillaProveedores2(buscador As Controles.Buscador2)

      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Proveedores)

   End Sub

   Public Sub PreparaGrillaProyectos(buscador As Controles.Buscador2)

      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Proyectos)

   End Sub

   Public Sub PreparaGrillaRepartos(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Repartos)
   End Sub

   Public Sub PreparaGrillaReservas(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.ReservasTurismo)
   End Sub

   Public Sub PreparaGrillaRubros2(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Rubros)
   End Sub
   Public Sub PreparaGrillaMovilRutas(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Rutas)
   End Sub

   Public Sub PreparaGrillaMarcas2(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Marcas)
   End Sub
   Public Sub PreparaGrillaCRMCategorias(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.CRMCategorias)
   End Sub
   Public Sub PreparaGrillaCRMMedios(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.CRMMediosComunicacion)
   End Sub
   Public Sub PreparaGrillaCRMMetodos(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.CRMMetodos)
   End Sub
   Public Sub PreparaGrillaCRMEstados(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.CRMEstados)
   End Sub
   Public Sub PreparaGrillaModelos(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Modelos)
   End Sub

   Public Sub PreparaGrillaSubRubros2(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.SubRubros)
   End Sub
   Public Sub PreparaGrillaSubSubRubros2(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.SubSubRubros)
   End Sub
   Public Sub PreparaGrillaSucursales(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Sucursales)
   End Sub
   Public Sub PreparaGrillaTablerosControlPanel(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.TablerosControlPanel)
   End Sub

   Public Sub PreparaGrillaTiposCliente(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.TiposClientes)
   End Sub
   Public Sub PreparaGrillaGrupoTiposComprobantes(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.GrupoTiposComprobantes)
   End Sub
   Public Sub PreparaGrillaTiposComprobantes(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.TiposComprobantes)
   End Sub
   Public Sub PreparaGrillaTiposUnidades(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.TiposUnidades)
   End Sub
   Public Sub PreparaGrillaTransportistas(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Transportistas)
   End Sub

   Public Sub PreparaGrillaUnidadesDeMedida(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.UnidadesDeMedida)
   End Sub

   Public Sub PreparaGrillaVehiculos2(buscador As Controles.Buscador2)

      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.Vehiculos)

   End Sub

   Public Sub PreparaGrillaZonasGeograficas2(buscador As Controles.Buscador2)
      PreparaGrillaAutomatico(buscador, Entidades.Buscador.Buscadores.ZonasGeograficas)
   End Sub


#Region "Método base para Buscador2"
   <Obsolete("Reemplazar por el que recibe el Enum")>
   Public Shared Sub PreparaGrillaAutomatico(buscador As Controles.Buscador2, TituloBuscador As String)
      Dim bus As DataTable = New DataTable()
      bus = New Reglas.Buscadores().GetBuscador(TituloBuscador)
      Dim buscamp As DataTable = New DataTable()
      If bus.Rows.Count = 0 Then Throw New Exception(String.Format("No existe el buscador con IdBuscador = '{0}'.", TituloBuscador))
      buscamp = New Reglas.Buscadores().GetBuscadorCampos(Integer.Parse(bus.Rows(0).Item("IdBuscador").ToString()))

      Dim iniciaConFocoEn As Controles.IniciaConFocoEn
      If Not [Enum].TryParse(bus.Rows(0).Item("IniciaConFocoEn").ToString(), True, iniciaConFocoEn) Then
         iniciaConFocoEn = Controles.IniciaConFocoEn.Grilla
      End If

      With buscador
         .ColumnasVisibles.Clear()
         .ConfigBuscador = New Controles.ConfigBuscador() _
                          With {.Titulo = bus.Rows(0).Item("Titulo").ToString().Trim(),
                                .AnchoAyuda = Integer.Parse(bus.Rows(0).Item("AnchoAyuda").ToString()),
                                .IniciaConFocoEn = iniciaConFocoEn,
                                .ColumaBusquedaInicial = bus.Rows(0).Item("ColumaBusquedaInicial").ToString()}
         Dim col As Eniac.Controles.ColumnaBuscador
         For Each dr As DataRow In buscamp.Rows
            col = New Controles.ColumnaBuscador
            col.Orden = Integer.Parse(dr("Orden").ToString())
            col.Nombre = dr("IdBuscadorNombreCampo").ToString().Trim()
            col.Titulo = dr("Titulo").ToString().Trim()
            Select Case Integer.Parse(dr("Alineacion").ToString())
               Case 64
                  col.Alineacion = DataGridViewContentAlignment.MiddleRight
               Case 32
                  col.Alineacion = DataGridViewContentAlignment.MiddleCenter
               Case 16
                  col.Alineacion = DataGridViewContentAlignment.MiddleLeft
            End Select
            col.Ancho = Integer.Parse(dr("Ancho").ToString())
            col.Formato = dr("Formato").ToString().Trim()

            Dim con As Eniac.Controles.ColumnaCondicion = New Eniac.Controles.ColumnaCondicion()
            If Not String.IsNullOrEmpty(dr("Valor").ToString()) Then
               con.Nombre = dr("IdBuscadorNombreCampo").ToString().Trim()
               Select Case dr("Condicion").ToString()
                  Case "Igual"
                     con.Condicion = Controles.ColumnaCondicion.TipoCondicion.Igual
                  Case "Menor"
                     con.Condicion = Controles.ColumnaCondicion.TipoCondicion.Menor
                  Case "Mayor"
                     con.Condicion = Controles.ColumnaCondicion.TipoCondicion.Mayor
                  Case "Como"
                     con.Condicion = Controles.ColumnaCondicion.TipoCondicion.Como
               End Select
               con.Valor = dr("Valor").ToString().Trim()
               con.ColorFila = Color.FromName(dr("ColorFila").ToString().Trim())
               buscador.ColumnasCondiciones.Add(con)
            End If

            .ColumnasVisibles.Add(col)
         Next

      End With


   End Sub
   Public Shared Sub PreparaGrillaAutomatico(buscador As Controles.Buscador2, idBuscador As Entidades.Buscador.Buscadores)
      Dim bus = New Reglas.Buscadores().GetUno(idBuscador)

      buscador.ColumnasVisibles.Clear()
      buscador.ConfigBuscador = New Controles.ConfigBuscador() With {
                                    .Titulo = bus.Titulo.Trim(),
                                    .AnchoAyuda = bus.AnchoAyuda,
                                    .IniciaConFocoEn = bus.IniciaConFocoEn.ToString().StringToEnum(Controles.IniciaConFocoEn.Grilla),
                                    .ColumaBusquedaInicial = bus.ColumnaBusquedaInicial
                                 }
      For Each dr In bus.Campos
         Dim col = New Controles.ColumnaBuscador With {
            .Orden = dr.Orden,
            .Nombre = dr.IdBuscadorNombreCampo,
            .Titulo = dr.Titulo,
            .Alineacion = dr.Alineacion,
            .Ancho = dr.Ancho,
            .Formato = dr.Formato
         }

         If Not String.IsNullOrEmpty(dr.ValorCondicion) Then
            Dim con = New Controles.ColumnaCondicion With {
               .Nombre = dr.IdBuscadorNombreCampo,
               .Condicion = dr.Condicion.ToString().StringToEnum(Controles.ColumnaCondicion.TipoCondicion.Igual),
               .Valor = dr.ValorCondicion,
               .ColorFila = Color.FromName(dr.ColorFilaCondicion.Trim())
            }
            buscador.ColumnasCondiciones.Add(con)
         End If
         buscador.ColumnasVisibles.Add(col)
      Next
   End Sub
   Public Shared Sub PreparaGrillaAutomatico(grilla As DataGridView, idBuscador As Entidades.Buscador.Buscadores)
      Dim bus = New Reglas.Buscadores().GetUno(idBuscador)
      grilla.OcultaTodasLasColumnas()

      For Each dr In bus.Campos
         Dim column = grilla.Columns.OfType(Of DataGridViewColumn).FirstOrDefault(Function(dc) dc.DataPropertyName = dr.IdBuscadorNombreCampo)
         If column IsNot Nothing Then
            column.HeaderText = dr.Titulo
            column.Width = dr.Ancho
            column.DisplayIndex = dr.Orden
            column.DefaultCellStyle.Alignment = dr.Alineacion
            column.DefaultCellStyle.Format = dr.Formato
            column.Visible = True
         End If
      Next
   End Sub
   Public Shared Sub PreparaGrillaAutomatico(grilla As UltraGrid, idBuscador As Entidades.Buscador.Buscadores)
      Dim bus = New Reglas.Buscadores().GetUno(idBuscador)
      grilla.OcultaTodasLasColumnas()

      For Each dr In bus.Campos
         Dim column = grilla.DisplayLayout.Bands(0).Columns.OfType(Of UltraGridColumn).FirstOrDefault(Function(dc) dc.Key = dr.IdBuscadorNombreCampo)
         If column IsNot Nothing Then
            column.Header.Caption = dr.Titulo
            column.Width = dr.Ancho
            column.Header.VisiblePosition = dr.Orden
            column.CellAppearance.TextHAlign = dr.Alineacion.ToHAlign
            column.CellAppearance.TextVAlign = dr.Alineacion.ToVAlign
            column.Format = dr.Formato
            column.Hidden = Not True
         End If
      Next
   End Sub
#End Region

End Class