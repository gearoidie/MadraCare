using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MadraCare.Services.Kennel.Store
{
    public interface IKennelRepo
    {
        Task<IEnumerable<Models.Kennel>> GetAllKennels();
        Task<Models.Kennel> GetKennel(Guid id);
        Task<Models.Kennel> Add(Models.Kennel newKennel);
        Task<bool> Update(Models.Kennel newKennel);
        Task<bool> Delete(Guid id);
    }
}