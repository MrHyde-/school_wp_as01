using Assigment01.Resources;

namespace Assigment01
{
    public class LocalizedStrings
    {
        private static AppResources localizedResources = new AppResources();

        public AppResources AppResources
        {
            get { return localizedResources; }
        }
    }
}
