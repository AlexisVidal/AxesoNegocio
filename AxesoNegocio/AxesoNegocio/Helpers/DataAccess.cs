using Axeso_BE;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AxesoNegocio.Helpers
{
    public class DataAccess
    {
        #region Nodejs
        //string urlnodejs = "http://190.117.184.215:5300";
        string urlnodejs = "http://localhost:5300";


        public async Task<Usuarios> ValidaLogueo(Usuarios usuario)
        {
            Usuarios entidadfound = new Usuarios();
            try
            {
                HttpClient client = new HttpClient();
                var connectionInfo = urlnodejs;
                client.BaseAddress = new Uri(connectionInfo);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string serializedObject = JsonConvert.SerializeObject(usuario);
                HttpContent contentPost = new StringContent(serializedObject, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("usuario/login", contentPost);
                if (response.IsSuccessStatusCode && response.RequestMessage != null)
                {
                    JArray usuarioe = JArray.Parse(await response.Content.ReadAsStringAsync());
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    settings.MissingMemberHandling = MissingMemberHandling.Ignore;
                    if (usuarioe != null && usuarioe.Count > 0)
                    {
                        var _lusuario = JsonConvert.DeserializeObject<List<Usuarios>>(usuarioe.ToString(), settings);
                        if (_lusuario.Any())
                        {
                            entidadfound = _lusuario.FirstOrDefault();
                        }
                    }
                }
                return entidadfound;
            }
            catch (Exception ex)
            {
                return entidadfound;
            }
        }

        public async Task<Usuarios> RecoverPassUsuario(Usuarios usuario)
        {
            Usuarios entidadfound = new Usuarios();
            try
            {
                HttpClient client = new HttpClient();
                var connectionInfo = urlnodejs;
                client.BaseAddress = new Uri(connectionInfo);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string serializedObject = JsonConvert.SerializeObject(usuario);
                HttpContent contentPost = new StringContent(serializedObject, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("usuario/updatepassusuarios", contentPost);
                if (response.IsSuccessStatusCode && response.RequestMessage != null)
                {
                    JArray usuarioe = JArray.Parse(await response.Content.ReadAsStringAsync());
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    settings.MissingMemberHandling = MissingMemberHandling.Ignore;
                    if (usuarioe != null && usuarioe.Count > 0)
                    {
                        var _lusuario = JsonConvert.DeserializeObject<List<Usuarios>>(usuarioe.ToString(), settings);
                        if (_lusuario.Any())
                        {
                            entidadfound = _lusuario.FirstOrDefault();
                        }
                    }
                }
                return entidadfound;
            }
            catch (Exception ex)
            {
                return entidadfound;
            }
        }

        #endregion
    }
}
