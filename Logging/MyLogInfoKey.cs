using NuciLog.Core;

namespace ApiScannerLogger.Logging
{
    public sealed class MyLogInfoKey : LogInfoKey
    {
        MyLogInfoKey(string name) : base(name) { }

        public static LogInfoKey Headers => new MyLogInfoKey(nameof(Headers));
        public static LogInfoKey IpAddress => new MyLogInfoKey(nameof(IpAddress));
        public static LogInfoKey Method => new MyLogInfoKey(nameof(Method));
        public static LogInfoKey Path => new MyLogInfoKey(nameof(Path));
        public static LogInfoKey QueryString => new MyLogInfoKey(nameof(QueryString));
    }
}
