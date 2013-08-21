using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cliente
{
    class Usuario
    {
        public String user;
        public String ip;
        public int estadoConectado;

        public Usuario()
        {
            this.user = null;
            this.ip = null;
            this.estadoConectado = 0;
        }

        public Usuario(String nick, String ip, int conectadoEst)
        {
            this.user = nick;
            this.ip = ip;
            this.estadoConectado = conectadoEst;
        }
    }
}
