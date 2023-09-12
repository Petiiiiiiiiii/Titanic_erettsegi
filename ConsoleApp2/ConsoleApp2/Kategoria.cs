namespace ConsoleApp2
{
    class Kategoria
    {
        public string KategoriaNev { get; set; }
        public int TuelelokSzama { get; set; }
        public int EltuntekSzama { get; set; }
        public int Utasok => this.TuelelokSzama + this.EltuntekSzama;

        public Kategoria(string sor)
        {
            var d = sor.Split(';');
            this.KategoriaNev = d[0];
            this.TuelelokSzama = int.Parse(d[1]);
            this.EltuntekSzama = int.Parse(d[2]);
        }
    }
}
