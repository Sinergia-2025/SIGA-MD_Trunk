Public Class ProyectosDetalle

   Private _publicos As Publicos
   Private _estadoOriginal As Integer = 0

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Eniac.Entidades.Proyecto)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Eventos"

   Private Sub chbFechaFinReal_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaFinReal.CheckedChanged
      Try
         Me.dtpFechaFinReal.Enabled = Me.chbFechaFinReal.Checked
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.dtpFechaInicio.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick

      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.dtpFechaInicio.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub nudImporte_ValueChanged(sender As Object, e As EventArgs) Handles nudImporte.ValueChanged
      RecalcularPrioridadPromedio()
   End Sub

   Private Sub nudEstrategico_ValueChanged(sender As Object, e As EventArgs) Handles nudEstrategico.ValueChanged
      RecalcularPrioridadPromedio()
   End Sub

   Private Sub nudComplejidad_ValueChanged(sender As Object, e As EventArgs) Handles nudComplejidad.ValueChanged
      RecalcularPrioridadPromedio()
   End Sub

   Private Sub nudReplicabilidad_ValueChanged(sender As Object, e As EventArgs) Handles nudReplicabilidad.ValueChanged
      RecalcularPrioridadPromedio()
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos()

         Dim rango As Integer = 30
         Me._publicos.CargaComboClasificaciones(Me.cmbClasificacion)

         Me._liSources.Add("Cliente", DirectCast(Me._entidad, Entidades.Proyecto).Cliente)
         Me._liSources.Add("Clasificacion", DirectCast(Me._entidad, Entidades.Proyecto).Clasificacion)

         Me._publicos.CargaComboProyectosEstados(Me.cmbEstado)

         '# Si el proyecto ya tiene seteada una Fecha Real de Fin, tildo el campo en la pantalla
         If _entidad IsNot Nothing AndAlso DirectCast(_entidad, Entidades.Proyecto).FechaFinReal.HasValue Then
            Me.chbFechaFinReal.Checked = True
         End If

         Me.BindearControles(Me._entidad, Me._liSources)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            Me.txtIdProyecto.Text = (New Reglas.Proyectos().GetCodigoMaximo() + 1).ToString()
            'Me.cmbEstado.Text = "Pendiente"
            Me.cmbEstado.SelectedIndex = 0

            RecalcularPrioridadPromedio()

            'esto es fijo por ahora
            DirectCast(Me._entidad, Entidades.Proyecto).FechaInicio = DateTime.Now
            DirectCast(Me._entidad, Entidades.Proyecto).FechaFin = DateTime.Now
            DirectCast(Me._entidad, Entidades.Proyecto).HsRealEstimadas = 0
            DirectCast(Me._entidad, Entidades.Proyecto).Estimado = 0
            DirectCast(Me._entidad, Entidades.Proyecto).HsInformadas = 0
            DirectCast(Me._entidad, Entidades.Proyecto).Presupuestado = 0

         Else

            '# Cargo manualmente los controles Numeric ya que son estándar de .NET y no se pueden bindear
            Me.nudImporte.Value = DirectCast(_entidad, Entidades.Proyecto).IdPrioridadImporte
            Me.nudEstrategico.Value = DirectCast(_entidad, Entidades.Proyecto).IdPrioridadEstrategico
            Me.nudComplejidad.Value = DirectCast(_entidad, Entidades.Proyecto).IdPrioridadComplejidad
            Me.nudReplicabilidad.Value = DirectCast(_entidad, Entidades.Proyecto).IdPrioridadReplicabilidad

            If Not String.IsNullOrEmpty(Me.bscCodigoCliente.Text) Then
               Me.bscCodigoCliente.PresionarBoton()
            End If
            'PosicionOriginal = DirectCast(_entidad, Entidades.CRMCategoriaNovedad).Posicion
         End If

         '# Estado del proyecto
         Me._estadoOriginal = CInt(DirectCast(Me.cmbEstado.SelectedItem, DataRowView).Row("IdEstado"))

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Proyectos()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If Not (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
         Return "ATENCION: Debe Seleccionar un Cliente."
      End If

      '# Si el estado del proyecto corresponde a un estado FINALIZADO, se debe validar que el proyecto no tenga items abiertos sin finalizar
      '# En caso de que tenga items sin finalizar, el proyecto no puede finalizarse
      '# Validar solo si se modifico el estado del proyecto
      Dim row As DataRow = DirectCast(Me.cmbEstado.SelectedItem, DataRowView).Row
      If CInt(row("IdEstado")) <> Me._estadoOriginal Then
         If CBool(row("Finalizado")) Then
            Dim rCRMNovedades As Reglas.CRMNovedades = New Reglas.CRMNovedades
            Dim dt As DataTable = rCRMNovedades.GetCantidadNovedadesPorProyecto(CInt(Me.txtIdProyecto.Text), finalizado:=False)
            Dim msg As StringBuilder = New StringBuilder
            For Each dr As DataRow In dt.Rows
               With msg
                  .AppendFormatLine(String.Format("{0} - Cantidad: {1}",
                                                  dr.Field(Of String)("NombreTipoNovedad"),
                                                  dr.Field(Of Integer)("Cantidad")))
               End With
            Next
            If Not String.IsNullOrEmpty(msg.ToString()) Then Return String.Format("El proyecto {1} tiene novedades sin finalizar por lo que no cerrarse." +
               Environment.NewLine + Environment.NewLine + "{0}", msg.ToString(), Me.txtNombreProyecto.Text)
         End If
      End If

      'Return vacio
      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()

      '# Seteo las prioridades manualmente ya que no se pueden bindear los controles Numeric
      SetPrioridades()

      '# Fecha Fin Real del proyecto
      DirectCast(_entidad, Entidades.Proyecto).FechaFinReal = Me.dtpFechaFinReal.Valor(Me.chbFechaFinReal)

      MyBase.Aceptar()

      If Not Me.HayError And Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.Close()
      End If
   End Sub
#End Region

#Region "Métodos"

   Private Sub RecalcularPrioridadPromedio()
      Me.txtPrioridadPromedio.Text = ((Me.nudImporte.Value + Me.nudEstrategico.Value + Me.nudComplejidad.Value + Me.nudReplicabilidad.Value) / 4).ToString("N2")
   End Sub

   Private Sub SetPrioridades()

      DirectCast(_entidad, Entidades.Proyecto).IdPrioridadImporte = Convert.ToInt32(Me.nudImporte.Value)
      DirectCast(_entidad, Entidades.Proyecto).IdPrioridadEstrategico = Convert.ToInt32(Me.nudEstrategico.Value)
      DirectCast(_entidad, Entidades.Proyecto).IdPrioridadComplejidad = Convert.ToInt32(Me.nudComplejidad.Value)
      DirectCast(_entidad, Entidades.Proyecto).IdPrioridadReplicabilidad = Convert.ToInt32(Me.nudReplicabilidad.Value)

   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      DirectCast(Me._entidad, Entidades.Proyecto).Cliente.NombreCliente = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      DirectCast(Me._entidad, Entidades.Proyecto).Cliente.CodigoCliente = Long.Parse(dr.Cells("CodigoCliente").Value.ToString())
      DirectCast(Me._entidad, Entidades.Proyecto).Cliente.IdCliente = Long.Parse(dr.Cells("IdCliente").Value.ToString())
   End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

    End Sub

#End Region

End Class