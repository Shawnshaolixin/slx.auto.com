using System;

namespace Hello
{
    /// <summary>
    /// 观察者，钓鱼的人
    /// </summary>
    public class FishingMan
    {
        public string Name { get; set; }
        public int FishCount { get; set; }
        /// <summary>
        /// 鱼竿，钓鱼的人 必须得有鱼竿啊
        /// </summary>
        public FishingRod FishingRod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public void Fishing()
        {
            this.FishingRod.ThrowHook(this);
        }
        public void Update(FishType type)
        {
            FishCount++;
            Console.WriteLine("{0}：钓到一条[{2}]，已经钓到{1}条鱼了！", Name, FishCount, type);
        }
    }

}
