namespace Assets.Script
{
    public interface ITrigger
    {
        
    }

    public interface IResponder
    {
        void Respond(ITrigger trigger);
    }
}