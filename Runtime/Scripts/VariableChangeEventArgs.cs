// Created by : Ertan TURAN
// Created : 04 / 08 / 2024
// Last change : 04 / 08 / 2024
// File Name : VariableChangeEventArgs.cs
// Project Name : VariableUtils

using System;

namespace VariableUtils
{
	public class VariableChangeEventArgs<T> : EventArgs
	{
		public T PreviousValue { get; set; }
		public T Value { get; set; }
	}
}