using System.Collections.Generic;

namespace TennisPlayerApiAwsLambda.Services.Interfaces
{
    public interface ICrudBaseService<TType>
    {
        IEnumerable<TType> Get();
        TType Get(string id);
        TType Create(TType input);
        void Update(string id, TType input);
        void Remove(TType input);
        void Remove(string id);
    }
}
