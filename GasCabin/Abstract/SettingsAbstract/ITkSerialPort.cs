using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasCabin.Abstract.SettingsAbstract
{
    public interface ITkSerialPort
    {
        bool OpenPort(SerialSetting setting);
        Task<int> ReadRegister1(SerialSetting setting);
        Task<int> ReadRegister2(SerialSetting setting);
        Task<int> ReadRegister3(SerialSetting setting);
        Task<int> ReadRegister4(SerialSetting setting);


    }
}
