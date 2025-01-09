
Option Explicit On
Option Strict On

Imports System.Text
Public Class ucCuentasDH
    Inherits Eniac.Reglas.Base
#Region "Constructores"

    Public Sub New()
        Me.NombreEntidad = "ucCuentasDH"
        da = New Datos.DataAccess()
    End Sub

    Public Sub New(ByVal accesoDatos As Datos.DataAccess)
        Me.NombreEntidad = "ucCuentasDH"
        da = accesoDatos
    End Sub

#End Region


    Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
        Me.EjecutaSP(entidad, TipoSP._I)
    End Sub



#Region "Metodos Privados"

    Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)


        Dim en As Entidades.ucCuentaDHvb = DirectCast(entidad, Entidades.ucCuentaDHvb)
        ' Dim Cuentas As Entidades.ucCuentaDHvb = rubro.entidadCuentas

        Try
            da.OpenConection()
            da.BeginTransaction()

            Dim sql As SqlServer.ucCuentasDH = New SqlServer.ucCuentasDH(Me.da)


            Select Case tipo

                Case TipoSP._I


                    'sql.CuentaRubro_I(en.idRubro _
                    '                , en.IdPlanCuenta _
                    '                , en.Tipo _
                    '                , en.idCuentaDebe.ToString _
                    '                , en.idCuentaHaber.ToString)
                Case TipoSP._U

                    sql.CuentaRubro_D(en.IdPlanCuenta, _
                                     en.idRubro, _
                                     en.Tipo)

                    'sql.CuentaRubro_I(en.idRubro _
                    '                 , en.IdPlanCuenta _
                    '                 , en.Tipo _
                    '                 , en.idCuentaDebe.ToString _
                    '                 , en.idCuentaHaber.ToString)

                Case TipoSP._D
                    sql.CuentaRubro_D(en.IdPlanCuenta, _
                                      en.idRubro, _
                                      en.Tipo)

            End Select

            da.CommitTransaction()

        Catch ex As Exception
            da.RollbakTransaction()
            Throw ex

        Finally
            da.CloseConection()
        End Try

    End Sub
#End Region
End Class
