Public Class TurismoTurnos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TurismoTurnos_I(idTurno As Integer,
                                    nombreTurno As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("INSERT INTO TurismoTurnos ({0}, {1})",
                           Entidades.TurismoTurno.Columnas.IdTurno.ToString(),
                           Entidades.TurismoTurno.Columnas.NombreTurno.ToString())
         .AppendFormatLine("     VALUES ({0}, '{1}'",
                           idTurno, nombreTurno)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TurismoTurnos_U(idTurno As Integer,
                                    nombreTurno As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE TurismoTurnos ")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.TurismoTurno.Columnas.NombreTurno.ToString(), nombreTurno)
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.TurismoTurno.Columnas.IdTurno.ToString(), idTurno)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TurismoTurnos_D(IdTurno As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM TurismoTurnos WHERE {0} = '{1}'", Entidades.TurismoTurno.Columnas.IdTurno.ToString(), IdTurno)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT EN.* ")
         .AppendFormatLine("  FROM TurismoTurnos AS EN")

      End With
   End Sub

   Public Function TurismoTurnos_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" ORDER BY  EN.NombreTurno")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TurismoTurnos_G1(IdTurno As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE EN.{0} = {1}", Entidades.TurismoTurno.Columnas.IdTurno.ToString(), IdTurno)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.TurismoTurno.Columnas.IdTurno.ToString(), "TurismoTurnos"))
   End Function

End Class
