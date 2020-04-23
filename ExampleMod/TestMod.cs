using EBML;
using EBML.API;
using EBML.Logging;

namespace MyMod {

	public class TestMod : Mod {

		static readonly ILog log = LogFactory.GetLogger (typeof (TestMod));

		public override ModInfo Info {
			get {
				return new ModInfo (
					"ExampleMod", 
					"Mod to test out ModLoader", 
					new Version(1, 0, 0),
					new Version (Version.API_VERSION) // Version.API_VERSION is a constant so this is allowed
				);
			}
		}

		public override void OnLoad () { }

		public override void OnInit () {
			log.Info ("Initializing new resource");

			int id = ModResources.RegisterNewResource (
				DataFactory.CreateStaticResourceData ("Uranium", Resource.ResourceType.Luxury, 5, 0),
				ModAssets.CreateAsset (SimpleSpriteFactory.CreateFromImageFile(@"ExampleMod\uranium.png")),
				true
			);

			var atomBomb = ModAssets.CreateAsset (SimpleSpriteFactory.CreateFromImageFile (@"ExampleMod\atombomb.png"));

			var ids = ModResources.RegisterNewProductionResource (
				DataFactory.CreateStaticResourceData ("Atom Bomb", Resource.ResourceType.Weapon, 1000000, 0),
				DataFactory.CreateStaticResourceProductionData (5, Turn.Season.None, 0, id, 5, 0, 0),
				atomBomb
			);

			ModProperties.RegisterNewPropertyType (DataFactory.CreateStaticResourceBuildingsData (
				"Small uranium mine", "Medium uranium mine", "Large uranium mine", "Huge uranium mine", "Modded property", id, Property.Type.Production),
				new ModAssetSet4<UnityEngine.Sprite> (atomBomb, atomBomb, atomBomb, atomBomb));
		}

		public override void OnPostInit () { }

	}

}
