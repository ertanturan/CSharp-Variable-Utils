// Created by : Ertan TURAN
// Created : 04 / 08 / 2024
// Last change : 04 / 08 / 2024
// File Name : Variable.cs
// Project Name : VariableUtils

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace VariableUtils
{
	public class Variable<T> : IVariable<T>
	{
		public event EventHandler<VariableChangeEventArgs<T>> OnValueChanged;
		private readonly VariableChangeEventArgs<T> _eventArgs = new();
		private readonly object _lock = new();
		private readonly IEqualityComparer<T> _comparer;

		private readonly Formatting _jsonFormatting;

		public string VariableName
		{
			get;
			set;
		}

		public T Value
		{
			get
			{
				lock (_lock)
				{
					return _value;
				}
			}
			set
			{
				lock (_lock)
				{
					if (!_comparer.Equals(_value, value))
					{
						_eventArgs.PreviousValue = _value;
						_value = value;
						_eventArgs.Value = _value;
						OnValueChanged?.Invoke(this, _eventArgs);
					}
				}
			}
		}

		private T _value;

		public Variable()
		{
			_value = default(T);
			_jsonFormatting = Formatting.None;
			_comparer = EqualityComparer<T>.Default;
		}

		public Variable(T initialValue = default(T))
		{
			_value = initialValue;
		}

		public Variable(T initialValue = default(T), Formatting jsonFormatting = Formatting.None) : this(initialValue)
		{
			_jsonFormatting = jsonFormatting;
		}

		public Variable(T initialValue = default(T), IEqualityComparer<T> comparer = null) : this(initialValue)
		{
			_comparer = comparer ?? EqualityComparer<T>.Default;
		}

		public Variable(T initialValue = default(T), Formatting jsonFormatting = Formatting.None,
		                IEqualityComparer<T> comparer = null) : this(initialValue, jsonFormatting)
		{
			_comparer = comparer ?? EqualityComparer<T>.Default;
		}

		public Variable<T> Clone()
		{
			lock (_lock)
			{
				return new Variable<T>(Value, _comparer);
			}
		}

		public void Reset()
		{
			lock (_lock)
			{
				Value = default(T);
			}
		}

		/// <summary>
		///     Json serialization. Make sure all fields are serializable
		/// </summary>
		/// <returns>Json</returns>
		public virtual string Serialize()
		{
			lock (_lock)
			{
				return JsonConvert.SerializeObject(this, _jsonFormatting);
			}
		}

		/// <summary>
		///     Json de-serialization. Make sure all fields are serializable
		/// </summary>
		/// <param name="jsonString"></param>
		/// <returns>De-serialized type value</returns>
		public virtual Variable<T> Deserialize(string jsonString)
		{
			return JsonConvert.DeserializeObject<Variable<T>>(jsonString);
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
}