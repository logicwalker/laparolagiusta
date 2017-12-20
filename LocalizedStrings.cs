using PanoramaApp1.Resources;

namespace PanoramaApp1
{
    /// <summary>
    /// Fornisce l'accesso alle risorse stringa.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}