using ReflectingForTesting.Model;

namespace ReflectingForTesting.Service
{
    public class ServiceProxy
    {
        private static ServiceProxy _instance;

        public static ServiceProxy Instance
        {
            get
            {
                return _instance ?? (_instance = new ServiceProxy {ServiceAdapter = new ProductionService()});
            }
        }

        internal ProductionService ServiceAdapter;

        /// <summary>
        /// Generates the authenticated asset URL.
        /// </summary>
        /// <param name="asset">The asset.</param>
        /// <returns></returns>
        public virtual string GenerateAuthenticatedAssetUrl(Asset asset)
        {
            return this.ServiceAdapter.GenerateAuthenticatedAssetUrl(asset);
        }

        /// <summary>
        /// Generates the authenticated drop URL.
        /// </summary>
        /// <param name="drop">The drop.</param>
        /// <returns></returns>
        public virtual string GenerateAuthenticatedDropUrl(Drop drop)
        {
            return this.ServiceAdapter.GenerateAuthenticatedDropUrl(drop);
        }
    }
}