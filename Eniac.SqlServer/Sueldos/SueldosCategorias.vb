Public Class SueldosCategorias
    Inherits Comunes

    Public Sub New(ByVal da As Eniac.Datos.DataAccess)
        MyBase.New(da)
    End Sub

    Public Sub SueldosCategorias_I(ByVal idCategoria As Integer, _
                             ByVal nombreCategoria As String)
        Dim myQuery As StringBuilder = New StringBuilder("")

        With myQuery
            .Append("INSERT INTO  ")
            .Append("SueldosCategorias  ")
            .Append("(IdCategoria, ")
            .Append("NombreCategoria)  ")
            .Append("VALUES(")
            .Append(idCategoria & ", ")
            .Append("'" & nombreCategoria & "') ")
        End With

        Me.Execute(myQuery.ToString())
        Me.Sincroniza_I(myQuery.ToString(), "SueldosCategorias")
    End Sub

    Public Sub SueldosCategorias_U(ByVal idCategoria As Integer, _
                            ByVal nombreCategoria As String)
        Dim myQuery As StringBuilder = New StringBuilder("")
        With myQuery
            .Append("UPDATE  ")
            .Append("SueldosCategorias  ")
            .Append("SET  ")

            .Append("nombreCategoria = '" & nombreCategoria & "' ")

            .Append("WHERE ")
            .Append("idCategoria = " & idCategoria)
        End With

        Me.Execute(myQuery.ToString())
        Me.Sincroniza_I(myQuery.ToString(), "Categorias")
    End Sub

    Public Sub SueldosCategorias_D(ByVal idCategoria As Integer)
        Dim myQuery As StringBuilder = New StringBuilder("")

        With myQuery
            .Append("DELETE FROM  ")
            .Append("SueldosCategorias  ")
            .Append("WHERE  ")
            .Append("idCategoria = " & idCategoria)
        End With

        Me.Execute(myQuery.ToString())
        Me.Sincroniza_I(myQuery.ToString(), "SueldosCategorias")
    End Sub

    Public Function SueldosCategorias_GA() As DataTable
        Dim myQuery As StringBuilder = New StringBuilder("")
        With myQuery
            .Append("SELECT  ")
            .Append("R.IdCategoria, ")
            .Append("R.NombreCategoria ")
            .Append("FROM SueldosCategorias R ")
            .Append("ORDER BY R.NombreCategoria ")
        End With

        Return Me.GetDataTable(myQuery.ToString())
    End Function

   Public Overloads Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
            .Length = 0
            .Append("select ")
            .Append(" max(IdCategoria) as maximo ")
            .Append(" from  SueldosCategorias")
        End With

        'Para el Importador de Productos (Airoldi y Generico)
        'Dim dt As DataTable = Me.DataServer().GetDataTable(stb.ToString())
        Dim dt As DataTable = Me.GetDataTable(stb.ToString())
        Dim val As Integer = 0

        If dt.Rows.Count > 0 Then
            If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
                val = Integer.Parse(dt.Rows(0)("maximo").ToString())
            End If
        End If

        Return val

    End Function

    Public Function SueldosCategorias_G1(ByVal IdSueldoCategoria As Integer) As DataTable

        Dim myQuery As StringBuilder = New StringBuilder("")
        With myQuery
            .Append("SELECT  ")
            .Append("IdCategoria, ")
            .Append("NombreCategoria ")
            .Append("FROM SueldosCategorias ")
            .AppendFormat("WHERE IdCategoria = '{0}' ", IdSueldoCategoria)
            .Append("ORDER BY IdCategoria ")
        End With

        Return Me.GetDataTable(myQuery.ToString())
    End Function
End Class
