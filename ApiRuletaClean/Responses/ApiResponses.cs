using RuletaClean.Core.CustomEntities;

namespace RuletaClean.Api.Responses
{
    public class ApiResponses<T>
    {
        public ApiResponses(T data)
        {
            Data = data;
        }
        public T Data { get; set; }

        public MetaData Meta { get; set; }
    }
}
