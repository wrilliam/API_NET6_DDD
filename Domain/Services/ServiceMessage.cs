using Domain.Interfaces;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ServiceMessage : IServiceMessage
    {
        #region Attributes

        private readonly IMessage _Message;

        #endregion

        #region Constructor

        public ServiceMessage(IMessage message)
        {
            _Message = message;
        }

        #endregion
    }
}
