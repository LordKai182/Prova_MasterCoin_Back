using Domain.Entities.Base;
using prmToolkit.NotificationPattern;
using System;

namespace Domain.Entities.Entity
{
    public class Usuario : EntityBase
    {

        public Usuario(string nome, DateTime dataNascimento, string senha, string email, string nomeUsuario = "")
        {
            NomeUsuario = nomeUsuario;
            Nome = nome;
            DataNascimento = dataNascimento;
            Senha = senha;
            Email = email;

            string _inputstr, _reversestr = string.Empty;
            
            #region NOTIFICATIONS
            
            new AddNotifications<Usuario>(this)
                .IfNullOrEmpty(nome, " O campo [Nome] precisa obrigatorio")
                .IfNull(dataNascimento, " O campo [DataNascimento] precisa obrigatorio")
                .IfNotEmail(email, " O campo [E-mail] nao e valido")
                .IfNullOrEmpty(email, " O campo [E-mail] e obrigatorio")
                .IfNullOrEmpty(senha, " O campo [Nome] e obrigatorio");
            _inputstr = nome;
            if (_inputstr != null)
            {
                for (int i = _inputstr.Length - 1; i >= 0; i--)
                {
                    _reversestr += _inputstr[i].ToString();
                }
                if (_reversestr == _inputstr)
                {
                    AddNotification(_reversestr, "Esta Palavra e um Palimdromo");
                }
               
            }

            if (nome.Contains("mastercoin") || nome.Contains("mc"))
            {
                AddNotification(nome, "Nome de Usuario nao permitido, nao sera permitido nome de usuarios que contenham: 'mastercoin' ou 'mc' ");
            }

            if(dataNascimento.ToString("ddMM") == DateTime.Now.ToString("ddMM"))
            {
                AddNotification("Feliz Aniversario", "Feliz Aniversario");
            }

            #endregion
        }

    

        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}
