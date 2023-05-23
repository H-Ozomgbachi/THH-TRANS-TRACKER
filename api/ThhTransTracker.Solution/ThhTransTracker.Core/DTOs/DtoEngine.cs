namespace ThhTransTracker.Core.DTOs
{
    public static class DtoEngine<T>
    {
        public static PagedList<T> UseListDtoProcessor<U>(PagedList<U> inputList, IMapper mapper)
        {
            var dtos = new List<T>();
            inputList.ForEach(x => { dtos.Add(mapper.Map<T>(x)); });

            return new PagedList<T>(dtos, inputList.TotalCount, inputList.CurrentPage, inputList.PageSize);
        }
    }
}
