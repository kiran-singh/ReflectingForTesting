using System.Collections.Generic;
using System.Linq;
using ReflectingForTesting.Model;

namespace ReflectingForTesting.Service
{
    public class AssetManager
    {
        private IList<Asset> _assets;

        public Asset GetAsset(int id)
        {
            if (this._assets == null || this._assets.Count == 0)
            {
                this._assets = new AssetService().GetAll();
            }
            return this._assets.FirstOrDefault(x => x.Id == id);
        }
    }
}