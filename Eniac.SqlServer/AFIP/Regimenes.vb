Public Class Regimenes
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Regimenes_I(ByVal IdRegimen As Integer, _
                           ByVal ConceptoRegimen As String, _
                           ByVal ARetenerInscripto As Decimal, _
                           ByVal ARetenerNoInscripto As Decimal, _
                           ByVal MontoAExceder As Decimal, _
                           ByVal ImporteMinimoInscripto As Decimal, _
                           ByVal ImporteMinimoNoInscripto As Decimal, _
                           ByVal IdTipoImpuesto As Entidades.TipoImpuesto.Tipos, _
                           ByVal RetienePorEscala As Boolean, _
                           ByVal MinimoNoImponible As Decimal, _
                           ByVal OrigenBaseImponible As Entidades.Regimen.OrigenBaseImponibleEnum, _
                           ByVal CodigoAfip As Integer)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("INSERT INTO Regimenes")
         .Append("           (IdRegimen")
         .Append("           ,ConceptoRegimen")
         .Append("           ,ARetenerInscripto")
         .Append("           ,ARetenerNoInscripto")
         .Append("           ,MontoAExceder")
         .Append("           ,ImporteMinimoInscripto")
         .Append("           ,ImporteMinimoNoInscripto")
         .Append("           ,IdTipoImpuesto")
         .Append("           ,RetienePorEscala")
         .Append("           ,MinimoNoImponible")
         .Append("           ,OrigenBaseImponible")
         .Append("           ,CodigoAfip")
         .Append("   ) VALUES")
         .AppendFormat("           ({0}", IdRegimen)
         .AppendFormat("           ,'{0}'", ConceptoRegimen)
         .AppendFormat("           ,{0}", ARetenerInscripto)
         .AppendFormat("           ,{0}", ARetenerNoInscripto)
         .AppendFormat("           ,{0}", MontoAExceder)
         .AppendFormat("           ,{0}", ImporteMinimoInscripto)
         .AppendFormat("           ,{0}", ImporteMinimoNoInscripto)
         .AppendFormat("           ,'{0}'", IdTipoImpuesto.ToString())
         .AppendFormat("           ,'{0}'", Me.GetStringFromBoolean(RetienePorEscala))
         .AppendFormat("           ,{0}", MinimoNoImponible)
         .AppendFormat("           ,'{0}'", OrigenBaseImponible.ToString())
         .AppendFormat("           ,{0}", CodigoAfip)
         .AppendLine(")")
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "Regimenes")
   End Sub

   Public Sub Regimenes_U(ByVal IdRegimen As Integer, _
                           ByVal ConceptoRegimen As String, _
                           ByVal ARetenerInscripto As Decimal, _
                           ByVal ARetenerNoInscripto As Decimal, _
                           ByVal MontoAExceder As Decimal, _
                           ByVal ImporteMinimoInscripto As Decimal, _
                           ByVal ImporteMinimoNoInscripto As Decimal, _
                           ByVal IdTipoImpuesto As Entidades.TipoImpuesto.Tipos,
                           ByVal RetienePorEscala As Boolean, _
                           ByVal MinimoNoImponible As Decimal, _
                           ByVal OrigenBaseImponible As Entidades.Regimen.OrigenBaseImponibleEnum,
                           ByVal CodigoAfip As Integer)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("UPDATE Regimenes")
         .Append("   SET ")
         .AppendFormat("      ConceptoRegimen = '{0}'", ConceptoRegimen)
         .AppendFormat("      ,ARetenerInscripto = {0}", ARetenerInscripto)
         .AppendFormat("      ,ARetenerNoInscripto = {0}", ARetenerNoInscripto)
         .AppendFormat("      ,MontoAExceder = {0}", MontoAExceder)
         .AppendFormat("      ,ImporteMinimoInscripto = {0}", ImporteMinimoInscripto)
         .AppendFormat("      ,ImporteMinimoNoInscripto = {0}", ImporteMinimoNoInscripto)
         .AppendFormat("      ,IdTipoImpuesto = '{0}'", IdTipoImpuesto.ToString())
         .AppendFormat("      ,RetienePorEscala = '{0}'", Me.GetStringFromBoolean(RetienePorEscala))
         .AppendFormat("      ,MinimoNoImponible = {0}", MinimoNoImponible)
         .AppendFormat("      ,OrigenBaseImponible = '{0}'", OrigenBaseImponible.ToString())
         .AppendFormat("      ,CodigoAfip = {0}", CodigoAfip)
         .AppendFormat(" WHERE IdRegimen = {0}", IdRegimen)
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "Regimenes")
   End Sub

   Public Sub Regimenes_D(ByVal IdRegimen As Integer)
      Dim stb As StringBuilder = New StringBuilder("")

      With stb

         .Append("DELETE FROM Regimenes")
         .AppendFormat(" WHERE IdRegimen = {0}", IdRegimen)
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "Regimenes")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT R.IdRegimen")
         .Append("      ,R.CodigoAfip")
         .Append("      ,R.ConceptoRegimen")
         .Append("      ,R.ARetenerInscripto")
         .Append("      ,R.ARetenerNoInscripto")
         .Append("      ,R.MontoAExceder")
         .Append("      ,R.MinimoNoImponible")
         .Append("      ,R.ImporteMinimoInscripto")
         .Append("      ,R.ImporteMinimoNoInscripto")
         .Append("      ,R.IdTipoImpuesto")
         .Append("      ,TI.NombreTipoImpuesto")
         .Append("      ,R.RetienePorEscala")
         .Append("      ,R.OrigenBaseImponible")
         .Append("  FROM Regimenes R ")
         .Append("  LEFT JOIN TiposImpuestos TI ON R.IdTipoImpuesto = TI.IdTipoImpuesto ")
      End With
   End Sub

   Public Function Regimenes_GA(idTipoImpuesto As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)

         .AppendLine("  WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idTipoImpuesto) Then
            .AppendFormat("  AND R.{0} = '{1}'", Entidades.Regimen.Columnas.IdTipoImpuesto.ToString(), idTipoImpuesto).AppendLine()
         End If
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Regimenes_G1(ByVal IdRegimen As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE R.IdRegimen = {0}", IdRegimen)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "R." + columna
      If columna = "R.NombreTipoImpuesto" Then columna = "TI.NombreTipoImpuesto"
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine("  WHERE ")
         .Append(columna)
         .Append(" LIKE '%")
         .Append(valor)
         .Append("%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
