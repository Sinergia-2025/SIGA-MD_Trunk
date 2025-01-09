Option Strict On
Option Explicit On
Imports Eniac.Entidades

Public Class AreasComunes
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub AreasComunes_I(ByVal areaComun As Entidades.AreaComun)
      AreasComunes_I(areaComun.IdAreaComun, areaComun.NombreAreaComun, areaComun.ParticipaExpensas, areaComun.IdNave, areaComun.IdCliente, areaComun.Superficie, areaComun.Coeficiente)
   End Sub

   Public Sub AreasComunes_I(ByVal idAreaComun As String,
                              ByVal nombreAreaComun As String,
                              ByVal participaExpensas As Boolean,
                              ByVal idNave As Short?,
                              ByVal idCliente As Long?,
                              ByVal superficie As Integer,
                              ByVal coeficiente As Decimal)

      Dim stb As StringBuilder = New StringBuilder("")

      Dim nave As String = "NULL"
      If idNave.HasValue Then
         nave = idNave.Value.ToString()
      End If
      'If idNave > 0 Then
      '    nave = idNave.Value.ToString()
      'End If
      Dim cliente As String = "NULL"
      If idCliente.HasValue Then
         cliente = idCliente.Value.ToString()
      End If

      With stb
         .Length = 0
         .AppendLine("INSERT INTO AreasComunes")
         .AppendFormat("   ({0}, {1}, {2}, {3}, {4}, {5}, {6})", Entidades.AreaComun.Columnas.IdAreaComun, Entidades.AreaComun.Columnas.NombreAreaComun,
                                                               Entidades.AreaComun.Columnas.ParticipaExpensas, Entidades.AreaComun.Columnas.IdNave,
                                                               Entidades.AreaComun.Columnas.IdCliente, Entidades.AreaComun.Columnas.Superficie,
                                                               Entidades.AreaComun.Columnas.Coeficiente).AppendLine()
         .AppendFormat("  VALUES ('{0}', '{1}', {2}, {3}, {4}, {5}, {6}) ",
                          idAreaComun, nombreAreaComun, IIf(participaExpensas, 1, 0), nave, cliente, superficie, coeficiente)
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub AreasComunes_U(ByVal areaComun As Entidades.AreaComun)
      AreasComunes_U(areaComun.IdAreaComun, areaComun.NombreAreaComun, areaComun.ParticipaExpensas, areaComun.IdNave, areaComun.IdCliente, areaComun.Superficie, areaComun.Coeficiente)
   End Sub

   Public Sub AreasComunes_U(ByVal idAreaComun As String,
                               ByVal nombreAreaComun As String,
                               ByVal participaExpensas As Boolean,
                               ByVal idNave As Short?,
                               ByVal idCliente As Long?,
                               ByVal superficie As Integer,
                               ByVal coeficiente As Decimal)

      Dim stb As StringBuilder = New StringBuilder("")
      Dim nave As String = "NULL"
      If idNave.HasValue Then
         nave = idNave.Value.ToString()
      End If
      Dim cliente As String = "NULL"
      If idCliente.HasValue Then
         cliente = idCliente.Value.ToString()
      End If

      With stb
         .Length = 0
         .AppendLine("UPDATE AreasComunes SET ")
         .AppendFormat("       {0} = '{1}',", Entidades.AreaComun.Columnas.NombreAreaComun, nombreAreaComun).AppendLine()
         .AppendFormat("       {0} =  {1}, ", Entidades.AreaComun.Columnas.ParticipaExpensas, IIf(participaExpensas, 1, 0)).AppendLine()
         .AppendFormat("       {0} =  {1}, ", Entidades.AreaComun.Columnas.IdNave, nave).AppendLine()
         .AppendFormat("       {0} =  {1}, ", Entidades.AreaComun.Columnas.IdCliente, cliente).AppendLine()
         .AppendFormat("       {0} =  {1}, ", Entidades.AreaComun.Columnas.Superficie, superficie).AppendLine()
         .AppendFormat("       {0} =  {1}  ", Entidades.AreaComun.Columnas.Coeficiente, coeficiente).AppendLine()
         .AppendFormat(" WHERE {0} = '{1}' ", Entidades.AreaComun.Columnas.IdAreaComun, idAreaComun).AppendLine()
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub AreasComunes_D(ByVal areaComun As Entidades.AreaComun)
      AreasComunes_D(areaComun.IdAreaComun)
   End Sub
   Public Sub AreasComunes_D(ByVal idAreaComun As String)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendFormat("DELETE FROM AreasComunes WHERE {0} = '{1}'", Entidades.AreaComun.Columnas.IdAreaComun, idAreaComun)
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub ActualizaCoeficientes()
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("UPDATE AreasComunes")
         .AppendLine("   SET Coeficiente = Convert(Decimal, AAC.Superficie) / Convert(Decimal, AAC.SuperficieTotal)")
         .AppendLine("             FROM (SELECT AC.IdAreaComun, AC.Superficie, ")
         .AppendLine("                   (SELECT SUM(ACS.Superficie) FROM AreasComunes ACS WHERE AC.ParticipaExpensas = 1) AS SuperficieTotal")
         .AppendLine("             FROM AreasComunes AC")
         .AppendLine("        WHERE AC.ParticipaExpensas = 1) AAC")
         .AppendLine("WHERE AAC.IdAreaComun = AreasComunes.IdAreaComun")
      End With

      Me.Execute(stb.ToString())
   End Sub


   Private Sub SelectTexto(ByVal stb As StringBuilder)
      SelectTexto(stb, "S")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder, tableAlias As String)
      With stb
         .Length = 0
         .AppendFormat("SELECT {0}.{1}, {0}.{2}, {0}.{3}, {0}.{4}, {0}.{8}, {0}.{11}, {5}.{6}, {0}.{7}, {9}.{10}",
                                  tableAlias,
                                  Entidades.AreaComun.Columnas.IdAreaComun,
                                  Entidades.AreaComun.Columnas.NombreAreaComun,
                                  Entidades.AreaComun.Columnas.ParticipaExpensas,
                                  Entidades.AreaComun.Columnas.IdNave,
                                  "N",
                                  Entidades.Nave.Columnas.NombreNave,
                                  Entidades.AreaComun.Columnas.IdCliente,
                                  Entidades.AreaComun.Columnas.Superficie,
                                  "C",
                                  Entidades.Cliente.Columnas.NombreCliente,
                                  Entidades.AreaComun.Columnas.Coeficiente).AppendLine()
         .AppendFormat("  FROM AreasComunes {0}", tableAlias).AppendLine()
         .AppendFormat("  LEFT JOIN Naves {0} ON {0}.{2} = {1}.{3}", "N", tableAlias, Entidades.Nave.Columnas.IdNave, Entidades.AreaComun.Columnas.IdNave)
         .AppendFormat("  LEFT JOIN Clientes {0} ON {0}.{2} = {1}.{3}", "C", tableAlias, Entidades.Cliente.Columnas.IdCliente, Entidades.AreaComun.Columnas.IdCliente)
      End With
   End Sub

   Public Function AreasComunes_GA(esNave As Boolean?) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE 1 = 1")
         If esNave.HasValue Then
            If esNave.Value Then
               .AppendFormat("  AND S.{0} IS NOT NULL", Entidades.AreaComun.Columnas.IdNave)
            Else
               .AppendFormat("  AND S.{0} IS NULL", Entidades.AreaComun.Columnas.IdNave)
            End If

         End If
         .AppendFormat("  ORDER BY S.{0}", Entidades.AreaComun.Columnas.NombreAreaComun)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function AreasComunes_G1(ByVal idAreaComun As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine().AppendFormat(" WHERE S.{0} = '{1}'", Entidades.AreaComun.Columnas.IdAreaComun, idAreaComun)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorNombre(ByVal nombreAreaComun As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine().AppendFormat(" WHERE S.{0} LIKE '%{1}%'", Entidades.AreaComun.Columnas.NombreAreaComun, nombreAreaComun)
         .AppendLine().AppendFormat("  ORDER BY S.{0}", Entidades.AreaComun.Columnas.NombreAreaComun)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      Dim tabla As String = "S."

      If columna.Equals(Entidades.Cliente.Columnas.NombreCliente.ToString()) Then tabla = "C."
      If columna.Equals(Entidades.Nave.Columnas.NombreNave.ToString()) Then tabla = "N."

      columna = tabla + columna
      'If columna = "S.NombreLocalidad" Then columna = columna.Replace("S.", "L.")
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine().AppendFormat("  WHERE {0} LIKE '%{1}%'", columna, valor)
         .AppendLine().AppendFormat("  ORDER BY S.{0}", Entidades.AreaComun.Columnas.NombreAreaComun)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetParaExpensas() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine().AppendFormat(" WHERE S.{0} = 'True'", Entidades.AreaComun.Columnas.ParticipaExpensas)
         .AppendLine().AppendFormat("  ORDER BY S.{0}", Entidades.AreaComun.Columnas.NombreAreaComun)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
