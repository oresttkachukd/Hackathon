using System.Threading.Tasks;

namespace Hackathon.Content.Application.Services
{
    public interface IMessageBroker
    {
        Task Publish(object @event);
    }
}
