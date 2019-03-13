using FoodBook.Domain.Entities;

namespace FoodBook.Infrastructure.DataAccess.QuerySettings
{
    public class Query<TEntity> where TEntity: BaseEntity
    {
        public bool IsTracked { get; set; }

        public FilterSettings<TEntity> FilterSettings { get; set; }

        public SortSettings<TEntity> SortSettings { get; set; }

        public PageSettings PageSettings { get; set; }

        public IncludeSettings<TEntity> IncludeSettings { get; set; }
    }
}