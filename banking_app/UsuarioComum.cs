using banking_app;

namespace BankingAppConsole
{
    public class UsuarioComum : Usuario
    {
        public UsuarioComum(string nomeCompleto, string cpf, string email, string senha)
            : base(nomeCompleto, cpf, email, senha) { }

        public void EnviarTransferencia(Usuario destinatario, decimal valor)
        {
            if (Saldo >= valor)
            {
                Saldo -= valor;
                destinatario.ReceberTransferencia(valor);
            }
            else
            {
                throw new InvalidOperationException("Saldo insuficiente para realizar a transferência.");
            }
        }

        public override void ReceberTransferencia(decimal valor)
        {
            Saldo += valor;
        }
    }
}
