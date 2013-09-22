using Assigment01.Resources;

namespace Assigment01
{
    //Class used for Resource Localization
    public class LocalizedStrings
    {
        private static AppResources localizedResources = new AppResources();

        public AppResources AppResources
        {
            get { return localizedResources; }
        }
    }
}
