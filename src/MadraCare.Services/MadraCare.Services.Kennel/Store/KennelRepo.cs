using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MadraCare.Models;
using Microsoft.EntityFrameworkCore;

namespace MadraCare.Services.Kennel.Store
{
    public class KennelRepo : IKennelRepo
    {
        private readonly KennelDbContext _kennelDbContext;

        public KennelRepo (KennelDbContext kennelDbContext)
        {
            _kennelDbContext = kennelDbContext;
        }
        public async Task<Models.Kennel> Add (Models.Kennel newKennel)
        {
            _kennelDbContext.Add (newKennel);
            var recordsAdded = await _kennelDbContext.SaveChangesAsync ();
            if (recordsAdded > 0)
                return newKennel;

            return null;
        }

        public async Task<bool> Delete (Guid id)
        {
            var kennel = await _kennelDbContext.Kennels.FindAsync (id);
            if (kennel != null)
            {
                _kennelDbContext.Remove (kennel);
            }

            var recordsDeleted = await _kennelDbContext.SaveChangesAsync ();
            return recordsDeleted > 0;
        }

        public async Task<IEnumerable<Models.Kennel>> GetAllKennels ()
        {
            return await _kennelDbContext.Kennels.AsNoTracking ().ToListAsync ();
        }

        public async Task<Models.Kennel> GetKennel (Guid id)
        {
            return await _kennelDbContext.Kennels.FindAsync (id);
        }

        public async Task<bool> Update (Models.Kennel newKennel)
        {
            var kennel = await _kennelDbContext.Kennels.FindAsync (newKennel.KennelId);
            if (kennel == null)
                return false;

            kennel.Name = newKennel.Name;
            _kennelDbContext.Kennels.Update (kennel);

            return (await _kennelDbContext.SaveChangesAsync ()) > 0;
        }
    }
}