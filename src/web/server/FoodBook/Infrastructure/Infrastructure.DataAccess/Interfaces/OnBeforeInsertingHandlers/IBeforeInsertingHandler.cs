namespace FoodBook.Infrastructure.DataAccess.Interfaces.OnBeforeInsertingHandlers
{
    public interface IBeforeInsertingHandler<in TEntity>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Handle(TEntity entity);
    }
}