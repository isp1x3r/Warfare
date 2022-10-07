using System.Linq;
using System.Text;

namespace Mercenary.Network
{
    public static class Extensions
    {
        public static string WriteCString(string @string, int length)
        {
            // Do we need to fill the remaining bytes?
            if(length - @string.Length > 0)
            {
                StringBuilder _builder = new StringBuilder(@string);
                byte[] padding = new byte[length];
                _builder.Append(Encoding.ASCII.GetString(padding));
                return _builder.ToString();
            }
            return @string;
        }
    }
}
