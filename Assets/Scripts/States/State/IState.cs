namespace F3Lib.Patterns.State
{
    public interface IState<TTrigger>
    {
        IStateMachine<TTrigger, IState<TTrigger>> StateMachine { get; set; }
        void Execute();
        void SetData(ITransitionalData data);
    }
}