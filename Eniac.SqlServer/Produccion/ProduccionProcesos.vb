Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class ProduccionProcesos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProduccionProcesos_I(idProduccionProceso As Integer,
                                   nombreProduccionProceso As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO ProduccionProcesos ({0}, {1})",
                       ProduccionProceso.Columnas.IdProduccionProceso.ToString(),
                       ProduccionProceso.Columnas.NombreProduccionProceso.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}')",
                       idProduccionProceso, nombreProduccionProceso)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ProduccionProcesos_U(idProduccionProceso As Integer,
                                   nombreProduccionProceso As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE ProduccionProcesos ")
         .AppendFormat("   SET {0} = '{1}'", ProduccionProceso.Columnas.NombreProduccionProceso.ToString(), nombreProduccionProceso).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", ProduccionProceso.Columnas.IdProduccionProceso.ToString(), idProduccionProceso)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ProduccionProcesos_D(idProduccionProceso As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM ProduccionProcesos WHERE {0} = {1}", ProduccionProceso.Columnas.IdProduccionProceso.ToString(), idProduccionProceso)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT PRP.*").AppendLine()
         .AppendFormat("  FROM ProduccionProcesos AS PRP").AppendLine()
      End With
   End Sub

   Public Function ProduccionProcesos_GA() As DataTable
      Return ProduccionProcesos_G(0, String.Empty)
   End Function
   Public Function ProduccionProcesos_G(idProduccionProceso As Integer, nombreProduccionProceso As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If idProduccionProceso <> 0 Then
            .AppendFormat("   AND PRP.IdProduccionProceso = {0}", idProduccionProceso).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(nombreProduccionProceso) Then
            .AppendFormat("   AND PRP.NombreProduccionProceso = '{0}'", nombreProduccionProceso).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ProduccionProcesos_G1(idProduccionProceso As Integer) As DataTable
      Return ProduccionProcesos_G(idProduccionProceso, String.Empty)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      'If columna = "NombreTipoNovedad" Then
      '   columna = "TN." + columna
      'Else
      columna = "PRP." + columna
      'End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(ProduccionProceso.Columnas.IdProduccionProceso.ToString(), "ProduccionProcesos"))
   End Function
End Class