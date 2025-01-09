#Region "Option/Imports"
Option Strict On
Option Explicit On

Imports Eniac.Win
#End Region

Public Class CuentasBancariasClaseABM

#Region "Overrides"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        'Me.BotonImprimir.Visible = False
    End Sub

    Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
        If estado = StateForm.Actualizar Then
            Return New CuentasBancariasClaseDetalle(DirectCast(Me.GetEntidad(), Entidades.CuentaBancariaClase))
        End If
        Return New CuentasBancariasClaseDetalle(New Eniac.Entidades.CuentaBancariaClase())
    End Function

    Protected Overrides Function GetReglas() As Eniac.Reglas.Base
        Return New Reglas.CuentasBancariasClase()
    End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return New Reglas.CuentasBancariasClase().GetUna(Integer.Parse(.Cells(Entidades.CuentaBancariaClase.Columnas.IdCuentaBancariaClase.ToString()).Value.ToString()))
      End With
   End Function
    Protected Overrides Sub FormatearGrilla()
        Try


            With Me.dgvDatos.DisplayLayout.Bands(0)

                Dim col As Integer = 0

                .Columns(Entidades.CuentaBancariaClase.Columnas.IdCuentaBancariaClase.ToString()).FormatearColumna("Código", col, 60, HAlign.Right)
                .Columns(Entidades.CuentaBancariaClase.Columnas.NombreCuentaBancariaClase.ToString()).FormatearColumna("Descripción", col, 180)

            End With

            ' Agrego el Filtro en Linea x Descripción de la clase
            AgregarFiltroEnLinea(dgvDatos, {Entidades.CuentaBancariaClase.Columnas.NombreCuentaBancariaClase.ToString()})
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

#End Region

#Region "Eventos"

    '#

#End Region

End Class