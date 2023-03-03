using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDomain
{
    public class Looptraining
    {
        public Looptraining(int sessieNummer, int duur, double gemiddeldeSnelheid, DateTime datum, int klantNummer)
        {
            ZetSessieNummer(sessieNummer);
            ZetDuur(duur);
            ZetGemiddeldeSnelheid(gemiddeldeSnelheid);
            Datum = datum;
            ZetKlantNummer(klantNummer);
        }
        public int SessieNummer { get;private set; }
        public int Duur { get; private set; } //min
        public double GemiddeldeSnelheid { get;private set; }
        public DateTime Datum { get; set; }
        public int KlantNummer { get; private set; }
        private SortedList<int,Loopinterval> intervallen=new SortedList<int,Loopinterval>();
        public IReadOnlyList<Loopinterval> GeefIntervallen()
        {
            return intervallen.Values.ToList().AsReadOnly();
        }
        public void VoegIntervalToe(Loopinterval interval)
        {
            if (intervallen.ContainsKey(interval.SeqNr)) { throw new DomeinException("voegintervaltoe"); }
            intervallen.Add(interval.SeqNr, interval);
        }
        public void ZetSessieNummer(int sessieNummer)
        {
            if (sessieNummer <= 0) { throw new DomeinException("ZetSessieNummer"); }
            SessieNummer= sessieNummer;
        }
        public void ZetDuur(int duur)
        {
            if (duur <= 5 || duur>=180) { throw new DomeinException("ZetDuur"); }
            Duur= duur;
        }
        public void ZetGemiddeldeSnelheid(double gemiddeldeSnelheid)
        {
            if (gemiddeldeSnelheid < 5 || gemiddeldeSnelheid > 22) throw new DomeinException("ZetGemiddeldeSnelheid");
            GemiddeldeSnelheid = gemiddeldeSnelheid;
        }
        public void ZetKlantNummer(int klantNummer)
        {
            if (klantNummer <= 0) { throw new DomeinException("ZetKlantNummer"); }
            KlantNummer = klantNummer;
        }
        public override string ToString()
        {
            return $"{KlantNummer},{Duur},{GemiddeldeSnelheid},{Datum},{SessieNummer}";
        }
    }
}
