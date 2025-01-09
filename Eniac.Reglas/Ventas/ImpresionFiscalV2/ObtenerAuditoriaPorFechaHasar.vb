Imports LibreriaFiscalV2

Namespace FiscalV2
   Public Class ObtenerAuditoriaPorFechaHasar
      Implements IObtenerAuditoriaPorFecha

      Private _controladorFiscal As ControladorFiscal

      Public Sub New(controladorFiscal As ControladorFiscal)
         _controladorFiscal = controladorFiscal
      End Sub

      ''' <summary>
      ''' Extracción por fechas de Auditoria de Fiscal.
      ''' </summary>
      ''' <param name="fechaDesde">Fecha de inicio de extracción</param>
      ''' <param name="fechaHasta">Fecha de fin de extracción</param>
      ''' <param name="archivoSalida">Archivo de salida</param>
      ''' <remarks>Si el archivo de salida no finaliza en zip le concatena dicha extensión.</remarks>
      Public Sub ObtenerAuditoria(fechaDesde As Date, fechaHasta As Date, archivoSalida As String) Implements IObtenerAuditoriaPorFecha.ObtenerAuditoria
         Dim archivoTemp = String.Concat(archivoSalida, ".temp")        'archivo temporal buffer extraccion...
         If Not archivoSalida.EndsWith(".zip") Then
            archivoSalida = String.Concat(archivoSalida, ".zip")        'archivo destino de la descarga...
         End If

         'If IO.File.Exists(ftmp) Then IO.File.Delete(ftmp)
         IO.File.Delete(archivoTemp)

         'inicio descarga de auditoria por fecha (puede ser por fecha por nro. Z
         _controladorFiscal.ObtenerPrimerBloqueAuditoria(fechaDesde, fechaHasta, ControladorFiscal.F2G_TiposDeReporteZ.REPORTE_ZFECHA, True, True)

         If Not _controladorFiscal.HuboErrorFiscal And Not _controladorFiscal.HuboErrorImpresor Then
            Dim pos = _controladorFiscal.Ascii85.Fill_TMP(archivoTemp, _controladorFiscal.Respuesta.Campo(4).ToString())   'pointer para escribir en "ftmp"
            Do
               _controladorFiscal.ObtenerSiguienteBloqueAuditoria()
               If _controladorFiscal.HuboErrorImpresor Or _controladorFiscal.HuboErrorFiscal Then
                  Throw New ExcepcionFiscal("Error extraccion de datos")
               End If
               If _controladorFiscal.Respuesta.Campo(3).ToString() = "0" Then
                  pos = _controladorFiscal.Ascii85.Fill_TMP(archivoTemp, _controladorFiscal.Respuesta.Campo(4).ToString(), pos)
                  Exit Do
               End If
               pos = _controladorFiscal.Ascii85.Fill_TMP(archivoTemp, _controladorFiscal.Respuesta.Campo(4).ToString(), pos)
            Loop

            'Se lee el archivo con ASCII85 con la descarga completa...
            Dim sbuff = My.Computer.FileSystem.ReadAllText(archivoTemp)          'receptor de "ftmp" para decodificar
            'Convierte ASCII85 a binario
            Dim bbuff = _controladorFiscal.Ascii85.Decode(sbuff)                 'buffer binario
            'Se escribe en destino final
            Using ofs = New IO.FileStream(archivoSalida, IO.FileMode.Create)     'stream pra escribir a destino...
               ofs.Write(bbuff, 0, bbuff.Length)
               ofs.Close()
            End Using
         End If
      End Sub
   End Class

End Namespace