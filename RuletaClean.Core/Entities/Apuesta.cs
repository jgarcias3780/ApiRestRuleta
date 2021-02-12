namespace RuletaClean.Core.Entities
{
    public partial class Apuesta
    {
        public int id_apuesta { get; set; }
        public int id_ruleta { get; set; }
        public int id_usuario { get; set; }
        public string numero { get; set; }
        public decimal dinero { get; set; }
        public string color { get; set; }
        public string gano { get; set; }
        public decimal valor_ganado { get; set; }

        public virtual Ruleta id_ruleta_navigation { get; set; }
        public virtual Usuario id_usuario_navigation { get; set; }
    }
}
