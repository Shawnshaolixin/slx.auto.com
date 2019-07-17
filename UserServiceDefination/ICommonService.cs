using MagicOnion;
using UserServiceDefination.dto;

namespace UserServiceDefination
{
    public interface ICommonService : IService<ICommonService>
    {
        UnaryResult<int> Add(AddRequestDTO request);
    }
}
