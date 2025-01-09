#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class TareasProgramadasDetalle
   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)

   Public ReadOnly Property TareaProgramada As Entidades.TareaProgramada
      Get
         Return DirectCast(_entidad, Entidades.TareaProgramada)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Eniac.Entidades.TareaProgramada)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Public Sub CargaComboDesdeEnum(ByVal combo As Eniac.Controles.ComboBox, enumArray As Array)
      Dim list As List(Of KeyValuePair(Of Object, String)) = New List(Of KeyValuePair(Of Object, String))()
      For Each item As System.Enum In enumArray
         If Publicos.CheckBrowsable(item) Then
            list.Add(New KeyValuePair(Of Object, String)(item, DirectCast(item, DayOfWeek).NombreDiaSemana()))
         End If
      Next

      combo.DataSource = list
      combo.DisplayMember = "Value"
      combo.ValueMember = "Key"
   End Sub

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos()
         CargaComboDesdeEnum(cmbDiaSemana, System.Enum.GetValues(GetType(DayOfWeek)))

         Me.BindearControles(Me._entidad, Me._liSources)

         Me.dtpHoraProgramada.Value = Date.Parse(DateTime.Now.ToString("HH:00"))

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            txtIdTareaProgramada.Text = (DirectCast(GetReglas(), Reglas.TareasProgramadas).GetCodigoMaximo() + 1).ToString()
         Else
            bscCodigoFuncion.Text = TareaProgramada.IdFuncion
            bscCodigoFuncion.PresionarBoton()
         End If

         _tit = GetColumnasVisiblesGrilla(ugDiasSemana)

         ugDiasSemana.DataSource = TareaProgramada.Horarios
         AjustarColumnasGrilla(ugDiasSemana, _tit)

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.TareasProgramadas()
   End Function

   Protected Overrides Sub Aceptar()

      TareaProgramada.IdFuncion = bscCodigoFuncion.Text

      MyBase.Aceptar()

      If Not Me.HayError And Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.Close()
      End If
   End Sub

   Protected Overrides Function ValidarDetalle() As String

      If Integer.Parse("0" & Me.txtIdTareaProgramada.Text) = 0 Then
         Me.txtIdTareaProgramada.Focus()
         Return "El Codigo de Tarea Programada NO puede ser Cero."
      End If


      If Not bscCodigoFuncion.Selecciono And Not bscNombreFuncion.Selecciono Then
         bscCodigoFuncion.Focus()
         Return "Debe seleccionar una Función."
      End If

      Return MyBase.ValidarDetalle()

   End Function

#End Region

#Region "Metodos"

   Private Function ValidarInsertarHorario() As Boolean

      If cmbDiaSemana.SelectedIndex < 0 Then
         ShowMessage("Debe seleccionar un día de semana")
         cmbDiaSemana.Focus()
         Return False
      End If

      Dim DiaSemanaPantalla As DayOfWeek = DirectCast(cmbDiaSemana.SelectedValue, DayOfWeek)
      Dim HoraProgramadaPantalla As DateTime = Today.AddHours(dtpHoraProgramada.Value.Hour).AddMinutes(0)

      Dim HoraProgramadaRegistro As DateTime
      Dim horaRegistro As Integer
      Dim minuRegistro As Integer

      For Each hora As Entidades.TareaProgramadaHorario In TareaProgramada.Horarios
         If DiaSemanaPantalla.Equals(hora.DiaSemana) Then
            horaRegistro = Integer.Parse(hora.HoraProgramada.Split(":"c)(0))
            minuRegistro = Integer.Parse(hora.HoraProgramada.Split(":"c)(1))
            HoraProgramadaRegistro = Today.AddHours(horaRegistro).AddMinutes(minuRegistro)
         End If
      Next

      Return True
   End Function

   Private Sub InsertarHorario()
      Dim horario As Entidades.TareaProgramadaHorario = New Entidades.TareaProgramadaHorario()
      horario.DiaSemana = DirectCast(cmbDiaSemana.SelectedValue, DayOfWeek)
      horario.HoraProgramada = dtpHoraProgramada.Value.ToString("HH:mm")

      TareaProgramada.Horarios.Add(horario)
      ugDiasSemana.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
   End Sub

#End Region

#Region "Eventos"

#Region "Eventos Botones"
   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If ValidarInsertarHorario() Then
            InsertarHorario()
            cmbDiaSemana.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         Dim horario As Entidades.TareaProgramadaHorario = ugDiasSemana.FilaSeleccionada(Of Entidades.TareaProgramadaHorario)()
         If horario IsNot Nothing Then
            TareaProgramada.Horarios.Remove(horario)
            ugDiasSemana.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Eventos KeyDown/KeyPress"
   Private Sub txtIdTareaProgramada_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservacion.KeyDown, txtIdTareaProgramada.KeyDown
      PresionarTab(e)
   End Sub

#End Region

#Region "Eventos Buscadores"
#Region "Función"
   Private Sub bscCodigoFuncion_BuscadorClick() Handles bscCodigoFuncion.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaFunciones2(Me.bscCodigoFuncion)
         Me.bscCodigoFuncion.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(bscCodigoFuncion.Text, String.Empty)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub
   Private Sub bscCodigoFuncion_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoFuncion.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosFuncion(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscNombreFuncion_BuscadorClick() Handles bscNombreFuncion.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaFunciones2(Me.bscNombreFuncion)
         Me.bscNombreFuncion.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(String.Empty, Me.bscNombreFuncion.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscNombreFuncion_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreFuncion.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosFuncion(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub CargarDatosFuncion(ByVal dr As DataGridViewRow)
      Me.bscNombreFuncion.Text = dr.Cells("Nombre").Value.ToString()
      Me.bscCodigoFuncion.Text = dr.Cells("Id").Value.ToString().Trim()
   End Sub
#End Region

#End Region

#End Region

End Class