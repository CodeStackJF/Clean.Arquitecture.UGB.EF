using System.Text;

namespace UGB.Application.Helper
{
    public static class StringHelper
    {
        public static string RemoveSpecialCharacters(this string str)
        {
            if (str == "") return "";
			StringBuilder sb = new StringBuilder();
			foreach (char c in str)
			{
				if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
				{
					sb.Append(c);
				}
			}
			return sb.ToString();
        }
    }
}