using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundedButton
{
    public partial class RoundedButton : Component
    {
        public RoundedButton()
        {
            InitializeComponent();
        }

        public RoundedButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
