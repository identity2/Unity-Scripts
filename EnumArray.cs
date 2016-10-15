using System;

//an array that uses enum for indexing
public class EnumArray<T, E> where E:struct
{
	private T[] array;
	private Func<E, int> convert;
	public int Length { get { return array.Length; } }

	public EnumArray(int size, Func<E, int> conversionMethod)
	{
		this.convert = conversionMethod;
		this.array = new T[size];
	}

	public T this[E index] {
		get {
			return this.array [this.convert (index)];
		}
		set {
			this.array [this.convert (index)] = value;
		}
	}
}
