namespace wsm.Puzzle
{
	public class LoadImagePresenter
	{
	  private readonly ILoadImageView m_view;
	  private readonly ILoadImageModel m_model;

	  public LoadImagePresenter(ILoadImageModel model, ILoadImageView view)
		{
		  m_view = view;
	    m_model = model;

      m_view.SubscribeLoadCommand(new EventDelegate(SetSelectedImageInModel));

      m_model.SubscribeImageListChanged(new EventDelegate(PutImageListIntoView));
      m_model.SubscribeStart(new EventDelegate(StartDialogInView));
      m_model.SubscribeFinish(new EventDelegate(CloseDialogInView));
		}

	  private void CloseDialogInView()
	  {
      m_view.Close();
	  }

	  private void StartDialogInView()
	  {
      m_view.Start();
	  }

	  private void PutImageListIntoView()
	  {
      m_view.SetImageList(m_model.GetImageNames());
	  }

	  private void SetSelectedImageInModel()
	  {
	    m_model.SetImageName(m_view.GetSelectedImage());
	  }
	}
}
