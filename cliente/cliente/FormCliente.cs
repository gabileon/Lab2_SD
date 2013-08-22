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
       

        //Presiona registrar
        private void button1_Click(object sender, EventArgs e)
        {

           FormRegistro vistaRegistro = new FormRegistro();
           vistaRegistro.Show();
           


        }
    }
}
