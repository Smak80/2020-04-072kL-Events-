using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2020_04_072kL_Events_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnProgress(int value)
        {
            if (!progressBar1.InvokeRequired)
                progressBar1.Value = value;
            else
                Invoke(new Processor.Progress(OnProgress), value);
        }

        private void OnProgressValue(int value)
        {
            if (!label1.InvokeRequired)
                label1.Text = "Выполнено: "+value.ToString()+"%";
            else
                Invoke(new Processor.Progress(OnProgressValue), value);
        }

        private void OnFinish(bool res, int resVal)
        {
            if (!label1.InvokeRequired)
            {
                if (res)
                    label1.Text = "Результат вычислений: " + resVal;
                else
                    label1.Text = "Результат не был получен :(";
            }
            else
            {
                object[] pars = { res, resVal };
                Invoke(new Processor.Finish(OnFinish),  pars);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Processor p = new Processor();
            p.EventProgress += OnProgress;
            p.EventProgress += OnProgressValue;
            p.EventFinish += OnFinish;
            p.Start();
        }
    }
}
