using GasCabin.Concrete;

namespace GasCabin.Views;

public partial class SettingsPage : ContentPage
{
    public byte slaveAddress1;
    public byte slaveAddress2;
    public byte slaveAddress3;
    public byte slaveAddress4;
    public static int deviationOfDevice1;
    public static int deviationOfDevice2;
    public static int deviationOfDevice3;
    public static int deviationOfDevice4;
   
    public SettingsPage()
	{
		InitializeComponent();

    }
    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (DeviationOfAddress1.Text == null)
        {
            DeviationOfAddress1.Text = "0";
        }
        if (DeviationOfAddress2.Text == null)
        {
            DeviationOfAddress2.Text = "0";
        }
        if (DeviationOfAddress3.Text == null)
        {
            DeviationOfAddress3.Text = "0";
        }
        if (DeviationOfAddress4.Text == null)
        {
            DeviationOfAddress4.Text = "0";
        }

        deviationOfDevice1 = Convert.ToInt32(DeviationOfAddress1.Text);
        deviationOfDevice2 = Convert.ToInt32(DeviationOfAddress2.Text);
        deviationOfDevice3 = Convert.ToInt32(DeviationOfAddress3.Text);
        deviationOfDevice4 = Convert.ToInt32(DeviationOfAddress4.Text);

        await Shell.Current.GoToAsync("//MainPage");
    }
    public void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        
    }
    private void OnEntryCompleted(object sender, EventArgs e)
    {
        
    }
}