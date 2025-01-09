Public Class Sucursales
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.Sucursal.NombreTabla, accesoDatos)
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.Sucursal)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.Sucursal)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.Sucursal)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.Sucursales(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.Sucursales(da).Sucursales_GA(False)
   End Function

#End Region

#Region "Metodos"
   Public Sub _Insertar(entidad As Entidades.Sucursal)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.Sucursal)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.Sucursal)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function EstoyEn(incluirLogo As Boolean) As Entidades.Sucursal
      Dim dt = New SqlServer.Sucursales(da).Sucursales_GA(estoyAca:=True, soyLaCentral:=Nothing, incluirLogo:=incluirLogo)
      Return CargaUna(dt, AccionesSiNoExisteRegistro.Excepcion, "No existe una Sucursal con Estoy Aca.", incluirLogo)
   End Function

   Public Function GetUna(id As Integer, incluirLogo As Boolean) As Entidades.Sucursal
      Dim dt = New SqlServer.Sucursales(da).Sucursales_G1(id, incluirLogo)
      Return CargaUna(dt, AccionesSiNoExisteRegistro.Excepcion, String.Format("No existe una Sucursal con Id = {0}.", id), incluirLogo)
   End Function

   Public Overloads Function GetTodas(incluirLogo As Boolean) As List(Of Entidades.Sucursal)
      Return GetTodas(idFuncion:=String.Empty, incluirLogo:=incluirLogo)
   End Function
   Public Overloads Function GetTodas(idFuncion As String, incluirLogo As Boolean) As List(Of Entidades.Sucursal)
      Return GetTodas(idFuncion, idEmpresa:=Nothing, incluirLogo)
   End Function
   Public Overloads Function GetTodas(idFuncion As String, idEmpresa As Integer?, incluirLogo As Boolean) As List(Of Entidades.Sucursal)
      Return GetTodas(idFuncion, idEmpresa, publicarEnWeb:=Entidades.Publicos.SiNoTodos.TODOS, incluirLogo)
   End Function
   Public Overloads Function GetTodas(publicarEnWeb As Entidades.Publicos.SiNoTodos, incluirLogo As Boolean) As List(Of Entidades.Sucursal)
      Return GetTodas(idFuncion:=String.Empty, idEmpresa:=Nothing, publicarEnWeb:=publicarEnWeb, incluirLogo:=incluirLogo)
   End Function

   Private Overloads Function GetTodas(idFuncion As String, publicarEnWeb As Entidades.Publicos.SiNoTodos, incluirLogo As Boolean) As List(Of Entidades.Sucursal)
      Return GetTodas(idFuncion, idEmpresa:=Nothing, publicarEnWeb, incluirLogo)
   End Function
   Private Overloads Function GetTodas(idFuncion As String, idEmpresa As Integer?, publicarEnWeb As Entidades.Publicos.SiNoTodos, incluirLogo As Boolean) As List(Of Entidades.Sucursal)
      Using dt = New SqlServer.Sucursales(da).Sucursales_GA(idFuncion, idEmpresa, publicarEnWeb, incluirLogo)
         Return CargaLista(dt, Sub(o, dr) CargaUna(o, dr, incluirLogo), Function() New Entidades.Sucursal())
      End Using
   End Function

   Public Overloads Function GetTodas(sacarLaSucursal As Integer, incluirLogo As Boolean) As List(Of Entidades.Sucursal)
      Dim dt = New SqlServer.Sucursales(da).Sucursales_GA_Excluye(sacarLaSucursal, incluirLogo)
      Return CargaLista(dt, Sub(o, dr) CargaUna(o, dr, incluirLogo), Function() New Entidades.Sucursal())
   End Function

   Public Function GetSoloIdsDeTodas() As List(Of Integer)
      Return EjecutaConConexion(Function() _GetSoloIdsDeTodas())
   End Function

   Friend Function _GetSoloIdsDeTodas() As List(Of Integer)
      Return New SqlServer.Sucursales(da).GetSoloIdsDeTodas()
   End Function

   Public Function GetEstoyAca(incluirLogo As Boolean) As Entidades.Sucursal
      Return EstoyEn(incluirLogo)
   End Function

   Public Function GetSoyLaCentral(incluirLogo As Boolean) As Entidades.Sucursal
      Dim dt = New SqlServer.Sucursales(da).Sucursales_GA(estoyAca:=Nothing, soyLaCentral:=True, incluirLogo:=incluirLogo)
      Return CargaUna(dt, AccionesSiNoExisteRegistro.Excepcion, "No existe una Sucursal con Soy La Central.", incluirLogo)
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.Sucursales(da).GetCodigoMaximo()
   End Function

   Public Function GetPorCodigo(id As Integer, idFuncion As String) As DataTable
      Return New SqlServer.Sucursales(da).GetPorCodigoNombre(id, String.Empty, idFuncion, False)
   End Function

   Public Function GetParaAlerta() As List(Of Entidades.Sucursal)
      Using dt = New SqlServer.Sucursales(da).Sucursales_GetParaAlerta()
         Return CargaLista(dt, Sub(o, dr) CargaUna(o, dr, False), Function() New Entidades.Sucursal())
      End Using
   End Function

   Public Function GetPorNombre(nombre As String, idFuncion As String) As DataTable
      Return New SqlServer.Sucursales(da).GetPorCodigoNombre(0, nombre, idFuncion, False)
   End Function

   Public Sub EjecutaLimpiezaDeSucursales(idSucursal As Integer)
      Dim sql = New SqlServer.Sucursales(da)
      sql.EjecutaLimpiezaDeSucursales(idSucursal)
   End Sub

   Public Function GetTodosParaSincronizarSegunIncluir(incluirSucursales As Entidades.JSonEntidades.CobranzasMovil.SucursalesSincronizar) As List(Of Entidades.Sucursal)
      Dim idSucursal As Integer? = Nothing
      Dim idEmpresa As Integer? = Nothing
      If incluirSucursales = Entidades.JSonEntidades.CobranzasMovil.SucursalesSincronizar.SUCURSAL Then idSucursal = actual.Sucursal.Id
      If incluirSucursales = Entidades.JSonEntidades.CobranzasMovil.SucursalesSincronizar.EMPRESAS Then idEmpresa = actual.Sucursal.IdEmpresa

      Using dt = New SqlServer.Sucursales(da).Sucursales_GA(idEmpresa, idSucursal)
         Return CargaLista(dt, Sub(o, dr) CargaUna(o, dr, incluirLogo:=False), Function() New Entidades.Sucursal())
      End Using
   End Function

   Public Function GetDepositoUbicacionPorDefectoPorSucursal() As DataTable
      Return New SqlServer.Sucursales(da).GetDepositoUbicacionPorDefectoPorSucursal()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.Sucursal, tipo As TipoSP)
      Dim sql = New SqlServer.Sucursales(da)
      Select Case tipo

         Case TipoSP._I

            If en.IdSucursal = 0 Then
               Throw New Exception("No se puede agregar una sucursal con Código cero (0)")
            End If

            sql.Sucursales_I(en.IdSucursal, en.Nombre, en.Direccion, en.Localidad.IdLocalidad, en.Telefono,
                             en.Correo, en.FechaInicioActiv, en.EstoyAca, en.SoyLaCentral, en.IdSucursalAsociada,
                             en.ColorSucursal, en.LogoSucursal, en.DireccionComercial, en.LocalidadComercial.IdLocalidad,
                             en.RedesSociales, en.IdSucursalAsociadaPrecios, en.PublicarEnWeb, en.IdEmpresa)

            Dim sqlPS = New SqlServer.ProductosSucursales(da)
            sqlPS.ProductosSucursales_IPorSucursal(en.IdSucursal, en.Usuario)

            Dim sqlPSP = New SqlServer.ProductosSucursalesPrecios(da)
            sqlPSP.ProductosSucursalesPrecios_IPorSucursal(en.IdSucursal, en.Usuario)

            '# Llamo a la regla para que agregue las Formas de Pago a la nueva sucursal
            Dim rVentasFormasPagoSucursales = New VentasFormasPagoSucursales(da)
            For Each formaPago In en.FormasDePago
               rVentasFormasPagoSucursales._Inserta(formaPago)
            Next

            Dim sImpresoras = New SqlServer.Impresoras(da)
            sImpresoras.Impresoras_IPorSucursal(actual.Sucursal.Id, en.IdSucursal, "NORMAL")

            'Genero la Caja Maestra 
            Dim sqlCN = New SqlServer.CajasNombres(da)
            'vml por defecto pongo el plan de cuentas principal.
            sqlCN.CajasNombres_I(en.IdSucursal, 1, "Principal", String.Empty, String.Empty, 1, 0, 0, 0, Nothing, String.Empty, String.Empty, String.Empty, String.Empty)

            'Genero la cabecara de la primer planilla de caja.
            Dim sqlCaja = New SqlServer.Cajas(da)
            sqlCaja.Cajas_I(en.IdSucursal, 1, 1, Date.Now, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Nothing)

            ''Genero la numeracion en cero, es muy importante mantener los comprobantes relacionados (FACT, NCRED, NDEB)
            'Dim sqlVentasNumero As SqlServer.VentasNumeros = New SqlServer.VentasNumeros(da)
            'sqlVentasNumero.VentasNumeros_GenerarNumeracion(sucu.IdSucursal)

            '-- Carga Deposito desde Sucursal.- ------------------
            Dim rDeposito = New SucursalesDepositos(da)
            rDeposito._InsertarDesdeSucursal(en)
            '-----------------------------------------------------

            Using dtUbicPredeterminada = New SucursalesUbicaciones(da).GetUbicacionPredeterminadaParaSucursal(en.IdSucursal)
               If Not dtUbicPredeterminada.Any() Then
                  Throw New Exception(String.Format("No se encontró Ubicación para definir por Defecto en la Sucursal {0}", en.IdSucursal))
               End If
               Dim dr = dtUbicPredeterminada.First()
               sqlPS.ProductosSucursales_UPorSucursal(en.IdSucursal, dr.Field(Of Integer)("IdDeposito"), dr.Field(Of Integer)("IdUbicacion"))
            End Using


         Case TipoSP._U
            sql.Sucursales_U(en.IdSucursal, en.Nombre, en.Direccion, en.Localidad.IdLocalidad, en.Telefono,
                             en.Correo, en.FechaInicioActiv, en.EstoyAca, en.SoyLaCentral, en.IdSucursalAsociada,
                             en.ColorSucursal, en.LogoSucursal, en.DireccionComercial, en.LocalidadComercial.IdLocalidad,
                             en.RedesSociales, en.IdSucursalAsociadaPrecios, en.PublicarEnWeb, en.IdEmpresa)

            '# Llamo a la regla para que borre todas las FP asociadas a ésta sucursal
            Dim rVentasFormasPagoSucursales = New VentasFormasPagoSucursales(da)
            rVentasFormasPagoSucursales.BorrarTodas(en.IdSucursal, False)

            '# Y agrego nuevamente las FP a la sucursal
            For Each formaPago As Entidades.VentasFormasPagoSucursales In en.FormasDePago
               rVentasFormasPagoSucursales._Inserta(formaPago)
            Next

         Case TipoSP._D
            '-- Procedimiento de Eliminacion de ubicaciones.- ---
            Dim rDepo = New SucursalesDepositos(da)
            Dim dt = rDepo.GetDeposito(en.IdSucursal)

            For Each tipo In Entidades.Publicos.EnumToArray(Of Entidades.SucursalDeposito.TiposDepositos)
               If dt.Count(Function(dr) dr.Field(Of String)("TipoDeposito") = tipo.ToString()) > 1 Then
                  Throw New Exception(String.Format("No se Puede Borrar la Sucursal. Posee más de 1 (un) Deposito de tipo {0}.", tipo))
               End If
            Next

            'If dt.Rows.Count > 1 Then
            '   Throw New Exception("No se Puede Borrar la Sucursal. Posee más de 1 (un) Deposito.")
            'End If

            Dim sqlCaja = New SqlServer.Cajas(da)
            sqlCaja.Cajas_D(en.IdSucursal, 0)

            Dim sqlCajasNombres = New SqlServer.CajasNombres(da)
            sqlCajasNombres.CajasNombres_D(en.IdSucursal, 0)

            Dim sqlHP = New SqlServer.HistorialPrecios(da)
            sqlHP.HistorialPrecios_D(en.IdSucursal)

            Dim sqlPSP = New SqlServer.ProductosSucursalesPrecios(da)
            sqlPSP.ProductosSucursalesPrecios_DPorSucursal(en.IdSucursal)

            Dim sqlPS = New SqlServer.ProductosSucursales(da)
            sqlPS.ProductosSucursales_DPorSucursal(en.IdSucursal)

            Dim sImpresoras = New SqlServer.Impresoras(da)
            sImpresoras.Impresoras_D(en.IdSucursal, String.Empty)

            '# Llamo a la regla para que borre todas las FP asociadas a ésta sucursal
            Dim rVentasFormasPagoSucursales = New Reglas.VentasFormasPagoSucursales(da)
            rVentasFormasPagoSucursales.BorrarTodas(en.IdSucursal, False)

            '-- Elimina Deposito.- --------------------------------------
            rDepo._BorrarDesdeDeposito(en)
            '------------------------------------------------------------
            sql.Sucursales_D(en.IdSucursal)

      End Select

   End Sub

   Private Sub CargaUna(o As Entidades.Sucursal, dr As DataRow, incluirLogo As Boolean)
      o.Id = dr.Field(Of Integer)("Id")
      o.IdSucursal = dr.Field(Of Integer)("IdSucursal")

      o.Empresa = New Empresas(da).GetUno(dr.Field(Of Integer)(Entidades.Sucursal.Columnas.IdEmpresa.ToString()))

      o.Nombre = dr.Field(Of String)("Nombre")

      o.Direccion = dr.Field(Of String)("Direccion")
      o.Localidad = New Localidades(da).GetUna(dr.Field(Of Integer)("IdLocalidad"))
      o.Telefono = dr.Field(Of String)("Telefono").IfNull()
      o.Correo = dr.Field(Of String)("Correo").IfNull()

      o.IdSucursalAsociada = dr.Field(Of Integer?)("IdSucursalAsociada").IfNull()
      o.NombreSucursalAsociada = dr.Field(Of String)("NombreSucursalAsociada").IfNull()

      o.IdSucursalAsociadaPrecios = dr.Field(Of Integer?)("IdSucursalAsociadaPrecios").IfNull()

      o.FechaInicioActiv = dr.Field(Of Date?)("FechaInicioActiv").IfNull()

      o.EstoyAca = dr.Field(Of Boolean)("EstoyAca")
      o.SoyLaCentral = dr.Field(Of Boolean)("SoyLaCentral")
      o.PublicarEnWeb = dr.Field(Of Boolean)("PublicarEnWeb")

      o.ColorSucursal = dr.Field(Of Integer)("ColorSucursal")

      o.DireccionComercial = dr.Field(Of String)("DireccionComercial")
      o.LocalidadComercial = New Localidades(da).GetUna(dr.Field(Of Integer)("IdLocalidadComercial"))
      o.RedesSociales = dr.Field(Of String)("RedesSociales").IfNull()

      If incluirLogo And Not String.IsNullOrEmpty(dr("LogoSucursal").ToString()) Then
         Dim content() As Byte = CType(dr("LogoSucursal"), Byte())
         Dim stream = New IO.MemoryStream(content)
         o.LogoSucursal = Drawing.Image.FromStream(stream) ' New System.Drawing.Bitmap(stream)
      End If

      ' # Cargo las Formas de Pago asociadas a la sucursal
      o.FormasDePago = CargarFormasDePagoSucursal(o)

   End Sub

   Private Function CargaUna(dt As DataTable, accion As AccionesSiNoExisteRegistro, mensajeExcepcion As String, incluirLogo As Boolean) As Entidades.Sucursal
      Dim o As Entidades.Sucursal = New Entidades.Sucursal()
      If dt.Rows.Count > 0 Then
         Me.CargaUna(o, dt.Rows(0), incluirLogo)
      Else
         If accion = AccionesSiNoExisteRegistro.Excepcion Then
            Throw New Exception(mensajeExcepcion)
         ElseIf accion = AccionesSiNoExisteRegistro.Nulo Then
            Return Nothing
         End If
      End If
      Return o
   End Function

   Private Function CargarFormasDePagoSucursal(o As Entidades.Sucursal) As List(Of Entidades.VentasFormasPagoSucursales)
      Dim rVentasFormasPagoSucursales = New VentasFormasPagoSucursales(da)
      Dim lista = New List(Of Entidades.VentasFormasPagoSucursales)
      Using dt = rVentasFormasPagoSucursales.GetAll(o.Id)
         If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
               Dim eVFPS = New Entidades.VentasFormasPagoSucursales With {
                  .IdSucursal = dr.Field(Of Integer)(Entidades.VentasFormasPagoSucursales.Columnas.IdSucursal.ToString()),
                  .IdFormasPago = dr.Field(Of Integer)(Entidades.VentasFormasPagoSucursales.Columnas.IdFormasPago.ToString()),
                  .DescripcionFormasPago = dr.Field(Of String)(Entidades.VentaFormaPago.Columnas.DescripcionFormasPago.ToString()),
                  .OrdenVentas = dr.Field(Of Integer)(Entidades.VentaFormaPago.Columnas.OrdenVentas.ToString()),
                  .OrdenCompras = dr.Field(Of Integer)(Entidades.VentaFormaPago.Columnas.OrdenCompras.ToString()),
                  .OrdenFichas = dr.Field(Of Integer)(Entidades.VentaFormaPago.Columnas.OrdenFichas.ToString())
               }
               lista.Add(eVFPS)
            Next
         End If
      End Using
      Return lista
   End Function

#End Region

End Class