Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class CRMPrioridadesNovedades
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CRMPrioridadesNovedades_I(en As Entidades.CRMPrioridadNovedad)
      CRMPrioridadesNovedades_I(en.IdPrioridadNovedad, en.NombrePrioridadNovedad, en.Posicion, en.IdTipoNovedad, en.PorDefecto)
   End Sub
   Public Sub CRMPrioridadesNovedades_I(IdPrioridadNovedad As Integer,
                                        NombrePrioridadNovedad As String,
                                        Posicion As Integer,
                                        idTipoNovedad As String,
                                        PorDefecto As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendFormat("INSERT INTO CRMPrioridadesNovedades ({0}, {1}, {2}, {3}, {4})",
                       CRMPrioridadNovedad.Columnas.IdPrioridadNovedad.ToString(),
                       CRMPrioridadNovedad.Columnas.NombrePrioridadNovedad.ToString(),
                       CRMPrioridadNovedad.Columnas.Posicion.ToString(),
                       CRMPrioridadNovedad.Columnas.IdTipoNovedad.ToString(),
                       CRMPrioridadNovedad.Columnas.PorDefecto.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}', {2}, '{3}', {4})",
                       IdPrioridadNovedad, NombrePrioridadNovedad, Posicion, idTipoNovedad, GetStringFromBoolean(PorDefecto))
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMPrioridadesNovedades_U(ByVal en As Entidades.CRMPrioridadNovedad)
      CRMPrioridadesNovedades_U(en.IdPrioridadNovedad, en.NombrePrioridadNovedad, en.Posicion, en.IdTipoNovedad, en.PorDefecto)
   End Sub
   Public Sub CRMPrioridadesNovedades_U(IdPrioridadNovedad As Integer,
                                        NombrePrioridadNovedad As String,
                                        Posicion As Integer,
                                        idTipoNovedad As String,
                                        PorDefecto As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendLine("UPDATE CRMPrioridadesNovedades ")
         .AppendFormat("   SET {0} = '{1}'", CRMPrioridadNovedad.Columnas.NombrePrioridadNovedad.ToString(), NombrePrioridadNovedad).AppendLine()
         .AppendFormat("     , {0} =  {1} ", CRMPrioridadNovedad.Columnas.Posicion.ToString(), Posicion).AppendLine()
         .AppendFormat("     , {0} = '{1}'", CRMPrioridadNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad).AppendLine()
         .AppendFormat("     , {0} =  {1} ", CRMPrioridadNovedad.Columnas.PorDefecto.ToString(), GetStringFromBoolean(PorDefecto)).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", CRMPrioridadNovedad.Columnas.IdPrioridadNovedad.ToString(), IdPrioridadNovedad)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMPrioridadesNovedades_D(IdPrioridadNovedad As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM CRMPrioridadesNovedades WHERE {0} = '{1}'", CRMPrioridadNovedad.Columnas.IdPrioridadNovedad.ToString(), IdPrioridadNovedad)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT PN.*, TN.NombreTipoNovedad FROM CRMPrioridadesNovedades AS PN").AppendLine()
         .AppendFormat("  INNER JOIN CRMTiposNovedades TN ON TN.IdTipoNovedad = PN.IdTipoNovedad").AppendLine()
      End With
   End Sub

   Public Function CRMPrioridadesNovedades_GA() As DataTable
      Return CRMPrioridadesNovedades_GA(String.Empty, False)
   End Function
   Public Function CRMPrioridadesNovedades_GA(idTipoNovedad As String, ordenarPosicion As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormat(" WHERE PN.IdTipoNovedad = '{0}'", idTipoNovedad).AppendLine()
         End If
         If ordenarPosicion Then
            .AppendFormat(" ORDER BY TN.NombreTipoNovedad, PN.Posicion")
         Else
            .AppendFormat(" ORDER BY TN.NombreTipoNovedad, PN.NombrePrioridadNovedad")
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CRMPrioridadesNovedades_G1(idPrioridadNovedad As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE PN.{0} = {1}", CRMPrioridadNovedad.Columnas.IdPrioridadNovedad.ToString(), IdPrioridadNovedad)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      If columna = "NombreTipoNovedad" Then
         columna = "TN." + columna
      Else
         columna = "PN." + columna
      End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(CRMPrioridadNovedad.Columnas.IdPrioridadNovedad.ToString(), "CRMPrioridadesNovedades"))
   End Function

End Class
