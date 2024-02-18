namespace _Project.AI.Core
{
    public interface IActor
    {
        void Act(float delta);
        IActor Copy();
    }
}