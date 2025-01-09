Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class AduanasDestinaciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub AduanasDestinaciones_I(IdDestinacion As String, NombreDestinacion As String, Cuit As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO AduanasDestinaciones ({0}, {1}, {2})",
                       AduanaDestinacion.Columnas.IdDestinacion.ToString(),
                       AduanaDestinacion.Columnas.NombreDestinacion.ToString(),
                       AduanaDestinacion.Columnas.RegimenArancelario.ToString()).AppendLine()
         .AppendFormat("     VALUES ('{0}', '{1}', '{2}')",
                       IdDestinacion, NombreDestinacion, Cuit)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub AduanasDestinaciones_U(IdDestinacion As String, NombreDestinacion As String, Cuit As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE AduanasDestinaciones ")
         .AppendFormat("   SET {0} = '{1}'", AduanaDestinacion.Columnas.NombreDestinacion.ToString(), NombreDestinacion).AppendLine()
         .AppendFormat("     , {0} = '{1}'", AduanaDestinacion.Columnas.RegimenArancelario.ToString(), Cuit).AppendLine()
         .AppendFormat(" WHERE {0} = '{1}'", AduanaDestinacion.Columnas.IdDestinacion.ToString(), IdDestinacion)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub AduanasDestinaciones_D(IdDestinacion As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM AduanasDestinaciones WHERE {0} = '{1}'", AduanaDestinacion.Columnas.IdDestinacion.ToString(), IdDestinacion)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT DET.* FROM AduanasDestinaciones AS DET").AppendLine()
      End With
   End Sub

   Public Function AduanasDestinaciones_GA() As DataTable
      Return AduanasDestinaciones_G(String.Empty, String.Empty, False)
   End Function

   Public Function AduanasDestinaciones_G(idDestinacion As String, nombre As String, idDestinacionParcial As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idDestinacion) Then
            If idDestinacionParcial Then
               .AppendFormat("   AND DET.{0} LIKE '%{1}%'", AduanaDestinacion.Columnas.IdDestinacion.ToString(), idDestinacion)
            Else
               .AppendFormat("   AND DET.{0} = '{1}'", AduanaDestinacion.Columnas.IdDestinacion.ToString(), idDestinacion)
            End If
         End If
         If Not String.IsNullOrWhiteSpace(nombre) Then
            .AppendFormat("   AND DET.{0} LIKE '%{1}%'", AduanaDestinacion.Columnas.NombreDestinacion.ToString(), nombre)
         End If
         .AppendFormat(" ORDER BY DET.NombreDestinacion")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function AduanasDestinaciones_G1(IdDestinacion As String) As DataTable
      Return AduanasDestinaciones_G(IdDestinacion, String.Empty, False)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      columna = "DET." + columna

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(AduanaDestinacion.Columnas.IdDestinacion.ToString(), "AduanasDestinaciones"))
   End Function

End Class
