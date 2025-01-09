Imports LibreriaFiscalV2

Namespace FiscalV2
   Public Class InformeAFIPHasar
      Implements IInformeAFIP

      Private _controladorFiscal As ControladorFiscal

      Public Sub New(controladorFiscal As ControladorFiscal)
         _controladorFiscal = controladorFiscal
      End Sub

      Public ReadOnly Property MetodoExportacion As MetodoExportacionInformeAFIP Implements IInformeAFIP.MetodoExportacion
         Get
            Return MetodoExportacionInformeAFIP.PorDirectorio
         End Get
      End Property

      Public Sub InformeAFIP(impresora As Entidades.Impresora, fechaDesde As Date, fechaHasta As Date, directorioExportacion As String) Implements IInformeAFIP.InformeAFIP
         Dim fechaProcesoDesde As Date = fechaDesde
         Dim fechaProcesoHasta As Date
         Dim fechaCalculoHasta As Date = fechaDesde
         Dim rImpresora = New ImpresorasExtracciones()

         Do
            Dim semana = ImpresionFiscalV2Comunes.SemanaFiscal(fechaCalculoHasta)

            fechaProcesoHasta = semana.Item2

            _controladorFiscal.ObtenerRangoZetasPorFechas(fechaProcesoDesde, fechaProcesoHasta)

            If Not _controladorFiscal.HuboErrorFiscal And Not _controladorFiscal.HuboErrorImpresor Then
               Dim zDesde = _controladorFiscal.Respuesta.GetCampo(Of Integer)(3)
               Dim zHasta = _controladorFiscal.Respuesta.GetCampo(Of Integer)(4)

               'FileIO.SpecialDirectories.Desktop, "Hasar", "1"
               Dim archivoSalida = IO.Path.Combine(directorioExportacion,
                                                   String.Format("InformeAFIP_{0:yyyyMMdd}_{1:yyyyMMdd}",
                                                                 fechaProcesoDesde, fechaProcesoHasta))

               Dim nombreArchivoExportado = InformeAFIPInterno(impresora, fechaProcesoDesde, fechaProcesoHasta, New IO.FileInfo(archivoSalida))

               If nombreArchivoExportado IsNot Nothing Then
                  rImpresora.Insertar(New Entidades.ImpresoraExtraccion() With
                                          {
                                             .IdSucursal = impresora.IdSucursal,
                                             .IdImpresora = impresora.IdImpresora,
                                             .ZetaDesde = zDesde,
                                             .ZetaHasta = zHasta,
                                             .FechaExtraccionDesde = fechaProcesoDesde,
                                             .FechaExtraccionHasta = fechaProcesoHasta,
                                             .FechaExtraccion = Date.Now,
                                             .IdUsuarioExtraccion = actual.Nombre,
                                             .NombreArchivo = nombreArchivoExportado.Name,
                                             .MD5Archivo = nombreArchivoExportado.CalculateMD5()
                                          })
               End If

               fechaProcesoDesde = fechaProcesoHasta.AddDays(1)
               fechaCalculoHasta = fechaProcesoDesde
            Else
               fechaCalculoHasta = fechaProcesoHasta.AddDays(1)
            End If

         Loop While fechaProcesoDesde < fechaHasta
      End Sub

      Private Function InformeAFIPInterno(impresora As Entidades.Impresora, fechaDesde As Date, fechaHasta As Date, archivoSalida As IO.FileInfo) As IO.FileInfo

         archivoSalida.Directory.Create()

         Dim archivoTemp = String.Concat(archivoSalida.FullName, ".temp")        'archivo temporal buffer extraccion...
         Dim archivoExportar As String
         If Not archivoSalida.FullName.EndsWith(".zip") Then
            archivoExportar = String.Concat(archivoSalida.FullName, ".zip")        'archivo destino de la descarga...
         Else
            archivoExportar = archivoSalida.FullName
         End If

         'If IO.File.Exists(archivoTemp) Then IO.File.Delete(archivoTemp)
         IO.File.Delete(archivoTemp)

         'inicio descarga de archivos de informe para enviar a AFIP
         'tipos de informes:
         'F2G_TiposDeInforme.REPORTE_AFIP_COMPLETO : formularios F8010/11/12
         'F2G_TiposDeInforme.REPORTE_AFIP_MEMORIA_FISCAL : formularios F8010/11/12
         Dim pf = _controladorFiscal.ObtenerPrimerBloqueReporteElectronico(fechaDesde, fechaHasta, ControladorFiscal.F2G_TiposDeInforme.REPORTE_AFIP_COMPLETO)

         If Not _controladorFiscal.HuboErrorFiscal And Not _controladorFiscal.HuboErrorImpresor Then
            Dim pos = _controladorFiscal.Ascii85.Fill_TMP(archivoTemp, _controladorFiscal.Respuesta.Campo(4).ToString())
            Do
               _controladorFiscal.ObtenerSiguienteBloqueReporteElectronico()
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
            Using ofs = New IO.FileStream(archivoExportar, IO.FileMode.Create)     'stream pra escribir a destino...
               ofs.Write(bbuff, 0, bbuff.Length)
               ofs.Close()
            End Using
            Return New IO.FileInfo(archivoExportar)
         End If
         Return Nothing
      End Function

      Public Function FechaPrimerZeta() As Date? Implements IInformeAFIP.FechaPrimerZeta
         Dim result As Date? = Nothing

         Try
            _controladorFiscal.ObtenerRangoFechasPorZetas(1, 1)

            If Not _controladorFiscal.HuboErrorFiscal And Not _controladorFiscal.HuboErrorImpresor Then
               Dim campo3 = _controladorFiscal.Respuesta.Campo(3).ToString()

               result = Date.ParseExact(campo3, "yyMMdd", Globalization.CultureInfo.InvariantCulture)

            End If
         Catch ex As Exception

         End Try

         Return result
      End Function
   End Class

End Namespace