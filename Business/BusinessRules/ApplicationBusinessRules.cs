using DataAccess.Repositories;

namespace Business.BusinessRules
{
    public class ApplicationBusinessRules(IApplicationRepository _repository)
    {
        

        public async Task CheckIfDuplicateExists(int applicantId, int bootcampId)
        {
           var exists = await _repository.GetAllAsync();
        if (exists.Any(x => x.ApplicantId == applicantId && x.BootcampId == bootcampId))
            throw new Exception("Bu kullanıcı zaten bu Bootcamp'e başvurmuş."); }
    }

}
