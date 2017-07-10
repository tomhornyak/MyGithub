using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovePicturesByDate
{

    

    public partial class Log : Form
    {
        public event EventHandler<EventArgs> ClosingEvent;

        private List<string> _lines = new List<string>();
        
        public Log()
        {
            InitializeComponent();
        }

        public void ClearForm()
        {
            _lines.Clear();
            _rtbLog.Text = string.Empty;
        }

        public void AppendText(string line)
        {
            _rtbLog.SuspendLayout();
            _lines.Add(line);
            _rtbLog.Lines = _lines.ToArray();
            _rtbLog.ResumeLayout();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            OnRaiseClosingEvent();
            base.OnClosing(e);
        }

        private  void OnRaiseClosingEvent()
        {
            ClosingEvent?.Invoke(this, new EventArgs());
        }

    }
}
