using System;
using System.Windows.Forms;
using ExecutionEngine.Job;

namespace ExecuteEngine.Forms
{
    using ExecutionEngine;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var jobManager = new JobManager(new ResourceManager());
            var id = jobManager.Add(new CopyFileFromIsoJob(@"Y:\media\backup-14.iso", @"G:\Renders\WoW-Intro-enUS.avi", @"c:\users\mario\desktop\"));
            jobManager.Run(id);
        }
    }
}