using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kosar2004
{
    internal class Merkozes
    {
        private string hazai;
        private string idegen;
        private int hazaiPont;
        private int idegenPont;
        private string helyszin;
        private DateTime idopont;

        public Merkozes(string hazai, string idegen, int hazaiPont, int idegenPont, string helyszin, DateTime idopont)
        {
            this.hazai = hazai;
            this.idegen = idegen;
            this.hazaiPont = hazaiPont;
            this.idegenPont = idegenPont;
            this.helyszin = helyszin;
            this.idopont = idopont;
        }

        public string Hazai { get => hazai; set => hazai = value; }
        public string Idegen { get => idegen; set => idegen = value; }
        public int HazaiPont { get => hazaiPont; set => hazaiPont = value; }
        public int IdegenPont { get => idegenPont; set => idegenPont = value; }
        public string Helyszin { get => helyszin; set => helyszin = value; }
        public DateTime Idopont { get => idopont; set => idopont = value; }
    }
}
