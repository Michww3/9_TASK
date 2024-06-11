class Prgramm
{
    static void Main(string[] args)
    {
        ResourceMonitor monitor = new(7403544);

        BigList(1001010020302303);

        void BigList(long n)
        {
            List <int> list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                list.Add(i);
                //Console.WriteLine(i);
                monitor.CheckMemoryUsage();
            }
        }
        void Cycle()
        {
            long temp = long.MaxValue;
            for (int i = 0; i < temp; i++)
            {
                Console.WriteLine(i);
                monitor.CheckMemoryUsage();
                Thread.Sleep(100);
            }
        }
    }


    public class ResourceMonitor
    {
        private long _maxMemoryUsage;

        public ResourceMonitor(long maxMemoryUsage)
        {
            _maxMemoryUsage = maxMemoryUsage;
        }

        public void CheckMemoryUsage()
        {
            long currentMemoryUsage = GC.GetTotalMemory(false);

            if (currentMemoryUsage >= _maxMemoryUsage)
            {
                Console.WriteLine($"Внимание: потребление памяти достигло  максимально допустимого уровня. {currentMemoryUsage}");
            }
            else
            {
                Console.WriteLine($"Текущее потребление памяти: {currentMemoryUsage} байт.");
            }
        }
    }
}