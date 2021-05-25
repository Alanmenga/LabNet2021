using Mengassini.EF.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mengassini.EF.Logic
{
    public class UsuarioLogic
    {
        public async Task<List<Usuario>> GetUsuarios()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/users");
            List<Usuario> listaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
            return listaUsuarios;
        }
    }
}
