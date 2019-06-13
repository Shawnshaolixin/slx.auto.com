namespace Hello
{
    /// <summary>
    /// 鱼竿，被观察者
    /// </summary>
    public class FishingRod
    {
        public delegate void FishingHandler(FishType type);//声明委托
        public event FishingHandler FishingEvent;//声明事件
        public void ThrowHook(FishingMan man)
        {

        }

    }
}
