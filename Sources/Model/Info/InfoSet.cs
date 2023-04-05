namespace NRO_Server.Model.Info
{
    public class InfoSet
    {
        public bool IsFullSetThanLinh { get; set; }
        public bool IsFullSetHuyDiet { get; set; }

        public bool IsFullSetKirin { get; set; }
        public bool IsFullSetSongoku { get; set; }
        public bool IsFullSetKaioken { get; set; }

        public bool IsFullSetNappa { get; set; }
        public bool IsFullSetKakarot { get; set; }
        public bool IsFullSetCadic { get; set; }

        public bool IsFullSetLienHoan { get; set; }
        public bool IsFullSetPicolo { get; set; }
        public bool IsFullSetPikkoro { get; set; }

        public InfoSet()
        {
            IsFullSetThanLinh = false;
            IsFullSetHuyDiet = false;

            IsFullSetKirin = false;
            IsFullSetSongoku = false;
            IsFullSetKaioken = false;

            IsFullSetNappa = false;
            IsFullSetKakarot = false;
            IsFullSetCadic = false;

            IsFullSetLienHoan = false;
            IsFullSetPicolo = false;
            IsFullSetPikkoro = false;
        }

        public void Reset()
        {
            IsFullSetThanLinh = false;
            IsFullSetHuyDiet = false;

            IsFullSetKirin = false;
            IsFullSetSongoku = false;
            IsFullSetKaioken = false;

            IsFullSetNappa = false;
            IsFullSetKakarot = false;
            IsFullSetCadic = false;

            IsFullSetLienHoan = false;
            IsFullSetPicolo = false;
            IsFullSetPikkoro = false;
        }
    }
}