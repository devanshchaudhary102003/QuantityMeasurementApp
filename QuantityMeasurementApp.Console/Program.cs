using QuantityMeasurementApp.Console.Controller;
using QuantityMeasurementApp.Console.Interface;
using QuantityMeasurementApp.Console.Menu;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppBusinessLayer.Service;
using QuantityMeasurementAppRepositoryLayer.Cache;
using QuantityMeasurementAppRepositoryLayer.Interface;

IQuantityMeasurementRepository repository = new QuantityMeasurementCacheRepository();
IQuantityMeasurementService service = new QuantityMeasurementService(repository);
QuantityMeasurementController controller = new QuantityMeasurementController(service);
IMenu menu = new Menu(controller);

menu.Show();