namespace banking_app
{
    public abstract class Usuario
    {
        public string NomeCompleto { get; set; }
        public string CPF { get; set; } // Ou CNPJ para lojistas
        public string Email { get; set; }
        public string Senha { get; set; }
        public decimal Saldo { get; set; }

        public Usuario(string nomeCompleto, string cpf, string email, string senha)
        {
            NomeCompleto = nomeCompleto;
            CPF = cpf;
            Email = email;
            Senha = senha;
            Saldo = 0;
        }

        public abstract void ReceberTransferencia(decimal valor);
    }
}
