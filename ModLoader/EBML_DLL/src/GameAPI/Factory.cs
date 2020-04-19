using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBML {

	public abstract class Factory<T> where T : Factory<T> {

		public static T Instance { get; private set; }

		static Factory () {
			Instance = Activator.CreateInstance<T> ();
		}

		protected Factory () {}

	}

}
