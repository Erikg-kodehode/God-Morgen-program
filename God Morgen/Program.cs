using System;
using System.IO;
using System.Windows.Forms;

class Program
{
    [STAThread]
    static void Main()
    {
        try
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GreetingForm());
        }
        catch (Exception ex)
        {
            File.WriteAllText("error.log", ex.ToString());
            MessageBox.Show($"En feil oppstod: {ex.Message}\n\nSe error.log for detaljer.", "Feil", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
