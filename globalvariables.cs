using System;
using System.Threading;
using System.Windows.Forms;

public class globals
{
    public string email { get; set; }
    public string defaultemail = "@gmail.com";
    public string password { get; set; }
    public string usblocation { get; set; }
    public string askuserforemail()
    {
        string input;
        Console.WriteLine(" ** Please enter your email address! ** ");
        input = Console.ReadLine();
        email = input;
        return email;
    }

    public string askuserforpass() // method to ask user to input password
    {
        string input;
        Console.WriteLine("Enter your email password to confirm send!");
        input = Console.ReadLine();
        password = input;
        return password; // returns password
    }

    public string askuserforusblocation()
    {
        FolderBrowserDialog file1 = new FolderBrowserDialog();
        file1.ShowNewFolderButton = true;
        file1.ShowDialog();
        usblocation = file1.SelectedPath;
        return usblocation;
    }
}
