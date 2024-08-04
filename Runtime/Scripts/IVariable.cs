using System;

namespace VariableUtils
{
	public interface IVariable : IVariableValueChanged
	{
		public string VariableName { get; set; }
	}

	public interface IVariable<T> : IVariable
	{
		public T Value { get; set; }
	}

	public interface IVariableValueChanged
	{
	}

	public interface IVariableValueChanged<T> : IVariableValueChanged
	{
		event EventHandler<VariableChangeEventArgs<T>> OnValueChanged;
	}
}