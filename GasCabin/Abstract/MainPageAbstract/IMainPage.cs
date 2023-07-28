using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasCabin.Abstract.MainPageAbstract
{
    public interface IMainPage
    {
        Task<int> ReadOne(byte slave);
    }
}
