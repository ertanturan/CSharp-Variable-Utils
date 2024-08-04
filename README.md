# VariableUtils

`VariableUtils` is a C# library for managing variables with change tracking, cloning, resetting, and JSON serialization capabilities.

## Features

- **Change Notification**: Listen for changes with `OnValueChanged` event.
- **Cloning**: Create copies of variables with the `Clone` method.
- **Resetting**: Reset variables to their default values.
- **Serialization**: Serialize and deserialize variables to and from JSON.

## Usage

### Example

```csharp
using System;
using VariableUtils;

class Program
{
    static void Main()
    {
        var intVariable = new IntVariable(10);

        intVariable.OnValueChanged += (sender, args) =>
        {
            Console.WriteLine($"Value changed from {args.PreviousValue} to {args.Value}");
        };

        intVariable.Value = 20;
    }
}
```
### Serialization
```csharp
var json = intVariable.Serialize();
var deserializedVariable = new IntVariable().Deserialize(json);
```
## Available Variable Types
Primitive Types: IntVariable, FloatVariable, StringVariable, etc.
Complex Types: Vector2Variable, ColorVariable, etc.
Collection Types: ListVariable<T>, DictionaryVariable<TKey, TValue>, etc.
# Dependencies
Newtonsoft.Json: For JSON operations.
