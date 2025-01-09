Imports LibreriaFiscalV2

Namespace FiscalV2
   Public Class InformeAFIPEpson
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

            Dim rangoZetas = _controladorFiscal.RangoZetasPorFechas(fechaProcesoDesde, fechaProcesoHasta)

            If Not _controladorFiscal.HuboErrorFiscal AndAlso Not _controladorFiscal.HuboErrorImpresor AndAlso rangoZetas IsNot Nothing Then
               Dim zDesde = rangoZetas.Item1 ' _controladorFiscal.Respuesta.GetCampo(Of Integer)(3)
               Dim zHasta = rangoZetas.Item2 ' _controladorFiscal.Respuesta.GetCampo(Of Integer)(4)

               'FileIO.SpecialDirectories.Desktop, "Hasar", "1"
               Dim archivoSalida = IO.Path.Combine(directorioExportacion,
                                                   String.Format("InformeAFIP_{0:yyyyMMdd}_{1:yyyyMMdd}",
                                                                 fechaProcesoDesde, fechaProcesoHasta))

               Dim nombreArchivoExportado = InformeAFIPInterno(impresora, fechaProcesoDesde, fechaProcesoHasta, New IO.DirectoryInfo(archivoSalida))

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
                                             .NombreArchivo = nombreArchivoExportado.Name
                                          })
                  ' ,
                  '.MD5Archivo = nombreArchivoExportado.CalculateMD5()
               End If

               fechaProcesoDesde = fechaProcesoHasta.AddDays(1)
               fechaCalculoHasta = fechaProcesoDesde
            Else
               fechaCalculoHasta = fechaProcesoHasta.AddDays(1)
            End If

         Loop While Not (fechaProcesoDesde >= fechaHasta Or fechaProcesoHasta >= fechaHasta)

      End Sub

      Public Function InformeAFIPInterno(impresora As Entidades.Impresora, fechaDesde As Date, fechaHasta As Date, directorioExportacion As IO.DirectoryInfo) As IO.DirectoryInfo
         Dim reportes = {
            ControladorFiscal.F2G_TiposDeInforme.REPORTE_AFIP_8010,
            ControladorFiscal.F2G_TiposDeInforme.REPORTE_AFIP_8011,
            ControladorFiscal.F2G_TiposDeInforme.REPORTE_AFIP_8012}

         directorioExportacion.Create()
         'IO.Directory.CreateDirectory(directorioExportacion)

         For Each reporte As ControladorFiscal.F2G_TiposDeInforme In reportes
            _controladorFiscal.ObtenerPrimerBloqueReporteElectronico(fechaDesde, fechaHasta, reporte)

            If (_controladorFiscal.Respuesta.CodigoRetorno = 0) Then
               Dim nombreArchivo = _controladorFiscal.Respuesta.Campo(3).ToString()
               Using sfile = New IO.StreamWriter(IO.Path.Combine(directorioExportacion.FullName, nombreArchivo))
                  Do
                     _controladorFiscal.ObtenerSiguienteBloqueReporteElectronico()
                     sfile.Write(_controladorFiscal.Respuesta.Campo(3).ToString())
                     If _controladorFiscal.Respuesta.Campo(4).ToString().ToUpper() <> "S" Then
                        sfile.Close()
                        Exit Do
                     End If
                  Loop
               End Using

               _controladorFiscal.FinalizarObtencionBloqueReporteElectronico()
            Else
               _controladorFiscal.CancelarObtencionBloqueReporteElectronico()
            End If
         Next

         Return directorioExportacion  ' Nothing
      End Function

      Public Function FechaPrimerZeta() As Date? Implements IInformeAFIP.FechaPrimerZeta
         Dim parFechas = _controladorFiscal.RangoFechasPorZetas(1, 1)

         If parFechas IsNot Nothing Then
            Return parFechas.Item1
         End If

         Return Nothing
      End Function
   End Class

End Namespace