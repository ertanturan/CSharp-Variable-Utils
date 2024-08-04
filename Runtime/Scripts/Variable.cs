// Created by : Ertan TURAN
// Created : 04 / 08 / 2024
// Last change : 04 / 08 / 2024
// File Name : Variable.cs
// Project Name : VariableUtils

using System;
using System.Collections.Generic;
using UnityEngine;

namespace VariableUtils
{
	public class Variable<T> : IVariable<T>
	{
		public event EventHandler<VariableChangeEventArgs<T>> OnValueChanged;
		private readonly VariableChangeEventArgs<T> _eventArgs = new();

		public string VariableName
		{
			get;
			set;
		}

		public T Value
		{
			get => _value;
			set
			{
				if (!EqualityComparer<T>.Default.Equals(_value, value))
				{
					_eventArgs.Value = _value;
					OnValueChanged?.Invoke(this, _eventArgs);
				}
			}
		}

		private readonly T _value;

		protected Variable(T initialValue = default(T))
		{
			_value = initialValue;
		}

		public Variable<T> Clone()
		{
			return new Variable<T>(Value);
		}
	}

	public class FloatVariable : Variable<float>
	{
	}

	public class IntVariable : Variable<int>
	{
	}

	public class DoubleVariable : Variable<double>
	{
	}

	public class StringVariable : Variable<string>
	{
	}

	public class BoolVariable : Variable<bool>
	{
	}

	public class Vector2Variable : Variable<Vector2>
	{
	}

	public class Vector3Variable : Variable<Vector3>
	{
	}

	public class ColorVariable : Variable<Color>
	{
	}

	public class QuaternionVariable : Variable<Quaternion>
	{
	}

	public class RectVariable : Variable<Rect>
	{
	}

	public class BoundsVariable : Variable<Bounds>
	{
	}

	public class Matrix4X4Variable : Variable<Matrix4x4>
	{
	}


	public class DecimalVariable : Variable<decimal>
	{
	}

	public class DateTimeVariable : Variable<DateTime>
	{
	}

	public class TimeSpanVariable : Variable<TimeSpan>
	{
	}

	public class GuidVariable : Variable<Guid>
	{
	}

	public class UriVariable : Variable<Uri>
	{
	}

	public class TupleVariable<T1, T2> : Variable<Tuple<T1, T2>>
	{
	}

	public class KeyValuePairVariable<TKey, TValue> : Variable<KeyValuePair<TKey, TValue>>
	{
	}

	public class ListVariable<T> : Variable<List<T>>
	{
	}

	public class DictionaryVariable<TKey, TValue> : Variable<Dictionary<TKey, TValue>>
	{
	}

	public class HashSetVariable<T> : Variable<HashSet<T>>
	{
	}

	using System;

	public class ByteVariable : Variable<byte>
	{
	}

	public class LongVariable : Variable<long>
	{
	}

	public class SByteVariable : Variable<sbyte>
	{
	}

	public class UShortVariable : Variable<ushort>
	{
	}

	public class UIntVariable : Variable<uint>
	{
	}

	public class ULongVariable : Variable<ulong>
	{
	}

	public class ShortVariable : Variable<short>
	{
	}

	public class CharVariable : Variable<char>
	{
	}

	public class ObjectVariable : Variable<object>
	{
	}

	public class UIntPtrVariable : Variable<UIntPtr>
	{
	}

	public class IntPtrVariable : Variable<IntPtr>
	{
	}
}