using System.Collections.Generic;
using System.Diagnostics;

namespace SimpleInjectorLib
{
    public class ProcessHelper
    {
        public List<Process> ProcessList { get; private set; }

        public ProcessHelper()
        {
            ProcessList = new List<Process>();
            var processArray = Process.GetProcesses();
            foreach (var process in processArray)
                ProcessList.Add(process);
        }

        public void Refresh()
        {
            _refresh();
        }

        public Process? GetProcessByName(string name)
        {
            _refresh();
            foreach (var process in ProcessList)
            {
                if (process.ProcessName == name)
                {
                    return process;
                }
            }
            return null;
        }

        public Process? GetProcessById(int id)
        {
            _refresh();
            foreach (var process in ProcessList)
            {
                if (process.Id == id)
                {
                    return process;
                }
            }
            return null;
        }

        public Process? GetProcessByTitle(string title)
        {
            _refresh();
            foreach (var process in ProcessList)
            {
                if (process.MainWindowTitle == title)
                {
                    return process;
                }
            }
            return null;
        }

        private void _refresh()
        {
            var processArray = Process.GetProcesses();
            ProcessList.Clear();
            foreach (var process in processArray)
                ProcessList.Add(process);
        }
    }
}