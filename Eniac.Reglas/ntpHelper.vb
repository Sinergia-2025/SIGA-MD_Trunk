Option Strict On
Option Explicit On
Imports System.Net
Imports System.Net.Sockets
Friend Class ntpHelper
   Friend Shared Function GetNetworkTime(ntpServer As String) As DateTime

      ''default Windows time server
      'Const ntpServer As String = "time.afip.gov.ar"

      '' NTP message size - 16 bytes of the digest (RFC 2030)
      Dim ntpData(47) As Byte

      ''Setting the Leap Indicator, Version Number and Mode values
      ntpData(0) = &H1B ''LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

      Dim addresses As System.Net.IPAddress() = Dns.GetHostEntry(ntpServer).AddressList

      ''The UDP port number assigned to NTP is 123
      Dim ipEndPoint As IPEndPoint = New IPEndPoint(addresses(0), 123)
      ''NTP uses UDP
      Dim socket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)

      socket.Connect(ipEndPoint)

      ''Stops code hang if NTP is blocked
      socket.ReceiveTimeout = 3000

      socket.Send(ntpData)
      socket.Receive(ntpData)
      socket.Close()

      ''Offset to get to the "Transmit Timestamp" field (time at which the reply 
      ''departed the server for the client, in 64-bit timestamp format."
      'Const serverReplyTime As Byte = 40


      Dim offsetTransmitTime As Byte = 40
      Dim intpart As ULong = 0
      Dim fractpart As ULong = 0

      For i As Integer = 0 To 3
         intpart = Convert.ToUInt64(256 * intpart + ntpData(offsetTransmitTime + i))
      Next

      For i As Integer = 4 To 7
         fractpart = Convert.ToUInt64(256 * fractpart + ntpData(offsetTransmitTime + i))
      Next

      Dim milliseconds As ULong = Convert.ToUInt64((intpart * 1000 + (fractpart * 1000) / &H100000000L))

      ''**UTC** time
      Dim networkDateTime As DateTime = (New DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds(Convert.ToInt64(milliseconds))

      Return networkDateTime.ToLocalTime()
   End Function
End Class
