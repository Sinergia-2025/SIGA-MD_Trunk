#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class ModelosVehiculosABM

#Region "Overrides"
    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        Me.tsbImprimir.Visible = False
    End Sub
    Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
        If estado = StateForm.Actualizar Then
            Return New ModelosVehiculosDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.ModeloVehiculo))
        End If
        Return New ModelosVehiculosDetalle(New Eniac.Entidades.ModeloVehiculo)
    End Function

    Protected Overrides Function GetReglas() As Reglas.Base
        Return New Reglas.ModelosVehiculos()
    End Function

    Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
        Dim ModeloVehiculo = New Eniac.Entidades.ModeloVehiculo
        With Me.dgvDatos.ActiveRow
            ModeloVehiculo = New Eniac.Reglas.ModelosVehiculos().GetUno(Integer.Parse(.Cells("IdModeloVehiculo").Value.ToString()))
        End With
        Return ModeloVehiculo
    End Function

    Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns(Eniac.Entidades.ModeloVehiculo.Columnas.IdModeloVehiculo.ToString()).FormatearColumna("Código", col, 80, HAlign.Right)
         .Columns(Eniac.Entidades.ModeloVehiculo.Columnas.NombreModeloVehiculo.ToString()).FormatearColumna("Nombre", col, 400)
         .Columns("IdMarcaVehiculo").FormatearColumna("Id Marca", col, 80, HAlign.Right)
         .Columns("NombreMarcaVehiculo").FormatearColumna("Nombre Marca", col, 200)
      End With
   End Sub

#End Region
End Class