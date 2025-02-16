namespace Game.Scripts.UI.MVVM
{
    public interface IView
    {
        public void Bind(ViewModel viewModel);
        public void Unbind();
    }
}