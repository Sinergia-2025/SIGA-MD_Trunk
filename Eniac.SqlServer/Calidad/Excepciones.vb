Public Class Excepciones
   Inherits Comunes

#Region "Constructores"

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#End Region

   Public Sub Excepciones_I(IdExcepcion As Integer,
                            IdListaControlTipo As Integer,
                            IdExcepcionTipo As Integer,
                            Motivo As String,
                            FechaExcepcion As DateTime,
                            IdUsuario As String,
                            AccionesCorrectivas As String,
                            Item As String,
                            IdUsuario1 As String,
                            IdUsuario2 As String,
                            IdUsuario3 As String,
                            FechaUsuario1 As DateTime,
                            FechaUsuario2 As DateTime,
                            FechaUsuario3 As DateTime,
                            Dpto As String)

      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO CalidadExcepciones (")
         .AppendFormatLine("  IdExcepcion,")
         .AppendFormatLine("  IdListaControlTipo,")
         .AppendFormatLine("	IdExcepcionTipo,")
         .AppendFormatLine("	Motivo,")
         .AppendFormatLine("	FechaExcepcion,")
         .AppendFormatLine("	IdUsuario,")
         .AppendFormatLine("	AccionesCorrectivas,")
         .AppendFormatLine("	Item,")
         .AppendFormatLine("	IdUsuario1,")
         .AppendFormatLine("	IdUsuario2,")
         .AppendFormatLine("	IdUsuario3,")
         .AppendFormatLine("	FechaUsuario1,")
         .AppendFormatLine("	FechaUsuario2,")
         .AppendFormatLine("	FechaUsuario3,")
         .AppendFormatLine("	Dpto")


         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	{0}", IdExcepcion)
         .AppendFormatLine("	,{0}", IdListaControlTipo)
         .AppendFormatLine("	,{0}", IdExcepcionTipo)
         .AppendFormatLine("	,'{0}'", Motivo)
         .AppendFormatLine("	,'{0}'", FechaExcepcion.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormatLine("	,'{0}'", IdUsuario)
         .AppendFormatLine("	,'{0}'", AccionesCorrectivas)
         .AppendFormatLine("	,'{0}'", Item)
         If String.IsNullOrEmpty(IdUsuario1) Then
            .AppendLine(" ,NULL")
         Else
            .AppendFormatLine("	,'{0}'", IdUsuario1)
         End If
         If String.IsNullOrEmpty(IdUsuario2) Then
            .AppendLine(" ,NULL")
         Else
            .AppendFormatLine("	,'{0}'", IdUsuario2)
         End If
         If String.IsNullOrEmpty(IdUsuario3) Then
            .AppendLine(" ,NULL")
         Else
            .AppendFormatLine("	,'{0}'", IdUsuario3)
         End If
         If FechaUsuario1 = Nothing Then
            .AppendFormat("           ,null")
         Else
            .AppendFormatLine("	,'{0}'", FechaUsuario1.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If FechaUsuario2 = Nothing Then
            .AppendFormat("           ,null")
         Else
            .AppendFormatLine("	,'{0}'", FechaUsuario2.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If FechaUsuario3 = Nothing Then
            .AppendFormat("           ,null")
         Else
            .AppendFormatLine("	,'{0}'", FechaUsuario3.ToString("yyyyMMdd HH:mm:ss"))
         End If
         .AppendFormatLine("	,'{0}'", Dpto)


         .AppendFormatLine(")")
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub Excepciones_U(IdExcepcion As Integer,
                            IdListaControlTipo As Integer,
                            IdExcepcionTipo As Integer,
                            Motivo As String,
                            FechaExcepcion As DateTime,
                            IdUsuario As String,
                            AccionesCorrectivas As String,
                            Item As String,
                            IdUsuario1 As String,
                            IdUsuario2 As String,
                            IdUsuario3 As String,
                            FechaUsuario1 As DateTime,
                            FechaUsuario2 As DateTime,
                            FechaUsuario3 As DateTime,
                            Dpto As String)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE CalidadExcepciones SET")
         .AppendFormatLine("	IdListaControlTipo = {0}", IdListaControlTipo)
         .AppendFormatLine("	,IdExcepcionTipo = {0}", IdExcepcionTipo)
         .AppendFormatLine("	,Motivo = '{0}'", Motivo)
         .AppendFormatLine("	,FechaExcepcion = '{0}'", FechaExcepcion.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormatLine("	,IdUsuario = '{0}'", IdUsuario)
         .AppendFormatLine("	,AccionesCorrectivas = '{0}'", AccionesCorrectivas)
         .AppendFormatLine("	,Item = '{0}'", Item)
         If String.IsNullOrEmpty(IdUsuario1) Then
            .AppendFormatLine("	,IdUsuario1 = NULL")
         Else
            .AppendFormatLine("	,IdUsuario1 = '{0}'", IdUsuario1)
         End If
         If String.IsNullOrEmpty(IdUsuario2) Then
            .AppendFormatLine("	,IdUsuario2 = NULL")
         Else
            .AppendFormatLine("	,IdUsuario2 = '{0}'", IdUsuario2)
         End If
         If String.IsNullOrEmpty(IdUsuario3) Then
            .AppendFormatLine("	,IdUsuario3 = NULL")
         Else
            .AppendFormatLine("	,IdUsuario3 = '{0}'", IdUsuario3)
         End If

         If FechaUsuario1 = Nothing Then
            .AppendFormat("           ,FechaUsuario1 = null")
         Else
            .AppendFormat("           ,FechaUsuario1 = '{0}'", FechaUsuario1.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If FechaUsuario2 = Nothing Then
            .AppendFormat("           ,FechaUsuario2 = null")
         Else
            .AppendFormat("           ,FechaUsuario2 = '{0}'", FechaUsuario2.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If FechaUsuario3 = Nothing Then
            .AppendFormat("           ,FechaUsuario3 = null")
         Else
            .AppendFormat("           ,FechaUsuario3 = '{0}'", FechaUsuario3.ToString("yyyyMMdd HH:mm:ss"))
         End If

         .AppendFormatLine("	,Dpto = '{0}'", Dpto)

         .AppendFormatLine("WHERE IdExcepcion = {0}", IdExcepcion)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub Excepciones_D(IdExcepcion As Integer)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("DELETE CalidadExcepciones WHERE IdExcepcion = {0}", IdExcepcion)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Function Excepciones_GA() As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function Excepciones_GExcepciones(IdListaControlTipo As Integer, IdExcepcionTipo As Integer) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendFormatLine("WHERE 1 = 1")
         If IdListaControlTipo <> 0 Then
            .AppendFormatLine(" AND CE.IdListaControlTipo = {0}", IdListaControlTipo)
         End If
         If IdExcepcionTipo <> 0 Then
            .AppendFormatLine(" AND CE.IdExcepcionTipo = {0}", IdExcepcionTipo)
         End If
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function Excepciones_G1(IdExcepcion As Integer) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendFormatLine("WHERE CE.IdExcepcion = {0}", IdExcepcion)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Sub SelectTexto(query As StringBuilder)
      With query
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("  CE.IdExcepcion,")
         .AppendFormatLine("  CE.IdListaControlTipo,")
         .AppendFormatLine("  CLCT.NombreListaControlTipo,")
         .AppendFormatLine("	CE.IdExcepcionTipo,")
         .AppendFormatLine("  CET.NombreExcepcionTipo,")
         .AppendFormatLine("	CE.Motivo,")
         .AppendFormatLine("	CE.FechaExcepcion,")
         .AppendFormatLine("	CE.IdUsuario,")
         .AppendFormatLine("	CE.AccionesCorrectivas,")
         .AppendFormatLine("	CE.Item,")
         .AppendFormatLine("	CE.IdUsuario1,")
         .AppendFormatLine("	CE.IdUsuario2,")
         .AppendFormatLine("	CE.IdUsuario3,")
         .AppendFormatLine("	CE.FechaUsuario1,")
         .AppendFormatLine("	CE.FechaUsuario2,")
         .AppendFormatLine("	CE.FechaUsuario3,")
         .AppendFormatLine("	CE.Dpto")

         .AppendFormatLine("FROM CalidadExcepciones CE")
         .AppendFormatLine(" INNER JOIN CalidadListasControlTipos CLCT ON CLCT.IdListaControlTipo = CE.IdListaControlTipo
                             INNER JOIN CalidadExcepcionesTipos CET ON CET.IdExcepcionTipo = CE.IdExcepcionTipo")

      End With
   End Sub


   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.Excepcion.Columnas.IdExcepcion.ToString(), Entidades.Excepcion.NombreTabla))
   End Function

End Class
