Imports System.Text

Public Class Actividades
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Actividades_I(ByVal idProvincia As String, _
                            ByVal idActividad As Integer, _
                           ByVal nombreActividad As String, _
                           ByVal porcentaje As Decimal, _
                           ByVal baseImponible As Decimal,
                           ByVal CodigoAfip As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO Actividades (")
         .AppendLine(" IdProvincia, ")
         .AppendLine(" IdActividad, ")
         .AppendLine(" NombreActividad, ")
         .AppendLine(" Porcentaje, ")
         .AppendLine(" BaseImponible,")
         .AppendLine("    CodigoAfip")
         .AppendLine(" ) VALUES (")
         .AppendLine("'" & idProvincia & "', ")
         .AppendLine(idActividad & ", ")
         .AppendLine("'" & nombreActividad & "', ")
         .AppendLine(porcentaje.ToString() & ",")
         .AppendLine(baseImponible.ToString() & ",")
         .AppendLine(CodigoAfip.ToString())

         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Actividades")

   End Sub


   Public Sub Actividades_U(ByVal idProvincia As String, _
                            ByVal idActividad As Integer, _
                           ByVal nombreActividad As String, _
                           ByVal porcentaje As Decimal, _
                           ByVal baseImponible As Decimal,
                           ByVal CodigoAfip As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Actividades SET ")
         .AppendLine(" NombreActividad = '" & nombreActividad & "', ")
         .AppendLine(" Porcentaje = " & porcentaje.ToString() & ",")
         .AppendLine(" BaseImponible = " & baseImponible.ToString() & ",")
         .AppendLine(" CodigoAfip = " & CodigoAfip.ToString())
         .AppendLine("WHERE IdProvincia = '" & idProvincia & "'")
         .AppendLine(" AND IdActividad = " & idActividad)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Actividades")

   End Sub

   Public Sub Actividades_D(ByVal idProvincia As String, _
                            ByVal idActividad As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM Actividades ")
         .AppendLine("WHERE IdProvincia = '" & idProvincia & "'")
         .AppendLine(" AND IdActividad = " & idActividad)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Categorias")

   End Sub

   Public Function Actividades_GA() As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("SELECT  ")
         .AppendLine(" A.IdProvincia, ")
         .AppendLine(" P.NombreProvincia,")
         .AppendLine(" A.IdActividad, ")
         .AppendLine(" A.NombreActividad, ")
         .AppendLine(" A.Porcentaje, ")
         .AppendLine(" A.BaseImponible,")
         .AppendLine(" A.CodigoAfip")
         .AppendLine("FROM Actividades A ")
         .AppendLine(" INNER JOIN Provincias P ON P.IdProvincia = A.IdProvincia")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function Actividades_GPorID(ByVal idProvincia As String, ByVal idActividad As Integer) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("SELECT IdProvincia")
         .Append("      ,IdActividad")
         .Append("      ,NombreActividad")
         .Append("      ,Porcentaje")
         .Append("      ,BaseImponible")
         .AppendLine("  ,CodigoAfip")
         .Append("  FROM Actividades")
         .AppendFormat("  WHERE IdProvincia = '{0}' ", idProvincia)
         .AppendFormat("  AND IdActividad = {0}", idActividad)
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function Actividades_GetIdMaximo(ByVal idProvincia As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine("SELECT MAX(IdActividad) AS maximo ")
         .AppendLine(" FROM Actividades")
         .AppendLine("WHERE IdProvincia = '" & idProvincia & "'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
