// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace org.Puzzle
{
    public class LoadImagePresenter
    {
        private readonly ILoadImageView m_view;

        private readonly ILoadImageModel m_model;

        public LoadImagePresenter(ILoadImageModel model, ILoadImageView view)
        {
            m_view = view;

            m_model = model;

            m_view.SubscribeLoadCommand(SetSelectedImageInModel);

            m_model.SubscribeImageListChanged(PutImageListIntoView);

            m_model.SubscribeStart(StartDialogInView);

            m_model.SubscribeFinish(CloseDialogInView);

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
            var name = m_view.GetSelectedImage();

            m_model.SetImageName(name);
        }
    }
}
