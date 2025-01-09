Option Strict On
Option Explicit On
Public Class MovilRutasListasDePrecios
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Eniac.Datos.DataAccess())
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = Entidades.MovilRutaListaDePrecios.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me._Insertar(DirectCast(entidad, Entidades.MovilRutaListaDePrecios)))
   End Sub
   Public Overrides Sub Actualizar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me._Actualizar(DirectCast(entidad, Entidades.MovilRutaListaDePrecios)))
   End Sub
   Public Overrides Sub Borrar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me._Borrar(DirectCast(entidad, Entidades.MovilRutaListaDePrecios)))
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Entidades.Buscar) As DataTable
      Dim sql As SqlServer.MovilRutasListasDePrecios = New SqlServer.MovilRutasListasDePrecios(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return GetAll(-1)
   End Function
   Public Overloads Function GetAll(idRuta As Integer) As System.Data.DataTable
      Return New SqlServer.MovilRutasListasDePrecios(Me.da).MovilRutasListasDePrecios_GA(idRuta)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.MovilRutaListaDePrecios, tipo As TipoSP)

      Dim sql As SqlServer.MovilRutasListasDePrecios = New SqlServer.MovilRutasListasDePrecios(Me.da)

      Select Case tipo
         Case TipoSP._I
            sql.MovilRutasListasDePrecios_I(en.IdRuta, en.IdListaPrecios, en.PorDefecto, en.AplicaPreciosOferta)
         Case TipoSP._U
            sql.MovilRutasListasDePrecios_U(en.IdRuta, en.IdListaPrecios, en.PorDefecto, en.AplicaPreciosOferta)
         Case TipoSP._D
            sql.MovilRutasListasDePrecios_D(en.IdRuta, en.IdListaPrecios)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.MovilRutaListaDePrecios, ByVal dr As DataRow)
      With o
         .IdRuta = Integer.Parse(dr(Entidades.MovilRutaListaDePrecios.Columnas.IdRuta.ToString()).ToString())
         .NombreRuta = dr(Entidades.MovilRuta.Columnas.NombreRuta.ToString()).ToString()
         .ListaDePrecios = New Eniac.Reglas.ListasDePrecios().GetUno(Integer.Parse(dr(Entidades.MovilRutaListaDePrecios.Columnas.IdListaPrecios.ToString()).ToString()))
         .PorDefecto = Boolean.Parse(dr(Entidades.MovilRutaListaDePrecios.Columnas.PorDefecto.ToString()).ToString())
         .AplicaPreciosOferta = Boolean.Parse(dr(Entidades.MovilRutaListaDePrecios.Columnas.AplicaPreciosOferta.ToString()).ToString())
      End With
   End Sub
#End Region

#Region "Metodos Publicos"

   Public Sub _Insertar(entidad As Entidades.MovilRutaListaDePrecios)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.MovilRutaListaDePrecios)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.MovilRutaListaDePrecios)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub


   Public Overloads Sub InsertaDesdeRuta(ruta As Entidades.MovilRuta)
      For Each ent As Entidades.MovilRutaListaDePrecios In ruta.ListasDePrecio
         ent.IdRuta = ruta.IdRuta
         _Insertar(ent)
      Next
   End Sub


   Public Function GetTodos() As List(Of Entidades.MovilRutaListaDePrecios)
      Return GetTodos(-1)
   End Function
   Public Function GetTodos(idRuta As Integer) As List(Of Entidades.MovilRutaListaDePrecios)
      Return CargaLista(Me.GetAll(idRuta), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.MovilRutaListaDePrecios())
   End Function

   Friend Function _GetUno(idRuta As Integer, idListaPrecios As Integer) As Entidades.MovilRutaListaDePrecios
      Dim sql As SqlServer.MovilRutasListasDePrecios = New SqlServer.MovilRutasListasDePrecios(Me.da)
      Return CargaEntidad(sql.MovilRutasListasDePrecios_G1(idRuta, idListaPrecios),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.MovilRutaListaDePrecios(),
                          AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe la Ruta/Lista De Precios con ruta {0} y lista de precios {1}.", idRuta, idListaPrecios))
   End Function

#End Region
End Class