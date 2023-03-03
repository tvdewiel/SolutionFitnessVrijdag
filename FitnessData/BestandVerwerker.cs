using FitnessDomain;
using System.Globalization;

namespace FitnessData
{
    public static class BestandVerwerker
    {
        public static List<Looptraining> LeesData(string dataBestand,string logBestand)
        {
            Dictionary<int,Looptraining> training= new Dictionary<int,Looptraining>();
            using(StreamWriter sw=new StreamWriter(logBestand))
            using(StreamReader sr=new StreamReader(dataBestand))
            {
                try
                {
                    string line;
                    while((line=sr.ReadLine()) != null) 
                    { 
                        line=line.Substring(line.IndexOf("(")+1,line.IndexOf(")")-line.IndexOf("(")-1);
                        string[] elementen=line.Split(',');
                        int sessieNr = Int32.Parse(elementen[0]);
                        DateTime datum = DateTime.Parse(elementen[1].Trim('\''));
                        int klantNummer = Int32.Parse(elementen[2]);
                        int duurTraining = Int32.Parse(elementen[3]);
                        double gemiddeldeSnelheid = Double.Parse(elementen[4],CultureInfo.InvariantCulture);
                        int seqNr = Int32.Parse(elementen[5]);
                        int intervalDuur = Int32.Parse(elementen[6]);
                        double intervalSnelheid = Double.Parse(elementen[7], CultureInfo.InvariantCulture);
                        try
                        {
                            Loopinterval li = new Loopinterval(intervalSnelheid, intervalDuur, seqNr);
                            if (training.ContainsKey(sessieNr))
                            {
                                training[sessieNr].VoegIntervalToe(li);
                            }
                            else
                            {
                                Looptraining lt = new Looptraining(sessieNr, duurTraining, gemiddeldeSnelheid, datum, klantNummer);
                                lt.VoegIntervalToe(li);
                                training.Add(sessieNr, lt);
                            }
                        }
                        catch (DomeinException ex)
                        {
                            sw.WriteLine(ex.Message);
                        }

                    }
                    return new List<Looptraining>(training.Values);
                }
                catch(Exception e)
                {
                    throw;
                }
            }
        }
    }
}