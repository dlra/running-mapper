using RunningMapper.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningMapper.Data.Services
{
    public interface IRunData
    {
        IEnumerable<Run> GetAll();
    }
}
