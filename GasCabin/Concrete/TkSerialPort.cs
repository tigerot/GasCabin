using GasCabin.Abstract;
using GasCabin.Abstract.SettingsAbstract;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasCabin.Concrete
{
    public class TkSerialPort : ITkSerialPort
    {
        public SerialPort _serialPort = new SerialPort();
        public IModbusSerialMaster _modbusSerialMaster;

        public bool OpenPort(SerialSetting setting)
        {
            try
            {
                if (_serialPort.IsOpen)
                    return true;

                //_serialPort.PortName = setting.Name;
                _serialPort.BaudRate = setting.BaudRate;
                _serialPort.DataBits = setting.DataBits;
                _serialPort.Parity   = setting.Parity;
                _serialPort.StopBits = setting.StopBits;

                _serialPort.Open();
                _modbusSerialMaster = ModbusSerialMaster.CreateRtu(_serialPort);
                _modbusSerialMaster.Transport.ReadTimeout = setting.ReadTimeout;


                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }
        }

        public async Task<int> ReadRegister1(SerialSetting setting)
        {
            
                ushort[] inputRegisterHolder1 = await _modbusSerialMaster.ReadInputRegistersAsync(setting.slaveAddress1, setting.StartAddress, setting.NumberOfInputs);
                int conversionResults1 = inputRegisterHolder1[0];
                return conversionResults1;
        
        }
        public async Task<int> ReadRegister2(SerialSetting setting)
        {

            ushort[] inputRegisterHolder2 = await _modbusSerialMaster.ReadInputRegistersAsync(setting.slaveAddress2, setting.StartAddress, setting.NumberOfInputs);
            int conversionResults2 = inputRegisterHolder2[0];
            return conversionResults2;

        }
        public async Task<int> ReadRegister3(SerialSetting setting)
        {

            ushort[] inputRegisterHolder3 = await _modbusSerialMaster.ReadInputRegistersAsync(setting.slaveAddress3, setting.StartAddress, setting.NumberOfInputs);
            int conversionResults3 = inputRegisterHolder3[0];
            return conversionResults3;

        }
        public async Task<int> ReadRegister4(SerialSetting setting)
        {

            ushort[] inputRegisterHolder4 = await _modbusSerialMaster.ReadInputRegistersAsync(setting.slaveAddress4, setting.StartAddress, setting.NumberOfInputs);
            int conversionResults4 = inputRegisterHolder4[0];
            return conversionResults4;

        }
    }
}
