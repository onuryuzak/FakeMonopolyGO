namespace MyGame.Core.Services
{
    public interface IObserver<T>
    {
        void OnUpdated(T data);
    }
}