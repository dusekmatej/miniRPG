namespace miniRPG.RenderUI.Screens;

public interface IScreen
{
    public void Render();
    public void SelectNext();
    public void SelectPrevious();
    public IScreen ConfirmSelection();
}