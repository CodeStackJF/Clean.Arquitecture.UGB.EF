using System.Security.Claims;

namespace UGB.Services.Helper
{
    /// <summary>
    /// Extensión para la entidad User para leer las propiedades
    /// </summary>
    public static class SessionHelper
    {
        public static dynamic GetProperty(this ClaimsPrincipal claimsPrincipal, string propertyName, Type T)
        {
            return Convert.ChangeType(claimsPrincipal.FindFirstValue(propertyName), T)!;
        }

        public static dynamic GetProperty(this ClaimsPrincipal claimsPrincipal, string propertyName)
        {
            return claimsPrincipal.FindFirstValue(propertyName)!.ToString();
        }
    }
}