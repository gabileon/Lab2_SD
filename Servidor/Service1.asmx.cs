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
            int registrado = buscarCliente(nombre);
        }

        [WebMethod]
        public int buscarCliente(string nombre)
        {

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