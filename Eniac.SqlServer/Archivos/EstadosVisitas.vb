Option Explicit On
Option Strict On

Public Class EstadosVisitas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EstadosVisitas_I(idEstadoVisita As Integer,
                               nombreEstadoVisita As String,
                               admitePedidoSinLineas As Boolean,
                               admintePedidoConLineas As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO EstadosVisitas ({0},{1},{2},{3}) ",
                       Entidades.EstadoVisita.Columnas.IdEstadoVisita.ToString(),
                       Entidades.EstadoVisita.Columnas.NombreEstadoVisita.ToString(),
                       Entidades.EstadoVisita.Columnas.AdmitePedidoSinLineas.ToString(),
                       Entidades.EstadoVisita.Columnas.AdmintePedidoConLineas.ToString())
         .AppendFormat(" VALUES ({0},'{1}',{2},{3})",
                       idEstadoVisita,
                       nombreEstadoVisita,
                       GetStringFromBoolean(admitePedidoSinLineas),
                       GetStringFromBoolean(admintePedidoConLineas))
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub EstadosVisitas_U(idEstadoVisita As Integer,
                               nombreEstadoVisita As String,
                               admitePedidoSinLineas As Boolean,
                               admintePedidoConLineas As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE EstadosVisitas")
         .AppendFormat("   SET {0} = '{1}'", Entidades.EstadoVisita.Columnas.NombreEstadoVisita.ToString(), nombreEstadoVisita)
         .AppendFormat("      ,{0} =  {1} ", Entidades.EstadoVisita.Columnas.AdmitePedidoSinLineas.ToString(), admitePedidoSinLineas)
         .AppendFormat("      ,{0} =  {1} ", Entidades.EstadoVisita.Columnas.AdmintePedidoConLineas.ToString(), admintePedidoConLineas)
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.EstadoVisita.Columnas.IdEstadoVisita.ToString(), idEstadoVisita)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub EstadosVisitas_D(ByVal idEstadoVisita As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM EstadosVisitas ")
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.EstadoVisita.Columnas.IdEstadoVisita.ToString(), idEstadoVisita)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT EV.*")
         .AppendLine("  FROM EstadosVisitas EV ")
      End With
   End Sub

   Public Function EstadosVisitas_GA() As DataTable
      Return EstadosVisitas_GA(Nothing, Nothing)
   End Function

   Public Function EstadosVisitas_GA(admitePedidoSinLineas As Boolean?, admintePedidoConLineas As Boolean?) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE 1 = 1")
         If admitePedidoSinLineas.HasValue Then
            .AppendFormat("   AND EV.{0} = {1}", Entidades.EstadoVisita.Columnas.AdmitePedidoSinLineas.ToString(), GetStringFromBoolean(admitePedidoSinLineas.Value))
         End If
         If admintePedidoConLineas.HasValue Then
            .AppendFormat("   AND EV.{0} = {1}", Entidades.EstadoVisita.Columnas.AdmintePedidoConLineas.ToString(), GetStringFromBoolean(admintePedidoConLineas.Value))
         End If
         .AppendFormat(" ORDER BY EV.{0}", Entidades.EstadoVisita.Columnas.NombreEstadoVisita.ToString())
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function EstadosVisitas_G1(ByVal IdEstadoVisita As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE EV.{0} = {1}", Entidades.EstadoVisita.Columnas.IdEstadoVisita.ToString(), IdEstadoVisita.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder()

      entidad.Columna = "EV." + entidad.Columna

      With stbQuery
         Me.SelectTexto(stbQuery)
         .AppendFormat(" WHERE {0} LIKE '%{1}%'", entidad.Columna, entidad.Valor)
      End With
      Return Me.GetDataTable(stbQuery.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Dim dt As DataTable = GetDataTable("SELECT MAX(IdEstadoVisita) AS MAXIMO FROM EstadosVisitas")
      Dim val As Integer = 0

      If dt.Rows.Count > 0 AndAlso Not String.IsNullOrEmpty(dt.Rows(0)("MAXIMO").ToString()) Then
         val = Integer.Parse(dt.Rows(0)("MAXIMO").ToString())
      End If

      Return val
   End Function

End Class
