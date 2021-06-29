using System;

    public class NBAPlayer
    {

        public string Ime { get; set; }

        public string Tim { get; set; }

        public double Poeni { get; set; }

        public double Asistencii { get; set; }

        public double Skokovi { get; set; }


        public NBAPlayer()
        {

        }


        public NBAPlayer(string ime, string tim, double poeni, double asistencii, double skokovi)
        {

            Ime = ime;
            Tim = tim;
            Poeni = poeni;
            Asistencii = asistencii;
            Skokovi = skokovi;

        }

        public virtual double Rating()
        {
            var rating = (Poeni / 0.45 + Asistencii / 0.30 + Skokovi / 0.25);
            var two_decimals = Math.Round(rating, 2);
            return two_decimals;

        }


        public virtual void Print()
        {

            Console.WriteLine($"New Rating:\n" +
                $" Ime: {Ime} \n" +
                $" Tim: {Tim} \n" +
                $" Poeni: {Poeni} \n" +
                $" Asistencii: {Asistencii} \n" +
                $" Skokovi: {Skokovi} \n" +
                $" Rejting: {Rating()} \n");

        }
    }
