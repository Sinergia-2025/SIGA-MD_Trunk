Imports Eniac.Entidades.SistemaE
Namespace Sistema
   Public Class AlertasSistemaCondiciones
      Inherits Comunes

      Public Sub New(da As Datos.DataAccess)
         MyBase.New(da)
      End Sub

      Public Sub AlertasSistemaCondiciones_I(idAlertaSistema As Integer, ordenCondicion As Integer,
                                             condicionCount As CondicionesCountAlerta,
                                             valorCondicionCount As Integer,
                                             mensajeCount As String,
                                             colorCondicionCount As Drawing.Color,
                                             ordenPrioridad As Integer,
                                             mostrarPopUp As Boolean,
                                             parametrosAdicionalesPantalla As String)
         Dim myQuery = New StringBuilder()
         With myQuery
            .AppendFormatLine("INSERT INTO {0} (", AlertaSistemaCondicion.NombreTabla)
            .AppendFormatLine("            {0}", AlertaSistemaCondicion.Columnas.IdAlertaSistema.ToString())
            .AppendFormatLine("          , {0}", AlertaSistemaCondicion.Columnas.OrdenCondicion.ToString())
            .AppendFormatLine("          , {0}", AlertaSistemaCondicion.Columnas.CondicionCount.ToString())
            .AppendFormatLine("          , {0}", AlertaSistemaCondicion.Columnas.ValorCondicionCount.ToString())
            .AppendFormatLine("          , {0}", AlertaSistemaCondicion.Columnas.MensajeCount.ToString())
            .AppendFormatLine("          , {0}", AlertaSistemaCondicion.Columnas.ColorCondicionCount.ToString())
            .AppendFormatLine("          , {0}", AlertaSistemaCondicion.Columnas.OrdenPrioridad.ToString())
            .AppendFormatLine("          , {0}", AlertaSistemaCondicion.Columnas.MostrarPopUp.ToString())
            .AppendFormatLine("          , {0}", AlertaSistemaCondicion.Columnas.ParametrosAdicionalesPantalla.ToString())

            .AppendFormatLine(" ) VALUES ( ")

            .AppendFormatLine("             {0} ", idAlertaSistema)
            .AppendFormatLine("          ,  {0} ", ordenCondicion)
            .AppendFormatLine("          , '{0}'", condicionCount.ToString())
            .AppendFormatLine("          ,  {0} ", valorCondicionCount)
            .AppendFormatLine("          , '{0}'", mensajeCount)
            .AppendFormatLine("          ,  {0} ", colorCondicionCount.ToArgb())
            .AppendFormatLine("          ,  {0} ", ordenPrioridad)
            .AppendFormatLine("          ,  {0} ", GetStringFromBoolean(mostrarPopUp))
            .AppendFormatLine("          , '{0}'", parametrosAdicionalesPantalla)

            .AppendLine(")")
         End With
         Execute(myQuery)
      End Sub

      Public Sub AlertasSistemaCondiciones_U(idAlertaSistema As Integer, ordenCondicion As Integer,
                                             condicionCount As CondicionesCountAlerta,
                                             valorCondicionCount As Integer,
                                             mensajeCount As String,
                                             colorCondicionCount As Drawing.Color,
                                             ordenPrioridad As Integer,
                                             mostrarPopUp As Boolean,
                                             parametrosAdicionalesPantalla As String)
         Dim myQuery = New StringBuilder()
         With myQuery
            .AppendFormatLine("UPDATE {0} ", AlertaSistemaCondicion.NombreTabla)
            .AppendFormatLine("   SET {0} = '{1}'", AlertaSistemaCondicion.Columnas.CondicionCount.ToString(), condicionCount.ToString())
            .AppendFormatLine("     , {0} =  {1} ", AlertaSistemaCondicion.Columnas.ValorCondicionCount.ToString(), valorCondicionCount)
            .AppendFormatLine("     , {0} = '{1}'", AlertaSistemaCondicion.Columnas.MensajeCount.ToString(), mensajeCount)
            .AppendFormatLine("     , {0} =  {1} ", AlertaSistemaCondicion.Columnas.ColorCondicionCount.ToString(), colorCondicionCount)
            .AppendFormatLine("     , {0} =  {1} ", AlertaSistemaCondicion.Columnas.OrdenPrioridad.ToString(), ordenPrioridad)
            .AppendFormatLine("     , {0} = '{1} ", AlertaSistemaCondicion.Columnas.MostrarPopUp.ToString(), GetStringFromBoolean(mostrarPopUp))
            .AppendFormatLine("     , {0} = '{1}'", AlertaSistemaCondicion.Columnas.ParametrosAdicionalesPantalla.ToString(), parametrosAdicionalesPantalla)
            .AppendFormatLine(" WHERE {0} =  {1} ", AlertaSistemaCondicion.Columnas.IdAlertaSistema.ToString(), idAlertaSistema)
            .AppendFormatLine("   AND {0} =  {1} ", AlertaSistemaCondicion.Columnas.OrdenCondicion.ToString(), ordenCondicion)
         End With
         Execute(myQuery)
      End Sub

      Public Sub AlertasSistemaCondiciones_D(idAlertaSistema As Integer, ordenCondicion As Integer)
         Dim myQuery = New StringBuilder()
         With myQuery
            .AppendFormatLine("DELETE FROM {0}", AlertaSistemaCondicion.NombreTabla)
            .AppendFormatLine(" WHERE {0} =  {1} ", AlertaSistemaCondicion.Columnas.IdAlertaSistema.ToString(), idAlertaSistema)
            If ordenCondicion <> 0 Then
               .AppendFormatLine("   AND {0} =  {1} ", AlertaSistemaCondicion.Columnas.OrdenCondicion.ToString(), ordenCondicion)
            End If
         End With
         Execute(myQuery)
      End Sub

      Private Sub SelectTexto(stb As StringBuilder)
         With stb
            .AppendFormatLine("SELECT AC.*")
            .AppendFormatLine("  FROM {0} AS AC", AlertaSistemaCondicion.NombreTabla)
         End With
      End Sub

      Public Function AlertasSistemaCondiciones_GA() As DataTable
         Return AlertasSistemaCondiciones_G(idAlertaSistema:=0, ordenCondicion:=0)
      End Function
      Public Function AlertasSistemaCondiciones_GA(idAlertaSistema As Integer) As DataTable
         Return AlertasSistemaCondiciones_G(idAlertaSistema, ordenCondicion:=0)
      End Function
      Private Function AlertasSistemaCondiciones_G(idAlertaSistema As Integer, ordenCondicion As Integer) As DataTable
         Dim myQuery = New StringBuilder()
         With myQuery
            SelectTexto(myQuery)
            .AppendFormatLine(" WHERE 1 = 1")
            If idAlertaSistema <> 0 Then
               .AppendFormatLine("   AND AC.{0} =  {1} ", AlertaSistemaCondicion.Columnas.IdAlertaSistema.ToString(), idAlertaSistema)
            End If
            If ordenCondicion <> 0 Then
               .AppendFormatLine("   AND AC.{0} =  {1} ", AlertaSistemaCondicion.Columnas.IdAlertaSistema.ToString(), ordenCondicion)
            End If
         End With
         Return GetDataTable(myQuery)
      End Function

      Public Function AlertasSistemaCondiciones_G1(idAlertaSistema As Integer, ordenCondicion As Integer) As DataTable
         Return AlertasSistemaCondiciones_G(idAlertaSistema, ordenCondicion)
      End Function

      Public Overloads Function Buscar(columna As String, valor As String) As DataTable
         Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "AC.")
      End Function

      Public Overloads Function GetCodigoMaximo(idAlertaSistema As Integer) As Integer
         Return GetCodigoMaximo(AlertaSistemaCondicion.Columnas.OrdenCondicion.ToString(), AlertaSistemaCondicion.NombreTabla,
                                String.Format("{0} = {1}", AlertaSistemaCondicion.Columnas.IdAlertaSistema.ToString(), AlertaSistemaCondicion.Columnas.IdAlertaSistema)).ToInteger()
      End Function

   End Class
End Namespace