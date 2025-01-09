Public Class ContabilidadAsientosABM
   Implements IConParametros

   Private _idEstadoAsiento As Integer

   Private WithEvents tsTxtFecha As ToolStripTextBox

   Protected Overrides Sub OnLoad(e As EventArgs)
      TryCatched(
         Sub()
            Dim tsLblFecha As ToolStripItem
            tsLblFecha = New ToolStripLabel()
            tsLblFecha.Text = "Meses"
            tsLblFecha.Name = "tsLblFecha"
            tsLblFecha.Size = New Size(60, 25)
            tstBarra.Items.Insert(8, tsLblFecha)

            tsTxtFecha = New ToolStripTextBox()
            tsTxtFecha.Text = "1"
            tsTxtFecha.Name = "tsTxtFecha"
            tsTxtFecha.Size = New Size(40, 25)
            tstBarra.Items.Insert(9, tsTxtFecha)
         End Sub)

      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            If _idEstadoAsiento <> 0 Then
               Dim estado = New Reglas.ContabilidadEstadosAsientos().GetUno(_idEstadoAsiento, Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
               If estado IsNot Nothing Then
                  Text = String.Format("{0} - {1}", Text, estado.NombreEstadoAsiento)
               End If
            End If
         End Sub)
   End Sub

   Private Sub tsTxtFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles tsTxtFecha.KeyDown
      If e.KeyCode = Keys.Enter Then
         Buscar()
      End If
   End Sub

   Protected Overrides Function Buscar(rg As Reglas.Base, args As Entidades.Buscar) As DataTable
      Dim dt = DirectCast(rg, Reglas.ContabilidadAsientos).Buscar(args, _idEstadoAsiento)
      ContabilidadExportacion.AgregarSubsiAsientoDescr(dt)
      Return dt
   End Function

   Protected Overrides Function GetAll(rg As Reglas.Base) As DataTable
      Dim meses As Integer = 1
      If IsNumeric(tsTxtFecha.Text) Then
         meses = Integer.Parse(tsTxtFecha.Text)
      End If
      Dim dt As DataTable = DirectCast(GetReglas(), Reglas.ContabilidadAsientos).GetAll(meses, _idEstadoAsiento) ''DirectCast(MyBase.GetAll(rg), DataTable)
      ContabilidadExportacion.AgregarSubsiAsientoDescr(dt)
      Return dt
   End Function

   Protected Overrides Function GetDetalle(estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Dim asiento = DirectCast(GetEntidad(), Entidades.ContabilidadAsiento)

         If Not asiento.EsManual Then
            Dim permiteEditarManuales As Boolean = New Eniac.Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "CntbAsientosABM-EditaNoManual")
            If Not permiteEditarManuales Then
               Throw New Exception("No se pueden modificar asiento que no sean manuales.")
            End If
         End If

         Dim frmDetalle As New ContabilidadAsientosDetalle(asiento)
         Return frmDetalle
      End If
      Return New ContabilidadAsientosDetalle(New Entidades.ContabilidadAsiento(True, Entidades.ContabilidadProceso.Procesos.MANUALES).InicializaManual())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ContabilidadAsientos()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      If dgvDatos.ActiveRow Is Nothing Then
         dgvDatos.ActiveRow = dgvDatos.ActiveCell.Row
      End If

      With dgvDatos.ActiveRow
         Dim Asientos = New Reglas.ContabilidadAsientos()
         Return Asientos.GetUna(Integer.Parse(.Cells(Entidades.ContabilidadAsiento.Columnas.IdEjercicio.ToString()).Value.ToString()),
                                Integer.Parse(.Cells(Entidades.ContabilidadAsiento.Columnas.IdPlanCuenta.ToString()).Value.ToString()),
                                Integer.Parse(.Cells(Entidades.ContabilidadAsiento.Columnas.IdAsiento.ToString()).Value.ToString()))
      End With
   End Function
   Protected Overrides Sub Borrar()
      Try
         Dim asiento As Entidades.ContabilidadAsiento = DirectCast(Me.GetEntidad(), Entidades.ContabilidadAsiento)

         If Not asiento.EsManual Then
            Throw New Exception("Solo se pueden eliminar asientos Manuales. Por favor verifique.")
         End If

         MyBase.Borrar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I

         .Columns(Entidades.ContabilidadAsiento.Columnas.IdPlanCuenta.ToString()).OcultoPosicion(hidden:=True, pos)
         .Columns(Entidades.ContabilidadAsiento.Columnas.NombrePlanCuenta.ToString()).FormatearColumna("Plan Cuenta", pos, 90)
         .Columns(Entidades.ContabilidadAsiento.Columnas.IdAsiento.ToString()).FormatearColumna("Asiento", pos, 60, HAlign.Right)
         .Columns(Entidades.ContabilidadAsiento.Columnas.NombreAsiento.ToString()).FormatearColumna("Concepto", pos, 330)
         .Columns(Entidades.ContabilidadAsiento.Columnas.FechaAsiento.ToString()).FormatearColumna("Fecha", pos, 70, HAlign.Center)

         .Columns(Entidades.ContabilidadAsiento.Columnas.IdTipoDoc.ToString()).OcultoPosicion(hidden:=True, pos)
         .Columns(Entidades.ContabilidadAsiento.Columnas.IdEjercicio.ToString()).OcultoPosicion(hidden:=True, pos)
         .Columns(Entidades.ContabilidadAsiento.Columnas.idSucursal.ToString()).OcultoPosicion(hidden:=True, pos)
         .Columns(Entidades.ContabilidadAsiento.Columnas.NombreSucursal.ToString()).FormatearColumna("Sucursal", pos, 90)

         .Columns(Entidades.ContabilidadEstadoAsiento.Columnas.NombreEstadoAsiento.ToString()).FormatearColumna("Estado", pos, 90)
         .Columns(Entidades.ContabilidadAsiento.Columnas.IdEstadoAsiento.ToString()).OcultoPosicion(hidden:=True, pos)

         .Columns(Entidades.ContabilidadAsiento.Columnas.SubsiAsiento.ToString()).OcultoPosicion(hidden:=True, pos)
         .Columns("SubsiAsientoDescr").FormatearColumna("Subsistema", pos, 80)

         .Columns(Entidades.ContabilidadAsiento.Columnas.EsManual.ToString()).FormatearColumna("Manual", pos, 50)
         .Columns(Entidades.ContabilidadAsiento.Columnas.FechaExportacion.ToString()).OcultoPosicion(hidden:=True, pos)
         .Columns(Entidades.ContabilidadAsiento.Columnas.TipoAsiento.ToString()).OcultoPosicion(hidden:=True, pos)

      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.ContabilidadAsiento.Columnas.NombreAsiento.ToString()})

   End Sub

   Private Function ValidarDeleteAsiento(eAsiento As Entidades.ContabilidadAsiento) As Boolean
      Dim oEjercicio = New Reglas.ContabilidadEjercicios()

      Dim codEjeVigente = oEjercicio.GetEjercicioVigente(eAsiento.FechaAsiento)
      Dim idPeriodoActual = oEjercicio.GetPeriodoActual(codEjeVigente, eAsiento.FechaAsiento)

      If oEjercicio.EstaPeriodoCerrado(codEjeVigente, idPeriodoActual) Then
         MessageBox.Show("El asiento que intenta eliminar posee movimientos asociados en el periodo vigente. No se puede eliminar", "Asientos", MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      Else
         Return True
      End If
   End Function

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      For Each paramKV In parametros.Split(";"c)
         Dim param = paramKV.Split("="c)
         If param(0) = "IdEstadoAsiento" And param.Count > 1 Then
            _idEstadoAsiento = param(1).ValorNumericoPorDefecto(0I)
         End If
      Next
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Dim stb = New StringBuilder("Lista separada por ';' de pares clave valor separados por '='").AppendLine().AppendLine()
      stb.AppendFormatLine("IdEstadoAsiento - Estado de los asientos a consutlar - 0")
      Return stb.ToString()
   End Function
End Class