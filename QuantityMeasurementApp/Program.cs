using QuantityMeasurementApp.Menu;

namespace QuantityMeasurementApp
{
    /// <summary>
    /// Entry point of the Quantity Measurement Application.
    /// 
    /// Responsibility:
    /// - Bootstraps the application.
    /// - Initializes required components.
    /// - Delegates execution control to the Menu layer.
    /// 
    /// NOTE:
    /// This class should remain lightweight.
    /// No business logic or UI logic should be implemented here.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main execution method.
        /// Invoked automatically when the application starts.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments (currently not used).
        /// </param>
        private static void Main(string[] args)
        {
            // Instantiate Menu component (UI Layer)
            Menu.Menu menu = new Menu.Menu();

            // Transfer execution control to Menu
            menu.Show();
        }
    }
}