using banking_app;
using System;

namespace BankingAppConsole
{
    public class Transferencia
    {
        public Usuario Remetente { get; set; }
        public Usuario Destinatario { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }

        public Transferencia(Usuario remetente, Usuario destinatario, decimal valor)
        {
            Remetente = remetente;
            Destinatario = destinatario;
            Valor = valor;
            Data = DateTime.Now;
        }
    }
}
