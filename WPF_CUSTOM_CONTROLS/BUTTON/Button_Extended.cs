using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCustomControls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPF_CUSTOM_CONTROLS"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPF_CUSTOM_CONTROLS;assembly=WPF_CUSTOM_CONTROLS"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class Button_Extended : Button
    {
        private Object? _boundObject;
        public Object? boundObject { get { return _boundObject; } set { _boundObject = value; } }
        public Object? BoundObject() { return _boundObject; }
        public void BoundObject(Object? obj) { _boundObject = obj; }

        private int _integerValue;
        public int integerValue { get { return _integerValue; } set { _integerValue = value; } }
        public int IntegerValue() { return _integerValue; }
        public void IntegerValue(int intVal) { _integerValue = intVal; }

        static Button_Extended()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Button_Extended), new FrameworkPropertyMetadata(typeof(Button_Extended)));
        }
    }
}
