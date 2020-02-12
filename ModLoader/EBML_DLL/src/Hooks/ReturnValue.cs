using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBML.Hooks {

	/// <summary>
	/// This is a wrapper class that is used in conjunction
	/// with <see cref="HookSystem{I}"/> in order to 
	/// optionally manipulate return value of a method.
	/// </summary>
	/// <typeparam name="T">Return type</typeparam>
	public class ReturnValue<T> {

		/// <summary>
		/// The modified value of what will be returned.
		/// Is null or default(T) if not set.
		/// </summary>
		public T value { get; private set; }

		/// <summary>
		/// This is a flag that is used to check if
		/// the value has been set or if the method
		/// should return the value of the original method.
		/// </summary>
		public bool isSet { get; private set; }

		/// <summary>
		/// Sets a new custom return value.
		/// </summary>
		/// <param name="value">The modified return value.</param>
		public void SetValue (T value) {
			this.value = value;
			this.isSet = true;
		}

	}
}
