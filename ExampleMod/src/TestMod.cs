using System;
using EBML;
using EBML.GameAPI;
using EBML.Logging;

namespace MyMod {

	public class TestMod : Mod {

		static readonly ILog log = LogFactory.GetLogger (typeof (TestMod));

		public override ModInfo Info {
			get {
				return new ModInfo ("ExampleMod", "Mod to test out ModLoader", "v1.0.0");
			}
		}

		public override void OnLoad () { }

		public override void OnInit () {
			log.Info ("Initializing new resource");

			int id = ModResources.RegisterNewResource (
				DataFactory.CreateStaticResourceData ("Uranium", Resource.ResourceType.Luxury, 5, 0),
				ModAssets.CreateAsset (SpriteFactory.GetSprite (usingTexture => usingTexture.FromBytes (usingBytes => usingBytes.FromFile(@"ExampleMod\uranium.png")))),
				true
			);

			ModAsset<UnityEngine.Sprite> atomBomb = ModAssets.CreateAsset (
				SpriteFactory.GetSprite (usingTexture => usingTexture.FromBytes (usingBytes => usingBytes.FromFile (@"ExampleMod\atombomb.png")))
			);

			Tuple<int, int> ids = ModResources.RegisterNewProductionResource (
				DataFactory.CreateStaticResourceData ("Atom Bomb", Resource.ResourceType.Weapon, 1000000, 0),
				DataFactory.CreateStaticResourceProductionData (5, Turn.Season.None, 0, id, 5, 0, 0),
				atomBomb
			);

			ModProperties.RegisterNewPropertyType (DataFactory.CreateStaticResourceBuildingsData (
				"Small uranium mine", "Medium uranium mine", "Large uranium mine", "Huge uranium mine", "Modded property", id, Property.Type.Production),
				new ModAssetSet4<UnityEngine.Sprite> (atomBomb, atomBomb, atomBomb, atomBomb));

			UnityEngine.Object test = UnityEngine.Resources.Load ("ResourceIcons/" + id);
			UnityEngine.Object test2 = UnityEngine.Resources.Load ("ResourceIcons/49");
			log.Debug ("Null: " + (test == null));
			log.Debug ("Null2: " + (test2 == null));

			UnityEngine.Sprite test3 = UnityEngine.Resources.Load<UnityEngine.Sprite> ("ResourceIcons/49");
			log.Debug ("Null3: " + (test3 == null));

			UnityEngine.Sprite test4 = UnityEngine.Resources.Load<UnityEngine.Sprite> ("Property/1001");
			log.Debug ("Null4: " + (test4 == null));
		}

		public override void OnPostInit () { }

	}

}
