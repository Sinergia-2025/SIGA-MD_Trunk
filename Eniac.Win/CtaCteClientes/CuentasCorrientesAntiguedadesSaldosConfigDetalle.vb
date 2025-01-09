Public Class CuentasCorrientesAntiguedadesSaldosConfigDetalle

#Region "Campos"

   Private _publicos As Publicos

#End Region

   Private ReadOnly Property AntiguedadSaldoConfig As Entidades.CuentaCorrienteAntiguedadSaldoConfig
      Get
         Return DirectCast(_entidad, Entidades.CuentaCorrienteAntiguedadSaldoConfig)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.CuentaCorrienteAntiguedadSaldoConfig)
      Me.New()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            _publicos.CargaComboDesdeEnum(cmbTipoAntiguedadSaldoConfig, GetType(Entidades.CuentaCorrienteAntiguedadSaldoConfig.TipoAntiguedadSaldo))

            BindearControles(_entidad)

            If Me.StateForm = Eniac.Win.StateForm.Insertar Then
               CargarProximoNumero()

            Else

            End If

            ugRangos.DataSource = AntiguedadSaldoConfig.Rangos

         End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CuentasCorrientesAntiguedadesSaldosConfig()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()
   End Function

#End Region

#Region "Eventos"
   Private Sub txtEtiqueta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOrden.KeyDown, txtEtiqueta.KeyDown, txtDiasHasta.KeyDown, txtDiasDesde.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      TryCatched(Sub() InsertarRango())
   End Sub
   Private Sub ugRangos_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugRangos.DoubleClickRow
      TryCatched(Sub() EditarRangos())
   End Sub
   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      TryCatched(Sub() EliminarRango())
   End Sub
   Private Sub btnSubirRango_Click(sender As Object, e As EventArgs) Handles btnSubirRango.Click
      TryCatched(Sub() SubirRango())
   End Sub
   Private Sub btnBajarRango_Click(sender As Object, e As EventArgs) Handles btnBajarRango.Click
      TryCatched(Sub() BajarRango())
   End Sub
#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      txtCodigo.Text = (New Reglas.CuentasCorrientesAntiguedadesSaldosConfig().GetCodigoMaximo() + 1).ToString()
   End Sub

   Private Sub LimpiaCamposRango()
      txtEtiqueta.Clear()
      txtDiasDesde.SetValor(0)
      txtDiasHasta.SetValor(0)
      txtOrden.SetValor(AntiguedadSaldoConfig.Rangos.MaxSecure(Function(r) r.Orden).IfNull() + 1)
   End Sub

   Private Sub InsertarRango()
      Dim desde = Decimal.ToInt32(txtDiasDesde.ValorNumericoPorDefecto(0D))
      Dim hasta = Decimal.ToInt32(txtDiasHasta.ValorNumericoPorDefecto(0D))
      Dim orden = Decimal.ToInt32(txtOrden.ValorNumericoPorDefecto(0D))
      If ValidarInsertarRango(desde, hasta, orden) Then
         If AntiguedadSaldoConfig.Rangos.Any(Function(r) r.Orden = orden) Then
            AntiguedadSaldoConfig.Rangos.Where(Function(r) r.Orden >= orden).ToList().ForEach(Sub(r) r.Orden += 1)
         End If
         AntiguedadSaldoConfig.Rangos.Add(New Entidades.CuentaCorrienteAntiguedadSaldoRangos() With
                                          {
                                             .DiasDesde = desde,
                                             .DiasHasta = hasta,
                                             .EtiquetaColumna = txtEtiqueta.Text,
                                             .Orden = orden
                                          })

         RefreshGrillaRangos()
         LimpiaCamposRango()
      End If
   End Sub

   Private Function ValidarInsertarRango(desde As Integer, hasta As Integer, orden As Integer) As Boolean
      If String.IsNullOrWhiteSpace(txtEtiqueta.Text) Then
         ShowMessage("Debe ingresar una Etiqueta para el rango.")
         Return False
      End If

      If orden < 1 Then
         ShowMessage("El orden debe ser mayor a cero.")
         Return False
      End If

      Dim result = AntiguedadSaldoConfig.Rangos.All(
                     Function(r)
                        If CompraraRangosEnteros(desde, hasta, r.DiasDesde, r.DiasHasta) Then
                           If ShowPregunta(String.Format("El rango ingresado coincide con el rango de {0} ({1} a {2}). ¿Desea agregar igualmente el nuevo rango?",
                                                         r.EtiquetaColumna, r.DiasDesde, r.DiasHasta)) = DialogResult.No Then
                              Return False
                           End If
                        End If
                        If r.Orden = orden Then
                           If ShowPregunta(String.Format("El orden coincide con el orden de {0} ¿Desea insertar en dicha posición el nuevo rango?",
                                                         r.EtiquetaColumna)) = DialogResult.No Then
                              Return False
                           End If
                        End If
                        Return True
                     End Function)
      If Not result Then Return False

      Return True
   End Function

   Private Sub EliminarRango()
      Dim dr = ugRangos.FilaSeleccionada(Of Entidades.CuentaCorrienteAntiguedadSaldoRangos)()
      If dr IsNot Nothing Then
         If ShowPregunta("¿Desea eliminar el rango seleccionado ({0})?", dr.EtiquetaColumna) = DialogResult.Yes Then
            AntiguedadSaldoConfig.Rangos.Remove(dr)
         End If

         RefreshGrillaRangos()
         LimpiaCamposRango()
      End If
   End Sub
   Private Sub SubirRango()
      Dim dr = ugRangos.FilaSeleccionada(Of Entidades.CuentaCorrienteAntiguedadSaldoRangos)()
      If dr IsNot Nothing Then
         Dim anteriorRango = AntiguedadSaldoConfig.Rangos.LastOrDefault(Function(r) r.Orden < dr.Orden)
         If anteriorRango IsNot Nothing Then
            dr.Orden = anteriorRango.Orden
            anteriorRango.Orden += 1
         Else
            dr.Orden = Math.Max(1, dr.Orden - 1)
         End If

         RefreshGrillaRangos()
      End If
   End Sub
   Private Sub BajarRango()
      Dim dr = ugRangos.FilaSeleccionada(Of Entidades.CuentaCorrienteAntiguedadSaldoRangos)()
      If dr IsNot Nothing Then
         Dim siguienteRango = AntiguedadSaldoConfig.Rangos.FirstOrDefault(Function(r) r.Orden > dr.Orden)
         If siguienteRango IsNot Nothing Then
            dr.Orden = siguienteRango.Orden
            siguienteRango.Orden -= 1
         Else
            dr.Orden = dr.Orden + 1
         End If

         RefreshGrillaRangos()
      End If
   End Sub

   Private Sub RefreshGrillaRangos()
      ugRangos.Rows.Refresh(RefreshRow.ReloadData)
      ugRangos.DisplayLayout.Bands(0).SortedColumns.RefreshSort(False)
   End Sub

   Private Sub EditarRangos()
      Dim dr = ugRangos.FilaSeleccionada(Of Entidades.CuentaCorrienteAntiguedadSaldoRangos)()
      If dr IsNot Nothing Then
         txtEtiqueta.Text = dr.EtiquetaColumna
         txtDiasDesde.SetValor(dr.DiasDesde)
         txtDiasHasta.SetValor(dr.DiasHasta)
         txtOrden.SetValor(dr.Orden)

         AntiguedadSaldoConfig.Rangos.Remove(dr)

         RefreshGrillaRangos()
      End If
   End Sub

#End Region

End Class