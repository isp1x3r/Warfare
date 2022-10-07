using System.Linq;
using System.Text;

namespace Mercenary.Network
{
    public static class Extensions
    {
        public static string WriteCString(string @string, int length)
        {
            // Do we need to fill the remaining bytes?
            int remaining = length - @string.Length;
            if(remaining > 0)
            {
                StringBuilder _builder = new StringBuilder(@string, length);
                byte[] padding = new byte[remaining];
                _builder.Append(Encoding.ASCII.GetString(padding));
                return _builder.ToString();
            }
            return @string;
        }
    }
}
