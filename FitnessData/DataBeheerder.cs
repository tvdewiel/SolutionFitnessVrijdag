using FitnessDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessData
{
    public class DataBeheerder
    {
        private Dictionary<int,List<Looptraining>> klantData=new Dictionary<int,List<Looptraining>>();
        private Dictionary<DateTime,List<Looptraining>> datumData=new Dictionary<DateTime,List<Looptraining>>();
        public DataBeheerder(List<Looptraining> data) {
            foreach(var t in data)
            {
                if (klantData.ContainsKey(t.KlantNummer))
                {
                    klantData[t.KlantNummer].Add(t);
                }
                else
                {
                    klantData.Add(t.KlantNummer, new List<Looptraining>() { t});
                }
                if (datumData.ContainsKey(t.Datum.Date))
                {
                    datumData[t.Datum.Date].Add(t);
                }
                else
                {
                    datumData.Add(t.Datum.Date,new List<Looptraining>() { t });
                }
            }
        }
        public List<Looptraining> GeefTrainingenKlant(int klantNr)
        {
            if (klantData.ContainsKey(klantNr)) return klantData[klantNr];
            else throw new FitnessDataException("klant niet gevonden");
        }
        public List<Looptraining> GeefTrainingenDatum(DateTime dag)
        {
            if (datumData.ContainsKey(dag)) return datumData[dag];
            else throw new FitnessDataException("dag niet gevonden");
        }
    }
}
