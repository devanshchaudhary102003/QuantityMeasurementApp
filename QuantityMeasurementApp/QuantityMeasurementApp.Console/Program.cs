using QuantityMeasurementApp.Console.Controller;
using QuantityMeasurementApp.Console.Menu;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppBusinessLayer.Service;
using QuantityMeasurementAppRepositoryLayer.Cache;
using QuantityMeasurementAppRepositoryLayer.Interface;

IQuantityMeasurementRepository repository = new QuantityMeasurementCacheRepository();
IQuantityMeasurementService service = new QuantityMeasurementService(repository);
//QuantityMeasurementController controller = new QuantityMeasurementController(service);
Menu menu = new Menu(service);

menu.Show();