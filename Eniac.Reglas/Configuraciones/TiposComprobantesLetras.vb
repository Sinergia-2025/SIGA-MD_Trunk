

Public Class TiposComprobantesLetras
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "TiposComprobantesLetras"
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "TiposComprobantesLetras"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._I)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._D)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._U)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.TiposComprobantesLetras(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposComprobantesLetras(Me.da).TiposComprobantesLetras_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.TipoComprobanteLetra = DirectCast(entidad, Entidades.TipoComprobanteLetra)

      Dim sql As SqlServer.TiposComprobantesLetras = New SqlServer.TiposComprobantesLetras(Me.da)
      Select Case tipo
         Case TipoSP._I
            sql.TiposComprobantesLetras_I(en.TipoComprobante.IdTipoComprobante, en.Letra, en.ArchivoAImprimir, en.ArchivoAImprimirEmbebido, _
                                          en.NombreImpresora, en.CantidadItemsProductos, en.CantidadItemsObservaciones, en.Imprime, en.CantidadCopias,
                                          en.ArchivoAImprimir2, en.ArchivoAImprimirEmbebido2, en.ArchivoAImprimirComplementario, en.ArchivoAImprimirComplementarioEmbebido,
                                          en.ArchivoAExportar, en.ArchivoAExportarEmbebido, en.IdTipoImpresionFiscalArchivoAImprimir, en.IdTipoImpresionFiscalArchivoAImprimir2,
                                          en.IdTipoImpresionFiscalArchivoAImprimirComplementario, en.IdTipoImpresionFiscalArchivoAExportar,
                                          en.DesplazamientoXArchivoAImprimir, en.DesplazamientoYArchivoAImprimir, en.DesplazamientoXArchivoAImprimir2, en.DesplazamientoYArchivoAImprimir2,
                                          en.DesplazamientoXArchivoAImprimirComplementario, en.DesplazamientoYArchivoAImprimirComplementario, en.DesplazamientoXArchivoAExportar, en.DesplazamientoYArchivoAExportar)
         Case TipoSP._U
            sql.TiposComprobantesLetras_U(en.TipoComprobante.IdTipoComprobante, en.Letra, en.ArchivoAImprimir, en.ArchivoAImprimirEmbebido, _
                                          en.NombreImpresora, en.CantidadItemsProductos, en.CantidadItemsObservaciones, en.Imprime, en.CantidadCopias,
                                          en.ArchivoAImprimir2, en.ArchivoAImprimirEmbebido2, en.ArchivoAImprimirComplementario, en.ArchivoAImprimirComplementarioEmbebido,
                                          en.ArchivoAExportar, en.ArchivoAExportarEmbebido, en.IdTipoImpresionFiscalArchivoAImprimir, en.IdTipoImpresionFiscalArchivoAImprimir2,
                                          en.IdTipoImpresionFiscalArchivoAImprimirComplementario, en.IdTipoImpresionFiscalArchivoAExportar,
                                          en.DesplazamientoXArchivoAImprimir, en.DesplazamientoYArchivoAImprimir, en.DesplazamientoXArchivoAImprimir2, en.DesplazamientoYArchivoAImprimir2,
                                          en.DesplazamientoXArchivoAImprimirComplementario, en.DesplazamientoYArchivoAImprimirComplementario, en.DesplazamientoXArchivoAExportar, en.DesplazamientoYArchivoAExportar)
         Case TipoSP._D
            sql.TiposComprobantesLetras_D(en.TipoComprobante.IdTipoComprobante, en.Letra)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.TipoComprobanteLetra, ByVal dr As DataRow)
      With o
         .TipoComprobante = New Reglas.TiposComprobantes(Me.da).GetUno(dr("idTipoComprobante").ToString())
         .Letra = dr("Letra").ToString()
         If Not String.IsNullOrEmpty(dr("ArchivoAImprimir").ToString()) Then
            .ArchivoAImprimir = dr("ArchivoAImprimir").ToString()
         End If
         If Not String.IsNullOrEmpty(dr("ArchivoAImprimirEmbebido").ToString()) Then
            .ArchivoAImprimirEmbebido = Boolean.Parse(dr("ArchivoAImprimirEmbebido").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("NombreImpresora").ToString()) Then
            .NombreImpresora = dr("NombreImpresora").ToString()
         Else
            .NombreImpresora = ""
         End If
         .CantidadItemsProductos = Integer.Parse(dr("CantidadItemsProductos").ToString())
         .CantidadItemsObservaciones = Integer.Parse(dr("CantidadItemsObservaciones").ToString())
         .Imprime = Boolean.Parse(dr("Imprime").ToString())
         .CantidadCopias = Integer.Parse(dr("CantidadCopias").ToString())

         .ArchivoAImprimir2 = dr(Entidades.TipoComprobanteLetra.Columnas.ArchivoAImprimir2.ToString()).ToString()
         .ArchivoAImprimirEmbebido2 = Boolean.Parse(dr(Entidades.TipoComprobanteLetra.Columnas.ArchivoAImprimirEmbebido2.ToString()).ToString())

         .ArchivoAImprimirComplementario = dr(Entidades.TipoComprobanteLetra.Columnas.ArchivoAImprimirComplementario.ToString()).ToString()
         .ArchivoAImprimirComplementarioEmbebido = Boolean.Parse(dr(Entidades.TipoComprobanteLetra.Columnas.ArchivoAImprimirComplementarioEmbebido.ToString()).ToString())

         .ArchivoAExportar = dr.Field(Of String)(Entidades.TipoComprobanteLetra.Columnas.ArchivoAExportar.ToString())
         .ArchivoAExportarEmbebido = dr.Field(Of Boolean)(Entidades.TipoComprobanteLetra.Columnas.ArchivoAExportarEmbebido.ToString())

         .IdTipoImpresionFiscalArchivoAImprimir = dr.Field(Of Integer)(Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAImprimir.ToString())
         .IdTipoImpresionFiscalArchivoAImprimir2 = dr.Field(Of Integer)(Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAImprimir2.ToString())
         .IdTipoImpresionFiscalArchivoAImprimirComplementario = dr.Field(Of Integer)(Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAImprimirComplementario.ToString())
         .IdTipoImpresionFiscalArchivoAExportar = dr.Field(Of Integer)(Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAExportar.ToString())
         .NombreTipoImpresionFiscalArchivoAImprimir = dr.Field(Of String)(String.Concat(Entidades.TipoImpresionFiscal.Columnas.NombreTipoImpresionFiscal.ToString(), "ArchivoAImprimir"))
         .NombreTipoImpresionFiscalArchivoAImprimir2 = dr.Field(Of String)(String.Concat(Entidades.TipoImpresionFiscal.Columnas.NombreTipoImpresionFiscal.ToString(), "ArchivoAImprimir2"))
         .NombreTipoImpresionFiscalArchivoAImprimirComplementario = dr.Field(Of String)(String.Concat(Entidades.TipoImpresionFiscal.Columnas.NombreTipoImpresionFiscal.ToString(), "ArchivoAImprimirComplementario"))
         .NombreTipoImpresionFiscalArchivoAExportar = dr.Field(Of String)(String.Concat(Entidades.TipoImpresionFiscal.Columnas.NombreTipoImpresionFiscal.ToString(), "ArchivoAExportar"))

         '# Desplazamiento de las impresiones
         .DesplazamientoXArchivoAImprimir = dr.Field(Of Integer)(Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAImprimir.ToString())
         .DesplazamientoYArchivoAImprimir = dr.Field(Of Integer)(Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAImprimir.ToString())
         .DesplazamientoXArchivoAImprimir2 = dr.Field(Of Integer)(Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAImprimir2.ToString())
         .DesplazamientoYArchivoAImprimir2 = dr.Field(Of Integer)(Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAImprimir2.ToString())
         .DesplazamientoXArchivoAImprimirComplementario = dr.Field(Of Integer)(Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAImprimirComplementario.ToString())
         .DesplazamientoYArchivoAImprimirComplementario = dr.Field(Of Integer)(Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAImprimirComplementario.ToString())
         .DesplazamientoXArchivoAExportar = dr.Field(Of Integer)(Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAExportar.ToString())
         .DesplazamientoYArchivoAExportar = dr.Field(Of Integer)(Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAExportar.ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.TipoComprobanteLetra)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.TipoComprobanteLetra
      Dim oLis As List(Of Entidades.TipoComprobanteLetra) = New List(Of Entidades.TipoComprobanteLetra)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.TipoComprobanteLetra()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUno(ByVal idTipoComprobante As String, ByVal letra As String) As Entidades.TipoComprobanteLetra
      Dim sql As SqlServer.TiposComprobantesLetras = New SqlServer.TiposComprobantesLetras(Me.da)
      Dim dt As DataTable = sql.GetUno(idTipoComprobante, letra)
      Dim o As Entidades.TipoComprobanteLetra = New Entidades.TipoComprobanteLetra()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Return New Entidades.TipoComprobanteLetra()
      End If
      Return o
   End Function

#End Region

End Class
