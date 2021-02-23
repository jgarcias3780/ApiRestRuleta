namespace RuletaClean.Core.Entities
{
    public partial class Bet
    {
        public int id_bet { get; set; }
        public int id_roulette { get; set; }
        public int id_user { get; set; }
        public string number { get; set; }
        public decimal? money { get; set; }
        public string color { get; set; }
        public string win { get; set; }
        public decimal? earned_value { get; set; }
        public virtual Roulette id_roulette_navigation { get; set; }
        public virtual User id_user_navigation { get; set; }
    }
}
