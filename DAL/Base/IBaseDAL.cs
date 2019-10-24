using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Base
{
    public interface IBaseDAL<TEntity> where TEntity : class
    {

        #region 1.0 增
        void Add(TEntity model);
        #endregion

        #region 2.0 删
        void Delete(TEntity model);
        #endregion

        #region 3.0 改
        void Update(TEntity model, string[] propertyNames);
        #endregion

        #region 4.0.1 根据条件查询
        List<TEntity> QueryWhere(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        TEntity QueryEntity(Expression<Func<TEntity, bool>> where);
        #endregion

        #region 5.0 统一保存
        /// <summary>
        /// 统一将EF容器对象中的所有代理类生成相应的sql语句发给db服务器执行
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
        #endregion

    }
}
