using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using cliente.servicioChat;


namespace cliente
{
    public partial class FormCliente : Form
    {
        // Lista local de ususarios conerctados
        public List<string> listConectados;
        // referncia local del servicio web
        private Service1 servidor;
        //puerto local inicia en 0 
        public int localPort = 0;
        // Hilo que escucha mensajes entrantes
        private Thread listener;
        // Varibale boolean que maneja localmente el estado del cliente
        private bool conectado = false;
        // Ip del cliente se asigna al conectar
        public string miIp;
        // Nombre del cliente
        public string miNombre;
        // Nombre de la sala, toda conexion inicial entra en la sala principal
        private string miSala = "Sala Principal";

        //Conversaciones uno a uno
        //public Dictionary<string, Form2> unoauno;
        public Dictionary<string, Thread> winThreads;
        public List<string> usuariosChat;
        private int cantP = 0;

        //contador
        int id = 1000;
        
        //DATOS PARA CONEXION DE BD "SD"//
       

        public FormCliente()
        {
            //Iniciar variables conversaciones privadas
            //unoauno = new Dictionary<string, Form2>();
            winThreads = new Dictionary<string, Thread>();
            usuariosChat = new List<string>();

            //Iniciar servicio
            servidor = new Service1();

            InitializeComponent();
        }

     
        private void conectarBoton_Click(object sender, EventArgs e)
        {
            this.preConect();
        }

        private void preConect()
        {
            //Determinar de forma local si el nombre y contraseña son validos
            string nombre = usuario.Text;
            string pass = contrasena.Text;





            //Comprobaciones//

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("No puede dejar vacío el campo de nombre.");
            }
            else
            {
                if (string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("No puede dejar vacío el campo de contraseña.");
                }
                else
                {
                    conectar(nombre, pass);

                    //Hacer qe el usuario y el pass no pueda ser editados
                }

            }
        }

        public int conectar(string user, string pass)
        {
            //conexion con el WS
            miNombre = user;
            /*Paquete ans = servidor.conectarCliente(user, pass);
            if (ans != null)
            {
                miIp = ans.ip;
                localPort = ans.puerto;
                listConectados = ans.cConectados.ToList();
                refresh(true, ans.Mensaje);
                listener = new Thread(escuchando);
                listener.IsBackground = true;
                listener.Start();
                desconectarBoton.Enabled = true;
                mensaje.Enabled = true;
                enviarBoton.Enabled = true;
                chat.Enabled = true;
                participantes.Enabled = true;
                conectarBoton.Enabled = false;
                usuario.Enabled = false;
                contrasena.Enabled = false;
                ayudantesSalaBoton.Enabled = false;
                conectado = true;
            }*/
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
