using Microsoft.EntityFrameworkCore;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Entities;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Repositories;

namespace UCR.ECCI.PI.Backend.Infrastructure.EntityLearningSpace.Repositories
{
    internal class LearningSpaceRepository : ILearningSpaceRepository
    {
        private DatabaseContext _databaseContext { get; set; }

        /// <summary>
        /// Learning space repository constructor.
        /// </summary>
        /// <param name="databaseContext"></param>
        public LearningSpaceRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        ///  Implements the method in the ILearningSpaceRepository interface to list all learning spaces by buildingId.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of LearninSpaces objects</returns>
        public async Task<IEnumerable<LearningSpace>> ListLearningSpacesAsync(string id)
        {
            var learningSpaces = await _databaseContext.GetLearningSpacesByBuildingId(id)
                        .ToListAsync();

            return learningSpaces.AsEnumerable();
        }

        /// <summary>
        /// Implements the method in the ILearningSpaceRepository interface to set a learning space.
        /// </summary>
        /// <param name="learningSpace"></param>
        /// <returns>0 when successful</returns>
        public async Task<int> SetLearningSpaceAsync(LearningSpace learningSpace)
        {
            int success = 0;
            try
            {
                _databaseContext.LearningSpace.Add(learningSpace);
                await _databaseContext.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database update error: {dbEx.Message}");
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
                return 2;
            }
            return success;
        }
    }
}