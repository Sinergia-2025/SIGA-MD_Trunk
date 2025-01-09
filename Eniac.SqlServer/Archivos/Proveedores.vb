Public Class Proveedores
   Inherits Comunes
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Proveedores_I(idProveedor As Long,
                            codigoProveedor As Long,
                            codigoProveedorLetras As String,
                            tipoDocProveedor As String,
                            nroDocProveedor As Long,
                            nombreProveedor As String,
                            direccionProveedor As String,
                            idLocalidad As Integer,
                            cuitProveedor As String,
                            telefonoProveedor As String,
                            faxProveedor As String,
                            idCategoriaFiscal As Integer,
                            ingresosBrutos As String,
                            correoElectronico As String,
                            observacion As String,
                            idCategoria As Integer,
                            idRubroCompra As Integer,
                            idCuentaCaja As Integer,
                            activo As Boolean,
                            esPasibleRetencion As Boolean,
                            idRegimen As Integer,
                            idTipoComprobante As String,
                            descuentoRecargoPorc As Decimal,
                            idFormasPago As Integer,
                            porCtaOrden As Boolean,
                            fechaHigSeg As Date?,
                            fechaRes559 As Date?,
                            fechaIndiceInc As Date?,
                            esPasibleRetencionIVA As Boolean,
                            idRegimenIVA As Integer,
                            esPasibleRetencionIIBB As Boolean,
                            idRegimenIIBB As Integer,
                            idRegimenGan As Integer,
                            idCuentaContable As Long?,
                            nombreDeFantasia As String,
                            idCuentaBanco As Integer,
                            nivelAutorizacion As Short,
                            fechaIndemnidad As Date?,
                            esProveedorGenerico As Boolean,
                            cbuProveedor As String,
                            cbuAliasProveedor As String,
                            cbuCuit As String,
                            correoAdministrativo As String,
                            nroCuenta As String,
                            idConceptoCM05 As Integer?,
                            idTransportista As Integer,
                            idClienteVinculado As Long?,
                            idRegimenIIBBComplem As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO Proveedores (")
         .AppendFormatLine("     {0}", Entidades.Proveedor.Columnas.IdProveedor.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.CodigoProveedor.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.CodigoProveedorLetras.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.TipoDocProveedor.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.NroDocProveedor.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.NombreProveedor.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.DireccionProveedor.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.IdLocalidadProveedor.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.CuitProveedor.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.TelefonoProveedor.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.FaxProveedor.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.IdCategoriaFiscal.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.IngresosBrutos.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.CorreoElectronico.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.Observacion.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.IdCategoria.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.IdRubroCompra.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.IdCuentaCaja.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.Activo.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.EsPasibleRetencion.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.IdRegimen.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.IdRegimenGan.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.DescuentoRecargoPorc.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.IdFormasPago.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.PorCtaOrden.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.FechaHigSeg.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.FechaRes559.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.FechaIndiceInc.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.EsPasibleRetencionIVA.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.IdRegimenIVA.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.EsPasibleRetencionIIBB.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.IdRegimenIIBB.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.IdCuentaContable.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.NombreDeFantasia.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.IdCuentaBanco.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.NivelAutorizacion.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.FechaIndemnidad.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.EsProveedorGenerico.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.CBUProveedor.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.CBUAliasProveedor.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.CBUCuit.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.CorreoAdministrativo.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.NroCuenta.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.IdConceptoCM05.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.IdTransportista.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.IdClienteVinculado.ToString())
         .AppendFormatLine("   , {0}", Entidades.Proveedor.Columnas.IdRegimenIIBBComplem.ToString())
         .AppendFormatLine(" ) VALUES  (")
         .AppendFormatLine("      {0} ", idProveedor)
         .AppendFormatLine("   ,  {0} ", codigoProveedor)
         .AppendFormatLine("   , '{0}'", codigoProveedorLetras)
         If nroDocProveedor > 0 Then
            .AppendFormatLine("   , '{0}'", tipoDocProveedor)
            .AppendFormatLine("   ,  {0} ", nroDocProveedor)
         Else
            .AppendFormatLine("   , NULL")
            .AppendFormatLine("   , NULL")
         End If

         .AppendFormatLine("   , '{0}'", nombreProveedor)
         .AppendFormatLine("   , '{0}'", direccionProveedor)
         .AppendFormatLine("   ,  {0} ", idLocalidad)
         .AppendFormatLine("   , '{0}'", cuitProveedor)
         .AppendFormatLine("   , '{0}'", telefonoProveedor)
         .AppendFormatLine("   , '{0}'", faxProveedor)
         .AppendFormatLine("   ,  {0} ", idCategoriaFiscal)
         .AppendFormatLine("   , '{0}'", ingresosBrutos)
         .AppendFormatLine("   , '{0}'", correoElectronico)
         .AppendFormatLine("   , '{0}'", observacion)
         .AppendFormatLine("   ,  {0} ", idCategoria)
         .AppendFormatLine("   ,  {0} ", idRubroCompra)
         .AppendFormatLine("   ,  {0} ", idCuentaCaja)
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(activo))
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(esPasibleRetencion))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idRegimen))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idRegimenGan))
         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(idTipoComprobante))
         .AppendFormatLine("   ,  {0} ", descuentoRecargoPorc)
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idFormasPago))
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(porCtaOrden))
         .AppendFormatLine("   ,  {0} ", ObtenerFecha(fechaHigSeg, False))
         .AppendFormatLine("   ,  {0} ", ObtenerFecha(fechaRes559, False))
         .AppendFormatLine("   ,  {0} ", ObtenerFecha(fechaIndiceInc, False))
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(esPasibleRetencionIVA))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idRegimenIVA))
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(esPasibleRetencionIIBB))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idRegimenIIBB))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idCuentaContable))
         .AppendFormatLine("   , '{0}'", nombreDeFantasia)
         .AppendFormatLine("   ,  {0} ", idCuentaBanco)
         .AppendFormatLine("   ,  {0} ", nivelAutorizacion)
         .AppendFormatLine("   ,  {0} ", ObtenerFecha(fechaIndemnidad, False))
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(esProveedorGenerico))
         '# Campos CBU
         If Not String.IsNullOrEmpty(cbuProveedor) AndAlso cbuProveedor <> "0" Then
            .AppendFormatLine("   , '{0}'", cbuProveedor)
         Else
            .AppendFormatLine("   , NULL")
         End If
         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(cbuAliasProveedor))
         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(cbuCuit))
         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(correoAdministrativo))
         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(nroCuenta))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idConceptoCM05))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idTransportista))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idClienteVinculado))

         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idRegimenIIBBComplem))

         .AppendFormatLine(")")
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Proveedores")
   End Sub

   Public Sub Proveedores_U(idProveedor As Long,
                            codigoProveedor As Long,
                            codigoProveedorLetras As String,
                            tipoDocProveedor As String,
                            nroDocProveedor As Long,
                            nombreProveedor As String,
                            direccionProveedor As String,
                            idLocalidad As Integer,
                            cuitProveedor As String,
                            telefonoProveedor As String,
                            faxProveedor As String,
                            idCategoriaFiscal As Integer,
                            ingresosBrutos As String,
                            correoElectronico As String,
                            observacion As String,
                            idCategoria As Integer,
                            idRubroCompra As Integer,
                            idCuentaCaja As Integer,
                            activo As Boolean,
                            esPasibleRetencion As Boolean,
                            idRegimen As Integer,
                            idTipoComprobante As String,
                            descuentoRecargoPorc As Decimal,
                            idFormasPago As Integer,
                            porCtaOrden As Boolean,
                            fechaHigSeg As Date?,
                            fechaRes559 As Date?,
                            fechaIndiceInc As Date?,
                            esPasibleRetencionIVA As Boolean,
                            idRegimenIVA As Integer,
                            esPasibleRetencionIIBB As Boolean,
                            idRegimenIIBB As Integer,
                            idRegimenGan As Integer,
                            idCuentaContable As Long?,
                            nombreDeFantasia As String,
                            idCuentaBanco As Integer,
                            nivelAutorizacion As Short,
                            fechaIndemnidad As Date?,
                            esProveedorGenerico As Boolean,
                            cbuProveedor As String,
                            cbuAliasProveedor As String,
                            cbuCuit As String,
                            correoAdministrativo As String,
                            nroCuenta As String,
                            idConceptoCM05 As Integer?,
                            idTransportista As Integer,
                            idClienteVinculado As Long?,
                            idRegimenIIBBComplem As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE Proveedores")
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.Proveedor.Columnas.CodigoProveedor.ToString(), codigoProveedor)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Proveedor.Columnas.CodigoProveedorLetras.ToString(), codigoProveedorLetras)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Proveedor.Columnas.NombreProveedor.ToString(), nombreProveedor)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Proveedor.Columnas.DireccionProveedor.ToString(), direccionProveedor)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.IdLocalidadProveedor.ToString(), idLocalidad)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Proveedor.Columnas.CuitProveedor.ToString(), cuitProveedor)
         If nroDocProveedor > 0 Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.Proveedor.Columnas.TipoDocProveedor.ToString(), tipoDocProveedor)
            .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.NroDocProveedor.ToString(), nroDocProveedor)
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.Proveedor.Columnas.TipoDocProveedor.ToString())
            .AppendFormatLine("     , {0} = NULL", Entidades.Proveedor.Columnas.NroDocProveedor.ToString())
         End If
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Proveedor.Columnas.TelefonoProveedor.ToString(), telefonoProveedor)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Proveedor.Columnas.FaxProveedor.ToString(), faxProveedor)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.IdCategoriaFiscal.ToString(), idCategoriaFiscal)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Proveedor.Columnas.IngresosBrutos.ToString(), ingresosBrutos)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Proveedor.Columnas.CorreoElectronico.ToString(), correoElectronico)

         .AppendFormatLine("     , {0} = '{1}'", Entidades.Proveedor.Columnas.Observacion.ToString(), observacion)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.IdCategoria.ToString(), idCategoria)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.IdRubroCompra.ToString(), idRubroCompra)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.IdCuentaCaja.ToString(), idCuentaCaja)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.Activo.ToString(), GetStringFromBoolean(activo))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.EsPasibleRetencion.ToString(), GetStringFromBoolean(esPasibleRetencion))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.IdRegimen.ToString(), GetStringFromNumber(idRegimen))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.IdRegimenGan.ToString(), GetStringFromNumber(idRegimenGan))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.IdTipoComprobante.ToString(), GetStringParaQueryConComillas(idTipoComprobante))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.DescuentoRecargoPorc.ToString(), descuentoRecargoPorc)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.IdFormasPago.ToString(), GetStringFromNumber(idFormasPago))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.PorCtaOrden.ToString(), GetStringFromBoolean(porCtaOrden))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.FechaHigSeg.ToString(), ObtenerFecha(fechaHigSeg, False))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.FechaRes559.ToString(), ObtenerFecha(fechaRes559, False))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.FechaIndiceInc.ToString(), ObtenerFecha(fechaIndiceInc, False))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.EsPasibleRetencionIVA.ToString(), GetStringFromBoolean(esPasibleRetencionIVA))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.IdRegimenIVA.ToString(), GetStringFromNumber(idRegimenIVA))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.EsPasibleRetencionIIBB.ToString(), GetStringFromBoolean(esPasibleRetencionIIBB))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.IdRegimenIIBB.ToString(), GetStringFromNumber(idRegimenIIBB))

         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.IdRegimenIIBBComplem.ToString(), GetStringFromNumber(idRegimenIIBBComplem))

         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.IdCuentaContable.ToString(), GetStringFromNumber(idCuentaContable))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Proveedor.Columnas.NombreDeFantasia.ToString(), nombreDeFantasia)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.IdCuentaBanco.ToString(), idCuentaBanco)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.NivelAutorizacion.ToString(), nivelAutorizacion)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.FechaIndemnidad.ToString(), ObtenerFecha(fechaIndemnidad, False))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.EsProveedorGenerico.ToString(), GetStringFromBoolean(esProveedorGenerico))
         '# Campos CBU
         If Not String.IsNullOrEmpty(cbuProveedor) AndAlso cbuProveedor <> "0" Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.Proveedor.Columnas.CBUProveedor.ToString(), cbuProveedor)
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.Proveedor.Columnas.CBUProveedor.ToString())
         End If
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.CBUAliasProveedor.ToString(), GetStringParaQueryConComillas(cbuAliasProveedor))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.CBUCuit.ToString(), GetStringParaQueryConComillas(cbuCuit))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.CorreoAdministrativo.ToString(), GetStringParaQueryConComillas(correoAdministrativo))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.NroCuenta.ToString(), GetStringParaQueryConComillas(nroCuenta))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.IdConceptoCM05.ToString(), GetStringFromNumber(idConceptoCM05))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.IdTransportista.ToString(), GetStringFromNumber(idTransportista))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Proveedor.Columnas.IdClienteVinculado.ToString(), GetStringFromNumber(idClienteVinculado))

         .AppendFormatLine(" WHERE IdProveedor = {0}", idProveedor)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Proveedores")
   End Sub

   Public Sub Proveedores_D(idProveedor As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM Proveedores ")
         .AppendFormatLine(" WHERE IdProveedor = {0}", idProveedor)
      End With
      Execute(myQuery.ToString())
      Sincroniza_I(myQuery.ToString(), "Proveedores")
   End Sub

   Public Function Proveedores_G1(idProveedor As Long, incluirFoto As Boolean) As DataTable
      Return Proveedores_G(idProveedor:=idProveedor,
                           incluirFoto:=incluirFoto,
                           codigoProveedor:=0, nombreProveedor:=String.Empty, codigoExacto:=False, activo:=Nothing, nombreExacto:=False, nombreProveedorYFantasia:=False, direccionProveedor:=String.Empty, porCtaOrden:=Nothing, cuit:=String.Empty)
   End Function

   Public Function Proveedores_G1_Codigo(codigoProveedor As Long, activo As Boolean?, incluirFoto As Boolean, codigoExacto As Boolean) As DataTable
      Return Proveedores_G(codigoProveedor:=codigoProveedor, codigoExacto:=codigoExacto,
                           incluirFoto:=incluirFoto,
                           idProveedor:=0, nombreProveedor:=String.Empty, nombreExacto:=False, activo:=activo, nombreProveedorYFantasia:=False, direccionProveedor:=String.Empty, porCtaOrden:=Nothing, cuit:=String.Empty)
   End Function

   Public Function Proveedores_G1_CodigoLetras(codigoProveedorLetras As String, incluirFoto As Boolean) As DataTable
      Dim stbQuery = New StringBuilder()
      SelectTexto(stbQuery, incluirFoto)
      With stbQuery
         .AppendFormatLine(" WHERE P.CodigoProveedorLetras LIKE '%{0}%'", codigoProveedorLetras)
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function Proveedores_G1_CodigoLetrasExacto(codigoProveedorLetras As String, incluirFoto As Boolean) As DataTable
      Dim stbQuery = New StringBuilder()
      SelectTexto(stbQuery, incluirFoto)
      With stbQuery
         .AppendFormatLine(" WHERE P.CodigoProveedorLetras = '{0}'", codigoProveedorLetras)
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function Proveedores_GA() As DataTable
      Return Proveedores_G(idProveedor:=0, codigoProveedor:=0, nombreProveedor:=String.Empty, incluirFoto:=False, codigoExacto:=False, nombreExacto:=False, activo:=Nothing, nombreProveedorYFantasia:=False, direccionProveedor:=String.Empty, porCtaOrden:=Nothing, cuit:=String.Empty)
   End Function

   Public Function Proveedores_GA_Nombre(nombreProveedor As String, nombreExacto As Boolean, nombreProveedorYFantasia As Boolean, activo As Boolean) As DataTable
      Return Proveedores_G(nombreProveedor:=nombreProveedor, nombreExacto:=nombreExacto, nombreProveedorYFantasia:=nombreProveedorYFantasia,
                           incluirFoto:=False,
                           idProveedor:=0, codigoProveedor:=0, codigoExacto:=False, activo:=activo, direccionProveedor:=String.Empty, porCtaOrden:=Nothing, cuit:=String.Empty)
   End Function

   Public Function Proveedores_GA_Direccion(direccionProveedor As String, activo As Boolean) As DataTable
      Return Proveedores_G(direccionProveedor:=direccionProveedor, activo:=activo,
                           incluirFoto:=False,
                           idProveedor:=0, codigoProveedor:=0, codigoExacto:=False, nombreProveedor:=String.Empty, nombreExacto:=False, nombreProveedorYFantasia:=False, porCtaOrden:=Nothing, cuit:=String.Empty)
   End Function

   Public Function Proveedores_GA_CtaOrden(porCtaOrden As Boolean) As DataTable
      Return Proveedores_G(porCtaOrden:=porCtaOrden,
                           incluirFoto:=False,
                           idProveedor:=0, codigoProveedor:=0, codigoExacto:=False, nombreProveedor:=String.Empty, nombreExacto:=False, nombreProveedorYFantasia:=False, direccionProveedor:=String.Empty, activo:=Nothing, cuit:=String.Empty)
   End Function

   Public Function Proveedores_GA_Cuit(cuit As String, activo As Boolean) As DataTable
      Return Proveedores_G(cuit:=cuit, activo:=activo,
                           incluirFoto:=False,
                           idProveedor:=0, codigoProveedor:=0, codigoExacto:=False, nombreProveedor:=String.Empty, nombreExacto:=False, nombreProveedorYFantasia:=False, direccionProveedor:=String.Empty, porCtaOrden:=Nothing)
   End Function

   Public Function Proveedores_G(idProveedor As Long,
                                 codigoProveedor As Long,
                                 nombreProveedor As String,
                                 direccionProveedor As String,
                                 cuit As String,
                                 activo As Boolean?,
                                 porCtaOrden As Boolean?,
                                 incluirFoto As Boolean,
                                 codigoExacto As Boolean, nombreExacto As Boolean, nombreProveedorYFantasia As Boolean) As DataTable
      Dim stbQuery = New StringBuilder()
      SelectTexto(stbQuery, incluirFoto)
      With stbQuery
         .AppendLine(" WHERE 1 = 1")
         If idProveedor > 0 Then
            .AppendLine("   AND P.IdProveedor = " & idProveedor.ToString())
         End If
         If activo.HasValue Then
            .AppendFormat("   AND P.Activo = {0}", GetStringFromBoolean(activo)).AppendLine()
         End If
         If codigoProveedor > 0 Then
            If codigoExacto Then
               .AppendFormat("   AND P.CodigoProveedor = {0}", codigoProveedor).AppendLine()
            Else
               .AppendFormat("   AND P.CodigoProveedor LIKE '%{0}%'", codigoProveedor).AppendLine()
            End If
         End If

         If Not String.IsNullOrWhiteSpace(nombreProveedor) Then
            Dim condicion As String = String.Empty
            If nombreProveedorYFantasia Then
               If nombreExacto Then
                  .AppendFormatLine("     AND (P.NombreProveedor = '{0}' OR P.NombreDeFantasia = '{0}')", nombreProveedor)
               Else
                  condicion = "   AND (P.NombreProveedor LIKE '%{0}%' OR P.NombreDeFantasia LIKE '%{0}%')"
               End If
            Else
               If nombreExacto Then
                  .AppendFormatLine("     AND P.NombreProveedor = '{0}'", nombreProveedor)
               Else
                  condicion = "   AND P.NombreProveedor LIKE '%{0}%'"
               End If
            End If

            If Not nombreExacto Then
               For Each palabra As String In nombreProveedor.Split(" "c)
                  If Not String.IsNullOrWhiteSpace(palabra) Then
                     .AppendFormat(condicion, palabra).AppendLine()
                  End If
               Next
            End If
         End If

         If Not String.IsNullOrWhiteSpace(direccionProveedor) Then
            .AppendFormat("   AND P.DireccionProveedor LIKE '%{0}%'", direccionProveedor).AppendLine()
         End If

         If porCtaOrden.HasValue Then
            .AppendFormat("   AND P.PorCtaOrden = {0}", GetStringFromBoolean(porCtaOrden)).AppendLine()
         End If

         If Not String.IsNullOrWhiteSpace(cuit) Then
            .AppendFormat("   AND P.CuitProveedor = '{0}'", cuit).AppendLine()
         End If

         .AppendLine(" ORDER BY P.NombreProveedor")
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      If columna = "NombreLocalidad" Then
         columna = "L." + columna
      ElseIf columna = "NombreCategoriaFiscal" Then
         columna = "CF." + columna
      ElseIf columna = "NombreCategoria" Then
         columna = "CP." + columna
      ElseIf columna = "NombreRubro" Then
         columna = "RC." + columna
      ElseIf columna = "NombreCuentaCaja" Then
         columna = "C." + columna
      ElseIf columna = "NombreCuenta" Then
         columna = "CC." + columna
      ElseIf columna = "NombreCuentaBanco" Then
         columna = "CB." + columna
      Else
         columna = "P." + columna
      End If

      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, incluirFoto:=False)
         .AppendLine("  WHERE 1 = 1")
         For Each palabra In valor.Split(" "c)
            .AppendFormat("   AND {0} LIKE '%{1}%'", columna, palabra)
         Next
         .AppendLine()
         .AppendLine(" ORDER BY P.NombreProveedor")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Private Sub SelectTexto(stb As StringBuilder, incluirFoto As Boolean)
      With stb
         .AppendFormatLine("SELECT P.IdProveedor")
         .AppendFormatLine("     , P.CodigoProveedor")
         .AppendFormatLine("     , P.CodigoProveedorLetras")
         .AppendFormatLine("     , P.NombreProveedor")
         .AppendFormatLine("     , P.NombreDeFantasia")
         .AppendFormatLine("     , P.DireccionProveedor")
         .AppendFormatLine("     , P.IdLocalidadProveedor")
         .AppendFormatLine("     , L.NombreLocalidad")
         .AppendFormatLine("     , CF.IdCategoriaFiscal")
         .AppendFormatLine("     , CFC.LetraFiscalCompra AS LetraFiscal")
         .AppendFormatLine("     , CF.NombreCategoriaFiscal")
         .AppendFormatLine("     , P.IdCategoria")
         .AppendFormatLine("     , CP.NombreCategoria")
         .AppendFormatLine("     , P.IdRubroCompra")
         .AppendFormatLine("     , RC.NombreRubro")
         .AppendFormatLine("     , P.CuitProveedor")
         .AppendFormatLine("     , P.TipoDocProveedor")
         .AppendFormatLine("     , P.NroDocProveedor")
         .AppendFormatLine("     , P.IngresosBrutos")
         .AppendFormatLine("     , P.TelefonoProveedor")
         .AppendFormatLine("     , P.FaxProveedor")
         .AppendFormatLine("     , P.CorreoElectronico")
         .AppendFormatLine("     , P.Observacion")
         .AppendFormatLine("     , P.IdCuentaCaja")
         .AppendFormatLine("     , C.NombreCuentaCaja")
         .AppendFormatLine("     , P.Activo ")
         .AppendFormatLine("     , P.EsPasibleRetencion")
         .AppendFormatLine("     , P.IdRegimen")
         .AppendFormatLine("     , P.IdRegimenGan")
         .AppendFormatLine("     , P.IdTipoComprobante")
         .AppendFormatLine("     , P.DescuentoRecargoPorc ")

         .AppendFormatLine("     , P.IdFormasPago")
         .AppendFormatLine("     , FP.DescripcionFormasPago")

         .AppendFormatLine("     , P.NivelAutorizacion")

         .AppendFormatLine("     , P.PorCtaOrden ")
         .AppendFormatLine("     , P.FechaHigSeg ")
         .AppendFormatLine("     , P.FechaRes559 ")
         .AppendFormatLine("     , P.FechaIndiceInc ")
         'Solo la busco en el GET1 porque ahi puedo necesitarlo, en todo lo demas NO.
         'Lentifica terriblemente la consulta.
         If incluirFoto Then
            .AppendFormatLine("      ,P.Foto")
         Else
            .AppendFormatLine("      ,NULL AS Foto")
         End If
         .AppendFormatLine("     , P.EsPasibleRetencionIVA")
         .AppendFormatLine("     , P.IdRegimenIVA")
         .AppendFormatLine("     , P.EsPasibleRetencionIIBB")
         .AppendFormatLine("     , P.IdRegimenIIBB")

         .AppendFormatLine("     , P.IdRegimenIIBBComplem")

         .AppendFormatLine("     , P.IdCuentaContable")
         .AppendFormatLine("     , CC.NombreCuenta")
         .AppendFormatLine("     , P.IdCuentaBanco")
         .AppendFormatLine("     , CB.NombreCuentaBanco")
         .AppendFormatLine("     , P.FechaIndemnidad")
         .AppendFormatLine("     , P.EsProveedorGenerico")
         .AppendFormatLine("     , P.CBUProveedor")
         .AppendFormatLine("     , P.CBUAliasProveedor")
         .AppendFormatLine("     , P.CBUCuit")
         .AppendFormatLine("     , P.CorreoAdministrativo")
         .AppendFormatLine("     , P.NroCuenta")
         .AppendFormatLine("     , P.IdConceptoCM05")
         .AppendFormatLine("     , CM05.DescripcionConceptoCM05")
         .AppendFormatLine("     , CM05.TipoConceptoCM05")
         .AppendFormatLine("     , P.IdTransportista")
         .AppendFormatLine("     , T.NombreTransportista")
         .AppendFormatLine("     , P.IdClienteVinculado")
         .AppendFormatLine("     , CL.CodigoCliente CodigoClienteVinculado")
         .AppendFormatLine("     , CL.NombreCliente NombreClienteVinculado")

         .AppendFormatLine("  FROM Proveedores P ")
         .AppendFormatLine(" INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = P.IdCategoriaFiscal ")

         .AppendFormatLine(" CROSS JOIN (SELECT * FROM Parametros WHERE IdParametro = 'CATEGORIAFISCALEMPRESA' AND IdEmpresa = {0}) PAR", actual.Sucursal.IdEmpresa)
         .AppendFormatLine("  LEFT JOIN CategoriasFiscalesConfiguraciones CFC ON CFC.IdCategoriaFiscalCliente = CF.IdCategoriaFiscal AND CFC.IdCategoriaFiscalEmpresa = ISNULL(PAR.ValorParametro, 0)")

         .AppendFormatLine(" INNER JOIN Localidades L ON L.IdLocalidad = P.IdLocalidadProveedor")
         .AppendFormatLine(" INNER JOIN CategoriasProveedores CP ON CP.IdCategoria = P.IdCategoria ")
         .AppendFormatLine(" INNER JOIN RubrosCompras RC ON RC.IdRubro = P.IdRubroCompra ")
         .AppendFormatLine(" INNER JOIN CuentasDeCajas C ON C.idCuentaCaja = P.idCuentaCaja")
         .AppendFormatLine(" INNER JOIN CuentasBancos CB ON CB.IdCuentaBanco = P.IdCuentaBanco")
         .AppendFormatLine("  LEFT JOIN VentasFormasPago FP ON FP.IdFormasPago = P.IdFormasPago")
         .AppendFormatLine("  LEFT JOIN ContabilidadCuentas CC ON CC.IdCuenta = P.IdCuentaContable")
         .AppendFormatLine("  LEFT JOIN AFIPConceptosCM05 CM05 ON CM05.IdConceptoCM05 = P.IdConceptoCM05")
         .AppendFormatLine("  LEFT JOIN Transportistas T ON T.IdTransportista = P.IdTransportista")
         .AppendFormatLine("  LEFT JOIN Clientes CL ON CL.IdCliente = P.IdClienteVinculado")

      End With
   End Sub

   Public Function Proveedores_GA_Ids() As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT P.IdProveedor FROM Proveedores P")
      End With
      Return GetDataTable(myQuery)
   End Function


   Public Function ExisteProveedor(codigoProveedor As Long, nombreProveedor As String) As Boolean
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT COUNT(CodigoProveedor) AS Existe")
         .AppendFormatLine("  FROM Proveedores")
         .AppendFormatLine(" WHERE 1=1")
         If codigoProveedor <> 0 Then
            .AppendFormatLine("   AND CodigoProveedor = {0}", codigoProveedor)
         End If
         If Not String.IsNullOrWhiteSpace(nombreProveedor) Then
            .AppendFormatLine("   AND NombreProveedor = '{0}'", nombreProveedor)
         End If
      End With
      Dim dt As DataTable = GetDataTable(stb.ToString())
      Return Integer.Parse(dt.Rows(0)("Existe").ToString()) > 0
   End Function


   Public Sub GrabarFoto(imagen As Drawing.Image, idProveedor As Long, nombreProveedor As String)

      If Not IO.Directory.Exists(Entidades.Publicos.DriverBase + "Eniac\") Then
         IO.Directory.CreateDirectory(Entidades.Publicos.DriverBase + "Eniac\")
      End If

      Dim path = Entidades.Publicos.DriverBase + "Eniac\" + nombreProveedor.Replace("/", "_") + ".jpg"

      Dim stbQuery = New StringBuilder()

      If imagen IsNot Nothing Then
         imagen.Save(path)

         Dim fsArchivo As IO.FileStream = New IO.FileStream(path, IO.FileMode.Open, IO.FileAccess.Read)

         Dim iFileLength As Integer = Integer.Parse(fsArchivo.Length.ToString())

         Dim foto(Integer.Parse(fsArchivo.Length.ToString())) As Byte

         fsArchivo.Read(foto, 0, iFileLength)

         fsArchivo.Close()

         With stbQuery
            .Length = 0
            .AppendLine("UPDATE Proveedores")
            .AppendLine("   SET Foto = @Foto")
            .AppendLine(" WHERE IdProveedor = " & idProveedor.ToString())
         End With

         Me._da.Command.CommandText = stbQuery.ToString()
         Me._da.Command.CommandType = CommandType.Text
         Dim oParameter As Data.Common.DbParameter = Me._da.Command.CreateParameter()
         oParameter.ParameterName = "@Foto"
         oParameter.DbType = DbType.Binary
         oParameter.Size = foto.Length
         oParameter.Value = foto
         Me._da.Command.Parameters.Add(oParameter)
         Me._da.Command.Connection = Me._da.Connection
         Me._da.ExecuteNonQuery(Me._da.Command)
      Else

         With stbQuery
            .Length = 0
            .AppendLine("UPDATE Proveedores")
            .AppendLine("   SET Foto = NULL")
            .AppendLine(" WHERE IdProveedor = " & idProveedor.ToString())
         End With

         Execute(stbQuery)
      End If
   End Sub

   Public Overloads Function GetCodigoMaximo(campo As String) As Long
      Return GetCodigoMaximo(campo, Entidades.Proveedor.NombreTabla)
   End Function

   Public Sub ActualizarTelefonosMails(idProveedor As Long, Telefonos As String, Mails As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE Proveedores SET ")
         .AppendFormat(" TelefonoProveedor = '{0}'", Telefonos.ToString())
         .AppendFormat(" ,CorreoElectronico = '{0}'", Mails.ToString())
         .AppendFormat(" WHERE idProveedor = {0}", idProveedor.ToString())
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Clientes")
   End Sub
End Class