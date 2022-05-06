using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Interfaces.Base
{
    public interface IRepositoryBase<TEntidade, TId>
         where TEntidade : class
         where TId : struct
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="QuetyInterpolade"></param>
        /// <returns></returns>

        IQueryable<TEntidade> FromSqlInterpolatedString(string QuetyInterpolade);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidade"></param>
        /// <param name="id"></param>
        void DetachLocal(TEntidade entidade, Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        TEntidade CriarPeloRequest(Object request);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entidade"></param>
        /// <param name="b"></param>
        /// <param name="ignoraveis"></param>
        /// <returns></returns>
        TEntidade AtualizarRegisto<T>(TEntidade entidade, T b, List<string> ignoraveis);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="where"></param>
        /// <param name="ordem"></param>
        /// <param name="ascendente"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IQueryable<TEntidade> ListarEOrdenadosPor<TKey>(Expression<Func<TEntidade, bool>> where, Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        TEntidade ObterPor(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        bool Existe(Func<TEntidade, bool> where);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="ordem"></param>
        /// <param name="ascendente"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IQueryable<TEntidade> ListarOrdenadosPor<TKey>(Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, object>>[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        TEntidade Adicionar(TEntidade entidade);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        TEntidade Add(TEntidade entidade);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        TEntidade Editar(TEntidade entidade);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidade"></param>
        void Remover(TEntidade entidade);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidades"></param>
        void Remover(IEnumerable<TEntidade> entidades);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidades"></param>
        void AdicionarLista(IEnumerable<TEntidade> entidades);
    }
}
