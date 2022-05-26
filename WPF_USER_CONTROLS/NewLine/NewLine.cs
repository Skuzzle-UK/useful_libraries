using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfUserControls
{
        public class NewLine : FrameworkElement
        {
            public NewLine()
            {
                Height = 0;
                var binding = new Binding
                {
                    RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(WrapPanel), 1),
                    Path = new PropertyPath("ActualWidth")
                };
                BindingOperations.SetBinding(this, WidthProperty, binding);
            }
        }
    }

