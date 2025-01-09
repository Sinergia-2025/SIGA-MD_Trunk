Public Class Categorias
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Categorias_I(idCategoria As Integer,
                           nombreCategoria As String,
                           idGrupoCategoria As String,
                           descuentoRecargo As Decimal,
                           idCaja As Integer,
                           idTipoComprobante As String,
                           idCuenta As Long,
                           idInteres As Integer,
                           idCuentaSecundaria As Long,
                           idProducto As String,
                           idInteresCuotas As Integer,
                           requiereRevisionAdministrativa As Boolean,
                           controlaBackup As Boolean,
                           nivelAutorizacion As Short,
                           actualizarAplicacion As Boolean,
                           comisiones As Decimal,
                           perteneceAlComplejo As Boolean,
                           firmaMandato As Boolean,
                           adquiereAcciones As String,
                           pideConyuge As Boolean,
                           tpFisicaDatosAdicionales As Boolean,
                           pideEmbarcacion As String,
                           pagaAlquiler As Boolean,
                           pagaExpensas As Boolean,
                           importaGastosAdmin As Decimal?,
                           adquiereCamas As String,
                           idCategoriaInversionista As Integer?,
                           limiteMesesDeudaBotado As Integer?,
                           backColor As Integer?,
                           foreColor As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO Categorias (")
         .AppendLine("     IdCategoria")
         .AppendLine("   , NombreCategoria")
         .AppendLine("   , IdGrupoCategoria")
         .AppendLine("   , DescuentoRecargo")
         .AppendLine("   , IdCaja")
         .AppendLine("   , IdTipoComprobante")
         .AppendLine("   , IdCuenta")
         .AppendLine("   , IdInteres")
         .AppendLine("   , IdCuentaSecundaria")
         .AppendLine("   , IdProducto")
         .AppendLine("   , IdInteresCuotas")
         .AppendLine("   , RequiereRevisionAdministrativa")
         .AppendLine("   , ControlaBackup")
         .AppendLine("   , NivelAutorizacion")
         .AppendLine("   , ActualizarAplicacion")
         .AppendLine("   , Comisiones")
         'Nuevos campos SiSeN
         .AppendLine("   , C.PerteneceAlComplejo")
         .AppendLine("   , C.FirmaMandato")
         .AppendLine("   , C.AdquiereAcciones")
         .AppendLine("   , C.PideConyuge")
         .AppendLine("   , C.TPFisicaDatosAdicionales")
         .AppendLine("   , C.PideEmbarcacion")
         .AppendLine("   , C.PagaAlquiler")
         .AppendLine("   , C.PagaExpensas")
         .AppendLine("   , C.ImporteGastosAdmin")
         .AppendLine("   , C.AdquiereCamas")
         '------------------------------------------------
         .AppendLine("   , C.IdCategoriaInversionista")
         .AppendLine("   , C.LimiteMesesDeudaBotado")
         .AppendLine("   , C.BackColor")
         .AppendLine("   , C.ForeColor")

         .AppendLine("  ) VALUES (")
         .AppendFormatLine("      {0} ", idCategoria)
         .AppendFormatLine("   , '{0}'", nombreCategoria)
         .AppendFormatLine("   , '{0}'", idGrupoCategoria)
         .AppendFormatLine("   ,  {0} ", descuentoRecargo)
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idCaja))
         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(idTipoComprobante))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idCuenta))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idInteres))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idCuentaSecundaria))
         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(idProducto))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idInteresCuotas))
         .AppendFormatLine("   , '{0}'", GetStringFromBoolean(requiereRevisionAdministrativa))
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(controlaBackup))
         .AppendFormatLine("   ,  {0} ", nivelAutorizacion)
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(actualizarAplicacion))
         .AppendFormatLine("   ,  {0} ", comisiones)
         'NUEVOSCAMPOS SISEN
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(perteneceAlComplejo))
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(firmaMandato))
         .AppendFormatLine("   , '{0}'", If(Not String.IsNullOrEmpty(adquiereAcciones), adquiereAcciones, "N"))            '--REQ-33533.- ---
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(pideConyuge))
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(tpFisicaDatosAdicionales))
         .AppendFormatLine("   , '{0}'", If(Not String.IsNullOrEmpty(pideEmbarcacion), pideEmbarcacion, "N"))
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(pagaAlquiler))
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(pagaExpensas))
         .AppendFormatLine("   ,  {0} ", GetStringFromDecimal(importaGastosAdmin))
         .AppendFormatLine("   , '{0}'", If(Not String.IsNullOrEmpty(adquiereCamas), adquiereCamas, "N"))
         '------------------------
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idCategoriaInversionista))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(limiteMesesDeudaBotado))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(backColor))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(foreColor))

         .AppendLine(")")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Categorias")

   End Sub
   Public Function GetGrupoCategoria() As DataTable
      Dim stb = New StringBuilder()
        With stb
            .AppendLine("SELECT DISTINCT IdGrupoCategoria")
            .AppendLine("    FROM Categorias")
         .AppendLine(" ORDER BY IdGrupoCategoria")
        End With
      Return GetDataTable(stb)
    End Function
   Public Sub Categorias_U(idCategoria As Integer,
                           nombreCategoria As String,
                           idGrupoCategoria As String,
                           descuentoRecargo As Decimal,
                           idCaja As Integer,
                           idTipoComprobante As String,
                           idCuenta As Long,
                           idInteres As Integer,
                           idCuentaSecundaria As Long,
                           idProducto As String,
                           idInteresCuotas As Integer,
                           requiereRevisionAdministrativa As Boolean,
                           controlaBackup As Boolean,
                           nivelAutorizacion As Short,
                           actualizarAplicacion As Boolean,
                           Comisiones As Decimal,
                           perteneceAlComplejo As Boolean,
                           firmaMandato As Boolean,
                           adquiereAcciones As String,
                           pideConyuge As Boolean,
                           TPFisicaDatosAdicionales As Boolean,
                           pideEmbarcacion As String,
                           pagaAlquiler As Boolean,
                           pagaExpensas As Boolean,
                           importaGastosAdmin As Decimal?,
                           adquiereCamas As String,
                           idCategoriaInversionista As Integer?,
                           limiteMesesDeudaBotado As Integer?,
                           backColor As Integer?,
                           foreColor As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE Categorias")
         .AppendFormatLine("   SET NombreCategoria = '{0}'", nombreCategoria)
         .AppendFormatLine("     , IdGrupoCategoria = '{0}'", idGrupoCategoria)
         .AppendFormatLine("     , DescuentoRecargo = {0}", descuentoRecargo)
         .AppendFormatLine("     , IdCaja = {0}", idCaja)
         .AppendFormatLine("     , IdTipoComprobante = {0}", GetStringParaQueryConComillas(idTipoComprobante))
         .AppendFormatLine("     , IdCuenta = {0}", GetStringFromNumber(idCuenta))
         .AppendFormatLine("     , IdInteres = {0}", GetStringFromNumber(idInteres))
         .AppendFormatLine("     , IdCuentaSecundaria = {0}", GetStringFromNumber(idCuentaSecundaria))
         .AppendFormatLine("     , IdProducto = {0}", GetStringParaQueryConComillas(idProducto))
         .AppendFormatLine("     , IdInteresCuotas = {0}", GetStringFromNumber(idInteresCuotas))
         .AppendFormatLine("     , RequiereRevisionAdministrativa = '{0}'", GetStringFromBoolean(requiereRevisionAdministrativa))
         .AppendFormatLine("     , ControlaBackup = {0}", GetStringFromBoolean(controlaBackup))
         .AppendFormatLine("     , NivelAutorizacion = {0}", nivelAutorizacion)
         .AppendFormatLine("     , ActualizarAplicacion = {0}", GetStringFromBoolean(actualizarAplicacion))
         .AppendFormatLine("     , Comisiones = {0}", Comisiones)
         'nuevos campos Sisen
         .AppendFormatLine("     , {0} = {1}", Entidades.Categoria.Columnas.PerteneceAlComplejo.ToString(), GetStringFromBoolean(perteneceAlComplejo))
         .AppendFormatLine("     , {0} = {1}", Entidades.Categoria.Columnas.FirmaMandato.ToString(), GetStringFromBoolean(firmaMandato))
         .AppendFormatLine("     , AdquiereAcciones = '{0}'", If(Not String.IsNullOrEmpty(adquiereAcciones), adquiereAcciones, "N"))         '--REQ-33533.- ---
         .AppendFormatLine("     , {0} = {1}", Entidades.Categoria.Columnas.PideConyuge.ToString(), GetStringFromBoolean(pideConyuge))
         .AppendFormatLine("     , {0} = {1}", Entidades.Categoria.Columnas.TPFisicaDatosAdicionales.ToString(), GetStringFromBoolean(TPFisicaDatosAdicionales))
         .AppendFormatLine("     , PideEmbarcacion = '{0}'", If(Not String.IsNullOrEmpty(pideEmbarcacion), pideEmbarcacion, "N"))
         .AppendFormatLine("     , {0} = {1}", Entidades.Categoria.Columnas.PagaAlquiler.ToString(), GetStringFromBoolean(pagaAlquiler))
         .AppendFormatLine("     , {0} = {1}", Entidades.Categoria.Columnas.PagaExpensas.ToString(), GetStringFromBoolean(pagaExpensas))
         .AppendFormatLine("     , {0} = {1}", Entidades.Categoria.Columnas.ImporteGastosAdmin.ToString(), GetStringFromDecimal(importaGastosAdmin))
         .AppendFormatLine("     , AdquiereCamas = '{0}'", If(Not String.IsNullOrEmpty(adquiereCamas), adquiereCamas, "N"))
         .AppendFormatLine("     , IdCategoriaInversionista = {0}", GetStringFromNumber(idCategoriaInversionista))
         .AppendFormatLine("     , LimiteMesesDeudaBotado = {0}", GetStringFromNumber(limiteMesesDeudaBotado))
         .AppendFormatLine("     , BackColor = {0}", GetStringFromNumber(backColor))
         .AppendFormatLine("     , ForeColor = {0}", GetStringFromNumber(foreColor))
         .AppendFormatLine(" WHERE idCategoria = {0}", idCategoria)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Categorias")
   End Sub

   Public Sub Categorias_D(idCategoria As Integer)
      Dim myQuery = New StringBuilder()
        With myQuery
         .AppendFormatLine("DELETE FROM Categorias ")
            .AppendFormatLine(" WHERE idCategoria = {0}", idCategoria)
        End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Categorias")
    End Sub

    Private Sub SelectTexto(stb As StringBuilder)
        With stb
            .AppendLine("SELECT C.IdCategoria")
            .AppendLine("      ,C.NombreCategoria")
            .AppendLine("      ,C.IdGrupoCategoria")
            .AppendLine("      ,C.DescuentoRecargo")
            .AppendLine("      ,C.IdCaja")
            .AppendLine("      ,CN.NombreCaja")
            .AppendLine("      ,C.IdTipoComprobante")
            .AppendLine("      ,C.IdCuenta")
            .AppendLine("      ,CC.NombreCuenta")
            .AppendLine("      ,C.IdInteres")
            .AppendLine("      ,I.NombreInteres")
            .AppendLine("      ,C.IdCuentaSecundaria")
            .AppendLine("      ,CC2.NombreCuenta AS NombreCuentaSecundaria")
            .AppendLine("      ,C.IdProducto")
            .AppendLine("      ,P.NombreProducto")
            .AppendLine("      ,C.IdInteresCuotas")
            .AppendLine("      ,IC.NombreInteres AS NombreInteresCuotas")
            .AppendLine("      ,C.RequiereRevisionAdministrativa")
            .AppendLine("      ,C.NivelAutorizacion")
            .AppendLine("      ,C.ActualizarAplicacion")
         .AppendLine("      ,C.ControlaBackup")
         .AppendLine("    ,C.Comisiones")
         'Nuevos campos SiSeN
         .AppendLine("      ,C.FirmaMandato")
         .AppendLine("      ,C.AdquiereAcciones")
         .AppendLine("      ,C.AdquiereCamas")
         .AppendLine("      ,C.PideConyuge")
         .AppendLine("      ,C.TPFisicaDatosAdicionales")
         .AppendLine("      ,C.PideEmbarcacion")
         .AppendLine("      ,C.PerteneceAlComplejo")
         .AppendLine("      ,C.PagaExpensas")
         .AppendLine("      ,C.PagaAlquiler")
         .AppendLine("      ,C.ImporteGastosAdmin")
         '------------------------------------------------
         .AppendLine("      ,C.IdCategoriaInversionista")
         .AppendLine("      ,CI.NombreCategoria AS NombreCategoriaInversionista")
         .AppendLine("      ,C.LimiteMesesDeudaBotado")
         .AppendLine("      ,C.BackColor")
         .AppendLine("      ,C.ForeColor")
         '------------------------------------------------

         .AppendLine("  FROM Categorias C")
            'TODO: Ver como se saca la sucursal de este query.
            .AppendLine(" LEFT OUTER JOIN CajasNombres CN ON CN.IdSucursal = 1 AND CN.IdCaja = C.IdCaja")
            .AppendLine(" LEFT OUTER JOIN ContabilidadCuentas CC ON CC.IdCuenta = C.IdCuenta")
            .AppendLine(" LEFT OUTER JOIN ContabilidadCuentas CC2 ON CC2.IdCuenta = C.IdCuentaSecundaria")
            .AppendLine(" LEFT OUTER JOIN Intereses I ON I.IdInteres = C.IdInteres")
            .AppendLine(" LEFT OUTER JOIN Intereses IC ON IC.IdInteres = C.IdInteresCuotas")
         .AppendLine(" LEFT OUTER JOIN Productos P ON P.IdProducto = C.IdProducto")
         'Nuevo join por los nuveos campos de SiSeN
         .AppendLine(" LEFT OUTER JOIN Categorias CI ON CI.IdCategoria = C.IdCategoriaInversionista")


      End With
    End Sub

    Public Function Categorias_GA() As DataTable
      Dim myQuery = New StringBuilder()
        With myQuery
         SelectTexto(myQuery)
            .AppendLine(" ORDER BY C.NombreCategoria")
        End With
      Return GetDataTable(myQuery)
    End Function

    Public Function Categorias_G_PorNombre(nombre As String, exacto As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
        With myQuery
         SelectTexto(myQuery)
            .AppendLine(" WHERE 1 = 1")
            If Not String.IsNullOrWhiteSpace(nombre) Then
                If exacto Then
               .AppendFormatLine("   AND C.NombreCategoria = '{0}'", nombre)
                Else
               .AppendFormatLine("   AND C.NombreCategoria LIKE '%{0}%'", nombre)
                End If
            End If
            .AppendLine(" ORDER BY C.NombreCategoria")
        End With
      Return GetDataTable(myQuery)
    End Function

    Public Function Categorias_ConInteres() As DataTable
      Dim myQuery = New StringBuilder()
        With myQuery
         SelectTexto(myQuery)
            .AppendLine(" WHERE (C.IdInteres IS NOT NULL OR C.IdInteresCuotas IS NOT NULL)")
            .AppendLine(" ORDER BY C.NombreCategoria")
        End With

      Return GetDataTable(myQuery)
    End Function

   Public Function Categorias_G1(idCategoria As Integer, ceroTodos As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         If idCategoria <> 0 And Not ceroTodos Then
            .AppendFormatLine(" WHERE C.IdCategoria = {0}", idCategoria)
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb1) SelectTexto(stb1), "C.",
                    New Dictionary(Of String, String) From {{"NombreCaja", "CN.NombreCaja"},
                                                            {"NombreCuenta", "CC.NombreCuenta"},
                                                            {"NombreCuentaSecundaria", "CC2.NombreCuentaSecundaria"},
                                                            {"NombreInteres", "I.NombreInteres"},
                                                            {"NombreInteresCuotas", "IC.NombreInteres"}})
   End Function

   Public Function Categorias_GetIdMaximo() As Integer
      Return GetCodigoMaximo("IdCategoria", "Categorias").ToInteger()
    End Function

   Public Function Categorias_GetPrimerIdCategoria() As Integer
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT TOP 1 C.IdCategoria FROM Categorias C")
      End With
      Using dt As DataTable = GetDataTable(stb)
         If Not dt.Any Then Throw New Exception("No existe ninguna categoría de cliente")
         Return dt.First().Field(Of Integer)("IdCategoria")
      End Using
   End Function

   Public Function GetPorNombreExacto(nombre As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE C.NombreCategoria = '{0}'", nombre)
      End With
      Return GetDataTable(stb)
   End Function
End Class