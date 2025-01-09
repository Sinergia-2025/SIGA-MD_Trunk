Public Class ProduccionModelosFormasABM

   Private _decimalesValores As Integer
   Private _formatoValores As String

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      TryCatched(
      Sub()
         _decimalesValores = Reglas.Publicos.ProduccionDecimalesVariablesModeloForma
         _formatoValores = Formatos.Format.CustomDecimales(_decimalesValores)
      End Sub)
      MyBase.OnLoad(e)
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ProduccionModelosFormasDetalle(DirectCast(GetEntidad(), Entidades.ProduccionModeloForma))
      End If
      Return New ProduccionModelosFormasDetalle(New Entidades.ProduccionModeloForma())
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ProduccionModelosFormas()
   End Function
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)()
      If dr IsNot Nothing Then
         Return New Reglas.ProduccionModelosFormas().GetUno(dr.Field(Of Integer)(Entidades.ProduccionModeloForma.Columnas.IdProduccionModeloForma.ToString()))
      End If
      Return New Entidades.ProduccionModeloForma()
   End Function
   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         .Columns(Entidades.ProduccionModeloForma.Columnas.IdProduccionModeloForma.ToString()).FormatearColumna("Código", pos, 70, HAlign.Right)
         .Columns(Entidades.ProduccionModeloForma.Columnas.NombreProduccionModeloForma.ToString()).FormatearColumna("Nombre", pos, 300)
         '.Columns(Entidades.ProduccionModeloForma.Columnas.Coeficiente.ToString()).FormatearColumna("Coeficiente", pos, 70, HAlign.Right, , "N2")

         For Each uc In .Columns.OfType(Of UltraGridColumn).Where(Function(c) c.Key.StartsWith("____"))
            uc.FormatearColumna(uc.Key.Trim("_"c), pos, 120, HAlign.Right, , _formatoValores)
         Next

      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.ProduccionModeloForma.Columnas.NombreProduccionModeloForma.ToString()})
   End Sub
   Protected Overrides Function GetAll(rg As Reglas.Base) As DataTable
      Return DirectCast(rg, Reglas.ProduccionModelosFormas).GetAll(pivotVariables:=True)
   End Function
   Protected Overrides Function Buscar(rg As Reglas.Base, bus As Entidades.Buscar) As DataTable
      Return DirectCast(rg, Reglas.ProduccionModelosFormas).Buscar(bus, pivotVariables:=True)
   End Function
#End Region

End Class