Public Class CmdExportacionVentas
   Implements Eniac.Win.IComandoMenu
   Implements IConParametros

   Private Const Tag As String = "CmdExportacionVentas.Ejecutar"

   Private _raiz As String
   Private _cantidadDeMesesAExportar As Integer
   Private _exportado As Boolean = False

   Public Sub Ejecutar(owner As IWin32Window, idFuncion As String) Implements IComandoMenu.Ejecutar
      My.Application.Log.WriteEntry(String.Format("{0} - Inicia", Tag), TraceEventType.Information)
      Using frm As ImpresionMasiva = New ImpresionMasiva()
         frm.Show()

         '# Seteando Filtros
         My.Application.Log.WriteEntry(String.Format("{0} - Seteando los filtros antes de realizar la Consulta", Tag), TraceEventType.Verbose)
         frm.dtpDesde.Value = Date.Today.AddMonths(_cantidadDeMesesAExportar * -1)
         My.Application.Log.WriteEntry(String.Format("{0} - Fecha Desde {1} Hasta {2}(Cant. Meses: {3})", Tag,
                                                     frm.dtpDesde.Value.ToString(), frm.dtpHasta.Value.ToString(), _cantidadDeMesesAExportar.ToString()), TraceEventType.Verbose)
         frm.cmbExportado.SelectedValue = Entidades.Publicos.SiNoTodos.NO
         My.Application.Log.WriteEntry(String.Format("{0} - Ventas Exportadas: {1}", Tag, _exportado.ToString()), TraceEventType.Verbose)

         '# Cargando Grilla Detalle
         My.Application.Log.WriteEntry(String.Format("{0} - Antes de frm.CargaGrillaDetalle", Tag), TraceEventType.Verbose)
         frm.CargaGrillaDetalle()

         If Not frm.dgvDetalle.Rows.Count > 0 Then
            My.Application.Log.WriteEntry(String.Format("{0} - No existen ventas para exportar", Tag), TraceEventType.Verbose)
            My.Application.Log.WriteEntry(String.Format("{0} - Finaliza", Tag), TraceEventType.Information)
            Exit Sub
         End If

         '# Marcando todos los registros obtenidos
         My.Application.Log.WriteEntry(String.Format("{0} - Antes de frm.MarcarTodos", Tag), TraceEventType.Verbose)
         frm.chbTodos.Checked = True
         frm.MarcarTodos()

         '# Validando la ubicación destino. Si no existe, la creo
         If Not My.Computer.FileSystem.DirectoryExists(_raiz) Then
            My.Application.Log.WriteEntry(String.Format("{0} - La Ubicación Destino no existe. Creando Ubicación Destino", Tag), TraceEventType.Verbose)
            My.Computer.FileSystem.CreateDirectory(_raiz)
         End If

         '# Exportando
         My.Application.Log.WriteEntry(String.Format("{0} - Antes de frm.Exportar", Tag), TraceEventType.Verbose)
         frm.Cursor = Cursors.WaitCursor
         frm.Exportar(_raiz, silentMode:=True)
         frm.Cursor = Cursors.Default

         frm.Close()
      End Using
      My.Application.Log.WriteEntry(String.Format("{0} - Finaliza", Tag), TraceEventType.Information)

   End Sub

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      If Not String.IsNullOrEmpty(parametros) Then
         Me.SetParametrosDeExportacion(parametros)
      End If
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function

   Private Sub SetParametrosDeExportacion(parametros As String)

      For Each p As String In parametros.Split(";"c)
         Dim keyValue As String() = p.Split("="c)
         Select Case keyValue(0)
            Case ParametrosPermitidos.CantidadMesesAExportar.ToString()
               _cantidadDeMesesAExportar = If(keyValue.Length > 0, CInt(keyValue(1)), 0)
            Case ParametrosPermitidos.Exportado.ToString()
               _exportado = If(keyValue.Length > 0, CBool(keyValue(1)), False)
            Case ParametrosPermitidos.UbicacionDestino.ToString()
               _raiz = If(keyValue.Length > 0, keyValue(1).ToString(), String.Empty)
         End Select
      Next

   End Sub

   '# Parámetros permitidos
   Private Enum ParametrosPermitidos
      UbicacionDestino
      Exportado
      CantidadMesesAExportar
   End Enum

End Class
