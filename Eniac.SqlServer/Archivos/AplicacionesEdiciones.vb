Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class AplicacionesEdiciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub AplicacionesEdiciones_I(idEdicion As String,
                                      idAplicacion As String,
                                      nombreEdicion As String)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO AplicacionesEdiciones ({0}, {1}, {2})",
                       AplicacionEdicion.Columnas.IdEdicion.ToString(),
                       AplicacionEdicion.Columnas.IdAplicacion.ToString(),
                       AplicacionEdicion.Columnas.NombreEdicion.ToString()).AppendLine()
         .AppendFormat("     VALUES ('{0}', '{1}', '{2}')",
                       idEdicion, idAplicacion, nombreEdicion)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub AplicacionesEdiciones_U(idEdicion As String,
                                      idAplicacion As String,
                                      nombreEdicion As String)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE AplicacionesEdiciones ")
         .AppendFormat("   SET {0} = '{1}'", AplicacionEdicion.Columnas.NombreEdicion.ToString(), nombreEdicion).AppendLine()
         .AppendFormat(" WHERE {0} = '{1}'", AplicacionEdicion.Columnas.IdEdicion.ToString(), idEdicion)
         .AppendFormat(" AND {0} = '{1}'", AplicacionEdicion.Columnas.IdAplicacion.ToString(), idAplicacion)

      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub AplicacionesEdiciones_D(IdEdicion As String, idAplicacion As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM AplicacionesEdiciones ")
         .AppendFormat(" WHERE {0} = '{1}'", AplicacionEdicion.Columnas.IdEdicion.ToString(), IdEdicion)
         .AppendFormat(" AND {0} = '{1}'", AplicacionEdicion.Columnas.IdAplicacion.ToString(), idAplicacion)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendFormat("SELECT AE.* FROM AplicacionesEdiciones AS AE").AppendLine()
      End With
   End Sub

   Public Function AplicacionesEdiciones_G(idEdicion As String, idAplicacion As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If Not String.IsNullOrEmpty(idEdicion) Then
            .AppendFormat("   AND AE.{0} = '{1}'", AplicacionEdicion.Columnas.IdEdicion.ToString(), idEdicion).AppendLine()
         End If
         If Not String.IsNullOrEmpty(idAplicacion) Then
            .AppendFormat("   AND AE.{0} = '{1}'", AplicacionEdicion.Columnas.IdAplicacion.ToString(), idAplicacion).AppendLine()
         End If
         .AppendFormat(" ORDER BY AE.NombreEdicion")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function AplicacionesEdiciones_GA() As DataTable
      Return AplicacionesEdiciones_G(idEdicion:=String.Empty, idAplicacion:=String.Empty)
   End Function

   Public Function AplicacionesEdiciones_G1(idEdicion As String, idAplicacion As String) As DataTable
      Return AplicacionesEdiciones_G(idEdicion, idAplicacion)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "I." + columna
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE {0} LIKE '%{1}%'", columna, valor).AppendLine()
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   'Public Overloads Function GetCodigoMaximo(ByVal IdAplicacion As String) As Integer
   '   Dim campo As String = Entidades.AplicacionEdicion.Columnas.IdEdicion.ToString()
   '   Dim campo1 As String = Entidades.AplicacionEdicion.Columnas.IdAplicacion.ToString()
   '   Return Convert.ToInt32(GetCodigoMaximo(campo, "AplicacionesEdiciones", String.Format("{0} = '{1}'", campo1, IdAplicacion)))
   'End Function
End Class
