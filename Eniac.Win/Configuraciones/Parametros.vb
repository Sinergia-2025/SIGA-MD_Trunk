Public Class Parametros

   Private _publicos As Publicos
#Region "Campos"

   Private _ucConfig As List(Of ucConfBase)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(
         Sub()

            _publicos = New Publicos()

            Reglas.ParametrosCache.Instancia.LimpiarCache()
            Reglas.ParametrosCache.Instancia.CargarTodos()

            _ucConfig = New List(Of ucConfBase)() From
                              {UcNDConfDatosEmpresa1, UcNDConfModulos1, UcNDConfVentas1, UcNDConfFacturaElectronica1,
                               UcNDConfPrecios1, UcNDConfCtaCteCliente1, UcNDConfCtaCteProv1, UcNDConfPedidos1,
                               UcNDConfArchivos1, UcNDConfExpensas1, UcNDConfStock1, UcNDConfBasesSecundarias1, UcNDConfActualizador1}

            _ucConfig.ForEach(Sub(uc) uc.Inicializar())

            CargasParametros()
         End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         Grabar()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(
         Sub()
            If ValidarDatos() Then
               Grabar()
               ShowMessage("Para que se apliquen estos seteos debe salir y volver a ingresar a la aplicacion.")
            End If
         End Sub,
         onFinallyAction:=Sub(owner) Reglas.ParametrosCache.Instancia.LimpiarCache())
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargasParametros()
      Try
         Dim sw = New Stopwatch()
         sw.Start()

         _ucConfig.ForEach(Sub(uc) uc.CargarParametros())

         sw.Stop()
      Catch ex As Exception
         Dim err = New StringBuilder()
         With err
            .AppendFormatLine("Error cargando Parametros: {0}", ex.Message).AppendLine()
            .AppendFormatLine("Stack Trace: {0}", ex.StackTrace)
         End With
         ShowMessage(err.ToString())
      End Try
   End Sub

   Private Sub ActualizarParametro(idParametro As String, valorParametro As String, categoriaParametro As String, descripcionParametro As String)

      Reglas.ParametrosCache.Editor.Instancia().Actualizar(idParametro, valorParametro, categoriaParametro, descripcionParametro, ubicacionParametro:=String.Empty)

   End Sub

   Private Sub Grabar()
      Reglas.ParametrosCache.Instancia().CargarTodos()
      Reglas.ParametrosCache.Editor.Instancia().Clear()

      _ucConfig.ForEach(Sub(uc) uc.GrabarParametros())

      Reglas.ParametrosCache.Editor.Instancia().Commit()
   End Sub

   Private Sub LocateControlOnTabs(uc As Control)
      uc.LocateControlOnTabs(Sub(tc, tp) tc.SelectTab(tp))
   End Sub

   Private Function ValidarDatos() As Boolean
      Dim stb = New StringBuilder()
      Dim algunError As Boolean = False
      Dim debeReposicionarConError As Boolean = True

      _ucConfig.ForEach(
         Sub(uc)
            If uc.ValidarParametros(stb) Then
               algunError = True
               If debeReposicionarConError Then
                  LocateControlOnTabs(uc)
                  debeReposicionarConError = False
               End If
            End If
         End Sub)

      If algunError Then
         ShowMessage(stb.ToString())
      End If
      Return Not algunError
   End Function

#End Region

End Class