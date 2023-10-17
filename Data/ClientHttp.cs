namespace InicioProyectoClasesCRUD.Data
{
    public class ClientHttp
    {
        public HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5120/") // esto se usa para porque te permite simplificar tus solicitudes posteriores al no tener que especificar la dirección base completa en cada solicitud
            };

            // Configura otros parámetros del cliente HTTP si es necesario

            return httpClient;
        }
    }
}
