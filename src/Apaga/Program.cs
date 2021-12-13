// See https://aka.ms/new-console-template for more information
using Apaga;
using Berger.Global.Extensions.Pagination;

Console.WriteLine("Hello, World!");

var airfields = new List<Airfield>();

airfields.Add(new Airfield("1", "aa"));
airfields.Add(new Airfield("2", "aa"));
airfields.Add(new Airfield("3", "aa"));
airfields.Add(new Airfield("4", "aa"));


var bla = airfields.AsQueryable();

var teste = bla.Paginate(2, 3);
