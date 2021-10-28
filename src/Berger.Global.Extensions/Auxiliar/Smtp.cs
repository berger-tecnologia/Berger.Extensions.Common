using System;

namespace Berger.Global.Extensions.Auxiliar
{
    public class Smtp
    {
        #region Properties
        public string Alias { get; set; }
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool SSL { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? Updated { get; set; }
        public bool Deleted { get; set; }
        #endregion
    }
}