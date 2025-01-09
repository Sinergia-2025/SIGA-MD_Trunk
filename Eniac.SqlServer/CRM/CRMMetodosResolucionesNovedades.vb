Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class CRMMetodosResolucionesNovedades
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CRMMetodosResolucionesNovedades_I(en As Entidades.CRMMetodoResolucionNovedad)
      CRMMetodosResolucionesNovedades_I(en.IdMetodoResolucionNovedad, en.NombreMetodoResolucionNovedad, en.Posicion, en.IdTipoNovedad, en.PorDefecto)
   End Sub
   Public Sub CRMMetodosResolucionesNovedades_I(IdMetodoResolucionNovedad As Integer,
                                                NombreMetodoResolucionNovedad As String,
                                                Posicion As Integer,
                                                idTipoNovedad As String,
                                                PorDefecto As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendFormat("INSERT INTO CRMMetodosResolucionesNovedades ({0}, {1}, {2}, {3}, {4})",
                       CRMMetodoResolucionNovedad.Columnas.IdMetodoResolucionNovedad.ToString(),
                       CRMMetodoResolucionNovedad.Columnas.NombreMetodoResolucionNovedad.ToString(),
                       CRMMetodoResolucionNovedad.Columnas.Posicion.ToString(),
                       CRMMetodoResolucionNovedad.Columnas.IdTipoNovedad.ToString(),
                       CRMMetodoResolucionNovedad.Columnas.PorDefecto.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}', {2}, '{3}', {4})",
                       IdMetodoResolucionNovedad, NombreMetodoResolucionNovedad, Posicion, idTipoNovedad, GetStringFromBoolean(PorDefecto))
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMMetodosResolucionesNovedades_U(ByVal en As Entidades.CRMMetodoResolucionNovedad)
      CRMMetodosResolucionesNovedades_U(en.IdMetodoResolucionNovedad, en.NombreMetodoResolucionNovedad, en.Posicion, en.IdTipoNovedad, en.PorDefecto)
   End Sub
   Public Sub CRMMetodosResolucionesNovedades_U(IdMetodoResolucionNovedad As Integer,
                                                NombreMetodoResolucionNovedad As String,
                                                Posicion As Integer,
                                                idTipoNovedad As String,
                                                PorDefecto As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendLine("UPDATE CRMMetodosResolucionesNovedades ")
         .AppendFormat("   SET {0} = '{1}'", CRMMetodoResolucionNovedad.Columnas.NombreMetodoResolucionNovedad.ToString(), NombreMetodoResolucionNovedad).AppendLine()
         .AppendFormat("     , {0} =  {1} ", CRMMetodoResolucionNovedad.Columnas.Posicion.ToString(), Posicion).AppendLine()
         .AppendFormat("     , {0} = '{1}'", CRMMetodoResolucionNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad).AppendLine()
         .AppendFormat("     , {0} =  {1} ", CRMMetodoResolucionNovedad.Columnas.PorDefecto.ToString(), GetStringFromBoolean(PorDefecto)).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", CRMMetodoResolucionNovedad.Columnas.IdMetodoResolucionNovedad.ToString(), IdMetodoResolucionNovedad)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMMetodosResolucionesNovedades_D(IdMetodoResolucionNovedad As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM CRMMetodosResolucionesNovedades WHERE {0} = '{1}'", CRMMetodoResolucionNovedad.Columnas.IdMetodoResolucionNovedad.ToString(), IdMetodoResolucionNovedad)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT MRN.*, TN.NombreTipoNovedad FROM CRMMetodosResolucionesNovedades AS MRN").AppendLine()
         .AppendFormat("  INNER JOIN CRMTiposNovedades TN ON TN.IdTipoNovedad = MRN.IdTipoNovedad").AppendLine()
      End With
   End Sub

   Public Function CRMMetodosResolucionesNovedades_GA() As DataTable
      Return CRMMetodosResolucionesNovedades_GA(String.Empty, False)
   End Function
   Public Function CRMMetodosResolucionesNovedades_GA(idTipoNovedad As String, ordenarPosicion As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormat(" WHERE MRN.IdTipoNovedad = '{0}'", idTipoNovedad).AppendLine()
         End If
         If ordenarPosicion Then
            .AppendFormat(" ORDER BY TN.NombreTipoNovedad, MRN.Posicion")
         Else
            .AppendFormat(" ORDER BY TN.NombreTipoNovedad, MRN.NombreMetodoResolucionNovedad")
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CRMMetodosResolucionesNovedades_G1(idMetodoResolucionNovedad As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE MRN.{0} = {1}", CRMMetodoResolucionNovedad.Columnas.IdMetodoResolucionNovedad.ToString(), idMetodoResolucionNovedad)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      If columna = "NombreTipoNovedad" Then
         columna = "TN." + columna
      Else
         columna = "MRN." + columna
      End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(CRMMetodoResolucionNovedad.Columnas.IdMetodoResolucionNovedad.ToString(), "CRMMetodosResolucionesNovedades"))
   End Function

   Public Function CRMMetodoResolucionesNovedades_GxCodigo(IdMetodoNovedad As Integer, idTipoNovedad As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE 1=1 ")
         If Not String.IsNullOrEmpty(idTipoNovedad) Then
            .AppendFormat(" and TN.IdTipoNovedad = '{0}'", idTipoNovedad)
         End If
         If IdMetodoNovedad <> 0 Then
            .AppendFormat(" and EN.{0} = {1}", Entidades.CRMMetodoResolucionNovedad.Columnas.IdMetodoResolucionNovedad.ToString(), IdMetodoNovedad)
         End If
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function CRMMetodoResolucionesNovedades_PorNombre(nombreMetodo As String, nombreExacto As Boolean, idTipoNovedad As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE 1=1 ")
         If Not String.IsNullOrEmpty(idTipoNovedad) Then
            .AppendFormat(" and TN.IdTipoNovedad = '{0}'", idTipoNovedad)
         End If
         If nombreExacto Then
            .AppendFormatLine(" and MRN.NombreMetodoResolucionNovedad = '{0}'", nombreMetodo)
         Else
            .AppendFormatLine(" and MRN.NombreMetodoResolucionNovedad LIKE '%{0}%'", nombreMetodo)
         End If
      End With
      Return GetDataTable(stb)
   End Function
End Class
