using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayeredSolution.Szamlazo
{
    public interface IMessageService
    {
        void ShowErrorMessage(string message);
    }

    public class MessageService:IMessageService
    {
        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
