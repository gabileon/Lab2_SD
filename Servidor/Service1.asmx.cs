using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace Servidor
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class Service1 : System.Web.Services.WebService
    {
        //Diccionario de clientes registrados
        private static Dictionary<string, Cliente> listaClientes = new Dictionary<string, Cliente>();
        //Diccionario de clientes por sala
        private static Dictionary<string, List<Cliente>> salasClientes = new Dictionary<string, List<Cliente>>();
        //Lista de clientes conectados
        private static List<Cliente> clientesConectados = new List<Cliente>();
        //lista de los nombres de los clientes conectados
        private static List<string> nombreClientesConectados = new List<string>();
        //Puerto base a partir del cual se conectan los clientes
        private static int numeroDePuerto = 13131;

        [WebMethod]
        public Paquete conectarCliente(string nombre, string pass)
        {
            numeroDePuerto++;
            Cliente reg;
            //Validar ingreso del cliente
            if (listaClientes.TryGetValue(nombre, out reg))
            {
                if (clientesConectados.Contains(reg))
                {
                    throw new Exception("Ya existe un usuario con esta cuenta");
                }
                if (pass != reg.pass)
                {
                    throw new Exception("Usuario o contraseña incorrectos");
                }
                listaClientes[nombre].ip = GetIP4Address();
            }
            else
            {
                string direccion = GetIP4Address();
                reg = new Cliente(nombre, pass, direccion, numeroDePuerto);
                listaClientes.Add(nombre, reg);
            }

            clientesConectados.Add(reg);
            nombreClientesConectados.Add(reg.name);

            //Asiganción del Cliente a la sala
            string nombreSala = "Sala Principal";
            List<Cliente> c = new List<Cliente>();
            if (!salas.Contains(nombreSala))
            {
                salas.Add(nombreSala);
                c.Add(listaClientes[nombre]);
                salasClientes.Add(nombreSala, c);
            }
            else
            {
                c = salasClientes[nombreSala];
                c.Add(listaClientes[nombre]);
                salasClientes[nombreSala] = c;
            }
            //fin Asiganción del Cliente a la sala          
            //Mensaje a enviar
            string msg = getTimestamp(DateTime.Now) + " - " + nombre + " se ha conectado.";
            //Definición de la informacion que se entregará al usuario como respuesta
            Paquete ans = new Paquete();
            ans.Mensaje = msg;
            ans.ip = reg.ip;
            ans.puerto = numeroDePuerto;
            ans.cConectados = nombreClientesConectados;
            ans.salas = salas;

            //Enviar información a usuarios conectados y retornar paquete
            Broadcast(msg, nombre);
            return ans;
        }


        [Serializable]
        public class Paquete
        {
            public string Mensaje { get; set; }
            public int puerto { get; set; }
            public string ip { get; set; }
            public List<string> cConectados { get; set; }
            public List<string> salas { get; set; }
            public Paquete() { }
            public Paquete(string msg) { this.Mensaje = msg; }
            public Paquete(string msg, List<string> l, List<string> li)
            {
                this.Mensaje = msg;
                this.cConectados = l;
                this.salas = li;
            }
        }

        [Serializable]
        public class Cliente
        {
            public int puerto { get; set; }
            public string name { get; set; }
            public string pass { get; set; }
            public string ip { get; set; }
            public Cliente() { }
            public Cliente(string name, string pass, string ip, int puerto)
            {
                this.name = name;
                this.ip = ip;
                this.pass = pass;
                this.puerto = puerto;
            }
        }
   
    }
}