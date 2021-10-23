# GetCharFromKey

## Usage Example:

```
private void Application_PreviewKeyDown(object sender, KeyEventArgs e)
  {
    char ch = Keyboard.GetCharFromKey(e.Key);
    Console.Writeline("Character keyed was: " + ch.ToString());
  }
```

Returns 'char' from a keyboard key or key combination.

When using WPF and C# there is no native method to recognise which character has been typed on a keyboard. I stumbled across this issue when trying to capture the % character input.

It would have been very easy to capture Shift + D5 as I was using a UK keyboard, but bugs would be present in the software if any other keyboard locale was in use which placed the % character in a different location.

*I can not take credit for this beautifully functioning extention class, but I can say that it works very well.*
