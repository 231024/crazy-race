using VContainer;
using VContainer.Unity;

namespace CTPK
{
	public class MenuPresenter : IStartable
	{
		[Inject] private MenuView _view;

		public void Start()
		{
		}
	}
}
