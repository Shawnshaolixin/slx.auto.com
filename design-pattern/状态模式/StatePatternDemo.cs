using System;
using System.Collections.Generic;
using System.Text;

namespace design_pattern.状态模式
{
    class StatePatternDemo
    {
        public void Init()
        {
            Context context = new Context();
            StartState startState = new StartState();
            startState.DoAction(context);

            Console.WriteLine(context.getState().ToString());
            StopState stopState = new StopState();
            stopState.DoAction(context);
            Console.WriteLine(context.getState().ToString());
        }
    }
    public interface IState
    {
        public void DoAction(Context context);
    }


    /// <summary>
    /// 开始状态
    /// </summary>
    public class StartState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("Player is in start state");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Start State";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class StopState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("Player is in stop state");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Stop State";
        }
    }

    public class Context
    {
        private IState state;
        public Context()
        {
            state = null;
        }
        public void SetState(IState state)
        {
            this.state = state;
        }
        public IState getState()
        {
            return state;
        }
    }
}
