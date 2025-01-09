#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class MarcasVehiculosABM

#Region "Overrides"
    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        Me.tsbImprimir.Visible = False
    End Sub
    Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
        If estado = StateForm.Actualizar Then
            Return New MarcasVehiculosDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.MarcaVehiculo))
        End If
        Return New MarcasVehiculosDetalle(New Eniac.Entidades.MarcaVehiculo)
    End Function

    Protected Overrides Function GetReglas() As Reglas.Base
        Return New Reglas.MarcasVehiculos()
    End Function

    Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
        Dim MarcaVehiculo = New Eniac.Entidades.MarcaVehiculo
        With Me.dgvDatos.ActiveRow
         MarcaVehiculo = New Eniac.Reglas.MarcasVehiculos().GetUno(Integer.Parse(.Cells("IdMarcaVehiculo").Value.ToString()))
      End With
        Return MarcaVehiculo
    End Function

    Protected Overrides Sub FormatearGrilla()
        With Me.dgvDatos.DisplayLayout.Bands(0)
            Dim col As Integer = 0
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns(Eniac.Entidades.MarcaVehiculo.Columnas.IdMarcaVehiculo.ToString()).FormatearColumna("Código", col, 80, HAlign.Right)
         .Columns(Eniac.Entidades.MarcaVehiculo.Columnas.NombreMarcaVehiculo.ToString()).FormatearColumna("Nombre", col, 400)
      End With
    End Sub

#End Region
End Class