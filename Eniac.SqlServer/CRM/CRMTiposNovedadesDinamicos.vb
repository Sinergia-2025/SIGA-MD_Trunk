Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class CRMTiposNovedadesDinamicos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CRMTiposNovedadesDinamicos_I(IdTipoNovedad As String,
                                           IdNombreDinamico As String,
                                           EsRequerido As Boolean,
                                           orden As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendFormat("INSERT INTO CRMTiposNovedadesDinamicos ({0}, {1}, {2}, {3})",
                       CRMTipoNovedadDinamico.Columnas.IdTipoNovedad.ToString(),
                       CRMTipoNovedadDinamico.Columnas.IdNombreDinamico.ToString(),
                       CRMTipoNovedadDinamico.Columnas.EsRequerido.ToString(),
                       CRMTipoNovedadDinamico.Columnas.Orden.ToString()).AppendLine()
         .AppendFormat("     VALUES ('{0}', '{1}', {2}, {3})",
                       IdTipoNovedad, IdNombreDinamico, GetStringFromBoolean(EsRequerido), orden)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMTiposNovedadesDinamicos_U(IdTipoNovedad As String,
                                           IdNombreDinamico As String,
                                           EsRequerido As Boolean,
                                           orden As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendLine("UPDATE CRMTiposNovedadesDinamicos ")
         .AppendFormat("   SET {0} = {1}", CRMTipoNovedadDinamico.Columnas.EsRequerido.ToString(), GetStringFromBoolean(EsRequerido)).AppendLine()
         .AppendFormat("     , {0} = {1}", CRMTipoNovedadDinamico.Columnas.Orden.ToString(), orden).AppendLine()
         .AppendFormat(" WHERE {0} = '{1}'", CRMTipoNovedadDinamico.Columnas.IdTipoNovedad.ToString(), IdTipoNovedad)
         .AppendFormat("   AND {0} = '{1}'", CRMTipoNovedadDinamico.Columnas.IdNombreDinamico.ToString(), IdNombreDinamico)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMTiposNovedadesDinamicos_D(IdTipoNovedad As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM CRMTiposNovedadesDinamicos WHERE {0} = '{1}'", CRMTipoNovedadDinamico.Columnas.IdTipoNovedad.ToString(), IdTipoNovedad)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT TND.* FROM CRMTiposNovedadesDinamicos AS TND").AppendLine()
      End With
   End Sub

   Public Function CRMTiposNovedadesDinamicos_GA() As DataTable
      Return CRMTiposNovedadesDinamicos_GA(String.Empty)
   End Function

   Public Function CRMTiposNovedadesDinamicos_GA(IdTipoNovedad As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         If Not String.IsNullOrWhiteSpace(IdTipoNovedad) Then
            .AppendFormat(" WHERE TND.{0} = '{1}'", CRMTipoNovedadDinamico.Columnas.IdTipoNovedad.ToString(), IdTipoNovedad)
         End If
         .AppendFormat(" ORDER BY TND.Orden, TND.IdNombreDinamico")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CRMTiposNovedadesDinamicos_G1(IdTipoNovedad As String, IdNombreDinamico As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE TND.{0} = '{1}'", CRMTipoNovedadDinamico.Columnas.IdTipoNovedad.ToString(), IdTipoNovedad)
         .AppendFormat("   AND TND.{0} = '{1}'", CRMTipoNovedadDinamico.Columnas.IdNombreDinamico.ToString(), IdNombreDinamico)
         .AppendFormat(" ORDER BY TND.Orden, TND.IdNombreDinamico")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      columna = "TND." + columna

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
         .AppendFormat(" ORDER BY TND.Orden, TND.IdNombreDinamico")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
