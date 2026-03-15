using QuantityMeasurementApp.Console.Menu;
using QuantityMeasurementAppRepositoryLayer.Database;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppBusinessLayer.Service;
using QuantityMeasurementAppRepositoryLayer.Interface;

IQuantityMeasurementRepository repository = new QuantityMeasurementDatabase();
IQuantityMeasurementService service = new QuantityMeasurementService(repository);
Menu menu = new Menu(service);

menu.Show();