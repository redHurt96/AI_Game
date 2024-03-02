namespace _Project.AI.Core
{
    public interface INeed
    {
        bool ShouldWorriedAbout(IActorContext context, IWorldContext world);
        float Amount(IActorContext context, IWorldContext world);
        bool IsAccomplished(IActorContext context, IWorldContext world);
    }
}