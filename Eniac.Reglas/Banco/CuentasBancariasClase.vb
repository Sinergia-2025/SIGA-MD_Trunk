Option Explicit On
Option Strict On

Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Reglas
Imports Eniac.Entidades

Public Class CuentasBancariasClase
    Inherits Eniac.Reglas.Base

#Region "Constructores"

    Public Sub New()
        Me.New(New Datos.DataAccess())
    End Sub

    Public Sub New(ByVal accesoDatos As Datos.DataAccess)
        Me.NombreEntidad = "CuentaBancariaClase"
        da = accesoDatos
    End Sub

#End Region

#Region "Overrides"

    Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
        EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.CuentaBancariaClase), TipoSP._I))
    End Sub

    Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
        EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.CuentaBancariaClase), TipoSP._U))
    End Sub

    Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
        EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.CuentaBancariaClase), TipoSP._D))
    End Sub

    Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
        Dim sql As SqlServer.CuentasBancariasClase = New SqlServer.CuentasBancariasClase(Me.da)
        Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
    End Function

    Public Overrides Function GetAll() As System.Data.DataTable
        Return New SqlServer.CuentasBancariasClase(Me.da).CuentasBancariasClase_GA()
    End Function


#End Region

#Region "Metodos Privados"

    Private Sub EjecutaSP(en As Entidades.CuentaBancariaClase, tipo As TipoSP)

        Dim sqlC As SqlServer.CuentasBancariasClase = New SqlServer.CuentasBancariasClase(da)

        Select Case tipo
            Case TipoSP._I
                sqlC.CuentasBancariasClase_I(en.IdCuentaBancariaClase, en.NombreCuentaBancariaClase)
            Case TipoSP._U
                sqlC.CuentasBancariasClase_U(en.IdCuentaBancariaClase, en.NombreCuentaBancariaClase)
            Case TipoSP._D
                sqlC.CuentasBancariasClase_D(en.IdCuentaBancariaClase)
        End Select

    End Sub

    Private Sub CargarUno(ByVal o As Entidades.CuentaBancariaClase, ByVal dr As DataRow)
        With o
            .IdCuentaBancariaClase = dr.Field(Of Integer)(Entidades.CuentaBancariaClase.Columnas.IdCuentaBancariaClase.ToString())
            .NombreCuentaBancariaClase = dr.Field(Of String)(Entidades.CuentaBancariaClase.Columnas.NombreCuentaBancariaClase.ToString())

        End With
    End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUna(IdCuentaBancariaClase As Integer) As Entidades.CuentaBancariaClase
      Return GetUna(IdCuentaBancariaClase, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUna(IdCuentaBancariaClase As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.CuentaBancariaClase
      Return CargaEntidad(New SqlServer.CuentasBancariasClase(Me.da).CuentasBancariasClase_G1(IdCuentaBancariaClase),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.CuentaBancariaClase(),
                         accion, Function() String.Format("No existe Clase de Cuenta Bancaria con Id: {0}", IdCuentaBancariaClase))
   End Function
    Public Function GetTodos() As List(Of Entidades.CuentaBancariaClase)
        Return CargaLista(Me.GetAll(),
                        Sub(o, dr) CargarUno(DirectCast(o, Entidades.CuentaBancariaClase), dr),
                        Function() New Entidades.CuentaBancariaClase())
    End Function
    Public Function GetCodigoMaximo() As Integer

        Return New SqlServer.CuentasBancariasClase(Me.da).GetCodigoMaximo()
    End Function
   Public Function GetFiltradoPorNombre(ByVal NombreCuentaBancariaClase As String) As DataTable
      Return New SqlServer.CuentasBancariasClase(da).GetFiltradoPorNombre(NombreCuentaBancariaClase)
   End Function

   'Public Function GetUna(idCuentaBancariaClase As Integer) As Entidades.CuentaBancariaClase
   '    Return CargaEntidad(New SqlServer.CuentasBancariasClase(Me.da).CuentasBancariasClase_G1(idCuentaBancariaClase),
   '                      Sub(o, dr)
   '                          o.IdCuentaBancariaClase = dr.ValorNumericoPorDefecto("idCuentaBancariaClase", 0I)
   '                          o.NombreCuentaBancariaClase = dr("NombreCuentaBancariaClase").ToString()

   '                      End Sub,
   '                      Function() New Entidades.CuentaBancariaClase,
   '                      AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe localidad con Id ´{0}´", idCuentaBancariaClase))


   'End Function


#End Region


End Class
