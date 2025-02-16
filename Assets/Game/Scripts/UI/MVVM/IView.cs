namespace Game.Scripts.MVVM
{
    public interface IView
    {
        public void Bind(ViewModel viewModel);
        public void Unbind();
    }
}