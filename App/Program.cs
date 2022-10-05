using GUI;
using System.Windows.Forms;

namespace App {
    public class ForwardToThePast {
        [STAThread]
        static void Main() {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}