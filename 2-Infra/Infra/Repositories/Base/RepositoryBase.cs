using Domain.Entities.Base;
using Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Infra.Repositories.Base
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntidade"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public class RepositoryBase<TEntidade, TId> : IRepositoryBase<TEntidade, TId>
          where TEntidade : EntityBase
          where TId : struct
    {
        private readonly MasterCoinContext _context;



        public RepositoryBase(MasterCoinContext context)
        {



            _context = context;



        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return Listar(includeProperties).Where(where);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="where"></param>
        /// <param name="ordem"></param>
        /// <param name="ascendente"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IQueryable<TEntidade> ListarEOrdenadosPor<TKey>(Expression<Func<TEntidade, bool>> where, Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return ascendente ? ListarPor(where, includeProperties).OrderBy(ordem) : ListarPor(where, includeProperties).OrderByDescending(ordem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public TEntidade ObterPor(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return Listar(includeProperties).FirstOrDefault(where);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            if (includeProperties.Any())
            {
                return Listar(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString());
            }



            return _context.Set<TEntidade>().Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            IQueryable<TEntidade> query = _context.Set<TEntidade>();



            if (includeProperties.Any())
            {
                return Include(_context.Set<TEntidade>(), includeProperties);
            }



            return query;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="ordem"></param>
        /// <param name="ascendente"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IQueryable<TEntidade> ListarOrdenadosPor<TKey>(Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return ascendente ? Listar(includeProperties).OrderBy(ordem) : Listar(includeProperties).OrderByDescending(ordem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        public TEntidade Adicionar(TEntidade entidade)
        {
            //var entity = _context.Add<TEntidade>(entidade);
            //_context.SaveChangesAsync();
            //return entity.Entity;
            var entity = _context.Set<TEntidade>().Add(entidade);
            _context.SaveChanges();
            return entity.Entity;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        public TEntidade Add(TEntidade entidade)
        {

            var entity = _context.Set<TEntidade>().Add(entidade);

            return entity.Entity;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        public TEntidade Editar(TEntidade entidade)
        {

            _context.Entry(entidade).State = EntityState.Modified;

            //  _context.SaveChanges();


            return entidade;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidade"></param>
        public void Remover(TEntidade entidade)
        {
            _context.Set<TEntidade>().Remove(entidade);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidades"></param>
        public void Remover(IEnumerable<TEntidade> entidades)
        {
            _context.Set<TEntidade>().RemoveRange(entidades);
        }

        /// <summary>
        /// Adicionar um coleção de entidades ao contexto do entity framework
        /// </summary>
        /// <param name="entidades">Lista de entidades que deverão ser persistidas</param>
        /// <returns></returns>
        public void AdicionarLista(IEnumerable<TEntidade> entidades)
        {
            _context.AddRange(entidades);
            //return _context.Set<TEntidade>().AddRange(entidades);
        }

        /// <summary>
        /// Verifica se existe algum objeto com a condição informada
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool Existe(Func<TEntidade, bool> where)
        {
            return _context.Set<TEntidade>().Any(where);
        }

        /// <summary>
        /// Realiza include populando o objeto passado por parametro
        /// </summary>
        /// <param name="query">Informe o objeto do tipo IQuerable</param>
        /// <param name="includeProperties">Ínforme o array de expressões que deseja incluir</param>
        /// <returns></returns>
        private IQueryable<TEntidade> Include(IQueryable<TEntidade> query, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }



            return query;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="ignoraveis"></param>
        /// <returns></returns>
        public TEntidade AtualizarRegisto<T>(TEntidade a, T b, List<string> ignoraveis)
        {
            foreach (PropertyInfo property in b.GetType().GetProperties())
            {
                var valor = property.GetValue(b, null);
                if (valor != null && valor.ToString() != "0")
                {
                    if (ignoraveis.Count(s => s == property.Name) == 0)
                    {
                        PropertyInfo propClass = a.GetType().GetProperty(property.Name);
                        propClass.SetValue(a, valor, null);
                    }
                }
            }
            return a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public TEntidade CriarPeloRequest(object request)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TEntidade>(request.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidade"></param>
        /// <param name="id"></param>
        public virtual void DetachLocal(TEntidade entidade, Guid id)
        {
            var local = _context.Set<TEntidade>()
                       .Local
                       .FirstOrDefault(entry => entry.Id.Equals(id));
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(entidade).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IQueryable<TEntidade> FromSqlInterpolatedString(string QuetyInterpolade)
        {
            return _context.Set<TEntidade>().FromSql(QuetyInterpolade);
        }
    }
}
