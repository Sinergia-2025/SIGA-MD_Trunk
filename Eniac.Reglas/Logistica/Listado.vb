Public Class Listado
    Inherits Reglas.Base

#Region "Constructores"

    Public Sub New()
        Me.NombreEntidad = "Listado"
        da = New Eniac.Datos.DataAccess()
    End Sub

    Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
        Me.New()
        da = accesoDatos
    End Sub

#End Region



   Public Function GetParaImpresionMasiva(ByVal idSucursal As Integer, _
                                         ByVal fechaDesde As Date, _
                                         ByVal fechaHasta As Date, _
                                         ByVal impreso As Entidades.General.Impreso, _
                                         ByVal TipoDocCliente As String, ByVal NroDocCliente As String, _
                                         ByVal idTipoComprobante As String, _
                                         ByVal letra As String, _
                                         ByVal centroEmisor As Short, _
                                         ByVal nroDesde As Long, _
                                         ByVal nroHasta As Long, _
                                         ByVal IdEstadoComprobante As String, _
                                         ByVal GrabaLibro As String, _
                                         ByVal AfectaCaja As String, _
                                         ByVal IdVendedor As Integer, _
                                         ByVal IdFormasPago As Integer, _
                                         ByVal IdUsuario As String, _
                                         ByVal NumeroReparto As Integer) As DataTable

      Try

         Dim oCategoriaFiscalEmpresa As Eniac.Entidades.CategoriaFiscal = New Eniac.Reglas.CategoriasFiscales(Me.da)._GetUno(Publicos.CategoriaFiscalEmpresa)

         Me.da.OpenConection()

         Dim sql As SqlServer.Listados = New SqlServer.Listados(Me.da)

         Return sql.GetParaImpresionMasiva(idSucursal, _
                                             fechaDesde, _
                                             fechaHasta, _
                                             impreso, _
                                             TipoDocCliente, NroDocCliente, _
                                             idTipoComprobante, _
                                             letra, _
                                             centroEmisor, _
                                             nroDesde, _
                                             nroHasta, _
                                             IdEstadoComprobante, _
                                             oCategoriaFiscalEmpresa.IvaDiscriminado, _
                                             GrabaLibro, _
                                             AfectaCaja, _
                                             IdVendedor,
                                             IdFormasPago, _
                                             IdUsuario,
                                             NumeroReparto)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

End Class
