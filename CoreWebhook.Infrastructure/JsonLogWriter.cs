using System.Collections.Concurrent;

namespace CoreWebhook.Infrastructure
{
    public class JsonLogWriter : IDisposable
    {
        private BlockingCollection<string> _blk=new BlockingCollection<string>();
        private StreamWriter log = null;
        bool run = true;
        Task task = null;
        public JsonLogWriter(string logfilepath)
        {
            log= new StreamWriter(logfilepath);
            task = Task.Run(() =>
            {
                while (run)
                {
                    log.WriteLine(_blk.Take());
                }
            });
        }

        public void WriteLine(string value)
        {
            _blk.Add(value);
        }
        public void Dispose()
        {
            run=false;
            task.Dispose();
            log.Close();
            log.Dispose();
        }
    }
}
