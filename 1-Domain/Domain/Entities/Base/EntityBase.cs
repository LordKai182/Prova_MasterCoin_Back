using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Base
{
    public abstract class EntityBase : Notifiable
    {

        public EntityBase()
        {
            this.DataCadastro = DateTime.Now;
        }


        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }


    }
}
