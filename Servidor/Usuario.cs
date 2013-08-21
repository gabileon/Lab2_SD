using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servidor
{
    public class Usuario
    {
        public String user;
        public String ip;

        public Usuario()
        {
            this.user = null;
            this.ip = null;
        }

        public Usuario(String nick, String ip)
        {
            this.user = nick;
            this.ip = ip;
        }
    }
}