using ReflectingForTesting.Model;

namespace ReflectingForTesting.Service
{
    public class UrlHelper
    {
        public string AuthenticatedAssetUrl(Asset asset)
        {
            return ServiceProxy.Instance.GenerateAuthenticatedAssetUrl(asset);
        }

        public string AuthenticatedDropUrl(Drop drop)
        {
            return ServiceProxy.Instance.GenerateAuthenticatedDropUrl(drop);
        } 
    }
}