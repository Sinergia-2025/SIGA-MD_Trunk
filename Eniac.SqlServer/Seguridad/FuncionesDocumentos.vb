Public Class FuncionesDocumentos
   Inherits Comunes

#Region "Constructores"
   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub
#End Region

#Region "Métodos Públicos"

   Public Sub FuncionesDocumentos_I(idFuncion As String,
                                    idTipoLink As String,
                                    orden As Integer,
                                    link As String,
                                    descripcion As String)
      Dim str As StringBuilder = New StringBuilder
      With str
         .AppendFormat("INSERT INTO FuncionesDocumentos(IdFuncion,IdTipoLink,Orden,Link, Descripcion)")
         .AppendFormat("   VALUES (")
         .AppendFormat("'{0}'", idFuncion)
         .AppendFormat(",'{0}'", idTipoLink.ToString())
         .AppendFormat(",{0}", orden)
         .AppendFormat(",'{0}'", link)
         .AppendFormat(",'{0}')", descripcion)

      End With
      Me.Execute(str.ToString())

   End Sub

   Public Sub FuncionesDocumentos_U(idFuncion As String,
                                    idTipoLink As String,
                                    orden As Integer,
                                    link As String,
                                    descripcion As String)
      Dim str As StringBuilder = New StringBuilder()
      With str
         .AppendFormat("UPDATE FuncionesDocumentos SET")
         .AppendFormat(" IdTipoLink = '{0}'", idTipoLink.ToString())
         .AppendFormat(",Link = '{0}'   ", link)
         .AppendFormat(",Descripcion = '{0}'   ", descripcion)

         .AppendFormat(" WHERE ")
         .AppendFormat("   IdFuncion = '{0}'", idFuncion)
         .AppendFormat("AND ")
         .AppendFormat("   Orden = {0}", orden)
      End With
      Me.Execute(str.ToString())

   End Sub

   Public Sub FuncionesDocumentos_D(IdFuncion As String)
      Dim str As StringBuilder = New StringBuilder()
      With str
         .AppendFormat("DELETE FuncionesDocumentos ")

         .AppendFormat(" WHERE ")
         .AppendFormat("   IdFuncion = '{0}'", IdFuncion)
      End With
      Me.Execute(str.ToString())

   End Sub

   Public Function FuncionesDocumentos_GA() As DataTable
      Return FuncionesDocumentos_GA(String.Empty)
   End Function

   Public Function FuncionesDocumentos_GA(IdFuncion As String) As DataTable
      Dim str As StringBuilder = New StringBuilder()
      With str
         Me.SelectTexto(str)
         If Not String.IsNullOrWhiteSpace(IdFuncion) Then
            .AppendFormat(" WHERE FD.{0} = '{1}'", Entidades.FuncionesDocumentos.Columnas.IdFuncion.ToString(), IdFuncion)
         End If
         .AppendFormat(" ORDER BY FD.Orden, FD.IdFuncion")
      End With
      Return Me.GetDataTable(str.ToString())

   End Function

   Public Function FuncionesDocumentos_G1(idFuncion As String, orden As Integer) As DataTable
      Dim str As StringBuilder = New StringBuilder()
      With str
         Me.SelectTexto(str)
         .AppendFormat(" WHERE FD.{0} = '{1}'", Entidades.FuncionesDocumentos.Columnas.IdFuncion.ToString(), idFuncion)
         .AppendFormat("   AND FD.{0} =  {1} ", Entidades.FuncionesDocumentos.Columnas.Orden.ToString(), orden)
         .AppendFormat(" ORDER BY FD.Orden, FD.IdFuncion")
      End With
      Return Me.GetDataTable(str.ToString())

   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "TND." + columna

      Dim str As StringBuilder = New StringBuilder()
      With str
         Me.SelectTexto(str)
         .AppendFormatLine(FormatoBuscar, columna, valor)
         .AppendFormat(" ORDER BY FD.Orden, FD.IdFuncion")
      End With
      Return Me.GetDataTable(str.ToString())

   End Function

#End Region

#Region "Métodos Privados"
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT FD.* FROM FuncionesDocumentos AS FD")
      End With
   End Sub

#End Region

End Class