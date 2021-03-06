﻿namespace EBML.Hooks {

	/// <summary>
	/// This is the base for ReturnValue.
	/// This can be used when you do not know
	/// generic type and want to access a field
	/// unrelated to generic type.
	/// </summary>
	public abstract class ReturnValue {

		/// <summary>
		/// This is a flag that is used to check if
		/// the value has been set or if the method
		/// should return the value of the original method.
		/// </summary>
		public bool IsSet { get; protected set; }

	}

	/// <summary>
	/// This is a wrapper class that is used in conjunction
	/// with <see cref="HookSystem{I}"/> in order to 
	/// optionally manipulate return value of a method.
	/// </summary>
	/// <typeparam name="T">Return type</typeparam>
	public class ReturnValue<T> : ReturnValue {

		/// <summary>
		/// The original return value.
		/// </summary>
		public T OriginalValue { get; private set; }

		/// <summary>
		/// The modified value of what will be returned.
		/// This is null or default(T) if not set.
		/// </summary>
		public T CustomValue { get; private set; }

		/// <summary>
		/// Creates a new ReturnValue instance with
		/// the original value.
		/// </summary>
		/// <param name="originalValue">The default return value</param>
		public ReturnValue (T originalValue) {
			this.OriginalValue = originalValue;
		}

		/// <summary>
		/// Sets a new custom return value.
		/// </summary>
		/// <param name="value">The modified return value.</param>
		public void SetValue (T value) {
			this.CustomValue = value;
			this.IsSet = true;
		}

		/// <summary>
		/// Sets the reference value to custom value if it is set.
		/// </summary>
		/// <param name="referenceValue">The reference value</param>
		public void UpdateReferenceValue (ref T referenceValue) {
			if (IsSet) {
				referenceValue = CustomValue;
			}
		}

	}
}
