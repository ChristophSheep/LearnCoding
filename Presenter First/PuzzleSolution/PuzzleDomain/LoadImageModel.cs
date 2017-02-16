using System.Drawing;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace org.Puzzle
{
    public class LoadImageModel : EventSender, ILoadImageModel
    {
        private string m_imageName;

        public event EventDelegate ImageListChangedEvent;

        public event EventDelegate StartEvent;

        public event EventDelegate FinishEvent;

        /// <summary>
        /// SubscribeImageListChanged
        /// </summary>
        /// <param name="listener"></param>
        public void SubscribeImageListChanged(EventDelegate listener)
        {
            ImageListChangedEvent += listener;
        }

        /// <summary>
        /// SubscribeStart
        /// </summary>
        /// <param name="listener"></param>
        public void SubscribeStart(EventDelegate listener)
        {
            StartEvent += listener;
        }

        /// <summary>
        /// SubscribeFinish
        /// </summary>
        /// <param name="listener"></param>
        public void SubscribeFinish(EventDelegate listener)
        {
            FinishEvent += listener;
        }

        /// <summary>
        /// LoadImage
        /// </summary>
        /// <returns></returns>
        public Image LoadImage()
        {
            FireEvent(ImageListChangedEvent);

            FireEvent(StartEvent);

            if (m_imageName.Equals("Carl"))
            {
                return Image.FromFile("../../Images/ce.bmp");
            }
            else if (m_imageName.Equals("USS Enterprise"))
            {
                return Image.FromFile("../../Images/USS Enterprise.jpg");
            }
            return Image.FromFile("../../Images/Numbered.jpg");
        }

        /// <summary>
        /// SetImageName
        /// </summary>
        /// <param name="name"></param>
        public void SetImageName(string name)
        {
            m_imageName = name;
            FireEvent(FinishEvent);
        }

        /// <summary>
        /// GetImageNames
        /// </summary>
        /// <returns></returns>
        public string[] GetImageNames()
        {
            return new[] {"Carl", "USS Enterprise", "Geeks"};
        }
    }
}