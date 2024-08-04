# VariableUtils

`VariableUtils` is a C# library for managing variables with change tracking, cloning, resetting, and JSON serialization capabilities.

## Features

- **Change Notification**: Listen for changes with `OnValueChanged` event.
- **Cloning**: Create copies of variables with the `Clone` method.
- **Resetting**: Reset variables to their default values.
- **Serialization**: Serialize and deserialize variables to and from JSON.
-  **Thread-Safety**: Ensure safe concurrent access to the variable with built-in locking mechanisms.

## Installation with UPM
1. **Open Your Unity Project**: Launch your Unity project in the Unity Editor.

2. **Open the Package Manager**:
   - Go to `Window` > `Package Manager`.

3. **Add the Package**:
   - Click the `+` button in the top-left corner of the Package Manager window.
   - Select `Add package from git URL...`.

4. **Enter the Repository URL**:
   - In the prompt that appears, enter the Git URL of the `VariableUtils` package. For example:
     ```
     https://github.com/YourUsername/VariableUtils.git
     ```
   - Click `Add`.

5. **Confirm the Installation**:
   - Unity will now download and install the package. You should see `VariableUtils` listed in the Package Manager once the installation is complete.

6. **Verify the Installation**:
   - Check the `Packages` folder in your Unity project's `Assets` directory to ensure the `VariableUtils` package has been added successfully.



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
