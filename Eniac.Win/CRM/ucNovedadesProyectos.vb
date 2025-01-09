Option Strict Off
Public Class ucNovedadesProyectos

   Public Property TipoNovedad As Entidades.CRMTipoNovedad

   Private _cargandoCliente As Boolean = False

   Private _idCliente As Long?
   Public Property IdCliente As Long?
      Get
         Return _idCliente
      End Get
      Set(value As Long?)
         _idCliente = value
         Dim dt = New Reglas.Proyectos().GetFiltradoPorCodigo(idProyecto:=Nothing, idCliente:=_idCliente)
         If dt.Rows.Count = 1 Then
            bscCodigoProyecto.PresionarBoton()
         ElseIf TipoNovedad IsNot Nothing AndAlso TipoNovedad.IdTipoNovedad = "TICKETS" AndAlso dt.Rows.Count > 1 Then
            _cargandoCliente = True
            bscCodigoProyecto.PresionarBoton()
            _cargandoCliente = False
         End If
      End Set
   End Property

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscCodigoProyecto_BuscadorClick() Handles bscCodigoProyecto.BuscadorClick
      Dim codigoProyecto As Long? = Nothing
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaProyectos(Me.bscCodigoProyecto)
         Dim oP As Reglas.Proyectos = New Reglas.Proyectos()
         If Me.bscCodigoProyecto.Text.Trim.Length > 0 Then
            codigoProyecto = Long.Parse(Me.bscCodigoProyecto.Text.Trim())
         End If

         Dim dt = oP.GetFiltradoPorCodigo(codigoProyecto, IdCliente)

         If _cargandoCliente AndAlso TipoNovedad IsNot Nothing AndAlso TipoNovedad.IdTipoNovedad = "TICKETS" AndAlso dt.Rows.Count > 1 Then
            Me.bscCodigoProyecto.Datos = {dt.Rows(0)}.CopyToDataTable()
         Else
            Me.bscCodigoProyecto.Datos = dt
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCodigoProyecto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProyecto.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProyectos(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscProyecto_BuscadorClick() Handles bscProyecto.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaProyectos(Me.bscProyecto)
         Dim oP As Reglas.Proyectos = New Reglas.Proyectos()
         Me.bscProyecto.Datos = oP.GetFiltradoPorNombre(Me.bscProyecto.Text.Trim(), IdCliente)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscProyecto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProyecto.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProyectos(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub CargarDatosProyectos(ByVal dr As DataGridViewRow)

      Me.bscCodigoProyecto.Text = dr.Cells("IdProyecto").Value.ToString()
      Me.bscProyecto.Text = dr.Cells("NombreProyecto").Value.ToString().Trim()
      Me.txtEstado.Text = dr.Cells("NombreEstado").Value.ToString().Trim()
      Me.txtPrioridad.Text = dr.Cells("IdPrioridadProyecto").Value.ToString().Trim()
      Me.txtClasificacion.Text = dr.Cells("NombreClasificacion").Value.ToString().Trim()

      OnSelectedChanged(Nothing)

   End Sub

   Public Property IdProyecto() As Integer
      Get
         If Me.bscCodigoProyecto.Selecciono Or Me.bscProyecto.Selecciono Then
            Return Integer.Parse(Me.bscCodigoProyecto.Text.ToString())
         Else
            Return 0
         End If
      End Get
      Set(ByVal value As Integer)
         Try
            If value > 0 Then
               Me.bscCodigoProyecto.Text = value
               Me.bscCodigoProyecto.PresionarBoton()
            Else
               Me.bscCodigoProyecto.Text = String.Empty
               Me.bscCodigoProyecto.Text = String.Empty
            End If
            OnSelectedChanged(Nothing)
         Catch ex As Exception
            Me.bscCodigoProyecto.Text = String.Empty
            Me.bscCodigoProyecto.Text = String.Empty
            OnSelectedChanged(Nothing)
            MessageBox.Show(String.Format("No se pudo recuperar el Proyecto: {0}", ex.Message), FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try
      End Set
   End Property

   Private Sub bscCodigoProyecto_TextChange(sender As Object, e As EventArgs) Handles bscCodigoProyecto.TextChange, bscProyecto.TextChange
      Try
         Me.txtPrioridad.Clear()
         Me.txtClasificacion.Clear()
         Me.txtEstado.Text = String.Empty
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

End Class
