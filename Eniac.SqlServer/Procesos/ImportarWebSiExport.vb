Imports Eniac.Entidades

Public Class ImportarWebSiExport
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub


   Public Function GetTodosWClientes() As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT * ")
         .AppendLine("FROM WClientes WC")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetCantidadRegistrosWClientes() As Integer
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT count(*) as Cantidad ")
         .AppendLine("FROM WClientes")
      End With

      Return Int32.Parse(Me.GetDataTable(stb.ToString()).Rows(0)("Cantidad").ToString())

   End Function

   Public Function GetTodosWVentas() As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT * ")
         .AppendLine("FROM WVentas WV ")
         .AppendLine("WHERE WV.FechaProcesado IS null")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetTodosWVentasProductos() As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT * ")
         .AppendLine("FROM WVentasProductos WVP")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetTodosWVentasImpuestos() As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT * ")
         .AppendLine("FROM WVentasImpuestos WVI")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetTodosWVentasTarjetas() As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT * ")
         .AppendLine("FROM WVentasTarjetas WVI")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Sub ActualizoFechasProcesado(guid As String)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE WVentas ")
         .AppendFormatLine("	 SET FechaProcesado =  '{0}' ", ObtenerFecha(DateTime.Now, True, True))
         .AppendFormatLine(" WHERE guid = '{0}'", guid)
      End With
      Execute(query)
   End Sub


End Class
