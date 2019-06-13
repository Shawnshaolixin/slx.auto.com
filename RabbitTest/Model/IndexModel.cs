using System.Threading.Tasks;

namespace RabbitTest.Model
{
    public class IndexModel
    {
        private readonly IMyDependency _myDependency;

        public IndexModel(IMyDependency myDependency)
        {
            _myDependency = myDependency;
        }
        public async Task OnGetAsync()
        {
            await _myDependency.WriteMessage("测试依赖注入.");
        }
    }
}
