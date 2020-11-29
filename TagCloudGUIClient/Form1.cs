﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CloudLayouters;
using TagCloudCreator;

namespace TagCloud
{
    public partial class Form1 : Form
    {
        private Bitmap image;
        private readonly List<BaseCloudLayouter> layouters;
        private readonly CloudPrinter cloudPrinter;

        public Form1(TableLayoutPanel table,CloudPrinter cloudPrinter , IEnumerable<BaseCloudLayouter> layouters)
        {
            this.layouters = layouters.ToList();
            layouter = this.layouters[0];
            this.table = table;
            this.cloudPrinter = cloudPrinter;
            InitializeComponent();
        }
    }
}