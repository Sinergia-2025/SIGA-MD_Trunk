Imports System.Text

Public Class TiposDeExension
    Inherits Comunes

    Public Sub New(ByVal da As Eniac.Datos.DataAccess)
        MyBase.New(da)
    End Sub

    Public Sub TiposDeExension_I(ByVal IdTipoDeExension As Short, _
                                    ByVal NombreIdTipoDeExension As String, _
                                    ByVal NombreIdTipoDeExensionAbrev As String, _
                                    ByVal Activo As Boolean)

        Dim stb As StringBuilder = New StringBuilder("")

        With stb
            .Length = 0
            .AppendLine("INSERT INTO TiposDeExension")
            .AppendLine("   (IdTipoDeExension")
            .AppendLine("   ,NombreIdTipoDeExension")
            .AppendLine("   ,NombreIdTipoDeExensionAbrev")
            .AppendLine("   ,Activo")
            .AppendLine(" ) VALUES ( ")
            .AppendLine("   " & IdTipoDeExension.ToString())
            .AppendLine("   ,'" & NombreIdTipoDeExension & "'")
            .AppendLine("   ,'" & NombreIdTipoDeExensionAbrev & "'")
            .AppendLine("   ,'" & Activo.ToString() & "'")
            .AppendLine(")")
        End With

        Me.Execute(stb.ToString())
        Me.Sincroniza_I(stb.ToString(), "TiposDeExension")

    End Sub

    Public Sub TiposDeExension_U(ByVal IdTipoDeExension As Short, _
                                    ByVal NombreIdTipoDeExension As String, _
                                    ByVal NombreIdTipoDeExensionAbrev As String, _
                                    ByVal Activo As Boolean)

        Dim stb As StringBuilder = New StringBuilder("")

        With stb
            .Length = 0
            .AppendLine("UPDATE TiposDeExension SET ")
            .AppendLine("   NombreIdTipoDeExension = '" & NombreIdTipoDeExension & "'")
            .AppendLine("   ,NombreIdTipoDeExensionAbrev = '" & NombreIdTipoDeExensionAbrev & "'")
            .AppendLine("   ,Activo = '" & Activo.ToString() & "'")
            .AppendLine(" WHERE IdTipoDeExension = " & IdTipoDeExension.ToString())
        End With

        Me.Execute(stb.ToString())
        Me.Sincroniza_I(stb.ToString(), "TiposDeExension")

    End Sub

    Public Sub TiposDeExension_D(ByVal IdTipoDeExension As Short)

        Dim stb As StringBuilder = New StringBuilder("")

        With stb
            .Length = 0
            .AppendLine("DELETE FROM TiposDeExension")
            .AppendLine(" WHERE IdTipoDeExension = " & IdTipoDeExension.ToString())
        End With

        Me.Execute(stb.ToString())
        Me.Sincroniza_I(stb.ToString(), "TiposDeExension")

    End Sub

    Public Function TiposDeExension_GA() As DataTable

        Dim myQuery As StringBuilder = New StringBuilder("")

        Me.SelectFiltrado(myQuery)

        With myQuery
            .AppendLine(" ORDER BY NombreTipoDeExension")
        End With

        Return Me.GetDataTable(myQuery.ToString())

    End Function

    Public Function TiposDeExension_GA(ByVal SoloActivos As Boolean) As DataTable

        Dim myQuery As StringBuilder = New StringBuilder("")

        Me.SelectFiltrado(myQuery)

        With myQuery
            .AppendLine("  WHERE Activo = '" & SoloActivos.ToString() & "'")
            .AppendLine(" ORDER BY NombreIdTipoDeExension")
        End With

        Return Me.GetDataTable(myQuery.ToString())

    End Function

    Public Function Get1(ByVal IdTipoDeExension As Short) As DataTable

        Dim stbQuery As StringBuilder = New StringBuilder("")

        Me.SelectFiltrado(stbQuery)

        With stbQuery
            .AppendLine("  WHERE TE.IdTipoDeExension = " & IdTipoDeExension.ToString())
        End With

        Return Me.GetDataTable(stbQuery.ToString())

    End Function

    Private Sub SelectFiltrado(ByRef stb As StringBuilder)

        With stb
            .Length = 0
            .AppendLine("SELECT TE.IdTipoDeExension")
            .AppendLine("      ,TE.NombreTipoDeExension")
            .AppendLine("      ,TE.NombreTipoDeExensionAbrev")
            .AppendLine("      ,TE.Activo")
            .AppendLine("  FROM TiposDeExension TE")
        End With

    End Sub
    Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
        columna = "CF." + columna
        'If columna = "CF.IdCategoriaFiscal" Then columna = columna.Replace("CF.", "MaV.")
        'If columna = "CF.NombreCategoriaFiscal" Then columna = columna.Replace("CF.", "MoV.")

        Dim stb As StringBuilder = New StringBuilder("")
        With stb
            Me.SelectFiltrado(stb)
            .AppendLine("  WHERE ")
            .Append(columna)
            .Append(" LIKE '%")
            .Append(valor)
            .Append("%'")
        End With
        Return Me.GetDataTable(stb.ToString())
    End Function
End Class
