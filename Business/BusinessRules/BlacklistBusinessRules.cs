using DataAccess.Repositories;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class BlacklistBusinessRules(IBlacklistRepository _blacklistRepository)
    {
              

        public async Task ApplicantCannotBeBlacklistedTwice(int applicantId)
        {
            var list = await _blacklistRepository.GetAllAsync();
            if (list.Any(b => b.ApplicantId == applicantId))
                throw new Exception("Bu aday zaten kara listeye alınmış.");
        }

        public Task ReasonCannotBeEmpty(string reason)
        {
            if (string.IsNullOrWhiteSpace(reason))
                throw new Exception("Sebep boş bırakılamaz.");
            return Task.CompletedTask;
        }
    }

}
