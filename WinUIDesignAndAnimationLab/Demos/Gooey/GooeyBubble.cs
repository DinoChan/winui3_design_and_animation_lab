using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUIDesignAndAnimationLab.AnimationTimelines;

namespace WinUIDesignAndAnimationLab.Demos.Gooey
{
    public class GooeyBubble
    {
        public DoubleTimeline OffsetTimeline { get; set; }
        public DoubleTimeline SizeTimeline { get; set; }
        public double X { get; set; }
    }

}
