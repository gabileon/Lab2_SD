using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServicioChat = cliente.servicioChat

namespace cliente
{
    class Comunicacion
    {
        static protected ServicioChat.Service1 Servicio = new ServicioChat.Service1();
        //----------------------------------------------------------------------------------------------
        public int login(String user, String pass, String ip)
        {
            // Método que permite utilizar el Servicio "login", retornando de forma directa lo recibido
            // como retorno del WebService, con los parámetros capturados a través del Form "Inicio".
            // De fallar la operación, retorna un valor que pueda ser identificado por el cliente como tal.
            try
            {
                return Servicio.login(user, pass, ip);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return -1;
            }
        }
        //----------------------------------------------------------------------------------------------
        public int logout(String user)
        {
            // Método que permite utilizar el Servicio "logout", retornando de forma directa lo recibido
            // como retorno del WebService, con los parámetros capturados a través del Form "Principal".
            // De fallar la operación, retorna un valor que pueda ser identificado por el cliente como tal.
            try
            {
                return Servicio.logout(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return -1;
            }
        }
        //----------------------------------------------------------------------------------------------
        public int RegistrarChat(String user, String pass)
        {
            // Método que permite utilizar el Servicio "registrar", retornando de forma directa lo recibido
            // como retorno del WebService, con los parámetros capturados a través del Form "Registrar".
            // De fallar la operación, retorna un valor que pueda ser identificado por el cliente como tal.
            try
            {
                return Servicio.registrar(user, pass);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return -1;
            }
        }
        //----------------------------------------------------------------------------------------------
        public int agregacontacto(String usuario, String nombre)
        {
            // Método que permite utilizar el Servicio "agregac", retornando de forma directa lo recibido
            // como retorno del WebService, con los parámetros capturados a través del Form "Agregar".
            // De fallar la operación, retorna un valor que pueda ser identificado por el cliente como tal.
            try
            {
                return Servicio.agregac(usuario, nombre);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return -1;
            }
        }
        //----------------------------------------------------------------------------------------------
        public int eliminacontacto(String usuario, String nombre)
        {
            // Método que permite utilizar el Servicio "eliminac", retornando de forma directa lo recibido
            // como retorno del WebService, con los parámetros capturados a través del Form "Agregar".
            // De fallar la operación, retorna un valor que pueda ser identificado por el cliente como tal.
            try
            {
                return Servicio.eliminac(usuario, nombre);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return -1;
            }
        }
        //----------------------------------------------------------------------------------------------
        public String entregacontactos(String usuario)
        {
            // Método que permite utilizar el Servicio "agregac", retornando de forma directa lo recibido
            // como retorno del WebService, con los parámetros capturados a través de los Form "Agregar"
            // y Principal. De fallar la operación, retorna un valor fijo, a pesar de que este no es 
            // controlado como un posible error a nivel de WebService.
            try
            {
                return Servicio.entregac(usuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return "";
            }
        }
        //----------------------------------------------------------------------------------------------
        public String entregaconectados()
        {
            // Método que permite utilizar el Servicio "entregaconect", retornando de forma directa lo
            // recibido como retorno del WebService, con los parámetros capturados a través del Form
            // "Principal". De fallar la operación, retorna un valor fijo, a pesar de que este no es 
            // controlado como un posible error a nivel de WebService.
            try
            {
                return Servicio.entregaconect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return "";
            }
        }
        //----------------------------------------------------------------------------------------------
        public string estaconectado(String user)
        {
            // Método que permite utilizar el Servicio "estaconect", retornando de forma directa lo
            // recibido como retorno del WebService, con los parámetros capturados a través de los Form
            // "Agregar" y "Eliminar". De fallar la operación, retorna un valor fijo, equivalente al
            // controlado por el WebService.
            try
            {
                return Servicio.estaconect(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return "0;Basura";
            }
        }
        //----------------------------------------------------------------------------------------------
        public int retpuerto()
        {
            // Método que permite utilizar el Servicio "estaconect", retornando de forma directa lo
            // recibido como retorno del WebService, con los parámetros capturados a través del Form
            // "Principal". De fallar la operación, retorna un valor fijo, equivalente al controlado 
            // por el WebService.
            try
            {
                return Servicio.entregpuerto();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}
