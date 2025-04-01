namespace UGB.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Excepción personalizada para estado 404
        /// </summary>
        public NotFoundException(string message) : base(message)
        {

        }

        public NotFoundException() : base("Recurso no encontrado.")
        {

        }
    }
}