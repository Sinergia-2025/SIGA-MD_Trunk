Public Class Cartas
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Cartas"
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._I)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._D)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._U)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Cartas = New SqlServer.Cartas(Me.da)
      Dim ds As DataSet = New DataSet()
      'ds.Tables.Add(sql.Buscar(entidad.Columna, entidad.Valor.ToString()))
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Cartas(Me.da).Cartas_GA()
   End Function

   Public Function GetxTipo(ByVal Tipo As String, ByVal Orden As String) As System.Data.DataTable
      Return New SqlServer.Cartas(Me.da).Cartas_GxTipo(Tipo, Orden)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.Carta = DirectCast(entidad, Entidades.Carta)

      Dim sql As SqlServer.Cartas = New SqlServer.Cartas(Me.da)
      Select Case tipo
         Case TipoSP._I
            sql.Cartas_I(en.IdCarta, en.NombreCarta, en.DiasDefault, en.ProximaCarta, en.Texto, en.Texto2,
                           en.TextoRTF, en.Texto2RTF, en.Firma, en.MiraAnoEnCurso, en.EsHTML, en.Tipo)
         Case TipoSP._U
            sql.Cartas_U(en.IdCarta, en.NombreCarta, en.DiasDefault, en.ProximaCarta, en.Texto, en.Texto2,
                           en.TextoRTF, en.Texto2RTF, en.Firma, en.MiraAnoEnCurso, en.EsHTML, en.Tipo)
         Case TipoSP._D
            sql.Cartas_D(en.IdCarta)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.Carta, ByVal dr As DataRow)
      With o
         .IdCarta = Int32.Parse(dr(Entidades.Carta.Columnas.IdCarta.ToString()).ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.Carta.Columnas.NombreCarta.ToString()).ToString()) Then
            .NombreCarta = dr(Entidades.Carta.Columnas.NombreCarta.ToString()).ToString()
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Carta.Columnas.Firma.ToString()).ToString()) Then
            .Firma = dr(Entidades.Carta.Columnas.Firma.ToString()).ToString()
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Carta.Columnas.DiasDefault.ToString()).ToString()) Then
            .DiasDefault = Int32.Parse(dr(Entidades.Carta.Columnas.DiasDefault.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Carta.Columnas.ProximaCarta.ToString()).ToString()) Then
            .ProximaCarta = Int32.Parse(dr(Entidades.Carta.Columnas.ProximaCarta.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Carta.Columnas.Texto.ToString()).ToString()) Then
            .Texto = dr(Entidades.Carta.Columnas.Texto.ToString()).ToString()
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Carta.Columnas.Texto2.ToString()).ToString()) Then
            .Texto2 = dr(Entidades.Carta.Columnas.Texto2.ToString()).ToString()
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Carta.Columnas.TextoRTF.ToString()).ToString()) Then
            .TextoRTF = dr(Entidades.Carta.Columnas.TextoRTF.ToString()).ToString()
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Carta.Columnas.Texto2RTF.ToString()).ToString()) Then
            .Texto2RTF = dr(Entidades.Carta.Columnas.Texto2RTF.ToString()).ToString()
         End If
         .MiraAnoEnCurso = Boolean.Parse(dr(Entidades.Carta.Columnas.MiraAnoEnCurso.ToString()).ToString())
         .EsHTML = Boolean.Parse(dr(Entidades.Carta.Columnas.EsHTML.ToString()).ToString())
         .Tipo = dr(Entidades.Carta.Columnas.Tipo.ToString()).ToString()

      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.Carta)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.Carta
      Dim oLis As List(Of Entidades.Carta) = New List(Of Entidades.Carta)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.Carta()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUno(ByVal idCarta As Integer) As Entidades.Carta
      Dim sql As SqlServer.Cartas = New SqlServer.Cartas(Me.da)

      Dim dt As DataTable = sql.Cartas_G1(idCarta)

      Dim o As Entidades.Carta = New Entidades.Carta()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe la Carta.")
      End If
      Return o
   End Function

   Public Sub EnvioCartas(ByVal colDatos As List(Of Long),
                           ByVal numeroCarta As Integer,
                           ByVal usuario As String,
                           ByVal proximaCarta As Integer,
                           ByVal fechaLiquidacion As DateTime,
                           ByVal fechaAlerta As DateTime,
                           ByVal fechaLLamadasPrevias As DateTime)
#Region "Codigo-Marcado"
      'Try
      '   da.OpenConection()
      '   da.BeginTransaction()

      '   Dim reg As Reglas.Pagos = New Reglas.Pagos(Me.da)

      '   Dim fechaCarta1 As DateTime = Nothing
      '   Dim fechaCarta2 As DateTime = Nothing
      '   Dim fechaCarta3 As DateTime = Nothing
      '   Dim FechaCartaLiqParcial As DateTime = Nothing

      '   Dim sql As SqlServer.Pagos = New SqlServer.Pagos(Me.da)
      '   Dim sqlD As SqlServer.Datos = New SqlServer.Datos(Me.da)
      '   Dim sqlGes As SqlServer.Gestiones = New SqlServer.Gestiones(Me.da)
      '   Dim sqlAler As SqlServer.Alertas = New SqlServer.Alertas(Me.da)

      '   Dim dt As DataTable
      '   Dim id As Long
      '   Dim textoGestion As String = String.Empty
      '   Dim textoAlerta As String = String.Empty
      '   Dim textoAlertaPosterior As String = String.Empty
      '   Dim controloTextoAlerta As String = "ENVIAR CARTA"
      '   Dim ImporteReclamado As Decimal = 0

      '   Select Case numeroCarta
      '      Case 1, 4
      '         fechaCarta1 = DateTime.Now
      '         textoGestion = "ENVIO CARTA 1"
      '         textoAlertaPosterior = "LLAMADA POSTERIOR CARTA 1"
      '         textoAlerta = "ENVIAR CARTA " + proximaCarta.ToString()
      '         If numeroCarta = 4 Then
      '            textoGestion += " B"
      '            textoAlertaPosterior += " B"
      '            textoAlerta += " B"
      '         End If
      '      Case 2
      '         fechaCarta2 = DateTime.Now
      '         textoGestion = "ENVIO CARTA " + numeroCarta.ToString()
      '         textoAlertaPosterior = "LLAMADA POSTERIOR CARTA " + numeroCarta.ToString()
      '         textoAlerta = "ENVIAR CARTA " + proximaCarta.ToString()
      '      Case 3
      '         fechaCarta3 = DateTime.Now
      '         textoGestion = "ENVIO CARTA " + numeroCarta.ToString()
      '         textoAlertaPosterior = "LLAMADA POSTERIOR CARTA " + numeroCarta.ToString()
      '         textoAlerta = "ENVIAR CARTA " + proximaCarta.ToString()
      '      Case 5
      '         FechaCartaLiqParcial = DateTime.Now
      '         textoGestion = "ENVIO CARTA LIQUIDACION "
      '         textoAlertaPosterior = "LLAMADA POSTERIOR ENVIO LIQUIDACION "
      '   End Select

      '   'obtengo todos los pagos de un dato
      '   For Each idDato As Long In colDatos


      '      'cargar la gestion
      '      id = sqlGes.GetProximoId()

      '      If numeroCarta <> 5 Then

      '         'recorre todos los pagos del Dato y actualiza las fechas
      '         dt = sqlD.Datos_GPagos(idDato)

      '         For Each dr As DataRow In dt.Rows
      '            sql.Pagos_UFechasCartas(Long.Parse(dr("IdPago").ToString()), fechaCarta1, fechaCarta2, fechaCarta3, fechaLiquidacion, FechaCartaLiqParcial)
      '            ImporteReclamado += Decimal.Parse(dr("ImporteAproximado").ToString())
      '         Next

      '         sqlGes.Gestiones_I(id, idDato, DateTime.Now, usuario, textoGestion, DateTime.Now, 1, numeroCarta, ImporteReclamado)
      '      Else
      '         Dim rPromesa As New Reglas.PromesasDePagos
      '         Dim idPP As Long = (New Reglas.PromesasDePagos).GetPromesaActiva(idDato)
      '         Dim oPromesa As Entidades.PromesaDePago = rPromesa.GetUno(idPP)
      '         Dim tipoNotificacion As Integer = CInt(If(oPromesa.TipoPromesa = "O", 11, 10))
      '         If tipoNotificacion = 10 Then
      '            Dim dtCuotasPendientes As DataTable = (New Reglas.PromesasDePagosDetalles).GetCuotasPendientes(idPP)
      '            Dim primerCuotaPendiente As Integer
      '            If dtCuotasPendientes.Rows.Count > 0 Then
      '               primerCuotaPendiente = Integer.Parse(dtCuotasPendientes.Rows(0).Item("NumeroCuota").ToString())
      '               For Each dr As DataRow In dtCuotasPendientes.Rows
      '                  If primerCuotaPendiente <> Integer.Parse(dr("NumeroCuota").ToString()) Then
      '                     Exit For
      '                  Else
      '                     ImporteReclamado += Decimal.Parse(dr("Importe").ToString())
      '                     '  sql.Pagos_UFechasCartas(Long.Parse(dr("IdPago").ToString()), fechaCarta1, fechaCarta2, fechaCarta3, fechaLiquidacion, FechaCartaLiqParcial)
      '                  End If
      '               Next
      '               sqlGes.Gestiones_I(id, idDato, DateTime.Now, usuario, textoGestion, DateTime.Now, tipoNotificacion, numeroCarta, ImporteReclamado)
      '            Else
      '               textoGestion = textoGestion & "Ninguna Pendiente"
      '            End If
      '         End If
      '      End If

      '      'controlo si tiene alertas activas y las desabilito
      '      Dim dtA As DataTable = sqlAler.Alertas_GDeUnDatoActivas(idDato)
      '      For Each drA As DataRow In dtA.Rows
      '         If drA("MotivoAlerta").ToString().Length >= 12 Then
      '            If drA("MotivoAlerta").ToString().Substring(0, 12).ToUpper() = controloTextoAlerta Then
      '               If Not Boolean.Parse(drA("Desactivar").ToString()) Then
      '                  sqlAler.Alertas_UDesactivar(Long.Parse(drA("IdAlerta").ToString()))
      '               End If
      '            End If
      '         End If
      '      Next

      '      'cargar la alerta si tiene proxima carta
      '      If Not String.IsNullOrEmpty(textoAlertaPosterior) Then
      '         id = sqlAler.GetProximoId()
      '         sqlAler.Alertas_I(id, fechaLLamadasPrevias, textoAlertaPosterior, False, idDato, False, 2)
      '      End If
      '      If proximaCarta <> 0 Then
      '         id = sqlAler.GetProximoId()
      '         sqlAler.Alertas_I(id, fechaAlerta, textoAlerta, False, idDato, False, 1)
      '      End If
      '      ImporteReclamado = 0
      '   Next

      '   da.CommitTransaction()

      'Catch ex As Exception
      '   da.RollbakTransaction()
      '   Throw ex
      'Finally
      '   da.CloseConection()
      'End Try
#End Region

   End Sub

   Public Sub EnvioCartasMutual(ByVal colDatos As List(Of Long), _
                           ByVal numeroCarta As Integer, _
                           ByVal usuario As String, _
                           ByVal proximaCarta As Integer, _
                           ByVal fechaLiquidacion As DateTime, _
                           ByVal fechaAlerta As DateTime, _
                           ByVal fechaLLamadasPrevias As DateTime)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim reg As Reglas.ClientesDeudas = New Reglas.ClientesDeudas(Me.da)

         Dim fechaCarta1 As DateTime = Nothing
         Dim fechaCarta2 As DateTime = Nothing
         Dim fechaCarta3 As DateTime = Nothing
         Dim FechaCartaLiqParcial As DateTime = Nothing

         Dim sql As SqlServer.ClientesDeudas = New SqlServer.ClientesDeudas(Me.da)
         Dim sqlD As SqlServer.Clientes = New SqlServer.Clientes(Me.da, Entidades.Cliente.ModoClienteProspecto.Cliente)

         Dim SqlCRM As SqlServer.CRMNovedades = New SqlServer.CRMNovedades(Me.da)
         'Dim sqlGes As SqlServer.Gestiones = New SqlServer.Gestiones(Me.da)
         'Dim sqlAler As SqlServer.Alertas = New SqlServer.Alertas(Me.da)

         Dim dt As DataTable
         Dim id As Long
         Dim textoGestion As String = String.Empty
         Dim textoAlerta As String = String.Empty
         Dim textoAlertaPosterior As String = String.Empty
         Dim controloTextoAlerta As String = "ENVIAR CARTA"
         Dim ImporteReclamado As Decimal = 0

         Select Case numeroCarta
            Case 80
               fechaCarta1 = DateTime.Now
               textoGestion = "ENVIO CARTA 1"
               textoAlertaPosterior = "LLAMADA POSTERIOR CARTA 1"
               textoAlerta = "ENVIAR CARTA " + proximaCarta.ToString()
            Case 82
               FechaCartaLiqParcial = DateTime.Now
               textoGestion = "ENVIO ACUERDO DE PAGO"
               textoAlertaPosterior = "CORROBORAR ACUERDO"
            Case 83
               FechaCartaLiqParcial = DateTime.Now
               textoGestion = "ENVIO ACUERDO DE PAGO"
               textoAlertaPosterior = "CORROBORAR ACUERDO"
         End Select

         'obtengo todos los pagos de un dato
         For Each idDato As Long In colDatos


            'cargar la gestion
            id = SqlCRM.GetCodigoMaximo("GESTIONES", "X", 1S) + 1



            'recorre todos los pagos del Dato y actualiza las fechas
            dt = sql.ClientesDeudas_GTotalDeuda(idDato)

            For Each dr As DataRow In dt.Rows
               sql.ClientesDeudas_UFechasCartas(Long.Parse(dr("IdCliente").ToString()), fechaLiquidacion, fechaCarta1, fechaCarta2)
               'ImporteReclamado += Decimal.Parse(dr("ImporteAproximado").ToString())
            Next

            Dim fechaActualizacionWeb As DateTime? = Nothing   'Desde la aplicación de gestión pasamos siempre NOTHING para que lo grabe SQL
            Dim nroSerieProductoPrestado As String = Nothing

            If numeroCarta = 80 Then
               '   sqlGes.Gestiones_I(id, idDato, DateTime.Now, usuario, textoGestion, DateTime.Now, 1, numeroCarta, ImporteReclamado)
               SqlCRM.CRMNovedades_I(fechaActualizacionWeb, "GESTIONES", "X", 1, id, DateTime.Now, textoGestion, 100, 1, 100, DateTime.Now,
                                      usuario, DateTime.Now, usuario, usuario, 0, 1, idDato, Nothing, Nothing,
                                      Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, False,
                                      False, Nothing, "", 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

            ElseIf numeroCarta = 82 Then

               SqlCRM.CRMNovedades_I(fechaActualizacionWeb, "GESTIONES", "X", 1, id, DateTime.Now, textoGestion, 100, 10, 100, DateTime.Now,
                                   usuario, DateTime.Now, usuario, usuario, 0, 1, idDato, Nothing, Nothing,
                                   Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, False,
                                   False, Nothing, "", 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

            ElseIf numeroCarta = 83 Then

               SqlCRM.CRMNovedades_I(fechaActualizacionWeb, "GESTIONES", "X", 1, id, DateTime.Now, textoGestion, 100, 11, 100, DateTime.Now,
                                 usuario, DateTime.Now, usuario, usuario, 0, 1, idDato, Nothing, Nothing,
                                 Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, False,
                                 False, Nothing, "", 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            End If

            ''controlo si tiene alertas activas y las desabilito
            Dim crm As Entidades.CRMNovedad = New Entidades.CRMNovedad
            Dim ocrm As Reglas.CRMNovedades = New Reglas.CRMNovedades()
            Dim dtA As DataTable = SqlCRM.GetGestionesAlertasXCliente("ALERTAS", idDato)
            'Dim dtA As DataTable = sqlAler.Alertas_GDeUnDatoActivas(idDato)

            For Each drA As DataRow In dtA.Rows
               If drA("Descripcion").ToString() = "ENVIAR CARTA " + proximaCarta.ToString() Or drA("Descripcion").ToString() = "LLAMADA POSTERIOR CARTA " + numeroCarta.ToString() Then
                  If Not Boolean.Parse(drA("RevisionAdministrativa").ToString()) Then
                     crm = ocrm.GetUno("ALERTAS", "X", 1, Long.Parse(drA("IdNovedad").ToString()))
                     crm.RevisionAdministrativa = True
                     ocrm.Actualizar(crm)
                     'sqlAler.Alertas_UDesactivar()
                     'SqlCRM.
                  End If
               End If
            Next

            'cargar la alerta si tiene proxima carta
            If Not String.IsNullOrEmpty(textoAlertaPosterior) Then
               id = SqlCRM.GetCodigoMaximo("ALERTAS", "X", 1S) + 1

               If numeroCarta <> 80 Then
                  SqlCRM.CRMNovedades_I(fechaActualizacionWeb, "ALERTAS", "X", 1, id, fechaLLamadasPrevias, textoAlertaPosterior,
                                        101, 42, 101, DateTime.Now, usuario, DateTime.Now, usuario, usuario,
                                        0, 2, idDato, Nothing, Nothing,
                                        Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing,
                                        False, False, Nothing, "", 1, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)


               Else
                  SqlCRM.CRMNovedades_I(fechaActualizacionWeb, "ALERTAS", "X", 1, id, fechaLLamadasPrevias, textoAlertaPosterior,
                                         101, 54, 101, DateTime.Now, usuario, DateTime.Now, usuario, usuario,
                                         0, 2, idDato, Nothing, Nothing,
                                         Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing,
                                         False, False, Nothing, "", 1, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)


               End If



               'id = sqlAler.GetProximoId()
               'sqlAler.Alertas_I(id, fechaLLamadasPrevias, textoAlertaPosterior, False, idDato, False, 2)

            End If
            If proximaCarta <> 0 Then

               id = SqlCRM.GetCodigoMaximo("ALERTAS", "X", 1S) + 1

               SqlCRM.CRMNovedades_I(fechaActualizacionWeb, "ALERTAS", "X", 1, id, fechaAlerta, textoAlerta,
                                     101, 42, 101, DateTime.Now, usuario, DateTime.Now, usuario, usuario,
                                     0, 2, idDato, Nothing, Nothing,
                                     Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing,
                                     False, False, Nothing, "X", 1, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

               'id = sqlAler.GetProximoId()
               'sqlAler.Alertas_I(id, fechaAlerta, textoAlerta, False, idDato, False, 1)
            End If
            ImporteReclamado = 0
         Next

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub CancelarCarta(ByVal idDato As Long, ByVal numeroCarta As Integer, ByVal usuario As String, ByVal proximaCarta As Integer)
      Try
         da.OpenConection()
         da.BeginTransaction()


         Dim SqlCRM As SqlServer.CRMNovedades = New SqlServer.CRMNovedades(Me.da)
         Dim id As Long = 0
         Dim ImporteReclamado As Decimal = 0
         Dim dt As DataTable

         If numeroCarta <> 80 Then
            Throw New Exception("Este nro. de carta no se puede Cancelar")
         End If

         Dim fechaActualizacionWeb As DateTime? = Nothing   'Desde la aplicación de gestión pasamos siempre NOTHING para que lo grabe SQL
         Dim nroSerieProductoPrestado As String = Nothing

         id = SqlCRM.GetCodigoMaximo("GESTIONES", "X", 1S) + 1
         SqlCRM.CRMNovedades_I(fechaActualizacionWeb, "GESTIONES", "X", 1, id, DateTime.Now, "CANCELO CARTA " + numeroCarta.ToString(), 100, 1, 100, DateTime.Now, usuario, DateTime.Now, usuario, usuario, 0, 1, idDato, Nothing, Nothing,
                               Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, False, False, Nothing, "", 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)



         'controlo si tiene alertas activas y las desabilito
         Dim crm As Entidades.CRMNovedad = New Entidades.CRMNovedad
         Dim ocrm As Reglas.CRMNovedades = New Reglas.CRMNovedades()
         Dim dtA As DataTable = SqlCRM.GetGestionesAlertasXCliente("ALERTAS", idDato)
         'Dim dtA As DataTable = sqlAler.Alertas_GDeUnDatoActivas(idDato)

         For Each drA As DataRow In dtA.Rows
            If drA("Descripcion").ToString() = "ENVIAR CARTA " + proximaCarta.ToString() Or drA("Descripcion").ToString() = "LLAMADA POSTERIOR CARTA " + numeroCarta.ToString() Then
               If Not Boolean.Parse(drA("RevisionAdministrativa").ToString()) Then
                  crm = ocrm.GetUno("ALERTAS", "X", 1, Long.Parse(drA("IdNovedad").ToString()))
                  crm.RevisionAdministrativa = True
                  ocrm.Actualizar(crm)
                  'sqlAler.Alertas_UDesactivar()
                  'SqlCRM.
               End If
            End If
         Next

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

 
#End Region

End Class

