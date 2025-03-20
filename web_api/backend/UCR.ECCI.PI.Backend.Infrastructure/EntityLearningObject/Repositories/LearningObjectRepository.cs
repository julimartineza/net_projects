using Microsoft.EntityFrameworkCore;
using UCR.ECCI.PI.Backend.Domain.LearningObjects.Entities;
using UCR.ECCI.PI.Backend.Domain.LearningObjects.Repositories;

namespace UCR.ECCI.PI.Backend.Infrastructure.EntityLearningObject.Repositories
{
    internal class LearningObjectRepository : ILearningObjectRepository
    {
        private DatabaseContext _databaseContext { get; set; }

        /// <summary>
        /// Learning space repository constructor.
        /// </summary>
        /// <param name="databaseContext"></param>
        public LearningObjectRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        ///  Implements the method in the ILearningObjecteRepository interface to list all learning objects
        /// </summary>
        /// <returns>List of LearningObject objects</returns>
        public async Task<IEnumerable<LearningObject>> ListLearningObjectsAsync()
        {
            var learningObject = await _databaseContext.LearningObjects.ToListAsync();

            return learningObject.AsEnumerable();
        }

        /// <summary>
        /// Implements the method in the ILearningObjectRepository interface to set a learning object.
        /// </summary>
        /// <param name="learningObject"></param>
        /// <returns>0 when successful</returns>
        public async Task<int> SetLearningObjectAsync(LearningObject learningObject)
        {
            int success = 0;
            try
            {
                _databaseContext.LearningObjects.Add(learningObject);
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

        public async Task<IEnumerable<LearningObject>> GetLearningObjectsAsync(string idLS)
        {
            return await _databaseContext.GetLearningObjectByIdLS(idLS)
                        .ToListAsync();
        }

        public async Task<int> EditLearningObjectAsync(LearningObject learningObject)
        {
            try
            {
                var existingLearningObject = await _databaseContext.LearningObjects
                    .FirstOrDefaultAsync(lo => lo.Id == learningObject.Id);

                if (existingLearningObject == null)
                {
                    // Lanzar una excepción específica si no se encuentra el objeto
                    throw new KeyNotFoundException($"Learning object with ID {learningObject.Id} not found in the database.");
                }

                _databaseContext.LearningObjects.Update(learningObject);
                await _databaseContext.SaveChangesAsync();
                return 0;
            }
            catch (Exception e)
            {
                throw new Exception("An unexpected error occurred.", e);
            }
        }
    }
}
