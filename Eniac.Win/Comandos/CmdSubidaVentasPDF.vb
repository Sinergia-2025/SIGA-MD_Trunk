Public Class CmdSubidaVentasPDF
   Implements Eniac.Win.IComandoMenu

   Private Const Tag As String = "CmdSubidaVentasPDF.Ejecutar"

   Public Sub Ejecutar(owner As IWin32Window, idFuncion As String) Implements IComandoMenu.Ejecutar

      '****************************Configuracion Validada *********************
      Dim servidorFTP As String = Reglas.Publicos.FTPServidorMovil
      Dim usuarioFTP As String = Reglas.Publicos.FTPUsuarioMovil
      Dim claveFTP As String = Reglas.Publicos.FTPPasswordMovil
      Dim conexionPasivaFTP As Boolean = Reglas.Publicos.FTPConexionPasivaMovil
      Dim carpetaRemotaFTP As String = String.Format("{0}", Reglas.Publicos.FTPCarpetaRemotaMovil)
      '************************************************************************

      My.Application.Log.WriteEntry(String.Format("{0} - Inicio subida de Comprobantes de Venta.", Tag), TraceEventType.Verbose)
      Dim ftp As Reglas.IFtp = New Reglas.SimpleFtp(servidorFTP, usuarioFTP, claveFTP)

      '# Buscando la función de exportación de ventas
      My.Application.Log.WriteEntry(String.Format("{0} - Buscando función de Exportación de Ventas", Tag), TraceEventType.Verbose)

      Dim funcion As Entidades.Funcion = New Reglas.Funciones().GetUna("CmdExportacionVentas", False, cargaVinculadas:=False)
      If funcion Is Nothing Then
         My.Application.Log.WriteEntry(String.Format("{0} - No existe la función de exportación de ventas", Tag), TraceEventType.Verbose)
         My.Application.Log.WriteEntry(String.Format("{0} - Finaliza", Tag), TraceEventType.Information)
         Exit Sub
      End If

      '# Una vez obtenida la función de ventas, busco la ubicación de la exportación
      My.Application.Log.WriteEntry(String.Format("{0} - Buscando ubicación de las Exportaciones de Ventas", Tag), TraceEventType.Verbose)

      Dim ubi As String = String.Empty
      For Each p As String In funcion.Parametros.Split(";"c)
         Dim keyValue As String() = p.Split("="c)
         Select Case keyValue(0)
            Case "UbicacionDestino"
               ubi = If(keyValue.Length > 0, keyValue(1).ToString(), String.Empty)
         End Select
      Next
      If ubi IsNot Nothing Then
         If Not IO.Directory.Exists(ubi) Then
            My.Application.Log.WriteEntry(String.Format("{0} - La Ubicación Destino no existe.", Tag), TraceEventType.Verbose)
            My.Application.Log.WriteEntry(String.Format("{0} - Finaliza", Tag), TraceEventType.Information)
            Exit Sub
         End If
      Else
         My.Application.Log.WriteEntry(String.Format("{0} - La Ubicación Destino no se encuentra configurada.", Tag), TraceEventType.Verbose)
         My.Application.Log.WriteEntry(String.Format("{0} - Finaliza", Tag), TraceEventType.Information)
         Exit Sub
      End If

      '# Seteando la ubicación antes de la subida
      My.Application.Log.WriteEntry(String.Format("{0} - Seteando la ubicación antes de la subida.", Tag), TraceEventType.Verbose)
      Dim ubicacion As IO.DirectoryInfo = New IO.DirectoryInfo(ubi)

      Dim count As Integer = 0
      For Each file As IO.FileInfo In ubicacion.GetFiles().Where(Function(x) x.Extension.Contains(".pdf"))
         ftp.UsePassive = conexionPasivaFTP

         '# Subiendo
         My.Application.Log.WriteEntry(String.Format("{0} - Subiendo comprobante {1}.", Tag, file), TraceEventType.Verbose)
         ftp.Upload(file, carpetaRemotaFTP, file.Name.ToLower())

         '# add
         count += 1

         '# Muevo los archivos a una carpeta "Subidos".
         My.Application.Log.WriteEntry(String.Format("{0} - Moviendo comprobante {1} a Subidos.", Tag, file), TraceEventType.Verbose)
         Dim subfolder As String = String.Concat(ubi, "\Subidos")
         If Not IO.Directory.Exists(subfolder) Then
            IO.Directory.CreateDirectory(subfolder)
         End If
         Dim dest As String = String.Concat(subfolder, String.Format("\{0}", file.Name))
         file.MoveTo(dest)
      Next

      If Not count > 0 Then
         My.Application.Log.WriteEntry(String.Format("{0} - No se han encontrado comprobantes para subir.", Tag), TraceEventType.Verbose)
         Exit Sub
      End If

      '# Fin de la subida
      My.Application.Log.WriteEntry(String.Format("{0} - {1} comprobantes subidos correctamente.", Tag, count), TraceEventType.Verbose)
      My.Application.Log.WriteEntry(String.Format("{0} - Fin subida de Comprobantes de Venta.", Tag), TraceEventType.Verbose)
   End Sub
End Class
