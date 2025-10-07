using DataAccess.Repositories;
using Entity.Entities;
using System;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class ApplicantBusinessRules
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IBlacklistRepository _blacklistRepository;

        public ApplicantBusinessRules(
            IApplicantRepository applicantRepository,
            IApplicationRepository applicationRepository,
            IBlacklistRepository blacklistRepository)
        {
            _applicantRepository = applicantRepository;
            _applicationRepository = applicationRepository;
            _blacklistRepository = blacklistRepository;
        }

        public async Task CheckIfApplicantWithSameIdentityExists(string nationalityIdentity)
        {
            var existingApplicant = await _applicantRepository.GetAsync(a => a.NationalityIdentity == nationalityIdentity);
            if (existingApplicant != null)
                throw new Exception("Bu TC Kimlik No ile zaten bir başvuru yapılmış.");
        }

        /// <summary>
        /// Kara listeye alınan bir başvuru sahibi yeni başvuru yapamaz.
        /// </summary>
        public async Task CheckIfApplicantIsBlacklisted(int applicantId)
        {
            var blacklisted = await _blacklistRepository.GetAsync(b => b.ApplicantId == applicantId);
            if (blacklisted != null)
                throw new Exception("Bu aday kara listededir, yeni başvuru yapamaz.");
        }

        /// <summary>
        /// Sistemde kayıtlı olmayan bir başvuru sahibi ile işlem yapılamaz.
        /// </summary>
        public async Task CheckIfApplicantExists(int applicantId)
        {
            var applicant = await _applicantRepository.GetByIdAsync(applicantId);
            if (applicant == null)
                throw new Exception("Aday sistemde kayıtlı değildir.");
        }
    }
}
