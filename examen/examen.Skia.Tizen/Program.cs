using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace examen.Skia.Tizen
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new examen.App(), args);
            host.Run();
        }
    }
}
