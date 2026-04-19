using NuciLog.Core;

namespace ApiScannerLogger.Logging
{
    public sealed class MyOperation : Operation
    {
        MyOperation(string name) : base(name) { }

        public static Operation HttpRequest => new MyOperation(nameof(HttpRequest));
    }
}
