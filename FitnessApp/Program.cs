// See https://aka.ms/new-console-template for more information
using FitnessData;
using System.Globalization;

Console.WriteLine("Hello, World!");

string bestandsNaam = @"C:\temp\insertRunning\insertrunning.sql";
string logNaam = @"C:\temp\insertRunning\log.txt";

var data=BestandVerwerker.LeesData(bestandsNaam, logNaam);
DataBeheerder db = new DataBeheerder(data);

//var trainingen = db.GeefTrainingenKlant(154);
//foreach (var item in trainingen)
//{
//    Console.WriteLine(item);
//    foreach (var interval in item.GeefIntervallen())
//    {
//        Console.WriteLine("   " + interval);
//    }
//}
var trainingenDag = db.GeefTrainingenDatum(DateTime.Parse("1-12-2021"));
foreach (var item in trainingenDag)
{
    Console.WriteLine(item);
    foreach (var interval in item.GeefIntervallen())
    {
        Console.WriteLine("   " + interval);
    }
}