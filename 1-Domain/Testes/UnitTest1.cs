using Domain.Entities.Entity;
using Infra.Repositories.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit.Sdk;

namespace Testes
{
    [TestClass]
    public class UnitTest1
    {
        MasterCoinContext _context;

        /// <summary>
        /// este teste foi escrito para nao passar na validacao de Notifications
        /// </summary>
        [TestMethod]
        
        public void FailTesteCadastroUsuarioSemBancoDeDados()
        {
            var _usuario = new Usuario("mastercoin", Convert.ToDateTime("17/10/1986"), "mastercoin", "emaile.com");

            Assert.AreEqual(0, _usuario.Notifications.Count, Environment.NewLine + String.Join(Environment.NewLine, _usuario.Notifications.Select( t => t.Message)));

        }

        /// <summary>
        /// teste feito para verificar se a data atual dd/MM
        /// bate com o aniversario do Usuario
        /// </summary>

        [TestMethod]

        public void TesteVerificaASniversarioUsuario()
        {
            var _usuario = new Usuario("mastercoin", Convert.ToDateTime("17/10/1986"), "mastercoin", "emaile.com");

            Assert.AreEqual(DateTime.Now.ToString("dd/MM"), _usuario.DataNascimento.ToString("dd/MM"));

        }

        /// <summary>
        /// aqui ele cadastrara somente um usuario na lista que estara validado
        /// </summary>
        [TestMethod]
        public void TesteCadastroUsuarioComBancoDeDados()
        {
            _context = new MasterCoinContext();
            
            var _usuarioInvalido = new Usuario("mastercoin", Convert.ToDateTime("17/10/1986"), "mastercoin", "emaile.com");
            var _usuarioValido = new Usuario("henrique", Convert.ToDateTime("17/10/1986"), "henrique", "email@teste.com");

            List<Usuario> listaUsuarios = new List<Usuario>() { _usuarioInvalido, _usuarioValido };

            foreach (Usuario usuario in listaUsuarios)
            {
                if(usuario.Notifications.Count == 0)
                {
                    _context.Add(usuario);
                    _context.SaveChanges();
                }
            }
            


        }

        /// <summary>
        /// teste de conversao de Dollar para Real
        /// API Usada: https://economia.awesomeapi.com.br
        /// </summary>
        [TestMethod]
        public void TesteConversaoRealEmDolar()
        {
            var valor = new Cotacao((float)1.20);

            Assert.AreNotEqual(0, valor.valor, String.Format(" O valor convertido de: {0} em real e de: {1} ", (float)1.20, valor.valor));
        }
            
   



    }
}
