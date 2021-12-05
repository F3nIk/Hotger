namespace F3Lib.Patterns.State
{
    public interface ITransition<TTrigger, TState> where TState : IState<TTrigger>
    {
        ITransition<TTrigger, TState> Bind(TTrigger command, TState state);
        ITransition<TTrigger, TState> ToSelf(TTrigger command);
        ITransition<TTrigger, TState> SetData(ITransitionalData data);
        TState GetState();
        TState GetTarget();

    }

    public interface ITransitionalData
    {

    }
}