Option Explicit On
Option Strict On

Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class PreciosCostoVenta

    Inherits Eniac.Reglas.Base
#Region "Constructores"

   Public Sub New()
      Me.New(New Eniac.Datos.DataAccess())
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "ProductosSucursales"
      da = accesoDatos
   End Sub

#End Region

   Public Function GetListaCostoVenta(ByVal idSucursal As Int32, ByVal idListaPrecios As Integer, _
                                      ByVal IdMarca As Int32, ByVal IdRubro As Int32, ByVal OrdenarPor As String) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")
      Dim strAnchoIdProducto As String = New Reglas.Publicos().GetAnchoCampo("Productos", "IdProducto").ToString()

      With stbQuery
         .Length = 0
         If Publicos.ProductoCodigoNumerico Then
            .AppendLine("SELECT RIGHT(REPLICATE(' '," & strAnchoIdProducto & ") + P.IdProducto," & strAnchoIdProducto & ") AS IdProducto, ")
         Else
            .AppendLine("SELECT p.idproducto, ")
         End If

         .AppendLine("       p.nombreproducto, ")
         .AppendLine("       p.tamano, ")
         .AppendLine("       p.idunidaddemedida, ")
         .AppendLine("       p.idmarca, ")
         .AppendLine("       p.idrubro, ")
         .AppendLine("       ps.preciofabrica, ")
         .AppendLine("       ps.preciocosto, ")
         .AppendLine("       psp.precioventa, ")
         .AppendLine("       r.nombrerubro, ")
         .AppendLine("       ps.fechaactualizacion, ")
         .AppendLine("       m.nombremarca,")
         .AppendLine("       p.IdTipoImpuesto,")
         .AppendLine("       p.Alicuota")
         .AppendLine(" , Mo.NombreMoneda, P.CodigoDeBarras")

         .Append(" FROM productos p, productossucursales ps, rubros r, marcas m, Monedas Mo  ")

         .AppendLine(", ProductosSucursalesPrecios PSP")

         .AppendLine(" WHERE p.idproducto = ps.idproducto")
         .AppendLine("   AND p.idrubro=r.idrubro")
         .AppendLine("   AND p.idmarca=m.idmarca")
         .AppendLine("   AND P.IdMoneda = Mo.IdMoneda  ")
         .AppendLine("   AND P.Activo = 'True'")

         .AppendLine("   AND PS.IdProducto = PSP.IdProducto")
         .AppendLine("   AND PSP.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND PSP.IdListaPrecios = " & idListaPrecios.ToString())

         .AppendLine("   AND ps.idsucursal = " & idSucursal.ToString())

         If Publicos.ConsultarPreciosOcultarProdNoAfectanStock Then
            .AppendLine(" AND P.AfectaStock = 'True'")
         End If

         'If Not String.IsNullOrEmpty(IdMarca) Then

         If IdMarca > 0 Then
            .AppendLine("   AND p.idmarca = " & IdMarca.ToString())
         End If

         If IdRubro > 0 Then
            .AppendLine("   AND p.idrubro = " & IdRubro.ToString())
         End If

         If OrdenarPor = "CODIGO" Then
            'Sin la "P." para que tome los espacio para el orden numerico.
            .AppendLine("ORDER BY IdProducto")
         Else
            .AppendLine("ORDER BY P.NombreProducto")
         End If
         'Demora bastante mas si le ponemos orden.
         '.Append(" ORDER BY r.nombrerubro, p.nombreproducto")

      End With

      Return Me.DataServer().GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetListaCosto(ByVal idSucursal As Int32, ByVal idListaPrecios As Integer, _
                                     ByVal IdMarca As Int32, 
                                     rubros As Entidades.Rubro(),
                                     subrubros As Entidades.SubRubro(),
                                     subsubrubros As Entidades.SubSubRubro(),
                                       ByVal FechaActualizadoDesde As Date, _
                                  ByVal FechaActualizadoHasta As Date) As DataTable

      Dim ConsultarPreciosOcultarProdNoAfectanStock As Boolean = Publicos.ConsultarPreciosOcultarProdNoAfectanStock

      Return New SqlServer.ProductosSucursales(da).GetListaCosto(idSucursal,
                                                                idListaPrecios,
                                                                IdMarca,
                                                                rubros,
                                                                subrubros,
                                                                subsubrubros,
                                                                FechaActualizadoDesde,
                                                                FechaActualizadoHasta,
                                                                ConsultarPreciosOcultarProdNoAfectanStock)

   End Function
End Class
