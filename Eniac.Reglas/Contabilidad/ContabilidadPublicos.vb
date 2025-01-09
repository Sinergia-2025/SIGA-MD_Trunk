Public Class ContabilidadPublicos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ContabilidadPublicos"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ContabilidadPublicos"
      da = accesoDatos
   End Sub

#End Region

   Public Shared ReadOnly Property ContabilidadEjecutarEnLinea() As Boolean
      Get
         Return ContabilidadEjecutarEnLinea(Nothing)
      End Get
   End Property
   Public Shared ReadOnly Property ContabilidadEjecutarEnLinea(da As Datos.DataAccess) As Boolean
      Get
         If da IsNot Nothing Then
            Return Boolean.Parse(New Parametros(da).GetValorPD(Entidades.Parametro.Parametros.CONTABILIDADEJECUTARENLINEA, Boolean.FalseString))
         Else
            Return Boolean.Parse(New Parametros().GetValorPD(Entidades.Parametro.Parametros.CONTABILIDADEJECUTARENLINEA, Boolean.FalseString))
         End If
      End Get
   End Property


   Public Shared ReadOnly Property UtilizaCentroCostos() As Boolean
      Get
         Return UtilizaCentroCostos(Nothing)
      End Get
   End Property

   Private Shared _utilizaCentroCostos As Boolean?
   Public Shared ReadOnly Property UtilizaCentroCostos(da As Datos.DataAccess) As Boolean
      Get
         If Not _utilizaCentroCostos.HasValue Then
            If da IsNot Nothing Then
               _utilizaCentroCostos = Boolean.Parse(New Eniac.Reglas.Parametros(da).GetValorPD(Entidades.Parametro.Parametros.UTILIZACENTROCOSTOS.ToString(), Boolean.FalseString))
            Else
               _utilizaCentroCostos = Boolean.Parse(New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.UTILIZACENTROCOSTOS.ToString(), Boolean.FalseString))
            End If
         End If
         Return _utilizaCentroCostos.Value
      End Get
   End Property
   Public Shared ReadOnly Property PermiteCambiarCentroCostosCompras() As Boolean
      Get
         Return PermiteCambiarCentroCostosCompras(Nothing)
      End Get
   End Property
   Public Shared ReadOnly Property PermiteCambiarCentroCostosCompras(da As Datos.DataAccess) As Boolean
      Get
         If da IsNot Nothing Then
            Return Boolean.Parse(New Eniac.Reglas.Parametros(da).GetValorPD(Entidades.Parametro.Parametros.PERMITECAMBIARCENTROCOSTOSCOMPRAS.ToString(), Boolean.FalseString))
         Else
            Return Boolean.Parse(New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PERMITECAMBIARCENTROCOSTOSCOMPRAS.ToString(), Boolean.FalseString))
         End If
      End Get
   End Property

   Public Shared ReadOnly Property PermiteCambiarCentroCostosCaja() As Boolean
      Get
         Return PermiteCambiarCentroCostosCaja(Nothing)
      End Get
   End Property
   Public Shared ReadOnly Property PermiteCambiarCentroCostosCaja(da As Datos.DataAccess) As Boolean
      Get
         If da IsNot Nothing Then
            Return Boolean.Parse(New Eniac.Reglas.Parametros(da).GetValorPD(Entidades.Parametro.Parametros.PERMITECAMBIARCENTROCOSTOSCAJA.ToString(), Boolean.FalseString))
         Else
            Return Boolean.Parse(New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PERMITECAMBIARCENTROCOSTOSCAJA.ToString(), Boolean.FalseString))
         End If
      End Get
   End Property

   Public Shared ReadOnly Property PermiteCambiarCentroCostosBanco() As Boolean
      Get
         Return PermiteCambiarCentroCostosBanco(Nothing)
      End Get
   End Property
   Public Shared ReadOnly Property PermiteCambiarCentroCostosBanco(da As Datos.DataAccess) As Boolean
      Get
         If da IsNot Nothing Then
            Return Boolean.Parse(New Eniac.Reglas.Parametros(da).GetValorPD(Entidades.Parametro.Parametros.PERMITECAMBIARCENTROCOSTOSBANCO.ToString(), Boolean.FalseString))
         Else
            Return Boolean.Parse(New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PERMITECAMBIARCENTROCOSTOSBANCO.ToString(), Boolean.FalseString))
         End If
      End Get
   End Property

   Public Shared ReadOnly Property PermiteCambiarCentroCostosVentas() As Boolean
      Get
         Return PermiteCambiarCentroCostosVentas(Nothing)
      End Get
   End Property
   Public Shared ReadOnly Property PermiteCambiarCentroCostosVentas(da As Datos.DataAccess) As Boolean
      Get
         If da IsNot Nothing Then
            Return Boolean.Parse(New Eniac.Reglas.Parametros(da).GetValorPD(Entidades.Parametro.Parametros.PERMITECAMBIARCENTROCOSTOSVENTAS.ToString(), Boolean.FalseString))
         Else
            Return Boolean.Parse(New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PERMITECAMBIARCENTROCOSTOSVENTAS.ToString(), Boolean.FalseString))
         End If
      End Get
   End Property


   Public Shared ReadOnly Property ContabilidadCuentaVentas() As Long
      Get
         Return ContabilidadCuentaVentas(Nothing)
      End Get
   End Property
   Public Shared ReadOnly Property ContabilidadCuentaVentas(da As Datos.DataAccess) As Long
      Get
         If da IsNot Nothing Then
            Return Long.Parse(New Eniac.Reglas.Parametros(da).GetValorPD(Entidades.Parametro.Parametros.CONTABILIDADCUENTAVENTAS, "0"))
         Else
            Return Long.Parse(New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CONTABILIDADCUENTAVENTAS, "0"))
         End If
      End Get
   End Property

   Public Shared ReadOnly Property ContabilidadCuentaCompras() As Long
      Get
         Return ContabilidadCuentaCompras(Nothing)
      End Get
   End Property
   Public Shared ReadOnly Property ContabilidadCuentaCompras(da As Datos.DataAccess) As Long
      Get
         If da IsNot Nothing Then
            Return Long.Parse(New Eniac.Reglas.Parametros(da).GetValorPD(Entidades.Parametro.Parametros.CONTABILIDADCUENTACOMPRAS, "0"))
         Else
            Return Long.Parse(New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CONTABILIDADCUENTACOMPRAS, "0"))
         End If
      End Get
   End Property

   Public Shared ReadOnly Property ContabilidadCuentaRedondeo() As Long
      Get
         Return ContabilidadCuentaRedondeo(Nothing)
      End Get
   End Property
   Public Shared ReadOnly Property ContabilidadCuentaRedondeo(da As Datos.DataAccess) As Long
      Get
         If da IsNot Nothing Then
            Return Long.Parse(New Eniac.Reglas.Parametros(da).GetValorPD(Entidades.Parametro.Parametros.CONTABILIDADCUENTAREDONDEO, "0"))
         Else
            Return Long.Parse(New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CONTABILIDADCUENTAREDONDEO, "0"))
         End If
      End Get
   End Property

   Public Shared ReadOnly Property ContabilidadCuentaSecundariaProducto() As Boolean
      Get
         Return ContabilidadCuentaSecundariaProducto(Nothing)
      End Get
   End Property

   Private Shared _contabilidadCuentaSecundariaProducto As Boolean?
   Public Shared ReadOnly Property ContabilidadCuentaSecundariaProducto(da As Datos.DataAccess) As Boolean
      Get
         If Not _contabilidadCuentaSecundariaProducto.HasValue Then
            If da IsNot Nothing Then
               _contabilidadCuentaSecundariaProducto = New Eniac.Reglas.Parametros(da).GetValorPD(Entidades.Parametro.Parametros.CONTABILIDADCUENTASECUNDARIAPRODUCTO, Boolean.FalseString) = Boolean.TrueString
            Else
               _contabilidadCuentaSecundariaProducto = New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CONTABILIDADCUENTASECUNDARIAPRODUCTO, Boolean.FalseString) = Boolean.TrueString
            End If
         End If
         Return _contabilidadCuentaSecundariaProducto.Value
      End Get
   End Property

   Public Shared ReadOnly Property ContabilidadCuentaSecundariaCategoria() As Boolean
      Get
         Return ContabilidadCuentaSecundariaCategoria(Nothing)
      End Get
   End Property
   Public Shared ReadOnly Property ContabilidadCuentaSecundariaCategoria(da As Datos.DataAccess) As Boolean
      Get
         If da IsNot Nothing Then
            Return New Eniac.Reglas.Parametros(da).GetValorPD(Entidades.Parametro.Parametros.CONTABILIDADCUENTASECUNDARIACATEGORIA, Boolean.FalseString) = Boolean.TrueString
         Else
            Return New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CONTABILIDADCUENTASECUNDARIACATEGORIA, Boolean.FalseString) = Boolean.TrueString
         End If
      End Get
   End Property

   Public Shared ReadOnly Property ContabilidadFormatoExportacion() As String
      Get
         Return ContabilidadFormatoExportacion(Nothing)
      End Get
   End Property
   Public Shared ReadOnly Property ContabilidadFormatoExportacion(da As Datos.DataAccess) As String
      Get
         If da IsNot Nothing Then
            Return New Eniac.Reglas.Parametros(da).GetValorPD(Entidades.Parametro.Parametros.CONTABILIDADFORMATOEXPORTACION, String.Empty)
         Else
            Return New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CONTABILIDADFORMATOEXPORTACION, String.Empty)
         End If
      End Get
   End Property

   Public Shared ReadOnly Property ContabilidadRedondeoImporteMaximo() As Decimal
      Get
         Return ContabilidadRedondeoImporteMaximo(Nothing)
      End Get
   End Property
   Public Shared ReadOnly Property ContabilidadRedondeoImporteMaximo(da As Datos.DataAccess) As Decimal
      Get
         If da IsNot Nothing Then
            Return Decimal.Parse(New Eniac.Reglas.Parametros(da).GetValorPD(Entidades.Parametro.Parametros.CONTABILIDADREDONDEOIMPORTEMAXIMO, "0.1"))
         Else
            Return Decimal.Parse(New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CONTABILIDADREDONDEOIMPORTEMAXIMO, "0.1"))
         End If
      End Get
   End Property

   Public Enum FormatoExportacion As Integer
      SAE = 1
      SAEv2 = 2
   End Enum


   Public Shared ReadOnly Property CerrarPeriodoConAsientoPermitir() As Entidades.Publicos.PermitirNoPermitir
      Get
         Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.CONTABILIDADCERRARPERIODOCONASIENTOPERMITIR, Entidades.Publicos.PermitirNoPermitir.PERMITIR.ToString()).
                     StringToEnum(Entidades.Publicos.PermitirNoPermitir.PERMITIR)
      End Get
   End Property

End Class