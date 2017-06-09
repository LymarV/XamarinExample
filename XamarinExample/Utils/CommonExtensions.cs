using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace XamarinExample
{
	public static class CommonExtensions
	{
		public static bool InRange (this IList collection, int index)
		{
			return index >= 0 && index < collection.Count;
		}

		public static bool InRange<T> (this T[] collection, int index)
		{
			return index >= 0 && index < collection.Length;
		}

		/// <summary>
		/// Returns ConfiguredTaskAwaitable delay for given time to force context switch
		/// </summary>
		/// <param name="milliseconds">Milliseconds.</param>
		public static ConfiguredTaskAwaitable ConfigureAwaitDelay (this int milliseconds)
		{
			return Task.Delay (10).ConfigureAwait (false);
		}
	}
}
