Beautifully simple WPF notification box which can be thought of as similar way to MessageBox
It requires a Grid object in the xaml to wrap around the rest of the xaml document or at least the parts where you would like the notifications to be displayed.
If you wrap a whole window document with a Grid as shown in the below example then notification will appear centre of window.

```xaml
<Window xmlns:WpfUserControls="clr-namespace:WpfUserControls;assembly=WpfUserControls">
<Grid x:Name="Main">
//Put the rest of your xaml in here
</Grid>
</Window>
```

To call the notification box you use this syntax in the c# behind your xaml

```c#
//Requires a parent Grid to attach to. In this case Grid is named Main.

//Simple example
Main.Children.Add(new MomentaryNotification("Simple notification"));

//Full constructor example : no acknowledgement required
SolidColorBrush borderBrush = new SolidColorBrush(Colors.Red);
SolidColorBrush backgroundBrush = new SolidColorBrush(Colors.Red);
SolidColorBrush foregroundBrush = new SolidColorBrush(Colors.Red);
var sender = this;
Main.Children.Add(new MomentaryNotification("displayText", false, 2, 4, 400, 200, new Thickness (10, 5, 5, 10), borderBrush, backgroundBrush, foregroundBrush, sender));

//Example opens the notification with a red border. The border is wider on the left as the thickness(50, 2, 2, 2) suggests.
//The bool true means that the notification requires acknowledgement via mousedown or keyup.
//1.5 second display and fade times, sized 400x100
//border colour is red
SolidColorBrush border = new SolidColorBrush(Colors.Red);
Main.Children.Add(new MomentaryNotification("This is a notification window", true, 1.5, 1.5, 400, 100, new Thickness(50, 2, 2, 2), border));
```
