# binary
C# Library for working with binary numbers

## Usage Examples:
### Instance without arguments
```
Binary bin = new Binary();
bin.Value = "11011010";
```
### Instance with arguments
```
Binary bin1 = new Binary("11011010");
Binary bin2 = Binary.ToBinary(218);
// bin1 and bin2 are equal
```
### Using methods on instance
```
Binary bin = new Binary("11011010");
decimal dec = bin.ToDecimal();
```
### Use static functions
```
Binary bin1 = new Binary("11011010");
decimal dec = Binary.ToDecimal(bin1);
decimal dec = Binary.ToDecimal("11011010");
```

*Suggested future additions to this would be to add functions & methods for binary mathematics.*
