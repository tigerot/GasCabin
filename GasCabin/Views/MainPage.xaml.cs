using Microsoft.VisualBasic;
using System.IO.Ports;
using System.Runtime;
using GasCabin.Constants;
using System.Diagnostics;
using Modbus.Device;
using GasCabin.Abstract.MainPageAbstract;
using GasCabin.Concrete;

namespace GasCabin.Views;

public partial class MainPage : ContentPage
{

    int count = 0;

    static SerialPort mainSerialPort = new SerialPort();

    static SerialPort detectionSerialPort = new SerialPort();

    string x = String.Empty;

    IModbusSerialMaster serialMaster;

    IModbusSerialMaster detectionSerialMaster;

    ushort startAddress = 6;

    ushort NumberOfInputs = 1;

    int NumberOfDevices;

    List<byte> detectionSlaveHolder = new List<byte>();

    ushort[] inputRegistersResults;

    SerialSetting settings;

    TkSerialPort tkserialport;

    public MainPage()
    {
        InitializeComponent();

        settings = new SerialSetting();

        // Address1Entry.IsVisible = false;

        // Address2Entry.IsVisible = false;

        // Address3Entry.IsVisible = false;

        // Address4Entry.IsVisible = false;

        // string[] portNames = SerialPort.GetPortNames();

        // PortEntry.Text = portNames[0];

        tkserialport = new TkSerialPort();

        // Detection();

    }
    /*async public Task<int> ReadOne(byte slave)
    {
        do
        {
            ushort[] inputRegistersResults = await serialMaster.ReadInputRegistersAsync(slave, startAddress, NumberOfInputs);

            int convertResults = Convert.ToInt32(inputRegistersResults[0]);

            return convertResults;

        } while (inputRegistersResults[0] >= 0);

    }*/
    public void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        /*if (Convert.ToInt32(DeviceEntry.Text) >= 4)
        {
            DeviceEntry.Text = "4";
        }
        if(Convert.ToInt32(DeviceEntry.Text) < 1)
        {

        }*/
    }
    private async void ConnectButton_Clicked(object sender, EventArgs e)
    {
        if (mainSerialPort.IsOpen || detectionSerialPort.IsOpen || tkserialport._serialPort.IsOpen)
        {

            mainSerialPort.Close();

            detectionSerialPort.Close();

            tkserialport._serialPort.Close();
        }

        settings.NumberOfDevices = Convert.ToUInt16(DeviceEntry.Text);
        
        string[] connectionPort = SerialPort.GetPortNames();
        tkserialport._serialPort.PortName = connectionPort[0];
        if (!tkserialport.OpenPort(new SerialSetting()
        { }))
            return;
        int readAddress1;
        int readAddress2;
        int readAddress3;
        int readAddress4;

        /*int readAddress1 = await tkserialport.ReadRegister1(new SerialSetting()
        {});

        int readAddress2 = await tkserialport.ReadRegister2(new SerialSetting()
        {});

        int readAddress3 = await tkserialport.ReadRegister3(new SerialSetting()
        {});

        int readAddress4 = await tkserialport.ReadRegister4(new SerialSetting()
        {});*/
        /*mainSerialPort.PortName  = PortEntry.Text;
        mainSerialPort.BaudRate  = settings.BaudRate;
        mainSerialPort.DataBits  = settings.DataBits;
        mainSerialPort.Parity    = settings.Parity;
        mainSerialPort.StopBits  = settings.StopBits;
        mainSerialPort.Handshake = settings.handshake;

        mainSerialPort.Open();
        // serialTransport.WriteTimeout = 1000;
        serialMaster = ModbusSerialMaster.CreateRtu(mainSerialPort);
        serialMaster.Transport.ReadTimeout = settings.ReadTimeout;*/
        switch (settings.NumberOfDevices)
        {
            case 1:
                Address1Entry.IsVisible = true;
                readAddress1 = await tkserialport.ReadRegister1(new SerialSetting()
                { });
                Address1Entry.Text = (readAddress1 + SettingsPage.deviationOfDevice1).ToString();
                break;
            case 2:
                Address1Entry.IsVisible = true;
                Address2Entry.IsVisible = true;
                readAddress1 = await tkserialport.ReadRegister1(new SerialSetting()
                { });
                readAddress2 = await tkserialport.ReadRegister2(new SerialSetting()
                { });
                Address1Entry.Text = (readAddress1 + SettingsPage.deviationOfDevice1).ToString();
                Address2Entry.Text = (readAddress2 + SettingsPage.deviationOfDevice2).ToString();
                break;
            case 3:
                Address1Entry.IsVisible = true;
                Address2Entry.IsVisible = true;
                Address3Entry.IsVisible = true;
                readAddress1 = await tkserialport.ReadRegister1(new SerialSetting()
                { });
                readAddress2 = await tkserialport.ReadRegister2(new SerialSetting()
                { });
                readAddress3 = await tkserialport.ReadRegister3(new SerialSetting()
                { });
                Address1Entry.Text = (readAddress1 + SettingsPage.deviationOfDevice1).ToString();
                Address2Entry.Text = (readAddress2 + SettingsPage.deviationOfDevice2).ToString();
                Address3Entry.Text = (readAddress3 + SettingsPage.deviationOfDevice3).ToString();
                break;
            case 4:
                Address1Entry.IsVisible = true;
                Address2Entry.IsVisible = true;
                Address3Entry.IsVisible = true;
                Address4Entry.IsVisible = true;
                readAddress1 = await tkserialport.ReadRegister1(new SerialSetting()
                { });
                readAddress2 = await tkserialport.ReadRegister2(new SerialSetting()
                { });
                readAddress3 = await tkserialport.ReadRegister3(new SerialSetting()
                { });
                readAddress4 = await tkserialport.ReadRegister4(new SerialSetting()
                { });
                Address1Entry.Text = (readAddress1 + SettingsPage.deviationOfDevice1).ToString();
                Address2Entry.Text = (readAddress2 + SettingsPage.deviationOfDevice2).ToString();
                Address3Entry.Text = (readAddress3 + SettingsPage.deviationOfDevice3).ToString();
                Address4Entry.Text = (readAddress4 + SettingsPage.deviationOfDevice4).ToString();
                break;
        }


        /*Address1Entry.Text = (readAddress1 + SettingsPage.deviationOfDevice1).ToString();

        Address2Entry.Text = (readAddress2 + SettingsPage.deviationOfDevice2).ToString();

        Address3Entry.Text = (readAddress3 + SettingsPage.deviationOfDevice3).ToString();

        Address4Entry.Text = (readAddress4 + SettingsPage.deviationOfDevice4).ToString();*/

        if (Address1Entry.Text == null || Address1Entry.Text == "VALUE1")
        {
            Address1Entry.Text = Constants.Messages.NotFoundMessage;
        }
        if (Address2Entry.Text == null || Address2Entry.Text == "VALUE2")
        {
            Address2Entry.Text = Constants.Messages.NotFoundMessage;
        }
        if (Address3Entry.Text == null || Address3Entry.Text == "VALUE3")
        {
            Address3Entry.Text = Constants.Messages.NotFoundMessage;
        }
        if (Address4Entry.Text == null || Address4Entry.Text == "VALUE4")
        {
            Address4Entry.Text = Constants.Messages.NotFoundMessage;
        }

    }
    private void DisconnectButton_Clicked(object sender, EventArgs e)
    {
        Address1Entry.Text = Constants.Messages.NotFoundMessage;

        Address2Entry.Text = Constants.Messages.NotFoundMessage;

        Address3Entry.Text = Constants.Messages.NotFoundMessage;

        Address4Entry.Text = Constants.Messages.NotFoundMessage;

        tkserialport._serialPort.Close();


    }
    private async void DetectButton_Clicked(object sender, EventArgs e)
    {
        if (tkserialport._serialPort.IsOpen || detectionSerialPort.IsOpen)
        {
            tkserialport._serialPort.Close();
            detectionSerialPort.Close();
        }

        // PortEntry.Text = SerialPort.GetPortNames()[0];
        string[] detectPort = SerialPort.GetPortNames();
        detectionSerialPort.PortName = detectPort[0];
        detectionSerialPort.BaudRate = settings.BaudRate;
        detectionSerialPort.DataBits = settings.DataBits;
        detectionSerialPort.Parity   = settings.Parity;
        detectionSerialPort.StopBits = settings.StopBits;

        detectionSerialPort.Open();

        detectionSerialMaster = ModbusSerialMaster.CreateRtu(detectionSerialPort);

        detectionSerialMaster.Transport.ReadTimeout = settings.ReadTimeout;

        detectionSerialPort.Handshake = settings.handshake;

        for (byte i = 1; i <= settings.NumberOfDevices; i++)
        {

            ushort[] inputRegistersResults = await detectionSerialMaster.ReadInputRegistersAsync(i, startAddress, NumberOfInputs);

            detectionSlaveHolder.Add(i);

            DetectionDeviceEntry.Text = (detectionSlaveHolder[i - 1].ToString()) + (", ");
        }

        detectionSerialPort.Close();

    }

    public async void Detection()
    {
        if (tkserialport._serialPort.IsOpen || detectionSerialPort.IsOpen)
        {
            tkserialport._serialPort.Close();
            detectionSerialPort.Close();
        }

        // PortEntry.Text = SerialPort.GetPortNames()[0];

        string[] ports = SerialPort.GetPortNames();

        detectionSerialPort.PortName = ports[0];
        detectionSerialPort.BaudRate = settings.BaudRate;
        detectionSerialPort.DataBits = settings.DataBits;
        detectionSerialPort.Parity   = settings.Parity;
        detectionSerialPort.StopBits = settings.StopBits;

        detectionSerialPort.Open();

        detectionSerialMaster = ModbusSerialMaster.CreateRtu(detectionSerialPort);

        detectionSerialMaster.Transport.ReadTimeout = settings.ReadTimeout;

        detectionSerialPort.Handshake = settings.handshake;

        for (byte i = 1; i <= 9; i++)
        {
            ushort[] detectionResults;
            do
            {

                // detectionResults = await detectionSerialMaster.ReadInputRegistersAsync(i, settings.StartAddress, settings.NumberOfInputs);
                detectionResults = await detectionSerialMaster.ReadInputRegistersAsync(i, settings.StartAddress, settings.NumberOfInputs);
            } while (detectionResults != null);

            detectionSlaveHolder.Add(i);

            DetectionDeviceEntry.Text = (detectionSlaveHolder.Count.ToString());
        }

        detectionSerialPort.Close();
    }

}