namespace _Project.AI.Core
{
    public interface INeed
    {
        float Amount(IActorContext context, IWorldContext world);
        bool IsAccomplished(IActorContext context, IWorldContext world);
    }
}