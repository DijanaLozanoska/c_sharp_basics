using System;

    public class AllStarPlayer : NBAPlayer
    {

        public double AllStarPoeni { get; set; }

        public double AllStarAsistencii { get; set; }

        public double AllStarSkokovi { get; set; }

        public NBAPlayer NBAPlayer { get; set; }


        public AllStarPlayer()
        {


        }


        public AllStarPlayer(NBAPlayer nbaplayer, double allstarpoeni, double allstarasistencii, double allstarskokovi)
        {

            NBAPlayer = nbaplayer;
            AllStarPoeni = allstarpoeni;
            AllStarAsistencii = allstarasistencii;
            AllStarSkokovi = allstarskokovi;

        }



        public AllStarPlayer(string ime, string tim, double poeni, double asistencii, double skokovi, double allstarpoeni, double allstarasistencii, double allstarskokovi)
        : base(ime, tim, poeni, asistencii, skokovi)
        {

            AllStarPoeni = allstarpoeni;
            AllStarAsistencii = allstarasistencii;
            AllStarSkokovi = allstarskokovi;

        }


        public double AllStarRating()
        {

            var all_star_rating = AllStarPoeni / 0.30 + AllStarAsistencii / 0.40 + AllStarSkokovi / 0.30;
            var two_decimals = Math.Round(all_star_rating, 2);
            return two_decimals;

        }

        public override double Rating()
        {

            return base.Rating();

        }

        public override void Print()
        {
            Console.WriteLine($" Ime: {NBAPlayer.Ime} \n" +
            $" Tim: {NBAPlayer.Tim} \n" +

            $"New Rating: {NBAPlayer.Rating()} \n" +
            $"All Star Rating: {AllStarRating()} \n"
            );
        }
    }
