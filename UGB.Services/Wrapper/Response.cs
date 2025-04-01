namespace UGB.Services.Wrapper
{
    public class Response
    {
        /// <summary>
        /// Estructura estándar de respuesta de errores
        /// </summary>
        private bool Success { get; set; } = false;
        public Dictionary<string, List<string>> ValidationErrors { get; set; } = new Dictionary<string, List<string>>();
        public dynamic Data { get; set; } = new {};
        public string Message { get; set; } = "";
        public int StatusCode { get; set; }
    }
}