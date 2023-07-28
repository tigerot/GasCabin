using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasCabin
{
    public class SerialSetting
    {
        // public string Name { get; set; }
        public int BaudRate { get; set; } = 9600;
        public int ReadTimeout { get; set; } = 1000;
        public int DataBits { get; set; } = 8;
        public Parity Parity { get; set; } = Parity.None;
        public StopBits StopBits { get; set; } = StopBits.One;
        public ushort StartAddress { get; set; } = 1;
        public ushort NumberOfInputs { get; set; } = 1;
        public ushort NumberOfDevices { get; set; }
        public Handshake handshake { get; set; } = Handshake.None;
        // public byte slaveAddress { get; set; }
        public byte slaveAddress1 { get; set; } = Convert.ToByte(1);
        public byte slaveAddress2 { get; set; } = Convert.ToByte(2);
        public byte slaveAddress3 { get; set; } = Convert.ToByte(3);
        public byte slaveAddress4 { get; set; } = Convert.ToByte(4);
    }
}
