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

		private T _value;
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
}