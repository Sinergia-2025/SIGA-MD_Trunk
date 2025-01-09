Public Class Chequeras
   Inherits Comunes

#Region "Constructores"

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#End Region

   Public Sub Chequeras_I(idChequera As Integer,
                          idCuentaBancaria As Integer,
                          numeroDesde As Integer,
                          numeroHasta As Integer,
                          nombreChequera As String,
                          numeroActual As Integer,
                          activo As Boolean,
                          descripcion As String)

      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO Chequeras (IdChequera, IdCuentaBancaria, NumeroDesde, NumeroHasta, NombreChequera, NumeroActual, Activo, Descripcion)")
         .AppendFormatLine("	VALUES(")
         .AppendFormatLine("		{0}", idChequera)
         .AppendFormatLine("		,{0}", idCuentaBancaria)
         .AppendFormatLine("		,{0}", numeroDesde)
         .AppendFormatLine("		,{0}", numeroHasta)
         .AppendFormatLine("		,'{0}'", nombreChequera)
         .AppendFormatLine("		,{0}", numeroActual)
         .AppendFormatLine("		,{0}", GetStringFromBoolean(activo))
         .AppendFormatLine("		,'{0}'", descripcion)
         .AppendFormatLine("	)")
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub Chequeras_U(idChequera As Integer,
                          idCuentaBancaria As Integer,
                          numeroDesde As Integer,
                          numeroHasta As Integer,
                          nombreChequera As String,
                          activo As Boolean,
                          descripcion As String)

      '# NO se realiza la modificación del Numero Actual para evitar posibles choques entre multiples usuarios utilizando cheques.

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE C SET ")
         .AppendFormatLine("	C.NumeroHasta = {0},", numeroHasta)
         .AppendFormatLine("	C.NombreChequera = '{0}',", nombreChequera)
         .AppendFormatLine("	C.Activo = {0},", GetStringFromBoolean(activo))
         .AppendFormatLine("	C.Descripcion = '{0}'", descripcion)
         .AppendFormatLine("FROM Chequeras C")
         .AppendFormatLine("WHERE C.IdChequera = {0}", idChequera)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub Chequeras_D(idChequera As Integer)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("DELETE Chequeras WHERE IdChequera = {0}", idChequera)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Function Chequeras_GA(idCuentaBancaria As Integer) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         Me.SelectTexto(query)
         If idCuentaBancaria > 0 Then .AppendFormatLine("WHERE C.IdCuentaBancaria = {0} AND C.Activo = 'True'", idCuentaBancaria)
         .AppendFormatLine("  AND (Cb.IdEmpresa = {0} OR Cb.IdEmpresa is null)", actual.Sucursal.Empresa.IdEmpresa)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   '# IdChequera
   Public Function Chequeras_G1(idChequera As Integer) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         Me.SelectTexto(query)
         .AppendFormatLine("WHERE C.IdChequera = {0}", idChequera)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   '# CuentaBancaria AND NumeroDesde (Alternative Key)
   Public Function Chequeras_G1(idCuentaBancaria As Integer, numeroDesde As Integer) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         Me.SelectTexto(query)
         .AppendFormatLine("WHERE C.IdCuentaBancaria = {0} AND C.NumeroDesde = {1}", idCuentaBancaria, numeroDesde)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Sub SelectTexto(query As StringBuilder)
      With query
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("	 C.IdChequera")
         .AppendFormatLine("	, C.IdCuentaBancaria")
         .AppendFormatLine("	, CB.NombreCuenta")
         .AppendFormatLine("	, C.NumeroDesde")
         .AppendFormatLine("	, C.NumeroHasta")
         .AppendFormatLine("	, C.NombreChequera")
         .AppendFormatLine("	, C.NumeroActual")
         .AppendFormatLine("	, C.Activo")
         .AppendFormatLine("	, C.Descripcion")
         .AppendFormatLine("FROM Chequeras C")
         .AppendFormatLine("INNER JOIN CuentasBancarias CB ON C.IdCuentaBancaria = CB.IdCuentaBancaria")
         '-- REQ-32727.- --
         '.AppendFormatLine(" INNER JOIN Empresas E ON CB.IdEmpresa = E.IdEmpresa")

      End With
   End Sub

   Public Function GetSiguienteChequeDisponible(idCuentaBancaria As Integer, idChequera As Integer) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT * FROM Chequeras C WHERE 1=1")
         .AppendFormatLine("  AND C.IdCuentaBancaria = {0}", idCuentaBancaria)
         .AppendFormatLine("  AND C.IdChequera = {0}", idChequera)
         .AppendFormatLine("  AND C.NumeroActual <= C.NumeroHasta") '# Valido que la chequera aún tenga cheques sin usar
         .AppendFormatLine("  AND C.Activo = 1")
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   Public Overloads Function ValidarRango(desde As Integer, hasta As Integer, idCuentaBancaria As Integer, idChequera As Integer) As DataTable
      Dim opc As String = String.Format("IdCuentaBancaria = {0} AND IdChequera <> {1}", idCuentaBancaria, idChequera)

      Return Me.ValidarRango(desde, hasta, Entidades.Chequera.NombreTabla, Entidades.Chequera.Columnas.NumeroDesde.ToString(), Entidades.Chequera.Columnas.NumeroHasta.ToString(), opc)
   End Function

   Public Sub ActualizarNumeroActual(idChequera As Integer, nroChequeRegistrado As Integer)
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE C SET C.NumeroActual = {1} FROM Chequeras C WHERE C.IdChequera = {0}", idChequera, nroChequeRegistrado)
      End With
      Me.Execute(query.ToString())
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} Like '%{1}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
End Class