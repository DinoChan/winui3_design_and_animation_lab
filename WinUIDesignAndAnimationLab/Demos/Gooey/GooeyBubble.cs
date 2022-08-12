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