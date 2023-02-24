namespace FitnessDomain
{
    public class Loopinterval
    {
        public Loopinterval(double gemiddeldeSnelheid, int duur, int seqNr)
        {
            ZetGemiddeldeSnelheid(gemiddeldeSnelheid);
            ZetDuur(duur);
            ZetSeqNr(seqNr);
        }
        public double GemiddeldeSnelheid { get; private set; }
        public int Duur { get; private set; }
        public int SeqNr { get;private set; }
        public void ZetGemiddeldeSnelheid(double gemiddeldeSnelheid)
        {
            if (gemiddeldeSnelheid < 5 || gemiddeldeSnelheid > 22) throw new DomeinException("ZetGemiddeldeSnelheid");
            GemiddeldeSnelheid= gemiddeldeSnelheid;
        }
        public void ZetDuur(int duur) //sec
        {
            if (duur < 5 || duur > 3 * 60 * 60) throw new DomeinException("ZetDuur");
            Duur = duur;
        }
        public void ZetSeqNr(int seqNr)
        {
            if (seqNr <= 0) throw new DomeinException("ZetSeqNr");
            SeqNr = seqNr;
        }
    }
}