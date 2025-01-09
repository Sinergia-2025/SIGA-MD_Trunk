Public Class ContabilidadCuentas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function GetUltimaCuentaNivel(ByVal nivel As Integer) As Long
      Dim stb As StringBuilder = New StringBuilder()
      '2 02 01

      With stb
         .AppendLine("SELECT max(IdCuenta) as siguiente ")
         .AppendLine(" FROM ContabilidadCuentas ")
         .AppendFormat(" WHERE Nivel= {0}", nivel)
      End With

      Dim siguiente As Long = 0
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         If String.IsNullOrEmpty(dt.Rows(0)("siguiente").ToString()) Then
            siguiente = Long.Parse(dt.Rows(0)("siguiente").ToString()) + 1
         End If
      End If

      Return siguiente
   End Function

   Public Sub Cuentas_I(idCuenta As Long,
                        nombreCuenta As String,
                        nivel As Integer,
                        esImputable As Boolean,
                        activa As Boolean,
                        idCuentaPadre As Long,
                        ajustaPorInflacion As Boolean,
                        tipoCuenta As Entidades.ContabilidadCuenta.TipoCuentaContable)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO ContabilidadCuentas")
         .AppendLine("   (IdCuenta")
         .AppendLine("   ,NombreCuenta")
         .AppendLine("   ,Nivel")
         .AppendLine("   ,EsImputable")
         .AppendLine("   ,Activa")
         .AppendLine("   ,IdCuentaPadre")
         .AppendLine("   ,AjustaPorInflacion")
         .AppendLine("   ,TipoCuenta")
         .AppendLine(" ) VALUES ( ")
         .AppendFormatLine("     {0} ", idCuenta)
         .AppendFormatLine("   ,'{0}'", nombreCuenta)
         .AppendFormatLine("   , {0} ", nivel)
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(esImputable))
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(activa))
         .AppendFormatLine("   , {0} ", GetStringFromNumber(idCuentaPadre))
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(ajustaPorInflacion))
         If tipoCuenta = Entidades.ContabilidadCuenta.TipoCuentaContable.NULL Then
            .AppendFormatLine("   ,NULL ")
         Else
            .AppendFormatLine("   ,'{0}'", tipoCuenta.ToString())
         End If
         .AppendLine(")")
      End With
      Me.Execute(stb.ToString())
   End Sub

   Public Sub Cuentas_U(idCuenta As Long,
                        nombreCuenta As String,
                        nivel As Integer,
                        esImputable As Boolean,
                        activa As Boolean,
                        idCuentaPadre As Long,
                        ajustaPorInflacion As Boolean,
                        tipoCuenta As Entidades.ContabilidadCuenta.TipoCuentaContable)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE ContabilidadCuentas ")
         .AppendFormatLine("   SET NombreCuenta = '{0}'", nombreCuenta)
         .AppendFormatLine("      ,Nivel = {0}", nivel)
         .AppendFormatLine("      ,Activa = {0}", GetStringFromBoolean(activa))
         .AppendFormatLine("      ,EsImputable = {0}", GetStringFromBoolean(esImputable))
         .AppendFormatLine("      ,IdCuentaPadre = {0}", GetStringFromNumber(idCuentaPadre))
         .AppendFormatLine("      ,AjustaPorInflacion = {0}", GetStringFromBoolean(ajustaPorInflacion))
         If tipoCuenta = Entidades.ContabilidadCuenta.TipoCuentaContable.NULL Then
            .AppendFormatLine("   ,TipoCuenta = NULL ")
         Else
            .AppendFormatLine("   ,TipoCuenta = '{0}'", tipoCuenta.ToString())
         End If

         .AppendFormatLine(" WHERE IdCuenta = {0}", idCuenta)
      End With
      Me.Execute(stb.ToString())
   End Sub

   Public Sub Cuentas_D(ByVal idCuenta As Long?)

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("DELETE FROM ContabilidadCuentas")
         If idCuenta.HasValue Then
            .AppendLine(" WHERE IdCuenta = " & idCuenta.Value.ToString())
         End If
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub Cuentas_D()
      Cuentas_D(Nothing)
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendLine("SELECT C.* ")
         .AppendLine(" , CC.NombreCuenta NombreCuentaPadre ")
         .AppendLine(" FROM ContabilidadCuentas C")
         .AppendLine(" LEFT JOIN ContabilidadCuentas CC ON CC.IdCuenta = C.IdCuentaPadre")
      End With
   End Sub

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "C." + columna
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Cuentas_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY C.NombreCuenta")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Cuentas_GA_Ids() As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT C.IdCuenta FROM ContabilidadCuentas C")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function Cuentas_GA_PorCodigo() As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY C.IdCuenta")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Cuentas_G1(ByVal idCuenta As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT * ")
         .AppendLine(" FROM ContabilidadCuentas ")
         .AppendFormat(" WHERE IdCuenta={0}", idCuenta)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorCodigoNombre(IdCuenta As Long, NombreCuenta As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(NombreCuenta) Then
            .AppendLine("   AND C.NombreCuenta LIKE '%" & NombreCuenta & "%'")
         End If
         If IdCuenta <> 0 Then
            .AppendLine("   AND C.IdCuenta = " & IdCuenta)
         End If
         .AppendLine(" ORDER BY C.NombreCuenta")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Cuenta_GetIdMaximo(nivel As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .Length = 0
         .AppendLine("SELECT MAX(IdCuenta) AS maximo ")
         .AppendLine(" FROM ContabilidadCuentas")
         .AppendFormat(" WHERE Nivel ={0}", nivel)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   ''' <summary>
   '''  Revisa si la cuenta es padre de alguna cuenta.
   ''' </summary>
   ''' <param name="idCuenta"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function TieneHijosLaCuenta(ByVal idCuenta As Long) As Boolean
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT IdCuenta ")
         .AppendLine(" FROM ContabilidadCuentas ")
         .AppendLine(" Where IdCuentaPadre = " & idCuenta.ToString)
      End With

      Return Me.GetDataTable(stb.ToString()).Rows.Count > 1

   End Function

   ''' <summary>
   ''' para las de nivel 4
   ''' </summary>
   ''' <param name="idCuenta"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function TieneAsientosLaCuenta(ByVal idCuenta As Long) As Boolean
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("SELECT IdCuenta ")
         .AppendLine(" FROM ContabilidadAsientosCuentas ")
         .AppendFormat(" Where IdCuenta= {0}", idCuenta)
      End With

      Return Me.GetDataTable(stb.ToString()).Rows.Count > 1

   End Function

   Public Function GetCuentasXNivel(ByVal nivel As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT C.IdCuenta, C.NombreCuenta ")
         .AppendLine(" FROM ContabilidadCuentas C")
         .AppendFormat(" where Nivel= {0}", nivel)
      End With
      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetCuentasImputables() As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT C.*")
         .AppendLine(" FROM ContabilidadCuentas C")
         .AppendFormat(" where C.EsImputable= 1")
      End With
      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetCuentasImputablesXCodigo(idCuenta As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" where C.EsImputable= 1")
         If idCuenta > 0 Then
            .AppendFormat(" and C.IdCuenta={0}", idCuenta)
         End If
      End With
      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetCuentasImputablesXNombre(nombreCuenta As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" where C.EsImputable= 1")
         .AppendFormat(" and C.NombreCuenta like'%{0}%'", nombreCuenta)
      End With
      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetCuentasXNivelDescripcion(ByVal nivel As Integer, nombreCuenta As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT C.IdCuenta, C.NombreCuenta ")
         .AppendLine(" FROM ContabilidadCuentas C")
         .AppendFormat(" where Nivel= {0}", nivel)
         .AppendFormat(" and C.NombreCuenta like '%{0}%'", nombreCuenta)
      End With
      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetCuentasImputablesXTipo(tipoCuenta As Eniac.Entidades.ContabilidadCuenta.TipoCuentaContable, nombreCuenta As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT C.*, CC.NombreCuenta NombreCuentaPadre ")
         .AppendLine(" FROM ContabilidadCuentas C")
         .AppendLine("  LEFT JOIN ContabilidadCuentas CC ON CC.IdCuenta = C.IdCuentaPadre")
         .AppendLine("    where C.EsImputable= 1  ")
         .AppendFormatLine("    and c.TipoCuenta = '{0}' ", tipoCuenta.ToString())
         .AppendFormatLine(" and C.NombreCuenta like '%{0}%'", nombreCuenta)
      End With
      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetCuentasImputablesXTipo(tipoCuenta As Eniac.Entidades.ContabilidadCuenta.TipoCuentaContable, idCuenta As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT C.*, CC.NombreCuenta NombreCuentaPadre ")
         .AppendLine(" FROM ContabilidadCuentas C")
         .AppendLine("  LEFT JOIN ContabilidadCuentas CC ON CC.IdCuenta = C.IdCuentaPadre")
         .AppendLine("    where C.EsImputable= 1  ")
         .AppendFormatLine("    and c.TipoCuenta = '{0}' ", tipoCuenta.ToString())
         If idCuenta > 0 Then
            .AppendFormat(" and C.IdCuenta={0}", idCuenta)
         End If
      End With
      Return Me.GetDataTable(stb.ToString())

   End Function



End Class
