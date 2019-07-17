using MagicOnion;
using MagicOnion.Server;
using UserServiceDefination;
using UserServiceDefination.dto;

namespace UserHost.Service
{
    public class CommonService : ServiceBase<ICommonService>, ICommonService
    {
        public async UnaryResult<int> Add(AddRequestDTO request)
        {
            return request.A + request.B;
        }
    }
}
