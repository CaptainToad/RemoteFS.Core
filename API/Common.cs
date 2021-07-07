using System.Runtime.CompilerServices;

namespace API
{
    public class Common
    {
        public static string GetCaller([CallerMemberName] string caller = null)
        {
            return caller;
        }
    }
}
