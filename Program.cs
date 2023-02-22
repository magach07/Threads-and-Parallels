using System.Diagnostics;
using Threads.ClientService;
using Threads.Models;

var stop = new Stopwatch();

// var action1 = new Action(ViaCep);

string[] ceps = new string[5];
ceps[0] = "29107358";
ceps[1] = "29101285";
ceps[2] = "29125009";
ceps[3] = "29118320";
ceps[4] = "29129307";

stop.Start();

var parallelOptions = new ParallelOptions();
parallelOptions.MaxDegreeOfParallelism = 5;

List<CepModel> listCep = new List<CepModel>();

Parallel.ForEach(ceps, parallelOptions, cep =>
{
    listCep.Add(new CepService().GetCep(cep));
});

listCep.OrderBy(cep => cep.Bairro).ToList().ForEach(cep => Console.WriteLine(cep));

stop.Stop();

// Parallel.Invoke(action1);

Console.WriteLine($"O tempo de processamento foi de {stop.ElapsedMilliseconds} ms");