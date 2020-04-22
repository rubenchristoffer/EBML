using System;

namespace EBML {

	/// <summary>
	/// Singleton base class for Lambda-based Factory classes.
	/// </summary>
	/// <typeparam name="T">The actual factory class type itself</typeparam>
	public abstract class Factory<T> where T : Factory<T> {

		/// <summary>
		/// Static singleton instance.
		/// </summary>
		protected static T Instance { get; private set; }

		static Factory () {
			Instance = Activator.CreateInstance<T> ();
		}

	}

}
