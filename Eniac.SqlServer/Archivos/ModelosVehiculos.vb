Public Class ModelosVehiculos
    Inherits Comunes

    Public Sub New(da As Eniac.Datos.DataAccess)
        MyBase.New(da)
    End Sub

   Public Sub ModelosVehiculos_I(IdModeloVehiculo As Integer,
                                 NombreModeloVehiculo As String,
                                 IdMarcaVehiculo As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} ({1}, {2}, {3})",
                             Entidades.ModeloVehiculo.NombreTabla,
                             Entidades.ModeloVehiculo.Columnas.IdModeloVehiculo.ToString(),
                             Entidades.ModeloVehiculo.Columnas.NombreModeloVehiculo.ToString(),
                             Entidades.ModeloVehiculo.Columnas.IdMarcaVehiculo.ToString())
         .AppendFormatLine("     VALUES ({0}, '{1}', {2})",
                             IdModeloVehiculo, NombreModeloVehiculo, IdMarcaVehiculo)
      End With
      Execute(myQuery)
   End Sub

   Public Sub ModelosVehiculos_U(IdModeloVehiculo As Integer,
                                 NombreModeloVehiculo As String,
                                 IdMarcaVehiculo As Integer)
        Dim myQuery = New StringBuilder()
        With myQuery
            .AppendFormat("UPDATE {0}", Entidades.ModeloVehiculo.NombreTabla).AppendLine()
            .AppendFormat("   SET {0} = '{1}'", Entidades.ModeloVehiculo.Columnas.NombreModeloVehiculo.ToString(), NombreModeloVehiculo).AppendLine()
            .AppendFormat("     , {0} =  {1} ", Entidades.ModeloVehiculo.Columnas.IdMarcaVehiculo.ToString(), IdMarcaVehiculo).AppendLine()
            .AppendFormat(" WHERE {0} =  {1} ", Entidades.ModeloVehiculo.Columnas.IdModeloVehiculo.ToString(), IdModeloVehiculo).AppendLine()
        End With
        Execute(myQuery)
    End Sub

    Public Sub ModelosVehiculos_D(IdModeloVehiculo As Integer)
        Dim myQuery As New StringBuilder()
        With myQuery
            .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.ModeloVehiculo.NombreTabla,
                          Entidades.ModeloVehiculo.Columnas.IdModeloVehiculo.ToString(), IdModeloVehiculo)
        End With
        Me.Execute(myQuery.ToString())
    End Sub

    Private Sub SelectTexto(stb As StringBuilder)
        With stb
         .AppendFormat("SELECT MOV.IdModeloVehiculo, MOV.NombreModeloVehiculo, MVH.IdMarcaVehiculo, MVH.NombreMarcaVehiculo FROM {0} AS MOV ", Entidades.ModeloVehiculo.NombreTabla).AppendLine()
         .AppendFormat("       INNER JOIN MarcasVehiculos MVH ON MOV.IdMarcaVehiculo = MVH.IdMarcaVehiculo ", Entidades.ModeloVehiculo.NombreTabla).AppendLine()
      End With
   End Sub

    Public Function ModelosVehiculos_GA() As DataTable
        Return ModelosVehiculos_G(IdModeloVehiculo:=0, NombreModeloVehiculo:=String.Empty, IdMarcaVehiculo:=0)
    End Function

   Public Function ModelosVehiculos_GA(ByVal IdMarcaVehiculo As Integer) As DataTable
      Return ModelosVehiculos_G(IdModeloVehiculo:=0, NombreModeloVehiculo:=String.Empty, IdMarcaVehiculo:=IdMarcaVehiculo)
   End Function

   Private Function ModelosVehiculos_G(IdModeloVehiculo As Integer, NombreModeloVehiculo As String, IdMarcaVehiculo As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If IdModeloVehiculo > 0 Then
            .AppendFormat("   AND MOV.IdModeloVehiculo = {0}", IdModeloVehiculo).AppendLine()
         End If
         If IdMarcaVehiculo > 0 Then
            .AppendFormat("   AND MOV.IdMarcaVehiculo = {0}", IdMarcaVehiculo).AppendLine()
         End If
         .AppendLine(" ORDER BY IdModeloVehiculo")

      End With
      Return Me.GetDataTable(myQuery.ToString())
    End Function

    Public Function ModelosVehiculos_G1(IdModeloVehiculo As Integer) As DataTable
        Return ModelosVehiculos_G(IdModeloVehiculo:=IdModeloVehiculo, NombreModeloVehiculo:=String.Empty, IdMarcaVehiculo:=0)
    End Function

    Public Overloads Function Buscar(columna As String, valor As String) As DataTable

        columna = "MOV." + columna

        Dim stb As StringBuilder = New StringBuilder()
        With stb
            Me.SelectTexto(stb)
            .AppendFormatLine(FormatoBuscar, columna, valor)
        End With
        Return Me.GetDataTable(stb.ToString())
    End Function
    Public Overloads Function GetCodigoMaximo() As Integer
        Return Convert.ToInt32(GetCodigoMaximo(Entidades.ModeloVehiculo.Columnas.IdModeloVehiculo.ToString(), "ModelosVehiculos"))
    End Function
End Class
