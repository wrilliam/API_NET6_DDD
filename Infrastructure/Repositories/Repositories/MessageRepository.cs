using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Repositories
{
    public class MessageRepository : CommonRepository<Message>, IMessage
    {
        #region Attributes

        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        #endregion

        #region Constructor

        public MessageRepository()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        #endregion
    }
}
