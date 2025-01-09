using System;

namespace AppFwk.Generic.Ftp
{
    public class BytesUploadedEventArgs : EventArgs
    {
        public BytesUploadedEventArgs()
        {

        }
        public BytesUploadedEventArgs(Int64 loadedBytes, Int64 bufferSize, Int64 totalBytes)
        {
            LoadedBytes = loadedBytes;
            BufferSize = bufferSize;
            TotalBytes = totalBytes;
        }
        public Int64 LoadedBytes { get; set; }
        public Int64 BufferSize { get; set; }
        public Int64 TotalBytes { get; set; }
        public Decimal Percentage
        {
            get
            {
                return (Convert.ToDecimal(LoadedBytes) / Convert.ToDecimal(TotalBytes)) * 100;
            }
        }
        public Int32 PercentageAsInteger
        {
            get
            {
                return Decimal.ToInt32(Math.Round(Percentage, 0));
            }
        }
    }
}