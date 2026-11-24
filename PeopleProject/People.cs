namespace PeopleProject
{
    internal class People
    {
        private List<int> eletkorok;

        public People()
        {
            this.eletkorok = new List<int>();
        }

        public List<int> Eletkorok { get => eletkorok; set => eletkorok = value; }

        public void UjSzemely(int eletkor)
        {
            if (eletkor < 0)
            {
                throw new ArgumentException();
            }
            eletkorok.Add(eletkor);
        }

        public string KategoriaAtlagOsszesbol()
        {
            if (eletkorok.Count == 0)
            {
                throw new InvalidOperationException();
            }

            int osszeg = 0;
            int count = 0;
            foreach (var i in eletkorok)
            {

                osszeg += i;
                count++;

            }
            double avg = osszeg / count;
            if(avg < 18)
            {
                return "Gyerek";
            }
            else if (avg < 65)
            {
                return "Felnőtt";
            }
            else
            {
                return "Nyugdíjas";
            }

        }

        public double AtlagEletkor(int minEletkor, int maxEletkor)
        {
            if (eletkorok.Count == 0)
            {
                throw new InvalidOperationException();
            }
            if (minEletkor > maxEletkor || minEletkor < 0 || maxEletkor < 0)
            {
                throw new ArgumentException();
            }
            int osszeg = 0;
            int count = 0;
            foreach (var i in eletkorok)
            {
                if (i <= maxEletkor && i >= minEletkor)
                {
                    osszeg += i;
                    count++;
                }
            }
            if (count == 0)
            {
                throw new ArgumentException();
            }


            return osszeg / count;

        }
    }
}


