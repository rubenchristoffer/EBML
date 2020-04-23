using System;
using System.Reflection;
using UnityEngine;

namespace EBML.Extensions {

	/// <summary>
	/// Extension methods for <see cref="WeaponInvestWindow"/>.
	/// </summary>
	public static class WeaponInvestWindowExtensions {

		static readonly Type type = typeof (WeaponInvestWindow);

		/// <summary>
		/// Gets the sellCardsPool field.
		/// </summary>
		/// <param name="instance">Instance</param>
		/// <returns>AutoPool of ResourceSellCard objects</returns>
		public static AutoPool<ResourceSellCard> GetSellCardsPool (this WeaponInvestWindow instance) {
			return (AutoPool<ResourceSellCard>) type
				.GetField ("sellCardsPool", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue (instance);
		}

		/// <summary>
		/// Gets the sellCardsPool field.
		/// </summary>
		/// <param name="instance">Instance</param>
		/// <param name="value">The new value</param>
		public static void SetSellCardsPool (this WeaponInvestWindow instance, AutoPool<ResourceSellCard> value) {
			type.GetField ("sellCardsPool", BindingFlags.NonPublic | BindingFlags.Instance).SetValue (instance, value);
		}

		/// <summary>
		/// Gets the sellCardPrefab field.
		/// </summary>
		/// <param name="instance">Instance</param>
		/// <returns>Prefab GameObject</returns>
		public static GameObject GetSellCardPrefab (this WeaponInvestWindow instance) {
			return (GameObject) type
				.GetField ("sellCardPrefab", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue (instance);
		}

		/// <summary>
		/// Gets the sellCardsContainer field.
		/// </summary>
		/// <param name="instance">Instance</param>
		/// <returns>RectTransform</returns>
		public static RectTransform GetSellCardsContainer (this WeaponInvestWindow instance) {
			return (RectTransform) type
				.GetField ("sellCardsContainer", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue (instance);
		}

	}

}
