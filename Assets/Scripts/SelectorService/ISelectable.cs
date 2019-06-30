namespace SelectorService
{
    public interface ISelectable
    {
        bool IsSelectable { get; set; }
        void MouseOver();
        void OnClick();
    }
}